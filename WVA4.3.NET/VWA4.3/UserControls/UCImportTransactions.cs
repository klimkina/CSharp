using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTree;
using System.Threading;
using System.Data.OleDb;
using OpenNETCF.Desktop.Communication;

namespace UserControls
{
    public partial class UCImportTransactions : UserControl, IVWAUserControlBase
    {
        private DriveDetector driveDetector = null;
        private VWA4Common.DBDetector dbDetector = null; // subscribe for db change
        private FileSystemWatcher watch = null;

		// Global flag to indicate ActiveSync Transfer from Tracker has occurred
		private bool activesyncfilescopied;
        private RAPI trackerRapi;  // handle to RAPI object - needed by more than one method
		private string trackerwastefilepath;  // string to tracker path used by ActiveSync
		private string trackerconfigauditfilepath;  // string to tracker path used by ActiveSync

        private decimal nWeightImportThreshold;
        private decimal nCostImportThreshold;

        private VWA4Common.CommonEvents commonEvents = null;
        
        public UCImportTransactions()
        {
            InitializeComponent();

            ucViewWeights1.ShowHideColumnChooser(true);
            ucViewWeights1.ConfigReportName = "Import Transactions";

            //btnOk.UseAppStyling = false;
            //btnOk.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            //btnOk.Appearance.BackColor = Color.AliceBlue;
        }


		///		
		/// Interface methods for User Controls
		///		

		public void Init(DateTime firstDayOfWeek)
		{
			_IsActive = true;
			if (commonEvents == null)
			{
				commonEvents = VWA4Common.CommonEvents.GetEvents();
				commonEvents.UpdateProductUIData +=
					new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
			}
			if (driveDetector == null)
			{
				driveDetector = new DriveDetector();
				driveDetector.DeviceArrived += new DriveDetectorEventHandler(OnDriveArrived);
				driveDetector.DeviceRemoved += new DriveDetectorEventHandler(OnDriveRemoved);
				driveDetector.QueryRemove += new DriveDetectorEventHandler(OnQueryRemove);
			}
			if (watch == null)
			{
				watch = new FileSystemWatcher();
				watch.Created += new FileSystemEventHandler(OnFileCreated);
				watch.Deleted += new FileSystemEventHandler(OnFileDeleted);
				watch.SynchronizingObject = utFileBrowser;
			}
			if (dbDetector == null)
			{
				dbDetector = VWA4Common.DBDetector.GetDBDetector();
				dbDetector.UserLogin += new VWA4Common.DBDetectorLoginEventHandler(dbDetector_UserLogin);
			}
		}

		public void SaveData()
		{
		}

		public bool ValidateData()
		{ return true; }

		public int AutoRun(string param)
		{
			return 0;
		}

		private bool _IsActive = false;
		public bool IsActive
		{
			get { return _IsActive; }
			set { _IsActive = value; }
		}
		public void LeaveSheet()
		{
			_IsActive = false;
		}



		///		
		/// Supporting Methods
		///		
		void commonEvents_UpdateProductUI(object sender, EventArgs e)
		{
			InitProductUI();
		}
		void InitProductUI()
		{
			panel1.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			panel5.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			panelFilters.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			panel4.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			panel3.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			lTaskName.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
			if (VWA4Common.GlobalSettings.ProductType == 3)
				btnOk.Appearance.BackColor = Color.Red;
			else
				btnOk.Appearance.BackColor = Color.FromArgb(110, 163, 27);
		}
		
		
		private void InitFileBrowser()
        {
            try
            {
                string[] drives = Directory.GetLogicalDrives();
                //search for VW import files - ENTIRE disk!
                //int n = 1;
                //double progressTick = (drives.Length > 0 ? 100 / drives.Length : 1);
                foreach (string drive in drives)
                {
                    //VWA4Common.ProgressDialog.SetStatus("Looking for VALUWASTE drives... ", (int)(progressTick *n++));

                    //if (VWA4Common.ProgressDialog.CancelPressed)
                    //{
                    //    VWA4Common.ProgressDialog.CancelPressed = false;
                    //    return;
                    //}

                    InitDir(drive);
                    System.IO.DriveInfo driveInfo = new System.IO.DriveInfo(drive);
                    if (driveInfo.IsReady && driveInfo.DriveType == DriveType.Removable && driveInfo.VolumeLabel.Trim().Length >= 9 &&
                        driveInfo.VolumeLabel.Trim().ToLower().Substring(0, 9) == "valuwaste")
                        InitFileWatcher(drive);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error occured in InitFileBrowser! Error raised, with message : " + ex.Message, "VWA Import File Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool InitDir(string drive)
        {
            try
            {
                ArrayList fileNames = new ArrayList();
                System.IO.DriveInfo driveInfo = new System.IO.DriveInfo(drive);
                if (driveInfo.IsReady && driveInfo.DriveType != DriveType.CDRom && driveInfo.VolumeLabel.Trim().Length >= 9 && driveInfo.VolumeLabel.Trim().ToLower().Substring(0, 9) == "valuwaste")
                    fileNames.AddRange(DirSearch(drive, VWA4Common.VWACommon.ImportFilePattern));


                if (fileNames != null)
                {
                    for (int i = 0; i < fileNames.Count; i++)
                    {
                        string fileName = fileNames[i].ToString();
                        if (utFileBrowser.GetNodeByKey(driveInfo.VolumeLabel + (driveInfo.VolumeLabel.Length > 0 ? " " : "") + fileName) != null)
                            continue;
                        if (fileName != null)
                            AddFile(fileName, true);
                    }
                }
                return (fileNames != null) && (fileNames.Count > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error occured in InitDir! Error raised, with message : " + ex.Message, "VWA Import File Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        private ArrayList DirSearch(string dir, string pattern)
        {
            ArrayList res = new ArrayList();
            try
            {
                foreach (string f in Directory.GetFiles(dir, pattern))
                    res.Add(f);

                foreach (string d in Directory.GetDirectories(dir))
                {
                    res.AddRange(DirSearch(d, pattern));
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, "Error occurred during DirSearch! Error raised, with message : " + ex.Message, "VWA Import File Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;
        }
        private void AddFile(string fileName, bool expand)
        {
            fileName = Regex.Replace(fileName, "^^[^\\s]+\\s([^\\s]+):", "$1:");
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
            string fullName = fileInfo.FullName;
            string[] directories = fullName.Split('\\');
            string prev = "";
            UltraTreeNode node, nextNode;

            System.IO.DriveInfo driveInfo = new System.IO.DriveInfo(directories[0]);
            directories[0] = driveInfo.VolumeLabel + (driveInfo.VolumeLabel.Length > 0 ? " " : "") + directories[0];
            foreach (string str in directories)
            {
                string next = prev + (prev == "" ? "" : "\\") + str;
                nextNode = utFileBrowser.GetNodeByKey(next);
                if (nextNode == null)
                {
                    node = utFileBrowser.GetNodeByKey(prev);
                    if (node != null)
                        nextNode = node.Nodes.Add(next, str);
                    else
                        nextNode = utFileBrowser.Nodes.Add(next, str);
                }
                nextNode.Expanded = expand;
                prev = next;
            }

            node = utFileBrowser.GetNodeByKey(driveInfo.VolumeLabel + (driveInfo.VolumeLabel.Length > 0 ? " " : "") + fullName);
            node.Selected = true;
            utFileBrowser.HideSelection = false;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.InitialDirectory = UserControls.VWAPath.ViewWasteImagesPath;
            dlg.Filter = "VWData (*.DAT)|*.dat|" +
                "VWDataBase (*.MDB)|*.mdb|" +
                "All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                AddFile(dlg.FileName, true);
                //utFileBrowser.GetNodeByKey(dlg.FileName).Selected = true;
                //utFileBrowser.HideSelection = false;
            }
        }

        /// <summary>
        ///  BASIC CLASS
        /// </summary>
        public void LoadData()
        {
			//btnOk.Enabled = bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Import Waste  Data"));
			btnOk.Enabled = VWA4Common.GlobalSettings.ImportWasteDataAvailable;

			///  New code for ActiveSync transfers
			///  
			bool lookforusb = true;
			activesyncfilescopied = false;  // this is a flag for indicating that temporary ActiveSync files need to be deleted on the Tracker
            try
			{
                try
                {
                    //VWA4Common.ProgressDialog.SetLeadin("Looking for Import Files");
                    //// If the ActiveSync Tracker Mode is enabled, look for the Tracker connection.
                    //int pd_left = (this.Left + (ParentForm != null ? ParentForm.Left : 0)) + this.Width / 2;
                    //int pd_top = (this.Top + (ParentForm != null ? ParentForm.Top : 0)) + this.Height / 2;
                    //VWA4Common.ProgressDialog.ShowProgressDialog("Looking for Transactions media.", "", "", pd_left, pd_top);

                    if (bool.Parse(VWA4Common.GlobalSettings.ActiveSyncTrackerTransfersOn))
                    { // ActiveSync Tracker mode is enabled - attempt to connect.
                        trackerRapi = new RAPI();
                        bool done = false;
                        while (!done)
                        {
                            if (!trackerRapi.DevicePresent)
                            {  // Tracker not present
                                if (MessageBox.Show(this, "Please connect your Tracker to this PC using the USB/ActiveSync cable, and then click OK to continue.",
                                    "ActiveSync Waste Import", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                {
                                    continue;
                                }
                                else
                                { // User cancelled
                                    if (MessageBox.Show(this, "ActiveSync Waste Import Cancelled - Look for VALUWASTE USB drive?",
                                        "ActiveSync Waste Import", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                                    { // Don't look for USB drive
                                        lookforusb = false;
                                    }
                                    done = true;
                                }
                            }
                            else
                            { // Tracker is present - copy files to local app directory in prep for import
                                //
                                // Process the transfer to local disk - application directory
                                // 
                                trackerRapi.Connect(false);
								string appdir = VWA4Common.GlobalSettings.VirtualAppDir;
                                // Copy Tracker files to app dir via RAPI
                                // waste file
                                string localpath = appdir + "\\VWT4WasteTransfer.dat";
                                trackerwastefilepath = VWA4Common.GlobalSettings.ActiveSyncTrackerTransferFolder + "\\VWT4WasteTransfer.dat";
                                if (trackerRapi.DeviceFileExists(trackerwastefilepath))
                                {
                                    this.utFileBrowser.Visible = false;
                                    trackerRapi.CopyFileFromDevice(localpath, trackerwastefilepath, true);
                                    // config audit file
                                    localpath = appdir + "\\VWT4ConfigAudit.dat";
                                    trackerconfigauditfilepath = VWA4Common.GlobalSettings.ActiveSyncTrackerTransferFolder + "\\VWT4ConfigAudit.dat";
                                    trackerRapi.CopyFileFromDevice(localpath, trackerconfigauditfilepath, true);

                                    /// Files are copied - start import process
                                    // Indicate that the files came from the Tracker
                                    activesyncfilescopied = true;  // indicates the Tracker files need to be deleted.
                                    string[] appDirs = Directory.GetFiles(appdir, VWA4Common.VWACommon.ImportFilePattern);
                                    //int n = 1;
                                    //double progressTick = (appDirs.Length > 0 ? 100 / appDirs.Length : 1);
                                    foreach (string fileName in appDirs)
                                    {
                                        //VWA4Common.ProgressDialog.SetStatus("Copying data file " + n + " of " + appDirs.Length + " to local disk... ", (int)(n * progressTick));
                                        ReadFile(fileName, true);
                                    }
                                    // Stephen todo - make sure to delete files from Tracker if import is successful
                                }
                                else
                                {
                                    MessageBox.Show("Waste import files not present on Tracker - please Transfer Waste on Tracker and then try Import Waste Data.");
                                }
                                done = true;
                                lookforusb = false;
                            }
                        }
                    }
                    // If we succeeded, then we're done; otherwise, try USB
                    if (!lookforusb)
                    {
                        btnOk.Hide();
                    }
                    else
                    // Continue - look for VALUWASTE volume label

                    //if (VWA4Common.GlobalSettings.ActiveSyncTrackerTransfersOn) //Stephen todo: also check tracker availiability && TrackerConnected && LibrariesInstalled
                    //{
                    //    //hide file browser
                    //    this.utFileBrowser.Visible = false;
                    //    //load all files from the ActiveSyncTrackerTransferFolder
                    //    foreach (string fileName in Directory.GetFiles(VWA4Common.GlobalSettings.ActiveSyncTrackerTransferFolder, VWA4Common.VWACommon.ImportFilePattern))
                    //    {
                    //        StartFileImport(fileName);
                    //    }
                    //}
                    //else

                    /// Fall through to here if we want to try standard USB transfer
                    /// 
                    {
                        InitFileBrowser();
                    }
                }
                finally
                {
                    //VWA4Common.ProgressDialog.CloseForm();
                }
            }
            catch (Exception ex)
            {
                //Note cancellation throws an exception
                MessageBox.Show(ex.Message);
            }
        }

        private void AllowImport(bool isAllow)
        {
            lblReady.Visible = isAllow;
			//btnOk.Enabled = isAllow && bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Import Waste Data"));
			btnOk.Enabled = isAllow && VWA4Common.GlobalSettings.ImportWasteDataAvailable;
			//btnCancel.Visible = btnOk.Enabled;
        }
        private void utFileBrowser_AfterSelect(object sender, SelectEventArgs e)
        {
            if (utFileBrowser.SelectedNodes.Count > 0)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(Regex.Replace(utFileBrowser.SelectedNodes[0].Key, "^[^\\s]+\\s([^\\s]+):", "$1:"));
                if (fileInfo != null && ((fileInfo.Attributes & FileAttributes.Directory) == 0))
                {
                    lblSummary.Text = PreReadInfo(fileInfo.FullName);
                    AllowImport(true);
                }
                else
                {
                    lblSummary.Text = "No file selected";
                    AllowImport(false);
                }
            }
        }
        //todo: write more complicated
        private string PreReadInfo(string fileName)
        {
            string[] fileData = null;
            int nTrans = 0, nWeights = 0, nProduce = 0;
            if (File.Exists(fileName))// Open the input file for input
            {
                AllowImport(true);

                FileInfo info = new FileInfo(fileName);
                if (info.Extension.ToLower() != ".mdb")
                {
                    fileData = File.ReadAllLines(fileName);

                    foreach (string str in fileData)
                        if (Regex.IsMatch(str, ImportData.TransferType))
                            nTrans++;
                        else if (Regex.IsMatch(str, ImportData.WasteRecordType))
                            nWeights++;
                        else if (Regex.IsMatch(str, ImportData.ProducedRecordType))
                            nProduce++;
                    ucViewWeights1.Visible = false;
                    panelFilters.Visible = false;
                    if(nTrans <= 0)
                        AllowImport(false);
                }
                else
                {
                    ucViewWeights1.DBPath = fileName;
                    ucViewWeights1.Visible = true;
                    panelFilters.Visible = true;
                    ucViewWeights1.LoadData();
                    weightFilter = errorWeightFilter = producedFilter = errorProducedFilter = "";
                    cbFilters.SelectedIndex = 0;
                }
            }
            return "Total number of Transfers: " + nTrans + Environment.NewLine + "Total number of Weight records: " + nWeights + Environment.NewLine +
                "Total number of Produced records: " + nProduce;
        }

        //Stephen todo: check how it works, I put this code in separate function
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        //private void StartFileImport(string fileName)
        //{
        //    _FileName = fileName;
        //    _IsArchive = true;
        //    progressBar1.Visible = true;
        //    progressBar1.Maximum = (int)new FileInfo(fileName).Length;
        //    btnCancel.Visible = true;
        //    btnOk.Visible = false;
        //    if (backgroundWorker1.IsBusy)
        //    {
        //        backgroundWorker1.CancelAsync();
        //        while (backgroundWorker1.IsBusy)
        //        {
        //            backgroundWorker1.CancelAsync();
        //        }
        //        backgroundWorker1.Dispose();
        //    }
        //    _TotalErrors = 0;
        //    backgroundWorker1.RunWorkerAsync();
        //}
		
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (utFileBrowser.SelectedNodes.Count > 0)
                {
                    string fileName = Regex.Replace(utFileBrowser.SelectedNodes[0].Key, "^[^\\s]+\\s([^\\s]+):", "$1:");
                    if (File.Exists(fileName))
                    {
                        nWeightImportThreshold = decimal.Parse(VWA4Common.GlobalSettings.WeightImportThreshold);
                        nCostImportThreshold = decimal.Parse(VWA4Common.GlobalSettings.CostImportThreshold);
                        FileInfo info = new FileInfo(fileName);
                        if (info.Extension.ToLower() != ".mdb")
                            ReadFile(fileName, true);                            
                        else
                            DBImport(fileName, true);
                    }
                    else
                    {
                        MessageBox.Show("Error raised with message: ", "Import Error", MessageBoxButtons.OK);
                        btnOk.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error occured! Error raised, with message : " + ex.Message, "VWA Import File Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public class TransferInfo
        {
            private string sTermID;   // Serial number up to 10 chars

            public string TermID
            {
                get { return sTermID; }
                set { sTermID = value; }
            }
            private string sTermName;

            public string TermName
            {
                get { return sTermName; }
                set { sTermName = value; }
            }
            private string sErrorMsg;

            public string ErrorMsg
            {
                get { return sErrorMsg; }
                set { sErrorMsg = value; }
            }
            private bool bSkipped;

            public bool Skipped
            {
                get { return bSkipped; }
                set { bSkipped = value; }
            }
            private int nRecNum;

            public int RecNum
            {
                get { return nRecNum; }
                set { nRecNum = value; }
            }
            private int nErrorRecNum;

            public int ErrorRecNum
            {
                get { return nErrorRecNum; }
                set { nErrorRecNum = value; }
            }

            private DateTime _Timestamp;

            public DateTime Timestamp
            {
                get { return _Timestamp; }
                set { _Timestamp = value; }
            }

            public TransferInfo(ImportTransfer transfer)
            {
                sTermID = transfer.TermID;   // Serial number up to 10 chars
                sTermName = transfer.TermName;
                sErrorMsg = transfer.ErrorMsg;
                _Timestamp = transfer.Timestamp;
                bSkipped = false;
                nRecNum = transfer.RecordsNumber;
                nErrorRecNum = transfer.IncorrectRecordsNumber;
            }

            public TransferInfo(int nNumOfRec)
            {
                bSkipped = true;
                nRecNum = nNumOfRec;
                nErrorRecNum = 0;
            }
            public override string ToString()
            {
                string skipped = "";
                if (bSkipped)
                    skipped = "was skipped - " + sErrorMsg;
                else if (nErrorRecNum == 0)
                    skipped = "- " + nRecNum + " records was imported.";
                else
                    skipped = "- " + nRecNum + " records was imported, " + nErrorRecNum + " error records.";

                return "Tracker " + sTermName + skipped + Environment.NewLine;
            }
        }
        private string GetLogFileName()
        {
            try
            {
				if (!Directory.Exists(VWA4Common.GlobalSettings.VirtualAppDir + "\\Backup\\"))
					Directory.CreateDirectory(VWA4Common.GlobalSettings.VirtualAppDir + "\\Backup\\");
				return VWA4Common.GlobalSettings.VirtualAppDir + "\\Backup\\" + "log_" + DateTime.Now.ToString("yy-MM-dd_hh-mm") + ".log";
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error occured! Error raised, with message : " + ex.Message, "VWA Create Log File Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "log.txt";
            }
        }
        private string GetBackupFileName(string sFileName, string sDateLog)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(sFileName);
            return Regex.Replace(fileInfo.Name, fileInfo.Extension, "") + sDateLog;
        }

        private const string LOGTGT = ".log", CFGAUDITTGT = "audit";
        private bool BackupFile(string sInFile, string[] fileData)
        {
            return BackupFile( sInFile, fileData, true);
        }
        private bool BackupFile(string sInFile, string[] fileData, bool isRemove)
        {
            try
            {

                // Create a backup of the waste data file (don"t if( we"re importing an archive
                // Format the date and time for the backup file name
                // Copy to a backup file
				if (!Directory.Exists(VWA4Common.GlobalSettings.VirtualAppDir + "\\ARCHIVE\\"))
					Directory.CreateDirectory(VWA4Common.GlobalSettings.VirtualAppDir + "\\ARCHIVE\\");

                string sDateLog = "_" + DateTime.Now.ToString("yy-MM-dd_hh-mm");
                string sBkFile = GetBackupFileName(sInFile, sDateLog);
				sBkFile = VWA4Common.GlobalSettings.VirtualAppDir + "\\ARCHIVE\\" + sBkFile;
                
                File.WriteAllLines(sBkFile +".dat", fileData);
                fileData = null; //release file
                File.Copy(sInFile, sBkFile + "_original.dat"); // save unmodifyed file
                File.Delete(sInFile);  // delete original file
				/// If ActiveSync, delete from Tracker also
				/// 
				if (activesyncfilescopied)
				{
					if (trackerRapi.DeviceFileExists(trackerwastefilepath))
					{
						trackerRapi.DeleteDeviceFile(trackerwastefilepath);
					}
				}
                ////remove from the tree
                if (isRemove)
                {
                    RemoveNode(sInFile);
                    lblSummary.Text = "";
                    AllowImport(false);
                }

                // if( the VWTConfigAudit.dat file exists, copy it to the archive and ) delete it.
				//string sAudIn = Regex.Replace(sInFile, LOGTGT, CFGAUDITTGT + ".dat");  // this did not work with SAR using ActiveSync transfer mode
				string sAudIn = Regex.Replace(sInFile, "WasteTransfer", "ConfigAudit");
				if (File.Exists(sAudIn))
                {
                    // Copy VWTConfigAudit.dat to the Archive directory and delete it
					// the following did not work with SAR using ActiveSync transfer mode
					//string sAudOut = Path.GetDirectoryName(Application.ExecutablePath) + "\\ARCHIVE\\" + CFGAUDITTGT + sDateLog + ".dat";
					string sAudOut = VWA4Common.GlobalSettings.VirtualAppDir + "\\ARCHIVE\\VWT4ConfigAudit_" + sDateLog + ".dat";
					File.Copy(sAudIn, sAudOut);
                    File.Delete(sAudIn);
					/// If ActiveSync, delete from Tracker also
					/// 
					if (activesyncfilescopied)
					{
						if (trackerRapi.DeviceFileExists(trackerconfigauditfilepath))
						{
							trackerRapi.DeleteDeviceFile(trackerconfigauditfilepath);
						}
					}
				}
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error occured! Error raised, with message : " + ex.Message, "VWA Import File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool bCanceled = false;
        private int SkipTransferData(string[] fileData, ref int pos, ImportTransfer transfer, ref TransferInfo transferInfo)
        {
            int numSkipped = 0;
            VWA4Common.ProgressDialog.SetHideProgressNow(true);
            if (TopMostMessageBox.Show("VWA Import File Error", "Error Reading Tracker Data. " + transfer.ErrorMsg + Environment.NewLine +
                        "Skip Tracker or Cancel all Import?", "Skip", "Cancel") == DialogResult.OK)
            {
                VWA4Common.ProgressDialog.SetHideProgressNow(false);
                int i = pos;
                double progressTick = (fileData.Length > 0 ? 90 / fileData.Length : 1);
                for (; i < fileData.Length; i++)
                {
                    string sLine = fileData[i];
                    if (sLine.Trim() != "")
                        if (Regex.IsMatch(sLine, "^" + ImportData.TransferType))
                            break;
                        else
                        {
                            fileData[i] = ""; // delete skipped data from archive file
                            numSkipped = numSkipped + 1;
                        }
                    VWA4Common.ProgressDialog.SetStatus("Importing line " + pos + " of " + fileData.Length, (int)(pos * progressTick)); //notify progress to main thread. We also pass time information in UserState to cover this property in the example.   
					//Error handling: uncomment this code if you want to test how an exception is handled by the background worker.   
					//also uncomment the mentioned attribute above to it doesn't stop in the debugger.   
					//if (i == 34)   
					//    throw new Exception("something wrong here!!");   

					//if cancellation is pending, cancel work.   
                    if (VWA4Common.ProgressDialog.CancelPressed)
					{
						return 0;
					}   
                }
                VWA4Common.ProgressDialog.SetHideProgressNow(false);
                _logFile.Write("Error reading Tracker " + transfer.TermName + " Data line# " + pos + ": " + transfer.ErrorMsg +
                    numSkipped + " records for tracker was skipped." + Environment.NewLine);
                transferInfo.ErrorRecNum = numSkipped;
                //"Error reading Tracker " + transfer.TermName + " Data: " + 
                transferInfo.ErrorMsg = transfer.ErrorMsg + Environment.NewLine +
                    numSkipped + " records for tracker was skipped." + Environment.NewLine;
                transferInfo.TermID = transfer.TermID;
                transferInfo.TermName = transfer.TermName;
                pos = i; 
            }
            else
                bCanceled = true;
            return numSkipped;
        }

        private int ReadTransferRecords(string[] fileData, ref int pos, ImportTransfer transfer, ref int nErrorRec)
        {
            ImportWeight rec = new ImportWeight();
            nErrorRec = 0;
            int numRec = 0;
            int i = pos;
            numRec = ReadWeights(fileData, ref i, transfer, ref nErrorRec, ImportData.ProducedRecordType); // read produced records first
            numRec += ReadWeights(fileData, ref pos, transfer, ref nErrorRec, ImportData.WasteRecordType);
            
            return numRec;
        }
        private int ReadWeights(string[] fileData, ref int pos, ImportTransfer transfer, ref int nErrorRec, string type)
        {
            ImportWeight rec;
            int numRec = 0;
            int i = pos;
            double progressTick = (fileData.Length > 0 ? 90 / fileData.Length : 1);
            //todo: save produced data first to prevent not existed lot numbers
            for (; i < fileData.Length; i++)
            {
                VWA4Common.ProgressDialog.SetStatus("Importing line " + i + " of " + fileData.Length, (int)(i * progressTick));
                if (VWA4Common.ProgressDialog.CancelPressed)
                {
                    VWA4Common.ProgressDialog.CancelPressed = false;
                    return 0;
                }
                string sLine = fileData[i];
                if (sLine.Trim() != "")
                {
                    if (Regex.IsMatch(sLine, "^" + type))
                    {
                        rec = new ImportWeight();
                        if (rec.Init(sLine, transfer, _connTransaction, _transaction))
                        {
                            if (!rec.Check(_connTransaction, _transaction)) //duplicate in Error table
                            {
                                if (MessageBox.Show(null, "Duplicate in Error table" + Environment.NewLine +
                                    "Do you want to Delete error record or skip current record?",
                                    "VWA Import File", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    if (rec.IsProduced)
                                        VWA4Common.DB.Delete("DELETE FROM ErrorWeightsProduced " +
                                        " WHERE LotNumber = '" + rec.LotNumber + "'", _connTransaction, _transaction);
                                    else
                                       VWA4Common.DB.Delete("DELETE FROM ErrorWeights  " +
                                            " WHERE Timestamp = #" + VWA4Common.VWACommon.DateToString(rec.Timestamp) + "#" +
                                            " AND TransKey IN (SELECT TransKey FROM Transfers WHERE TermID = '" + transfer.TermID + "')", 
                                            _connTransaction, _transaction);
                                    _logFile.Write("Duplicate for Line#: " + i + " from Error table was deleted" + Environment.NewLine);
                                }
                                else
                                {
                                    _logFile.Write("Duplicate Error" + type + " record" + rec.ToString() + " was skipped for record from " + rec.Timestamp +
                                    " for transfer terminal " + transfer.TermName + Environment.NewLine);
                                    fileData[i] = "";  // delete skipped data from archive file
                                    continue;
                                }
                            }
                            if (VWA4Common.VWACommon.NotNullOrEmpty(rec.ErrorMsg))
                                _logFile.Write("Record Line #" + i + ":" + Environment.NewLine + rec.ErrorMsg + Environment.NewLine);
                            if (VWA4Common.VWACommon.NotNullOrEmpty(rec.WarningMsg))
                                _logFile.Write("Record Line #" + i + ":" + Environment.NewLine + rec.WarningMsg + Environment.NewLine);
                            if (rec.IsCorrect())
                            {
                                if (nWeightImportThreshold > 0 && rec.GetWeight() > nWeightImportThreshold)
                                {
                                    rec.AddWarning("Waste Weight is above a Weight Import Threshold");
                                    VWA4Common.ProgressDialog.SetHideProgressNow(true);
                                    MessageBox.Show("Waste Weight is above a Weight Import Threshold");
                                    VWA4Common.ProgressDialog.SetHideProgressNow(false);
                                }
                                if (nCostImportThreshold > 0 && rec.GetTotalCost() > nCostImportThreshold)
                                {
                                    rec.AddWarning("Waste Cost is above a Cost Import Threshold");
                                    VWA4Common.ProgressDialog.SetHideProgressNow(true);
                                    MessageBox.Show("Waste Cost is above a Cost Import Threshold");
                                    VWA4Common.ProgressDialog.SetHideProgressNow(false);
                                }
                                rec.DBSave(_connTransaction, _transaction, true);
                                numRec++;
                            }
                            else
                            {
                                rec.DBSaveError(_connTransaction, _transaction, true);
                                nErrorRec++;
                            }
                        }
                        else // it was duplicate and we skip it
                        {
                            _logFile.Write("Duplicate " + type + " record " + rec.ToString() + " was skipped for record from " + rec.Timestamp +
                                " for transfer terminal " + transfer.TermName + Environment.NewLine);
                            fileData[i] = "";  // delete skipped data from archive file
                        }

                        

                    }
                    else if (Regex.IsMatch(sLine, "^" + ImportData.TransferType))
                        break; // next transfer record
                }
                //else
                //    progressBar1.PerformStep();
            }
            pos = i;
            return numRec;
        }

        private delegate bool ShowEditTransferHandler(ref ImportTransfer transfer);

        private bool ShowEditTransfer(ref ImportTransfer transfer)
        {
            try
            {
                EditTransfer frm = new EditTransfer(transfer);
                if (frm.InvokeRequired)
                    frm.Invoke(new ShowEditTransferHandler(ShowEditTransfer), new object[] { transfer });
                else
                {
                    VWA4Common.ProgressDialog.SetHideProgressNow(true);
                    frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        _logFile.Write(transfer.ToString() + " - Transfer record was edited" + Environment.NewLine); // write previous error to log file
                        transfer = frm.Transfer;
                        _logFile.Write(transfer.ToString() + " - New transfer record" + Environment.NewLine); // write previous error to log file
                        VWA4Common.ProgressDialog.SetHideProgressNow(false);
                        return true;
                    }
                    VWA4Common.ProgressDialog.SetHideProgressNow(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error occured! Error raised, with message : " + ex.Message, "VWA Import File Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        // returns  true if record was edited
        private bool EditTransfer(ref ImportTransfer transfer)
        {
            VWA4Common.ProgressDialog.SetHideProgressNow(true);
            if (TopMostMessageBox.Show("VWA Import File", "Error in tracker record. " + transfer.ErrorMsg + Environment.NewLine +
                "Do you want to edit tracker data or skip weight data related to this tracker?", "Edit", "Skip") == DialogResult.OK)
            {
                return ShowEditTransfer(ref transfer);
                //EditTransfer frm = new EditTransfer(transfer);
                //frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    _logFile.Write(transfer.ToString() + " - Transfer record was edited" + Environment.NewLine); // write previous error to log file
                //    transfer = frm.Transfer;
                //    _logFile.Write(transfer.ToString() + " - New transfer record" + Environment.NewLine); // write previous error to log file
                //    VWA4Common.ProgressDialog.SetHideProgressNow(false);
                //    return true;
                //}
            }
            VWA4Common.ProgressDialog.SetHideProgressNow(false);
            return false;
        }

        private StreamWriter _logFile;
        System.Data.OleDb.OleDbConnection _connTransaction;
        OleDbTransaction _transaction;

        private void ReadFile(string FileName, bool ArchiveFileFlag)
        {
            int totalSuccess = 0;
            int totalErrors = 0;
            int num, nErrorRec = 0;
            string sResult = "";
            string[] fileData = null;
            bCanceled = false;
            ArrayList transferData = new ArrayList();
            try
            {
                int pd_left = (this.Left + (ParentForm != null ? ParentForm.Left : 0)) + this.Width / 2;
                int pd_top = (this.Top + (ParentForm != null ? ParentForm.Top : 0)) + this.Height / 2;

                VWA4Common.ProgressDialog.SetLeadin("Importing File");
                VWA4Common.ProgressDialog.ShowProgressDialog("Reading File data...", "", "", pd_left, pd_top);
                //todo: save produced data first to prevent not existed lot numbers



                if (File.Exists(FileName))// Open the input file for input
                    fileData = File.ReadAllLines(FileName);

                if (fileData != null)
                {
                    double progressTick = (fileData.Length > 0 ? 90 / fileData.Length : 1);
                    _connTransaction = new System.Data.OleDb.OleDbConnection(VWA4Common.AppContext.WasteConnectionString);
                    _connTransaction.Open();
                    _transaction = _connTransaction.BeginTransaction();

                    //todo: get path from settings, create dir if not exists
                    using (FileStream fs = new FileStream(GetLogFileName(), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                    {
                        try
                        {
                            //VWA4Common.ProgressDialog.SetLeadin("Importing File");
                            //VWA4Common.ProgressDialog.ShowProgressDialog("Reading File data...", "", "", pd_left, pd_top);

                            _logFile = new StreamWriter(fs);
                            _logFile.AutoFlush = true;
                            if (!fs.CanWrite)
                                MessageBox.Show(this, "Error occured! Can't write to log file ", "VWA Log File Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                            ImportTransfer transfer = new ImportTransfer();
                            int pos = 0;

                            while ((pos < fileData.Length) && !bCanceled)
                            {
                                VWA4Common.ProgressDialog.SetStatus("Reading line " + pos + " of " + fileData.Length, (int)(pos * progressTick));
                                if (VWA4Common.ProgressDialog.CancelPressed)
                                {
                                    VWA4Common.ProgressDialog.CancelPressed = false;
                                    return;
                                }
                                string sLine = fileData[pos];
                                pos = pos + 1;

                                if (sLine.Trim() != "")    // skip empty strings
                                {
                                    TransferInfo transferInfo = new TransferInfo(0);

                                    if (transfer.Init(sLine, _connTransaction, _transaction))// no duplicates
                                    {
                                        transfer.Check(_connTransaction, _transaction);
                                        // write to log-file
                                        if (VWA4Common.VWACommon.NotNullOrEmpty(transfer.ErrorMsg))
                                            _logFile.Write(transfer.ErrorMsg + Environment.NewLine);
                                        if (VWA4Common.VWACommon.NotNullOrEmpty(transfer.WarningMsg))
                                            _logFile.Write(transfer.WarningMsg + Environment.NewLine);
                                        if (transfer.IsCorrect())
                                        {
                                            transfer.DBSave(_connTransaction, _transaction, true);
                                            num = ReadTransferRecords(fileData, ref pos, transfer, ref nErrorRec);
                                            transfer.RecordsNumber = num;
                                            transfer.IncorrectRecordsNumber = nErrorRec;
                                            transferInfo = new TransferInfo(transfer);
                                        }
                                        else
                                        {
                                            if (EditTransfer(ref transfer))
                                            {
                                                pos = pos - 1;
                                                fileData[pos] = transfer.ToString(); // rewrite transfer data and process again
                                                continue; // to not add transfer info
                                            }
                                            else
                                                SkipTransferData(fileData, ref pos, transfer, ref transferInfo);
                                        }
                                    }
                                    else  // duplicate transfer record
                                        SkipTransferData(fileData, ref pos, transfer, ref transferInfo);

                                    transferData.Add(transferInfo);
                                }
                            }

                            if (!bCanceled)
                            {
                                // show import result
                                for (pos = 0; pos < transferData.Count; pos++)
                                {
                                    sResult = sResult + ((TransferInfo)transferData[pos]).ToString() + Environment.NewLine;
                                    totalSuccess = totalSuccess + ((TransferInfo)transferData[pos]).RecNum;
                                    totalErrors = totalErrors + ((TransferInfo)transferData[pos]).ErrorRecNum;
                                }
                                sResult = totalSuccess + " records from " + transferData.Count + " transfers were imported successfully." + Environment.NewLine +
                                totalErrors + "  records were imported with errors" + Environment.NewLine + sResult;
                                VWA4Common.ProgressDialog.SetHideProgressNow(true);
                                if (TopMostMessageBox.Show("VWA Import File", sResult + Environment.NewLine + "Save or Cancel input?", "Save", "Cancel") == DialogResult.Cancel)
                                    bCanceled = true;
                                //else
                                //    _logFile.Write("Saving approved by user: " + VWA4Common.VWACommon.DateToString(DateTime.Now) + Environment.NewLine);
                                VWA4Common.ProgressDialog.SetHideProgressNow(false);
                            }

                            _logFile.Flush();
                            _logFile.Close();

                            if (bCanceled)
                            {
                                _transaction.Rollback();
                                sResult = "Import was canceled. " + sResult;
                            }
                            else
                            {
                                _transaction.Commit();
                                sResult = "Import finished: " + sResult;

                                new VWA4Common.UtilitiesInstance().setTaskCheck(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek), true, "importwastedata");
                                VWA4Common.VWADBUtils.MostRecents = new DateTime(0); //calculate new dates for last weights data
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, "Error occured! Error raised, with message : " + ex.Message, "VWA Import File Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _transaction.Rollback();
                        }
                        finally
                        {
                            //VWA4Common.ProgressDialog.CloseForm();
                            //MessageBox.Show("Enter final block");
                            try
                            {
                                if (_connTransaction != null && _connTransaction.State != ConnectionState.Closed)
                                    _connTransaction.Close();
                                //MessageBox.Show("Transaction was successfully closed: " + VWA4Common.VWACommon.DateToString(DateTime.Now));
                                //_logFile.Flush();
                                //MessageBox.Show("Log buffer written");
                                _logFile.Close();
                                //MessageBox.Show("Log file was saved");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(this, "Error occured! Error raised, with message : " + ex.Message, "VWA Import File Error",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    if (!bCanceled && ArchiveFileFlag)//backup and delete original file
                    {
                        BackupFile(FileName, fileData);
                    }
                    this.lblReady.Text = "Import finished";
					//if (!bCanceled && totalErrors > 0)
					//{
					//    //VWA4Common.ProgressDialog.SetHideProgressNow(true);
					//    //int i = 0;
					//    //while (TopMostMessageBox.Show("VWA Import Error", "Do you want to " + (i > 0 ? "continue " : "") +
					//    //    "edit error records?", "Edit", "No") == DialogResult.OK)
					//    //{
					//    //    // todo: Edit errors;
					//    //    ViewErrors frm = new ViewErrors();
					//    //    frm.FilterTransfers(transferData);
					//    //    frm.ShowDialog();
					//    //    i = 1;
					//    //}
					//    DataTable dtEO = VWA4Common.DB.Retrieve("SELECT * FROM BEOType WHERE TypeName IS NULL");
					//    if (dtEO != null && dtEO.Rows.Count > 0)
					//        if (MessageBox.Show(this, "There are automatically added Event Orders " + Environment.NewLine + "Do you want to edit?", "VWA Import Error",
					//                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
					//        {
					//            foreach (DataRow row in dtEO.Rows)
					//            {
					//                EditEventOrder frm = new EditEventOrder(row["TypeID"].ToString());
					//                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
					//                frm.Show();
					//            }
					//        }
					//}
                    transferData.Clear(); // free array
                }//end if fileData != null
            }
            finally
            {
                VWA4Common.ProgressDialog.CloseProgressForm();
            }
        }
        private string weightFilter = "", errorWeightFilter = "", producedFilter = "", errorProducedFilter = "";
        private string ConstructSelect(string filter, string tableName)
        {
            string select = "";
            if (filter != "")
                select = "TransKey IN (SELECT TransKey FROM " + tableName + " WHERE " + filter + ")";
            else
                select = "TransKey IN (SELECT TransKey FROM " + tableName + ")";
            return select;
        }
        private string ConstructWhere()
        {
            string where = "";
            if(weightFilter != "" || errorWeightFilter != "" || producedFilter != "" || errorProducedFilter != "")// at least one filter exists
            {
                where = ConstructSelect(weightFilter, "Weights");
                where = where + " OR " + ConstructSelect(errorWeightFilter, "ErrorWeights");
                where = where + " OR " + ConstructSelect(producedFilter, "WeightsProduced");
                where = where + " OR " + ConstructSelect(errorProducedFilter, "ErrorWeightsProduced");
                where = " WHERE " + where;
            }
            return where;
        }
        private void DBImport(string FileName, bool ArchiveFileFlag)
        {
            int totalSuccess = 0;
            int totalErrors = 0;
            int nErrorRec = 0;
            string sResult = "";
            DataTable transfers = null;
            bCanceled = false;
            ArrayList transferData = new ArrayList();

            // If the ActiveSync Tracker Mode is enabled, look for the Tracker connection.
            int pd_left = (this.Left + (ParentForm != null ? ParentForm.Left : 0)) + this.Width / 2;
            int pd_top = (this.Top + (ParentForm != null ? ParentForm.Top : 0)) + this.Height / 2;
            VWA4Common.ProgressDialog.SetLeadin("Importing DB");
            VWA4Common.ProgressDialog.ShowProgressDialog("Looking for DataBase.", "", "", pd_left, pd_top);

            if (File.Exists(FileName))// Open the import DB
            {
                System.Data.OleDb.OleDbConnection connImport = new System.Data.OleDb.OleDbConnection(VWA4Common.VWACommon.GetConnectionString(FileName));
                _connTransaction = new System.Data.OleDb.OleDbConnection(VWA4Common.AppContext.WasteConnectionString);
                _connTransaction.Open();
                _transaction = _connTransaction.BeginTransaction();

                SetFilter(cbFilters.SelectedItem.ToString()); //save current filter
                transfers = VWA4Common.DB.Retrieve("SELECT Transfers.*, TermName FROM Transfers LEFT JOIN Terminals ON Transfers.TermID = Terminals.TermID " + ConstructWhere(), connImport, null);
                
                VWA4Common.ProgressDialog.SetStatus("Reading DB data... ", 10);
                try
                {
                    //todo: get path from settings, create dir if not exists
                    using (FileStream fs = new FileStream(GetLogFileName(), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                    {
                        _logFile = new StreamWriter(fs);
                        _logFile.AutoFlush = true;
                        if (!fs.CanWrite)
                            MessageBox.Show(this, "Error occured! Can't write to log file ", "VWA Log File Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ImportTransfer transfer = new ImportTransfer();
                        int pos = 0;
                        double progressTick = (transfers.Rows.Count > 0 ? 90 / transfers.Rows.Count : 1);
                        while ((pos < transfers.Rows.Count) && !bCanceled)
                        {
                            VWA4Common.ProgressDialog.SetStatus("Importing transfer record " + pos + " of " + transfers.Rows.Count, (int)(pos * progressTick));
                            if (VWA4Common.ProgressDialog.CancelPressed)
                            {
                                VWA4Common.ProgressDialog.CancelPressed = false;
                                return;
                            }

                            DataRow row = transfers.Rows[pos];

                            TransferInfo transferInfo = new TransferInfo(0);
                            if (transfer.Init(row, _connTransaction, _transaction, true))
                            {
                                transfer.Check(_connTransaction, _transaction, true);

                                // write to log-file
                                if (VWA4Common.VWACommon.NotNullOrEmpty(transfer.ErrorMsg))
                                    _logFile.Write(transfer.ErrorMsg + Environment.NewLine);
                                if (VWA4Common.VWACommon.NotNullOrEmpty(transfer.WarningMsg))
                                    _logFile.Write(transfer.WarningMsg + Environment.NewLine);
                                if (!transfer.IsCorrect())
                                    if (!EditTransfer(ref transfer))
                                    {
                                        bCanceled = true;
                                        continue; // to not add transfer info
                                    }
                                transfer.DBSave(_connTransaction, _transaction, true); //do not save transfer if there are duplicates
                            }
                            // else - it is duplicate record - do not save it, just pass transfer for importing weight records

                            transfer.RecordsNumber = ImportTransferRecords(transfer, row["TransKey"].ToString(), ref nErrorRec, connImport);
                            transfer.IncorrectRecordsNumber = nErrorRec;
                            transferInfo = new TransferInfo(transfer);

                            transferData.Add(transferInfo);
                            pos++;
                        }
                        
                        if (!bCanceled)
                        {
                            // show import result
                            for (pos = 0; pos < transferData.Count; pos++)
                            {
                                sResult = sResult + ((TransferInfo)transferData[pos]).ToString() + Environment.NewLine;
                                totalSuccess = totalSuccess + ((TransferInfo)transferData[pos]).RecNum;
                                totalErrors = totalErrors + ((TransferInfo)transferData[pos]).ErrorRecNum;
                            }
                            sResult = totalSuccess + " records from " + transferData.Count + " transfers were imported successfully." + Environment.NewLine +
                            totalErrors + "  records were imported with errors" + Environment.NewLine + sResult;

                            VWA4Common.ProgressDialog.SetHideProgressNow(true);
                            if (TopMostMessageBox.Show("VWA Import File", sResult + Environment.NewLine + "Save or Cancel input?", "Save", "Cancel") 
                                    == DialogResult.Cancel)
                                bCanceled = true;
                            VWA4Common.ProgressDialog.SetHideProgressNow(false);
                        }

                        _logFile.Flush();
                        _logFile.Close();

                        VWA4Common.ProgressDialog.CloseForm();

                        if (bCanceled)
                        {
                            _transaction.Rollback();
                            sResult = "Import was canceled. " + sResult;
                        }
                        else
                        {
                            _transaction.Commit();
                            sResult = "Import finished: " + sResult;
                            //if (ArchiveFileFlag)
                            //    BackupFile(FileName, fileData);
                            // set checkbox in tasks
                            VWA4Common.UtilitiesInstance utils = new VWA4Common.UtilitiesInstance();
                            utils.setTaskCheck(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek), true, "importwastedata");

                            VWA4Common.VWADBUtils.MostRecents = new DateTime(0);//calculate new dates for last weights data
                        }

                        // finish log file
                        //_logFile.Write(VWA4Common.VWACommon.DateToString(DateTime.Now) + " " + sResult + Environment.NewLine);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error occured! Error raised, with message : " + ex.Message, "VWA Import File Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _transaction.Rollback();
                }
                finally
                {
                    VWA4Common.ProgressDialog.CloseProgressForm();
                    if (_connTransaction != null && _connTransaction.State != ConnectionState.Closed)
                        _connTransaction.Close();
                    //_logFile.Flush();
                    _logFile.Close();
                }
                this.lblReady.Text = "Import finished";
                if (!bCanceled && totalErrors > 0)
                {
                    if (MessageBox.Show(this, "Do you want to edit error records?", "VWA Import Error",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // todo: Edit errors;
                        ViewErrors frm = new ViewErrors();
                        frm.FilterTransfers(transferData);
                        frm.ShowDialog();
                    }
                    DataTable dtEO = VWA4Common.DB.Retrieve("SELECT * FROM BEOType WHERE TypeName IS NULL");
                    if (dtEO != null && dtEO.Rows.Count > 0)
                        if (MessageBox.Show(this, "There are automatically added Event Orders" + Environment.NewLine + "Do you want to edit?", "VWA Import Error",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            foreach (DataRow row in dtEO.Rows)
                            {
                                EditEventOrder frm = new EditEventOrder(row["TypeID"].ToString());
                                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                                frm.Show();
                            }
                        }
                }
                transferData.Clear(); // free array
            }
        }
        private int ImportTransferRecords(ImportTransfer transfer, string oldTransKey, ref int nErrorRec, OleDbConnection connImport)
        {
            ImportWeight rec = new ImportWeight();
            nErrorRec = 0;
            int numRec = 0;
            string filter = producedFilter;
            if (filter != "")
                filter = " AND (" + filter + ")";
            // import produced first
            DataTable weights = VWA4Common.DB.Retrieve("SELECT * FROM WeightsProduced WHERE TransKey = " + oldTransKey + filter, connImport, null);
            foreach (DataRow weight in weights.Rows)
            {
                rec = new ImportWeight();
                if (rec.Init(weight, transfer, true, false, _connTransaction, _transaction))
                {
                    numRec++;
                    if (nWeightImportThreshold > 0 && rec.GetWeight() > nWeightImportThreshold)
                    {
                        rec.AddWarning("Weight is above a Weight Import Threshold");
                        MessageBox.Show("Weight is above a Weight Import Threshold");
                    }
                    if (nCostImportThreshold > 0 && rec.GetTotalCost() > nCostImportThreshold)
                    {
                        rec.AddWarning("Waste Cost is above a Cost Import Threshold");
                        MessageBox.Show("Waste Cost is above a Cost Import Threshold");
                    }
                    if (rec.IsCorrect())
                        rec.DBSave(_connTransaction, _transaction, true);
                    else
                    {
                        rec.DBSaveError(_connTransaction, _transaction, true);
                        nErrorRec++;
                    }
                }
            }
            filter = errorProducedFilter;
            if (filter != "")
                filter = " AND (" + filter + ")";
            weights = VWA4Common.DB.Retrieve("SELECT * FROM ErrorWeightsProduced WHERE TransKey = " + oldTransKey + filter, connImport, null);
            foreach (DataRow weight in weights.Rows)
            {
                rec = new ImportWeight();
                if (rec.Init(weight, transfer, true, true, _connTransaction, _transaction))
                {
                    numRec++;
                    rec.DBSaveError(_connTransaction, _transaction, true);
                    nErrorRec++;
                }
            }
            filter = weightFilter;
            if (filter != "")
                filter = " AND (" + filter + ")";
            weights = VWA4Common.DB.Retrieve("SELECT Weights.* , WeightsProduced.LotNumber, ProducedAmount " +
                " FROM Weights LEFT JOIN WeightsProduced ON Weights.ProducedID = WeightsProduced.ID " +
                " WHERE Weights.TransKey = " + oldTransKey + filter, connImport, null);
            foreach (DataRow weight in weights.Rows)
            {
                rec = new ImportWeight();
                if (rec.Init(weight, transfer, false, false, _connTransaction, _transaction))
                {
                    numRec++;
                    if (rec.IsCorrect())
                        rec.DBSave(_connTransaction, _transaction, true);
                    else
                    {
                        rec.DBSaveError(_connTransaction, _transaction, true);
                        nErrorRec++;
                    }
                }
                else //duplicate
                {
                    if(new frmSaveAs("VWA Import Error", "Duplicate weight record!" + Environment.NewLine + 
                        "Do you want to Skip or Save it to Eroors?", "Skip", "Save").ShowDialog() == DialogResult.Cancel)
                        rec.DBSaveError(_connTransaction, _transaction, true);
                    nErrorRec++;
                }
            }
            filter = errorWeightFilter;
            if (filter != "")
                filter = " AND (" + filter + ")";
            weights = VWA4Common.DB.Retrieve("SELECT ErrorWeights.* , WeightsProduced.LotNumber, ProducedAmount " +
                        " FROM ErrorWeights LEFT JOIN WeightsProduced ON ErrorWeights.ProducedID = WeightsProduced.ID " +
                        " WHERE ErrorWeights.TransKey = " + oldTransKey + filter, connImport, null);
            foreach (DataRow weight in weights.Rows)
            {
                rec = new ImportWeight();
                if (rec.Init(weight, transfer, false, true, _connTransaction, _transaction))
                {
                    numRec++;
                    rec.DBSaveError(_connTransaction, _transaction, true);
                    nErrorRec++;
                }
            }
            
            return numRec;
        }

        private string _VolumeLabel = "";
        private void InitFileWatcher(string drive)
        {
            watch.Path = new System.IO.DriveInfo(drive).RootDirectory.ToString();
            _VolumeLabel = new System.IO.DriveInfo(drive).VolumeLabel;
            if (_VolumeLabel != "")
                _VolumeLabel += " ";
            //watch.Filter = VWA4Common.VWACommon.ImportFilePattern;
            watch.IncludeSubdirectories = true;

            watch.EnableRaisingEvents = true;

            this.label1.Text = "";
        }
        // Called by DriveDetector when removable device in inserted
        private void OnDriveArrived(object sender, DriveDetectorEventArgs e)
        {
            InitDir(e.Drive);
            
            //MessageBox.Show("No valid VWT4 waste transfer data found!\n Drive label should be 'VALUWASTE' and file name should be 'VWT4WasteTransfer*.dat'");
            InitFileWatcher(e.Drive);
            
            e.HookQueryRemove = true;
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            AddFile(_VolumeLabel + e.FullPath, true);
        }
        private void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            RemoveNode(_VolumeLabel + e.FullPath);
        }

        // Called by DriveDetector after removable device has been unplugged

        private void OnDriveRemoved(object sender, DriveDetectorEventArgs e)
        {
            // TODO: do clean up here, etc. Letter of the removed drive is in
            RemoveNode(_VolumeLabel + e.Drive);
            watch.EnableRaisingEvents = false;
            
            this.label1.Text = "Plug your device into USB drive to start import";
        }

        // Called by DriveDetector when removable drive is about to be removed
        private void OnQueryRemove(object sender, DriveDetectorEventArgs e)
        {
            // Should we allow the drive to be unplugged?

            if (MessageBox.Show("Allow remove?", "Query remove",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                e.Cancel = false;        // Allow removal

            else
                e.Cancel = true;         // Cancel the removal of the device

        }
        private void RemoveNode(string key)
        {
            try
            {
                //remove from the tree
                key = Regex.Replace(key, @"\\$", "");
                UltraTreeNode node = utFileBrowser.GetNodeByKey(key);
                if (node == null)
                    node = utFileBrowser.GetNodeByKey("VALUWASTE " + key);
                if (node == null)
                    node = utFileBrowser.GetNodeByKey(_VolumeLabel + key);
                if (node != null)
                {
                    while (node != null)
                        if (node.Parent == null || node.Parent.Nodes.Count > 1)
                        {
                            node.Remove();
                            node = null;
                        }
                        else if (node.Parent != null && node.Parent.Nodes.Count == 1)//no other files in dir
                        {
                            node = node.Parent;
                            node.Nodes.Clear();
                        }

                    utFileBrowser.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error occured! Error raised, with message : " + ex.Message, "VWA Remove Node Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string prevFilter = "Set Weights Filter";
        private void SetFilter(string filterName)
        {
            switch (filterName)
            {
                case "Set Weights Filter":
                    weightFilter = ucViewWeights1.GetFilters();
                    break;
                case "Set Error Weights Filter":
                    errorWeightFilter = ucViewWeights1.GetFilters();
                    break;
                case "Set Produced Filter":
                    producedFilter = ucViewWeights1.GetFilters();
                    break;
                case "Set Error Produced Filter":
                    errorProducedFilter = ucViewWeights1.GetFilters();
                    break;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFilter(prevFilter);
            switch (cbFilters.SelectedItem.ToString())
            {
                case "Set Weights Filter":
                    ucViewWeights1.Mode = UCViewWeights.DisplayMode.Weights;
                    break;
                case "Set Error Weights Filter":
                    ucViewWeights1.Mode = UCViewWeights.DisplayMode.ErrorWeights;
                    break;
                case "Set Produced Filter":
                    ucViewWeights1.Mode = UCViewWeights.DisplayMode.Produced;
                    break;
                case "Set Error Produced Filter":
                    ucViewWeights1.Mode = UCViewWeights.DisplayMode.ErrorProduced;
                    break;
            }
            ucViewWeights1.LoadData();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            commonEvents.TaskSheetKey = "dashboard";
        }
		private void dbDetector_UserLogin(object sender, VWA4Common.LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) // ||  !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Import Data")))
				commonEvents.TaskSheetKey = "dashboard";
		}

        
        //private int _TotalErrors = 0;
        //private ArrayList _TransferData = null;
        ////Stephen todo: this is the main cycle. It is here because of multythreading. UI is in one thread and import is in another thread
        ////UI and import in different threads so user can cancel import. If UI and import in the same thread Cancel can't work
        //private void StartFileImport(string fileName)
        //{
        //    int totalSuccess = 0;
			
        //    int num, nErrorRec = 0;
        //    string sResult = "";
        //    string[] fileData = null;
        //    bCanceled = false;
        //    _TransferData = new ArrayList();
        //    string FileName = fileName;
        //    bool ArchiveFileFlag = _IsArchive;
        //    try
        //    {
        //        pf = new VWA4Common.ProgressForm();
        //        pf.SetupAndShow(this.ParentForm, "Converting Reports to PDF", "Creating Report List...", true, true);
        //        int pd_left = (this.Left + ParentForm.Left) + this.Width / 2;
        //        int pd_top = (this.Top + ParentForm.Top) + this.Height / 2;

        //        VWA4Common.ProgressDialog.ShowProgressDialog("Looking for Reports' Names.", "", "", pd_left, pd_top);

        //    if (File.Exists(FileName))// Open the input file for input
        //        fileData = File.ReadAllLines(FileName);
        //    VWA4Common.ProgressDialog.SetStatus("Reading file data...", 10);
        //    if (fileData != null)
        //    {
        //        _connTransaction = new System.Data.OleDb.OleDbConnection(VWA4Common.AppContext.WasteConnectionString);
        //        _connTransaction.Open();
        //        _transaction = _connTransaction.BeginTransaction();

        //        double progressTick = (fileData.Length > 0 ? 90 / fileData.Length : 1);
        //        //todo: get path from settings, create dir if not exists
        //        using (FileStream fs = new FileStream(GetLogFileName(), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
        //        {
        //            try
        //            {
        //                _logFile = new StreamWriter(fs);
        //                _logFile.AutoFlush = true;
        //                if (!fs.CanWrite)
        //                    MessageBox.Show(this, "Error occurred! Can't write to log file ", "VWA Log File Error",
        //                                MessageBoxButtons.OK, MessageBoxIcon.Error);

        //                ImportTransfer transfer = new ImportTransfer();
        //                int pos = 0;

        //                while ((pos < fileData.Length) && !bCanceled)
        //                {
        //                    if (VWA4Common.ProgressDialog.CancelPressed)
        //                    {
        //                        VWA4Common.ProgressDialog.CancelPressed = false;
        //                        bCanceled = true;
        //                        //btnOk.Enabled = true;
        //                        return;
        //                    }
        //                    string sLine = fileData[pos];
        //                    pos = pos + 1;
        //                    VWA4Common.ProgressDialog.SetStatus("Importing line " + pos + " of " + fileData.Length, (int)(pos * progressTick));

        //                    if (sLine.Trim() != "")    // skip empty strings
        //                    {
        //                        TransferInfo transferInfo = new TransferInfo(0);

        //                        if (transfer.Init(sLine, _connTransaction, _transaction))// no duplicates
        //                        {
        //                            transfer.Check(_connTransaction, _transaction);
        //                            // write to log-file
        //                            if (VWA4Common.VWACommon.NotNullOrEmpty(transfer.ErrorMsg))
        //                                _logFile.Write(transfer.ErrorMsg + Environment.NewLine);
        //                            if (VWA4Common.VWACommon.NotNullOrEmpty(transfer.WarningMsg))
        //                                _logFile.Write(transfer.WarningMsg + Environment.NewLine);
        //                            if (transfer.IsCorrect())
        //                            {
        //                                transfer.DBSave(_connTransaction, _transaction, true);
        //                                num = ReadTransferRecords(fileData, ref pos, transfer, ref nErrorRec);
        //                                transfer.RecordsNumber = num;
        //                                transfer.IncorrectRecordsNumber = nErrorRec;
        //                                transferInfo = new TransferInfo(transfer);
        //                            }
        //                            else
        //                            {
        //                                if (EditTransfer(ref transfer))
        //                                {
        //                                    pos = pos - 1;
        //                                    fileData[pos] = transfer.ToString(); // rewrite transfer data and process again
        //                                    continue; // to not add transfer info
        //                                }
        //                                else
        //                                    SkipTransferData(fileData, ref pos, transfer, ref transferInfo);
        //                            }
        //                        }
        //                        else  // duplicate transfer record
        //                            SkipTransferData(fileData, ref pos, transfer, ref transferInfo);

        //                        _TransferData.Add(transferInfo);

        //                    }
        //                }

        //                if (!bCanceled)
        //                {
        //                    // show import result
        //                    for (pos = 0; pos < _TransferData.Count; pos++)
        //                    {
        //                        sResult = sResult + ((TransferInfo)_TransferData[pos]).ToString() + Environment.NewLine;
        //                        totalSuccess = totalSuccess + ((TransferInfo)_TransferData[pos]).RecNum;
        //                        _TotalErrors = _TotalErrors + ((TransferInfo)_TransferData[pos]).ErrorRecNum;
        //                    }
        //                    sResult = totalSuccess + " records from " + _TransferData.Count + " transfers were imported successfully." + Environment.NewLine +
        //                    _TotalErrors + "  records were imported with errors" + Environment.NewLine + sResult;

        //                    if (new frmSaveAs("VWA Import File", sResult + Environment.NewLine + "Save or Cancel input?", "Save", "Cancel").ShowDialog() == DialogResult.Cancel)
        //                        bCanceled = true;
        //                    //else
        //                    //    _logFile.Write("Saving approved by user: " + VWA4Common.VWACommon.DateToString(DateTime.Now) + Environment.NewLine);
        //                }

        //                _logFile.Flush();
        //                _logFile.Close();

        //                if (bCanceled)
        //                {
        //                    _transaction.Rollback();
        //                    sResult = "Import was cancelled. " + sResult;
        //                }
        //                else
        //                {
        //                    _transaction.Commit();
        //                    sResult = "Import finished: " + sResult;

        //                    VWA4Common.VWADBUtils.MostRecents = new DateTime(0); //calculate new dates for last weights data
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Error occured! Error raised, with message : " + ex.Message, "VWA Import File Error",
        //                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                _transaction.Rollback();
        //            }
        //            finally
        //            {
        //                pf.Finish();
        //                VWA4Common.ProgressDialog.CloseForm();
        //                //MessageBox.Show("Enter final block");
        //                try
        //                {
        //                    if (_connTransaction != null && _connTransaction.State != ConnectionState.Closed)
        //                        _connTransaction.Close();
        //                    //MessageBox.Show("Transaction was successfully closed: " + VWA4Common.VWACommon.DateToString(DateTime.Now));
        //                    //_logFile.Flush();
        //                    //MessageBox.Show("Log buffer written");
        //                    _logFile.Close();
        //                    //MessageBox.Show("Log file was saved");
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(this, "Error occured! Error raised, with message : " + ex.Message, "VWA Import File Error",
        //                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //        }

        //        if (!bCanceled && ArchiveFileFlag)//backup and delete original file
        //        {
        //            BackupFile(FileName, fileData, false);
        //            //remove from the tree
        //            ClearImported(FileName);
        //        }

        //        btnOk.Visible = true;

        //    if (e.Cancelled)
        //    {
        //        this.lblReady.Text = "The task has been cancelled";
        //    }
        //    else if (e.Error != null)
        //    {
        //        this.lblReady.Text = "Error. Details: " + (e.Error as Exception).ToString();
        //    }
        //    else
        //    {
        //        this.lblReady.Text = bCanceled ? "The task has been cancelled" : "Import finished";
        //        new VWA4Common.UtilitiesInstance().setTaskCheck(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek), true, "importwastedata");

        //        if (!bCanceled && _TotalErrors > 0)
        //        {
        //            MessageBox.Show(_TotalErrors + " records were imported with errors. Contact LeanPath Customer support to report the errors.");
        //            //int i = 0;
        //            //while (new frmSaveAs("VWA Import Error", "Do you want to " + (i > 0 ? "continue " : "") +
        //            //    "edit error records?", "Edit", "No").ShowDialog() == DialogResult.OK)
        //            //{
        //            //    // todo: Edit errors;
        //            //    ViewErrors frm = new ViewErrors();
        //            //    frm.FilterTransfers(_TransferData);
        //            //    frm.ShowDialog();
        //            //    i = 1;
        //            //}
        //        }
        //        DataTable dtEO = VWA4Common.DB.Retrieve("SELECT * FROM BEOType WHERE TypeName IS NULL");
        //        if (dtEO != null && dtEO.Rows.Count > 0)
        //                MessageBox.Show("There are automatically added Event Orders in this transfer." + Environment.NewLine +
        //                    "Edit via “Manage Event Orders” on your Task bar”");
        //            //if (MessageBox.Show(this, "There are automatically added Event Orders\n Do you want to edit?", "VWA Import Error",
        //            //            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
        //            //{
        //            //    foreach (DataRow row in dtEO.Rows)
        //            //    {
        //            //        EditEventOrder frm = new EditEventOrder(row["TypeID"].ToString());
        //            //        frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        //            //        frm.Show();
        //            //    }
        //            //}
				
				
        //        //MessageBox.Show("The task has been completed. Results: " + e.Result.ToString());
        //    }
        //    _TransferData.Clear(); // free array
        //}
				
        //    }//end if fileData != null
        //    }
        //    catch (Exception ex)
        //    {
        //        //Note cancellation throws an exception
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private delegate void ClearImportedHandler(string s);

        private void ClearImported(string s)
        {
            if (this.utFileBrowser.InvokeRequired)
                this.utFileBrowser.Invoke(new ClearImportedHandler(ClearImported), new object[] { s });
            else if(!bool.Parse(VWA4Common.GlobalSettings.ActiveSyncTrackerTransfersOn))//Stephen todo: I added this code so in case of activesync tree view of files is not updated (cause it is hidden in this mode and can raise error "File not found")
            {
                RemoveNode(s);
                lblSummary.Text = "";
                AllowImport(false);
            }
        }

        
    }
}

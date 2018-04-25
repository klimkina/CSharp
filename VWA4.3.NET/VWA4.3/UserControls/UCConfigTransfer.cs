using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OpenNETCF.Desktop.Communication;
using System.Reflection;

namespace UserControls
{
    public partial class UCConfigTransfer : UserControl, IVWAUserControlBase
    {
        VWA4Common.ProgressForm pf;
		
		string outputpathname;
		bool activesyncxfer;
		
		VWA4Common.CommonEvents commonEvents = null;
		
		/// <summary>
		/// Constructor
		/// </summary>
		public UCConfigTransfer()
        {
            InitializeComponent();
		}

        /// <summary>
        /// Initialize - nothing to do
        /// </summary>
        /// <param name="firstDayOfWeek"></param>
        public void Init(DateTime firstDayOfWeek)
        {
			if (commonEvents == null)
			{
				commonEvents = VWA4Common.CommonEvents.GetEvents();
				commonEvents.UpdateProductUIData +=
					new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
			}
			_IsActive = true;
        }

		/// <summary>
		/// Update the Product UI based on global settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void commonEvents_UpdateProductUI(object sender, EventArgs e)
		{
			///***********
			/// Product Type
			///***********
			// Task background
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
			// Task header
			pTaskHdr.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			lTaskTitle.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other labels
		}
	
		public void LoadData()
		{ }
        public void SaveData()
        { }
        public bool ValidateData()
        { return true; }

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

		/// <summary>
		/// find the VALUWASTE volume needed for transfer, or ask user to provide
		/// a destination for the exported file.
		/// </summary>
		/// <param name="mode"></param>
		public int AutoRun(string mode)
		{
			bool lookforusb = true;
			activesyncxfer = false;
			lNextStepError.Hide();
			lNextStep2.Hide();
			lNextStepText.Hide();
			pbNextStepDiagram1.Hide();
			pbActiveSync.Hide();
			lMessage.Text = "Update Tracker Failed - Check Transfer Media.";
			lMessage.BackColor = VWA4Common.GlobalSettings.BackColor_Failure;
			// If the ActiveSync Tracker Mode is enabled, look for the Tracker connection.
			if (bool.Parse(VWA4Common.GlobalSettings.ActiveSyncTrackerTransfersOn))
			{ // ActiveSync Tracker mode is enabled - attempt to connect.
				RAPI trackerRapi = new RAPI();
				bool done = false;
				while (!done)
				{
					trackerRapi.Connect();
					if (!trackerRapi.DevicePresent)
					{  // Tracker not present
						if (MessageBox.Show(this, "Please connect your Tracker to this PC using the USB/ActiveSync cable, and then click OK to continue.",
							"Update Tracker via ActiveSync", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
						{
							continue;
						}
						else
						{ // User cancelled
							if (MessageBox.Show(this, "Update Tracker via ActiveSync Cancelled - Look for VALUWASTE USB drive?",
								"Update Tracker via ActiveSync", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
							{ // Don't look for USB drive
								lookforusb = false;
							}
							done = true;
						}
					}
					else
					{ // Tracker is present - output configuration to local file and then copy to Tracker
						//
						// Process the transfer to local disk - application directory
						// 
						string appdir = System.IO.Path.GetDirectoryName(VWA4Common.GlobalSettings.VirtualAppDir);
						string localpath = appdir + "\\VWT4ConfigTransfer.dat";
						string trackerpath = VWA4Common.GlobalSettings.ActiveSyncTrackerTransferFolder + "\\VWT4ConfigTransfer.dat";
						activesyncxfer = true;
						TransferConfigData(localpath);
						// Copy local file to Tracker via RAPI
						lMessage.Show();
						trackerRapi.CopyFileToDevice(localpath, trackerpath, true);
						done = true;
						lookforusb = false;
						lMessage.Text = "Tracker Update Successfully Transferred via\n   ActiveSync Transfer (USB Cable)";
						lMessage.BackColor = VWA4Common.GlobalSettings.BackColor_Success;
					}
				}
			}
			// If we succeeded, then we're done; otherwise, try USB
			if (!lookforusb) { return 0; }
			
			// Continue - look for VALUWASTE volume label
			int pd_left = (this.Left + ParentForm.Left) + this.Width / 2;
			int pd_top = (this.Top + ParentForm.Top) + this.Height / 2;
			VWA4Common.ProgressDialog.ShowProgressDialog("Looking for transfer media.", "", "", pd_left, pd_top);

			// bring up message that says we are scanning drives to find the VALUWASTE volume
			try
			{
				lMessage.Hide();
				pf = new VWA4Common.ProgressForm();
				pf.SetupAndShow(this.ParentForm, "Update Tracker", "Locating VALUWASTE Data Device...", true, true);
				try
				{
					// Scan for VALUWASTE volume
					InitFileBrowser();
				}
				finally
				{
					pf.Finish();
				}
                
			}
			catch (Exception ex)
			{
				VWA4Common.ProgressDialog.CloseProgressForm();
				//Note cancellation throws an exception
				MessageBox.Show(ex.Message);
			}
            return 0;
		}

        /// <summary>
        /// Scan for VALUWASTE volume
        /// </summary>
        private void InitFileBrowser()
        {
				VWA4Common.ProgressDialog.SetLeadin("Scanning drives...");
			string[] drives = Directory.GetLogicalDrives();
            bool altmsgs = false;
            bool volfound = false;
            outputpathname = "";
            //search PC for a logical drive with VALUWASTE volume label
            foreach (string drive in drives)
            {
                System.IO.DriveInfo driveInfo = new System.IO.DriveInfo(drive);
                if (driveInfo.IsReady && driveInfo.VolumeLabel.Trim().Length > 8 && driveInfo.VolumeLabel.Trim().ToLower().Substring(0, 9) == "valuwaste")
                {
                    // We have found a VALUWASTE volume
                    volfound = true;
                    outputpathname = driveInfo.Name + "VWT"; // start building the output pathname
					VWA4Common.ProgressDialog.SetStatus(driveInfo.Name, 10);
					break;
                }
                altmsgs = !altmsgs;
           }
            // done searching
            if (volfound)
            {
                // We have found a VALUWASTE volume
                //
                VWA4Common.ProgressDialog.SetLeadin("VALUWASTE volume found!");
				VWA4Common.ProgressDialog.SetStatus("Transferring config data...", 20);
                //
                // Prep the drive if necessary
                if (VWA4Common.VWACommon.CheckPath(outputpathname))
                { // good to go with the VWT directory
                    // We have a directory - add the filename to create the path
                    outputpathname += "\\VWT4ConfigTransfer.dat";
                }
                else
                { // Unable to create the necessary directory
					VWA4Common.ProgressDialog.CloseProgressForm();
					MessageBox.Show("Unable to create VWT4 directory!\r\nPlease check the VALUWASTE data transfer drive.");
                    return;
                }
                //
                // Process the transfer
                // 
                TransferConfigData(outputpathname);
                // Finish off the progress dialog
                //pf.Finish();
            }
            else
            {
                // No VALUWASTE volume is found
                //
                // Hide the progress dialog
				VWA4Common.ProgressDialog.SetHideProgressNow(true);
				MessageBox.Show("VALUWASTE volume not found!\r\nPlease select a folder for the transfer.");
				//System.Threading.Thread.Sleep(3000);
                // Bring up a folder chooser dialog
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
				if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
				{
					// Use the selected folder for the transfer
					outputpathname = folderBrowserDialog1.SelectedPath;
					// We have a directory - add the filename to create the path
					outputpathname += "\\VWT4ConfigTransfer.dat";
					//
					// Process the transfer
					// 
					VWA4Common.ProgressDialog.SetHideProgressNow(false);
					TransferConfigData(outputpathname);
				}
				else
				{
					lMessage.Text = "Update Tracker Cancelled by User.";
					lMessage.BackColor = VWA4Common.GlobalSettings.BackColor_Failure;
					lMessage.Show();
				}
            }
        }
        /// <summary>
        ///         /// Transfer config data ---
        /// Do the heavy lifting - actually write out the config file.
        /// </summary>
        /// <param name="outputpathname">Full pathname to write output file to.</param>
        private void TransferConfigData(string outputpathname)
        {
			if (activesyncxfer)
			{
				int pd_left = (this.Left + ParentForm.Left) + this.Width / 2;
				int pd_top = (this.Top + ParentForm.Top) + this.Height / 2;
				VWA4Common.ProgressDialog.ShowProgressDialog("Using ActiveSync Transfer Mode...", "", "", pd_left, pd_top);
			}
			else
			{
				VWA4Common.ProgressDialog.SetLeadin("Transferring configuration...");
			}
				VWA4Common.ProgressDialog.SetStatus("", 30);
			// If the standard config file already exists, change its name to archive it
            if (File.Exists(outputpathname))
            {
				string archivedir = System.IO.Path.GetDirectoryName(outputpathname) + "\\Archive\\";
				if (!Directory.Exists(archivedir))
				{ Directory.CreateDirectory(archivedir); }
				string archivefilename = System.IO.Path.GetFileName(outputpathname);
				archivefilename = archivefilename.Replace("/", "");
				string archivepathname = archivedir  + archivefilename.Remove(archivefilename.Length - 4, 4) + "_thru_" +
					DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("HH-mm-sstt") + ".dat";

				//string archivepathname = outputpathname.Remove(outputpathname.Length-4,4) + "_thru_" +
				//    DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("HH-mm-sstt") + ".dat";
				//archivepathname = archivepathname.Replace("/", "");
				//// archivepathname = archivepathname.Replace(" ", "");

                File.Move(outputpathname, archivepathname);
            }
            StreamWriter sw = File.AppendText(outputpathname);
            try
            {
                /// Now we can write out the new file

                //***** Header (ONE PER FILE)
				Assembly assem = Assembly.GetExecutingAssembly();
				string verstr = assem.GetName().Version.ToString();
				string scmt1 = "//*****************************";
                string scmt2 = "//";
                sw.WriteLine(scmt1);
                sw.WriteLine(scmt1);
                sw.WriteLine(scmt2 + " VALUWASTE 4 Configuration Transfer File");
                sw.WriteLine(scmt1);
                sw.WriteLine(scmt1);
				//** Tracker record
				scmt1 = "//*********...,TermID,VWATransferDate,VWTTransferDate(local),VWAProductVersion,VWAAssemblyVersion";
				sw.WriteLine(scmt1);
				string sheader = "TransferConfig," + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
					+ ",," + Application.ProductVersion.ToString() + "," + verstr;
                sw.WriteLine(sheader);
                DataTable dtTracker = VWA4Common.DB.Retrieve("SELECT * FROM Terminals INNER JOIN (Sites "
                    + "LEFT JOIN TypeCatalogs ON Sites.TypeCatalogID=TypeCatalogs.ID) ON Terminals.SiteID=Sites.ID");
                //*****
                //***** Write out Units of Volume Records (ONE SET PER FILE)
                //*****
                DataTable dtUnitsVolume = VWA4Common.DB.Retrieve("SELECT * FROM UnitsVolume");
                foreach (DataRow row in dtUnitsVolume.Rows)
                {
                    string line = "VolumeUnit," + row["UniqueName"] + "," + row["DisplayFullName"] + "," + row["DisplayAbbreviatedName"] + ","
                        + row["ConversionFactor"];
                    sw.WriteLine(line);
                }
                //*****
                //***** Write out Units of Weight Records (ONE SET PER FILE)
                //*****
                DataTable dtUnitsWeight = VWA4Common.DB.Retrieve("SELECT * FROM UnitsWeight");
                foreach (DataRow row in dtUnitsWeight.Rows)
                {
                    string line = "WeightUnit," + row["UniqueName"] + "," + row["DisplayFullName"] + "," + row["DisplayAbbreviatedName"] + ","
                        + row["ConversionFactor"];
                    sw.WriteLine(line);
                }
                //*****
                //***** Write out Food Cost Discount Records (ONE SET PER FILE)
                //*****
                DataTable dtFoodCostDiscounts = VWA4Common.DB.Retrieve("SELECT * FROM Discounts");
                foreach (DataRow row in dtFoodCostDiscounts.Rows)
                {
                    string line = "FCDiscount," + row["FoodTypeID"] + "," + row["LossTypeID"] + "," + row["FoodCostDiscount"];
                    sw.WriteLine(line);
                }
                ///*****
                ///***** Build tables that contain necessary Tracker-specific information
                ///*****
                DataView dvUserButtons = GetMenuTable("User");
                DataView dvFoodButtons = GetMenuTable("Food");
                DataView dvLossButtons = GetMenuTable("Loss");
                DataView dvContainerButtons = GetMenuTable("Container");
                DataView dvQuestionButtons = GetMenuTable("Question");
				DataView dvPaperUIButtons = GetMenuTable("PaperUI");
				int progresslevel = 35;
				//*****
                //***** Loop through all Trackers in the current Site (ONE SET OF RECORDS PER TRACKER)
                //*****
                foreach (DataRow trackerRow in dtTracker.Rows)
                {
					progresslevel += 5;
					if (progresslevel > 100) progresslevel = 90;
					sw.WriteLine(scmt1);
                    sw.WriteLine(scmt1);
                    sw.WriteLine(scmt2 + " Tracker " + trackerRow["TermID"] + " -- " + trackerRow["TermName"]);
                    sw.WriteLine(scmt1);
                    sw.WriteLine(scmt1);
					VWA4Common.ProgressDialog.SetStatus(trackerRow["TermName"].ToString(), progresslevel);
					//*****
                    //***** Write out Tracker-specific records
                    //*****
                    // 
                    // Filter for only the current Tracker
                    //
                    dvUserButtons.RowFilter = "TermID = '" + trackerRow["TermID"] + "'";
                    dvUserButtons.Sort = "MenuRank, MenuName, ButtonRank, ButtonName";
                    dvFoodButtons.RowFilter = "TermID = '" + trackerRow["TermID"] + "'";
                    dvFoodButtons.Sort = "MenuRank, MenuName, ButtonRank, FullName";
                    dvLossButtons.RowFilter = "TermID = '" + trackerRow["TermID"] + "'";
                    dvLossButtons.Sort = "MenuRank, MenuName, ButtonRank, FullName";
                    dvContainerButtons.RowFilter = "TermID = '" + trackerRow["TermID"] + "'";
                    dvContainerButtons.Sort = "MenuRank, MenuName, ButtonRank, FullName";
					dvQuestionButtons.RowFilter = "TermID = '" + trackerRow["TermID"] + "'";
                    dvQuestionButtons.Sort = "MenuRank, MenuName, ButtonRank, FullName";
					dvPaperUIButtons.RowFilter = "TermID = '" + trackerRow["TermID"] + "'";
                    dvPaperUIButtons.Sort = "MenuRank, MenuName, ButtonRank, FullName";
					//*****
                    //***** Write Tracker global setting/info records (ONE RECORD EACH PER TRACKER)
                    //*****
                    {
                        //** Tracker record
						string line = "//*....,TermID,TermName,AdminPIN,WasteTimeout,AdminTimeout,AttractTimeout,EditTimeout,DefaultWasteClass.ProfileClass,DefaultWasteClass";
						sw.WriteLine(line);
                        line = "Tracker,";
                        line += trackerRow["TermID"] + ",";
                        line += trackerRow["TermName"] + ",";
                        line += trackerRow["AdminPIN"] + ",";
                        line += trackerRow["WasteTimeout"].ToString() + ",";
                        line += trackerRow["AdminTimeout"].ToString() + ",";
                        line += trackerRow["AttractTimeout"].ToString() + ",";
						line += trackerRow["EditTimeout"].ToString() + ",";
						string sqx = "SELECT * FROM WasteClass WHERE UniqueName = '"
							+ trackerRow["DefaultWasteClass"].ToString() + "';";
					    DataTable dtWasteClass = VWA4Common.DB.Retrieve(sqx);
						DataRow xrow = dtWasteClass.Rows[0];
						line += xrow["WasteProfile"] + ",";
						line += trackerRow["DefaultWasteClass"].ToString() + ",";
                        sw.WriteLine(line);

                        //** Site record
						line = "//* ,SiteID,LicensedSite,TypeCatalogID";
						sw.WriteLine(line);
						line = "Site,";
                        int CurrTypeCatalogID = 0;
                        line += trackerRow["SiteID"] + ",";
                        line += trackerRow["LicensedSite"] + ",";
                        int ti = (int)trackerRow["TypeCatalogID"];
                        if (ti == 0)
                        {
                            line += "0,";
                        }
                        else
                        {
                            line += trackerRow["TypeCatalogID"].ToString() + ",";
                            CurrTypeCatalogID = (int)trackerRow["TypeCatalogID"];
                        }
                        string ts = trackerRow["TypeCatalogName"].ToString();
                        if (ts == "")
                            line += "(Master Type Catalog)";
                        else
                            line += trackerRow["TypeCatalogName"];
                        sw.WriteLine(line);

                        //** Languages record
                        //
                        if ((bool)trackerRow["ShowLanguage2"])
                        {
                            line = "Lang,en,es";
                        }
                        else
                        {
                            line = "Lang,en";
                        }
                        sw.WriteLine(line);

                        //** Units record
                        // when this is implemented, it will use the Terminals:DisplayUnits field to determine value
                        line = "Units,lb";
                        sw.WriteLine(line);

                        //** Operation Mode Record
                        // 
                        {
                            line = "Mode,";
                            if (dvUserButtons.Count == 0)
                            {
                                line += "Login-Off";
                            }
                            else
                            {
                                line += "Login-On";
                            }
                            line += ",Food-On,Loss-On,Tare-On,";
                            // BEO
                            if ((bool.Parse(trackerRow["ShowBEOButton"].ToString())))
                            {
                                line += "EO-On";
                            }
                            else
                            {
                                line += "EO-Off";
                            }
                            // Default Pre/Post/Int
                            if (int.Parse(trackerRow["DefaultPrePostConsumerFlag"].ToString()) == 0)
                            {
                                line += ",Pre";
                            }
                            else if (int.Parse(trackerRow["DefaultPrePostConsumerFlag"].ToString()) == 1)
                            {
                                line += ",Post";
                            }
                            else line += ",Int";
                            // Produced Amount Paper UI
                            if (bool.Parse(trackerRow["ProducedAmtPaperUI"].ToString()))
                            {
                                line += ",ProdAmtPaper-On";
                            }
                            else
                            {
                                line += ",ProdAmtPaper-Off";
                            }
                            // Produced Amount Main UI
                            if (bool.Parse(trackerRow["ProducedAmtMainUI"].ToString()))
                            {
                                line += ",ProdAmtMain-On";
                            }
                            else
                            {
                                line += ",ProdAmtMain-Off";
                            }
                            // Volume based data entry
                            if (bool.Parse(trackerRow["VolumeBasedDataEntry"].ToString()))
                            {
                                line += ",VolumeEntryMain-On";
                            }
                            else
                            {
                                line += ",VolumeEntryMain-Off";
                            }
							// Admin password used for PaperUI
                            if (bool.Parse(trackerRow["PaperUIMgrPIN"].ToString()))
                            {
                                line += ",PaperUIPIN-On";
                            }
                            else
                            {
                                line += ",PaperUIPIN-Off";
                            }

                            sw.WriteLine(line);
                        }
                        //
                        //** Default Station Record
                        // 
                        line = "DefStation,";
                        if (trackerRow["DefaultStation"].ToString() == "")
                        {
                            // No default Station
                            line += ",,";
                        }
                        else
                        {
                            // Get the rest of the info since there is a default Station
                            DataTable dtStation = VWA4Common.DB.Retrieve("SELECT * FROM StationType AS st WHERE (st.TypeID = '"
                                + trackerRow["DefaultStation"] + "');");
                            // Should get one record
                            line += dtStation.Rows[0]["TypeID"] + ",";
                            line += dtStation.Rows[0]["TypeName"] + ",";
                            line += dtStation.Rows[0]["SpanishTypeName"];
                        }
                        sw.WriteLine(line);


                        //** Default Disposition Record
                        // 
                        line = "DefDisposition,";
                        if (trackerRow["DefaultDisposition"].ToString() == "")
                        {
                            // No default Disposition
                            line += ",,";
                        }
                        else
                        {
                            // Get the rest of the info since there is a default Disposition
                            DataTable dtDisposition = VWA4Common.DB.Retrieve("SELECT * FROM DispositionType AS st WHERE (st.TypeID = '"
                                + trackerRow["DefaultDisposition"] + "');");
                            // Should get one record
                            line += dtDisposition.Rows[0]["TypeID"] + ",";
                            line += dtDisposition.Rows[0]["TypeName"] + ",";
                            line += dtDisposition.Rows[0]["SpanishTypeName"];
                        }
                        sw.WriteLine(line);


                        //** Default Daypart Record
                        // 
                        line = "DefDaypart,";
                        if (trackerRow["DefaultDaypart"].ToString() == "")
                        {
                            // No default Daypart
                            line += ",,";
                        }
                        else
                        {
                            // Get the rest of the info since there is a default Daypart
                            DataTable dtDaypart = VWA4Common.DB.Retrieve("SELECT * FROM DaypartType AS st WHERE (st.TypeID = '"
                                + trackerRow["DefaultDaypart"] + "');");
                            // Should get one record
                            line += dtDaypart.Rows[0]["TypeID"] + ",";
                            line += dtDaypart.Rows[0]["TypeName"] + ",";
                            line += dtDaypart.Rows[0]["SpanishTypeName"];
                        }
                        sw.WriteLine(line);

                    } /// finished with PER TRACKER records

                    string spanishfullname;
                    string spanishbuttonname;

                    //*****
                    //***** Write out User Buttons (ONE SET OF RECORDS PER TRACKER)
                    //*****
                    foreach (DataRowView row in dvUserButtons)
                    {
                        spanishbuttonname = row["SpanishButtonName"].ToString();
                        if (spanishbuttonname == "")
                        { // Blank spanish name - substitute English
                            spanishbuttonname = row["ButtonName"].ToString();
                        }
                        string line = "User," + row["TypeID"] + "," + row["ButtonName"] + ","
							+ spanishbuttonname + ",,";  // password and Language fields are future expansion - MBB
                        sw.WriteLine(line);
                    }
                    
                    //*****
                    //***** Write out Food Buttons (ONE SET OF RECORDS PER TRACKER)
                    //*****
                    foreach (DataRowView row in dvFoodButtons)
                    {
                        spanishfullname = row["SpanishFullName"].ToString();
                        if (Regex.IsMatch(spanishfullname, "\\\\")) // "if there is any occurrance of "\\""
                        { // Blank spanish name - substitute English
                            spanishfullname = row["FullName"].ToString();
                        }
                        spanishbuttonname = row["SpanishButtonName"].ToString();
                        if (spanishbuttonname == "")
                        { // Blank spanish name - substitute English
                            spanishbuttonname = row["ButtonName"].ToString();
                        }
                        string line = "Food," + row["TypeID"] + "," + row["FullName"] + "\\" + row["ButtonName"] + ","
                            + spanishfullname + "\\" + spanishbuttonname
                            + ",$" + ((decimal)row["Cost"]).ToString("####0.000") + "," + row["ImpliedStation"]
                            + "," + row["ImpliedDaypart"] + "," + row["VolumeWeight"]
                            + "," + row["VolumeUnits"] + "," + row["UniqueName"];
                        sw.WriteLine(line);
                    }
                    //*****
                    //***** Write out Loss Buttons (ONE SET OF RECORDS PER TRACKER)
                    //*****
                    foreach (DataRowView row in dvLossButtons)
                    {
                        spanishfullname = row["SpanishFullName"].ToString();
                        if (Regex.IsMatch(spanishfullname, "\\\\")) // "if there is any occurrance of "\\""
                        { // Blank spanish name - substitute English
                            spanishfullname = row["FullName"].ToString();
                        }
                        spanishbuttonname = row["SpanishButtonName"].ToString();
                        if (spanishbuttonname == "")
                        { // Blank spanish name - substitute English
                            spanishbuttonname = row["ButtonName"].ToString();
                        }
                        string line = "Loss," + row["TypeID"] + "," + row["FullName"] + "\\" + row["ButtonName"] + ","
                            + spanishfullname + "\\" + spanishbuttonname + ","
                            + ((bool)row["OverproductionFlag"] ? -1 : 0).ToString() + "," + ((bool)row["TrimWasteFlag"] ? -1 : 0).ToString() + "," +
                            ((bool)row["HandlingFlag"] ? -1 : 0).ToString();
                        sw.WriteLine(line);
                    }

                    //*****
                    //***** Write out Container Buttons (ONE SET OF RECORDS PER TRACKER)
                    //*****
                    foreach (DataRowView row in dvContainerButtons)
                    {
                        spanishfullname = row["SpanishFullName"].ToString();
                        if (Regex.IsMatch(spanishfullname, "\\\\")) // "if there is any occurrance of "\\""
                        { // Blank spanish name - substitute English
                            spanishfullname = row["FullName"].ToString();
                        }
                        spanishbuttonname = row["SpanishButtonName"].ToString();
                        if (spanishbuttonname == "")
                        { // Blank spanish name - substitute English
                            spanishbuttonname = row["ButtonName"].ToString();
                        }

                        string line = "Cont," + row["TypeID"] + "," + row["FullName"] + "\\" + row["ButtonName"] + ","
                            + spanishfullname + "\\" + spanishbuttonname + ","
                            + row["TareWeight"] + ",$" + ((decimal)row["Cost"]).ToString("####0.000") + ","
                            + row["Volume"] + "," + row["UniqueName"];
                        sw.WriteLine(line);
                    }
                    //*****
                    //***** Write out Question Buttons (ONE SET OF RECORDS PER TRACKER)
                    //*****
                    // bool post = true;
                    foreach (DataRowView row in dvQuestionButtons)
                    {
                        spanishfullname = row["SpanishFullName"].ToString();
                        if (Regex.IsMatch(spanishfullname, "\\\\")) // "if there is any occurrance of "\\""
                        { // Blank spanish name - substitute English
                            spanishfullname = row["FullName"].ToString();
                        }
                        spanishbuttonname = row["SpanishButtonName"].ToString();
                        if (spanishbuttonname == "")
                        { // Blank spanish name - substitute English
                            spanishbuttonname = row["ButtonName"].ToString();
                        }
                        string line = "";
                        line = ((bool)row["IsPreQ"]) ? "PreQ," : "PostQ,";
                        //
                        line += row["MenuType"] + "," + row["FullName"] + "\\" + row["ButtonName"] + ","
                            + spanishfullname + "\\" + spanishbuttonname + ",";
                        // Handle various flavors of Question types
                        switch ((int)row["MenuType"])
                        {
                            case (1): // Station
                                {
                                    line += row["TypeID"];
                                    break;
                                }
                            case (2): // Disposition
                                {
                                    line += row["TypeID"];
                                    break;
                                }
                            case (3): // Daypart
                                {
                                    line += row["TypeID"];
                                    break;
                                }
                            case (4): // Event Order
                                {
                                    // field is left blank
                                    break;
                                }
                            case (5): // Pre/Post Consumer
                                {
                                    string tempstr = (string)row["TypeID"];
                                    tempstr = tempstr.Substring(1, 3).ToLower();
                                    switch (tempstr)
                                    {
                                        case ("pre"): line += "Pre";
                                            break;
                                        case ("pos"): line += "Post";
                                            break;
                                        case ("int"): line += "Int";
                                            break;
                                    }

                                    break;
                                }
                            case (6): // User defined Question
                                {
                                    // field is left blank
                                    break;
                                }
                        }
                        sw.WriteLine(line);  // write the Question Button record
                    } // foreach loop end

					//*****
					//***** Write out Memorized Transaction Buttons (ONE SET OF RECORDS PER TRACKER)
					//*****
					foreach (DataRowView row in dvPaperUIButtons)
					{
						spanishfullname = row["SpanishFullName"].ToString();
						if (Regex.IsMatch(spanishfullname, "\\\\")) // "if there is any occurrance of "\\""
						{ // Blank spanish name - substitute English
							spanishfullname = row["FullName"].ToString();
						}
						spanishbuttonname = row["SpanishButtonName"].ToString();
						if (spanishbuttonname == "")
						{ // Blank spanish name - substitute English
							spanishbuttonname = row["ButtonName"].ToString();
						}

						string line = "MemTrans," + row["FullName"] + "\\" + row["ButtonName"] + ","
							+ spanishfullname + "\\" + spanishbuttonname + ","
							+ row["UnitTypeKey"] + "," + row["UnitTypeDisplayName"] + "," + row["UnitaryFoodWeight"] + ","
							+ row["PrePostConsumerFlag"] + "," + row["FoodTypeName"] + "," + row["FoodTypeID"] + ",$" 
							+ ((decimal)row["FoodTypeCost"]).ToString("####0.000") + "," + row["LossTypeName"] + ","
							+ row["LossTypeID"] + "," + row["ContainerTypeName"] + "," + row["ContainerTypeID"] + ","
							+ row["ContainerWeight"] + ",$" + ((decimal)row["ContainerCost"]).ToString("####0.000") + ","
							+ row["StationTypeID"] + "," + row["DispositionTypeID"] + "," 
							+ row["DaypartTypeID"] + "," + row["UserDefinedQuestionButton"];
						sw.WriteLine(line);
					}
				}
				// Denote that the Tracker config has been transferred
				VWA4Common.GlobalSettings.TrackerConfigOutofSync = false;
				lMessage.BackColor = VWA4Common.GlobalSettings.BackColor_Success;
				if (!activesyncxfer)
				{
					pbNextStepDiagram1.Show();
					lMessage.Text = "Tracker Update Successfully Transferred to\n" + outputpathname;
					lNextStepText.Show();
				}
				else
				{
					pbActiveSync.Show();
					lNextStep2.Show();
				}
					pbNextStepDiagram1.Show();
            }
            /// Exception anywhere is fatal
            catch (Exception ex)
            {
				VWA4Common.ProgressDialog.CloseProgressForm();

				MessageBox.Show(ex.Message);
				lMessage.Text = "Tracker Configuration Transfer Not Completed!";
				lMessage.BackColor = VWA4Common.GlobalSettings.BackColor_Failure;

				if (activesyncxfer)
				{
					lNextStepError.Text = "Make sure your ActiveSync connection is active, or contact LeanPath Support.";
				}
				else
				{
					lNextStepError.Text = "Make sure your ValuWaste USB drive is connected, or contact LeanPath Support.";
				}
				lNextStepError.Show();
			}
            /// Always close the output file
            finally
            {
				VWA4Common.ProgressDialog.CloseProgressForm();
				sw.Close();
				lMessage.Show();
			}

        }

        /// <summary>
        /// For specified dimension, create a table containing fully qualified menu/button
        /// names, and calculate levels.  Also provide dimension-specific columns needed for 
        /// the config file.
        /// Then, Sort the table so it is ready to use for exporting the config file.
        /// </summary>
        /// <param name="name">Designates the dimension; used to construct table names.</param>
        /// <returns></returns>
        private DataView GetMenuTable(string name)
        {
            // Create the menu hierarchy table for this dimension
            DataTable dtMenu = CreateMenuHierarchy(name);
            // Create data table
            string sql = CreateSQL(name);  // get the appropriate SQL for the dimension
            DataTable dtMenuButtons = VWA4Common.DB.Retrieve(sql);
            // Copy full names and levels from hierarchy to data table
            dtMenuButtons.TableName = "FullMenuButtonsInfo";
            dtMenuButtons.Columns.Add("FullName", typeof(string));
            dtMenuButtons.Columns.Add("SpanishFullName", typeof(string));
            // Exceptions for specific dimensions
            if (name == "Food")
            {
                dtMenuButtons.Columns.Add("ImpliedStation", typeof(string));
                dtMenuButtons.Columns.Add("ImpliedDaypart", typeof(string));
            }
            else if(name == "Question")
                dtMenuButtons.Columns.Add("IsPreQ", typeof(bool));
            dtMenuButtons.Columns.Add("Level", typeof(int));
            foreach (DataRow thisRow in dtMenuButtons.Rows)
            {
                // find  menu
                DataRow menuRow;
                object[] strFind = new object[1];
                strFind[0] = int.Parse(thisRow["MenuID"].ToString());
                menuRow = dtMenu.Rows.Find(strFind);
                thisRow["FullName"] = menuRow["FullName"];
                thisRow["SpanishFullName"] = menuRow["SpanishFullName"];
                if (name == "Food")
                {
                    thisRow["ImpliedStation"] = menuRow["ImpliedStation"];
                    thisRow["ImpliedDaypart"] = menuRow["ImpliedDaypart"];
                }
                else if (name == "Question")
                    thisRow["IsPreQ"] = menuRow["IsPreQ"];
                thisRow["Level"] = menuRow["Level"];
            }

            //put datatable to view to be able to filter and sort it
            DataView view = new DataView();
            view.Table = dtMenuButtons;
            view.Sort = "Level";
            return view;
        }

        /// <summary>
        /// Provide the SQL needed to retrieve necessary data from joining the type, menu and button tables,
        /// for the specified data dimension.
        /// </summary>
        /// <param name="name">Designates the dimension; used to construct table names.</param>
        /// <returns></returns>
        private string CreateSQL(string name)
        {
            string sql = "";
            // todo: add code to handle subtypes associated with different type catalogs
            switch (name)
            {
                case "User": sql = "SELECT ButtonName, SpanishButtonName, Tracker" + name + "Buttons.TermID AS TermID, " 
                        + name + "Type.TypeID AS TypeID, PIN, UserLanguage, ButtonID, Tracker" + name + "Menus.MenuID AS MenuID,ParentMenuID, MenuName, "
                        + " Iif(Tracker" + name + "Buttons.Rank IS NULL, '999999', Format(Tracker" + name + "Buttons.Rank, '000000')) AS ButtonRank, "
                        + " Iif(Tracker" + name + "Menus.Rank IS NULL, '999999', Format(Tracker" + name + "Menus.Rank, '000000')) AS MenuRank, "
                        + " Tracker" + name + "Menus.MenuName AS MenuName"
                        + " FROM Tracker" + name + "Menus, Tracker" + name + "Buttons INNER JOIN " + name + "Type ON "
                        + " Tracker" + name + "Buttons.TypeID = " + name + "Type.TypeID "
                        + " WHERE Tracker" + name + "Menus.MenuID = Tracker" + name + "Buttons.MenuID"
                        + " ORDER BY Tracker" + name + "Buttons.Rank, ButtonName";
                    break;
                
                //case "Food": sql = "SELECT Cost, VolumeWeight, VolumeUnits, VolumeUnitType, ButtonName, SpanishButtonName, Tracker"
                //    + name + "Buttons.TermID AS TermID, " +
                //    name + "Type.TypeID AS TypeID, ButtonID, Tracker" + name + "Menus.MenuID AS MenuID,ParentMenuID MenuName" +
                //   " FROM Tracker" + name + "Menus, Tracker" + name + "Buttons INNER JOIN " + name + "Type ON " +
                //   " Tracker" + name + "Buttons.TypeID = " + name + "Type.TypeID " +
                //   " WHERE Tracker" + name + "Menus.MenuID = Tracker" + name + "Buttons.MenuID" +
                //   " ORDER BY Tracker" + name + "Buttons.Rank, ButtonName";
                //    break;

                case "Food": sql = "SELECT Cost, VolumeWeight, VolumeUnits, VolumeUnitType, ButtonName, SpanishButtonName, TrackerFoodButtons.TermID AS TermID, "
                        + " Iif(TrackerFoodButtons.Rank IS NULL, '999999', Format(TrackerFoodButtons.Rank, '000000')) AS ButtonRank, "
                        + " FoodType.TypeID AS TypeID, ButtonID, TrackerFoodMenus.MenuID AS MenuID, "
                        + " Iif(TrackerFoodMenus.Rank IS NULL, '999999', Format(TrackerFoodMenus.Rank, '000000')) AS MenuRank, "
                        + " ParentMenuID, UnitsVolume.UniqueName, MenuName"
                        + " FROM TrackerFoodMenus INNER JOIN (TrackerFoodButtons INNER JOIN(FoodType LEFT JOIN UnitsVolume ON FoodType.VolumeUnitType=UnitsVolume.ID)"
                        + " ON TrackerFoodButtons.TypeID = FoodType.TypeID) ON TrackerFoodMenus.MenuID=TrackerFoodButtons.MenuID"
                        + " ORDER BY TrackerFoodMenus.Rank, TrackerFoodMenus.MenuName, TrackerFoodButtons.Rank, TrackerFoodButtons.ButtonName";
                    break;

                case "Loss": sql = "SELECT OverProductionFlag, TrimWasteFlag, HandlingFlag, ButtonName, SpanishButtonName, TrackerLossButtons.TermID AS TermID, "
                        + " Iif(TrackerLossButtons.Rank IS NULL, '999999', Format(TrackerLossButtons.Rank, '000000')) AS ButtonRank, " 
                        + " LossType.TypeID AS TypeID, ButtonID, TrackerLossMenus.MenuID AS MenuID, "
                        + " Iif(TrackerLossMenus.Rank IS NULL, '999999', Format(TrackerLossMenus.Rank, '000000')) AS MenuRank, "
                        + " ParentMenuID, MenuName"
                        + " FROM TrackerLossMenus, TrackerLossButtons INNER JOIN LossType ON TrackerLossButtons.TypeID = LossType.TypeID "
                        + " WHERE TrackerLossMenus.MenuID = TrackerLossButtons.MenuID"
                        + " ORDER BY TrackerLossMenus.Rank, TrackerLossMenus.MenuName, TrackerLossButtons.Rank, TrackerLossButtons.ButtonName";
                    break;

                case "Container": sql = "SELECT TareWeight, Cost, Volume, VolumeUnitType, ButtonName, SpanishButtonName, TrackerContainerButtons.TermID AS TermID, "
                        + " Iif(TrackerContainerButtons.Rank IS NULL, '999999', Format(TrackerContainerButtons.Rank, '000000')) AS ButtonRank, "
                        + " ContainerType.TypeID AS TypeID, ButtonID, TrackerContainerMenus.MenuID AS MenuID, "
                        + " Iif(TrackerContainerMenus.Rank IS NULL, '999999', Format(TrackerContainerMenus.Rank, '000000')) AS MenuRank, "
                        + " ParentMenuID, UnitsVolume.UniqueName, MenuName"
                        + " FROM TrackerContainerMenus INNER JOIN (TrackerContainerButtons INNER JOIN "
                        + " (ContainerType LEFT JOIN UnitsVolume ON ContainerType.VolumeUnitType=UnitsVolume.ID)"
                        + " ON TrackerContainerButtons.TypeID = ContainerType.TypeID) ON TrackerContainerMenus.MenuID=TrackerContainerButtons.MenuID"
                        + " ORDER BY TrackerContainerMenus.Rank, TrackerContainerMenus.MenuName, TrackerContainerButtons.Rank, TrackerContainerButtons.ButtonName";
                    break;

				case "Question": sql = "SELECT MenuType, ButtonName, SpanishButtonName, TrackerQuestionButtons.TermID AS TermID, "
                        + " Iif(TrackerQuestionButtons.Rank IS NULL, '999999', Format(TrackerQuestionButtons.Rank, '000000')) AS ButtonRank, "
                        + " TrackerQuestionButtons.TypeID AS TypeID, ButtonID, Tracker"
                        + "QuestionMenus.MenuID AS MenuID,ParentMenuID, "
                        + " Iif(TrackerQuestionMenus.Rank IS NULL, '999999', Format(TrackerQuestionMenus.Rank, '000000')) AS MenuRank, MenuName"
                        + " FROM TrackerQuestionMenus, TrackerQuestionButtons "
                        + " WHERE TrackerQuestionMenus.MenuID = TrackerQuestionButtons.MenuID"
                        + " ORDER BY TrackerQuestionMenus.Rank, TrackerQuestionMenus.MenuName, TrackerQuestionButtons.Rank, TrackerQuestionButtons.ButtonName";
					break;

				case "PaperUI": sql = "SELECT ButtonName, SpanishButtonName, TrackerPaperUIButtons.TermID AS TermID, "
                        + " Iif(TrackerPaperUIButtons.Rank IS NULL, '999999', Format(TrackerPaperUIButtons.Rank, '000000')) AS ButtonRank, "
                        + " TrackerPaperUIButtons.TypeID AS TypeID, ButtonID, "
                        + "TrackerPaperUIMenus.MenuID AS MenuID,ParentMenuID, "
                        + " Iif(TrackerPaperUIMenus.Rank IS NULL, '999999', Format(TrackerPaperUIMenus.Rank, '000000')) AS MenuRank, MenuName, "
                        + "UnitTypeKey, UnitTypeDisplayName, UnitaryFoodWeight, PrePostConsumerFlag, FoodTypeName, FoodTypeID, FoodTypeCost, "
                        + "LossTypeName, LossTypeID, ContainerTypeName, ContainerTypeID, ContainerWeight, ContainerCost, StationTypeName, StationTypeID, "
                        + "DispositionTypeName, DispositionTypeID, DaypartTypeName, DaypartTypeID, UserDefinedQuestionButton"
                        + " FROM TrackerPaperUIMenus, TrackerPaperUIButtons "
                        + " WHERE (TrackerPaperUIMenus.MenuID = TrackerPaperUIButtons.MenuID)"
                        + " ORDER BY TrackerPaperUIMenus.Rank, TrackerPaperUIMenus.MenuName, TrackerPaperUIButtons.Rank, TrackerPaperUIButtons.ButtonName";
					break;
			}
            return sql;
        }


        /// <summary>
        /// Append Tracker records for the specified Tracker to the file represented by the specified open 
        /// stream.
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="termid"></param>
        private void WriteTrackerRecs(StreamWriter sw, string termid)
        {
        }

        /// <summary>
        /// Create a hierarchy table with full names and levels, return it to caller.
        /// 
        /// Contains logic to handle the special case of ImpliedStation and Implied Daypart;
        /// this serves to set these values for each (food dimension only) config record
        /// based on the lowest specified menu level taking precedence.  When unspecified
        /// within a particular menu, the implicit settings are inherited from the parent
        /// menu.
        /// </summary>
        /// <param name="name">Designates the dimension; used to construct table names.</param>
        /// <returns>DataTable with menu hierarchy names built and meta data prepped.</returns>
        private DataTable CreateMenuHierarchy(string name)
        {
            // create hierarchy table with full names and calculate level
            //
            // get the table data for the Menus
            DataTable dtMenu = VWA4Common.DB.Retrieve("SELECT * FROM Tracker" + name + "Menus");
            // say where is the key column to datatable
            DataColumn[] menukeys = new DataColumn[1];
            menukeys[0] = dtMenu.Columns["MenuID"];
            dtMenu.PrimaryKey = menukeys;
            // create columns to hold the fully qualified names we are building
            dtMenu.Columns.Add("FullName", typeof(string));
            dtMenu.Columns.Add("SpanishFullName", typeof(string));
            // if the dimension is Food, then we use the Implied station and daypart columns
            if (name == "Food")
            {
                dtMenu.Columns.Add("ImpliedStation", typeof(string));
                dtMenu.Columns.Add("ImpliedDaypart", typeof(string));
            }
            else if(name == "Question") // then we need a column for question order position
                dtMenu.Columns.Add("IsPreQ", typeof(bool));
            
            // need a column to hold the level of the menu
            dtMenu.Columns.Add("Level", typeof(int));
            // iterate through the menu table, build the top menu of the name hierarchies
            foreach (DataRow thisRow in dtMenu.Rows)
            {
                if (int.Parse(thisRow["ParentMenuID"].ToString()) != 0)
                {
                    thisRow["FullName"] = "\\" + thisRow["MenuName"];
                    thisRow["SpanishFullName"] = "\\" + thisRow["SpanishMenuName"];
                }
                if (name == "Food")
                {
                    thisRow["ImpliedStation"] = thisRow["ImpliedStationTypeID"];
                    thisRow["ImpliedDaypart"] = thisRow["ImpliedDaypartTypeID"];
                }
            }

            // pass all rows in DataTable 
            foreach (DataRow thisRow in dtMenu.Rows)
            {
                int Level = 0;
                // recursively look up the tree and count the levels 
                int parentID = int.Parse(thisRow["ParentMenuID"].ToString());
                while (!(parentID == 0))
                {
                    // find parent 
                    DataRow parentRow;
                    object[] strFind = new object[1];
                    strFind[0] = parentID;
                    parentRow = dtMenu.Rows.Find(strFind);

                    // set to look for parent or throw error if no parent found 
                    if (parentRow == null)
                    {
						VWA4Common.ProgressDialog.CloseProgressForm();
						MessageBox.Show("No Parent Found for " + parentID.ToString());
                        parentID = 0;
                    }
                    else
                    {
                        parentID = int.Parse(parentRow["ParentMenuID"].ToString());
                        if (parentID != 0)
                        {
                            thisRow["FullName"] = "\\" + parentRow["MenuName"].ToString() + thisRow["FullName"].ToString();
                            thisRow["SpanishFullName"] = "\\" + parentRow["SpanishMenuName"].ToString() + thisRow["SpanishFullName"].ToString();
                        }
                        else if (name == "Question")
                            thisRow["IsPreQ"] = Regex.IsMatch(parentRow["MenuName"].ToString(), @"^\(Pre");
                        //
						if (name == "Food")
                        {
                            if (thisRow["ImpliedStation"].ToString() == "")
                                thisRow["ImpliedStation"] = parentRow["ImpliedStationTypeID"];
                            if (thisRow["ImpliedDaypart"].ToString() == "")
                                thisRow["ImpliedDaypart"] = parentRow["ImpliedDaypartTypeID"];
                        }
                        Level++;
                    }
                }
                thisRow["Level"] = Level;
            }
            return dtMenu;
        }

		private void bDone_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}
   

        //private ArrayList DirSearch(string dir, string pattern)
        //{
        //    ArrayList res = new ArrayList();
        //    try
        //    {
        //        foreach (string d in Directory.GetDirectories(dir))
        //        {
        //            try
        //            {
        //                foreach (string f in Directory.GetFiles(d, pattern))

        //                    res.Add(f);
        //            }
        //            catch { }
        //            res.AddRange(DirSearch(d, pattern));
        //        }
        //    }
        //    catch { }
        //    return res;
        //}

    } 
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using VWAUpdater.com.updatemanager;
using VWAUpdater.Models;
using UpdateStatus = VWAUpdater.Models.UpdateStatus;

namespace VWAUpdater
{
    public partial class Main : Form
    {
        public BackgroundWorker thread = new BackgroundWorker();
        public UpdateFile currentFile;
        public UpdateManager updateService = new UpdateManager { Credentials = new NetworkCredential("LMAN", "530E9D3B-7ACC-4F9D-B16F-2FEBA545C8B1") };

        public UpdateStatus Status = UpdateStatus.Update;
        public List<Guid> FileIds = new List<Guid>();

        public int NumFiles = 0;
        public int NumFilesUpdated = 0;

        public List<BackupFile> OldFiles = new List<BackupFile>();

        public Main(IEnumerable<Guid> ids, int index, int total)
        {
            FileIds.AddRange(ids);
            NumFiles = FileIds.Count;

            thread.WorkerReportsProgress = true;
            thread.WorkerSupportsCancellation = true;
            thread.DoWork += thread_DoWork;
            thread.ProgressChanged += thread_ProgressChanged;

            InitializeComponent();

            lblTotalUpdates.Text = string.Format("Performing Update ({0} of {1})", index, total);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            NumFilesUpdated++;
            updateStatus("Starting...", null, null);
            doNext();
        }

        private void doNext()
        {
            foreach (Guid id in FileIds)
            {
                currentFile = updateService.GetUpdateFileById(id);
                updateStatus("Downloading File", null, null);
                thread.RunWorkerAsync();
                return;
            }

            tmrDoUploads.Stop();
            updateStatus("Update Completed Successfully", null, null);
            Close();
        }

        private void updateStatus(string msg, int? cur, int? total)
        {
            txtOutput.Text += string.Format("{0} ({1}/{2}){3}", msg, cur.GetValueOrDefault(NumFilesUpdated), total.GetValueOrDefault(NumFiles), Environment.NewLine);
        }

        void thread_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                long fileLength = updateService.StartDownload(currentFile.Id);
                byte[] fileData = new byte[0];

                while (fileData.Length < fileLength && !Status.Equals(UpdateStatus.Error) && !Status.Equals(UpdateStatus.Cancel))
                {
                    var buffer = updateService.Download(currentFile.Id, fileData.Length);

                    var concat = new byte[fileData.Length + buffer.Length];
                    Buffer.BlockCopy(fileData, 0, concat, 0, fileData.Length);
                    Buffer.BlockCopy(buffer, 0, concat, fileData.Length, buffer.Length);

                    fileData = new byte[concat.Length];
                    concat.CopyTo(fileData, 0);

                    double t1 = (double)fileData.Length / fileLength;
                    int done = Convert.ToInt32(t1 * 100);
                    thread.ReportProgress(done);
                }

                //read old file into memory incase there is a error, delete it
                string path = Path.GetDirectoryName(Application.ExecutablePath) + currentFile.InstallPath;
                path = Path.Combine(path, currentFile.FileName);

                try
                {
                    var oldFileStream = File.Open(path, FileMode.Open, FileAccess.Read);
                    var oldFileData = new byte[oldFileStream.Length];
                    oldFileStream.Read(oldFileData, 0, (int)oldFileStream.Length);
                    oldFileStream.Close();
                    File.Delete(path);

                    OldFiles.Add(new BackupFile { FileData = oldFileData, FilePath = path });
                }
                catch(Exception)
                {
                    
                }

                //write new file to hd
                var fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
                fs.Write(fileData, 0, fileData.Length);
                fs.Close();
                FileIds.Remove(currentFile.Id);
            }
            catch (Exception ex)
            {   
                //write all old files back to hd and error out
                thread.ReportProgress(0);
                thread.CancelAsync();
                Status = UpdateStatus.Error;
            }
        }

        void thread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(Status.Equals(UpdateStatus.Error))
            {
                updateError();
                return;
            }

            prgUpload.Value = e.ProgressPercentage;
            lblPercentComplete.Text = string.Format("{0}%", e.ProgressPercentage);
            if(e.ProgressPercentage == 100)
            {
                updateStatus("Copying File", null, null);
            }
        }

        private void updateError()
        {
            pnlDownloadProgress.Visible = false;
            updateStatus("Error Updating", null, null);
            tmrDoUploads.Enabled = false;
            revertFiles();
            Close();
        }

        private void revertFiles()
        {
            int rc = 0;
            foreach (var f in OldFiles)
            {
                try
                {
                    updateStatus("Reverting", rc++, OldFiles.Count);
                    var fs = new FileStream(f.FilePath, FileMode.CreateNew, FileAccess.Write);
                    fs.Write(f.FileData, 0, f.FileData.Length);
                    fs.Close();
                    fs.Dispose();
                }
                catch(Exception)
                {
                    updateStatus("Error Reverting", rc, OldFiles.Count);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Status = UpdateStatus.Cancel;
            txtOutput.Text += string.Format("Canceling update...{0}", Environment.NewLine);
            thread.CancelAsync();
            revertFiles();
            Close();
        }

        private void tmrDoUploads_Tick(object sender, EventArgs e)
        {
            if (!thread.IsBusy)
            {
                updateStatus("Finished", null, null);
                NumFilesUpdated++;
                doNext();
            }
        }
    }
}

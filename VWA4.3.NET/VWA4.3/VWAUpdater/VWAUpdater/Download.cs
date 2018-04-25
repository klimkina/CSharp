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

namespace VWAUpdater
{
    public partial class Download : Form
    {
        public BackgroundWorker thread = new BackgroundWorker();
        public UpdateFile currentFile;
        public UpdateManager updateService = new UpdateManager { Credentials = new NetworkCredential("LMAN", "530E9D3B-7ACC-4F9D-B16F-2FEBA545C8B1") };
        public bool CancelDownload = false;
        public List<Guid> FileIds = new List<Guid>();

        public Download(IEnumerable<Guid> ids)
        {
            FileIds.AddRange(ids);

            thread.WorkerReportsProgress = true;
            thread.WorkerSupportsCancellation = true;
            thread.DoWork += new DoWorkEventHandler(thread_DoWork);
            thread.ProgressChanged += new ProgressChangedEventHandler(thread_ProgressChanged);

            InitializeComponent();
        }

        private void Download_Load(object sender, EventArgs e)
        {
            doNext();
        }

        private void doNext()
        {
            foreach(Guid id in FileIds)
            {
                currentFile = updateService.GetUpdateFileById(id);
                lblDetails.Text = string.Format("Downloading: {0}", currentFile.FileName);
                thread.RunWorkerAsync();
                return;
            }

            tmrDoUploads.Stop();
            Close();
        }

        void thread_DoWork(object sender, DoWorkEventArgs e)
        {
            long fileLength = updateService.StartDownload(currentFile.Id);
            byte[] fileData = new byte[0];

            while(fileData.Length < fileLength && !CancelDownload)
            {
                var buffer = updateService.Download(currentFile.Id, fileData.Length);

                var concat = new byte[fileData.Length + buffer.Length];
                Buffer.BlockCopy(fileData, 0, concat, 0, fileData.Length);
                Buffer.BlockCopy(buffer, 0, concat, fileData.Length, buffer.Length);

                fileData = new byte[concat.Length];
                concat.CopyTo(fileData, 0);

                double t1 = (double)fileData.Length/ fileLength;
                int done = Convert.ToInt32(t1 * 100);
                thread.ReportProgress(done);
            }

            //read old file into memory incase there is a error, delete it
            string path = Path.GetDirectoryName(Application.ExecutablePath) + currentFile.InstallPath;
            path = Path.Combine(path, currentFile.FileName);
            var oldFileStream = File.Open(path, FileMode.Open, FileAccess.Read);
            var oldFileData = new byte[oldFileStream.Length];
            oldFileStream.Read(oldFileData, 0, (int)oldFileStream.Length);
            oldFileStream.Close();
            File.Delete(path);

            try
            {
                //write new file to hd
                var fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
                fs.Write(fileData, 0, fileData.Length);
                fs.Close();

                FileIds.Remove(currentFile.Id);
            }
            catch(Exception ex)
            {
                //write old file back to hd
                var fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
                fs.Write(oldFileData, 0, oldFileData.Length);
                fs.Close();
            }
        }

        void thread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgUpload.Value = e.ProgressPercentage;
            if (e.ProgressPercentage.Equals(100))
                lblDetails.Text = string.Format("Copying: {0}", currentFile.FileName);
           
            lblPercentComplete.Text = string.Format("{0}%", e.ProgressPercentage);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            thread.CancelAsync();
            CancelDownload = true;

            Close();
        }

        private void tmrDoUploads_Tick(object sender, EventArgs e)
        {
            if (!thread.IsBusy)
            {
                doNext();
            }
        }   
    }
}

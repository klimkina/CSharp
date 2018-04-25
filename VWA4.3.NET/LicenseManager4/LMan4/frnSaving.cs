using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using LMan4.com.updatemanager;
using LMan4.Updates;
using Update = LMan4.com.updatemanager.Update;

namespace LMan4
{
    public partial class frmSaving : Form
    {
        public const int BufferSize = 10420;

        private UpdateManager updateService = new UpdateManager();
        private bool CancelUpload = false;
        private FileStream file;
        private UploadFileUiModel currentFile;

        public Update currentUpdate = new Update();
        public List<UploadFileUiModel> Files;

        public BackgroundWorker thread = new BackgroundWorker();

        public frmSaving(Update cu, List<UploadFileUiModel> fs)
        {
            this.currentUpdate = cu;
            Files = fs;

            thread.WorkerReportsProgress = true;
            thread.WorkerSupportsCancellation = true;
            thread.DoWork += new DoWorkEventHandler(thread_DoWork);
            thread.ProgressChanged += new ProgressChangedEventHandler(thread_ProgressChanged);
            
            InitializeComponent();
        }

        private void frmSaving_Load(object sender, EventArgs e)
        {
            updateService.Credentials = new NetworkCredential("LMAN", "530E9D3B-7ACC-4F9D-B16F-2FEBA545C8B1");
            
            tmrDoUploads.Start();
            doNext();
        }

        private void doNext()
        {
            foreach (var uf in from object f in Files
                        select f as UploadFileUiModel
                        into uf where uf != null && uf.Id.Equals(Guid.Empty)
                        select uf)
            {
                currentFile = uf;
                file = new FileStream(currentFile.FilePath, FileMode.Open);
                lblDetails.Text = string.Format("Uploading: {0}", currentFile.FileName);
                thread.RunWorkerAsync();
                return;
            }
            tmrDoUploads.Stop();
            this.Close();
        }

        void thread_DoWork(object sender, DoWorkEventArgs e)
        {
            var fileContents = new byte[file.Length];
            currentFile.Id = updateService.StartUpload(currentUpdate.Id, currentFile.FileName, currentFile.InstallPath);

            try
            {
                file.Read(fileContents, 0, Convert.ToInt32(file.Length));

                int bytesRead = 0;
                int bytesToRead = (int)file.Length;
                var buffer = new byte[BufferSize];
                int i = 0;

                while (bytesToRead > 0 && !CancelUpload)
                {
                    Buffer.BlockCopy(fileContents, bytesRead, buffer, 0, (file.Length - bytesRead) < BufferSize ? (int)(file.Length - bytesRead) : BufferSize);
                    bytesRead += BufferSize;

                    string msg = updateService.AppendUpload(currentFile.Id, buffer);

                    double t1 = (double)bytesRead / file.Length;
                    int done = Convert.ToInt32(t1 * 100);

                    thread.ReportProgress(done < 100 ? done : 100);
                    if (msg != "Success")
                    {
                        MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK);
                    }

                    buffer = new byte[BufferSize];
                    bytesToRead -= BufferSize;
                }

                updateService.FinishUpload(currentFile.Id);
            }
            catch (Exception ex)
            {
                updateService.CancelUpload(currentFile.Id);
            }
            finally
            {
                file.Close();
                file.Dispose();
            }
        }

        void thread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgUpload.Value = e.ProgressPercentage;
            this.lblPercentComplete.Text = string.Format("{0}%", e.ProgressPercentage);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            thread.CancelAsync();
            CancelUpload = true;
            updateService.CancelAllUploadsByUpdateId(currentUpdate.Id);
            
            Close();
        }

        private void tmrDoUploads_Tick(object sender, EventArgs e)
        {
            if(!thread.IsBusy)
            {
                doNext();
            }
        }
    }
}

using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using VWAUpdater.com.updatemanager;

namespace VWAUpdater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var updateService = new UpdateManager { Credentials = new NetworkCredential(Properties.Settings.Default.ws_username, Properties.Settings.Default.ws_password) };
            var applicationId = args.Select(x => Guid.Parse(x)).First();//first argument is always applicationid
            var updateSeriesIds = args.Skip(1).Select(s => Guid.Parse(s));//rest of arguements are update series id
            var currentUpdate = 0;

            var allSeries = updateSeriesIds.Select(id => updateService.GetUpdateSeriesById(id));
            var updateTotal = allSeries.SelectMany(t => t.Updates).Where(u => u.UpdateType.Equals(UpdateType.Hotfix)).Count();
            
            foreach (var series in allSeries)
            {
                foreach(var u in series.Updates.Where(u => u.UpdateType.Equals(UpdateType.Update)))
                {
                    try
                    {
                        var frmDownload = new Main(u.UpdateFileIds, 1, 1);
                        frmDownload.ShowDialog();

                        var file = updateService.GetFilesForUpdate(u.Id);
                        var p = new Process { StartInfo = { FileName = file[0].FileName, UseShellExecute = true, } };
                        p.Start();

                        Application.Exit();
                        return;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(string.Format("Error applying updates: {0}\r\n\r\nExiting updater.", ex.Message), "Error", MessageBoxButtons.OK);
                        Application.Exit();
                        break;
                    }
                }
                foreach (var u in series.Updates.Where(u => u.UpdateType.Equals(UpdateType.Hotfix)))
                {
                    try
                    {
                        var frmDownload = new Main(u.UpdateFileIds, ++currentUpdate, updateTotal);
                        frmDownload.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Error applying updates: {0}\r\n\r\nExiting updater.", ex.Message), "Error", MessageBoxButtons.OK);
                        Application.Exit();
                        break;
                    }
                    //complete update on server
                    updateService.CompleteUpdate(applicationId, u.Id);
                }
            }

            RestartVWA4();
        }

        static void RestartVWA4()
        {
            //restart VWA
            var p = new Process { StartInfo = { FileName = @Properties.Settings.Default.VWAFilePath, UseShellExecute = true } };
            p.Start();

            Application.Exit();
        }
    }
}

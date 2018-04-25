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
using LMan4.com.updatemanager;
using LMan4.Updates;
using Version = LMan4.com.updatemanager.Version;
using Update = LMan4.com.updatemanager.Update;

namespace LMan4
{
    public partial class frmManageUpdates : Form
    {
        private bool loadUpdates = false;

        private UpdateManager updateService = new UpdateManager();

        private UpdateSeries currentSeries = new UpdateSeries();
        private Update currentUpdate = new Update();
        private List<UploadFileUiModel> currentFiles = new List<UploadFileUiModel>();

        public frmManageUpdates()
        {
            updateService.Credentials = new NetworkCredential("LMAN", "530E9D3B-7ACC-4F9D-B16F-2FEBA545C8B1");

            InitializeComponent();

            grdFiles.DataSourceChanged += new EventHandler(grdFiles_DataSourceChanged);
        }

        private void updateUpdateSeries()
        {
            //Update series
            lstUpdateSeries.DataSource = updateService.GetAllUpdateSeries();
            lstUpdateSeries.DisplayMember = "Name";
            lstUpdateSeries.ValueMember = "Id";
        }

        private void updateUpdates()
        {
            //Updates
            if(!currentSeries.Id.Equals(Guid.Empty))
            {
                lstUpdates.DataSource = updateService.GetUpdatesBySeriesId(currentSeries.Id);
                lstUpdates.DisplayMember = "Name";
                lstUpdates.ValueMember = "Id";
            }
        }

        private void updateVersions()
        {
            //versions
            var allversions = updateService.GetAllVersions();

            lstVersions.DataSource = allversions;
            lstVersions.DisplayMember = "VersionName";
            lstVersions.ValueMember = "Id";

            lstSeriesVersions.DataSource = allversions;
            lstSeriesVersions.DisplayMember = "VersionName";
            lstSeriesVersions.ValueMember = "Id";

            lstVersions.SelectedIndex = -1;
            lstSeriesVersions.SelectedIndex = -1;
        }

        private void populateUpdateSeries(UpdateSeries us)
        {
            this.txtSeriesName.Text = us.Name;
            this.txtSeriesDescription.Text = us.Description;
            this.lblSeriesDateCreated.Text = us.DateCreated.ToShortDateString();
            this.lblSeriesDateModified.Text = us.DateModified.ToShortDateString();

            for (var i = 0; i < lstSeriesVersions.Items.Count; i++)
            {
                if(us.Versions != null && us.Versions.Contains((lstSeriesVersions.Items[i] as Version).Id))
                {
                    lstSeriesVersions.SetItemChecked(i, true);
                }
            }
        }

        private void populateUpdate(Update u)
        {
            currentFiles = new List<UploadFileUiModel>();
            this.lblUpdateDateCreated.Text = u.DateCreated.ToShortDateString();
            this.lblUpdateDateModified.Text = u.DateModified.ToShortDateString();
            this.txtUpdateName.Text = u.Name;
            this.txtUpdateDescription.Text = u.Description;
            this.txtInfoMessage.Text = u.Message;

            if(u.UpdateType.Equals(UpdateType.Hotfix))
            {
                currentFiles.AddRange(updateService.GetFilesForUpdate(u.Id).Select(x => new UploadFileUiModel { Id = x.Id, FileName = x.FileName, FilePath = "Uploaded", InstallPath = x.InstallPath }));
                
                updateFileGrid(new BindingSource {DataSource = currentFiles});
            }
        }
        
        private void btnAddVersion_Click(object sender, EventArgs e)
        {
            var newversion = new Version {VersionName = txtNewVersionName.Text};

            updateService.SaveVersion(newversion);

            this.txtNewVersionName.Text = string.Empty;
            this.updateVersions();
        }

        private void lstUpdateSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = lstUpdateSeries.SelectedItem as UpdateSeries;
            if(lstUpdateSeries.SelectedItem != null && loadUpdates)
            {
                currentSeries = updateService.GetUpdateSeriesById(selected.Id);
                currentUpdate = new Update();

                populateUpdateSeries(currentSeries);
                populateUpdate(currentUpdate);
                updateUpdates();
            }
        }

        private void lstUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var update = lstUpdates.SelectedItem as Update;
            if(update != null)
            {
                currentUpdate = updateService.GetUpdateById(update.Id);

                populateUpdate(currentUpdate);
            }
        }

        private void btnSaveUpdateSeries_Click(object sender, EventArgs e)
        {
            currentSeries.Name = txtSeriesName.Text;
            currentSeries.Description = txtSeriesDescription.Text;
            currentSeries.Versions = new Guid[lstSeriesVersions.CheckedItems.Count];
            
            for (var i = 0; i < lstSeriesVersions.CheckedItems.Count; i++)
            {
                currentSeries.Versions[i] = (lstSeriesVersions.CheckedItems[i] as Version).Id;
            }

            currentSeries = updateService.SaveUpdateSeries(currentSeries);

            this.updateUpdateSeries();
        }

        private UpdateType getUpdateType()
        {
            switch (updateType.SelectedIndex)
            {
                case 0:
                    return UpdateType.Message;
                case 1:
                    return UpdateType.Hotfix;
                case 2:
                    return UpdateType.Update;
                default:
                    return UpdateType.Message;
            }
        }

        private void btnUpdateSave_Click(object sender, EventArgs e)
        {
            currentUpdate.Name = txtUpdateName.Text;
            currentUpdate.Description = txtUpdateDescription.Text;
            currentUpdate.UpdateType = getUpdateType();
            currentUpdate.Message = txtInfoMessage.Text;
            currentUpdate.UpdateSeriesId = (this.lstUpdateSeries.SelectedItem as UpdateSeries).Id;

            currentUpdate = updateService.SaveUpdate(currentUpdate);

            if (currentUpdate.UpdateType.Equals(UpdateType.Hotfix) || currentUpdate.UpdateType.Equals(UpdateType.Update))
            {
                var save = new frmSaving(currentUpdate, currentFiles);
                save.ShowDialog();
            }

            this.updateUpdates();
            this.populateUpdate(currentUpdate);
        }

        private void btnNewSeries_Click(object sender, EventArgs e)
        {
            this.currentSeries = new UpdateSeries();
            this.populateUpdateSeries(currentSeries);
        }

        private void btnNewUpdate_Click(object sender, EventArgs e)
        {
            this.currentUpdate = new Update();
            this.populateUpdate(currentUpdate);
        }

        private void frmManageUpdates_Load(object sender, EventArgs e)
        {
            this.updateUpdateSeries();
            this.updateUpdates();
            this.updateVersions();

            currentSeries = new UpdateSeries();
            currentUpdate = new Update();

            populateUpdateSeries(currentSeries);
            populateUpdate(currentUpdate);

            this.lstUpdateSeries.SelectedIndex = -1;
            this.lstUpdates.SelectedIndex = -1;

            this.loadUpdates = true;
        }

        private void btnHotFixBrowse_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog {InitialDirectory = Application.StartupPath};

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string installpath = Microsoft.VisualBasic.Interaction.InputBox("Enter install path", "Install Path",
                                                                                "\\");

                currentFiles.Add(new UploadFileUiModel
                                     {
                                         Id = Guid.Empty,
                                         FileName = Path.GetFileName(ofd.FileName),
                                         FilePath = ofd.FileName,
                                         InstallPath = installpath
                                     });

                updateFileGrid(new BindingSource { DataSource = currentFiles });
            }
        }

        private void updateFileGrid(BindingSource bs)
        {
            grdFiles.AutoSize = true;
            grdFiles.DataSource = bs;
        }

        void grdFiles_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                grdFiles.Columns[0].Visible = false;
                grdFiles.Columns[1].Width = 140;
                grdFiles.Columns[2].Width = 235;
                grdFiles.Columns[3].Width = 130;
            }
            catch(Exception) { }
        }

        private void btnDeleteUpdate_Click(object sender, EventArgs e)
        {
            updateService.DeleteUpdateById(currentUpdate.Id);
            currentUpdate = new Update();

            populateUpdateSeries(currentSeries);
            populateUpdate(currentUpdate);
            updateUpdates();
        }
    }
}

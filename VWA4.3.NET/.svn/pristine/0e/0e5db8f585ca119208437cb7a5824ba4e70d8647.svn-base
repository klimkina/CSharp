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

namespace LMan4.Updates
{
    public partial class EditUpdate : Form
    {
        private readonly UpdateManager _updateService = new UpdateManager();
        private Update _currentUpdate = new Update();
        private readonly UpdateSeries _currentUpdateSeries = new UpdateSeries();
        private List<UploadFileUiModel> _currentFiles = new List<UploadFileUiModel>();

        public EditUpdate()
        {
            _updateService.Credentials = new NetworkCredential("LMAN", "530E9D3B-7ACC-4F9D-B16F-2FEBA545C8B1");

            InitializeComponent();
        }

        public EditUpdate(Update u, UpdateSeries us) : this()
        {
            _currentUpdate = u;
            _currentUpdateSeries = us;
        }

        public EditUpdate(UpdateSeries us) : this()
        {
            _currentUpdateSeries = us;
        }

        private void EditUpdate_Load(object sender, EventArgs e)
        {
            grdFiles.CellContentClick += grdFiles_CellContentClick;

            if(_currentUpdate.Id.Equals(Guid.Empty))
            {
                lblDateCreatedValue.Text = DateTime.Now.ToShortDateString();
                lblDateModifiedValue.Text = DateTime.Now.ToShortDateString();
                return;
            }

            _currentFiles = new List<UploadFileUiModel>();
            txtName.Text = _currentUpdate.Name;
            txtDescription.Text = _currentUpdate.Description;
            lblDateCreatedValue.Text = _currentUpdate.DateCreated.ToShortDateString();
            lblDateModifiedValue.Text = _currentUpdate.DateModified.ToShortDateString();
            txtInfoMessage.Text = _currentUpdate.Message;

            if (_currentUpdate.UpdateType.Equals(UpdateType.Hotfix))
            {   
                _currentFiles.AddRange(_updateService.GetFilesForUpdate(_currentUpdate.Id).Select(x => new UploadFileUiModel{Id = x.Id, FileName = x.FileName, FilePath = "Uploaded", InstallPath = x.InstallPath}));
                if(_currentFiles.Count > 0)
                    grdFiles.DataSource = new BindingSource { DataSource = _currentFiles};
            }
        }

        private void btnHotFixBrowse_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog { InitialDirectory = Application.StartupPath };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var installpath = Microsoft.VisualBasic.Interaction.InputBox("Enter install path", "Install Path", "\\");

                _currentFiles.Add(new UploadFileUiModel
                                      {
                                          Id = Guid.Empty,
                                          FileName = Path.GetFileName(ofd.FileName),
                                          FilePath = ofd.FileName,
                                          InstallPath = installpath
                                      });

                grdFiles.Columns.Clear();
                grdFiles.DataSource = new BindingSource {DataSource = _currentFiles};
            }
        }

        void grdFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(4) || e.ColumnIndex.Equals(0))
            {
                //delete
                if (MessageBox.Show("Are you sure you want to delete this file", "Delete file",
                    MessageBoxButtons.OKCancel).Equals(DialogResult.OK))
                {
                    var id = Guid.Empty;
                    Guid.TryParse(grdFiles.Rows[e.RowIndex].Cells[0].Value.ToString(), out id);
                    if (id == Guid.Empty)
                        Guid.TryParse(grdFiles.Rows[e.RowIndex].Cells[1].Value.ToString(), out id);
                    if (!id.Equals(Guid.Empty))
                    {
                        _updateService.DeleteUpload(id);
                    }
                    grdFiles.Rows.RemoveAt(e.RowIndex);
                    _currentFiles.RemoveAt(e.RowIndex);
                }
            }
        }

        private void grdFiles_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                grdFiles.Columns.Insert(grdFiles.Columns.Count, new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Delete",
                    Name = "btnDelete",
                    UseColumnTextForButtonValue = true
                });

                grdFiles.Columns[0].Visible = false;
                grdFiles.Columns[1].Width = 140;
                grdFiles.Columns[2].Width = 200;
                grdFiles.Columns[3].Width = 290;
                grdFiles.Columns[4].Width = 83;
            }
            catch (Exception) { }
        }

        private UpdateType getUpdateType()
        {
            if(txtUpdatePackageFilePath.Text.Length > 0)
            {
                return UpdateType.Update;
            }
            return _currentFiles.Count > 0 ? UpdateType.Hotfix : UpdateType.Message;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _currentUpdate.Name = txtName.Text;
            _currentUpdate.Description = txtDescription.Text;
            _currentUpdate.UpdateType = getUpdateType();
            _currentUpdate.Message = txtInfoMessage.Text;
            _currentUpdate.UpdateSeriesId = _currentUpdateSeries.Id;

            _currentUpdate = _updateService.SaveUpdate(_currentUpdate);

            if(_currentUpdate.UpdateType.Equals(UpdateType.Hotfix) || _currentUpdate.UpdateType.Equals(UpdateType.Update))
            {
                var frmSave = new frmSaving(_currentUpdate, _currentFiles);
                frmSave.ShowDialog();
            }

            Close();
        }

        private void btnUpdateBrowse_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog { InitialDirectory = Application.StartupPath };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tabInfoMessage.Visible = false;
                tabHotFix.Visible = false;

                txtUpdatePackageFilePath.Text = ofd.FileName;
                _currentFiles.Clear();
                _currentFiles.Add(new UploadFileUiModel
                {
                    Id = Guid.Empty,
                    FileName = Path.GetFileName(ofd.FileName),
                    FilePath = ofd.FileName,
                    InstallPath = string.Empty
                });
            }
        }
    }
}

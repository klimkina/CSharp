using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using LMan4.com.updatemanager;
using Version = LMan4.com.updatemanager.Version;

namespace LMan4.Updates
{
    public partial class EditUpdateSeries : Form
    {
        private readonly UpdateManager _updateService = new UpdateManager();
        private UpdateSeries _updateSeries = new UpdateSeries();

        public EditUpdateSeries()
        {
            _updateService.Credentials = new NetworkCredential("LMAN", "530E9D3B-7ACC-4F9D-B16F-2FEBA545C8B1");

            InitializeComponent();
        }

        public EditUpdateSeries(UpdateSeries us) : this()
        {
            _updateSeries = us;
        }

        private void EditUpdateSeries_Load(object sender, EventArgs e)
        {
            grdUpdates.DataSourceChanged += grdUpdates_DataSourceChanged;
            grdUpdates.CellContentClick += grdUpdates_CellContentClick;
            grdUpdates.Width = grdUpdates.Parent.Width;

            if (_updateSeries.Id.Equals(Guid.Empty))
            {
                btnNew.Enabled = false;
                lblDateCreatedValue.Text = DateTime.Now.ToShortDateString();
                lblDateModifiedValue.Text = DateTime.Now.ToShortDateString();

                return;
            }

            lstVersions.DataSource = _updateService.GetAllVersionsForUpdateSeries(_updateSeries.Id);
            lstVersions.DisplayMember = "VersionName";
            lstVersions.ValueMember = "Id";

            txtName.Text = _updateSeries.Name;
            txtDescription.Text = _updateSeries.Description;
            lblDateCreatedValue.Text = _updateSeries.DateCreated.ToShortDateString();
            lblDateModifiedValue.Text = _updateSeries.DateModified.ToShortDateString();

            var allUpdates = _updateService.GetUpdatesBySeriesId(_updateSeries.Id).Select(x => new UpdateUiModel { Id = x.Id, Name = x.Name, Type = x.UpdateType, DateCreated = x.DateCreated });
            if(allUpdates.Count() > 0)
                grdUpdates.DataSource = new BindingSource { DataSource = allUpdates };
        }

        void grdUpdates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(14))
            {
                //edit
                var frm = new EditUpdate(_updateService.GetUpdateById(Guid.Parse(grdUpdates.Rows[e.RowIndex].Cells[0].Value.ToString())), _updateSeries);
                frm.ShowDialog();

                grdUpdates.Columns.Clear();
                grdUpdates.DataSource = new BindingSource { DataSource = _updateService.GetUpdatesBySeriesId(_updateSeries.Id).Select(x => new UpdateUiModel { Id = x.Id, Name = x.Name, Type = x.UpdateType, DateCreated = x.DateCreated }) };
            }
            else if (e.ColumnIndex.Equals(4))
            {
                //delete
                if (MessageBox.Show("Are you sure you want to delete this update", "Delete update",
                    MessageBoxButtons.OKCancel).Equals(DialogResult.OK))
                {
                    _updateService.DeleteUpdateById(Guid.Parse(grdUpdates.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    grdUpdates.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        void grdUpdates_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                //grdUpdates.Columns.Add(new DataGridViewButtonColumn
                //{
                //    HeaderText = "",
                //    Text = "Edit",
                //    Name = "btnEdit",
                //    UseColumnTextForButtonValue = true,
                //});

                grdUpdates.Columns.Add(new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Delete",
                    Name = "btnDelete",
                    UseColumnTextForButtonValue = true
                });

                grdUpdates.Columns[0].Visible = false;
                grdUpdates.Columns[1].Width = 262;
                grdUpdates.Columns[2].Width = 200;
                grdUpdates.Columns[3].Width = 150;
                grdUpdates.Columns[4].Width = 150;
                //grdUpdates.Columns[5].Width = 150;
            }
            catch (Exception) { }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new EditUpdate(_updateSeries);
            frm.ShowDialog();

            grdUpdates.DataSource = new BindingSource { DataSource = _updateService.GetUpdatesBySeriesId(_updateSeries.Id).Select(x => new UpdateUiModel { Id = x.Id, Name = x.Name, Type = x.UpdateType, DateCreated = x.DateCreated }) };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _updateSeries.Name = txtName.Text;
            _updateSeries.Description = txtDescription.Text;
            _updateSeries.DateModified = DateTime.Now;
            _updateSeries.Versions = (from object i in lstVersions.Items select (i as Version).Id).ToArray();

            _updateSeries = _updateService.SaveUpdateSeries(_updateSeries);

            btnNew.Enabled = true;

            MessageBox.Show("Update has been saved.", "Update saved", MessageBoxButtons.OK);
        }

        private void btnAddVersion_Click(object sender, EventArgs e)
        {
            var frm = new AddVersion();
            frm.ShowDialog();

            var allversions = (from object v in lstVersions.Items select v as Version).ToList();
            allversions.AddRange(frm.Versions);

            lstVersions.DataSource = allversions.Distinct().ToList();
        }

        private void btnManageVersions_Click(object sender, EventArgs e)
        {
            var frm = new ManageVersions();
            frm.ShowDialog();
        }

        private void btnDeleteVersion_Click(object sender, EventArgs e)
        {
            if(lstVersions.SelectedItem != null)
            {
                var allversions = (from object v in lstVersions.Items select v as Version).ToList();
                allversions.Remove((lstVersions.SelectedItem as Version));

                lstVersions.DataSource = allversions.Distinct().ToList();
            }
        }
    }
}

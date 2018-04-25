using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Windows.Forms;
using LMan4.com.updatemanager;

namespace LMan4.Updates
{
    public partial class ManageUpdatesNew : Form
    {
        private readonly UpdateManager _updateService = new UpdateManager();

        public ManageUpdatesNew()
        {
            _updateService.Credentials = new NetworkCredential("LMAN", "530E9D3B-7ACC-4F9D-B16F-2FEBA545C8B1");
            InitializeComponent();
        }

        private void ManageUpdatesNew_Load(object sender, System.EventArgs e)
        {
            grdUpdateSeries.DataSourceChanged += grdUpdateSeries_DataSourceChanged;
            grdUpdateSeries.CellContentClick += grdUpdateSeries_CellContentClick;
            grdUpdateSeries.Width = grdUpdateSeries.Parent.Width;

            var allSeries = _updateService.GetAllUpdateSeries().Select(x => new UpdateSeriesUiModel { Id = x.Id, Name = x.Name, DateCreated = x.DateCreated });
            if(allSeries.Count() > 0)
                grdUpdateSeries.DataSource = new BindingSource { DataSource = allSeries };
        }

        void grdUpdateSeries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex.Equals(13))
            {
                //edit
                var frmEditUpdate = new EditUpdateSeries(_updateService.GetUpdateSeriesById(Guid.Parse(grdUpdateSeries.Rows[e.RowIndex].Cells[0].Value.ToString())));
                frmEditUpdate.ShowDialog();

                grdUpdateSeries.Rows.Clear();
                grdUpdateSeries.Columns.Clear();
                grdUpdateSeries.DataSource = new BindingSource { DataSource = _updateService.GetAllUpdateSeries().Select(x => new UpdateSeriesUiModel { Id = x.Id, Name = x.Name, DateCreated = x.DateCreated }) };
            }
            else if(e.ColumnIndex.Equals(3))
            {
                //delete
                if (MessageBox.Show("Are you sure you want to delete this series, and all associated updates?", "Delete series", 
                    MessageBoxButtons.OKCancel).Equals(DialogResult.OK))
                {
                    _updateService.DeleteUpdateSeriesById(Guid.Parse(grdUpdateSeries.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    grdUpdateSeries.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        void grdUpdateSeries_DataSourceChanged(object sender, System.EventArgs e)
        {
            try
            {
                //grdUpdateSeries.Columns.Add(new DataGridViewButtonColumn
                //                                {
                //                                    HeaderText = "",
                //                                    Text = "Edit",
                //                                    Name = "btnEdit",
                //                                    UseColumnTextForButtonValue = true,
                //                                });

                grdUpdateSeries.Columns.Add(new DataGridViewButtonColumn
                                                {
                                                    HeaderText = "",
                                                    Text = "Delete",
                                                    Name = "btnDelete",
                                                    UseColumnTextForButtonValue = true
                                                });

                grdUpdateSeries.Columns[0].Visible = false;
                grdUpdateSeries.Columns[1].Width = 310;
                grdUpdateSeries.Columns[2].Width = 300;
                grdUpdateSeries.Columns[3].Width = 150;
                //grdUpdateSeries.Columns[4].Width = 150;
            }
            catch(Exception) { }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new EditUpdateSeries();
            frm.ShowDialog();

            var allSeries = _updateService.GetAllUpdateSeries().Select(x => new UpdateSeriesUiModel { Id = x.Id, Name = x.Name, DateCreated = x.DateCreated });
            if (allSeries.Count() > 0)
                grdUpdateSeries.DataSource = new BindingSource { DataSource = allSeries };
        }
    }
}

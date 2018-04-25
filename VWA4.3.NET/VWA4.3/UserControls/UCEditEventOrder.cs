using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCEditEventOrder : UserControl
    {
        private string _ID = "";
        private string _CatID = "";
        private string _TypeCatalog = "";
        private bool _Changed = false;
        public UCEditEventOrder()
        {
            InitializeComponent();
            Init("0", "0");
            ucSiteChooser1.Init();
        }
        public void Init(string typeCatalog, string id)
        {
            ucTreeView1.InitTreeView(typeCatalog, "BEO", id);
            if (VWA4Common.VWACommon.IsAllowEditVersion())
            {
                btnNew.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        private void ucTreeView1_TreeViewIDChanged(object sender, UCTreeView.TreeViewEventArgs e)
        {
            DataTable dataTable = new DataTable();
            
            string sql;
            if(e.TypeCatalogID == "0" || e.TypeCatalogID == "")
                sql = @"SELECT * FROM BEOType WHERE TypeID = '" + e.ID + "'";
            else
                sql = @"SELECT TypeName, ReportTypeName, SpanishTypeName, Rank, BEOSubTypes.Enabled, Description, EventDate, BEONumber, GuestCount, " +
                        " MRatio, CatID, BEOSubTypes.TypeID " +
                        " FROM BEOSubTypes INNER JOIN BEOType ON BEOType.TypeID = BEOSubTypes.TypeID " +
                        " WHERE TypeCatalogID = " + e.TypeCatalogID + " AND BEOSubTypes.TypeID = '" + e.ID + "'";
            dataTable = VWA4Common.DB.Retrieve(sql);
            if( dataTable.Rows.Count > 0)
            {
                txtName.Text = dataTable.Rows[0]["TypeName"].ToString();
                txtReportName.Text = dataTable.Rows[0]["ReportTypeName"].ToString();
                txtSpanishName.Text = dataTable.Rows[0]["SpanishTypeName"].ToString();
                nRank.Value = int.Parse(dataTable.Rows[0]["Rank"].ToString() == "" ? "0" : dataTable.Rows[0]["Rank"].ToString());
                chkEnabled.Checked = bool.Parse(dataTable.Rows[0]["Enabled"].ToString());
                txtDescription.Text = dataTable.Rows[0]["Description"].ToString();
                dtEventDate.Value = DateTime.Parse(dataTable.Rows[0]["EventDate"].ToString() == "" ? DateTime.Now.ToString() : dataTable.Rows[0]["EventDate"].ToString());
                txtEventNumber.Text = dataTable.Rows[0]["BEONumber"].ToString();
                nGuestNumber.Value = int.Parse(dataTable.Rows[0]["GuestCount"].ToString() == "" ? "0" : dataTable.Rows[0]["GuestCount"].ToString());
                nRatio.Value = decimal.Parse(dataTable.Rows[0]["MRatio"].ToString() == "" ? "0" : dataTable.Rows[0]["MRatio"].ToString());
                _CatID = e.CatID;
                _ID = e.ID;
                _TypeCatalog = e.TypeCatalogID;
                _Changed = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string catID = ucTreeView1.SelectedCat();
            int typeCat = (_TypeCatalog == "" || _TypeCatalog == "0") ? 0 : int.Parse(_TypeCatalog);
            string id, sql, sError = "";
            sql = "";
            DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM BEOType WHERE BEONumber = '" + txtEventNumber.Text + "' AND Enabled = true");
            if (dt.Rows.Count > 0)
                MessageBox.Show(this, "Event Order with such Event Number already exists. Disable previouse Event Order or enter new Event Number",
                    "Input Error", MessageBoxButtons.OK);
            else
            { 
                id = VWA4Common.VWADBUtils.AutoCreateBEOID(txtEventNumber.Text, DateTime.Now, typeCat, ref sError);
                sql = EOUpdate(id);
                VWA4Common.DB.Update(sql);
                DataRow row = VWA4Common.DB.Retrieve("SELECT * FROM BEOType WHERE TypeID = '" + id + "'").Rows[0];
                ucTreeView1.InsertDrag(row);
            }
        }

        private void ucSiteChooser1_SiteChanged(object sender, UCSiteChooser.SiteEventArgs e)
        {
            ucTreeView1.TypeCatalogID = e.TypeCatalogID;
        }
        private string EOUpdate(string id)
        {
            return "UPDATE BEOType SET " +
                        " TypeName = '" + txtName.Text + "'" +
                        ", ReportTypeName = '" + txtReportName.Text.Replace("'", "''") + "'" +
                        ", SpanishTypeName = '" + txtSpanishName.Text.Replace("'", "''") + "'" +
                        ", Rank = " + nRank.Value +
                        ", Enabled = " + chkEnabled.Checked +
                        ", Description = '" + txtDescription.Text.Replace("'", "''") + "'" +
                        ", EventDate = #" + VWA4Common.VWACommon.DateToString(dtEventDate.Value) + "#" +
                        ", BEONumber = '" + txtEventNumber.Text + "'" +
                        ", GuestCount =" + nGuestNumber.Value +
                        ", MRatio =" + nRatio.Value +
                        ", ModifiedDate = #" + VWA4Common.VWACommon.DateToString(DateTime.Now) + "#" +
                        " WHERE TypeID = '" + id + "'";
        }

        public delegate void SavePressedEventHandler(object sender, EventArgs e);
        private SavePressedEventHandler savePressed;
        public event SavePressedEventHandler SavePressed
        {
            add { savePressed += value; }
            remove { savePressed -= value; }
        }
        public void SetSavePressed()
        {
            OnSavePressed(EventArgs.Empty);
        }
        protected virtual void OnSavePressed(EventArgs e)
        {
            ucTreeView1.SaveTree();
            if (_ID != "")
            {
                string sql;
                if (_Changed)
                {
                    sql = EOUpdate(_ID);
                    VWA4Common.DB.Update(sql);
                }
                if (_TypeCatalog != "" && _TypeCatalog != "0")
                {
                    sql = "UPDATE BEOSubTypes SET Enabled = " + chkEnabled.Checked.ToString() + " WHERE TypeID = '" + _ID + "'";
                    VWA4Common.DB.Update(sql);
                }
            }
            if (savePressed != null)
                savePressed(this, e);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // catch pressing enter key means user finished input
            if (sender != null)
                SetSavePressed();
        }

        public delegate void CancelPressedEventHandler(object sender, EventArgs e);
        private CancelPressedEventHandler cancelPressed;
        public event CancelPressedEventHandler CancelPressed
        {
            add { cancelPressed += value; }
            remove { cancelPressed -= value; }
        }
        public void SetCancelPressed()
        {
            OnCancelPressed(EventArgs.Empty);
        }
        protected virtual void OnCancelPressed(EventArgs e)
        {
            if (cancelPressed != null)
                cancelPressed(this, e);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // catch pressing enter key means user finished input
            if (sender != null)
                SetCancelPressed();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            _Changed = true;
        }
    }
}

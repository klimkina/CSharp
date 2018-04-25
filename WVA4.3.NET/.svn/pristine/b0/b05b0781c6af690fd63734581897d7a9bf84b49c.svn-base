using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCEditProduced : UserControl
    {
        public UCEditProduced()
        {
            InitializeComponent();
        }
        // private ImportWeight _produced;
        public void Init(ImportWeight produced)
        {
            //_produced = produced;
            //DataTable siteDataTable = new DataTable();
            //int i = 0;
            //string sql = @"SELECT Sites.ID, LicensedSite, TypeCatalogs.ID AS TypeCatalogID, TypeCatalogs.TypeCatalogName AS TypeCatalogName " +
            //            " FROM Sites LEFT  JOIN TypeCatalogs ON Sites.TypeCatalogID = TypeCatalogs.ID " +
            //            " WHERE Active = True";
            //siteDataTable = VWA4Common.DB.Retrieve(sql);
            //foreach (DataRow row in siteDataTable.Rows)
            //{
            //    i = cbSite.Items.Add(new VWA4Common.VWACommon.MyListBoxItem(row.ItemArray[1].ToString(),
            //        row.ItemArray[0].ToString() + "," + row.ItemArray[1].ToString() + "," + row.ItemArray[2].ToString() + "," + row.ItemArray[3].ToString()));
            //    if (row.ItemArray[0].ToString() == transfer.SiteID.ToString())
            //    {
            //        cbSite.SelectedIndex = i;
            //        lblTypeCatalog.Text = "TypeCatalog: " + (row.ItemArray[3].ToString() == "" ? "Master" : row.ItemArray[3].ToString());
            //    }
            //}

            //dtTimestamp.Value = transfer.Timestamp;

            //sql = @"SELECT TermID, TermName, Terminals.SiteID, Sites.TypeCatalogID " +
            //    " FROM Terminals LEFT JOIN Sites ON Terminals.SiteID = Sites.ID " +
            //    " WHERE Terminals.Active = true;";
            //siteDataTable = VWA4Common.DB.Retrieve(sql);
            //foreach (DataRow row in siteDataTable.Rows)
            //{
            //    i = cbTerminal.Items.Add(new VWA4Common.VWACommon.MyListBoxItem(row.ItemArray[1].ToString(),
            //        row.ItemArray[0].ToString() + "," + row.ItemArray[2].ToString() + "," + row.ItemArray[3].ToString()));
            //    if (row.ItemArray[0].ToString() == transfer.TermID)
            //        cbTerminal.SelectedIndex = i;
            //}

            //txtLotNumber.Value = transfer.Version;
            //cbRecordingMethod.SelectedIndex = transfer.IsPrior ? 1 : 0;
        }
        public class SaveEventArgs : EventArgs
        {
            private ImportTransfer _transfer;
            public ImportTransfer Transfer
            {
                get { return _transfer; }
                set { _transfer = value; }
            }
            public SaveEventArgs(ImportTransfer transfer)
            {
                _transfer = transfer;
            }
        }
        public delegate void SavePressedEventHandler(object sender, SaveEventArgs e);
        private SavePressedEventHandler savePressed;
        public event SavePressedEventHandler SavePressed
        {
            add { savePressed += value; }
            remove { savePressed -= value; }
        }
        public void SetSavePressed()
        {
            //string[] term = ((VWA4Common.VWACommon.MyListBoxItem)cbTerminal.SelectedItem).ItemData.Split(',');
            //string[] site = ((VWA4Common.VWACommon.MyListBoxItem)cbSite.SelectedItem).ItemData.Split(',');
            //ImportTransfer transfer = new ImportTransfer(dtTimestamp.Value,
            //    term[0], cbTerminal.SelectedItem.ToString(), txtLotNumber.Value.ToString(), int.Parse(term[1]), site[1],
            //    int.Parse(term[2]), site[3], cbRecordingMethod.SelectedIndex != 0);// todo: change zero to value
            //OnSavePressed(new SaveEventArgs(transfer));
        }
        protected virtual void OnSavePressed(SaveEventArgs e)
        {
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

        private void ultraTextEditor1_BeforeEditorButtonDropDown(object sender, Infragistics.Win.UltraWinEditors.BeforeEditorButtonDropDownEventArgs e)
        {
            //   Set the date picker's size and location equal to the active cell's size and location        
            this.ucTreeView1.SetBounds(e.Location.X, e.Location.Y, ucTreeView1.Width, ucTreeView1.Height);
            //   Set the value  
            //this.ucTreeView1.InitTreeView(VWA4Common.VWADBUtils.TypeCatalog(objCell.Row.Cells["TermID"].Value.ToString()).ToString(),
            //    Station,
            //    _produced.S);
            this.ucTreeView1.Visible = true;
            this.ucTreeView1.Focus();
            this.ucTreeView1.BringToFront();
        }
    }
}

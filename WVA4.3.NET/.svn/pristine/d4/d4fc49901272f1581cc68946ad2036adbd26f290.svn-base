using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UCEditTransfer : UserControl
    {
        public UCEditTransfer()
        {
            InitializeComponent();
        }
        // todo: init here
        public UCEditTransfer(ImportTransfer transfer)
        {
            InitializeComponent();
            dtTimestamp.MaxDate = DateTime.Now;
            Init(transfer);
        }
        public void Init(ImportTransfer transfer)
        {
            DataTable siteDataTable = new DataTable();
            int i = 0;
            string sql = @"SELECT Sites.ID, LicensedSite, TypeCatalogs.ID AS TypeCatalogID, TypeCatalogs.TypeCatalogName AS TypeCatalogName " +
                        " FROM Sites LEFT  JOIN TypeCatalogs ON Sites.TypeCatalogID = TypeCatalogs.ID " +
                        " WHERE Active = True";
            siteDataTable = VWA4Common.DB.Retrieve(sql);
            foreach (DataRow row in siteDataTable.Rows)
            {
                i = cbSite.Items.Add(new VWA4Common.VWACommon.MyListBoxItem(row.ItemArray[1].ToString(),
                    row.ItemArray[0].ToString() + "," + row.ItemArray[1].ToString() + "," + row.ItemArray[2].ToString() + "," + row.ItemArray[3].ToString()));
                if (row.ItemArray[0].ToString() == transfer.SiteID.ToString())
                {
                    cbSite.SelectedIndex = i;
                    lblTypeCatalog.Text = "TypeCatalog: " + (row.ItemArray[3].ToString() == "" ? "Master" : row.ItemArray[3].ToString());
                }
            }

            dtTimestamp.Value = transfer.Timestamp;

            sql = @"SELECT TermID, TermName, Terminals.SiteID, Sites.TypeCatalogID " +
                " FROM Terminals LEFT JOIN Sites ON Terminals.SiteID = Sites.ID " +
                " WHERE Terminals.Active = true;";
            siteDataTable = VWA4Common.DB.Retrieve(sql);
            foreach (DataRow row in siteDataTable.Rows)
            {
                i = cbTerminal.Items.Add(new VWA4Common.VWACommon.MyListBoxItem(row.ItemArray[1].ToString(), 
                    row.ItemArray[0].ToString() + "," + row.ItemArray[2].ToString() + "," + row.ItemArray[3].ToString()));
                if (row.ItemArray[0].ToString() == transfer.TermID)
                    cbTerminal.SelectedIndex = i;
            }
            
            txtVersion.Value = transfer.Version;
            cbPrior.SelectedIndex = transfer.IsPrior ? 1 : 0;
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
            string[] term = {"0", "0", "0"};
            if (cbTerminal.SelectedItem != null)
                term = ((VWA4Common.VWACommon.MyListBoxItem)cbTerminal.SelectedItem).ItemData.Split(',');
            
            string[] site;
            if (cbSite.SelectedItem != null)
                site = ((VWA4Common.VWACommon.MyListBoxItem)cbSite.SelectedItem).ItemData.Split(',');
            else
                site = new string[4];
            ImportTransfer transfer = new ImportTransfer(dtTimestamp.Value,
                term[0], (cbTerminal.SelectedItem != null ?cbTerminal.SelectedItem.ToString() : ""), txtVersion.Value.ToString(), int.Parse(term[1]), site[1], 
                int.Parse(term[2]), site[3], cbPrior.SelectedIndex != 0);// todo: change zero to value
            OnSavePressed(new SaveEventArgs(transfer));
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

        private void cbTerminal_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] termsite = ((VWA4Common.VWACommon.MyListBoxItem)cbTerminal.SelectedItem).ItemData.Split(',');
            int i = 0;
            if(termsite.Length > 1)
                foreach (VWA4Common.VWACommon.MyListBoxItem item in cbSite.Items)
                {
                    string[] temp = item.ItemData.Split(',');
                    if (temp.Length > 3 && temp[0] == termsite[1])
                    {
                        cbSite.SelectedIndex = i;
                        lblTypeCatalog.Text = "TypeCatalog: " + (temp[3] == "" ? "Master" : temp[3]);
                    }
                    i++;
                }
        }
    }
}

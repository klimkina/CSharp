using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using LMan4.com.licensemanager4web;
using Infragistics.Win.UltraWinListView;
using Infragistics.Win;

namespace LMan4
{
    public partial class LoadLicense : Form
    {
        public int LicenseId { get; set; }

        private LicenseManagerWebService licenseService = LicenseUtility.GetWebService();
        private UltraListView ulvLicenses = new UltraListView();
        
        public LoadLicense()
        {
            InitializeComponent();

            this.Text = string.Format("Load License - Using {0} Database", LicenseUtility.TestMode ? "Test" : "Production");

            ulvLicenses.Width = this.pnlLicenses.Width;
            ulvLicenses.Height = this.pnlLicenses.Height;
            this.pnlLicenses.Controls.Add(ulvLicenses);

            this.ulvLicenses.ItemSelectionChanged += new ItemSelectionChangedEventHandler(ulvLicenses_ItemSelectionChanged);
            this.ulvLicenses.ItemDoubleClick += new ItemDoubleClickEventHandler(ulvLicenses_ItemDoubleClick);

            //load clients into drop down
            this.populateClients();
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        void ulvLicenses_ItemDoubleClick(object sender, ItemDoubleClickEventArgs e)
        {
            btnLoad_Click(sender, e);
        }

        void ulvLicenses_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            this.btnLoad.Enabled = true;
        }

        private void populateClients()
        {
            this.ddlClients.DisplayMember = "ClientName";
            this.ddlClients.ValueMember = "ID";

            foreach (Client c in licenseService.GetAllClients())
            {
                this.ddlClients.Items.Add(c);
            }
            this.ddlClients.Items.Insert(0, new Client { ID = -1, ClientName = "All Clients" });

            this.ddlClients.SelectedIndex = 0;
            this.ddlClients.SelectedIndexChanged += new EventHandler(ddlClients_SelectedIndexChanged);

            this.populateLicensesList();
        }

        void ddlClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.ddlClients.SelectedItem as Client).ID == -1)
            {
                this.ddlSites.Visible = false;
                this.lblFilterBySite.Visible = false;
                this.ddlSites.SelectedIndex = 0;
                this.populateLicensesList();

                return;
            }

            this.ddlSites.Visible = true;
            this.lblFilterBySite.Visible = true;
            this.ddlSites.Items.Clear();
            this.ddlSites.DisplayMember = "SiteName";
            this.ddlSites.ValueMember = "ID";

            foreach (Site s in licenseService.GetAllSitesByClientId((this.ddlClients.SelectedItem as Client).ID))
            {
                this.ddlSites.Items.Add(s);
            }

            this.ddlSites.Items.Insert(0, new Site { ID = -1, SiteName = "All Sites" });

            this.ddlSites.SelectedIndex = 0;
            this.ddlSites.SelectedIndexChanged += new EventHandler(ddlSites_SelectedIndexChanged);

            this.populateLicensesList();
        }

        void ddlSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ulvLicenses.SelectedItems.Clear();
            this.btnLoad.Enabled = false;

            this.populateLicensesList();
        }

        private void populateLicensesList()
        {
            this.btnLoad.Enabled = false;

            LMan4.com.licensemanager4web.License[] licenses;

            ulvLicenses.Items.Clear();
            ulvLicenses.SubItemColumns.Clear();
            ulvLicenses.SelectedItems.Clear();

            ulvLicenses.ViewSettingsDetails.CheckBoxStyle = CheckBoxStyle.None;
            ulvLicenses.ViewSettingsDetails.ImageSize = Size.Empty;
            ulvLicenses.ViewSettingsDetails.FullRowSelect = true;
            ulvLicenses.View = UltraListViewStyle.Details;
            ulvLicenses.ViewSettingsList.MultiColumn = false;            
            ulvLicenses.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
            ulvLicenses.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
            ulvLicenses.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
            ulvLicenses.ItemSettings.SelectionType = SelectionType.Single;
            ulvLicenses.ItemSettings.AllowEdit = DefaultableBoolean.False;

            UltraListViewMainColumn mainColumn = ulvLicenses.MainColumn;
            mainColumn.Text = "ID";
            mainColumn.DataType = typeof(Int32);
            mainColumn.Width = 50;

            UltraListViewSubItemColumn cLicenseName = new UltraListViewSubItemColumn();
            cLicenseName.Text = "LicenseID";
            cLicenseName.Width = 50;
            cLicenseName.VisibleInDetailsView = DefaultableBoolean.True;
            cLicenseName.DataType = typeof(String);

            UltraListViewSubItemColumn cProduct = new UltraListViewSubItemColumn();
            cProduct.Text = "Product";
            cProduct.Width = 50;
            cProduct.VisibleInDetailsView = DefaultableBoolean.True;
            cProduct.DataType = typeof(String);

            UltraListViewSubItemColumn cLicenseType = new UltraListViewSubItemColumn();
            cLicenseType.Text = "License Type";
            cLicenseType.Width = 50;
            cLicenseType.VisibleInDetailsView = DefaultableBoolean.True;
            cLicenseType.DataType = typeof(String);

            UltraListViewSubItemColumn cGeneratedBy = new UltraListViewSubItemColumn();
            cGeneratedBy.Text = "Created By";
            cGeneratedBy.Width = 50;
            cGeneratedBy.VisibleInDetailsView = DefaultableBoolean.True;
            cGeneratedBy.DataType = typeof(String);

            UltraListViewSubItemColumn cGeneratedTime = new UltraListViewSubItemColumn();
            cGeneratedTime.Text = "Date Created";
            cGeneratedTime.Width = 100;
            cGeneratedTime.VisibleInDetailsView = DefaultableBoolean.True;
            cGeneratedTime.DataType = typeof(String);

            ulvLicenses.SubItemColumns.Add(cLicenseName);
            ulvLicenses.SubItemColumns.Add(cProduct);
            ulvLicenses.SubItemColumns.Add(cLicenseType);
            ulvLicenses.SubItemColumns.Add(cGeneratedBy);
            ulvLicenses.SubItemColumns.Add(cGeneratedTime);

            if ((this.ddlClients.SelectedItem as Client).ID != -1 && (this.ddlSites.SelectedItem as Site).ID != -1)
            {
                licenses = licenseService.GetLicensesByClientIdAndSiteId(Convert.ToInt32((this.ddlClients.SelectedItem as Client).ID),
                    Convert.ToInt32((this.ddlSites.SelectedItem as Site).ID));
            }
            else if ((this.ddlClients.SelectedItem as Client).ID != -1)
            {
                licenses = licenseService.GetLicensesByClientId(Convert.ToInt32((this.ddlClients.SelectedItem as Client).ID));
            }
            else
            {
                licenses = licenseService.GetAllLicenses();
            }

            for (int i = 0; i < licenses.Length; i++)
            {
                UltraListViewItem item = ulvLicenses.Items.Add(licenses[i].ID.ToString(), licenses[i].ID.ToString());
                item.SubItems[0].Value = licenses[i].LicenseID;
                item.SubItems[1].Value = licenses[i].Product;
                item.SubItems[2].Value = licenses[i].LicenseType;
                item.SubItems[3].Value = licenses[i].GeneratedBy;
                item.SubItems[4].Value = string.Format("{0} {1}", licenses[i].GeneratedTime.ToLongDateString(), licenses[i].GeneratedTime.ToShortTimeString());
            }
            
            this.ulvLicenses.Focus();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (this.ulvLicenses.SelectedItems.Count > 0)
            {
                this.LicenseId = Convert.ToInt32(ulvLicenses.SelectedItems[0].Key);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.LicenseId = -1;
            this.Close();
        }

		private void LoadLicense_FormClosing(object sender, FormClosingEventArgs e)
		{

		}
    }
}

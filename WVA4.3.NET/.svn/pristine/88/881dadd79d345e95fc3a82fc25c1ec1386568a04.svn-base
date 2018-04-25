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
	public partial class ManageClientsSites : Form
	{
	    private LicenseManagerWebService licenseService = LicenseUtility.GetWebService();

        private UltraListView ulvClients = new UltraListView();
        private UltraListView ulvSites = new UltraListView();

		public ManageClientsSites()
		{
			InitializeComponent();

            this.ulvClients.Click += new EventHandler(ulvClients_Click);
            this.ulvSites.Click += new EventHandler(ulvSites_Click);

            this.pnlClients.Controls.Add(this.ulvClients);
            this.pnlSites.Controls.Add(this.ulvSites);

            this.ulvClients.Width = this.pnlClients.Width;
            this.ulvClients.Height = this.pnlClients.Height;

            this.ulvSites.Width = this.pnlSites.Width;
            this.ulvSites.Height = this.pnlSites.Height;

            this.populateClients();

            this.Text = string.Format("Manage Clients & Sites - Using {0} Database", LicenseUtility.TestMode ? "Test" : "Production");
		}

	    public override sealed string Text
	    {
	        get { return base.Text; }
	        set { base.Text = value; }
	    }

	    void ulvSites_Click(object sender, EventArgs e)
        {
            if (this.ulvSites.SelectedItems.Count > 0)
            {
                this.btnSaveSite.Enabled = true;
                this.btnDeleteSite.Enabled = true;

                Site s = licenseService.GetSiteById(Convert.ToInt32(this.ulvSites.SelectedItems[0].Key));
                this.lblSiteRecordId.Text = s.ID.ToString();
                this.txtSiteName.Text = s.SiteName;
                this.txtSiteSalesForceId.Text = s.SalesForceId;
            }            
        }

        void ulvClients_Click(object sender, EventArgs e)
        {
            if (this.ulvClients.SelectedItems.Count > 0)
            {
                this.grpSites.Visible = true;
                this.btnSaveClient.Enabled = true;
                this.btnDeleteClient.Enabled = true;

                this.btnSaveSite.Enabled = false;
                this.btnDeleteSite.Enabled = false;

                this.populateSites();

                Client c = licenseService.GetClientById(Convert.ToInt32(this.ulvClients.SelectedItems[0].Key));
                this.lblClientRecordId.Text = c.ID.ToString();
                this.txtClientName.Text = c.ClientName;
                this.txtClientSalesForceId.Text = c.SalesForceId;
            }            
        }

        private void populateSites()
        {
			LMan4.com.licensemanager4web.Site[] sites;

            ulvSites.Items.Clear();
            ulvSites.SubItemColumns.Clear();
            ulvSites.SelectedItems.Clear();

            ulvSites.ViewSettingsDetails.CheckBoxStyle = CheckBoxStyle.None;
            ulvSites.ViewSettingsDetails.ImageSize = Size.Empty;
            ulvSites.ViewSettingsDetails.FullRowSelect = true;
            ulvSites.View = UltraListViewStyle.Details;
            ulvSites.ViewSettingsList.MultiColumn = false;
            ulvSites.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
            ulvSites.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
            ulvSites.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
            ulvSites.ItemSettings.SelectionType = SelectionType.Single;
            ulvSites.ItemSettings.AllowEdit = DefaultableBoolean.False;

            UltraListViewMainColumn mainColumn = ulvSites.MainColumn;
            mainColumn.Text = "Sales Force ID";
            mainColumn.DataType = typeof(Int32);
            mainColumn.Width = 50;

            UltraListViewSubItemColumn cSiteName = new UltraListViewSubItemColumn();
            cSiteName.Text = "Site Name";
            cSiteName.Width = 50;
            cSiteName.VisibleInDetailsView = DefaultableBoolean.True;
            cSiteName.DataType = typeof(String);

            ulvSites.SubItemColumns.Add(cSiteName);

            //get all sites by selected client
            sites = licenseService.GetAllSitesByClientId(Convert.ToInt32(this.ulvClients.SelectedItems[0].Key));

            for (int i = 0; i < sites.Length; i++)
            {
                UltraListViewItem item = ulvSites.Items.Add(sites[i].ID.ToString(), sites[i].SalesForceId.ToString());
                item.SubItems[0].Value = sites[i].SiteName;
            }

            this.ulvSites.Focus();
        }

        private void populateClients()
        {
            this.grpSites.Visible = false;

            LMan4.com.licensemanager4web.Client[] clients;

            ulvClients.Items.Clear();
            ulvClients.SubItemColumns.Clear();
            ulvClients.SelectedItems.Clear();

            ulvClients.ViewSettingsDetails.CheckBoxStyle = CheckBoxStyle.None;
            ulvClients.ViewSettingsDetails.ImageSize = Size.Empty;
            ulvClients.ViewSettingsDetails.FullRowSelect = true;
            ulvClients.View = UltraListViewStyle.Details;
            ulvClients.ViewSettingsList.MultiColumn = false;
            ulvClients.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
            ulvClients.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
            ulvClients.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
            ulvClients.ItemSettings.SelectionType = SelectionType.Single;
            ulvClients.ItemSettings.AllowEdit = DefaultableBoolean.False;

            UltraListViewMainColumn mainColumn = ulvClients.MainColumn;
            mainColumn.Text = "Sales Force Id";
            mainColumn.DataType = typeof(Int32);
            mainColumn.Width = 50;

            UltraListViewSubItemColumn cClientName = new UltraListViewSubItemColumn();
            cClientName.Text = "Client Name";
            cClientName.Width = 50;
            cClientName.VisibleInDetailsView = DefaultableBoolean.True;
            cClientName.DataType = typeof(String);

            UltraListViewSubItemColumn cNumSites = new UltraListViewSubItemColumn();
            cNumSites.Text = "# Sites";
            cNumSites.Width = 50;
            cNumSites.VisibleInDetailsView = DefaultableBoolean.True;
            cNumSites.DataType = typeof(String);

            ulvClients.SubItemColumns.Add(cClientName);
            ulvClients.SubItemColumns.Add(cNumSites);

            //get all clients
            clients = licenseService.GetAllClients();

            for (int i = 0; i < clients.Length; i++)
            {
                UltraListViewItem item = ulvClients.Items.Add(clients[i].ID.ToString(), clients[i].SalesForceId.ToString());
                item.SubItems[0].Value = clients[i].ClientName;
                item.SubItems[1].Value = clients[i].NumberOfSites;
            }

            this.ulvClients.Focus();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            string clientName = this.txtClientName.Text;
            string clientSalesForceId = this.txtClientSalesForceId.Text;

            if (MessageBox.Show(string.Format("Are you sure you want to add client {0} with sales force id '{1}'?", clientName, clientSalesForceId), "Add Client", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                if (licenseService.CreateClient(clientName, clientSalesForceId) > 0)
                {
                    MessageBox.Show("Success", "Create Client");
                    this.populateClients();
                }
            }
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            if (this.ulvClients.SelectedItems.Count > 0)
            {
                MessageBox.Show(licenseService.SaveClient(Convert.ToInt32(this.ulvClients.SelectedItems[0].Key), this.txtClientName.Text, this.txtClientSalesForceId.Text), "Save Client");
                this.populateClients();
            }
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (this.ulvClients.SelectedItems.Count > 0)
            {
                if (!licenseService.ClientHasActiveLicenses(Convert.ToInt32(this.ulvClients.SelectedItems[0].Key)))
                {
                    //delete
                }
                else
                {
                    MessageBox.Show("Cannot delete client with active licenses.", "Error");
                }
            }
        }

        private void btnAddSite_Click(object sender, EventArgs e)
        {
            string siteName = this.txtSiteName.Text;
            string siteSalesForceId = this.txtSiteSalesForceId.Text;

            if (MessageBox.Show(string.Format("Are you sure you want to add site {0} with sales force id '{1}'?", siteName, siteSalesForceId), "Add Site", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                if (licenseService.CreateSite(Convert.ToInt32(this.ulvClients.SelectedItems[0].Key), siteName, siteSalesForceId) > 0)
                {
                    MessageBox.Show("Success", "Create Site");
                    this.populateSites();
                }
            }
        }

        private void btnSaveSite_Click(object sender, EventArgs e)
        {
            if (this.ulvSites.SelectedItems.Count > 0)
            {
                MessageBox.Show(licenseService.SaveSite(Convert.ToInt32(this.ulvSites.SelectedItems[0].Key), Convert.ToInt32(this.ulvClients.SelectedItems[0].Key), this.txtSiteName.Text, this.txtSiteSalesForceId.Text), "Save Site");
                this.populateSites();
            }
        }

        private void btnDeleteSite_Click(object sender, EventArgs e)
        {
            if (this.ulvSites.SelectedItems.Count > 0)
            {
                if (!licenseService.SiteHasActiveLicenses(Convert.ToInt32(this.ulvSites.SelectedItems[0].Key)))
                {
                    //delete
                }
                else
                {
                    MessageBox.Show("Cannot delete site with active licenses.", "Error");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}

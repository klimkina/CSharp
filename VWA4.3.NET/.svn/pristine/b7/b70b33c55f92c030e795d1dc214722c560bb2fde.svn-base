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
    public partial class ManageVersions : Form
    {
        private readonly UpdateManager _updateService = new UpdateManager();

        public ManageVersions()
        {
            _updateService.Credentials = new NetworkCredential("LMAN", "530E9D3B-7ACC-4F9D-B16F-2FEBA545C8B1");

            InitializeComponent();
        }

        private void EditVersions_Load(object sender, EventArgs e)
        {
            populateVersions();

            btnDelete.Enabled = false;
        }

        private void populateVersions()
        {
            lstVersions.DataSource = _updateService.GetAllVersions();
            lstVersions.DisplayMember = "VersionName";
            lstVersions.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtVersion.Text))
            {
                MessageBox.Show("Enter a value for the Version.", "Error", MessageBoxButtons.OK);
                return;
            }

            _updateService.SaveVersion(new Version {VersionName = txtVersion.Text});

            populateVersions();
            txtVersion.Text = string.Empty;
        }

        private void lstVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lstVersions.SelectedItem != null)
            {
                _updateService.DeleteVersionById((lstVersions.SelectedItem as Version).Id);
                btnDelete.Enabled = false;
                populateVersions();
            }
        }
    }
}

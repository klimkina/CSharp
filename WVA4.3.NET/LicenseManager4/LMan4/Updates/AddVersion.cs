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
    public partial class AddVersion : Form
    {
        private readonly UpdateManager _updateService = new UpdateManager();
        public List<Version> Versions = new List<Version>();

        public AddVersion()
        {
            _updateService.Credentials = new NetworkCredential("LMAN", "530E9D3B-7ACC-4F9D-B16F-2FEBA545C8B1");

            InitializeComponent();
        }

        private void AddVersion_Load(object sender, EventArgs e)
        {
            lstVersions.DataSource = _updateService.GetAllVersions();
            lstVersions.DisplayMember = "VersionName";
            lstVersions.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach(var i in lstVersions.SelectedItems)
            {
                Versions.Add(i as Version);
            }
            Close();
        }
    }
}

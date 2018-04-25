namespace LMan4
{
	partial class ManageClientsSites
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.grpClients = new System.Windows.Forms.GroupBox();
            this.lblClientRecordId = new System.Windows.Forms.Label();
            this.pnlClients = new System.Windows.Forms.Panel();
            this.btnSaveClient = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientSalesForceId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.grpSites = new System.Windows.Forms.GroupBox();
            this.lblSiteRecordId = new System.Windows.Forms.Label();
            this.pnlSites = new System.Windows.Forms.Panel();
            this.btnSaveSite = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSiteSalesForceId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteSite = new System.Windows.Forms.Button();
            this.btnAddSite = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.grpClients.SuspendLayout();
            this.grpSites.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpClients
            // 
            this.grpClients.Controls.Add(this.lblClientRecordId);
            this.grpClients.Controls.Add(this.pnlClients);
            this.grpClients.Controls.Add(this.btnSaveClient);
            this.grpClients.Controls.Add(this.label2);
            this.grpClients.Controls.Add(this.txtClientSalesForceId);
            this.grpClients.Controls.Add(this.label6);
            this.grpClients.Controls.Add(this.txtClientName);
            this.grpClients.Controls.Add(this.label31);
            this.grpClients.Controls.Add(this.btnDeleteClient);
            this.grpClients.Controls.Add(this.btnAddClient);
            this.grpClients.Location = new System.Drawing.Point(17, 24);
            this.grpClients.Name = "grpClients";
            this.grpClients.Size = new System.Drawing.Size(282, 311);
            this.grpClients.TabIndex = 22;
            this.grpClients.TabStop = false;
            this.grpClients.Text = "Clients";
            // 
            // lblClientRecordId
            // 
            this.lblClientRecordId.AutoSize = true;
            this.lblClientRecordId.Location = new System.Drawing.Point(101, 211);
            this.lblClientRecordId.Name = "lblClientRecordId";
            this.lblClientRecordId.Size = new System.Drawing.Size(0, 13);
            this.lblClientRecordId.TabIndex = 31;
            // 
            // pnlClients
            // 
            this.pnlClients.Location = new System.Drawing.Point(6, 20);
            this.pnlClients.Name = "pnlClients";
            this.pnlClients.Size = new System.Drawing.Size(270, 188);
            this.pnlClients.TabIndex = 30;
            // 
            // btnSaveClient
            // 
            this.btnSaveClient.Enabled = false;
            this.btnSaveClient.Location = new System.Drawing.Point(104, 272);
            this.btnSaveClient.Name = "btnSaveClient";
            this.btnSaveClient.Size = new System.Drawing.Size(75, 23);
            this.btnSaveClient.TabIndex = 29;
            this.btnSaveClient.Text = "Save Client";
            this.btnSaveClient.UseVisualStyleBackColor = true;
            this.btnSaveClient.Click += new System.EventHandler(this.btnSaveClient_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Client ID:";
            // 
            // txtClientSalesForceId
            // 
            this.txtClientSalesForceId.Location = new System.Drawing.Point(86, 248);
            this.txtClientSalesForceId.MaxLength = 64;
            this.txtClientSalesForceId.Name = "txtClientSalesForceId";
            this.txtClientSalesForceId.Size = new System.Drawing.Size(182, 20);
            this.txtClientSalesForceId.TabIndex = 27;
            this.txtClientSalesForceId.Text = "(enter ID from Salesforce.com)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Client Name:";
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(86, 227);
            this.txtClientName.MaxLength = 64;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(182, 20);
            this.txtClientName.TabIndex = 25;
            this.txtClientName.Text = "(enter client name)";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(12, 211);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(91, 13);
            this.label31.TabIndex = 24;
            this.label31.Text = "Client Record ID: ";
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.Enabled = false;
            this.btnDeleteClient.Location = new System.Drawing.Point(193, 272);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteClient.TabIndex = 23;
            this.btnDeleteClient.Text = "Delete Client";
            this.btnDeleteClient.UseVisualStyleBackColor = true;
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDeleteClient_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(15, 272);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(75, 23);
            this.btnAddClient.TabIndex = 22;
            this.btnAddClient.Text = "Add Client";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // grpSites
            // 
            this.grpSites.Controls.Add(this.lblSiteRecordId);
            this.grpSites.Controls.Add(this.pnlSites);
            this.grpSites.Controls.Add(this.btnSaveSite);
            this.grpSites.Controls.Add(this.label3);
            this.grpSites.Controls.Add(this.txtSiteSalesForceId);
            this.grpSites.Controls.Add(this.label4);
            this.grpSites.Controls.Add(this.txtSiteName);
            this.grpSites.Controls.Add(this.label5);
            this.grpSites.Controls.Add(this.btnDeleteSite);
            this.grpSites.Controls.Add(this.btnAddSite);
            this.grpSites.Location = new System.Drawing.Point(318, 24);
            this.grpSites.Name = "grpSites";
            this.grpSites.Size = new System.Drawing.Size(285, 311);
            this.grpSites.TabIndex = 23;
            this.grpSites.TabStop = false;
            this.grpSites.Text = "Sites";
            this.grpSites.Visible = false;
            // 
            // lblSiteRecordId
            // 
            this.lblSiteRecordId.AutoSize = true;
            this.lblSiteRecordId.Location = new System.Drawing.Point(95, 211);
            this.lblSiteRecordId.Name = "lblSiteRecordId";
            this.lblSiteRecordId.Size = new System.Drawing.Size(0, 13);
            this.lblSiteRecordId.TabIndex = 35;
            // 
            // pnlSites
            // 
            this.pnlSites.Location = new System.Drawing.Point(6, 19);
            this.pnlSites.Name = "pnlSites";
            this.pnlSites.Size = new System.Drawing.Size(273, 188);
            this.pnlSites.TabIndex = 31;
            // 
            // btnSaveSite
            // 
            this.btnSaveSite.Enabled = false;
            this.btnSaveSite.Location = new System.Drawing.Point(107, 272);
            this.btnSaveSite.Name = "btnSaveSite";
            this.btnSaveSite.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSite.TabIndex = 34;
            this.btnSaveSite.Text = "Save Site";
            this.btnSaveSite.UseVisualStyleBackColor = true;
            this.btnSaveSite.Click += new System.EventHandler(this.btnSaveSite_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Site ID:";
            // 
            // txtSiteSalesForceId
            // 
            this.txtSiteSalesForceId.Location = new System.Drawing.Point(89, 248);
            this.txtSiteSalesForceId.MaxLength = 64;
            this.txtSiteSalesForceId.Name = "txtSiteSalesForceId";
            this.txtSiteSalesForceId.Size = new System.Drawing.Size(182, 20);
            this.txtSiteSalesForceId.TabIndex = 32;
            this.txtSiteSalesForceId.Text = "(enter ID from Salesforce.com)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Site Name:";
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(89, 227);
            this.txtSiteName.MaxLength = 64;
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(182, 20);
            this.txtSiteName.TabIndex = 30;
            this.txtSiteName.Text = "(enter site name)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Site Record ID: ";
            // 
            // btnDeleteSite
            // 
            this.btnDeleteSite.Enabled = false;
            this.btnDeleteSite.Location = new System.Drawing.Point(196, 272);
            this.btnDeleteSite.Name = "btnDeleteSite";
            this.btnDeleteSite.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSite.TabIndex = 25;
            this.btnDeleteSite.Text = "Delete Site";
            this.btnDeleteSite.UseVisualStyleBackColor = true;
            this.btnDeleteSite.Click += new System.EventHandler(this.btnDeleteSite_Click);
            // 
            // btnAddSite
            // 
            this.btnAddSite.Location = new System.Drawing.Point(18, 272);
            this.btnAddSite.Name = "btnAddSite";
            this.btnAddSite.Size = new System.Drawing.Size(75, 23);
            this.btnAddSite.TabIndex = 24;
            this.btnAddSite.Text = "Add Site";
            this.btnAddSite.UseVisualStyleBackColor = true;
            this.btnAddSite.Click += new System.EventHandler(this.btnAddSite_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(502, 341);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 33);
            this.button5.TabIndex = 25;
            this.button5.Text = "Done";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ManageClientsSites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 383);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.grpSites);
            this.Controls.Add(this.grpClients);
            this.Name = "ManageClientsSites";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Clients & Sites";
            this.grpClients.ResumeLayout(false);
            this.grpClients.PerformLayout();
            this.grpSites.ResumeLayout(false);
            this.grpSites.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private Infragistics.Win.UltraWinListView.UltraListView ultraListView1;
		private System.Windows.Forms.GroupBox grpClients;
		private System.Windows.Forms.Button btnDeleteClient;
		private System.Windows.Forms.Button btnAddClient;
		private System.Windows.Forms.GroupBox grpSites;
		private System.Windows.Forms.Button btnDeleteSite;
		private System.Windows.Forms.Button btnAddSite;
        private Infragistics.Win.UltraWinListView.UltraListView ultraListView2;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtClientSalesForceId;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtClientName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSiteSalesForceId;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtSiteName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnSaveClient;
		private System.Windows.Forms.Button btnSaveSite;
		private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel pnlClients;
        private System.Windows.Forms.Panel pnlSites;
        private System.Windows.Forms.Label lblClientRecordId;
        private System.Windows.Forms.Label lblSiteRecordId;
	}
}
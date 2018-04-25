namespace UserControls
{
    partial class UCImportTransactions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lTaskName = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.btnDone = new Infragistics.Win.Misc.UltraButton();
			this.btnCancel = new Infragistics.Win.Misc.UltraButton();
			this.lblReady = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.utFileBrowser = new Infragistics.Win.UltraWinTree.UltraTree();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnOpenFile = new System.Windows.Forms.Button();
			this.panelFilters = new System.Windows.Forms.Panel();
			this.cbFilters = new System.Windows.Forms.ComboBox();
			this.lblSummary = new Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel();
			this.ucViewWeights1 = new UserControls.UCViewWeights();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.utFileBrowser)).BeginInit();
			this.panel4.SuspendLayout();
			this.panelFilters.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(630, 54);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(0, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(223, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Plug your device into USB drive to start import";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.lTaskName);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(630, 35);
			this.panel5.TabIndex = 3;
			// 
			// lTaskName
			// 
			this.lTaskName.AutoSize = true;
			this.lTaskName.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lTaskName.ForeColor = System.Drawing.Color.Sienna;
			this.lTaskName.Location = new System.Drawing.Point(3, 1);
			this.lTaskName.Name = "lTaskName";
			this.lTaskName.Size = new System.Drawing.Size(391, 35);
			this.lTaskName.TabIndex = 0;
			this.lTaskName.Text = "Import Transactions Data";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnOk);
			this.panel3.Controls.Add(this.btnDone);
			this.panel3.Controls.Add(this.btnCancel);
			this.panel3.Controls.Add(this.lblReady);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 272);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(630, 76);
			this.panel3.TabIndex = 2;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOk.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(163)))), ((int)(((byte)(27)))));
			this.btnOk.Appearance.BorderColor = System.Drawing.Color.Black;
			this.btnOk.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
			this.btnOk.Appearance.ForeColor = System.Drawing.Color.White;
			this.btnOk.Appearance.Options.UseBackColor = true;
			this.btnOk.Appearance.Options.UseBorderColor = true;
			this.btnOk.Appearance.Options.UseFont = true;
			this.btnOk.Appearance.Options.UseForeColor = true;
			this.btnOk.Location = new System.Drawing.Point(10, 6);
			this.btnOk.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
			this.btnOk.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(171, 62);
			this.btnOk.TabIndex = 202;
			this.btnOk.Text = "Import";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnDone
			// 
			this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDone.Location = new System.Drawing.Point(513, 37);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(105, 29);
			this.btnDone.TabIndex = 201;
			this.btnDone.Text = "Done";
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(198, 37);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(113, 29);
			this.btnCancel.TabIndex = 199;
			this.btnCancel.Text = "Cancel";
			// 
			// lblReady
			// 
			this.lblReady.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblReady.AutoSize = true;
			this.lblReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblReady.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblReady.Location = new System.Drawing.Point(206, 12);
			this.lblReady.Name = "lblReady";
			this.lblReady.Size = new System.Drawing.Size(97, 13);
			this.lblReady.TabIndex = 2;
			this.lblReady.Text = "Ready to Import";
			this.lblReady.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblReady.Visible = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.splitContainer1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 54);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(630, 218);
			this.panel2.TabIndex = 3;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.utFileBrowser);
			this.splitContainer1.Panel1.Controls.Add(this.panel4);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.ucViewWeights1);
			this.splitContainer1.Panel2.Controls.Add(this.panelFilters);
			this.splitContainer1.Panel2.Controls.Add(this.lblSummary);
			this.splitContainer1.Size = new System.Drawing.Size(630, 218);
			this.splitContainer1.SplitterDistance = 287;
			this.splitContainer1.TabIndex = 0;
			// 
			// utFileBrowser
			// 
			this.utFileBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.utFileBrowser.Location = new System.Drawing.Point(0, 0);
			this.utFileBrowser.Name = "utFileBrowser";
			this.utFileBrowser.Size = new System.Drawing.Size(287, 194);
			this.utFileBrowser.TabIndex = 2;
			this.utFileBrowser.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.utFileBrowser_AfterSelect);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnOpenFile);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(0, 194);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(287, 24);
			this.panel4.TabIndex = 1;
			this.panel4.Text = "panel4";
			// 
			// btnOpenFile
			// 
			this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenFile.Location = new System.Drawing.Point(210, 1);
			this.btnOpenFile.Name = "btnOpenFile";
			this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
			this.btnOpenFile.TabIndex = 0;
			this.btnOpenFile.Text = "Open File";
			this.btnOpenFile.UseVisualStyleBackColor = true;
			this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
			// 
			// panelFilters
			// 
			this.panelFilters.Controls.Add(this.cbFilters);
			this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelFilters.Location = new System.Drawing.Point(0, 0);
			this.panelFilters.Name = "panelFilters";
			this.panelFilters.Size = new System.Drawing.Size(339, 29);
			this.panelFilters.TabIndex = 1;
			this.panelFilters.Visible = false;
			// 
			// cbFilters
			// 
			this.cbFilters.FormattingEnabled = true;
			this.cbFilters.Items.AddRange(new object[] {
            "Set Weights Filter",
            "Set Error Weights Filter",
            "Set Produced Filter",
            "Set Error Produced Filter"});
			this.cbFilters.Location = new System.Drawing.Point(4, 4);
			this.cbFilters.Name = "cbFilters";
			this.cbFilters.Size = new System.Drawing.Size(121, 21);
			this.cbFilters.TabIndex = 0;
			this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// lblSummary
			// 
			this.lblSummary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblSummary.Location = new System.Drawing.Point(0, 0);
			this.lblSummary.Name = "lblSummary";
			this.lblSummary.Size = new System.Drawing.Size(339, 218);
			this.lblSummary.TabIndex = 0;
			this.lblSummary.TabStop = true;
			this.lblSummary.Value = "";
			// 
			// ucViewWeights1
			// 
			this.ucViewWeights1.DBPath = "";
			this.ucViewWeights1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucViewWeights1.IsActive = false;
			this.ucViewWeights1.Location = new System.Drawing.Point(0, 29);
			this.ucViewWeights1.Mode = UserControls.UCViewWeights.DisplayMode.Weights;
			this.ucViewWeights1.Name = "ucViewWeights1";
			this.ucViewWeights1.Size = new System.Drawing.Size(339, 189);
			this.ucViewWeights1.TabIndex = 2;
			this.ucViewWeights1.Visible = false;
			// 
			// UCImportTransactions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Name = "UCImportTransactions";
			this.Size = new System.Drawing.Size(630, 348);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.utFileBrowser)).EndInit();
			this.panel4.ResumeLayout(false);
			this.panelFilters.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTaskName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblReady;
        private Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel lblSummary;
        private Infragistics.Win.UltraWinTree.UltraTree utFileBrowser;
        private UCViewWeights ucViewWeights1;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.ComboBox cbFilters;
        private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.Misc.UltraButton btnDone;
		private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}

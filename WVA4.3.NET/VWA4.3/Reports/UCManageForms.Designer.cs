namespace Reports
{
    partial class UCManageForms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCManageForms));
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCreateForm = new DevExpress.XtraEditors.SimpleButton();
            this.pnlForms = new System.Windows.Forms.Panel();
            this.pnlFormSeries = new System.Windows.Forms.Panel();
            this.btnCreateSeries = new DevExpress.XtraEditors.SimpleButton();
            this.pnlPrintSeries = new System.Windows.Forms.Panel();
            this.lblPrintSeriesName = new DevExpress.XtraEditors.LabelControl();
            this.btnSavePrintSeries = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.PrintThisSeries = new DevExpress.XtraEditors.SimpleButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editSeriesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSeriesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesSeriesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSeriesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlPrintSeriesPanel = new System.Windows.Forms.Panel();
            this.btnEditFormProperties = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeriesProperties = new DevExpress.XtraEditors.SimpleButton();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editFormFormSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFormFormSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesFormFormSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.printFormFormSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.pnlPrintSeriesPanel.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(440, 64);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(82, 19);
            this.labelControl5.TabIndex = 213;
            this.labelControl5.Text = "Print Series:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(174)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.labelControl6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 45);
            this.panel1.TabIndex = 253;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(16, 1);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(373, 35);
            this.labelControl6.TabIndex = 198;
            this.labelControl6.Text = "Manage Form Documents";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "row_add.png");
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(16, 61);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(120, 19);
            this.labelControl1.TabIndex = 255;
            this.labelControl1.Text = "Form Documents:";
            // 
            // btnCreateForm
            // 
            this.btnCreateForm.Appearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateForm.Appearance.Options.UseFont = true;
            this.btnCreateForm.Location = new System.Drawing.Point(16, 474);
            this.btnCreateForm.Name = "btnCreateForm";
            this.btnCreateForm.Size = new System.Drawing.Size(123, 23);
            this.btnCreateForm.TabIndex = 257;
            this.btnCreateForm.Text = "Add New Form";
            this.btnCreateForm.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // pnlForms
            // 
            this.pnlForms.Location = new System.Drawing.Point(16, 87);
            this.pnlForms.Name = "pnlForms";
            this.pnlForms.Size = new System.Drawing.Size(410, 381);
            this.pnlForms.TabIndex = 258;
            // 
            // pnlFormSeries
            // 
            this.pnlFormSeries.Location = new System.Drawing.Point(438, 87);
            this.pnlFormSeries.Name = "pnlFormSeries";
            this.pnlFormSeries.Size = new System.Drawing.Size(295, 130);
            this.pnlFormSeries.TabIndex = 259;
            // 
            // btnCreateSeries
            // 
            this.btnCreateSeries.Appearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateSeries.Appearance.Options.UseFont = true;
            this.btnCreateSeries.Location = new System.Drawing.Point(438, 223);
            this.btnCreateSeries.Name = "btnCreateSeries";
            this.btnCreateSeries.Size = new System.Drawing.Size(139, 23);
            this.btnCreateSeries.TabIndex = 262;
            this.btnCreateSeries.Text = "Add New Print Series";
            this.btnCreateSeries.Click += new System.EventHandler(this.btnCreateSeries_Click);
            // 
            // pnlPrintSeries
            // 
            this.pnlPrintSeries.Location = new System.Drawing.Point(1, 25);
            this.pnlPrintSeries.Name = "pnlPrintSeries";
            this.pnlPrintSeries.Size = new System.Drawing.Size(294, 185);
            this.pnlPrintSeries.TabIndex = 260;
            // 
            // lblPrintSeriesName
            // 
            this.lblPrintSeriesName.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrintSeriesName.Appearance.Options.UseFont = true;
            this.lblPrintSeriesName.Location = new System.Drawing.Point(3, 3);
            this.lblPrintSeriesName.Name = "lblPrintSeriesName";
            this.lblPrintSeriesName.Size = new System.Drawing.Size(96, 19);
            this.lblPrintSeriesName.TabIndex = 263;
            this.lblPrintSeriesName.Text = "[name] Series:";
            // 
            // btnSavePrintSeries
            // 
            this.btnSavePrintSeries.Appearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePrintSeries.Appearance.Options.UseFont = true;
            this.btnSavePrintSeries.Location = new System.Drawing.Point(2, 217);
            this.btnSavePrintSeries.Name = "btnSavePrintSeries";
            this.btnSavePrintSeries.Size = new System.Drawing.Size(149, 23);
            this.btnSavePrintSeries.TabIndex = 264;
            this.btnSavePrintSeries.Text = "Save Print Series";
            this.btnSavePrintSeries.Click += new System.EventHandler(this.btnSavePrintSeries_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 548);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(745, 52);
            this.panel2.TabIndex = 265;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(630, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PrintThisSeries
            // 
            this.PrintThisSeries.Appearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintThisSeries.Appearance.Options.UseFont = true;
            this.PrintThisSeries.Location = new System.Drawing.Point(155, 217);
            this.PrintThisSeries.Name = "PrintThisSeries";
            this.PrintThisSeries.Size = new System.Drawing.Size(135, 23);
            this.PrintThisSeries.TabIndex = 266;
            this.PrintThisSeries.Text = "Print This Series";
            this.PrintThisSeries.Click += new System.EventHandler(this.PrintThisSeries_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.printToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 92);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSeriesMenuItem,
            this.deleteSeriesMenuItem,
            this.propertiesSeriesMenuItem,
            this.printSeriesMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(128, 92);
            // 
            // editSeriesMenuItem
            // 
            this.editSeriesMenuItem.Name = "editSeriesMenuItem";
            this.editSeriesMenuItem.Size = new System.Drawing.Size(127, 22);
            this.editSeriesMenuItem.Text = "Edit";
            this.editSeriesMenuItem.Click += new System.EventHandler(this.editSeriesMenuItem_Click);
            // 
            // deleteSeriesMenuItem
            // 
            this.deleteSeriesMenuItem.Name = "deleteSeriesMenuItem";
            this.deleteSeriesMenuItem.Size = new System.Drawing.Size(127, 22);
            this.deleteSeriesMenuItem.Text = "Delete";
            this.deleteSeriesMenuItem.Click += new System.EventHandler(this.deleteSeriesMenuItem_Click);
            // 
            // propertiesSeriesMenuItem
            // 
            this.propertiesSeriesMenuItem.Name = "propertiesSeriesMenuItem";
            this.propertiesSeriesMenuItem.Size = new System.Drawing.Size(127, 22);
            this.propertiesSeriesMenuItem.Text = "Properties";
            this.propertiesSeriesMenuItem.Click += new System.EventHandler(this.propertiesSeriesMenuItem_Click);
            // 
            // printSeriesMenuItem
            // 
            this.printSeriesMenuItem.Name = "printSeriesMenuItem";
            this.printSeriesMenuItem.Size = new System.Drawing.Size(127, 22);
            this.printSeriesMenuItem.Text = "Print";
            this.printSeriesMenuItem.Click += new System.EventHandler(this.printSeriesMenuItem_Click);
            // 
            // pnlPrintSeriesPanel
            // 
            this.pnlPrintSeriesPanel.Controls.Add(this.btnEditFormProperties);
            this.pnlPrintSeriesPanel.Controls.Add(this.btnSeriesProperties);
            this.pnlPrintSeriesPanel.Controls.Add(this.lblPrintSeriesName);
            this.pnlPrintSeriesPanel.Controls.Add(this.pnlPrintSeries);
            this.pnlPrintSeriesPanel.Controls.Add(this.btnSavePrintSeries);
            this.pnlPrintSeriesPanel.Controls.Add(this.PrintThisSeries);
            this.pnlPrintSeriesPanel.Location = new System.Drawing.Point(438, 257);
            this.pnlPrintSeriesPanel.Name = "pnlPrintSeriesPanel";
            this.pnlPrintSeriesPanel.Size = new System.Drawing.Size(295, 272);
            this.pnlPrintSeriesPanel.TabIndex = 267;
            this.pnlPrintSeriesPanel.Visible = false;
            // 
            // btnEditFormProperties
            // 
            this.btnEditFormProperties.Appearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditFormProperties.Appearance.Options.UseFont = true;
            this.btnEditFormProperties.Location = new System.Drawing.Point(155, 246);
            this.btnEditFormProperties.Name = "btnEditFormProperties";
            this.btnEditFormProperties.Size = new System.Drawing.Size(135, 23);
            this.btnEditFormProperties.TabIndex = 268;
            this.btnEditFormProperties.Text = "Edit Form Properties";
            this.btnEditFormProperties.Visible = false;
            this.btnEditFormProperties.Click += new System.EventHandler(this.btnEditPrintSeries_Click);
            // 
            // btnSeriesProperties
            // 
            this.btnSeriesProperties.Appearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeriesProperties.Appearance.Options.UseFont = true;
            this.btnSeriesProperties.Location = new System.Drawing.Point(2, 246);
            this.btnSeriesProperties.Name = "btnSeriesProperties";
            this.btnSeriesProperties.Size = new System.Drawing.Size(149, 23);
            this.btnSeriesProperties.TabIndex = 267;
            this.btnSeriesProperties.Text = "Form Properties";
            this.btnSeriesProperties.Visible = false;
            this.btnSeriesProperties.Click += new System.EventHandler(this.btnSeriesProperties_Click);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editFormFormSeries,
            this.deleteFormFormSeries,
            this.propertiesFormFormSeries,
            this.printFormFormSeries});
            this.contextMenuStrip3.Name = "contextMenuStrip1";
            this.contextMenuStrip3.Size = new System.Drawing.Size(128, 92);
            // 
            // editFormFormSeries
            // 
            this.editFormFormSeries.Name = "editFormFormSeries";
            this.editFormFormSeries.Size = new System.Drawing.Size(127, 22);
            this.editFormFormSeries.Text = "Edit";
            this.editFormFormSeries.Click += new System.EventHandler(this.editFormFormSeries_Click);
            // 
            // deleteFormFormSeries
            // 
            this.deleteFormFormSeries.Name = "deleteFormFormSeries";
            this.deleteFormFormSeries.Size = new System.Drawing.Size(127, 22);
            this.deleteFormFormSeries.Text = "Delete";
            this.deleteFormFormSeries.Click += new System.EventHandler(this.deleteFormFormSeries_Click);
            // 
            // propertiesFormFormSeries
            // 
            this.propertiesFormFormSeries.Name = "propertiesFormFormSeries";
            this.propertiesFormFormSeries.Size = new System.Drawing.Size(127, 22);
            this.propertiesFormFormSeries.Text = "Properties";
            this.propertiesFormFormSeries.Click += new System.EventHandler(this.propertiesFormFormSeries_Click);
            // 
            // printFormFormSeries
            // 
            this.printFormFormSeries.Name = "printFormFormSeries";
            this.printFormFormSeries.Size = new System.Drawing.Size(127, 22);
            this.printFormFormSeries.Text = "Print";
            this.printFormFormSeries.Click += new System.EventHandler(this.printFormFormSeries_Click);
            // 
            // UCManageForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.Controls.Add(this.pnlFormSeries);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCreateSeries);
            this.Controls.Add(this.pnlPrintSeriesPanel);
            this.Controls.Add(this.btnCreateForm);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.pnlForms);
            this.Name = "UCManageForms";
            this.Size = new System.Drawing.Size(745, 600);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.pnlPrintSeriesPanel.ResumeLayout(false);
            this.pnlPrintSeriesPanel.PerformLayout();
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl5;
		private System.Windows.Forms.Panel panel1;
		private DevExpress.XtraEditors.LabelControl labelControl6;
        private Infragistics.Win.Misc.UltraButton bDone;
		private Infragistics.Win.UltraWinListView.UltraListView ulvDataEntryTemplates;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCreateForm;
        private System.Windows.Forms.Panel pnlForms;
		private System.Windows.Forms.Panel pnlFormSeries;
        private DevExpress.XtraEditors.SimpleButton btnCreateSeries;
		private System.Windows.Forms.Panel pnlPrintSeries;
		private DevExpress.XtraEditors.LabelControl lblPrintSeriesName;
		private DevExpress.XtraEditors.SimpleButton btnSavePrintSeries;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button1;
		private DevExpress.XtraEditors.SimpleButton PrintThisSeries;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem editSeriesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSeriesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesSeriesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printSeriesMenuItem;
        private System.Windows.Forms.Panel pnlPrintSeriesPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem editFormFormSeries;
        private System.Windows.Forms.ToolStripMenuItem deleteFormFormSeries;
        private System.Windows.Forms.ToolStripMenuItem propertiesFormFormSeries;
        private System.Windows.Forms.ToolStripMenuItem printFormFormSeries;
        private DevExpress.XtraEditors.SimpleButton btnEditFormProperties;
        private DevExpress.XtraEditors.SimpleButton btnSeriesProperties;
    }
}

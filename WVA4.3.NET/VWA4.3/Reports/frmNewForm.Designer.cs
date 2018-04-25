namespace Reports
{
    partial class frmNewForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewForm));
			this.pFormHdr = new System.Windows.Forms.Panel();
			this.lFormTitle = new System.Windows.Forms.Label();
			this.txtName = new DevExpress.XtraEditors.TextEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.txtPath = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.ddlSaveDocument = new DevExpress.XtraEditors.ComboBoxEdit();
			this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.imageList1 = new System.Windows.Forms.ImageList();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.lblFormDocumentValue = new System.Windows.Forms.Label();
			this.pFormHdr.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ddlSaveDocument.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pFormHdr
			// 
			this.pFormHdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(174)))), ((int)(((byte)(65)))));
			this.pFormHdr.Controls.Add(this.lFormTitle);
			this.pFormHdr.Dock = System.Windows.Forms.DockStyle.Top;
			this.pFormHdr.Location = new System.Drawing.Point(0, 0);
			this.pFormHdr.Name = "pFormHdr";
			this.pFormHdr.Size = new System.Drawing.Size(441, 46);
			this.pFormHdr.TabIndex = 239;
			// 
			// lFormTitle
			// 
			this.lFormTitle.AutoSize = true;
			this.lFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFormTitle.Location = new System.Drawing.Point(6, 11);
			this.lFormTitle.Name = "lFormTitle";
			this.lFormTitle.Size = new System.Drawing.Size(148, 20);
			this.lFormTitle.TabIndex = 0;
			this.lFormTitle.Text = "Create New Form";
			// 
			// txtName
			// 
			this.txtName.EditValue = "";
			this.txtName.Location = new System.Drawing.Point(17, 88);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(362, 20);
			this.txtName.TabIndex = 241;
			// 
			// labelControl3
			// 
			this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl3.Appearance.Options.UseFont = true;
			this.labelControl3.Location = new System.Drawing.Point(16, 61);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(78, 16);
			this.labelControl3.TabIndex = 240;
			this.labelControl3.Text = "Form Name:";
			// 
			// txtPath
			// 
			this.txtPath.Appearance.BackColor = System.Drawing.Color.White;
			this.txtPath.Appearance.Options.UseBackColor = true;
			this.txtPath.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.txtPath.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
			this.txtPath.Location = new System.Drawing.Point(18, 172);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(271, 26);
			this.txtPath.TabIndex = 258;
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl2.Appearance.Options.UseFont = true;
			this.labelControl2.Location = new System.Drawing.Point(17, 120);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(187, 16);
			this.labelControl2.TabIndex = 257;
			this.labelControl2.Text = "Attach Form Document (PDF):";
			// 
			// labelControl4
			// 
			this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl4.Appearance.Options.UseFont = true;
			this.labelControl4.Location = new System.Drawing.Point(18, 205);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new System.Drawing.Size(120, 16);
			this.labelControl4.TabIndex = 259;
			this.labelControl4.Text = "Save Document in:";
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl1.Appearance.Options.UseFont = true;
			this.labelControl1.Location = new System.Drawing.Point(18, 262);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(177, 16);
			this.labelControl1.TabIndex = 261;
			this.labelControl1.Text = "Select Data Entry Template:";
			// 
			// ddlSaveDocument
			// 
			this.ddlSaveDocument.Location = new System.Drawing.Point(18, 236);
			this.ddlSaveDocument.Name = "ddlSaveDocument";
			this.ddlSaveDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ddlSaveDocument.Size = new System.Drawing.Size(250, 20);
			this.ddlSaveDocument.TabIndex = 263;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(298, 172);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(89, 29);
			this.btnBrowse.TabIndex = 265;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// btnSave
			// 
			this.btnSave.Appearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Appearance.Options.UseFont = true;
			this.btnSave.Location = new System.Drawing.Point(341, 428);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(83, 29);
			this.btnSave.TabIndex = 267;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// panel2
			// 
			this.panel2.AutoScroll = true;
			this.panel2.Location = new System.Drawing.Point(18, 294);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(402, 99);
			this.panel2.TabIndex = 268;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "row_add.png");
			// 
			// btnCancel
			// 
			this.btnCancel.Appearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Appearance.Options.UseFont = true;
			this.btnCancel.Location = new System.Drawing.Point(224, 428);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 29);
			this.btnCancel.TabIndex = 272;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblFormDocumentValue
			// 
			this.lblFormDocumentValue.Font = new System.Drawing.Font("Calibri", 9.75F);
			this.lblFormDocumentValue.Location = new System.Drawing.Point(25, 141);
			this.lblFormDocumentValue.Name = "lblFormDocumentValue";
			this.lblFormDocumentValue.Size = new System.Drawing.Size(417, 27);
			this.lblFormDocumentValue.TabIndex = 273;
			// 
			// frmNewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
			this.ClientSize = new System.Drawing.Size(441, 473);
			this.Controls.Add(this.lblFormDocumentValue);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.ddlSaveDocument);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.labelControl4);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.pFormHdr);
			this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNewForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Forms";
			this.pFormHdr.ResumeLayout(false);
			this.pFormHdr.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ddlSaveDocument.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pFormHdr;
        private System.Windows.Forms.Label lFormTitle;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl txtPath;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit ddlSaveDocument;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.LookUpEdit ddlData;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label lblFormDocumentValue;
    }
}
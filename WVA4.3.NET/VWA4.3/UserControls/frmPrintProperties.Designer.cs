namespace UserControls
{
    partial class frmPrintProperties
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
			Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintProperties));
			this.label1 = new System.Windows.Forms.Label();
			this.chkImage = new System.Windows.Forms.CheckBox();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.chkFilter = new System.Windows.Forms.CheckBox();
			this.nPages = new System.Windows.Forms.NumericUpDown();
			this.chkFit = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtTo = new System.Windows.Forms.TextBox();
			this.txtFrom = new System.Windows.Forms.TextBox();
			this.radioRange = new System.Windows.Forms.RadioButton();
			this.radioCurrent = new System.Windows.Forms.RadioButton();
			this.radioAll = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnPreview = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pFormHdr = new System.Windows.Forms.Panel();
			this.lFormTitle = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.nPages)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.pFormHdr.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Title:";
			// 
			// chkImage
			// 
			this.chkImage.AutoSize = true;
			this.chkImage.Location = new System.Drawing.Point(1, 55);
			this.chkImage.Name = "chkImage";
			this.chkImage.Size = new System.Drawing.Size(121, 17);
			this.chkImage.TabIndex = 4;
			this.chkImage.Text = "Page Header Image";
			this.chkImage.UseVisualStyleBackColor = true;
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(49, 52);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(289, 20);
			this.txtTitle.TabIndex = 6;
			this.txtTitle.Text = "Waste";
			// 
			// chkFilter
			// 
			this.chkFilter.AutoSize = true;
			this.chkFilter.Location = new System.Drawing.Point(1, 36);
			this.chkFilter.Name = "chkFilter";
			this.chkFilter.Size = new System.Drawing.Size(142, 17);
			this.chkFilter.TabIndex = 7;
			this.chkFilter.Text = "Include Filter Description";
			this.chkFilter.UseVisualStyleBackColor = true;
			// 
			// nPages
			// 
			this.nPages.Enabled = false;
			this.nPages.Location = new System.Drawing.Point(92, 16);
			this.nPages.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nPages.Name = "nPages";
			this.nPages.Size = new System.Drawing.Size(63, 20);
			this.nPages.TabIndex = 8;
			this.nPages.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// chkFit
			// 
			this.chkFit.AutoSize = true;
			this.chkFit.Location = new System.Drawing.Point(1, 16);
			this.chkFit.Name = "chkFit";
			this.chkFit.Size = new System.Drawing.Size(85, 17);
			this.chkFit.TabIndex = 9;
			this.chkFit.Text = "Fit to Pages:";
			this.chkFit.UseVisualStyleBackColor = true;
			this.chkFit.CheckedChanged += new System.EventHandler(this.chkFit_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtTo);
			this.groupBox1.Controls.Add(this.txtFrom);
			this.groupBox1.Controls.Add(this.radioRange);
			this.groupBox1.Controls.Add(this.radioCurrent);
			this.groupBox1.Controls.Add(this.radioAll);
			this.groupBox1.Location = new System.Drawing.Point(186, 75);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(153, 77);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Page Range";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(94, 54);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(8, 16);
			this.label7.TabIndex = 63;
			this.label7.Text = "-";
			// 
			// txtTo
			// 
			this.txtTo.Enabled = false;
			this.txtTo.Location = new System.Drawing.Point(102, 54);
			this.txtTo.Name = "txtTo";
			this.txtTo.Size = new System.Drawing.Size(40, 20);
			this.txtTo.TabIndex = 62;
			// 
			// txtFrom
			// 
			this.txtFrom.Enabled = false;
			this.txtFrom.Location = new System.Drawing.Point(56, 54);
			this.txtFrom.Name = "txtFrom";
			this.txtFrom.Size = new System.Drawing.Size(40, 20);
			this.txtFrom.TabIndex = 61;
			// 
			// radioRange
			// 
			this.radioRange.AutoSize = true;
			this.radioRange.Location = new System.Drawing.Point(1, 54);
			this.radioRange.Name = "radioRange";
			this.radioRange.Size = new System.Drawing.Size(58, 17);
			this.radioRange.TabIndex = 2;
			this.radioRange.TabStop = true;
			this.radioRange.Text = "Pages:";
			this.radioRange.UseVisualStyleBackColor = true;
			this.radioRange.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// radioCurrent
			// 
			this.radioCurrent.AutoSize = true;
			this.radioCurrent.Location = new System.Drawing.Point(1, 35);
			this.radioCurrent.Name = "radioCurrent";
			this.radioCurrent.Size = new System.Drawing.Size(87, 17);
			this.radioCurrent.TabIndex = 1;
			this.radioCurrent.TabStop = true;
			this.radioCurrent.Text = "Current Page";
			this.radioCurrent.UseVisualStyleBackColor = true;
			// 
			// radioAll
			// 
			this.radioAll.AutoSize = true;
			this.radioAll.Checked = true;
			this.radioAll.Location = new System.Drawing.Point(1, 17);
			this.radioAll.Name = "radioAll";
			this.radioAll.Size = new System.Drawing.Size(36, 17);
			this.radioAll.TabIndex = 0;
			this.radioAll.TabStop = true;
			this.radioAll.Text = "All";
			this.radioAll.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkFit);
			this.groupBox2.Controls.Add(this.chkImage);
			this.groupBox2.Controls.Add(this.chkFilter);
			this.groupBox2.Controls.Add(this.nPages);
			this.groupBox2.Location = new System.Drawing.Point(11, 75);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(169, 77);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Settings";
			// 
			// btnPreview
			// 
			this.btnPreview.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnPreview.Location = new System.Drawing.Point(170, 162);
			this.btnPreview.Name = "btnPreview";
			this.btnPreview.Size = new System.Drawing.Size(88, 23);
			this.btnPreview.TabIndex = 13;
			this.btnPreview.Text = "Print Preview";
			this.btnPreview.UseVisualStyleBackColor = true;
			this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(264, 162);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// pFormHdr
			// 
			this.pFormHdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(174)))), ((int)(((byte)(65)))));
			this.pFormHdr.Controls.Add(this.lFormTitle);
			this.pFormHdr.Dock = System.Windows.Forms.DockStyle.Top;
			this.pFormHdr.Location = new System.Drawing.Point(0, 0);
			this.pFormHdr.Name = "pFormHdr";
			this.pFormHdr.Size = new System.Drawing.Size(348, 39);
			this.pFormHdr.TabIndex = 242;
			// 
			// lFormTitle
			// 
			appearance18.FontData.BoldAsString = "True";
			appearance18.TextHAlignAsString = "Left";
			appearance18.TextVAlignAsString = "Middle";
			this.lFormTitle.Appearance = appearance18;
			this.lFormTitle.AutoSize = true;
			this.lFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFormTitle.Location = new System.Drawing.Point(7, 8);
			this.lFormTitle.Name = "lFormTitle";
			this.lFormTitle.Size = new System.Drawing.Size(188, 21);
			this.lFormTitle.TabIndex = 214;
			this.lFormTitle.Text = "Choose Print Properties";
			// 
			// frmPrintProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(348, 189);
			this.Controls.Add(this.pFormHdr);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnPreview);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPrintProperties";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Print Properties";
			((System.ComponentModel.ISupportInitialize)(this.nPages)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.pFormHdr.ResumeLayout(false);
			this.pFormHdr.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkImage;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.CheckBox chkFilter;
        private System.Windows.Forms.NumericUpDown nPages;
        private System.Windows.Forms.CheckBox chkFit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioRange;
        private System.Windows.Forms.RadioButton radioCurrent;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pFormHdr;
		private Infragistics.Win.Misc.UltraLabel lFormTitle;
    }
}
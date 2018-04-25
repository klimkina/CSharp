namespace UserControls
{
    partial class UCBaseParameters
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblWasteClasses = new System.Windows.Forms.Label();
            this.cbWasteClasses = new UserControls.CheckedComboBox();
            this.chkLeanPath = new System.Windows.Forms.CheckBox();
            this.chkCustomer = new System.Windows.Forms.CheckBox();
            this.chkLbs = new System.Windows.Forms.CheckBox();
            this.chkHorizontal = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPalette = new System.Windows.Forms.ComboBox();
            this.chk3D = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSubTitle = new System.Windows.Forms.TextBox();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnRTF = new System.Windows.Forms.Button();
            this.toolTipWasteClasses = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblWasteClasses);
            this.groupBox2.Controls.Add(this.cbWasteClasses);
            this.groupBox2.Controls.Add(this.chkLeanPath);
            this.groupBox2.Controls.Add(this.chkCustomer);
            this.groupBox2.Controls.Add(this.chkLbs);
            this.groupBox2.Controls.Add(this.chkHorizontal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbPalette);
            this.groupBox2.Controls.Add(this.chk3D);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTitle);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtSubTitle);
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 110);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chart Appearance:";
            // 
            // lblWasteClasses
            // 
            this.lblWasteClasses.AutoSize = true;
            this.lblWasteClasses.Location = new System.Drawing.Point(321, 87);
            this.lblWasteClasses.Name = "lblWasteClasses";
            this.lblWasteClasses.Size = new System.Drawing.Size(80, 13);
            this.lblWasteClasses.TabIndex = 44;
            this.lblWasteClasses.Text = "Waste Classes:";
            this.toolTipWasteClasses.SetToolTip(this.lblWasteClasses, "\"Waste Classes\"");
            // 
            // cbWasteClasses
            // 
            this.cbWasteClasses.CheckOnClick = true;
            this.cbWasteClasses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbWasteClasses.DropDownHeight = 1;
            this.cbWasteClasses.FormattingEnabled = true;
            this.cbWasteClasses.IntegralHeight = false;
            this.cbWasteClasses.Location = new System.Drawing.Point(407, 85);
            this.cbWasteClasses.Name = "cbWasteClasses";
            this.cbWasteClasses.Size = new System.Drawing.Size(144, 21);
            this.cbWasteClasses.TabIndex = 43;
            this.cbWasteClasses.ValueSeparator = ", ";
            this.cbWasteClasses.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cbWasteClasses_ItemCheck);
            // 
            // chkLeanPath
            // 
            this.chkLeanPath.AutoSize = true;
            this.chkLeanPath.Location = new System.Drawing.Point(143, 87);
            this.chkLeanPath.Name = "chkLeanPath";
            this.chkLeanPath.Size = new System.Drawing.Size(99, 17);
            this.chkLeanPath.TabIndex = 42;
            this.chkLeanPath.Text = "LeanPath Logo";
            this.chkLeanPath.UseVisualStyleBackColor = true;
            // 
            // chkCustomer
            // 
            this.chkCustomer.AutoSize = true;
            this.chkCustomer.Location = new System.Drawing.Point(49, 87);
            this.chkCustomer.Name = "chkCustomer";
            this.chkCustomer.Size = new System.Drawing.Size(97, 17);
            this.chkCustomer.TabIndex = 41;
            this.chkCustomer.Text = "Customer Logo";
            this.chkCustomer.UseVisualStyleBackColor = true;
            // 
            // chkLbs
            // 
            this.chkLbs.AutoSize = true;
            this.chkLbs.Location = new System.Drawing.Point(314, 15);
            this.chkLbs.Name = "chkLbs";
            this.chkLbs.Size = new System.Drawing.Size(83, 17);
            this.chkLbs.TabIndex = 39;
            this.chkLbs.Text = "Show in lbs.";
            this.chkLbs.UseVisualStyleBackColor = true;
            // 
            // chkHorizontal
            // 
            this.chkHorizontal.AutoSize = true;
            this.chkHorizontal.Location = new System.Drawing.Point(211, 15);
            this.chkHorizontal.Name = "chkHorizontal";
            this.chkHorizontal.Size = new System.Drawing.Size(97, 17);
            this.chkHorizontal.TabIndex = 38;
            this.chkHorizontal.Text = "Horizontal Bars";
            this.chkHorizontal.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Color:";
            // 
            // cbPalette
            // 
            this.cbPalette.FormattingEnabled = true;
            this.cbPalette.Items.AddRange(new object[] {
            "Default",
            "Cascade",
            "Springtime",
            "Iceberg",
            "Confetti",
            "Greens",
            "Berries",
            "Autumn",
            "Murphy"});
            this.cbPalette.Location = new System.Drawing.Point(61, 12);
            this.cbPalette.Name = "cbPalette";
            this.cbPalette.Size = new System.Drawing.Size(56, 21);
            this.cbPalette.TabIndex = 27;
            // 
            // chk3D
            // 
            this.chk3D.AutoSize = true;
            this.chk3D.Checked = true;
            this.chk3D.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk3D.Location = new System.Drawing.Point(123, 15);
            this.chk3D.Name = "chk3D";
            this.chk3D.Size = new System.Drawing.Size(82, 17);
            this.chk3D.TabIndex = 29;
            this.chk3D.Text = "3D Charting";
            this.chk3D.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.AcceptsReturn = true;
            this.txtTitle.Location = new System.Drawing.Point(61, 38);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(485, 20);
            this.txtTitle.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "SubTitle:";
            // 
            // txtSubTitle
            // 
            this.txtSubTitle.Location = new System.Drawing.Point(61, 62);
            this.txtSubTitle.Name = "txtSubTitle";
            this.txtSubTitle.Size = new System.Drawing.Size(485, 20);
            this.txtSubTitle.TabIndex = 33;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Location = new System.Drawing.Point(391, 115);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(81, 23);
            this.btnExportPDF.TabIndex = 55;
            this.btnExportPDF.Text = "Export to PDF";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnViewReport.Location = new System.Drawing.Point(303, 114);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(85, 23);
            this.btnViewReport.TabIndex = 54;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(6, 114);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(93, 23);
            this.btnFilter.TabIndex = 53;
            this.btnFilter.Text = "Advanced Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(117, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 23);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(157, 114);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(40, 23);
            this.btnLoad.TabIndex = 59;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnRTF
            // 
            this.btnRTF.Location = new System.Drawing.Point(474, 115);
            this.btnRTF.Name = "btnRTF";
            this.btnRTF.Size = new System.Drawing.Size(81, 23);
            this.btnRTF.TabIndex = 60;
            this.btnRTF.Text = "Export to RTF";
            this.btnRTF.UseVisualStyleBackColor = true;
            this.btnRTF.Click += new System.EventHandler(this.btnRTF_Click);
            // 
            // UCBaseParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRTF);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.btnFilter);
            this.Name = "UCBaseParameters";
            this.Size = new System.Drawing.Size(563, 138);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkLbs;
        private System.Windows.Forms.CheckBox chkHorizontal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPalette;
        private System.Windows.Forms.CheckBox chk3D;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSubTitle;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.CheckBox chkCustomer;
        private System.Windows.Forms.CheckBox chkLeanPath;
        private System.Windows.Forms.Button btnRTF;
        private UserControls.CheckedComboBox cbWasteClasses;
        private System.Windows.Forms.Label lblWasteClasses;
        private System.Windows.Forms.ToolTip toolTipWasteClasses;
    }
}

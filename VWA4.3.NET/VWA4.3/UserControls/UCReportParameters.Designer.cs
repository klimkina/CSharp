namespace UserControls
{
    partial class UCReportParameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCReportParameters));
            this.panelHideParams = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.popupShowHide = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelParams = new System.Windows.Forms.Panel();
            this.gpTrendParameters = new System.Windows.Forms.GroupBox();
            this.chkLbs = new System.Windows.Forms.CheckBox();
            this.chkNumOfTrans = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkHorizontal = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPalette = new System.Windows.Forms.ComboBox();
            this.chk3D = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnLoadLogo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLogo = new System.Windows.Forms.TextBox();
            this.txtSubTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboTimeFrame = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.cbDayOfWeek = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.endDate = new UserControls.SmartDateTimePicker();
            this.startDate = new UserControls.SmartDateTimePicker();
            this.panelHideParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.popupShowHide.SuspendLayout();
            this.panelParams.SuspendLayout();
            this.gpTrendParameters.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHideParams
            // 
            this.panelHideParams.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelHideParams.Controls.Add(this.label9);
            this.panelHideParams.Controls.Add(this.pictureBox1);
            this.panelHideParams.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHideParams.Location = new System.Drawing.Point(0, 244);
            this.panelHideParams.Name = "panelHideParams";
            this.panelHideParams.Size = new System.Drawing.Size(608, 16);
            this.panelHideParams.TabIndex = 48;
            this.toolTip1.SetToolTip(this.panelHideParams, "Click to Show Report Properties");
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Report Parameters";
            this.toolTip1.SetToolTip(this.label9, "Right Click to show parameters");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(14, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // popupShowHide
            // 
            this.popupShowHide.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideParametersToolStripMenuItem});
            this.popupShowHide.Name = "popupShowHide";
            this.popupShowHide.Size = new System.Drawing.Size(162, 26);
            // 
            // hideParametersToolStripMenuItem
            // 
            this.hideParametersToolStripMenuItem.Name = "hideParametersToolStripMenuItem";
            this.hideParametersToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.hideParametersToolStripMenuItem.Text = "Hide Parameters";
            this.hideParametersToolStripMenuItem.Click += new System.EventHandler(this.hideParametersToolStripMenuItem_Click);
            // 
            // panelParams
            // 
            this.panelParams.AutoSize = true;
            this.panelParams.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelParams.Controls.Add(this.gpTrendParameters);
            this.panelParams.Controls.Add(this.groupBox2);
            this.panelParams.Controls.Add(this.groupBox1);
            this.panelParams.Controls.Add(this.cboTimeFrame);
            this.panelParams.Controls.Add(this.label8);
            this.panelParams.Controls.Add(this.btnExportPDF);
            this.panelParams.Controls.Add(this.cbDayOfWeek);
            this.panelParams.Controls.Add(this.label2);
            this.panelParams.Controls.Add(this.btnViewReport);
            this.panelParams.Controls.Add(this.btnFilter);
            this.panelParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParams.Location = new System.Drawing.Point(0, 0);
            this.panelParams.Name = "panelParams";
            this.panelParams.Size = new System.Drawing.Size(608, 260);
            this.panelParams.TabIndex = 50;
            // 
            // gpTrendParameters
            // 
            this.gpTrendParameters.Controls.Add(this.chkLbs);
            this.gpTrendParameters.Controls.Add(this.chkNumOfTrans);
            this.gpTrendParameters.Location = new System.Drawing.Point(5, 51);
            this.gpTrendParameters.Name = "gpTrendParameters";
            this.gpTrendParameters.Size = new System.Drawing.Size(239, 49);
            this.gpTrendParameters.TabIndex = 57;
            this.gpTrendParameters.TabStop = false;
            this.gpTrendParameters.Text = "Report Parameters:";
            // 
            // chkLbs
            // 
            this.chkLbs.AutoSize = true;
            this.chkLbs.Location = new System.Drawing.Point(6, 30);
            this.chkLbs.Name = "chkLbs";
            this.chkLbs.Size = new System.Drawing.Size(80, 17);
            this.chkLbs.TabIndex = 25;
            this.chkLbs.Text = "Show in lbs";
            this.chkLbs.UseVisualStyleBackColor = true;
            // 
            // chkNumOfTrans
            // 
            this.chkNumOfTrans.AutoSize = true;
            this.chkNumOfTrans.Location = new System.Drawing.Point(6, 12);
            this.chkNumOfTrans.Name = "chkNumOfTrans";
            this.chkNumOfTrans.Size = new System.Drawing.Size(173, 17);
            this.chkNumOfTrans.TabIndex = 26;
            this.chkNumOfTrans.Text = "Show # of Waste Transactions";
            this.chkNumOfTrans.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkHorizontal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbPalette);
            this.groupBox2.Controls.Add(this.chk3D);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTitle);
            this.groupBox2.Controls.Add(this.btnLoadLogo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtLogo);
            this.groupBox2.Controls.Add(this.txtSubTitle);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(5, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(599, 110);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chart Appearance:";
            // 
            // chkHorizontal
            // 
            this.chkHorizontal.AutoSize = true;
            this.chkHorizontal.Location = new System.Drawing.Point(309, 16);
            this.chkHorizontal.Name = "chkHorizontal";
            this.chkHorizontal.Size = new System.Drawing.Size(97, 17);
            this.chkHorizontal.TabIndex = 38;
            this.chkHorizontal.Text = "Horizontal Bars";
            this.chkHorizontal.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Chart Color:";
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
            this.cbPalette.Location = new System.Drawing.Point(66, 13);
            this.cbPalette.Name = "cbPalette";
            this.cbPalette.Size = new System.Drawing.Size(121, 21);
            this.cbPalette.TabIndex = 27;
            // 
            // chk3D
            // 
            this.chk3D.AutoSize = true;
            this.chk3D.Checked = true;
            this.chk3D.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk3D.Location = new System.Drawing.Point(207, 16);
            this.chk3D.Name = "chk3D";
            this.chk3D.Size = new System.Drawing.Size(82, 17);
            this.chk3D.TabIndex = 29;
            this.chk3D.Text = "3D Charting";
            this.chk3D.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.AcceptsReturn = true;
            this.txtTitle.Location = new System.Drawing.Point(66, 38);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(526, 20);
            this.txtTitle.TabIndex = 31;
            // 
            // btnLoadLogo
            // 
            this.btnLoadLogo.Location = new System.Drawing.Point(545, 85);
            this.btnLoadLogo.Name = "btnLoadLogo";
            this.btnLoadLogo.Size = new System.Drawing.Size(47, 23);
            this.btnLoadLogo.TabIndex = 37;
            this.btnLoadLogo.Text = "Load";
            this.btnLoadLogo.UseVisualStyleBackColor = true;
            this.btnLoadLogo.Click += new System.EventHandler(this.btnLoadLogo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "SubTitle:";
            // 
            // txtLogo
            // 
            this.txtLogo.Location = new System.Drawing.Point(66, 86);
            this.txtLogo.Name = "txtLogo";
            this.txtLogo.Size = new System.Drawing.Size(478, 20);
            this.txtLogo.TabIndex = 36;
            // 
            // txtSubTitle
            // 
            this.txtSubTitle.Location = new System.Drawing.Point(66, 62);
            this.txtSubTitle.Name = "txtSubTitle";
            this.txtSubTitle.Size = new System.Drawing.Size(526, 20);
            this.txtSubTitle.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Logo:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbPeriod);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Location = new System.Drawing.Point(252, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 95);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Frame Used:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Aggregate Period:";
            // 
            // cbPeriod
            // 
            this.cbPeriod.FormattingEnabled = true;
            this.cbPeriod.Items.AddRange(new object[] {
            "Day",
            "Week",
            "Month",
            "Quarter",
            "Year"});
            this.cbPeriod.Location = new System.Drawing.Point(96, 13);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(121, 21);
            this.cbPeriod.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Period:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.endDate);
            this.panel3.Controls.Add(this.startDate);
            this.panel3.Location = new System.Drawing.Point(48, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(298, 48);
            this.panel3.TabIndex = 42;
            // 
            // cboTimeFrame
            // 
            this.cboTimeFrame.FormattingEnabled = true;
            this.cboTimeFrame.Items.AddRange(new object[] {
            "Custom",
            "Last week - by day ",
            "Last 2 weeks - by day ",
            "Last 4 weeks - by week ",
            "Last 3 months - by months ",
            "Last year - by month ",
            "All - by month "});
            this.cboTimeFrame.Location = new System.Drawing.Point(76, 30);
            this.cboTimeFrame.Name = "cboTimeFrame";
            this.cboTimeFrame.Size = new System.Drawing.Size(168, 21);
            this.cboTimeFrame.TabIndex = 54;
            this.cboTimeFrame.SelectedIndexChanged += new System.EventHandler(this.cboTimeFrame_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Time Frame:";
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Location = new System.Drawing.Point(523, 217);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(81, 23);
            this.btnExportPDF.TabIndex = 52;
            this.btnExportPDF.Text = "Export to PDF";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // cbDayOfWeek
            // 
            this.cbDayOfWeek.FormattingEnabled = true;
            this.cbDayOfWeek.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.cbDayOfWeek.Location = new System.Drawing.Point(123, 5);
            this.cbDayOfWeek.Name = "cbDayOfWeek";
            this.cbDayOfWeek.Size = new System.Drawing.Size(121, 21);
            this.cbDayOfWeek.TabIndex = 51;
            this.cbDayOfWeek.SelectedIndexChanged += new System.EventHandler(this.cbDayOfWeek_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Starting Day Of Week: ";
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(442, 217);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(81, 23);
            this.btnViewReport.TabIndex = 49;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(5, 217);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(81, 23);
            this.btnFilter.TabIndex = 48;
            this.btnFilter.Text = "Filter Data";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(3, 25);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(291, 20);
            this.endDate.TabIndex = 1;
            this.endDate.Value = new System.DateTime(2008, 4, 22, 12, 9, 59, 0);
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(3, 3);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(291, 20);
            this.startDate.TabIndex = 0;
            this.startDate.Value = new System.DateTime(2008, 4, 22, 12, 9, 54, 0);
            // 
            // UCReportParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ContextMenuStrip = this.popupShowHide;
            this.Controls.Add(this.panelHideParams);
            this.Controls.Add(this.panelParams);
            this.Name = "UCReportParameters";
            this.Size = new System.Drawing.Size(608, 260);
            this.panelHideParams.ResumeLayout(false);
            this.panelHideParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.popupShowHide.ResumeLayout(false);
            this.panelParams.ResumeLayout(false);
            this.panelParams.PerformLayout();
            this.gpTrendParameters.ResumeLayout(false);
            this.gpTrendParameters.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHideParams;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip popupShowHide;
        private System.Windows.Forms.ToolStripMenuItem hideParametersToolStripMenuItem;
        private System.Windows.Forms.Panel panelParams;
        private System.Windows.Forms.GroupBox gpTrendParameters;
        private System.Windows.Forms.CheckBox chkLbs;
        private System.Windows.Forms.CheckBox chkNumOfTrans;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPalette;
        private System.Windows.Forms.CheckBox chk3D;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnLoadLogo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLogo;
        private System.Windows.Forms.TextBox txtSubTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private SmartDateTimePicker endDate;
        private SmartDateTimePicker startDate;
        private System.Windows.Forms.ComboBox cboTimeFrame;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.ComboBox cbDayOfWeek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.CheckBox chkHorizontal;
    }
}

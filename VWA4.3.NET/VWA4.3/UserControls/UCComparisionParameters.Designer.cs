namespace UserControls
{
    partial class UCComparisionParameters
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbCompareWeek = new System.Windows.Forms.ComboBox();
            this.chkRecentWeek = new System.Windows.Forms.CheckBox();
            this.dtCompareWeek = new System.Windows.Forms.DateTimePicker();
            this.dtStartWeek = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblComparision = new System.Windows.Forms.Label();
            this.cbComparision = new System.Windows.Forms.ComboBox();
            this.cbDayOfWeek = new System.Windows.Forms.ComboBox();
            this.gpTrendParameters = new System.Windows.Forms.GroupBox();
            this.numShown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gpTrendParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numShown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Location = new System.Drawing.Point(248, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 71);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Weeks to Compare:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbCompareWeek);
            this.panel4.Controls.Add(this.chkRecentWeek);
            this.panel4.Controls.Add(this.dtCompareWeek);
            this.panel4.Controls.Add(this.dtStartWeek);
            this.panel4.Location = new System.Drawing.Point(6, 14);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(307, 53);
            this.panel4.TabIndex = 42;
            // 
            // cbCompareWeek
            // 
            this.cbCompareWeek.FormattingEnabled = true;
            this.cbCompareWeek.Items.AddRange(new object[] {
            "User Select",
            "None",
            "Previous Week",
            "Previous Cycle",
            "Previous Year"});
            this.cbCompareWeek.Location = new System.Drawing.Point(3, 28);
            this.cbCompareWeek.Name = "cbCompareWeek";
            this.cbCompareWeek.Size = new System.Drawing.Size(98, 21);
            this.cbCompareWeek.TabIndex = 5;
            this.cbCompareWeek.SelectedIndexChanged += new System.EventHandler(this.cbCompareWeek_SelectedIndexChanged);
            // 
            // chkRecentWeek
            // 
            this.chkRecentWeek.AutoSize = true;
            this.chkRecentWeek.Location = new System.Drawing.Point(3, 5);
            this.chkRecentWeek.Name = "chkRecentWeek";
            this.chkRecentWeek.Size = new System.Drawing.Size(93, 17);
            this.chkRecentWeek.TabIndex = 4;
            this.chkRecentWeek.Text = "Recent Week";
            this.chkRecentWeek.UseVisualStyleBackColor = true;
            this.chkRecentWeek.CheckedChanged += new System.EventHandler(this.chkRecentWeek_CheckedChanged);
            // 
            // dtCompareWeek
            // 
            this.dtCompareWeek.Location = new System.Drawing.Point(105, 29);
            this.dtCompareWeek.Name = "dtCompareWeek";
            this.dtCompareWeek.Size = new System.Drawing.Size(200, 20);
            this.dtCompareWeek.TabIndex = 3;
            // 
            // dtStartWeek
            // 
            this.dtStartWeek.Location = new System.Drawing.Point(105, 4);
            this.dtStartWeek.Name = "dtStartWeek";
            this.dtStartWeek.Size = new System.Drawing.Size(200, 20);
            this.dtStartWeek.TabIndex = 2;
            this.dtStartWeek.ValueChanged += new System.EventHandler(this.dtStartWeek_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Starting Day Of Week: ";
            // 
            // lblComparision
            // 
            this.lblComparision.AutoSize = true;
            this.lblComparision.Location = new System.Drawing.Point(61, 35);
            this.lblComparision.Name = "lblComparision";
            this.lblComparision.Size = new System.Drawing.Size(57, 13);
            this.lblComparision.TabIndex = 53;
            this.lblComparision.Text = "Report on:";
            // 
            // cbComparision
            // 
            this.cbComparision.FormattingEnabled = true;
            this.cbComparision.Items.AddRange(new object[] {
            "Days of Week",
            "Loss Categories",
            //VWA4Common.VWACommon.WasteProfile + 
			"Food Categories",
            "Stations"});
            this.cbComparision.Location = new System.Drawing.Point(119, 32);
            this.cbComparision.Name = "cbComparision";
            this.cbComparision.Size = new System.Drawing.Size(121, 21);
            this.cbComparision.TabIndex = 52;
            this.cbComparision.SelectedIndexChanged += new System.EventHandler(this.cbComparision_SelectedIndexChanged);
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
            this.cbDayOfWeek.Location = new System.Drawing.Point(119, 10);
            this.cbDayOfWeek.Name = "cbDayOfWeek";
            this.cbDayOfWeek.Size = new System.Drawing.Size(121, 21);
            this.cbDayOfWeek.TabIndex = 55;
            this.cbDayOfWeek.SelectedIndexChanged += new System.EventHandler(this.cbDayOfWeek_SelectedIndexChanged);
            // 
            // gpTrendParameters
            // 
            this.gpTrendParameters.Controls.Add(this.numShown);
            this.gpTrendParameters.Controls.Add(this.label1);
            this.gpTrendParameters.Controls.Add(this.label2);
            this.gpTrendParameters.Controls.Add(this.cbDayOfWeek);
            this.gpTrendParameters.Controls.Add(this.lblComparision);
            this.gpTrendParameters.Controls.Add(this.cbComparision);
            this.gpTrendParameters.Location = new System.Drawing.Point(3, 0);
            this.gpTrendParameters.Name = "gpTrendParameters";
            this.gpTrendParameters.Size = new System.Drawing.Size(241, 77);
            this.gpTrendParameters.TabIndex = 60;
            this.gpTrendParameters.TabStop = false;
            this.gpTrendParameters.Text = "Report Parameters:";
            // 
            // numShown
            // 
            this.numShown.Location = new System.Drawing.Point(119, 54);
            this.numShown.Name = "numShown";
            this.numShown.Size = new System.Drawing.Size(121, 20);
            this.numShown.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "# of Items Shown: ";
            // 
            // UCComparisionParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpTrendParameters);
            this.Controls.Add(this.groupBox1);
            this.Name = "UCComparisionParameters";
            this.Size = new System.Drawing.Size(566, 78);
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.gpTrendParameters.ResumeLayout(false);
            this.gpTrendParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numShown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbCompareWeek;
        private System.Windows.Forms.DateTimePicker dtCompareWeek;
        private System.Windows.Forms.DateTimePicker dtStartWeek;
        private System.Windows.Forms.CheckBox chkRecentWeek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblComparision;
        private System.Windows.Forms.ComboBox cbComparision;
        private System.Windows.Forms.ComboBox cbDayOfWeek;
        private System.Windows.Forms.GroupBox gpTrendParameters;
        private System.Windows.Forms.NumericUpDown numShown;
        private System.Windows.Forms.Label label1;
    }
}

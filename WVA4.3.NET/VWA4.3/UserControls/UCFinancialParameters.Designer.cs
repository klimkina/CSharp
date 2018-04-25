namespace UserControls
{
    partial class UCFinancialParameters
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
            this.dtPeriodStart = new System.Windows.Forms.DateTimePicker();
            this.numOfMonths = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ucSiteChooser1 = new UserControls.UCSiteChooser();
            this.gpFinancials = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numOfMonths)).BeginInit();
            this.gpFinancials.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtPeriodStart
            // 
            this.dtPeriodStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPeriodStart.Location = new System.Drawing.Point(299, 23);
            this.dtPeriodStart.Name = "dtPeriodStart";
            this.dtPeriodStart.Size = new System.Drawing.Size(121, 20);
            this.dtPeriodStart.TabIndex = 1;
            // 
            // numOfMonths
            // 
            this.numOfMonths.Location = new System.Drawing.Point(299, 46);
            this.numOfMonths.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numOfMonths.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOfMonths.Name = "numOfMonths";
            this.numOfMonths.Size = new System.Drawing.Size(120, 20);
            this.numOfMonths.TabIndex = 2;
            this.numOfMonths.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Site:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(218, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Period Start:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(182, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number of Months:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(2, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mode:";
            // 
            // cbMode
            // 
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "Points",
            "CPM"});
            this.cbMode.Location = new System.Drawing.Point(47, 46);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(121, 21);
            this.cbMode.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(124, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
			//VWA4Common.VWACommon.WasteProfile + 
			"Points ",
			//VWA4Common.VWACommon.WasteProfile[0] + 
			"CPM"});
            this.comboBox1.Location = new System.Drawing.Point(124, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // ucSiteChooser1
            // 
            this.ucSiteChooser1.Location = new System.Drawing.Point(47, 19);
            this.ucSiteChooser1.Name = "ucSiteChooser1";
            this.ucSiteChooser1.Size = new System.Drawing.Size(121, 21);
            this.ucSiteChooser1.TabIndex = 0;
            this.ucSiteChooser1.SiteChanged += new UCSiteChooser.SiteChangedEventHandler(ucSiteChooser1_SiteChanged);
            // 
            // gpFinancials
            // 
            this.gpFinancials.Controls.Add(this.ucSiteChooser1);
            this.gpFinancials.Controls.Add(this.cbMode);
            this.gpFinancials.Controls.Add(this.dtPeriodStart);
            this.gpFinancials.Controls.Add(this.label4);
            this.gpFinancials.Controls.Add(this.numOfMonths);
            this.gpFinancials.Controls.Add(this.label3);
            this.gpFinancials.Controls.Add(this.label1);
            this.gpFinancials.Controls.Add(this.label2);
            this.gpFinancials.Location = new System.Drawing.Point(3, 3);
            this.gpFinancials.Name = "gpFinancials";
            this.gpFinancials.Size = new System.Drawing.Size(427, 72);
            this.gpFinancials.TabIndex = 8;
            this.gpFinancials.TabStop = false;
            this.gpFinancials.Text = "Financial Parameters";
            // 
            // UCFinancialParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpFinancials);
            this.Name = "UCFinancialParameters";
            this.Size = new System.Drawing.Size(433, 85);
            ((System.ComponentModel.ISupportInitialize)(this.numOfMonths)).EndInit();
            this.gpFinancials.ResumeLayout(false);
            this.gpFinancials.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UCSiteChooser ucSiteChooser1;
        private System.Windows.Forms.DateTimePicker dtPeriodStart;
        private System.Windows.Forms.NumericUpDown numOfMonths;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox gpFinancials;
    }
}

namespace UserControls
{
    partial class UCDetailsParameters
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
            this.chkNumOfTrans = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.cboTimeFrame = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkNumOfTrans
            // 
            this.chkNumOfTrans.AutoSize = true;
            this.chkNumOfTrans.Location = new System.Drawing.Point(4, 53);
            this.chkNumOfTrans.Name = "chkNumOfTrans";
            this.chkNumOfTrans.Size = new System.Drawing.Size(173, 13);
            this.chkNumOfTrans.TabIndex = 4;
            this.chkNumOfTrans.Text = "Show # of Waste Transactions";
            this.chkNumOfTrans.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Select Aggregate Period:";
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
            this.cbPeriod.Location = new System.Drawing.Point(126, 34);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(120, 21);
            this.cbPeriod.TabIndex = 3;
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
            this.cboTimeFrame.Location = new System.Drawing.Point(78, 12);
            this.cboTimeFrame.Name = "cboTimeFrame";
            this.cboTimeFrame.Size = new System.Drawing.Size(168, 21);
            this.cboTimeFrame.TabIndex = 2;
            this.cboTimeFrame.SelectedIndexChanged += new System.EventHandler(this.cboTimeFrame_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Time Frame:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTimeFrame);
            this.groupBox1.Controls.Add(this.cbPeriod);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkNumOfTrans);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 73);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Parameters";
            // 
            // UCDetailsParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCDetailsParameters";
            this.Size = new System.Drawing.Size(257, 76);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkNumOfTrans;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.ComboBox cboTimeFrame;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

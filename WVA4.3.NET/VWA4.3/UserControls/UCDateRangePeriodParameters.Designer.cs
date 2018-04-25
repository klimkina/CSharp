namespace UserControls
{
    partial class UCDateRangePeriodParameters
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
            this.cbCompareWeek = new System.Windows.Forms.ComboBox();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbCompareWeek
            // 
            this.cbCompareWeek.FormattingEnabled = true;
            this.cbCompareWeek.Items.AddRange(new object[] {
            "User Select",
            "Week",
            "2 Weeks",
            "3 Weeks",
            "4 Weeks",
            "Month",
            "2 Months",
            "3 Months"});
            this.cbCompareWeek.Location = new System.Drawing.Point(4, 24);
            this.cbCompareWeek.Name = "cbCompareWeek";
            this.cbCompareWeek.Size = new System.Drawing.Size(91, 21);
            this.cbCompareWeek.TabIndex = 5;
            this.cbCompareWeek.SelectedIndexChanged += new System.EventHandler(this.cbCompareWeek_SelectedIndexChanged);
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(99, 25);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(200, 20);
            this.dateEnd.TabIndex = 3;
            this.dateEnd.ValueChanged += new System.EventHandler(this.dateEnd_ValueChanged);
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(99, 0);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(200, 20);
            this.dateStart.TabIndex = 2;
            this.dateStart.ValueChanged += new System.EventHandler(this.dateStart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start Date:";
            // 
            // UCDateRangePeriodParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCompareWeek);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.dateEnd);
            this.Name = "UCDateRangePeriodParameters";
            this.Size = new System.Drawing.Size(303, 46);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCompareWeek;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label label1;
    }
}

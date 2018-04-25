namespace UserControls
{
    partial class UCTabularParameters
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
            this.chkDaypart = new System.Windows.Forms.CheckBox();
            this.chkStation = new System.Windows.Forms.CheckBox();
            this.chkDisposition = new System.Windows.Forms.CheckBox();
            this.cbGroupBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkDaypart
            // 
            this.chkDaypart.AutoSize = true;
            this.chkDaypart.Location = new System.Drawing.Point(3, 2);
            this.chkDaypart.Name = "chkDaypart";
            this.chkDaypart.Size = new System.Drawing.Size(63, 17);
            this.chkDaypart.TabIndex = 2;
            this.chkDaypart.Text = "Daypart";
            this.chkDaypart.UseVisualStyleBackColor = true;
            // 
            // chkStation
            // 
            this.chkStation.AutoSize = true;
            this.chkStation.Location = new System.Drawing.Point(3, 20);
            this.chkStation.Name = "chkStation";
            this.chkStation.Size = new System.Drawing.Size(59, 17);
            this.chkStation.TabIndex = 3;
            this.chkStation.Text = "Station";
            this.chkStation.UseVisualStyleBackColor = true;
            // 
            // chkDisposition
            // 
            this.chkDisposition.AutoSize = true;
            this.chkDisposition.Location = new System.Drawing.Point(3, 38);
            this.chkDisposition.Name = "chkDisposition";
            this.chkDisposition.Size = new System.Drawing.Size(77, 17);
            this.chkDisposition.TabIndex = 4;
            this.chkDisposition.Text = "Disposition";
            this.chkDisposition.UseVisualStyleBackColor = true;
            // 
            // cbGroupBy
            // 
            this.cbGroupBy.FormattingEnabled = true;
            this.cbGroupBy.Items.AddRange(new object[] {
            "Day",
            "Week",
            "Month"});
            this.cbGroupBy.Location = new System.Drawing.Point(64, 61);
            this.cbGroupBy.Name = "cbGroupBy";
            this.cbGroupBy.Size = new System.Drawing.Size(89, 21);
            this.cbGroupBy.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Group By:";
            // 
            // UCTabularParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbGroupBy);
            this.Controls.Add(this.chkDisposition);
            this.Controls.Add(this.chkStation);
            this.Controls.Add(this.chkDaypart);
            this.Name = "UCTabularParameters";
            this.Size = new System.Drawing.Size(156, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDaypart;
        private System.Windows.Forms.CheckBox chkStation;
        private System.Windows.Forms.CheckBox chkDisposition;
        private System.Windows.Forms.ComboBox cbGroupBy;
        private System.Windows.Forms.Label label1;
    }
}

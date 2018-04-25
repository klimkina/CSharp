﻿namespace UserControls
{
    partial class UCWasteAvoidanceParameters
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
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPounds = new System.Windows.Forms.RadioButton();
            this.chkDollars = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPeriod
            // 
            this.cbPeriod.FormattingEnabled = true;
            this.cbPeriod.Items.AddRange(new object[] {
            "Week",
            "Month",
            "Quarter",
            "Year"});
            this.cbPeriod.Location = new System.Drawing.Point(95, 2);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(122, 21);
            this.cbPeriod.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Aggregate Period:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Display:";
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.chkPounds);
            this.groupBox1.Controls.Add(this.chkDollars);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(87, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 38);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // chkPounds
            // 
            this.chkPounds.AutoSize = true;
            this.chkPounds.Location = new System.Drawing.Point(59, 15);
            this.chkPounds.Name = "chkPounds";
            this.chkPounds.Size = new System.Drawing.Size(61, 17);
            this.chkPounds.TabIndex = 1;
            this.chkPounds.TabStop = true;
            this.chkPounds.Text = "Pounds";
            this.chkPounds.UseVisualStyleBackColor = true;
            // 
            // chkDollars
            // 
            this.chkDollars.AutoSize = true;
            this.chkDollars.Location = new System.Drawing.Point(6, 15);
            this.chkDollars.Name = "chkDollars";
            this.chkDollars.Size = new System.Drawing.Size(57, 17);
            this.chkDollars.TabIndex = 0;
            this.chkDollars.TabStop = true;
            this.chkDollars.Text = "Dollars";
            this.chkDollars.UseVisualStyleBackColor = true;
            // 
            // UCWasteAvoidanceParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPeriod);
            this.Name = "UCWasteAvoidanceParameters";
            this.Size = new System.Drawing.Size(220, 72);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton chkPounds;
        private System.Windows.Forms.RadioButton chkDollars;

    }
}

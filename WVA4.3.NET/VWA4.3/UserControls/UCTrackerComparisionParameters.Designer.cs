namespace UserControls
{
    partial class UCTrackerComparisionParameters
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
            this.gpTrendParameters = new System.Windows.Forms.GroupBox();
            this.chkNumOfTrans = new System.Windows.Forms.CheckBox();
            this.gpTrendParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpTrendParameters
            // 
            this.gpTrendParameters.Controls.Add(this.chkNumOfTrans);
            this.gpTrendParameters.Location = new System.Drawing.Point(3, 0);
            this.gpTrendParameters.Name = "gpTrendParameters";
            this.gpTrendParameters.Size = new System.Drawing.Size(182, 49);
            this.gpTrendParameters.TabIndex = 60;
            this.gpTrendParameters.TabStop = false;
            this.gpTrendParameters.Text = "Report Parameters:";
            // 
            // chkNumOfTrans
            // 
            this.chkNumOfTrans.AutoSize = true;
            this.chkNumOfTrans.Location = new System.Drawing.Point(5, 19);
            this.chkNumOfTrans.Name = "chkNumOfTrans";
            this.chkNumOfTrans.Size = new System.Drawing.Size(109, 17);
            this.chkNumOfTrans.TabIndex = 11;
            this.chkNumOfTrans.Text = "# of Transactions";
            this.chkNumOfTrans.UseVisualStyleBackColor = true;
            // 
            // UCTrackerComparisionParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpTrendParameters);
            this.Name = "UCTrackerComparisionParameters";
            this.Size = new System.Drawing.Size(191, 49);
            this.gpTrendParameters.ResumeLayout(false);
            this.gpTrendParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpTrendParameters;
        private System.Windows.Forms.CheckBox chkNumOfTrans;
    }
}

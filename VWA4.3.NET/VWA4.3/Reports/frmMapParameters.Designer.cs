namespace Reports
{
    partial class frmMapParameters
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
			this.ucMapParameters1 = new Reports.UCMapParameters();
			this.SuspendLayout();
			// 
			// ucMapParameters1
			// 
			this.ucMapParameters1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucMapParameters1.Location = new System.Drawing.Point(0, 0);
			this.ucMapParameters1.Name = "ucMapParameters1";
			this.ucMapParameters1.Size = new System.Drawing.Size(706, 115);
			this.ucMapParameters1.TabIndex = 0;
			// 
			// frmMapParameters
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(706, 115);
			this.Controls.Add(this.ucMapParameters1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::Reports.Properties.Resources.VW_appicon;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMapParameters";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmMapParameters";
			this.ResumeLayout(false);

        }

        #endregion

        private UCMapParameters ucMapParameters1;
    }
}
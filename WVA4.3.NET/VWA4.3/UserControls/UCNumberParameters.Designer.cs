namespace UserControls
{
    partial class UCNumberParameters
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
            this.numShown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numShown)).BeginInit();
            this.SuspendLayout();
            // 
            // numShown
            // 
            this.numShown.Location = new System.Drawing.Point(135, 1);
            this.numShown.Name = "numShown";
            this.numShown.Size = new System.Drawing.Size(92, 20);
            this.numShown.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Items Shown: ";
            // 
            // UCNumberParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numShown);
            this.Controls.Add(this.label1);
            this.Name = "UCNumberParameters";
            this.Size = new System.Drawing.Size(232, 21);
            ((System.ComponentModel.ISupportInitialize)(this.numShown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numShown;
        private System.Windows.Forms.Label label1;
    }
}

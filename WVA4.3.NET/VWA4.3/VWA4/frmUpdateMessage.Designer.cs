namespace VWA4
{
    partial class frmUpdateMessage
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
            this.brwMessage = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // brwMessage
            // 
            this.brwMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brwMessage.Location = new System.Drawing.Point(0, 0);
            this.brwMessage.MinimumSize = new System.Drawing.Size(20, 20);
            this.brwMessage.Name = "brwMessage";
            this.brwMessage.Size = new System.Drawing.Size(610, 415);
            this.brwMessage.TabIndex = 0;
            // 
            // frmUpdateMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 415);
            this.Controls.Add(this.brwMessage);
            this.Name = "frmUpdateMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message";
            this.Load += new System.EventHandler(this.frmUpdateMessage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser brwMessage;
    }
}
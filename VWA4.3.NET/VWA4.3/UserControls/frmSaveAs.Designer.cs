namespace UserControls
{
    partial class frmSaveAs
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pIcon = new System.Windows.Forms.PictureBox();
            this.pButtons = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pLabel = new System.Windows.Forms.Panel();
            this.pPicture = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pIcon)).BeginInit();
            this.pButtons.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pLabel.SuspendLayout();
            this.pPicture.SuspendLayout();
            this.SuspendLayout();
            // Icon
            this.Icon = (System.Drawing.Icon.FromHandle(Properties.Resources.VW_appicon.GetHicon()));
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(127, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "button1";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(206, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "button2";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pIcon
            // 
            this.pIcon.Location = new System.Drawing.Point(4, 4);
            this.pIcon.Name = "pIcon";
            this.pIcon.Size = new System.Drawing.Size(52, 50);
            this.pIcon.TabIndex = 3;
            this.pIcon.TabStop = false;
            this.pIcon.Paint += new System.Windows.Forms.PaintEventHandler(this.pIcon_Paint);
            // 
            // pButtons
            // 
            this.pButtons.Controls.Add(this.btnCancel);
            this.pButtons.Controls.Add(this.btnOk);
            this.pButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButtons.Location = new System.Drawing.Point(0, 68);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(284, 29);
            this.pButtons.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.pLabel);
            this.panel2.Controls.Add(this.pPicture);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 68);
            this.panel2.TabIndex = 5;
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Controls.Add(this.lblMessage);
            this.pLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLabel.Location = new System.Drawing.Point(59, 0);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(225, 68);
            this.pLabel.TabIndex = 1;
            // 
            // pPicture
            // 
            this.pPicture.AutoSize = true;
            this.pPicture.Controls.Add(this.pIcon);
            this.pPicture.Dock = System.Windows.Forms.DockStyle.Left;
            this.pPicture.Location = new System.Drawing.Point(0, 0);
            this.pPicture.Name = "pPicture";
            this.pPicture.Size = new System.Drawing.Size(59, 68);
            this.pPicture.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Multiline = true;
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.ReadOnly = true;
            this.lblMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lblMessage.Size = new System.Drawing.Size(225, 68);
            this.lblMessage.TabIndex = 3;
            // 
            // frmSaveAs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 97);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pButtons);
            this.Name = "frmSaveAs";
            this.Text = "frmSaveAs";
            ((System.ComponentModel.ISupportInitialize)(this.pIcon)).EndInit();
            this.pButtons.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pLabel.ResumeLayout(false);
            this.pLabel.PerformLayout();
            this.pPicture.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pIcon;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pLabel;
        private System.Windows.Forms.Panel pPicture;
        private System.Windows.Forms.TextBox lblMessage;
    }
}
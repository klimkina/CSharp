namespace VWA4Common
{
    partial class frmEnterActivationCode
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
            this.txtActivationCode4 = new System.Windows.Forms.TextBox();
            this.txtActivationCode3 = new System.Windows.Forms.TextBox();
            this.txtActivationCode2 = new System.Windows.Forms.TextBox();
            this.txtActivationCode1 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCPUID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtActivationCode4
            // 
            this.txtActivationCode4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActivationCode4.Location = new System.Drawing.Point(300, 35);
            this.txtActivationCode4.MaxLength = 4;
            this.txtActivationCode4.Name = "txtActivationCode4";
            this.txtActivationCode4.Size = new System.Drawing.Size(46, 20);
            this.txtActivationCode4.TabIndex = 19;
            this.txtActivationCode4.Text = "....";
            // 
            // txtActivationCode3
            // 
            this.txtActivationCode3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActivationCode3.Location = new System.Drawing.Point(250, 35);
            this.txtActivationCode3.MaxLength = 4;
            this.txtActivationCode3.Name = "txtActivationCode3";
            this.txtActivationCode3.Size = new System.Drawing.Size(46, 20);
            this.txtActivationCode3.TabIndex = 18;
            this.txtActivationCode3.Text = "....";
            // 
            // txtActivationCode2
            // 
            this.txtActivationCode2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActivationCode2.Location = new System.Drawing.Point(200, 35);
            this.txtActivationCode2.MaxLength = 4;
            this.txtActivationCode2.Name = "txtActivationCode2";
            this.txtActivationCode2.Size = new System.Drawing.Size(46, 20);
            this.txtActivationCode2.TabIndex = 17;
            this.txtActivationCode2.Text = "....";
            // 
            // txtActivationCode1
            // 
            this.txtActivationCode1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActivationCode1.Location = new System.Drawing.Point(150, 35);
            this.txtActivationCode1.MaxLength = 4;
            this.txtActivationCode1.Name = "txtActivationCode1";
            this.txtActivationCode1.Size = new System.Drawing.Size(46, 20);
            this.txtActivationCode1.TabIndex = 16;
            this.txtActivationCode1.Text = "....";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(270, 61);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(189, 61);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Activation Code: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(41, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Your CPU ID:";
            // 
            // lblCPUID
            // 
            this.lblCPUID.AutoSize = true;
            this.lblCPUID.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCPUID.Location = new System.Drawing.Point(150, 12);
            this.lblCPUID.Name = "lblCPUID";
            this.lblCPUID.Size = new System.Drawing.Size(57, 18);
            this.lblCPUID.TabIndex = 21;
            this.lblCPUID.Text = "CPI ID";
            // 
            // frmEnterActivationCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 105);
            this.Controls.Add(this.lblCPUID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtActivationCode4);
            this.Controls.Add(this.txtActivationCode3);
            this.Controls.Add(this.txtActivationCode2);
            this.Controls.Add(this.txtActivationCode1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Name = "frmEnterActivationCode";
            this.Text = "Enter Activation Code";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtActivationCode4;
        private System.Windows.Forms.TextBox txtActivationCode3;
        private System.Windows.Forms.TextBox txtActivationCode2;
        private System.Windows.Forms.TextBox txtActivationCode1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCPUID;
    }
}
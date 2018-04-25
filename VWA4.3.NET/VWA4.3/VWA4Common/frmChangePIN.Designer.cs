namespace VWA4Common
{
    partial class frmChangePIN
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.passField = new System.Windows.Forms.TextBox();
			this.confirmField = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.entropyStatus = new System.Windows.Forms.Label();
			this.okBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.oldPIN = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbUser = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
            // Icon
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(8, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(264, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please enter an old password:";
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(8, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(264, 40);
			this.label2.TabIndex = 1;
			this.label2.Text = "It is recommended that you enter a strong password by using a combination of A-Z," +
				" a-z, 0-9, and punctuation marks.";
			// 
			// label3
			// 
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Location = new System.Drawing.Point(4, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "New password:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// passField
			// 
			this.passField.Location = new System.Drawing.Point(93, 112);
			this.passField.MaxLength = 32;
			this.passField.Name = "passField";
			this.passField.PasswordChar = '*';
			this.passField.Size = new System.Drawing.Size(176, 20);
			this.passField.TabIndex = 1;
			this.passField.TextChanged += new System.EventHandler(this.passField_TextChanged);
			// 
			// confirmField
			// 
			this.confirmField.Location = new System.Drawing.Point(93, 136);
			this.confirmField.MaxLength = 32;
			this.confirmField.Name = "confirmField";
			this.confirmField.PasswordChar = '*';
			this.confirmField.Size = new System.Drawing.Size(176, 20);
			this.confirmField.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label4.Location = new System.Drawing.Point(4, 139);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(87, 17);
			this.label4.TabIndex = 4;
			this.label4.Text = "Confirm password:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// entropyStatus
			// 
			this.entropyStatus.Location = new System.Drawing.Point(8, 168);
			this.entropyStatus.Name = "entropyStatus";
			this.entropyStatus.Size = new System.Drawing.Size(261, 32);
			this.entropyStatus.TabIndex = 6;
			this.entropyStatus.Text = "Waiting for password entry...";
			// 
			// okBtn
			// 
			this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.okBtn.Location = new System.Drawing.Point(114, 200);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 3;
			this.okBtn.Text = "OK";
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cancelBtn.Location = new System.Drawing.Point(194, 200);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 4;
			this.cancelBtn.Text = "Cancel";
			// 
			// oldPIN
			// 
			this.oldPIN.Location = new System.Drawing.Point(93, 46);
			this.oldPIN.MaxLength = 32;
			this.oldPIN.Name = "oldPIN";
			this.oldPIN.PasswordChar = '*';
			this.oldPIN.Size = new System.Drawing.Size(176, 20);
			this.oldPIN.TabIndex = 0;
			// 
			// label6
			// 
			this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label6.Location = new System.Drawing.Point(18, 47);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(73, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Old password:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// cmbUser
			// 
			this.cmbUser.FormattingEnabled = true;
			this.cmbUser.Items.AddRange(new object[] {
            "Manager",
            "Administrator"});
			this.cmbUser.Location = new System.Drawing.Point(93, 6);
			this.cmbUser.Name = "cmbUser";
			this.cmbUser.Size = new System.Drawing.Size(176, 21);
			this.cmbUser.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(26, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Select User:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// frmChangePIN
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(274, 227);
			this.Controls.Add(this.cmbUser);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.oldPIN);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.entropyStatus);
			this.Controls.Add(this.confirmField);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.passField);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmChangePIN";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Please Change a password";
			this.Load += new System.EventHandler(this.passwordDlg_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label entropyStatus;
        private System.Windows.Forms.TextBox confirmField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.TextBox textBox1;
        //private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox oldPIN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label label5;
    }
}
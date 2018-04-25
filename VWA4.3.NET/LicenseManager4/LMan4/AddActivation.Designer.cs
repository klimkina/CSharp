namespace LMan4
{
	partial class AddActivation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddActivation));
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.bCopyCPUIDtoClipboard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCPUID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblActivationCode = new System.Windows.Forms.Label();
            this.lblLicenseSerialNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bCopyActivationIDtoClipboard = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnActivationCode = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblExpirationsWarningsMode = new System.Windows.Forms.Label();
            this.lblExpirationWarningsFrequency = new System.Windows.Forms.Label();
            this.lblExpirationWarningsStartDate = new System.Windows.Forms.Label();
            this.lblExpirationDateBase = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGenerateActivatedLicense = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.chkIsEnabled = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddMonth = new System.Windows.Forms.Button();
            this.btnAddThreeMonths = new System.Windows.Forms.Button();
            this.btnAddSixMonths = new System.Windows.Forms.Button();
            this.btnAddTwelveMonths = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtExtendedExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox14.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Activation Code:";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.bCopyCPUIDtoClipboard);
            this.groupBox14.Controls.Add(this.label1);
            this.groupBox14.Controls.Add(this.txtCPUID);
            this.groupBox14.Location = new System.Drawing.Point(26, 214);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(425, 94);
            this.groupBox14.TabIndex = 15;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Hardware Info";
            // 
            // bCopyCPUIDtoClipboard
            // 
            this.bCopyCPUIDtoClipboard.Location = new System.Drawing.Point(107, 65);
            this.bCopyCPUIDtoClipboard.Name = "bCopyCPUIDtoClipboard";
            this.bCopyCPUIDtoClipboard.Size = new System.Drawing.Size(177, 23);
            this.bCopyCPUIDtoClipboard.TabIndex = 19;
            this.bCopyCPUIDtoClipboard.Text = "Copy CPU ID  to Clipboard";
            this.bCopyCPUIDtoClipboard.UseVisualStyleBackColor = true;
            this.bCopyCPUIDtoClipboard.Click += new System.EventHandler(this.bCopyCPUIDtoClipboard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "CPU ID:";
            // 
            // txtCPUID
            // 
            this.txtCPUID.Location = new System.Drawing.Point(74, 34);
            this.txtCPUID.MaxLength = 64;
            this.txtCPUID.Name = "txtCPUID";
            this.txtCPUID.Size = new System.Drawing.Size(294, 20);
            this.txtCPUID.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(43, 230);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(365, 22);
            this.label13.TabIndex = 11;
            this.label13.Text = "Enter CPU ID (or leave blank to allow Internet Activation with any CPU)";
            // 
            // lblActivationCode
            // 
            this.lblActivationCode.AutoSize = true;
            this.lblActivationCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivationCode.Location = new System.Drawing.Point(105, 38);
            this.lblActivationCode.Name = "lblActivationCode";
            this.lblActivationCode.Size = new System.Drawing.Size(0, 15);
            this.lblActivationCode.TabIndex = 16;
            // 
            // lblLicenseSerialNumber
            // 
            this.lblLicenseSerialNumber.AutoSize = true;
            this.lblLicenseSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseSerialNumber.Location = new System.Drawing.Point(97, 7);
            this.lblLicenseSerialNumber.Name = "lblLicenseSerialNumber";
            this.lblLicenseSerialNumber.Size = new System.Drawing.Size(222, 15);
            this.lblLicenseSerialNumber.TabIndex = 18;
            this.lblLicenseSerialNumber.Text = "(License ID from License Record)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "License ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bCopyActivationIDtoClipboard);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblActivationCode);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(26, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 99);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Activation Data for Client CPU";
            // 
            // bCopyActivationIDtoClipboard
            // 
            this.bCopyActivationIDtoClipboard.Location = new System.Drawing.Point(107, 67);
            this.bCopyActivationIDtoClipboard.Name = "bCopyActivationIDtoClipboard";
            this.bCopyActivationIDtoClipboard.Size = new System.Drawing.Size(177, 23);
            this.bCopyActivationIDtoClipboard.TabIndex = 18;
            this.bCopyActivationIDtoClipboard.Text = "Copy Activation Code to Clipboard";
            this.bCopyActivationIDtoClipboard.UseVisualStyleBackColor = true;
            this.bCopyActivationIDtoClipboard.Click += new System.EventHandler(this.bCopyActivationIDtoClipboard_Click);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(17, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(294, 22);
            this.label5.TabIndex = 17;
            this.label5.Text = "Provide this to Client for Activating License on target CPU";
            // 
            // btnActivationCode
            // 
            this.btnActivationCode.Location = new System.Drawing.Point(26, 427);
            this.btnActivationCode.Name = "btnActivationCode";
            this.btnActivationCode.Size = new System.Drawing.Size(126, 23);
            this.btnActivationCode.TabIndex = 21;
            this.btnActivationCode.Text = "Generate Activation ID";
            this.btnActivationCode.UseVisualStyleBackColor = true;
            this.btnActivationCode.Click += new System.EventHandler(this.btnActivationCode_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Start Date:";
            // 
            // dtExpirationDate
            // 
            this.dtExpirationDate.Location = new System.Drawing.Point(159, 25);
            this.dtExpirationDate.Name = "dtExpirationDate";
            this.dtExpirationDate.Size = new System.Drawing.Size(235, 20);
            this.dtExpirationDate.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblExpirationsWarningsMode);
            this.groupBox3.Controls.Add(this.lblExpirationWarningsFrequency);
            this.groupBox3.Controls.Add(this.lblExpirationWarningsStartDate);
            this.groupBox3.Controls.Add(this.lblExpirationDateBase);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(26, 98);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 110);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Base License Expiration Date";
            // 
            // lblExpirationsWarningsMode
            // 
            this.lblExpirationsWarningsMode.AutoSize = true;
            this.lblExpirationsWarningsMode.Location = new System.Drawing.Point(199, 64);
            this.lblExpirationsWarningsMode.Name = "lblExpirationsWarningsMode";
            this.lblExpirationsWarningsMode.Size = new System.Drawing.Size(137, 13);
            this.lblExpirationsWarningsMode.TabIndex = 12;
            this.lblExpirationsWarningsMode.Text = "(Expiration Warnings Mode)";
            // 
            // lblExpirationWarningsFrequency
            // 
            this.lblExpirationWarningsFrequency.AutoSize = true;
            this.lblExpirationWarningsFrequency.Location = new System.Drawing.Point(199, 85);
            this.lblExpirationWarningsFrequency.Name = "lblExpirationWarningsFrequency";
            this.lblExpirationWarningsFrequency.Size = new System.Drawing.Size(160, 13);
            this.lblExpirationWarningsFrequency.TabIndex = 11;
            this.lblExpirationWarningsFrequency.Text = "(Expiration Warnings Frequency)";
            // 
            // lblExpirationWarningsStartDate
            // 
            this.lblExpirationWarningsStartDate.AutoSize = true;
            this.lblExpirationWarningsStartDate.Location = new System.Drawing.Point(199, 43);
            this.lblExpirationWarningsStartDate.Name = "lblExpirationWarningsStartDate";
            this.lblExpirationWarningsStartDate.Size = new System.Drawing.Size(158, 13);
            this.lblExpirationWarningsStartDate.TabIndex = 10;
            this.lblExpirationWarningsStartDate.Text = "(Expiration Warnings Start Date)";
            // 
            // lblExpirationDateBase
            // 
            this.lblExpirationDateBase.AutoSize = true;
            this.lblExpirationDateBase.Location = new System.Drawing.Point(199, 22);
            this.lblExpirationDateBase.Name = "lblExpirationDateBase";
            this.lblExpirationDateBase.Size = new System.Drawing.Size(157, 13);
            this.lblExpirationDateBase.TabIndex = 9;
            this.lblExpirationDateBase.Text = "(License Expiration Date (base))";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Expiration Warnings Mode:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Expiration Warnings Frequency:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(184, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Expiration Warnings Start Date (base)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "License Expiration Date (base)";
            // 
            // btnGenerateActivatedLicense
            // 
            this.btnGenerateActivatedLicense.Location = new System.Drawing.Point(159, 427);
            this.btnGenerateActivatedLicense.Name = "btnGenerateActivatedLicense";
            this.btnGenerateActivatedLicense.Size = new System.Drawing.Size(192, 23);
            this.btnGenerateActivatedLicense.TabIndex = 25;
            this.btnGenerateActivatedLicense.Text = "Generate Activated License File";
            this.btnGenerateActivatedLicense.UseVisualStyleBackColor = true;
            this.btnGenerateActivatedLicense.Click += new System.EventHandler(this.btnGenerateActivatedLicense_Click);
            // 
            // btnDone
            // 
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDone.Location = new System.Drawing.Point(438, 427);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 26;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // chkIsEnabled
            // 
            this.chkIsEnabled.AutoSize = true;
            this.chkIsEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsEnabled.Location = new System.Drawing.Point(416, 20);
            this.chkIsEnabled.Name = "chkIsEnabled";
            this.chkIsEnabled.Size = new System.Drawing.Size(223, 20);
            this.chkIsEnabled.TabIndex = 27;
            this.chkIsEnabled.Text = "This Activation record is Enabled";
            this.chkIsEnabled.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(413, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(209, 118);
            this.label17.TabIndex = 12;
            this.label17.Text = resources.GetString("label17.Text");
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(357, 427);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddMonth
            // 
            this.btnAddMonth.Location = new System.Drawing.Point(122, 72);
            this.btnAddMonth.Name = "btnAddMonth";
            this.btnAddMonth.Size = new System.Drawing.Size(66, 23);
            this.btnAddMonth.TabIndex = 29;
            this.btnAddMonth.Text = "1 Month";
            this.btnAddMonth.UseVisualStyleBackColor = true;
            this.btnAddMonth.Click += new System.EventHandler(this.btnAddMonth_Click);
            // 
            // btnAddThreeMonths
            // 
            this.btnAddThreeMonths.Location = new System.Drawing.Point(194, 72);
            this.btnAddThreeMonths.Name = "btnAddThreeMonths";
            this.btnAddThreeMonths.Size = new System.Drawing.Size(66, 23);
            this.btnAddThreeMonths.TabIndex = 30;
            this.btnAddThreeMonths.Text = "3 Months";
            this.btnAddThreeMonths.UseVisualStyleBackColor = true;
            this.btnAddThreeMonths.Click += new System.EventHandler(this.btnAddThreeMonths_Click);
            // 
            // btnAddSixMonths
            // 
            this.btnAddSixMonths.Location = new System.Drawing.Point(265, 72);
            this.btnAddSixMonths.Name = "btnAddSixMonths";
            this.btnAddSixMonths.Size = new System.Drawing.Size(66, 23);
            this.btnAddSixMonths.TabIndex = 31;
            this.btnAddSixMonths.Text = "6 Months";
            this.btnAddSixMonths.UseVisualStyleBackColor = true;
            this.btnAddSixMonths.Click += new System.EventHandler(this.btnAddSixMonths_Click);
            // 
            // btnAddTwelveMonths
            // 
            this.btnAddTwelveMonths.Location = new System.Drawing.Point(337, 72);
            this.btnAddTwelveMonths.Name = "btnAddTwelveMonths";
            this.btnAddTwelveMonths.Size = new System.Drawing.Size(66, 23);
            this.btnAddTwelveMonths.TabIndex = 32;
            this.btnAddTwelveMonths.Text = "12 Months";
            this.btnAddTwelveMonths.UseVisualStyleBackColor = true;
            this.btnAddTwelveMonths.Click += new System.EventHandler(this.btnAddTwelveMonths_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Add";
            // 
            // dtExtendedExpirationDate
            // 
            this.dtExtendedExpirationDate.Location = new System.Drawing.Point(159, 50);
            this.dtExtendedExpirationDate.Name = "dtExtendedExpirationDate";
            this.dtExtendedExpirationDate.Size = new System.Drawing.Size(235, 20);
            this.dtExtendedExpirationDate.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Extended Expiration Date:";
            // 
            // AddActivation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 500);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtExtendedExpirationDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddTwelveMonths);
            this.Controls.Add(this.btnAddSixMonths);
            this.Controls.Add(this.btnAddThreeMonths);
            this.Controls.Add(this.btnAddMonth);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.chkIsEnabled);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnGenerateActivatedLicense);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dtExpirationDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnActivationCode);
            this.Controls.Add(this.lblLicenseSerialNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddActivation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Activation Record";
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCPUID;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lblActivationCode;
		private System.Windows.Forms.Label lblLicenseSerialNumber;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnActivationCode;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dtExpirationDate;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lblExpirationsWarningsMode;
		private System.Windows.Forms.Label lblExpirationWarningsFrequency;
		private System.Windows.Forms.Label lblExpirationWarningsStartDate;
		private System.Windows.Forms.Label lblExpirationDateBase;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnGenerateActivatedLicense;
		private System.Windows.Forms.Button btnDone;
		private System.Windows.Forms.CheckBox chkIsEnabled;
		private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button bCopyCPUIDtoClipboard;
		private System.Windows.Forms.Button bCopyActivationIDtoClipboard;
        private System.Windows.Forms.Button btnAddMonth;
        private System.Windows.Forms.Button btnAddThreeMonths;
        private System.Windows.Forms.Button btnAddSixMonths;
        private System.Windows.Forms.Button btnAddTwelveMonths;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtExtendedExpirationDate;
        private System.Windows.Forms.Label label3;
	}
}
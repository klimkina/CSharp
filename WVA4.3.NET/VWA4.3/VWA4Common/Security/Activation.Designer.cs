namespace VWA4Common.Security
{
	partial class Activation
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Activation));
			this.lCPUID = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lLicenseID = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tActivationID = new System.Windows.Forms.TextBox();
			this.bActivatebyInternet = new System.Windows.Forms.Button();
			this.bActivateManually = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lCPUID
			// 
			this.lCPUID.AutoSize = true;
			this.lCPUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lCPUID.Location = new System.Drawing.Point(162, 84);
			this.lCPUID.Name = "lCPUID";
			this.lCPUID.Size = new System.Drawing.Size(52, 16);
			this.lCPUID.TabIndex = 0;
			this.lCPUID.Text = "lCPUID";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(28, 84);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "CPU ID of this PC:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(163, 103);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(102, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Copy to Clipboard";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.bCPUID_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(163, 50);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(102, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Copy to Clipboard";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(11, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(148, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Installed License ID:";
			// 
			// lLicenseID
			// 
			this.lLicenseID.AutoSize = true;
			this.lLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lLicenseID.Location = new System.Drawing.Point(162, 31);
			this.lLicenseID.Name = "lLicenseID";
			this.lLicenseID.Size = new System.Drawing.Size(71, 16);
			this.lLicenseID.TabIndex = 3;
			this.lLicenseID.Text = "lLicenseID";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 151);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Activation Code:";
			// 
			// tActivationID
			// 
			this.tActivationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tActivationID.Location = new System.Drawing.Point(139, 151);
			this.tActivationID.Name = "tActivationID";
			this.tActivationID.Size = new System.Drawing.Size(312, 22);
			this.tActivationID.TabIndex = 8;
			this.tActivationID.Text = "tActivationID";
			this.tActivationID.TextChanged += new System.EventHandler(this.tActivateManually_TextChanged);
			// 
			// bActivatebyInternet
			// 
			this.bActivatebyInternet.Location = new System.Drawing.Point(19, 217);
			this.bActivatebyInternet.Name = "bActivatebyInternet";
			this.bActivatebyInternet.Size = new System.Drawing.Size(112, 34);
			this.bActivatebyInternet.TabIndex = 9;
			this.bActivatebyInternet.Text = "Activate by Internet Now";
			this.bActivatebyInternet.UseVisualStyleBackColor = true;
			this.bActivatebyInternet.Click += new System.EventHandler(this.bActivatebyInternet_Click);
			// 
			// bActivateManually
			// 
			this.bActivateManually.Location = new System.Drawing.Point(153, 217);
			this.bActivateManually.Name = "bActivateManually";
			this.bActivateManually.Size = new System.Drawing.Size(112, 34);
			this.bActivateManually.TabIndex = 10;
			this.bActivateManually.Text = "Activate Manually Now";
			this.bActivateManually.UseVisualStyleBackColor = true;
			this.bActivateManually.Click += new System.EventHandler(this.bActivateManually_Click);
			// 
			// bCancel
			// 
			this.bCancel.Location = new System.Drawing.Point(335, 217);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(97, 34);
			this.bCancel.TabIndex = 11;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// Activation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(463, 274);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bActivateManually);
			this.Controls.Add(this.bActivatebyInternet);
			this.Controls.Add(this.tActivationID);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lLicenseID);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lCPUID);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Activation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Activate ValuWaste Advantage 4";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lCPUID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lLicenseID;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tActivationID;
		private System.Windows.Forms.Button bActivatebyInternet;
		private System.Windows.Forms.Button bActivateManually;
		private System.Windows.Forms.Button bCancel;
	}
}
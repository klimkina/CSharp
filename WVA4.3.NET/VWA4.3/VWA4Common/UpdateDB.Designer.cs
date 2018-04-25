namespace VWA4Common
{
	partial class UpdateDB
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDB));
			this.label1 = new System.Windows.Forms.Label();
			this.lDBPath = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lDBVersion = new System.Windows.Forms.Label();
			this.bUpgrade = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.bOpenDB = new System.Windows.Forms.Button();
			this.ckDET = new System.Windows.Forms.CheckBox();
			this.ckEachFormats = new System.Windows.Forms.CheckBox();
			this.ckForms = new System.Windows.Forms.CheckBox();
			this.bDone = new System.Windows.Forms.Button();
			this.ckBackup = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(29, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(146, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Database Selected:";
			// 
			// lDBPath
			// 
			this.lDBPath.Location = new System.Drawing.Point(39, 42);
			this.lDBPath.Name = "lDBPath";
			this.lDBPath.Size = new System.Drawing.Size(400, 45);
			this.lDBPath.TabIndex = 1;
			this.lDBPath.Text = "lDBPath";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(29, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Database Version:";
			// 
			// lDBVersion
			// 
			this.lDBVersion.AutoSize = true;
			this.lDBVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lDBVersion.Location = new System.Drawing.Point(172, 96);
			this.lDBVersion.Name = "lDBVersion";
			this.lDBVersion.Size = new System.Drawing.Size(76, 16);
			this.lDBVersion.TabIndex = 3;
			this.lDBVersion.Text = "lDBVersion";
			// 
			// bUpgrade
			// 
			this.bUpgrade.Location = new System.Drawing.Point(161, 202);
			this.bUpgrade.Name = "bUpgrade";
			this.bUpgrade.Size = new System.Drawing.Size(82, 40);
			this.bUpgrade.TabIndex = 4;
			this.bUpgrade.Text = "Upgrade Database";
			this.bUpgrade.UseVisualStyleBackColor = true;
			this.bUpgrade.Click += new System.EventHandler(this.bUpgrade_Click);
			// 
			// bCancel
			// 
			this.bCancel.Location = new System.Drawing.Point(267, 203);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(75, 40);
			this.bCancel.TabIndex = 5;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// bOpenDB
			// 
			this.bOpenDB.Location = new System.Drawing.Point(30, 202);
			this.bOpenDB.Name = "bOpenDB";
			this.bOpenDB.Size = new System.Drawing.Size(107, 40);
			this.bOpenDB.TabIndex = 6;
			this.bOpenDB.Text = "Select Different Database";
			this.bOpenDB.UseVisualStyleBackColor = true;
			this.bOpenDB.Click += new System.EventHandler(this.bOpenDB_Click);
			// 
			// ckDET
			// 
			this.ckDET.AutoSize = true;
			this.ckDET.Location = new System.Drawing.Point(34, 118);
			this.ckDET.Name = "ckDET";
			this.ckDET.Size = new System.Drawing.Size(345, 17);
			this.ckDET.TabIndex = 7;
			this.ckDET.Text = "Upgrade Data Entry Templates Table (clears all template definitions)";
			this.ckDET.UseVisualStyleBackColor = true;
			// 
			// ckEachFormats
			// 
			this.ckEachFormats.AutoSize = true;
			this.ckEachFormats.Location = new System.Drawing.Point(34, 137);
			this.ckEachFormats.Name = "ckEachFormats";
			this.ckEachFormats.Size = new System.Drawing.Size(328, 17);
			this.ckEachFormats.TabIndex = 8;
			this.ckEachFormats.Text = "Upgrade Each Formats Table (clears all Each Format definitions)";
			this.ckEachFormats.UseVisualStyleBackColor = true;
			// 
			// ckForms
			// 
			this.ckForms.AutoSize = true;
			this.ckForms.Location = new System.Drawing.Point(34, 156);
			this.ckForms.Name = "ckForms";
			this.ckForms.Size = new System.Drawing.Size(254, 17);
			this.ckForms.TabIndex = 9;
			this.ckForms.Text = "Upgrade Form Tables (clears all Form definitions)";
			this.ckForms.UseVisualStyleBackColor = true;
			// 
			// bDone
			// 
			this.bDone.Location = new System.Drawing.Point(366, 203);
			this.bDone.Name = "bDone";
			this.bDone.Size = new System.Drawing.Size(82, 40);
			this.bDone.TabIndex = 10;
			this.bDone.Text = "Done";
			this.bDone.UseVisualStyleBackColor = true;
			this.bDone.Click += new System.EventHandler(this.bDone_Click);
			// 
			// ckBackup
			// 
			this.ckBackup.AutoSize = true;
			this.ckBackup.Location = new System.Drawing.Point(34, 175);
			this.ckBackup.Name = "ckBackup";
			this.ckBackup.Size = new System.Drawing.Size(184, 17);
			this.ckBackup.TabIndex = 11;
			this.ckBackup.Text = "Create backup file (Name + \'.bak)";
			this.ckBackup.UseVisualStyleBackColor = true;
			// 
			// UpdateDB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(465, 255);
			this.Controls.Add(this.ckBackup);
			this.Controls.Add(this.bDone);
			this.Controls.Add(this.ckForms);
			this.Controls.Add(this.ckEachFormats);
			this.Controls.Add(this.ckDET);
			this.Controls.Add(this.bOpenDB);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bUpgrade);
			this.Controls.Add(this.lDBVersion);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lDBPath);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UpdateDB";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Upgrade Database";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lDBPath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lDBVersion;
		private System.Windows.Forms.Button bUpgrade;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.Button bOpenDB;
		private System.Windows.Forms.CheckBox ckDET;
		private System.Windows.Forms.CheckBox ckEachFormats;
		private System.Windows.Forms.CheckBox ckForms;
		private System.Windows.Forms.Button bDone;
		private System.Windows.Forms.CheckBox ckBackup;
	}
}
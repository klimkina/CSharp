namespace UserControls
{
	partial class frmAddNewTag
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bDone = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.pFormHdr = new System.Windows.Forms.Panel();
			this.lFormTitle = new System.Windows.Forms.Label();
			this.tTagName = new System.Windows.Forms.TextBox();
			this.tTagDescription = new System.Windows.Forms.TextBox();
			this.lTagName = new Infragistics.Win.Misc.UltraLabel();
			this.lTagDescription = new Infragistics.Win.Misc.UltraLabel();
			this.panel2.SuspendLayout();
			this.pFormHdr.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.bDone);
			this.panel2.Controls.Add(this.bCancel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 222);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(401, 51);
			this.panel2.TabIndex = 263;
			// 
			// bDone
			// 
			this.bDone.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bDone.BackColor = System.Drawing.Color.White;
			this.bDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bDone.Location = new System.Drawing.Point(224, 12);
			this.bDone.Name = "bDone";
			this.bDone.Size = new System.Drawing.Size(105, 29);
			this.bDone.TabIndex = 252;
			this.bDone.Text = "Save";
			this.bDone.UseVisualStyleBackColor = false;
			this.bDone.Click += new System.EventHandler(this.bDone_Click);
			// 
			// bCancel
			// 
			this.bCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bCancel.BackColor = System.Drawing.Color.White;
			this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bCancel.Location = new System.Drawing.Point(67, 12);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(105, 29);
			this.bCancel.TabIndex = 253;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = false;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// pFormHdr
			// 
			this.pFormHdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(174)))), ((int)(((byte)(65)))));
			this.pFormHdr.Controls.Add(this.lFormTitle);
			this.pFormHdr.Dock = System.Windows.Forms.DockStyle.Top;
			this.pFormHdr.Location = new System.Drawing.Point(0, 0);
			this.pFormHdr.Name = "pFormHdr";
			this.pFormHdr.Size = new System.Drawing.Size(401, 37);
			this.pFormHdr.TabIndex = 264;
			// 
			// lFormTitle
			// 
			this.lFormTitle.AutoSize = true;
			this.lFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFormTitle.Location = new System.Drawing.Point(4, 9);
			this.lFormTitle.Name = "lFormTitle";
			this.lFormTitle.Size = new System.Drawing.Size(115, 20);
			this.lFormTitle.TabIndex = 0;
			this.lFormTitle.Text = "Add New Tag";
			// 
			// tTagName
			// 
			this.tTagName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tTagName.Location = new System.Drawing.Point(38, 76);
			this.tTagName.Name = "tTagName";
			this.tTagName.Size = new System.Drawing.Size(315, 20);
			this.tTagName.TabIndex = 265;
			this.tTagName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tTagName_KeyPress);
			// 
			// tTagDescription
			// 
			this.tTagDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tTagDescription.Location = new System.Drawing.Point(38, 133);
			this.tTagDescription.Multiline = true;
			this.tTagDescription.Name = "tTagDescription";
			this.tTagDescription.Size = new System.Drawing.Size(315, 62);
			this.tTagDescription.TabIndex = 266;
			// 
			// lTagName
			// 
			appearance1.FontData.BoldAsString = "True";
			appearance1.TextHAlignAsString = "Left";
			appearance1.TextVAlignAsString = "Middle";
			this.lTagName.Appearance = appearance1;
			this.lTagName.AutoSize = true;
			this.lTagName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lTagName.Location = new System.Drawing.Point(26, 48);
			this.lTagName.Name = "lTagName";
			this.lTagName.Size = new System.Drawing.Size(90, 21);
			this.lTagName.TabIndex = 267;
			this.lTagName.Text = "Tag Name:";
			// 
			// lTagDescription
			// 
			appearance2.FontData.BoldAsString = "True";
			appearance2.TextHAlignAsString = "Left";
			appearance2.TextVAlignAsString = "Middle";
			this.lTagDescription.Appearance = appearance2;
			this.lTagDescription.AutoSize = true;
			this.lTagDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lTagDescription.Location = new System.Drawing.Point(27, 103);
			this.lTagDescription.Name = "lTagDescription";
			this.lTagDescription.Size = new System.Drawing.Size(131, 21);
			this.lTagDescription.TabIndex = 268;
			this.lTagDescription.Text = "Tag Description:";
			// 
			// frmAddNewTag
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 273);
			this.Controls.Add(this.lTagDescription);
			this.Controls.Add(this.lTagName);
			this.Controls.Add(this.tTagDescription);
			this.Controls.Add(this.tTagName);
			this.Controls.Add(this.pFormHdr);
			this.Controls.Add(this.panel2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAddNewTag";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add New Tag";
			this.panel2.ResumeLayout(false);
			this.pFormHdr.ResumeLayout(false);
			this.pFormHdr.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button bDone;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.Panel pFormHdr;
		private System.Windows.Forms.Label lFormTitle;
		private System.Windows.Forms.TextBox tTagName;
		private System.Windows.Forms.TextBox tTagDescription;
		private Infragistics.Win.Misc.UltraLabel lTagName;
		private Infragistics.Win.Misc.UltraLabel lTagDescription;
	}
}
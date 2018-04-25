namespace UserControls
{
	partial class frmEventOrderPicker
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventOrderPicker));
			this.ucTreeView1 = new UserControls.UCTreeView();
			this.pFormHdr = new System.Windows.Forms.Panel();
			this.lFormTitle = new Infragistics.Win.Misc.UltraLabel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bCancel = new System.Windows.Forms.Button();
			this.pFormHdr.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ucTreeView1
			// 
			this.ucTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucTreeView1.EnableCheckboxes = false;
			this.ucTreeView1.ID = "";
			this.ucTreeView1.Location = new System.Drawing.Point(0, 34);
			this.ucTreeView1.Name = "ucTreeView1";
			this.ucTreeView1.ShowAllNames = false;
			this.ucTreeView1.ShowBEONumber = true;
			this.ucTreeView1.ShowDisabled = false;
			this.ucTreeView1.ShowPrice = false;
			this.ucTreeView1.Size = new System.Drawing.Size(492, 435);
			this.ucTreeView1.TabIndex = 127;
			this.ucTreeView1.TypeCatalogID = "0";
			this.ucTreeView1.TypeName = "";
			this.ucTreeView1.Visible = false;
			this.ucTreeView1.TreeViewIDChanged += new UserControls.UCTreeView.TreeViewIDChangedEventHandler(this.ucTreeView1_TreeViewIDChanged);
			// 
			// pFormHdr
			// 
			this.pFormHdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(174)))), ((int)(((byte)(65)))));
			this.pFormHdr.Controls.Add(this.lFormTitle);
			this.pFormHdr.Dock = System.Windows.Forms.DockStyle.Top;
			this.pFormHdr.Location = new System.Drawing.Point(0, 0);
			this.pFormHdr.Name = "pFormHdr";
			this.pFormHdr.Size = new System.Drawing.Size(492, 34);
			this.pFormHdr.TabIndex = 243;
			// 
			// lFormTitle
			// 
			appearance1.FontData.BoldAsString = "True";
			appearance1.TextHAlignAsString = "Left";
			appearance1.TextVAlignAsString = "Middle";
			this.lFormTitle.Appearance = appearance1;
			this.lFormTitle.AutoSize = true;
			this.lFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFormTitle.Location = new System.Drawing.Point(12, 7);
			this.lFormTitle.Name = "lFormTitle";
			this.lFormTitle.Size = new System.Drawing.Size(83, 21);
			this.lFormTitle.TabIndex = 214;
			this.lFormTitle.Text = "lFormTitle";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.bCancel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 469);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(492, 52);
			this.panel2.TabIndex = 244;
			// 
			// bCancel
			// 
			this.bCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bCancel.BackColor = System.Drawing.Color.White;
			this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bCancel.Location = new System.Drawing.Point(356, 11);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(105, 29);
			this.bCancel.TabIndex = 254;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = false;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// frmEventOrderPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(492, 521);
			this.Controls.Add(this.ucTreeView1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.pFormHdr);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmEventOrderPicker";
			this.Text = "Event Orders";
			this.pFormHdr.ResumeLayout(false);
			this.pFormHdr.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private UCTreeView ucTreeView1;
		private System.Windows.Forms.Panel pFormHdr;
		private Infragistics.Win.Misc.UltraLabel lFormTitle;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button bCancel;
	}
}
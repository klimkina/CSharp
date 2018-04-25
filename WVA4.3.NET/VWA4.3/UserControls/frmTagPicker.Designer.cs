namespace UserControls
{
	partial class frmTagPicker
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
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTagPicker));
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			this.ulvTagList = new Infragistics.Win.UltraWinListView.UltraListView();
			this.pFormHdr = new System.Windows.Forms.Panel();
			this.lFormTitle = new Infragistics.Win.Misc.UltraLabel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bCancel = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.ulvTagList)).BeginInit();
			this.pFormHdr.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ulvTagList
			// 
			this.ulvTagList.Dock = System.Windows.Forms.DockStyle.Fill;
			appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
			this.ulvTagList.ItemSettings.Appearance = appearance5;
			this.ulvTagList.Location = new System.Drawing.Point(0, 34);
			this.ulvTagList.Name = "ulvTagList";
			this.ulvTagList.Size = new System.Drawing.Size(389, 392);
			this.ulvTagList.TabIndex = 257;
			this.ulvTagList.Text = "ultraListView1";
			this.ulvTagList.ItemSelectionChanged += new Infragistics.Win.UltraWinListView.ItemSelectionChangedEventHandler(this.ulvTagList_ItemSelectionChanged);
			// 
			// pFormHdr
			// 
			this.pFormHdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(174)))), ((int)(((byte)(65)))));
			this.pFormHdr.Controls.Add(this.lFormTitle);
			this.pFormHdr.Dock = System.Windows.Forms.DockStyle.Top;
			this.pFormHdr.Location = new System.Drawing.Point(0, 0);
			this.pFormHdr.Name = "pFormHdr";
			this.pFormHdr.Size = new System.Drawing.Size(389, 34);
			this.pFormHdr.TabIndex = 258;
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
			this.lFormTitle.Size = new System.Drawing.Size(48, 21);
			this.lFormTitle.TabIndex = 214;
			this.lFormTitle.Text = "lType";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.bCancel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 426);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(389, 52);
			this.panel2.TabIndex = 259;
			// 
			// bCancel
			// 
			this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bCancel.BackColor = System.Drawing.Color.White;
			this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bCancel.Location = new System.Drawing.Point(259, 11);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(105, 29);
			this.bCancel.TabIndex = 254;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = false;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "pin_yellow.ico");
			this.imageList1.Images.SetKeyName(1, "pin_red.ico");
			// 
			// frmTagPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(389, 478);
			this.Controls.Add(this.ulvTagList);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.pFormHdr);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmTagPicker";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Choose Tag";
			((System.ComponentModel.ISupportInitialize)(this.ulvTagList)).EndInit();
			this.pFormHdr.ResumeLayout(false);
			this.pFormHdr.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Infragistics.Win.UltraWinListView.UltraListView ulvTagList;
		private System.Windows.Forms.Panel pFormHdr;
		private Infragistics.Win.Misc.UltraLabel lFormTitle;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.ImageList imageList1;
	}
}
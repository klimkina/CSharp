namespace UserControls
{
	partial class frmTransactionViewer
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
			Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransactionViewer));
			this.pFormHdr = new System.Windows.Forms.Panel();
			this.lFormTitle = new Infragistics.Win.Misc.UltraLabel();
			this.bClose = new Infragistics.Win.Misc.UltraButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.ucTransactionViewer0 = new UserControls.UCTransactionViewer();
			this.pFormHdr.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pFormHdr
			// 
			this.pFormHdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(174)))), ((int)(((byte)(65)))));
			this.pFormHdr.Controls.Add(this.lFormTitle);
			this.pFormHdr.Dock = System.Windows.Forms.DockStyle.Top;
			this.pFormHdr.Location = new System.Drawing.Point(0, 0);
			this.pFormHdr.Name = "pFormHdr";
			this.pFormHdr.Size = new System.Drawing.Size(637, 39);
			this.pFormHdr.TabIndex = 241;
			// 
			// lFormTitle
			// 
			appearance18.FontData.BoldAsString = "True";
			appearance18.TextHAlignAsString = "Left";
			appearance18.TextVAlignAsString = "Middle";
			this.lFormTitle.Appearance = appearance18;
			this.lFormTitle.AutoSize = true;
			this.lFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFormTitle.Location = new System.Drawing.Point(4, 9);
			this.lFormTitle.Name = "lFormTitle";
			this.lFormTitle.Size = new System.Drawing.Size(190, 21);
			this.lFormTitle.TabIndex = 214;
			this.lFormTitle.Text = "View Waste Transaction";
			// 
			// bClose
			// 
			this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bClose.Location = new System.Drawing.Point(521, 10);
			this.bClose.Name = "bClose";
			this.bClose.Size = new System.Drawing.Size(105, 29);
			this.bClose.TabIndex = 243;
			this.bClose.Text = "Close";
			this.bClose.Click += new System.EventHandler(this.bClose_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.Image = global::UserControls.Properties.Resources.printericon;
			this.pictureBox1.Location = new System.Drawing.Point(606, 45);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(25, 25);
			this.pictureBox1.TabIndex = 215;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.bClose);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 556);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(637, 48);
			this.panel2.TabIndex = 215;
			// 
			// ucTransactionViewer0
			// 
			this.ucTransactionViewer0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
			this.ucTransactionViewer0.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucTransactionViewer0.IsActive = false;
			this.ucTransactionViewer0.Location = new System.Drawing.Point(0, 39);
			this.ucTransactionViewer0.Name = "ucTransactionViewer0";
			this.ucTransactionViewer0.Size = new System.Drawing.Size(637, 565);
			this.ucTransactionViewer0.TabIndex = 245;
			// 
			// frmTransactionViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
			this.ClientSize = new System.Drawing.Size(637, 604);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.ucTransactionViewer0);
			this.Controls.Add(this.pFormHdr);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmTransactionViewer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "View Waste Transaction Details";
			this.pFormHdr.ResumeLayout(false);
			this.pFormHdr.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pFormHdr;
		private Infragistics.Win.Misc.UltraLabel lFormTitle;
		private Infragistics.Win.Misc.UltraButton bClose;
		private UCTransactionViewer ucTransactionViewer0;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel2;
	}
}
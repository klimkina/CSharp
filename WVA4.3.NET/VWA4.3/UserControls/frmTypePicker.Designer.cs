namespace UserControls
{
	partial class frmTypePicker
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTypePicker));
			this.panel1 = new System.Windows.Forms.Panel();
			this.pFormHdr = new System.Windows.Forms.Panel();
			this.lFormTitle = new Infragistics.Win.Misc.UltraLabel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bCancel = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.ucTrackerViewer1 = new UserControls.UCTrackerViewer();
			this.panel1.SuspendLayout();
			this.pFormHdr.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pFormHdr);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(499, 39);
			this.panel1.TabIndex = 224;
			// 
			// pFormHdr
			// 
			this.pFormHdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(174)))), ((int)(((byte)(65)))));
			this.pFormHdr.Controls.Add(this.lFormTitle);
			this.pFormHdr.Dock = System.Windows.Forms.DockStyle.Top;
			this.pFormHdr.Location = new System.Drawing.Point(0, 0);
			this.pFormHdr.Name = "pFormHdr";
			this.pFormHdr.Size = new System.Drawing.Size(499, 34);
			this.pFormHdr.TabIndex = 242;
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
			this.panel2.Location = new System.Drawing.Point(0, 412);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(499, 52);
			this.panel2.TabIndex = 225;
			// 
			// bCancel
			// 
			this.bCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bCancel.BackColor = System.Drawing.Color.White;
			this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bCancel.Location = new System.Drawing.Point(359, 11);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(105, 29);
			this.bCancel.TabIndex = 254;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = false;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.ucTrackerViewer1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 39);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(499, 373);
			this.panel3.TabIndex = 226;
			// 
			// ucTrackerViewer1
			// 
			this.ucTrackerViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucTrackerViewer1.ID = "";
			this.ucTrackerViewer1.Location = new System.Drawing.Point(0, 0);
			this.ucTrackerViewer1.Name = "ucTrackerViewer1";
			this.ucTrackerViewer1.Size = new System.Drawing.Size(499, 373);
			this.ucTrackerViewer1.TabIndex = 224;
			this.ucTrackerViewer1.TermID = null;
			this.ucTrackerViewer1.TypeID = "";
			this.ucTrackerViewer1.TypeName = null;
			this.ucTrackerViewer1.TrackerButtonChanged += new UserControls.UCTrackerViewer.TrackerButtonChangedEventHandler(this.ucTrackerViewer1_TrackerButtonChanged);
			// 
			// frmTypePicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
			this.ClientSize = new System.Drawing.Size(499, 464);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmTypePicker";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = " Types";
			this.panel1.ResumeLayout(false);
			this.pFormHdr.ResumeLayout(false);
			this.pFormHdr.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private UCTrackerViewer ucTrackerViewer1;
		private Infragistics.Win.Misc.UltraLabel lFormTitle;
		private System.Windows.Forms.Panel pFormHdr;
		private System.Windows.Forms.Button bCancel;
	}
}
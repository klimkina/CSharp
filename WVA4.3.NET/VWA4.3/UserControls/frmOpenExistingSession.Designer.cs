namespace UserControls
{
	partial class frmOpenExistingSession
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
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpenExistingSession));
			this.pFormHdr = new System.Windows.Forms.Panel();
			this.lFormTitle = new Infragistics.Win.Misc.UltraLabel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bDone = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.ulvSessions = new Infragistics.Win.UltraWinListView.UltraListView();
			this.pFormHdr.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ulvSessions)).BeginInit();
			this.SuspendLayout();
			// 
			// pFormHdr
			// 
			this.pFormHdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(174)))), ((int)(((byte)(65)))));
			this.pFormHdr.Controls.Add(this.lFormTitle);
			this.pFormHdr.Dock = System.Windows.Forms.DockStyle.Top;
			this.pFormHdr.Location = new System.Drawing.Point(0, 0);
			this.pFormHdr.Name = "pFormHdr";
			this.pFormHdr.Size = new System.Drawing.Size(456, 39);
			this.pFormHdr.TabIndex = 240;
			// 
			// lFormTitle
			// 
			appearance18.FontData.BoldAsString = "True";
			appearance18.TextHAlignAsString = "Left";
			appearance18.TextVAlignAsString = "Middle";
			this.lFormTitle.Appearance = appearance18;
			this.lFormTitle.AutoSize = true;
			this.lFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFormTitle.Location = new System.Drawing.Point(7, 8);
			this.lFormTitle.Name = "lFormTitle";
			this.lFormTitle.Size = new System.Drawing.Size(302, 21);
			this.lFormTitle.TabIndex = 214;
			this.lFormTitle.Text = "Select  Session for Data Entry / Editing";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.bDone);
			this.panel2.Controls.Add(this.bCancel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 494);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(456, 45);
			this.panel2.TabIndex = 241;
			// 
			// bDone
			// 
			this.bDone.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bDone.BackColor = System.Drawing.Color.White;
			this.bDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bDone.Location = new System.Drawing.Point(247, 8);
			this.bDone.Name = "bDone";
			this.bDone.Size = new System.Drawing.Size(180, 29);
			this.bDone.TabIndex = 254;
			this.bDone.Text = "Start Selected Session";
			this.bDone.UseVisualStyleBackColor = false;
			this.bDone.Click += new System.EventHandler(this.bDone_Click);
			// 
			// bCancel
			// 
			this.bCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bCancel.BackColor = System.Drawing.Color.White;
			this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bCancel.Location = new System.Drawing.Point(30, 8);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(105, 29);
			this.bCancel.TabIndex = 255;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = false;
			this.bCancel.Click += new System.EventHandler(this.lCancel_Click);
			// 
			// ulvSessions
			// 
			this.ulvSessions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
			this.ulvSessions.ItemSettings.Appearance = appearance2;
			this.ulvSessions.ItemSettings.SelectionType = Infragistics.Win.UltraWinListView.SelectionType.Single;
			this.ulvSessions.Location = new System.Drawing.Point(7, 45);
			this.ulvSessions.Name = "ulvSessions";
			this.ulvSessions.Size = new System.Drawing.Size(442, 443);
			this.ulvSessions.TabIndex = 0;
			this.ulvSessions.Text = "ulvSessions";
			this.ulvSessions.ViewSettingsDetails.FullRowSelect = true;
			this.ulvSessions.ItemSelectionChanged += new Infragistics.Win.UltraWinListView.ItemSelectionChangedEventHandler(this.ulvSessions_ItemSelectionChanged);
			this.ulvSessions.DoubleClick += new System.EventHandler(this.bDone_Click);
			// 
			// frmOpenExistingSession
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
			this.ClientSize = new System.Drawing.Size(456, 539);
			this.Controls.Add(this.ulvSessions);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.pFormHdr);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmOpenExistingSession";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Data Entry Sessions";
			this.pFormHdr.ResumeLayout(false);
			this.pFormHdr.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ulvSessions)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pFormHdr;
		private Infragistics.Win.Misc.UltraLabel lFormTitle;
		private System.Windows.Forms.Panel panel2;
		private Infragistics.Win.UltraWinListView.UltraListView ulvSessions;
		private System.Windows.Forms.Button bDone;
		private System.Windows.Forms.Button bCancel;
	}
}
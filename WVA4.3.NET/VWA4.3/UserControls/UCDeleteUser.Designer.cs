namespace UserControls
{
	partial class UCDeleteUser
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton1 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
			this.ucTreeView1 = new UserControls.UCTreeView();
			this.lTaskTitle = new DevExpress.XtraEditors.LabelControl();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.bDelete = new Infragistics.Win.Misc.UltraButton();
			this.bCancel = new Infragistics.Win.Misc.UltraButton();
			this.teUser = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.bDone = new Infragistics.Win.Misc.UltraButton();
			this.pTaskHdr = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.teUser)).BeginInit();
			this.pTaskHdr.SuspendLayout();
			this.SuspendLayout();
			// 
			// ucTreeView1
			// 
			this.ucTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ucTreeView1.EnableCheckboxes = false;
			this.ucTreeView1.ID = "";
			this.ucTreeView1.Location = new System.Drawing.Point(240, 115);
			this.ucTreeView1.Name = "ucTreeView1";
			this.ucTreeView1.ShowAllNames = false;
			this.ucTreeView1.ShowBEONumber = true;
			this.ucTreeView1.ShowDisabled = false;
			this.ucTreeView1.ShowPrice = false;
			this.ucTreeView1.Size = new System.Drawing.Size(214, 337);
			this.ucTreeView1.TabIndex = 130;
			this.ucTreeView1.TypeCatalogID = "0";
			this.ucTreeView1.TypeName = "";
			this.ucTreeView1.Visible = false;
			this.ucTreeView1.TreeViewIDChanged += new UserControls.UCTreeView.TreeViewIDChangedEventHandler(this.ucTreeView1_TreeViewIDChanged);
			this.ucTreeView1.Load += new System.EventHandler(this.ucTreeView1_Load);
			this.ucTreeView1.Leave += new System.EventHandler(this.ucTreeView1_Leave);
			// 
			// lTaskTitle
			// 
			this.lTaskTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lTaskTitle.Appearance.ForeColor = System.Drawing.Color.Sienna;
			this.lTaskTitle.Appearance.Options.UseFont = true;
			this.lTaskTitle.Appearance.Options.UseForeColor = true;
			this.lTaskTitle.Location = new System.Drawing.Point(3, 3);
			this.lTaskTitle.Name = "lTaskTitle";
			this.lTaskTitle.Size = new System.Drawing.Size(193, 35);
			this.lTaskTitle.TabIndex = 56;
			this.lTaskTitle.Text = "Remove User";
			// 
			// ultraLabel1
			// 
			appearance11.TextHAlignAsString = "Center";
			appearance11.TextVAlignAsString = "Middle";
			this.ultraLabel1.Appearance = appearance11;
			this.ultraLabel1.AutoSize = true;
			this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ultraLabel1.Location = new System.Drawing.Point(240, 72);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(283, 17);
			this.ultraLabel1.TabIndex = 126;
			this.ultraLabel1.Text = "User Name will be removed from all Trackers.";
			// 
			// bDelete
			// 
			this.bDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bDelete.Location = new System.Drawing.Point(247, 146);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(94, 29);
			this.bDelete.TabIndex = 127;
			this.bDelete.Text = "Delete";
			this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
			// 
			// bCancel
			// 
			this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bCancel.Location = new System.Drawing.Point(359, 146);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(90, 29);
			this.bCancel.TabIndex = 128;
			this.bCancel.Text = "Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// teUser
			// 
			dropDownEditorButton1.Control = this.ucTreeView1;
			dropDownEditorButton1.PreferredDropDownSize = new System.Drawing.Size(0, 0);
			this.teUser.ButtonsRight.Add(dropDownEditorButton1);
			this.teUser.Location = new System.Drawing.Point(247, 105);
			this.teUser.Name = "teUser";
			this.teUser.Size = new System.Drawing.Size(202, 21);
			this.teUser.TabIndex = 129;
			this.teUser.Text = "teUser";
			this.teUser.ValueChanged += new System.EventHandler(this.teUser_ValueChanged);
			this.teUser.BeforeEditorButtonDropDown += new Infragistics.Win.UltraWinEditors.BeforeEditorButtonDropDownEventHandler(this.ultraTextEditor1_BeforeEditorButtonDropDown);
			// 
			// bDone
			// 
			this.bDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bDone.Location = new System.Drawing.Point(601, 454);
			this.bDone.Name = "bDone";
			this.bDone.Size = new System.Drawing.Size(105, 29);
			this.bDone.TabIndex = 147;
			this.bDone.Text = "Done";
			this.bDone.Click += new System.EventHandler(this.bDone_Click);
			// 
			// pTaskHdr
			// 
			this.pTaskHdr.Controls.Add(this.lTaskTitle);
			this.pTaskHdr.Dock = System.Windows.Forms.DockStyle.Top;
			this.pTaskHdr.Location = new System.Drawing.Point(0, 0);
			this.pTaskHdr.Name = "pTaskHdr";
			this.pTaskHdr.Size = new System.Drawing.Size(722, 45);
			this.pTaskHdr.TabIndex = 148;
			// 
			// UCDeleteUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.bDone);
			this.Controls.Add(this.teUser);
			this.Controls.Add(this.bDelete);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.ultraLabel1);
			this.Controls.Add(this.ucTreeView1);
			this.Controls.Add(this.pTaskHdr);
			this.MinimumSize = new System.Drawing.Size(200, 200);
			this.Name = "UCDeleteUser";
			this.Size = new System.Drawing.Size(722, 497);
			((System.ComponentModel.ISupportInitialize)(this.teUser)).EndInit();
			this.pTaskHdr.ResumeLayout(false);
			this.pTaskHdr.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl lTaskTitle;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraButton bDelete;
		private Infragistics.Win.Misc.UltraButton bCancel;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor teUser;
		private UCTreeView ucTreeView1;
		private Infragistics.Win.Misc.UltraButton bDone;
		private System.Windows.Forms.Panel pTaskHdr;
	}
}

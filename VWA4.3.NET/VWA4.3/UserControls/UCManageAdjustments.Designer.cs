namespace UserControls
{
	partial class UCManageAdjustments
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
			Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton1 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			this.ucTreeView1 = new UserControls.UCTreeView();
			this.pTaskHdr = new System.Windows.Forms.Panel();
			this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.lTaskTitle = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bDelete = new Infragistics.Win.Misc.UltraButton();
			this.bDone = new Infragistics.Win.Misc.UltraButton();
			this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.pTaskHdr.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// ucTreeView1
			// 
			this.ucTreeView1.EnableCheckboxes = false;
			this.ucTreeView1.ID = "";
			this.ucTreeView1.Location = new System.Drawing.Point(541, 14);
			this.ucTreeView1.Name = "ucTreeView1";
			this.ucTreeView1.ShowAllNames = false;
			this.ucTreeView1.ShowBEONumber = true;
			this.ucTreeView1.ShowDisabled = false;
			this.ucTreeView1.ShowPrice = false;
			this.ucTreeView1.Size = new System.Drawing.Size(306, 179);
			this.ucTreeView1.TabIndex = 127;
			this.ucTreeView1.TypeCatalogID = "0";
			this.ucTreeView1.TypeName = "";
			this.ucTreeView1.Visible = false;
			this.ucTreeView1.TreeViewIDChanged += new UserControls.UCTreeView.TreeViewIDChangedEventHandler(this.ucTreeView1_TreeViewIDChanged);
			// 
			// pTaskHdr
			// 
			this.pTaskHdr.Controls.Add(this.ultraTextEditor1);
			this.pTaskHdr.Controls.Add(this.lTaskTitle);
			this.pTaskHdr.Dock = System.Windows.Forms.DockStyle.Top;
			this.pTaskHdr.Location = new System.Drawing.Point(0, 0);
			this.pTaskHdr.Name = "pTaskHdr";
			this.pTaskHdr.Size = new System.Drawing.Size(877, 45);
			this.pTaskHdr.TabIndex = 5;
			// 
			// ultraTextEditor1
			// 
			dropDownEditorButton1.Control = this.ucTreeView1;
			dropDownEditorButton1.PreferredDropDownSize = new System.Drawing.Size(0, 0);
			this.ultraTextEditor1.ButtonsRight.Add(dropDownEditorButton1);
			this.ultraTextEditor1.Location = new System.Drawing.Point(470, 15);
			this.ultraTextEditor1.Name = "ultraTextEditor1";
			this.ultraTextEditor1.Size = new System.Drawing.Size(111, 21);
			this.ultraTextEditor1.TabIndex = 128;
			this.ultraTextEditor1.Text = "ultraTextEditor1";
			// 
			// ultraLabel1
			// 
			appearance2.TextHAlignAsString = "Center";
			appearance2.TextVAlignAsString = "Middle";
			this.ultraLabel1.Appearance = appearance2;
			this.ultraLabel1.AutoSize = true;
			this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ultraLabel1.Location = new System.Drawing.Point(6, 48);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(392, 17);
			this.ultraLabel1.TabIndex = 126;
			this.ultraLabel1.Text = "Enter new adjustments on the first line; edit existing data in place.";
			// 
			// lTaskTitle
			// 
			this.lTaskTitle.AutoSize = true;
			this.lTaskTitle.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lTaskTitle.ForeColor = System.Drawing.Color.Sienna;
			this.lTaskTitle.Location = new System.Drawing.Point(5, 3);
			this.lTaskTitle.Name = "lTaskTitle";
			this.lTaskTitle.Size = new System.Drawing.Size(462, 35);
			this.lTaskTitle.TabIndex = 2;
			this.lTaskTitle.Text = "Enter Waste Cost Adjustments";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.bDelete);
			this.panel2.Controls.Add(this.bDone);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 548);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(877, 51);
			this.panel2.TabIndex = 6;
			// 
			// bDelete
			// 
			this.bDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bDelete.Location = new System.Drawing.Point(11, 10);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(129, 29);
			this.bDelete.TabIndex = 148;
			this.bDelete.Text = "Delete Adjustment";
			this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
			// 
			// bDone
			// 
			this.bDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bDone.Location = new System.Drawing.Point(758, 11);
			this.bDone.Name = "bDone";
			this.bDone.Size = new System.Drawing.Size(105, 29);
			this.bDone.TabIndex = 147;
			this.bDone.Text = "Done";
			this.bDone.Click += new System.EventHandler(this.bDone_Click);
			// 
			// ultraGrid1
			// 
			this.ultraGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance5.BackColor = System.Drawing.SystemColors.Window;
			appearance5.BorderColor = System.Drawing.SystemColors.InactiveCaption;
			this.ultraGrid1.DisplayLayout.Appearance = appearance5;
			this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			appearance1.BackColor = System.Drawing.SystemColors.ActiveBorder;
			appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance1.BorderColor = System.Drawing.SystemColors.Window;
			this.ultraGrid1.DisplayLayout.GroupByBox.Appearance = appearance1;
			appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
			this.ultraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
			this.ultraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			appearance4.BackColor2 = System.Drawing.SystemColors.Control;
			appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
			this.ultraGrid1.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
			this.ultraGrid1.DisplayLayout.MaxColScrollRegions = 1;
			this.ultraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
			appearance14.BackColor = System.Drawing.SystemColors.Window;
			appearance14.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ultraGrid1.DisplayLayout.Override.ActiveCellAppearance = appearance14;
			appearance8.BackColor = System.Drawing.SystemColors.Highlight;
			appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.ultraGrid1.DisplayLayout.Override.ActiveRowAppearance = appearance8;
			this.ultraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
			this.ultraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
			appearance7.BackColor = System.Drawing.SystemColors.Window;
			this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance7;
			appearance6.BorderColor = System.Drawing.Color.Silver;
			appearance6.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
			this.ultraGrid1.DisplayLayout.Override.CellAppearance = appearance6;
			this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
			this.ultraGrid1.DisplayLayout.Override.CellPadding = 0;
			appearance10.BackColor = System.Drawing.SystemColors.Control;
			appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
			appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance10.BorderColor = System.Drawing.SystemColors.Window;
			this.ultraGrid1.DisplayLayout.Override.GroupByRowAppearance = appearance10;
			appearance13.TextHAlignAsString = "Left";
			this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance13;
			this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			this.ultraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
			appearance12.BackColor = System.Drawing.SystemColors.Window;
			appearance12.BorderColor = System.Drawing.Color.Silver;
			this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance12;
			this.ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			appearance9.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ultraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance9;
			this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
			this.ultraGrid1.Location = new System.Drawing.Point(0, 67);
			this.ultraGrid1.Name = "ultraGrid1";
			this.ultraGrid1.Size = new System.Drawing.Size(877, 481);
			this.ultraGrid1.TabIndex = 7;
			this.ultraGrid1.Text = "ultraGrid1";
			this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
			this.ultraGrid1.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.ultraGrid1_AfterRowUpdate);
			this.ultraGrid1.BeforeRowUpdate += new Infragistics.Win.UltraWinGrid.CancelableRowEventHandler(this.ultraGrid1_BeforeRowUpdate);
			this.ultraGrid1.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.ultraGrid1_BeforeEnterEditMode);
			this.ultraGrid1.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.ultraGrid1_BeforeExitEditMode);
			// 
			// UCManageAdjustments
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ucTreeView1);
			this.Controls.Add(this.ultraGrid1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.ultraLabel1);
			this.Controls.Add(this.pTaskHdr);
			this.MinimumSize = new System.Drawing.Size(200, 200);
			this.Name = "UCManageAdjustments";
			this.Size = new System.Drawing.Size(877, 599);
			this.pTaskHdr.ResumeLayout(false);
			this.pTaskHdr.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pTaskHdr;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		public System.Windows.Forms.Label lTaskTitle;
		private System.Windows.Forms.Panel panel2;
		private Infragistics.Win.Misc.UltraButton bDelete;
		private Infragistics.Win.Misc.UltraButton bDone;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private UCTreeView ucTreeView1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
	}
}

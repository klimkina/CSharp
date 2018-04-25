namespace UserControls
{
	partial class UCEnterFinancialData
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Financials", -1);
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FoodCostActual");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FoodCostBudget");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FoodRevenueActual");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FoodRevenueBudget");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MealCountActual");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MealCountBudget");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PeriodUniqueName");
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PeriodStartDate", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
			Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SiteID");
			Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			this.ultraCurrencyEditor1 = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
			this.ultraDateTimeEditor1 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.lTaskTitle = new System.Windows.Forms.Label();
			this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.pTaskHdr = new System.Windows.Forms.Panel();
			this.lTaskTitle1 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.bDone = new Infragistics.Win.Misc.UltraButton();
			this.bDelete = new Infragistics.Win.Misc.UltraButton();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.ultraCurrencyEditor1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraDateTimeEditor1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			this.pTaskHdr.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ultraCurrencyEditor1
			// 
			this.ultraCurrencyEditor1.Location = new System.Drawing.Point(40, 233);
			this.ultraCurrencyEditor1.Name = "ultraCurrencyEditor1";
			this.ultraCurrencyEditor1.Size = new System.Drawing.Size(100, 21);
			this.ultraCurrencyEditor1.TabIndex = 4;
			this.ultraCurrencyEditor1.Visible = false;
			// 
			// ultraDateTimeEditor1
			// 
			this.ultraDateTimeEditor1.DateTime = new System.DateTime(2008, 12, 5, 0, 0, 0, 0);
			this.ultraDateTimeEditor1.Location = new System.Drawing.Point(160, 239);
			this.ultraDateTimeEditor1.MaskInput = "{LOC}mm/yyyy";
			this.ultraDateTimeEditor1.Name = "ultraDateTimeEditor1";
			this.ultraDateTimeEditor1.Size = new System.Drawing.Size(144, 21);
			this.ultraDateTimeEditor1.TabIndex = 5;
			this.ultraDateTimeEditor1.Value = new System.DateTime(2008, 12, 5, 0, 0, 0, 0);
			this.ultraDateTimeEditor1.Visible = false;
			// 
			// lTaskTitle
			// 
			this.lTaskTitle.AutoSize = true;
			this.lTaskTitle.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lTaskTitle.ForeColor = System.Drawing.Color.Sienna;
			this.lTaskTitle.Location = new System.Drawing.Point(4, 4);
			this.lTaskTitle.Name = "lTaskTitle";
			this.lTaskTitle.Size = new System.Drawing.Size(378, 35);
			this.lTaskTitle.TabIndex = 2;
			this.lTaskTitle.Text = "Enter Monthly Financials";
			// 
			// ultraGrid1
			// 
			this.ultraGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			appearance1.BackColor = System.Drawing.SystemColors.Window;
			appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
			this.ultraGrid1.DisplayLayout.Appearance = appearance1;
			ultraGridColumn11.Header.VisiblePosition = 0;
			ultraGridColumn11.Hidden = true;
			ultraGridColumn12.EditorComponent = this.ultraCurrencyEditor1;
			ultraGridColumn12.Header.Caption = "Waste Cost (Actual)";
			ultraGridColumn12.Header.VisiblePosition = 3;
			ultraGridColumn12.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
			ultraGridColumn12.MaskInput = "{currency:9.2}";
			ultraGridColumn13.EditorComponent = this.ultraCurrencyEditor1;
			ultraGridColumn13.Header.Caption = "Waste Cost (Budget)";
			ultraGridColumn13.Header.VisiblePosition = 6;
			ultraGridColumn13.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
			ultraGridColumn13.MaskInput = "{currency:9.2}";
			ultraGridColumn14.EditorComponent = this.ultraCurrencyEditor1;
			ultraGridColumn14.Header.Caption = "Waste Revenue (Actual)";
			ultraGridColumn14.Header.VisiblePosition = 2;
			ultraGridColumn14.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
			ultraGridColumn14.MaskInput = "{currency:9.2}";
			ultraGridColumn15.EditorComponent = this.ultraCurrencyEditor1;
			ultraGridColumn15.Header.Caption = "Waste Revenue (Budget)";
			ultraGridColumn15.Header.VisiblePosition = 5;
			ultraGridColumn15.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
			ultraGridColumn15.MaskInput = "{currency:9.2}";
			ultraGridColumn16.EditorComponent = this.ultraCurrencyEditor1;
			ultraGridColumn16.Header.Caption = "Meal Count (Actual)";
			ultraGridColumn16.Header.VisiblePosition = 4;
			ultraGridColumn16.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
			ultraGridColumn16.MaskInput = "nnnnnnnnn";
			ultraGridColumn17.EditorComponent = this.ultraCurrencyEditor1;
			ultraGridColumn17.Header.Caption = "Meal Count (Budget)";
			ultraGridColumn17.Header.VisiblePosition = 7;
			ultraGridColumn17.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
			ultraGridColumn17.MaskInput = "nnnnnnnnn";
			ultraGridColumn18.Header.VisiblePosition = 8;
			ultraGridColumn18.Hidden = true;
			ultraGridColumn19.EditorComponent = this.ultraDateTimeEditor1;
			ultraGridColumn19.Format = "MM/yyyy";
			ultraGridColumn19.Header.Caption = "Date";
			ultraGridColumn19.Header.VisiblePosition = 1;
			ultraGridColumn20.Header.VisiblePosition = 9;
			ultraGridColumn20.Hidden = true;
			ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20});
			this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
			this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			appearance13.BackColor = System.Drawing.SystemColors.ActiveBorder;
			appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance13.BorderColor = System.Drawing.SystemColors.Window;
			this.ultraGrid1.DisplayLayout.GroupByBox.Appearance = appearance13;
			appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
			this.ultraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
			this.ultraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
			appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			appearance4.BackColor2 = System.Drawing.SystemColors.Control;
			appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
			this.ultraGrid1.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
			this.ultraGrid1.DisplayLayout.MaxColScrollRegions = 1;
			this.ultraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
			appearance5.BackColor = System.Drawing.SystemColors.Window;
			appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ultraGrid1.DisplayLayout.Override.ActiveCellAppearance = appearance5;
			appearance6.BackColor = System.Drawing.SystemColors.Highlight;
			appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.ultraGrid1.DisplayLayout.Override.ActiveRowAppearance = appearance6;
			this.ultraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.FixedAddRowOnTop;
			this.ultraGrid1.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
			this.ultraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
			this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
			this.ultraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
			this.ultraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
			appearance7.BackColor = System.Drawing.SystemColors.Window;
			this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance7;
			appearance8.BorderColor = System.Drawing.Color.Silver;
			appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
			this.ultraGrid1.DisplayLayout.Override.CellAppearance = appearance8;
			this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
			this.ultraGrid1.DisplayLayout.Override.CellPadding = 0;
			appearance9.BackColor = System.Drawing.SystemColors.Control;
			appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
			appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance9.BorderColor = System.Drawing.SystemColors.Window;
			this.ultraGrid1.DisplayLayout.Override.GroupByRowAppearance = appearance9;
			appearance10.TextHAlignAsString = "Left";
			this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance10;
			this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			this.ultraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
			appearance14.BackColor = System.Drawing.SystemColors.Window;
			appearance14.BorderColor = System.Drawing.Color.Silver;
			this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance14;
			this.ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
			this.ultraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
			appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ultraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
			this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.ultraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ultraGrid1.Location = new System.Drawing.Point(0, 19);
			this.ultraGrid1.Name = "ultraGrid1";
			this.ultraGrid1.RowUpdateCancelAction = Infragistics.Win.UltraWinGrid.RowUpdateCancelAction.RetainDataAndActivation;
			this.ultraGrid1.Size = new System.Drawing.Size(882, 480);
			this.ultraGrid1.TabIndex = 3;
			this.ultraGrid1.Text = "ultraGrid1";
			this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
			this.ultraGrid1.AfterRowsDeleted += new System.EventHandler(this.ultraGrid1_AfterRowsDeleted);
			this.ultraGrid1.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.ultraGrid1_AfterRowUpdate);
			this.ultraGrid1.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.ultraGrid1_BeforeExitEditMode);
			this.ultraGrid1.BeforeRowInsert += new Infragistics.Win.UltraWinGrid.BeforeRowInsertEventHandler(this.ultraGrid1_BeforeRowInsert);
			// 
			// pTaskHdr
			// 
			this.pTaskHdr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pTaskHdr.Controls.Add(this.lTaskTitle1);
			this.pTaskHdr.Controls.Add(this.lTaskTitle);
			this.pTaskHdr.Location = new System.Drawing.Point(0, 0);
			this.pTaskHdr.Name = "pTaskHdr";
			this.pTaskHdr.Size = new System.Drawing.Size(882, 43);
			this.pTaskHdr.TabIndex = 4;
			// 
			// lTaskTitle1
			// 
			appearance11.FontData.BoldAsString = "True";
			appearance11.TextHAlignAsString = "Left";
			appearance11.TextVAlignAsString = "Middle";
			this.lTaskTitle1.Appearance = appearance11;
			this.lTaskTitle1.AutoSize = true;
			this.lTaskTitle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lTaskTitle1.Location = new System.Drawing.Point(398, 15);
			this.lTaskTitle1.Name = "lTaskTitle1";
			this.lTaskTitle1.Size = new System.Drawing.Size(65, 21);
			this.lTaskTitle1.TabIndex = 151;
			this.lTaskTitle1.Text = "for Site:";
			// 
			// ultraLabel1
			// 
			appearance2.TextHAlignAsString = "Center";
			appearance2.TextVAlignAsString = "Middle";
			this.ultraLabel1.Appearance = appearance2;
			this.ultraLabel1.AutoSize = true;
			this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ultraLabel1.Location = new System.Drawing.Point(5, 0);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(507, 17);
			this.ultraLabel1.TabIndex = 126;
			this.ultraLabel1.Text = "Enter new financial data on the first line, starting with date; edit existing dat" +
				"a in place.";
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.Controls.Add(this.ultraLabel1);
			this.panel3.Controls.Add(this.ultraDateTimeEditor1);
			this.panel3.Controls.Add(this.ultraCurrencyEditor1);
			this.panel3.Controls.Add(this.ultraGrid1);
			this.panel3.Location = new System.Drawing.Point(0, 49);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(882, 507);
			this.panel3.TabIndex = 6;
			// 
			// bDone
			// 
			this.bDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bDone.Location = new System.Drawing.Point(766, 8);
			this.bDone.Name = "bDone";
			this.bDone.Size = new System.Drawing.Size(105, 29);
			this.bDone.TabIndex = 147;
			this.bDone.Text = "Done";
			this.bDone.Click += new System.EventHandler(this.bDone_Click);
			// 
			// bDelete
			// 
			this.bDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bDelete.Location = new System.Drawing.Point(9, 6);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(105, 29);
			this.bDelete.TabIndex = 148;
			this.bDelete.Text = "Delete Month";
			this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.bDelete);
			this.panel2.Controls.Add(this.bDone);
			this.panel2.Location = new System.Drawing.Point(0, 550);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(882, 45);
			this.panel2.TabIndex = 8;
			// 
			// UCEnterFinancialData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.pTaskHdr);
			this.MinimumSize = new System.Drawing.Size(200, 200);
			this.Name = "UCEnterFinancialData";
			this.Size = new System.Drawing.Size(882, 599);
			((System.ComponentModel.ISupportInitialize)(this.ultraCurrencyEditor1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraDateTimeEditor1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			this.pTaskHdr.ResumeLayout(false);
			this.pTaskHdr.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Label lTaskTitle;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private UserControls.vwa40blankDataSetTableAdapters.FinancialsTableAdapter financialsTableAdapter;
		private System.Windows.Forms.Panel pTaskHdr;
        private System.Windows.Forms.Panel panel3;
        private Infragistics.Win.UltraWinEditors.UltraCurrencyEditor ultraCurrencyEditor1;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor ultraDateTimeEditor1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel lTaskTitle1;
		private Infragistics.Win.Misc.UltraButton bDone;
		private Infragistics.Win.Misc.UltraButton bDelete;
		private System.Windows.Forms.Panel panel2;
	}
}

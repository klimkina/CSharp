namespace UserControls
{
    partial class UCViewWaste
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.gridViewWaste = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraPrintPreviewDlg = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
            this.ultraGridPrintDocument1 = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
            this.dtpStamp = new UserControls.SmartDateTimePicker();
            this.ultraMaskedEdit1 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWaste)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewWaste
            // 
            this.gridViewWaste.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridViewWaste.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridViewWaste.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridViewWaste.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.gridViewWaste.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridViewWaste.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.gridViewWaste.DisplayLayout.MaxColScrollRegions = 1;
            this.gridViewWaste.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridViewWaste.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridViewWaste.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.gridViewWaste.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridViewWaste.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.gridViewWaste.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridViewWaste.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridViewWaste.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridViewWaste.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.gridViewWaste.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.gridViewWaste.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.gridViewWaste.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridViewWaste.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.gridViewWaste.DisplayLayout.Override.RowAppearance = appearance11;
            this.gridViewWaste.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridViewWaste.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.gridViewWaste.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridViewWaste.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridViewWaste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewWaste.Location = new System.Drawing.Point(0, 0);
            this.gridViewWaste.Name = "gridViewWaste";
            this.gridViewWaste.RowUpdateCancelAction = Infragistics.Win.UltraWinGrid.RowUpdateCancelAction.RetainDataAndActivation;
            this.gridViewWaste.Size = new System.Drawing.Size(804, 362);
            this.gridViewWaste.TabIndex = 0;
            this.gridViewWaste.Text = "ultraGrid1";
            this.gridViewWaste.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnUpdate;
            this.gridViewWaste.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.gridViewWaste_BeforeEnterEditMode);
            this.gridViewWaste.InitializePrint += new Infragistics.Win.UltraWinGrid.InitializePrintEventHandler(this.gridViewWaste_InitializePrint);
            this.gridViewWaste.AfterRowResize += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.gridViewWaste_AfterRowResize);
            this.gridViewWaste.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gridViewWaste_InitializeLayout);
            this.gridViewWaste.AfterColRegionSize += new Infragistics.Win.UltraWinGrid.ColScrollRegionEventHandler(this.gridViewWaste_AfterColRegionSize);
            this.gridViewWaste.BeforeRowFilterDropDown += new Infragistics.Win.UltraWinGrid.BeforeRowFilterDropDownEventHandler(this.gridViewWaste_BeforeRowFilterDropDown);
            this.gridViewWaste.AfterColPosChanged += new Infragistics.Win.UltraWinGrid.AfterColPosChangedEventHandler(this.gridViewWaste_AfterColPosChanged);
            this.gridViewWaste.AfterRowFilterChanged += new Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventHandler(this.gridViewWaste_AfterRowFilterChanged);
            this.gridViewWaste.BeforeCellDeactivate += new System.ComponentModel.CancelEventHandler(this.gridViewWaste_BeforeCellDeactivate);
            this.gridViewWaste.AfterRowRegionSize += new Infragistics.Win.UltraWinGrid.RowScrollRegionEventHandler(this.gridViewWaste_AfterRowRegionSize);
            this.gridViewWaste.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.gridViewWaste_CellChange);
            this.gridViewWaste.AfterRowRegionScroll += new Infragistics.Win.UltraWinGrid.RowScrollRegionEventHandler(this.gridViewWaste_AfterRowRegionScroll);
            this.gridViewWaste.AfterColRegionScroll += new Infragistics.Win.UltraWinGrid.ColScrollRegionEventHandler(this.gridViewWaste_AfterColRegionScroll);
            this.gridViewWaste.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.gridViewWaste_DoubleClickRow);
            // 
            // ultraPrintPreviewDlg
            // 
            this.ultraPrintPreviewDlg.Document = this.ultraGridPrintDocument1;
            this.ultraPrintPreviewDlg.Name = "Waste Print Preview";
            this.ultraPrintPreviewDlg.Load += new System.EventHandler(this.ultraPrintPreviewDlg_Load);
            this.ultraPrintPreviewDlg.Printed += new System.EventHandler(this.ultraPrintPreviewDlg_Printed);
            // 
            // dtpStamp
            // 
            this.dtpStamp.Location = new System.Drawing.Point(431, 337);
            this.dtpStamp.Name = "dtpStamp";
            this.dtpStamp.Size = new System.Drawing.Size(294, 20);
            this.dtpStamp.TabIndex = 3;
            this.dtpStamp.Value = new System.DateTime(2008, 3, 21, 14, 37, 37, 0);
            this.dtpStamp.EnterPressed += new UserControls.SmartDateTimePicker.EnterPressedEventHandler(this.dtpStamp_EnterPressed);
            this.dtpStamp.Leave += new System.EventHandler(this.dtpStamp_Leave);
            // 
            // ultraMaskedEdit1
            // 
            this.ultraMaskedEdit1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.ultraMaskedEdit1.InputMask = "{double:-9.4:c}";
            this.ultraMaskedEdit1.Location = new System.Drawing.Point(0, 0);
            this.ultraMaskedEdit1.Name = "ultraMaskedEdit1";
            this.ultraMaskedEdit1.Size = new System.Drawing.Size(100, 20);
            this.ultraMaskedEdit1.TabIndex = 4;
            this.ultraMaskedEdit1.Text = "ultraMaskedEdit1";
            // 
            // UCViewWaste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraMaskedEdit1);
            this.Controls.Add(this.dtpStamp);
            this.Controls.Add(this.gridViewWaste);
            this.Name = "UCViewWaste";
            this.Size = new System.Drawing.Size(804, 362);
            this.Load += new System.EventHandler(this.UCViewWaste_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWaste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Infragistics.Win.UltraWinGrid.UltraGrid gridViewWaste;
        private SmartDateTimePicker dtpStamp;
        private Infragistics.Win.Printing.UltraPrintPreviewDialog ultraPrintPreviewDlg;
        private Infragistics.Win.UltraWinGrid.UltraGridPrintDocument ultraGridPrintDocument1;
        private Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit ultraMaskedEdit1;
    }
}

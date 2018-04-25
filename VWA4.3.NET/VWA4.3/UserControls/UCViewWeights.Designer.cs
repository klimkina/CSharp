namespace UserControls
{
    partial class UCViewWeights
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
			Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton1 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
			Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton2 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnXMLExport = new System.Windows.Forms.Button();
			this.ultraTransferEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.btnPDF = new System.Windows.Forms.Button();
			this.btnLoadView = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnSaveView = new System.Windows.Forms.Button();
			this.btnColumnChooser = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.ultraPrintPreviewDlg = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
			this.ultraGridPrintDocument1 = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.cboSite = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblFilter = new System.Windows.Forms.Label();
			this.ultraGridColumnChooser1 = new Infragistics.Win.UltraWinGrid.UltraGridColumnChooser();
			this.gridViewWaste = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.cmReplaceColumn = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
			this.ultraGridDocumentExporter1 = new Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(this.components);
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.ucTreeView1 = new UserControls.UCTreeView();
			this.ucEditTransfer1 = new UserControls.UCEditTransfer();
			this.dtpStamp = new UserControls.SmartDateTimePicker();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraTransferEditor)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGridColumnChooser1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewWaste)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
			this.cmReplaceColumn.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.btnXMLExport);
			this.panel1.Controls.Add(this.ultraTransferEditor);
			this.panel1.Controls.Add(this.btnPDF);
			this.panel1.Controls.Add(this.btnLoadView);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnSaveView);
			this.panel1.Controls.Add(this.btnColumnChooser);
			this.panel1.Controls.Add(this.btnPrint);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 414);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(748, 29);
			this.panel1.TabIndex = 0;
			// 
			// btnXMLExport
			// 
			this.btnXMLExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnXMLExport.Location = new System.Drawing.Point(500, 4);
			this.btnXMLExport.Name = "btnXMLExport";
			this.btnXMLExport.Size = new System.Drawing.Size(93, 23);
			this.btnXMLExport.TabIndex = 10;
			this.btnXMLExport.Text = "Export to XML";
			this.btnXMLExport.UseVisualStyleBackColor = true;
			this.btnXMLExport.Click += new System.EventHandler(this.btnXMLExport_Click);
			// 
			// ultraTransferEditor
			// 
			dropDownEditorButton1.Control = this.ucEditTransfer1;
			this.ultraTransferEditor.ButtonsRight.Add(dropDownEditorButton1);
			this.ultraTransferEditor.Location = new System.Drawing.Point(0, 0);
			this.ultraTransferEditor.Name = "ultraTransferEditor";
			this.ultraTransferEditor.Size = new System.Drawing.Size(100, 21);
			this.ultraTransferEditor.TabIndex = 9;
			this.ultraTransferEditor.Visible = false;
			// 
			// btnPDF
			// 
			this.btnPDF.Location = new System.Drawing.Point(44, 3);
			this.btnPDF.Name = "btnPDF";
			this.btnPDF.Size = new System.Drawing.Size(36, 23);
			this.btnPDF.TabIndex = 8;
			this.btnPDF.Text = "PDF";
			this.btnPDF.UseVisualStyleBackColor = true;
			this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
			// 
			// btnLoadView
			// 
			this.btnLoadView.Location = new System.Drawing.Point(282, 3);
			this.btnLoadView.Name = "btnLoadView";
			this.btnLoadView.Size = new System.Drawing.Size(75, 23);
			this.btnLoadView.TabIndex = 5;
			this.btnLoadView.Text = "Load View";
			this.btnLoadView.UseVisualStyleBackColor = true;
			this.btnLoadView.Click += new System.EventHandler(this.btnLoadView_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(668, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Done";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point(593, 4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Save Data";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnSaveView
			// 
			this.btnSaveView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSaveView.Location = new System.Drawing.Point(207, 3);
			this.btnSaveView.Name = "btnSaveView";
			this.btnSaveView.Size = new System.Drawing.Size(75, 23);
			this.btnSaveView.TabIndex = 2;
			this.btnSaveView.Text = "Save View";
			this.btnSaveView.UseVisualStyleBackColor = true;
			this.btnSaveView.Click += new System.EventHandler(this.btnSaveView_Click);
			// 
			// btnColumnChooser
			// 
			this.btnColumnChooser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnColumnChooser.Location = new System.Drawing.Point(80, 3);
			this.btnColumnChooser.Name = "btnColumnChooser";
			this.btnColumnChooser.Size = new System.Drawing.Size(127, 23);
			this.btnColumnChooser.TabIndex = 1;
			this.btnColumnChooser.Text = "Hide Choose Columns";
			this.btnColumnChooser.UseVisualStyleBackColor = true;
			this.btnColumnChooser.Click += new System.EventHandler(this.btnColumnChooser_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPrint.Location = new System.Drawing.Point(4, 3);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(40, 23);
			this.btnPrint.TabIndex = 0;
			this.btnPrint.Text = "Print";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// ultraPrintPreviewDlg
			// 
			this.ultraPrintPreviewDlg.Name = "ultraPrintPreviewDlg";
			this.ultraPrintPreviewDlg.Load += new System.EventHandler(this.ultraPrintPreviewDlg_Load);
			this.ultraPrintPreviewDlg.Printed += new System.EventHandler(this.ultraPrintPreviewDlg_Printed);
			// 
			// ultraGridPrintDocument1
			// 
			this.ultraGridPrintDocument1.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.ultraGridPrintDocument1_QueryPageSettings);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.cboSite);
			this.panel2.Controls.Add(this.lblFilter);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(748, 65);
			this.panel2.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(507, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Site:";
			// 
			// cboSite
			// 
			this.cboSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cboSite.FormattingEnabled = true;
			this.cboSite.Location = new System.Drawing.Point(553, 3);
			this.cboSite.Name = "cboSite";
			this.cboSite.Size = new System.Drawing.Size(190, 21);
			this.cboSite.TabIndex = 2;
			this.cboSite.SelectedIndexChanged += new System.EventHandler(this.cboSite_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.Sienna;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(289, 36);
			this.label1.TabIndex = 1;
			this.label1.Text = "View Transactions";
			// 
			// lblFilter
			// 
			this.lblFilter.AutoSize = true;
			this.lblFilter.Location = new System.Drawing.Point(1, 49);
			this.lblFilter.Name = "lblFilter";
			this.lblFilter.Size = new System.Drawing.Size(104, 13);
			this.lblFilter.TabIndex = 0;
			this.lblFilter.Text = "Filters Applied: None";
			// 
			// ultraGridColumnChooser1
			// 
			this.ultraGridColumnChooser1.BackColor = System.Drawing.Color.White;
			this.ultraGridColumnChooser1.ColumnDisplayOrder = Infragistics.Win.UltraWinGrid.ColumnDisplayOrder.SameAsGrid;
			this.ultraGridColumnChooser1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
			this.ultraGridColumnChooser1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			this.ultraGridColumnChooser1.DisplayLayout.MaxColScrollRegions = 1;
			this.ultraGridColumnChooser1.DisplayLayout.MaxRowScrollRegions = 1;
			this.ultraGridColumnChooser1.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
			this.ultraGridColumnChooser1.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
			this.ultraGridColumnChooser1.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
			this.ultraGridColumnChooser1.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
			this.ultraGridColumnChooser1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			this.ultraGridColumnChooser1.DisplayLayout.Override.CellPadding = 2;
			this.ultraGridColumnChooser1.DisplayLayout.Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.Never;
			this.ultraGridColumnChooser1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
			this.ultraGridColumnChooser1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			this.ultraGridColumnChooser1.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
			this.ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.ultraGridColumnChooser1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
			this.ultraGridColumnChooser1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.ultraGridColumnChooser1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.ultraGridColumnChooser1.Dock = System.Windows.Forms.DockStyle.Left;
			this.ultraGridColumnChooser1.Location = new System.Drawing.Point(0, 65);
			this.ultraGridColumnChooser1.Name = "ultraGridColumnChooser1";
			this.ultraGridColumnChooser1.Size = new System.Drawing.Size(140, 349);
			this.ultraGridColumnChooser1.StyleLibraryName = "";
			this.ultraGridColumnChooser1.StyleSetName = "";
			this.ultraGridColumnChooser1.TabIndex = 5;
			this.ultraGridColumnChooser1.Text = "ultraGridColumnChooser1";
			// 
			// gridViewWaste
			// 
			appearance28.BackColor = System.Drawing.SystemColors.Window;
			appearance28.BorderColor = System.Drawing.SystemColors.InactiveCaption;
			this.gridViewWaste.DisplayLayout.Appearance = appearance28;
			this.gridViewWaste.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.gridViewWaste.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			appearance25.BackColor = System.Drawing.SystemColors.ActiveBorder;
			appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance25.BorderColor = System.Drawing.SystemColors.Window;
			this.gridViewWaste.DisplayLayout.GroupByBox.Appearance = appearance25;
			appearance26.ForeColor = System.Drawing.SystemColors.GrayText;
			this.gridViewWaste.DisplayLayout.GroupByBox.BandLabelAppearance = appearance26;
			this.gridViewWaste.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			appearance27.BackColor = System.Drawing.SystemColors.ControlLightLight;
			appearance27.BackColor2 = System.Drawing.SystemColors.Control;
			appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance27.ForeColor = System.Drawing.SystemColors.GrayText;
			this.gridViewWaste.DisplayLayout.GroupByBox.PromptAppearance = appearance27;
			this.gridViewWaste.DisplayLayout.MaxColScrollRegions = 1;
			this.gridViewWaste.DisplayLayout.MaxRowScrollRegions = 1;
			appearance36.BackColor = System.Drawing.SystemColors.Window;
			appearance36.ForeColor = System.Drawing.SystemColors.ControlText;
			this.gridViewWaste.DisplayLayout.Override.ActiveCellAppearance = appearance36;
			appearance31.BackColor = System.Drawing.SystemColors.Highlight;
			appearance31.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.gridViewWaste.DisplayLayout.Override.ActiveRowAppearance = appearance31;
			this.gridViewWaste.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
			this.gridViewWaste.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
			appearance30.BackColor = System.Drawing.SystemColors.Window;
			this.gridViewWaste.DisplayLayout.Override.CardAreaAppearance = appearance30;
			appearance29.BorderColor = System.Drawing.Color.Silver;
			appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
			this.gridViewWaste.DisplayLayout.Override.CellAppearance = appearance29;
			this.gridViewWaste.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
			this.gridViewWaste.DisplayLayout.Override.CellPadding = 0;
			appearance33.BackColor = System.Drawing.SystemColors.Control;
			appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
			appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance33.BorderColor = System.Drawing.SystemColors.Window;
			this.gridViewWaste.DisplayLayout.Override.GroupByRowAppearance = appearance33;
			appearance35.TextHAlignAsString = "Left";
			this.gridViewWaste.DisplayLayout.Override.HeaderAppearance = appearance35;
			this.gridViewWaste.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			this.gridViewWaste.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
			appearance34.BackColor = System.Drawing.SystemColors.Window;
			appearance34.BorderColor = System.Drawing.Color.Silver;
			this.gridViewWaste.DisplayLayout.Override.RowAppearance = appearance34;
			this.gridViewWaste.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			appearance32.BackColor = System.Drawing.SystemColors.ControlLight;
			this.gridViewWaste.DisplayLayout.Override.TemplateAddRowAppearance = appearance32;
			this.gridViewWaste.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.gridViewWaste.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.gridViewWaste.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
			this.gridViewWaste.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridViewWaste.Location = new System.Drawing.Point(140, 65);
			this.gridViewWaste.Name = "gridViewWaste";
			this.gridViewWaste.Size = new System.Drawing.Size(608, 349);
			this.gridViewWaste.TabIndex = 6;
			this.gridViewWaste.Text = "ultraGrid1";
			this.gridViewWaste.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.gridViewWaste_BeforeEnterEditMode);
			this.gridViewWaste.AfterColRegionSize += new Infragistics.Win.UltraWinGrid.ColScrollRegionEventHandler(this.gridViewWaste_AfterColRegionSize);
			this.gridViewWaste.AfterColPosChanged += new Infragistics.Win.UltraWinGrid.AfterColPosChangedEventHandler(this.gridViewWaste_AfterColPosChanged);
			this.gridViewWaste.AfterRowFilterChanged += new Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventHandler(this.gridViewWaste_AfterRowFilterChanged);
			this.gridViewWaste.BeforeCellDeactivate += new System.ComponentModel.CancelEventHandler(this.gridViewWaste_BeforeCellDeactivate);
			this.gridViewWaste.AfterColRegionScroll += new Infragistics.Win.UltraWinGrid.ColScrollRegionEventHandler(this.gridViewWaste_AfterColRegionScroll);
			this.gridViewWaste.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewWaste_KeyDown);
			this.gridViewWaste.BeforeRowFilterDropDown += new Infragistics.Win.UltraWinGrid.BeforeRowFilterDropDownEventHandler(this.gridViewWaste_BeforeRowFilterDropDown);
			this.gridViewWaste.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridViewWaste_MouseClick);
			this.gridViewWaste.BeforeCustomRowFilterDialog += new Infragistics.Win.UltraWinGrid.BeforeCustomRowFilterDialogEventHandler(this.gridViewWaste_BeforeCustomRowFilterDialog);
			this.gridViewWaste.AfterRowResize += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.gridViewWaste_AfterRowResize);
			this.gridViewWaste.InitializePrint += new Infragistics.Win.UltraWinGrid.InitializePrintEventHandler(this.gridViewWaste_InitializePrint);
			this.gridViewWaste.FilterCellValueChanged += new Infragistics.Win.UltraWinGrid.FilterCellValueChangedEventHandler(this.gridViewWaste_FilterCellValueChanged);
			this.gridViewWaste.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gridViewWaste_InitializeLayout);
			this.gridViewWaste.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.gridViewWaste_CellChange);
			this.gridViewWaste.AfterRowRegionScroll += new Infragistics.Win.UltraWinGrid.RowScrollRegionEventHandler(this.gridViewWaste_AfterRowRegionScroll);
			this.gridViewWaste.AfterRowRegionSize += new Infragistics.Win.UltraWinGrid.RowScrollRegionEventHandler(this.gridViewWaste_AfterRowRegionSize);
			// 
			// ultraTextEditor1
			// 
			dropDownEditorButton2.Control = this.ucTreeView1;
			this.ultraTextEditor1.ButtonsRight.Add(dropDownEditorButton2);
			this.ultraTextEditor1.Location = new System.Drawing.Point(21, 139);
			this.ultraTextEditor1.Name = "ultraTextEditor1";
			this.ultraTextEditor1.Size = new System.Drawing.Size(100, 21);
			this.ultraTextEditor1.TabIndex = 7;
			this.ultraTextEditor1.Text = "ultraTextEditor1";
			this.ultraTextEditor1.Visible = false;
			// 
			// cmReplaceColumn
			// 
			this.cmReplaceColumn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceToolStripMenuItem,
            this.remapToolStripMenuItem});
			this.cmReplaceColumn.Name = "contextMenuStrip1";
			this.cmReplaceColumn.Size = new System.Drawing.Size(124, 48);
			// 
			// replaceToolStripMenuItem
			// 
			this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
			this.replaceToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.replaceToolStripMenuItem.Text = "Replace";
			this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
			// 
			// remapToolStripMenuItem
			// 
			this.remapToolStripMenuItem.Name = "remapToolStripMenuItem";
			this.remapToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.remapToolStripMenuItem.Text = "Remap";
			this.remapToolStripMenuItem.Click += new System.EventHandler(this.remapToolStripMenuItem_Click);
			// 
			// ultraToolTipManager1
			// 
			this.ultraToolTipManager1.ContainingControl = this;
			// 
			// ucTreeView1
			// 
			this.ucTreeView1.BackColor = System.Drawing.Color.White;
			this.ucTreeView1.EnableCheckboxes = false;
			this.ucTreeView1.ID = "";
			this.ucTreeView1.Location = new System.Drawing.Point(553, 90);
			this.ucTreeView1.Name = "ucTreeView1";
			this.ucTreeView1.ShowAllNames = false;
			this.ucTreeView1.ShowBEONumber = true;
			this.ucTreeView1.ShowDisabled = false;
			this.ucTreeView1.ShowPrice = false;
			this.ucTreeView1.Size = new System.Drawing.Size(329, 179);
			this.ucTreeView1.TabIndex = 7;
			this.ucTreeView1.TypeCatalogID = "0";
			this.ucTreeView1.TypeName = "";
			this.ucTreeView1.Visible = false;
			this.ucTreeView1.TreeViewIDChanged += new UserControls.UCTreeView.TreeViewIDChangedEventHandler(this.ucTreeView1_TreeViewIDChanged);
			// 
			// ucEditTransfer1
			// 
			this.ucEditTransfer1.BackColor = System.Drawing.Color.White;
			this.ucEditTransfer1.Location = new System.Drawing.Point(207, 102);
			this.ucEditTransfer1.Name = "ucEditTransfer1";
			this.ucEditTransfer1.Size = new System.Drawing.Size(370, 155);
			this.ucEditTransfer1.TabIndex = 8;
			this.ucEditTransfer1.Visible = false;
			this.ucEditTransfer1.SavePressed += new UserControls.UCEditTransfer.SavePressedEventHandler(this.ucEditTransfer1_SavePressed);
			this.ucEditTransfer1.CancelPressed += new UserControls.UCEditTransfer.CancelPressedEventHandler(this.ucEditTransfer1_CancelPressed);
			// 
			// dtpStamp
			// 
			this.dtpStamp.Location = new System.Drawing.Point(451, 263);
			this.dtpStamp.Name = "dtpStamp";
			this.dtpStamp.Size = new System.Drawing.Size(294, 20);
			this.dtpStamp.TabIndex = 3;
			this.dtpStamp.Value = new System.DateTime(2008, 4, 3, 10, 44, 37, 0);
			this.dtpStamp.Visible = false;
			this.dtpStamp.ValueChanged += new UserControls.SmartDateTimePicker.ValueChangedEventHandler(this.dtpStamp_ValueChanged);
			this.dtpStamp.EnterPressed += new UserControls.SmartDateTimePicker.EnterPressedEventHandler(this.dtpStamp_EnterPressed);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.label1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(748, 45);
			this.panel3.TabIndex = 4;
			// 
			// UCViewWeights
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ultraTextEditor1);
			this.Controls.Add(this.ucTreeView1);
			this.Controls.Add(this.ucEditTransfer1);
			this.Controls.Add(this.gridViewWaste);
			this.Controls.Add(this.ultraGridColumnChooser1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.dtpStamp);
			this.Controls.Add(this.panel1);
			this.Name = "UCViewWeights";
			this.Size = new System.Drawing.Size(748, 443);
			this.Load += new System.EventHandler(this.UCViewWeights_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraTransferEditor)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGridColumnChooser1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewWaste)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
			this.cmReplaceColumn.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveView;
        private System.Windows.Forms.Button btnColumnChooser;
        private System.Windows.Forms.Button btnPrint;
        private SmartDateTimePicker dtpStamp;
        private Infragistics.Win.Printing.UltraPrintPreviewDialog ultraPrintPreviewDlg;
        private Infragistics.Win.UltraWinGrid.UltraGridPrintDocument ultraGridPrintDocument1;
        private System.Windows.Forms.Panel panel2;
        private Infragistics.Win.UltraWinGrid.UltraGridColumnChooser ultraGridColumnChooser1;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridViewWaste;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnLoadView;
        private UCTreeView ucTreeView1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
        private System.Windows.Forms.ContextMenuStrip cmReplaceColumn;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remapToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboSite;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter ultraGridDocumentExporter1;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTransferEditor;
        private UCEditTransfer ucEditTransfer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXMLExport;
		private System.Windows.Forms.Panel panel3;

    }
}

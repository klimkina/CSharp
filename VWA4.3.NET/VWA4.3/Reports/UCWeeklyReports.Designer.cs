namespace Reports
{
    partial class UCWeeklyReports
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
			Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.lblSerieName = new System.Windows.Forms.Label();
			this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.panel4 = new System.Windows.Forms.Panel();
			this.ultraCalendarCombo1 = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
			this.btnDone = new System.Windows.Forms.Button();
			this.btnPDF = new System.Windows.Forms.Button();
			this.btnPrintReportSet = new System.Windows.Forms.Button();
			this.btnViewReportSet = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraCalendarCombo1)).BeginInit();
			this.panel2.SuspendLayout();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.lblSerieName);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(518, 69);
			this.panel1.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Sienna;
			this.label3.Location = new System.Drawing.Point(3, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(326, 35);
			this.label3.TabIndex = 10;
			this.label3.Text = "Print Weekly Reports";
			// 
			// lblSerieName
			// 
			this.lblSerieName.AutoSize = true;
			this.lblSerieName.Location = new System.Drawing.Point(6, 49);
			this.lblSerieName.Name = "lblSerieName";
			this.lblSerieName.Size = new System.Drawing.Size(201, 13);
			this.lblSerieName.TabIndex = 9;
			this.lblSerieName.Text = "Report Collection name is displayed here.";
			// 
			// ultraGrid1
			// 
			appearance28.BackColor = System.Drawing.SystemColors.Window;
			appearance28.BorderColor = System.Drawing.SystemColors.InactiveCaption;
			this.ultraGrid1.DisplayLayout.Appearance = appearance28;
			this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			appearance25.BackColor = System.Drawing.SystemColors.ActiveBorder;
			appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance25.BorderColor = System.Drawing.SystemColors.Window;
			this.ultraGrid1.DisplayLayout.GroupByBox.Appearance = appearance25;
			appearance26.ForeColor = System.Drawing.SystemColors.GrayText;
			this.ultraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance26;
			this.ultraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			appearance27.BackColor = System.Drawing.SystemColors.ControlLightLight;
			appearance27.BackColor2 = System.Drawing.SystemColors.Control;
			appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance27.ForeColor = System.Drawing.SystemColors.GrayText;
			this.ultraGrid1.DisplayLayout.GroupByBox.PromptAppearance = appearance27;
			this.ultraGrid1.DisplayLayout.MaxColScrollRegions = 1;
			this.ultraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
			appearance36.BackColor = System.Drawing.SystemColors.Window;
			appearance36.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ultraGrid1.DisplayLayout.Override.ActiveCellAppearance = appearance36;
			appearance31.BackColor = System.Drawing.SystemColors.Highlight;
			appearance31.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.ultraGrid1.DisplayLayout.Override.ActiveRowAppearance = appearance31;
			this.ultraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
			this.ultraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
			appearance30.BackColor = System.Drawing.SystemColors.Window;
			this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance30;
			appearance29.BorderColor = System.Drawing.Color.Silver;
			appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
			this.ultraGrid1.DisplayLayout.Override.CellAppearance = appearance29;
			this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
			this.ultraGrid1.DisplayLayout.Override.CellPadding = 0;
			appearance33.BackColor = System.Drawing.SystemColors.Control;
			appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
			appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance33.BorderColor = System.Drawing.SystemColors.Window;
			this.ultraGrid1.DisplayLayout.Override.GroupByRowAppearance = appearance33;
			appearance35.TextHAlignAsString = "Left";
			this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance35;
			this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			this.ultraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
			appearance34.BackColor = System.Drawing.SystemColors.Window;
			appearance34.BorderColor = System.Drawing.Color.Silver;
			this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance34;
			this.ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			appearance32.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ultraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance32;
			this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
			this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ultraGrid1.Location = new System.Drawing.Point(0, 23);
			this.ultraGrid1.Name = "ultraGrid1";
			this.ultraGrid1.Size = new System.Drawing.Size(518, 235);
			this.ultraGrid1.TabIndex = 2;
			this.ultraGrid1.Text = "ultraGrid1";
			this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
			this.ultraGrid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.ultraGrid1_DoubleClickRow);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.ultraCalendarCombo1);
			this.panel4.Controls.Add(this.btnDone);
			this.panel4.Controls.Add(this.btnPDF);
			this.panel4.Controls.Add(this.btnPrintReportSet);
			this.panel4.Controls.Add(this.btnViewReportSet);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(0, 258);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(518, 55);
			this.panel4.TabIndex = 1;
			// 
			// ultraCalendarCombo1
			// 
			this.ultraCalendarCombo1.DateButtons.Add(dateButton1);
			this.ultraCalendarCombo1.Location = new System.Drawing.Point(197, 24);
			this.ultraCalendarCombo1.Name = "ultraCalendarCombo1";
			this.ultraCalendarCombo1.NonAutoSizeHeight = 21;
			this.ultraCalendarCombo1.Size = new System.Drawing.Size(119, 21);
			this.ultraCalendarCombo1.TabIndex = 19;
			this.ultraCalendarCombo1.Visible = false;
			// 
			// btnDone
			// 
			this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDone.Location = new System.Drawing.Point(427, 22);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(75, 23);
			this.btnDone.TabIndex = 15;
			this.btnDone.Text = "Done";
			this.btnDone.UseVisualStyleBackColor = true;
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
			// 
			// btnPDF
			// 
			this.btnPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPDF.Location = new System.Drawing.Point(111, 22);
			this.btnPDF.Name = "btnPDF";
			this.btnPDF.Size = new System.Drawing.Size(47, 23);
			this.btnPDF.TabIndex = 14;
			this.btnPDF.Text = "PDF";
			this.btnPDF.UseVisualStyleBackColor = true;
			this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
			// 
			// btnPrintReportSet
			// 
			this.btnPrintReportSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPrintReportSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnPrintReportSet.Location = new System.Drawing.Point(15, 22);
			this.btnPrintReportSet.Name = "btnPrintReportSet";
			this.btnPrintReportSet.Size = new System.Drawing.Size(47, 23);
			this.btnPrintReportSet.TabIndex = 13;
			this.btnPrintReportSet.Text = "Print";
			this.btnPrintReportSet.UseVisualStyleBackColor = true;
			this.btnPrintReportSet.Click += new System.EventHandler(this.btnPrintReportSet_Click);
			// 
			// btnViewReportSet
			// 
			this.btnViewReportSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnViewReportSet.Location = new System.Drawing.Point(63, 22);
			this.btnViewReportSet.Name = "btnViewReportSet";
			this.btnViewReportSet.Size = new System.Drawing.Size(47, 23);
			this.btnViewReportSet.TabIndex = 12;
			this.btnViewReportSet.Text = "View";
			this.btnViewReportSet.UseVisualStyleBackColor = true;
			this.btnViewReportSet.Click += new System.EventHandler(this.btnViewReportSet_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(518, 23);
			this.panel2.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Reports:";
			// 
			// MainPanel
			// 
			this.MainPanel.Controls.Add(this.ultraGrid1);
			this.MainPanel.Controls.Add(this.panel4);
			this.MainPanel.Controls.Add(this.panel2);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 69);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(518, 313);
			this.MainPanel.TabIndex = 0;
			// 
			// UCWeeklyReports
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.MainPanel);
			this.Controls.Add(this.panel1);
			this.Name = "UCWeeklyReports";
			this.Size = new System.Drawing.Size(518, 382);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraCalendarCombo1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.MainPanel.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel MainPanel;
        //private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        //private System.Windows.Forms.Label label5;
        //private UserControls.UCSiteChooser ucSiteChooser1;
        private System.Windows.Forms.Label lblSerieName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnPrintReportSet;
        private System.Windows.Forms.Button btnViewReportSet;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDone;
        //private System.Windows.Forms.Button btnCancel;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo ultraCalendarCombo1;
    }
}

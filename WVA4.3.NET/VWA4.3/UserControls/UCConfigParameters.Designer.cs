namespace UserControls
{
    partial class UCConfigParameters
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
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ultraGrid1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(292, 266);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Configurations Included:";
			// 
			// ultraGrid1
			// 
			appearance4.BackColor = System.Drawing.SystemColors.Window;
			appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
			this.ultraGrid1.DisplayLayout.Appearance = appearance4;
			this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			appearance1.BackColor = System.Drawing.SystemColors.ActiveBorder;
			appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance1.BorderColor = System.Drawing.SystemColors.Window;
			this.ultraGrid1.DisplayLayout.GroupByBox.Appearance = appearance1;
			appearance2.ForeColor = System.Drawing.SystemColors.GrayText;
			this.ultraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance2;
			this.ultraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			appearance3.BackColor2 = System.Drawing.SystemColors.Control;
			appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
			this.ultraGrid1.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
			this.ultraGrid1.DisplayLayout.MaxColScrollRegions = 1;
			this.ultraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
			appearance12.BackColor = System.Drawing.SystemColors.Window;
			appearance12.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ultraGrid1.DisplayLayout.Override.ActiveCellAppearance = appearance12;
			appearance7.BackColor = System.Drawing.SystemColors.Highlight;
			appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.ultraGrid1.DisplayLayout.Override.ActiveRowAppearance = appearance7;
			this.ultraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
			this.ultraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
			appearance6.BackColor = System.Drawing.SystemColors.Window;
			this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance6;
			appearance5.BorderColor = System.Drawing.Color.Silver;
			appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
			this.ultraGrid1.DisplayLayout.Override.CellAppearance = appearance5;
			this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
			this.ultraGrid1.DisplayLayout.Override.CellPadding = 0;
			appearance9.BackColor = System.Drawing.SystemColors.Control;
			appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
			appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance9.BorderColor = System.Drawing.SystemColors.Window;
			this.ultraGrid1.DisplayLayout.Override.GroupByRowAppearance = appearance9;
			appearance11.TextHAlignAsString = "Left";
			this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance11;
			this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			this.ultraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
			appearance10.BackColor = System.Drawing.SystemColors.Window;
			appearance10.BorderColor = System.Drawing.Color.Silver;
			this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance10;
			this.ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			appearance8.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ultraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance8;
			this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
			this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ultraGrid1.Location = new System.Drawing.Point(3, 16);
			this.ultraGrid1.Name = "ultraGrid1";
			this.ultraGrid1.Size = new System.Drawing.Size(286, 247);
			this.ultraGrid1.TabIndex = 0;
			this.ultraGrid1.Text = "ultraGrid1";
			this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
			this.ultraGrid1.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ultraGrid1_InitializeRow);
			this.ultraGrid1.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ultraGrid1_CellChange);
			// 
			// UCConfigParameters
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Name = "UCConfigParameters";
			this.Size = new System.Drawing.Size(292, 266);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;

	}
}

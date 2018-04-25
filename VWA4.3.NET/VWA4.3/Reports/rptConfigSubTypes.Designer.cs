namespace Reports
{
    /// <summary>
    /// Summary description for rptConfigSubTypes.
    /// </summary>
    partial class rptConfigSubTypes
    {
        private DataDynamics.ActiveReports.Detail detail;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptConfigSubTypes));
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.txtName = new DataDynamics.ActiveReports.TextBox();
            this.txtID = new DataDynamics.ActiveReports.TextBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.txtReportName = new DataDynamics.ActiveReports.TextBox();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.txtSpanishTypeName = new DataDynamics.ActiveReports.TextBox();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.txtCost = new DataDynamics.ActiveReports.TextBox();
            this.txtWeight = new DataDynamics.ActiveReports.TextBox();
            this.txtEnabled = new DataDynamics.ActiveReports.TextBox();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.txtModifiedDate = new DataDynamics.ActiveReports.TextBox();
            this.txtDescription = new DataDynamics.ActiveReports.TextBox();
            this.txtCostLabel = new DataDynamics.ActiveReports.TextBox();
            this.txtVolumeWeight = new DataDynamics.ActiveReports.TextBox();
            this.txtEventDateLabel = new DataDynamics.ActiveReports.TextBox();
            this.txtGuestCountLabel = new DataDynamics.ActiveReports.TextBox();
            this.txtEventDate = new DataDynamics.ActiveReports.TextBox();
            this.txtGuestCount = new DataDynamics.ActiveReports.TextBox();
            this.txtMaleRatioLabel = new DataDynamics.ActiveReports.TextBox();
            this.txtMaleRatio = new DataDynamics.ActiveReports.TextBox();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.txtEnabledLabel = new DataDynamics.ActiveReports.TextBox();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.txtMenu = new DataDynamics.ActiveReports.Label();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReportName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpanishTypeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModifiedDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCostLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVolumeWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEventDateLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGuestCountLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEventDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGuestCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaleRatioLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaleRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnabledLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.CanShrink = true;
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtName,
            this.txtID,
            this.label1,
            this.txtReportName,
            this.label2,
            this.txtSpanishTypeName,
            this.label3,
            this.line2,
            this.line3,
            this.line4,
            this.txtCost,
            this.txtWeight,
            this.txtEnabled,
            this.label7,
            this.txtModifiedDate,
            this.txtDescription,
            this.txtCostLabel,
            this.txtVolumeWeight,
            this.txtEventDateLabel,
            this.txtGuestCountLabel,
            this.txtEventDate,
            this.txtGuestCount,
            this.txtMaleRatioLabel,
            this.txtMaleRatio,
            this.line1,
            this.txtEnabledLabel});
            this.detail.Height = 1.395833F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // txtName
            // 
            this.txtName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.RightColor = System.Drawing.Color.Black;
            this.txtName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.TopColor = System.Drawing.Color.Black;
            this.txtName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.DataField = "TypeName";
            this.txtName.Height = 0.1875F;
            this.txtName.Left = 0.125F;
            this.txtName.Name = "txtName";
            this.txtName.Style = "font-weight: bold; ";
            this.txtName.Text = "textBox1";
            this.txtName.Top = 0F;
            this.txtName.Width = 2.875F;
            // 
            // txtID
            // 
            this.txtID.Border.BottomColor = System.Drawing.Color.Black;
            this.txtID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtID.Border.LeftColor = System.Drawing.Color.Black;
            this.txtID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtID.Border.RightColor = System.Drawing.Color.Black;
            this.txtID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtID.Border.TopColor = System.Drawing.Color.Black;
            this.txtID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtID.DataField = "TypeID";
            this.txtID.Height = 0.1875F;
            this.txtID.Left = 3.0625F;
            this.txtID.Name = "txtID";
            this.txtID.Style = "font-weight: bold; ";
            this.txtID.Text = "textBox2";
            this.txtID.Top = 0F;
            this.txtID.Width = 2.9375F;
            // 
            // label1
            // 
            this.label1.Border.BottomColor = System.Drawing.Color.Black;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftColor = System.Drawing.Color.Black;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightColor = System.Drawing.Color.Black;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopColor = System.Drawing.Color.Black;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Height = 0.1875F;
            this.label1.HyperLink = null;
            this.label1.Left = 0.125F;
            this.label1.Name = "label1";
            this.label1.Style = "";
            this.label1.Text = "ReportTypeName:  ";
            this.label1.Top = 0.25F;
            this.label1.Width = 1.25F;
            // 
            // txtReportName
            // 
            this.txtReportName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtReportName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReportName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtReportName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReportName.Border.RightColor = System.Drawing.Color.Black;
            this.txtReportName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReportName.Border.TopColor = System.Drawing.Color.Black;
            this.txtReportName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReportName.DataField = "ReportTypeName";
            this.txtReportName.Height = 0.1875F;
            this.txtReportName.Left = 1.4375F;
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Style = "";
            this.txtReportName.Text = "textBox1";
            this.txtReportName.Top = 0.25F;
            this.txtReportName.Width = 1.5625F;
            // 
            // label2
            // 
            this.label2.Border.BottomColor = System.Drawing.Color.Black;
            this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.LeftColor = System.Drawing.Color.Black;
            this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.RightColor = System.Drawing.Color.Black;
            this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.TopColor = System.Drawing.Color.Black;
            this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Height = 0.1875F;
            this.label2.HyperLink = null;
            this.label2.Left = 3.0625F;
            this.label2.Name = "label2";
            this.label2.Style = "";
            this.label2.Text = "SpanishTypeName: ";
            this.label2.Top = 0.25F;
            this.label2.Width = 1.3125F;
            // 
            // txtSpanishTypeName
            // 
            this.txtSpanishTypeName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSpanishTypeName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpanishTypeName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSpanishTypeName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpanishTypeName.Border.RightColor = System.Drawing.Color.Black;
            this.txtSpanishTypeName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpanishTypeName.Border.TopColor = System.Drawing.Color.Black;
            this.txtSpanishTypeName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpanishTypeName.DataField = "SpanishTypeName";
            this.txtSpanishTypeName.Height = 0.1875F;
            this.txtSpanishTypeName.Left = 4.4375F;
            this.txtSpanishTypeName.Name = "txtSpanishTypeName";
            this.txtSpanishTypeName.Style = "";
            this.txtSpanishTypeName.Text = "textBox2";
            this.txtSpanishTypeName.Top = 0.25F;
            this.txtSpanishTypeName.Width = 1.5625F;
            // 
            // label3
            // 
            this.label3.Border.BottomColor = System.Drawing.Color.Black;
            this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.LeftColor = System.Drawing.Color.Black;
            this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.RightColor = System.Drawing.Color.Black;
            this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.TopColor = System.Drawing.Color.Black;
            this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Height = 0.1979167F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.125F;
            this.label3.Name = "label3";
            this.label3.Style = "font-weight: bold; ";
            this.label3.Text = "Description:";
            this.label3.Top = 0.5F;
            this.label3.Width = 1.0625F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0F;
            this.line2.Left = 0.0625F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0.4375F;
            this.line2.Width = 6.375F;
            this.line2.X1 = 0.0625F;
            this.line2.X2 = 6.4375F;
            this.line2.Y1 = 0.4375F;
            this.line2.Y2 = 0.4375F;
            // 
            // line3
            // 
            this.line3.Border.BottomColor = System.Drawing.Color.Black;
            this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.LeftColor = System.Drawing.Color.Black;
            this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.RightColor = System.Drawing.Color.Black;
            this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.TopColor = System.Drawing.Color.Black;
            this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Height = 0.4375F;
            this.line3.Left = 0.0625F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Width = 0F;
            this.line3.X1 = 0.0625F;
            this.line3.X2 = 0.0625F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0.4375F;
            // 
            // line4
            // 
            this.line4.Border.BottomColor = System.Drawing.Color.Black;
            this.line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.LeftColor = System.Drawing.Color.Black;
            this.line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.RightColor = System.Drawing.Color.Black;
            this.line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.TopColor = System.Drawing.Color.Black;
            this.line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Height = 0.4375F;
            this.line4.Left = 6.4375F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0F;
            this.line4.Width = 0F;
            this.line4.X1 = 6.4375F;
            this.line4.X2 = 6.4375F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0.4375F;
            // 
            // txtCost
            // 
            this.txtCost.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCost.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCost.Border.RightColor = System.Drawing.Color.Black;
            this.txtCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCost.Border.TopColor = System.Drawing.Color.Black;
            this.txtCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCost.CanShrink = true;
            this.txtCost.Height = 0.1979167F;
            this.txtCost.Left = 1.25F;
            this.txtCost.Name = "txtCost";
            this.txtCost.OutputFormat = resources.GetString("txtCost.OutputFormat");
            this.txtCost.Style = "";
            this.txtCost.Text = null;
            this.txtCost.Top = 0.75F;
            this.txtCost.Width = 1F;
            // 
            // txtWeight
            // 
            this.txtWeight.Border.BottomColor = System.Drawing.Color.Black;
            this.txtWeight.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeight.Border.LeftColor = System.Drawing.Color.Black;
            this.txtWeight.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeight.Border.RightColor = System.Drawing.Color.Black;
            this.txtWeight.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeight.Border.TopColor = System.Drawing.Color.Black;
            this.txtWeight.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeight.CanShrink = true;
            this.txtWeight.Height = 0.1979167F;
            this.txtWeight.Left = 1.25F;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.OutputFormat = resources.GetString("txtWeight.OutputFormat");
            this.txtWeight.Style = "";
            this.txtWeight.Text = null;
            this.txtWeight.Top = 0.96875F;
            this.txtWeight.Width = 1F;
            // 
            // txtEnabled
            // 
            this.txtEnabled.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEnabled.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEnabled.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEnabled.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEnabled.Border.RightColor = System.Drawing.Color.Black;
            this.txtEnabled.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEnabled.Border.TopColor = System.Drawing.Color.Black;
            this.txtEnabled.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEnabled.CanShrink = true;
            this.txtEnabled.Height = 0.1979167F;
            this.txtEnabled.Left = 1.25F;
            this.txtEnabled.Name = "txtEnabled";
            this.txtEnabled.Style = "";
            this.txtEnabled.Text = null;
            this.txtEnabled.Top = 1.1875F;
            this.txtEnabled.Width = 1F;
            // 
            // label7
            // 
            this.label7.Border.BottomColor = System.Drawing.Color.Black;
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.LeftColor = System.Drawing.Color.Black;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.RightColor = System.Drawing.Color.Black;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.TopColor = System.Drawing.Color.Black;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Height = 0.1875F;
            this.label7.HyperLink = null;
            this.label7.Left = 4.4375F;
            this.label7.Name = "label7";
            this.label7.Style = "";
            this.label7.Text = "Last Modified:  ";
            this.label7.Top = 0.5F;
            this.label7.Width = 0.9375F;
            // 
            // txtModifiedDate
            // 
            this.txtModifiedDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtModifiedDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtModifiedDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtModifiedDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtModifiedDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtModifiedDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtModifiedDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtModifiedDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtModifiedDate.DataField = "ModifiedDate";
            this.txtModifiedDate.Height = 0.1875F;
            this.txtModifiedDate.Left = 5.4375F;
            this.txtModifiedDate.Name = "txtModifiedDate";
            this.txtModifiedDate.OutputFormat = resources.GetString("txtModifiedDate.OutputFormat");
            this.txtModifiedDate.Style = "";
            this.txtModifiedDate.Text = null;
            this.txtModifiedDate.Top = 0.5F;
            this.txtModifiedDate.Width = 1F;
            // 
            // txtDescription
            // 
            this.txtDescription.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDescription.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescription.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDescription.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescription.Border.RightColor = System.Drawing.Color.Black;
            this.txtDescription.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescription.Border.TopColor = System.Drawing.Color.Black;
            this.txtDescription.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescription.DataField = "Description";
            this.txtDescription.Height = 0.1875F;
            this.txtDescription.Left = 1.25F;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Style = "";
            this.txtDescription.Text = null;
            this.txtDescription.Top = 0.5F;
            this.txtDescription.Width = 3.125F;
            // 
            // txtCostLabel
            // 
            this.txtCostLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCostLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCostLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCostLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCostLabel.Border.RightColor = System.Drawing.Color.Black;
            this.txtCostLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCostLabel.Border.TopColor = System.Drawing.Color.Black;
            this.txtCostLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCostLabel.CanShrink = true;
            this.txtCostLabel.Height = 0.1979167F;
            this.txtCostLabel.Left = 0.125F;
            this.txtCostLabel.Name = "txtCostLabel";
            this.txtCostLabel.Style = "";
            this.txtCostLabel.Text = null;
            this.txtCostLabel.Top = 0.75F;
            this.txtCostLabel.Width = 1.0625F;
            // 
            // txtVolumeWeight
            // 
            this.txtVolumeWeight.Border.BottomColor = System.Drawing.Color.Black;
            this.txtVolumeWeight.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVolumeWeight.Border.LeftColor = System.Drawing.Color.Black;
            this.txtVolumeWeight.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVolumeWeight.Border.RightColor = System.Drawing.Color.Black;
            this.txtVolumeWeight.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVolumeWeight.Border.TopColor = System.Drawing.Color.Black;
            this.txtVolumeWeight.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtVolumeWeight.CanShrink = true;
            this.txtVolumeWeight.Height = 0.1875F;
            this.txtVolumeWeight.Left = 0.125F;
            this.txtVolumeWeight.Name = "txtVolumeWeight";
            this.txtVolumeWeight.Style = "";
            this.txtVolumeWeight.Text = null;
            this.txtVolumeWeight.Top = 0.9739584F;
            this.txtVolumeWeight.Width = 1.0625F;
            // 
            // txtEventDateLabel
            // 
            this.txtEventDateLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEventDateLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEventDateLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEventDateLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEventDateLabel.Border.RightColor = System.Drawing.Color.Black;
            this.txtEventDateLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEventDateLabel.Border.TopColor = System.Drawing.Color.Black;
            this.txtEventDateLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEventDateLabel.CanShrink = true;
            this.txtEventDateLabel.Height = 0.1979167F;
            this.txtEventDateLabel.Left = 2.375F;
            this.txtEventDateLabel.Name = "txtEventDateLabel";
            this.txtEventDateLabel.Style = "";
            this.txtEventDateLabel.Text = null;
            this.txtEventDateLabel.Top = 0.75F;
            this.txtEventDateLabel.Width = 1.0625F;
            // 
            // txtGuestCountLabel
            // 
            this.txtGuestCountLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGuestCountLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGuestCountLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGuestCountLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGuestCountLabel.Border.RightColor = System.Drawing.Color.Black;
            this.txtGuestCountLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGuestCountLabel.Border.TopColor = System.Drawing.Color.Black;
            this.txtGuestCountLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGuestCountLabel.CanShrink = true;
            this.txtGuestCountLabel.Height = 0.1875F;
            this.txtGuestCountLabel.Left = 2.375F;
            this.txtGuestCountLabel.Name = "txtGuestCountLabel";
            this.txtGuestCountLabel.Style = "";
            this.txtGuestCountLabel.Text = null;
            this.txtGuestCountLabel.Top = 0.9739584F;
            this.txtGuestCountLabel.Width = 1.0625F;
            // 
            // txtEventDate
            // 
            this.txtEventDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEventDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEventDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEventDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEventDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtEventDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEventDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtEventDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEventDate.CanShrink = true;
            this.txtEventDate.DataField = "EventDate";
            this.txtEventDate.Height = 0.1979167F;
            this.txtEventDate.Left = 3.5F;
            this.txtEventDate.Name = "txtEventDate";
            this.txtEventDate.OutputFormat = resources.GetString("txtEventDate.OutputFormat");
            this.txtEventDate.Style = "";
            this.txtEventDate.Text = null;
            this.txtEventDate.Top = 0.75F;
            this.txtEventDate.Width = 1F;
            // 
            // txtGuestCount
            // 
            this.txtGuestCount.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGuestCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGuestCount.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGuestCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGuestCount.Border.RightColor = System.Drawing.Color.Black;
            this.txtGuestCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGuestCount.Border.TopColor = System.Drawing.Color.Black;
            this.txtGuestCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGuestCount.CanShrink = true;
            this.txtGuestCount.DataField = "GuestCount";
            this.txtGuestCount.Height = 0.1979167F;
            this.txtGuestCount.Left = 3.5F;
            this.txtGuestCount.Name = "txtGuestCount";
            this.txtGuestCount.OutputFormat = resources.GetString("txtGuestCount.OutputFormat");
            this.txtGuestCount.Style = "";
            this.txtGuestCount.Text = null;
            this.txtGuestCount.Top = 0.96875F;
            this.txtGuestCount.Width = 1F;
            // 
            // txtMaleRatioLabel
            // 
            this.txtMaleRatioLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.txtMaleRatioLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMaleRatioLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.txtMaleRatioLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMaleRatioLabel.Border.RightColor = System.Drawing.Color.Black;
            this.txtMaleRatioLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMaleRatioLabel.Border.TopColor = System.Drawing.Color.Black;
            this.txtMaleRatioLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMaleRatioLabel.CanShrink = true;
            this.txtMaleRatioLabel.Height = 0.1875F;
            this.txtMaleRatioLabel.Left = 2.375F;
            this.txtMaleRatioLabel.Name = "txtMaleRatioLabel";
            this.txtMaleRatioLabel.Style = "";
            this.txtMaleRatioLabel.Text = null;
            this.txtMaleRatioLabel.Top = 1.1875F;
            this.txtMaleRatioLabel.Width = 1.0625F;
            // 
            // txtMaleRatio
            // 
            this.txtMaleRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.txtMaleRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMaleRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.txtMaleRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMaleRatio.Border.RightColor = System.Drawing.Color.Black;
            this.txtMaleRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMaleRatio.Border.TopColor = System.Drawing.Color.Black;
            this.txtMaleRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMaleRatio.CanShrink = true;
            this.txtMaleRatio.DataField = "MRatio";
            this.txtMaleRatio.Height = 0.1979167F;
            this.txtMaleRatio.Left = 3.5F;
            this.txtMaleRatio.Name = "txtMaleRatio";
            this.txtMaleRatio.OutputFormat = resources.GetString("txtMaleRatio.OutputFormat");
            this.txtMaleRatio.Style = "";
            this.txtMaleRatio.Text = null;
            this.txtMaleRatio.Top = 1.1875F;
            this.txtMaleRatio.Width = 1F;
            // 
            // line1
            // 
            this.line1.Border.BottomColor = System.Drawing.Color.Black;
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftColor = System.Drawing.Color.Black;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightColor = System.Drawing.Color.Black;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopColor = System.Drawing.Color.Black;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Height = 0F;
            this.line1.Left = 0.0625F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0F;
            this.line1.Width = 6.375F;
            this.line1.X1 = 0.0625F;
            this.line1.X2 = 6.4375F;
            this.line1.Y1 = 0F;
            this.line1.Y2 = 0F;
            // 
            // txtEnabledLabel
            // 
            this.txtEnabledLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEnabledLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEnabledLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEnabledLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEnabledLabel.Border.RightColor = System.Drawing.Color.Black;
            this.txtEnabledLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEnabledLabel.Border.TopColor = System.Drawing.Color.Black;
            this.txtEnabledLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEnabledLabel.CanShrink = true;
            this.txtEnabledLabel.Height = 0.1875F;
            this.txtEnabledLabel.Left = 0.125F;
            this.txtEnabledLabel.Name = "txtEnabledLabel";
            this.txtEnabledLabel.Style = "";
            this.txtEnabledLabel.Text = null;
            this.txtEnabledLabel.Top = 1.1875F;
            this.txtEnabledLabel.Width = 1.0625F;
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtMenu});
            this.groupHeader1.Height = 0.1875F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // txtMenu
            // 
            this.txtMenu.Border.BottomColor = System.Drawing.Color.Black;
            this.txtMenu.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMenu.Border.LeftColor = System.Drawing.Color.Black;
            this.txtMenu.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMenu.Border.RightColor = System.Drawing.Color.Black;
            this.txtMenu.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMenu.Border.TopColor = System.Drawing.Color.Black;
            this.txtMenu.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtMenu.DataField = "LicensedSite";
            this.txtMenu.Height = 0.1875F;
            this.txtMenu.HyperLink = null;
            this.txtMenu.Left = 0.0625F;
            this.txtMenu.Name = "txtMenu";
            this.txtMenu.Style = "color: White; text-align: left; font-weight: normal; background-color: IndianRed;" +
                " font-size: 10pt; vertical-align: middle; ";
            this.txtMenu.Text = "";
            this.txtMenu.Top = 0F;
            this.txtMenu.Width = 6.375F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.CanShrink = true;
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // rptConfigSubTypes
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.75F;
            this.PageSettings.Margins.Left = 0.75F;
            this.PageSettings.Margins.Right = 0.75F;
            this.PageSettings.Margins.Top = 0.75F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 6.489583F;
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport.FetchEventHandler(this.rptConfigSubTypes_FetchData);
            this.ReportStart += new System.EventHandler(this.rptConfigSubTypes_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReportName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpanishTypeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModifiedDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCostLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVolumeWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEventDateLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGuestCountLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEventDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGuestCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaleRatioLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaleRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnabledLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.Label txtMenu;
        private DataDynamics.ActiveReports.Line line1;
        private DataDynamics.ActiveReports.TextBox txtName;
        private DataDynamics.ActiveReports.TextBox txtID;
        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.TextBox txtReportName;
        private DataDynamics.ActiveReports.Label label2;
        private DataDynamics.ActiveReports.TextBox txtSpanishTypeName;
        private DataDynamics.ActiveReports.Label label3;
        private DataDynamics.ActiveReports.Line line2;
        private DataDynamics.ActiveReports.Line line3;
        private DataDynamics.ActiveReports.Line line4;
        private DataDynamics.ActiveReports.TextBox txtCost;
        private DataDynamics.ActiveReports.TextBox txtWeight;
        private DataDynamics.ActiveReports.TextBox txtEnabled;
        private DataDynamics.ActiveReports.Label label7;
        private DataDynamics.ActiveReports.TextBox txtModifiedDate;
        private DataDynamics.ActiveReports.TextBox txtDescription;
        private DataDynamics.ActiveReports.TextBox txtCostLabel;
        private DataDynamics.ActiveReports.TextBox txtVolumeWeight;
        private DataDynamics.ActiveReports.TextBox txtEventDateLabel;
        private DataDynamics.ActiveReports.TextBox txtGuestCountLabel;
        private DataDynamics.ActiveReports.TextBox txtEventDate;
        private DataDynamics.ActiveReports.TextBox txtGuestCount;
        private DataDynamics.ActiveReports.TextBox txtMaleRatioLabel;
        private DataDynamics.ActiveReports.TextBox txtMaleRatio;
        private DataDynamics.ActiveReports.TextBox txtEnabledLabel;
    }
}

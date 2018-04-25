namespace Reports
{
    /// <summary>
    /// Summary description for rptEmployee.
    /// </summary>
    partial class rptEmployee
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptEmployee));
            DataDynamics.ActiveReports.DataSources.OleDBDataSource oleDBDataSource1 = new DataDynamics.ActiveReports.DataSources.OleDBDataSource();
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.txtPeriod = new DataDynamics.ActiveReports.TextBox();
            this.txtOrder = new DataDynamics.ActiveReports.TextBox();
            this.imgLogo = new DataDynamics.ActiveReports.Picture();
            this.txtSubTitle = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.lblRank = new DataDynamics.ActiveReports.Label();
            this.txtName = new DataDynamics.ActiveReports.TextBox();
            this.txtWeight = new DataDynamics.ActiveReports.TextBox();
            this.txtCount = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.txtFilter = new DataDynamics.ActiveReports.TextBox();
            this.imgLeanPath = new DataDynamics.ActiveReports.Picture();
            this.lblDB = new DataDynamics.ActiveReports.TextBox();
            this.ghEmployee = new DataDynamics.ActiveReports.GroupHeader();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.txtError = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTitle,
            this.label7,
            this.label5,
            this.txtPeriod,
            this.txtOrder,
            this.imgLogo,
            this.txtSubTitle});
            this.pageHeader.Height = 0.9270833F;
            this.pageHeader.Name = "pageHeader";
            // 
            // lblTitle
            // 
            this.lblTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.RightColor = System.Drawing.Color.Black;
            this.lblTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.TopColor = System.Drawing.Color.Black;
            this.lblTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Height = 0.3125F;
            this.lblTitle.HyperLink = null;
            this.lblTitle.Left = 0.0625F;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Style = "color: White; text-align: center; font-weight: bold; background-color: IndianRed;" +
                " font-size: 16pt; vertical-align: middle; ";
            this.lblTitle.Text = "Employee Report";
            this.lblTitle.Top = 0F;
            this.lblTitle.Width = 8.6875F;
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
            this.label7.Left = 0.5F;
            this.label7.Name = "label7";
            this.label7.Style = "";
            this.label7.Text = "Ranked by: ";
            this.label7.Top = 0.73F;
            this.label7.Width = 0.75F;
            // 
            // label5
            // 
            this.label5.Border.BottomColor = System.Drawing.Color.Black;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.LeftColor = System.Drawing.Color.Black;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightColor = System.Drawing.Color.Black;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopColor = System.Drawing.Color.Black;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Height = 0.1875F;
            this.label5.HyperLink = null;
            this.label5.Left = 0.0625F;
            this.label5.Name = "label5";
            this.label5.Style = "";
            this.label5.Text = "Reporting Period: ";
            this.label5.Top = 0.54F;
            this.label5.Width = 1.1875F;
            // 
            // txtPeriod
            // 
            this.txtPeriod.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPeriod.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriod.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPeriod.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriod.Border.RightColor = System.Drawing.Color.Black;
            this.txtPeriod.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriod.Border.TopColor = System.Drawing.Color.Black;
            this.txtPeriod.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriod.Height = 0.1875F;
            this.txtPeriod.Left = 1.25F;
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Style = "";
            this.txtPeriod.Text = "textBox1";
            this.txtPeriod.Top = 0.54F;
            this.txtPeriod.Width = 7.5F;
            // 
            // txtOrder
            // 
            this.txtOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.txtOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.txtOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOrder.Border.RightColor = System.Drawing.Color.Black;
            this.txtOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOrder.Border.TopColor = System.Drawing.Color.Black;
            this.txtOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOrder.Height = 0.1875F;
            this.txtOrder.Left = 1.25F;
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Style = "";
            this.txtOrder.Text = "textBox1";
            this.txtOrder.Top = 0.73F;
            this.txtOrder.Width = 7.5F;
            // 
            // imgLogo
            // 
            this.imgLogo.Border.BottomColor = System.Drawing.Color.Black;
            this.imgLogo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLogo.Border.LeftColor = System.Drawing.Color.Black;
            this.imgLogo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLogo.Border.RightColor = System.Drawing.Color.Black;
            this.imgLogo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLogo.Border.TopColor = System.Drawing.Color.Black;
            this.imgLogo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLogo.Height = 0.32F;
            this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
            this.imgLogo.ImageData = ((System.IO.Stream)(resources.GetObject("imgLogo.ImageData")));
            this.imgLogo.Left = 0.0625F;
            this.imgLogo.LineWeight = 0F;
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.imgLogo.Top = 0F;
            this.imgLogo.Width = 0.625F;
            // 
            // txtSubTitle
            // 
            this.txtSubTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTitle.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTitle.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTitle.CanShrink = true;
            this.txtSubTitle.Height = 0.1875F;
            this.txtSubTitle.Left = 0F;
            this.txtSubTitle.Name = "txtSubTitle";
            this.txtSubTitle.Style = "text-align: center; ";
            this.txtSubTitle.Text = null;
            this.txtSubTitle.Top = 0.34F;
            this.txtSubTitle.Width = 8.75F;
            // 
            // detail
            // 
            this.detail.ColumnCount = 3;
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblRank,
            this.txtName,
            this.txtWeight,
            this.txtCount});
            this.detail.Height = 0.1979167F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // lblRank
            // 
            this.lblRank.Border.BottomColor = System.Drawing.Color.Black;
            this.lblRank.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRank.Border.LeftColor = System.Drawing.Color.Black;
            this.lblRank.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRank.Border.RightColor = System.Drawing.Color.Black;
            this.lblRank.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRank.Border.TopColor = System.Drawing.Color.Black;
            this.lblRank.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRank.Height = 0.1875F;
            this.lblRank.HyperLink = null;
            this.lblRank.Left = 0.125F;
            this.lblRank.Name = "lblRank";
            this.lblRank.Style = "";
            this.lblRank.Text = "Rank";
            this.lblRank.Top = 0F;
            this.lblRank.Width = 0.1875F;
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
            this.txtName.DataField = "Name";
            this.txtName.Height = 0.1875F;
            this.txtName.Left = 0.375F;
            this.txtName.Name = "txtName";
            this.txtName.Style = "";
            this.txtName.Text = "textBox1";
            this.txtName.Top = 0F;
            this.txtName.Width = 1.375F;
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
            this.txtWeight.CanGrow = false;
            this.txtWeight.DataField = "WasteWeight";
            this.txtWeight.Height = 0.1875F;
            this.txtWeight.Left = 2.375F;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.OutputFormat = resources.GetString("txtWeight.OutputFormat");
            this.txtWeight.Style = "text-align: right; font-weight: bold; ";
            this.txtWeight.Text = "None";
            this.txtWeight.Top = 0F;
            this.txtWeight.Width = 0.5625F;
            // 
            // txtCount
            // 
            this.txtCount.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCount.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCount.Border.RightColor = System.Drawing.Color.Black;
            this.txtCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCount.Border.TopColor = System.Drawing.Color.Black;
            this.txtCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCount.DataField = "WasteCount";
            this.txtCount.Height = 0.1875F;
            this.txtCount.Left = 1.8125F;
            this.txtCount.Name = "txtCount";
            this.txtCount.OutputFormat = resources.GetString("txtCount.OutputFormat");
            this.txtCount.Style = "text-align: right; font-weight: bold; ";
            this.txtCount.Text = "0";
            this.txtCount.Top = 0F;
            this.txtCount.Width = 0.5F;
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtFilter,
            this.imgLeanPath,
            this.lblDB});
            this.pageFooter.Height = 0.3854167F;
            this.pageFooter.Name = "pageFooter";
            // 
            // txtFilter
            // 
            this.txtFilter.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFilter.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFilter.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFilter.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFilter.Border.RightColor = System.Drawing.Color.Black;
            this.txtFilter.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFilter.Border.TopColor = System.Drawing.Color.Black;
            this.txtFilter.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFilter.Height = 0.1875F;
            this.txtFilter.Left = 0F;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Style = "font-size: 8pt; ";
            this.txtFilter.Text = "textBox1";
            this.txtFilter.Top = 0F;
            this.txtFilter.Width = 8.0625F;
            // 
            // imgLeanPath
            // 
            this.imgLeanPath.Border.BottomColor = System.Drawing.Color.Black;
            this.imgLeanPath.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLeanPath.Border.LeftColor = System.Drawing.Color.Black;
            this.imgLeanPath.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLeanPath.Border.RightColor = System.Drawing.Color.Black;
            this.imgLeanPath.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLeanPath.Border.TopColor = System.Drawing.Color.Black;
            this.imgLeanPath.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.imgLeanPath.Height = 0.3125F;
            this.imgLeanPath.Image = ((System.Drawing.Image)(resources.GetObject("imgLeanPath.Image")));
            this.imgLeanPath.ImageData = ((System.IO.Stream)(resources.GetObject("imgLeanPath.ImageData")));
            this.imgLeanPath.Left = 8.125F;
            this.imgLeanPath.LineWeight = 0F;
            this.imgLeanPath.Name = "imgLeanPath";
            this.imgLeanPath.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.imgLeanPath.Top = 0.0625F;
            this.imgLeanPath.Width = 0.625F;
            // 
            // lblDB
            // 
            this.lblDB.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDB.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDB.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDB.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDB.Border.RightColor = System.Drawing.Color.Black;
            this.lblDB.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDB.Border.TopColor = System.Drawing.Color.Black;
            this.lblDB.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDB.Height = 0.1875F;
            this.lblDB.Left = 0F;
            this.lblDB.Name = "lblDB";
            this.lblDB.Style = "font-size: 8pt; ";
            this.lblDB.Text = null;
            this.lblDB.Top = 0.1875F;
            this.lblDB.Width = 8.0625F;
            // 
            // ghEmployee
            // 
            this.ghEmployee.ColumnGroupKeepTogether = true;
            this.ghEmployee.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label2,
            this.label1,
            this.label4,
            this.label3});
            this.ghEmployee.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.ghEmployee.Height = 0.3645833F;
            this.ghEmployee.Name = "ghEmployee";
            this.ghEmployee.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnColumn;
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
            this.label2.Left = 0.375F;
            this.label2.Name = "label2";
            this.label2.Style = "color: Navy; font-weight: bold; ";
            this.label2.Text = "Employee";
            this.label2.Top = 0F;
            this.label2.Width = 1.3125F;
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
            this.label1.Left = 0F;
            this.label1.Name = "label1";
            this.label1.Style = "color: Navy; font-weight: bold; ";
            this.label1.Text = "Rank";
            this.label1.Top = 0F;
            this.label1.Width = 0.375F;
            // 
            // label4
            // 
            this.label4.Border.BottomColor = System.Drawing.Color.Black;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.LeftColor = System.Drawing.Color.Black;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightColor = System.Drawing.Color.Black;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopColor = System.Drawing.Color.Black;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Height = 0.1875F;
            this.label4.HyperLink = null;
            this.label4.Left = 1.75F;
            this.label4.Name = "label4";
            this.label4.Style = "color: Navy; font-weight: bold; ";
            this.label4.Text = "Count";
            this.label4.Top = 0F;
            this.label4.Width = 0.5F;
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
            this.label3.Height = 0.375F;
            this.label3.HyperLink = null;
            this.label3.Left = 2.3125F;
            this.label3.Name = "label3";
            this.label3.Style = "color: Navy; font-weight: bold; ";
            this.label3.Text = "Total Weight";
            this.label3.Top = 0F;
            this.label3.Width = 0.625F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label6,
            this.textBox2,
            this.line1,
            this.txtError});
            this.groupFooter1.Height = 0.4791667F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // label6
            // 
            this.label6.Border.BottomColor = System.Drawing.Color.Black;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.LeftColor = System.Drawing.Color.Black;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.RightColor = System.Drawing.Color.Black;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.TopColor = System.Drawing.Color.Black;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Height = 0.1875F;
            this.label6.HyperLink = null;
            this.label6.Left = 0.0625F;
            this.label6.Name = "label6";
            this.label6.Style = "font-weight: bold; vertical-align: middle; ";
            this.label6.Text = "Total Weight for All Employee: ";
            this.label6.Top = 0.25F;
            this.label6.Width = 2.0625F;
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.DataField = "WasteWeight";
            this.textBox2.Height = 0.1875F;
            this.textBox2.Left = 2.125F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "text-align: right; font-weight: bold; ";
            this.textBox2.SummaryGroup = "ghEmployee";
            this.textBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox2.Text = "textBox2";
            this.textBox2.Top = 0.25F;
            this.textBox2.Width = 0.8125F;
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
            this.line1.Top = 0.25F;
            this.line1.Width = 2.875F;
            this.line1.X1 = 0.0625F;
            this.line1.X2 = 2.9375F;
            this.line1.Y1 = 0.25F;
            this.line1.Y2 = 0.25F;
            // 
            // txtError
            // 
            this.txtError.Border.BottomColor = System.Drawing.Color.Black;
            this.txtError.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtError.Border.LeftColor = System.Drawing.Color.Black;
            this.txtError.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtError.Border.RightColor = System.Drawing.Color.Black;
            this.txtError.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtError.Border.TopColor = System.Drawing.Color.Black;
            this.txtError.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtError.CanShrink = true;
            this.txtError.Height = 0.1875F;
            this.txtError.Left = 0.0625F;
            this.txtError.Name = "txtError";
            this.txtError.Style = "color: Red; ";
            this.txtError.Text = null;
            this.txtError.Top = 0F;
            this.txtError.Width = 2.875F;
            // 
            // rptEmployee
            // 
            this.MasterReport = false;
			//oleDBDataSource1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Mila\\Projects\\WVA40\\AccessD" +
			//    "Bs\\vwa40dev-fix.mdb;Persist Security Info=False";
			//oleDBDataSource1.SQL = resources.GetString("oleDBDataSource1.SQL");
			//this.DataSource = oleDBDataSource1;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.75F;
            this.PageSettings.Margins.Left = 0.75F;
            this.PageSettings.Margins.Right = 0.75F;
            this.PageSettings.Margins.Top = 0.75F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 8.854167F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.ghEmployee);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rptEmployee_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Label lblRank;
        private DataDynamics.ActiveReports.TextBox txtName;
        private DataDynamics.ActiveReports.TextBox txtWeight;
        private DataDynamics.ActiveReports.TextBox txtFilter;
        private DataDynamics.ActiveReports.TextBox txtCount;
        private DataDynamics.ActiveReports.Label label5;
        private DataDynamics.ActiveReports.TextBox txtPeriod;
        private DataDynamics.ActiveReports.Label label7;
        private DataDynamics.ActiveReports.TextBox txtOrder;
        private DataDynamics.ActiveReports.GroupHeader ghEmployee;
        private DataDynamics.ActiveReports.Label label2;
        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.Label label4;
        private DataDynamics.ActiveReports.Label label3;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.Label label6;
        private DataDynamics.ActiveReports.TextBox textBox2;
        private DataDynamics.ActiveReports.Line line1;
        private DataDynamics.ActiveReports.TextBox txtError;
        private DataDynamics.ActiveReports.Picture imgLogo;
        private DataDynamics.ActiveReports.Label lblTitle;
        private DataDynamics.ActiveReports.TextBox txtSubTitle;
        private DataDynamics.ActiveReports.Picture imgLeanPath;
        private DataDynamics.ActiveReports.TextBox lblDB;
    }
}

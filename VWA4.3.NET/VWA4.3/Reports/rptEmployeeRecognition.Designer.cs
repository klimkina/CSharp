namespace Reports
{
    /// <summary>
    /// Summary description for rptEmployeeRecognition.
    /// </summary>
    partial class rptEmployeeRecognition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptEmployeeRecognition));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.imgLogo = new DataDynamics.ActiveReports.Picture();
            this.txtSubTitle = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.line12 = new DataDynamics.ActiveReports.Line();
            this.txtCriteria = new DataDynamics.ActiveReports.TextBox();
            this.txtAward = new DataDynamics.ActiveReports.TextBox();
            this.txtWeek = new DataDynamics.ActiveReports.TextBox();
            this.txtUser = new DataDynamics.ActiveReports.TextBox();
            this.line18 = new DataDynamics.ActiveReports.Line();
            this.line23 = new DataDynamics.ActiveReports.Line();
            this.line24 = new DataDynamics.ActiveReports.Line();
            this.line25 = new DataDynamics.ActiveReports.Line();
            this.line27 = new DataDynamics.ActiveReports.Line();
            this.line29 = new DataDynamics.ActiveReports.Line();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.line14 = new DataDynamics.ActiveReports.Line();
            this.line15 = new DataDynamics.ActiveReports.Line();
            this.line16 = new DataDynamics.ActiveReports.Line();
            this.line17 = new DataDynamics.ActiveReports.Line();
            this.line19 = new DataDynamics.ActiveReports.Line();
            this.line20 = new DataDynamics.ActiveReports.Line();
            this.line22 = new DataDynamics.ActiveReports.Line();
            this.txtSite = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.txtPeriods = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.lblFooter = new DataDynamics.ActiveReports.TextBox();
            this.lblWarning = new DataDynamics.ActiveReports.TextBox();
            this.lblDB = new DataDynamics.ActiveReports.TextBox();
            this.imgLeanPath = new DataDynamics.ActiveReports.Picture();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.gpTable = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCriteria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.CanShrink = true;
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTitle,
            this.imgLogo,
            this.txtSubTitle});
            this.pageHeader.Height = 0.5104167F;
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
            this.lblTitle.Left = 0F;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Style = "color: White; text-align: center; font-weight: bold; background-color: IndianRed;" +
                " font-size: 16pt; vertical-align: middle; ";
            this.lblTitle.Text = "Employee Recognition Report";
            this.lblTitle.Top = 0F;
            this.lblTitle.Width = 6.6875F;
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
            this.imgLogo.Height = 0.3125F;
            this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
            this.imgLogo.ImageData = ((System.IO.Stream)(resources.GetObject("imgLogo.ImageData")));
            this.imgLogo.Left = 0F;
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
            this.txtSubTitle.Top = 0.3125F;
            this.txtSubTitle.Width = 6.6875F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line8,
            this.line12,
            this.txtCriteria,
            this.txtAward,
            this.txtWeek,
            this.txtUser,
            this.line18,
            this.line23,
            this.line24,
            this.line25,
            this.line27,
            this.line29});
            this.detail.Height = 0.2604167F;
            this.detail.Name = "detail";
            // 
            // line8
            // 
            this.line8.Border.BottomColor = System.Drawing.Color.Black;
            this.line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.LeftColor = System.Drawing.Color.Black;
            this.line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.RightColor = System.Drawing.Color.Black;
            this.line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.TopColor = System.Drawing.Color.Black;
            this.line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Height = 0F;
            this.line8.Left = 0.0625F;
            this.line8.LineWeight = 1F;
            this.line8.Name = "line8";
            this.line8.Top = 1.1875F;
            this.line8.Width = 0F;
            this.line8.X1 = 0.0625F;
            this.line8.X2 = 0.0625F;
            this.line8.Y1 = 1.1875F;
            this.line8.Y2 = 1.1875F;
            // 
            // line12
            // 
            this.line12.Border.BottomColor = System.Drawing.Color.Black;
            this.line12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.LeftColor = System.Drawing.Color.Black;
            this.line12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.RightColor = System.Drawing.Color.Black;
            this.line12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.TopColor = System.Drawing.Color.Black;
            this.line12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Height = 0F;
            this.line12.Left = 0.0625F;
            this.line12.LineWeight = 1F;
            this.line12.Name = "line12";
            this.line12.Top = 1.1875F;
            this.line12.Width = 0F;
            this.line12.X1 = 0.0625F;
            this.line12.X2 = 0.0625F;
            this.line12.Y1 = 1.1875F;
            this.line12.Y2 = 1.1875F;
            // 
            // txtCriteria
            // 
            this.txtCriteria.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCriteria.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCriteria.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCriteria.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCriteria.Border.RightColor = System.Drawing.Color.Black;
            this.txtCriteria.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCriteria.Border.TopColor = System.Drawing.Color.Black;
            this.txtCriteria.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCriteria.DataField = "AwardReason";
            this.txtCriteria.Height = 0.1875F;
            this.txtCriteria.Left = 3.75F;
            this.txtCriteria.Name = "txtCriteria";
            this.txtCriteria.Style = "vertical-align: bottom; ";
            this.txtCriteria.Text = "textBox21";
            this.txtCriteria.Top = 0F;
            this.txtCriteria.Width = 2.9375F;
            // 
            // txtAward
            // 
            this.txtAward.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAward.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAward.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAward.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAward.Border.RightColor = System.Drawing.Color.Black;
            this.txtAward.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAward.Border.TopColor = System.Drawing.Color.Black;
            this.txtAward.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAward.DataField = "AwardType";
            this.txtAward.Height = 0.1875F;
            this.txtAward.Left = 2.3125F;
            this.txtAward.Name = "txtAward";
            this.txtAward.OutputFormat = resources.GetString("txtAward.OutputFormat");
            this.txtAward.Style = "text-align: center; vertical-align: bottom; ";
            this.txtAward.Text = "textBox20";
            this.txtAward.Top = 0F;
            this.txtAward.Width = 1.375F;
            // 
            // txtWeek
            // 
            this.txtWeek.Border.BottomColor = System.Drawing.Color.Black;
            this.txtWeek.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeek.Border.LeftColor = System.Drawing.Color.Black;
            this.txtWeek.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeek.Border.RightColor = System.Drawing.Color.Black;
            this.txtWeek.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeek.Border.TopColor = System.Drawing.Color.Black;
            this.txtWeek.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeek.DataField = "WeekStart";
            this.txtWeek.Height = 0.1875F;
            this.txtWeek.Left = 0.125F;
            this.txtWeek.Name = "txtWeek";
            this.txtWeek.OutputFormat = resources.GetString("txtWeek.OutputFormat");
            this.txtWeek.Style = "vertical-align: bottom; ";
            this.txtWeek.Text = "textBox18";
            this.txtWeek.Top = 0F;
            this.txtWeek.Width = 0.8125F;
            // 
            // txtUser
            // 
            this.txtUser.Border.BottomColor = System.Drawing.Color.Black;
            this.txtUser.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtUser.Border.LeftColor = System.Drawing.Color.Black;
            this.txtUser.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtUser.Border.RightColor = System.Drawing.Color.Black;
            this.txtUser.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtUser.Border.TopColor = System.Drawing.Color.Black;
            this.txtUser.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtUser.DataField = "UserName";
            this.txtUser.Height = 0.1875F;
            this.txtUser.Left = 1F;
            this.txtUser.Name = "txtUser";
            this.txtUser.OutputFormat = resources.GetString("txtUser.OutputFormat");
            this.txtUser.Style = "text-align: center; vertical-align: bottom; ";
            this.txtUser.Text = "textBox19";
            this.txtUser.Top = 0F;
            this.txtUser.Width = 1.25F;
            // 
            // line18
            // 
            this.line18.AnchorBottom = true;
            this.line18.Border.BottomColor = System.Drawing.Color.Black;
            this.line18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Border.LeftColor = System.Drawing.Color.Black;
            this.line18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Border.RightColor = System.Drawing.Color.Black;
            this.line18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Border.TopColor = System.Drawing.Color.Black;
            this.line18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Height = 0.25F;
            this.line18.Left = 0.0625F;
            this.line18.LineWeight = 1F;
            this.line18.Name = "line18";
            this.line18.Top = 0F;
            this.line18.Width = 0F;
            this.line18.X1 = 0.0625F;
            this.line18.X2 = 0.0625F;
            this.line18.Y1 = 0F;
            this.line18.Y2 = 0.25F;
            // 
            // line23
            // 
            this.line23.AnchorBottom = true;
            this.line23.Border.BottomColor = System.Drawing.Color.Black;
            this.line23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Border.LeftColor = System.Drawing.Color.Black;
            this.line23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Border.RightColor = System.Drawing.Color.Black;
            this.line23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Border.TopColor = System.Drawing.Color.Black;
            this.line23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Height = 0.25F;
            this.line23.Left = 0.9375F;
            this.line23.LineWeight = 1F;
            this.line23.Name = "line23";
            this.line23.Top = 0F;
            this.line23.Width = 0F;
            this.line23.X1 = 0.9375F;
            this.line23.X2 = 0.9375F;
            this.line23.Y1 = 0F;
            this.line23.Y2 = 0.25F;
            // 
            // line24
            // 
            this.line24.AnchorBottom = true;
            this.line24.Border.BottomColor = System.Drawing.Color.Black;
            this.line24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.LeftColor = System.Drawing.Color.Black;
            this.line24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.RightColor = System.Drawing.Color.Black;
            this.line24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.TopColor = System.Drawing.Color.Black;
            this.line24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Height = 0.25F;
            this.line24.Left = 2.25F;
            this.line24.LineWeight = 1F;
            this.line24.Name = "line24";
            this.line24.Top = 0F;
            this.line24.Width = 0F;
            this.line24.X1 = 2.25F;
            this.line24.X2 = 2.25F;
            this.line24.Y1 = 0F;
            this.line24.Y2 = 0.25F;
            // 
            // line25
            // 
            this.line25.AnchorBottom = true;
            this.line25.Border.BottomColor = System.Drawing.Color.Black;
            this.line25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Border.LeftColor = System.Drawing.Color.Black;
            this.line25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Border.RightColor = System.Drawing.Color.Black;
            this.line25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Border.TopColor = System.Drawing.Color.Black;
            this.line25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Height = 0.25F;
            this.line25.Left = 3.6875F;
            this.line25.LineWeight = 1F;
            this.line25.Name = "line25";
            this.line25.Top = 0F;
            this.line25.Width = 0F;
            this.line25.X1 = 3.6875F;
            this.line25.X2 = 3.6875F;
            this.line25.Y1 = 0F;
            this.line25.Y2 = 0.25F;
            // 
            // line27
            // 
            this.line27.AnchorBottom = true;
            this.line27.Border.BottomColor = System.Drawing.Color.Black;
            this.line27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Border.LeftColor = System.Drawing.Color.Black;
            this.line27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Border.RightColor = System.Drawing.Color.Black;
            this.line27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Border.TopColor = System.Drawing.Color.Black;
            this.line27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Height = 0.25F;
            this.line27.Left = 6.6875F;
            this.line27.LineWeight = 1F;
            this.line27.Name = "line27";
            this.line27.Top = 0F;
            this.line27.Width = 0F;
            this.line27.X1 = 6.6875F;
            this.line27.X2 = 6.6875F;
            this.line27.Y1 = 0F;
            this.line27.Y2 = 0.25F;
            // 
            // line29
            // 
            this.line29.Border.BottomColor = System.Drawing.Color.Black;
            this.line29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line29.Border.LeftColor = System.Drawing.Color.Black;
            this.line29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line29.Border.RightColor = System.Drawing.Color.Black;
            this.line29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line29.Border.TopColor = System.Drawing.Color.Black;
            this.line29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line29.Height = 0F;
            this.line29.Left = 0.0625F;
            this.line29.LineWeight = 1F;
            this.line29.Name = "line29";
            this.line29.Top = 0.25F;
            this.line29.Width = 6.625F;
            this.line29.X1 = 0.0625F;
            this.line29.X2 = 6.6875F;
            this.line29.Y1 = 0.25F;
            this.line29.Y2 = 0.25F;
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
            this.label2.Left = 1F;
            this.label2.Name = "label2";
            this.label2.Style = "color: Black; text-align: center; font-weight: bold; ";
            this.label2.Text = "Employee";
            this.label2.Top = 0F;
            this.label2.Width = 1.1875F;
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
            this.label1.Style = "color: Black; text-align: center; font-weight: bold; ";
            this.label1.Text = "Week";
            this.label1.Top = 0F;
            this.label1.Width = 0.75F;
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
            this.label4.Left = 2.3125F;
            this.label4.Name = "label4";
            this.label4.Style = "color: Black; text-align: center; font-weight: bold; ";
            this.label4.Text = "Award";
            this.label4.Top = 0F;
            this.label4.Width = 1.3125F;
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
            this.label3.Height = 0.1875F;
            this.label3.HyperLink = null;
            this.label3.Left = 3.75F;
            this.label3.Name = "label3";
            this.label3.Style = "color: Black; text-align: center; font-weight: bold; ";
            this.label3.Text = "Criteria";
            this.label3.Top = 0F;
            this.label3.Width = 2.875F;
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
            this.label7.Left = 0.0625F;
            this.label7.Name = "label7";
            this.label7.Style = "color: Black; text-align: left; font-weight: bold; ";
            this.label7.Text = "Employee Awards: ";
            this.label7.Top = 0.5F;
            this.label7.Width = 3.9375F;
            // 
            // line14
            // 
            this.line14.Border.BottomColor = System.Drawing.Color.Black;
            this.line14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.LeftColor = System.Drawing.Color.Black;
            this.line14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.RightColor = System.Drawing.Color.Black;
            this.line14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.TopColor = System.Drawing.Color.Black;
            this.line14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Height = 0F;
            this.line14.Left = 0.0625F;
            this.line14.LineWeight = 1F;
            this.line14.Name = "line14";
            this.line14.Top = 0F;
            this.line14.Width = 6.625F;
            this.line14.X1 = 0.0625F;
            this.line14.X2 = 6.6875F;
            this.line14.Y1 = 0F;
            this.line14.Y2 = 0F;
            // 
            // line15
            // 
            this.line15.Border.BottomColor = System.Drawing.Color.Black;
            this.line15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Border.LeftColor = System.Drawing.Color.Black;
            this.line15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Border.RightColor = System.Drawing.Color.Black;
            this.line15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Border.TopColor = System.Drawing.Color.Black;
            this.line15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Height = 0F;
            this.line15.Left = 0.0625F;
            this.line15.LineWeight = 1F;
            this.line15.Name = "line15";
            this.line15.Top = 0.1875F;
            this.line15.Width = 6.625F;
            this.line15.X1 = 0.0625F;
            this.line15.X2 = 6.6875F;
            this.line15.Y1 = 0.1875F;
            this.line15.Y2 = 0.1875F;
            // 
            // line16
            // 
            this.line16.AnchorBottom = true;
            this.line16.Border.BottomColor = System.Drawing.Color.Black;
            this.line16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Border.LeftColor = System.Drawing.Color.Black;
            this.line16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Border.RightColor = System.Drawing.Color.Black;
            this.line16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Border.TopColor = System.Drawing.Color.Black;
            this.line16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Height = 0.1875F;
            this.line16.Left = 0.0625F;
            this.line16.LineWeight = 1F;
            this.line16.Name = "line16";
            this.line16.Top = 0F;
            this.line16.Width = 0F;
            this.line16.X1 = 0.0625F;
            this.line16.X2 = 0.0625F;
            this.line16.Y1 = 0F;
            this.line16.Y2 = 0.1875F;
            // 
            // line17
            // 
            this.line17.AnchorBottom = true;
            this.line17.Border.BottomColor = System.Drawing.Color.Black;
            this.line17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.LeftColor = System.Drawing.Color.Black;
            this.line17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.RightColor = System.Drawing.Color.Black;
            this.line17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.TopColor = System.Drawing.Color.Black;
            this.line17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Height = 0.1875F;
            this.line17.Left = 0.9375F;
            this.line17.LineWeight = 1F;
            this.line17.Name = "line17";
            this.line17.Top = 0F;
            this.line17.Width = 0F;
            this.line17.X1 = 0.9375F;
            this.line17.X2 = 0.9375F;
            this.line17.Y1 = 0F;
            this.line17.Y2 = 0.1875F;
            // 
            // line19
            // 
            this.line19.AnchorBottom = true;
            this.line19.Border.BottomColor = System.Drawing.Color.Black;
            this.line19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.LeftColor = System.Drawing.Color.Black;
            this.line19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.RightColor = System.Drawing.Color.Black;
            this.line19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.TopColor = System.Drawing.Color.Black;
            this.line19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Height = 0.1875F;
            this.line19.Left = 2.25F;
            this.line19.LineWeight = 1F;
            this.line19.Name = "line19";
            this.line19.Top = 0F;
            this.line19.Width = 0F;
            this.line19.X1 = 2.25F;
            this.line19.X2 = 2.25F;
            this.line19.Y1 = 0F;
            this.line19.Y2 = 0.1875F;
            // 
            // line20
            // 
            this.line20.AnchorBottom = true;
            this.line20.Border.BottomColor = System.Drawing.Color.Black;
            this.line20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Border.LeftColor = System.Drawing.Color.Black;
            this.line20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Border.RightColor = System.Drawing.Color.Black;
            this.line20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Border.TopColor = System.Drawing.Color.Black;
            this.line20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Height = 0.1875F;
            this.line20.Left = 3.6875F;
            this.line20.LineWeight = 1F;
            this.line20.Name = "line20";
            this.line20.Top = 0F;
            this.line20.Width = 0F;
            this.line20.X1 = 3.6875F;
            this.line20.X2 = 3.6875F;
            this.line20.Y1 = 0F;
            this.line20.Y2 = 0.1875F;
            // 
            // line22
            // 
            this.line22.AnchorBottom = true;
            this.line22.Border.BottomColor = System.Drawing.Color.Black;
            this.line22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Border.LeftColor = System.Drawing.Color.Black;
            this.line22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Border.RightColor = System.Drawing.Color.Black;
            this.line22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Border.TopColor = System.Drawing.Color.Black;
            this.line22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Height = 0.1875F;
            this.line22.Left = 6.6875F;
            this.line22.LineWeight = 1F;
            this.line22.Name = "line22";
            this.line22.Top = 0F;
            this.line22.Width = 0F;
            this.line22.X1 = 6.6875F;
            this.line22.X2 = 6.6875F;
            this.line22.Y1 = 0F;
            this.line22.Y2 = 0.1875F;
            // 
            // txtSite
            // 
            this.txtSite.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSite.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSite.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSite.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSite.Border.RightColor = System.Drawing.Color.Black;
            this.txtSite.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSite.Border.TopColor = System.Drawing.Color.Black;
            this.txtSite.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSite.Height = 0.1875F;
            this.txtSite.Left = 1.3125F;
            this.txtSite.Name = "txtSite";
            this.txtSite.Style = "font-weight: bold; ";
            this.txtSite.Text = "textBox2";
            this.txtSite.Top = 0F;
            this.txtSite.Width = 5.375F;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightColor = System.Drawing.Color.Black;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopColor = System.Drawing.Color.Black;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Height = 0.1875F;
            this.textBox5.Left = 0.0625F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "font-weight: bold; ";
            this.textBox5.Text = "ReportingPeriod:";
            this.textBox5.Top = 0.1875F;
            this.textBox5.Width = 1.1875F;
            // 
            // txtPeriods
            // 
            this.txtPeriods.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPeriods.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriods.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPeriods.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriods.Border.RightColor = System.Drawing.Color.Black;
            this.txtPeriods.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriods.Border.TopColor = System.Drawing.Color.Black;
            this.txtPeriods.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPeriods.Height = 0.1875F;
            this.txtPeriods.Left = 1.3125F;
            this.txtPeriods.Name = "txtPeriods";
            this.txtPeriods.Style = "";
            this.txtPeriods.Text = null;
            this.txtPeriods.Top = 0.1875F;
            this.txtPeriods.Width = 5.375F;
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 0.0625F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-weight: bold; ";
            this.textBox1.Text = "Facility: ";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 1.1875F;
            // 
            // pageFooter
            // 
            this.pageFooter.CanShrink = true;
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblFooter,
            this.lblWarning,
            this.lblDB,
            this.imgLeanPath});
            this.pageFooter.Height = 0.6458333F;
            this.pageFooter.Name = "pageFooter";
            // 
            // lblFooter
            // 
            this.lblFooter.Border.BottomColor = System.Drawing.Color.Black;
            this.lblFooter.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFooter.Border.LeftColor = System.Drawing.Color.Black;
            this.lblFooter.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFooter.Border.RightColor = System.Drawing.Color.Black;
            this.lblFooter.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFooter.Border.TopColor = System.Drawing.Color.Black;
            this.lblFooter.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFooter.Height = 0.1875F;
            this.lblFooter.Left = 0F;
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Style = "font-size: 8pt; ";
            this.lblFooter.Text = null;
            this.lblFooter.Top = 0F;
            this.lblFooter.Width = 5.9375F;
            // 
            // lblWarning
            // 
            this.lblWarning.Border.BottomColor = System.Drawing.Color.Black;
            this.lblWarning.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblWarning.Border.LeftColor = System.Drawing.Color.Black;
            this.lblWarning.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblWarning.Border.RightColor = System.Drawing.Color.Black;
            this.lblWarning.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblWarning.Border.TopColor = System.Drawing.Color.Black;
            this.lblWarning.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblWarning.Height = 0.1875F;
            this.lblWarning.Left = 0F;
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Style = "font-size: 8pt; ";
            this.lblWarning.Text = null;
            this.lblWarning.Top = 0.21875F;
            this.lblWarning.Width = 5.9375F;
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
            this.lblDB.Top = 0.4375F;
            this.lblDB.Width = 5.9375F;
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
            this.imgLeanPath.Height = 0.375F;
            this.imgLeanPath.Image = ((System.Drawing.Image)(resources.GetObject("imgLeanPath.Image")));
            this.imgLeanPath.ImageData = ((System.IO.Stream)(resources.GetObject("imgLeanPath.ImageData")));
            this.imgLeanPath.Left = 6F;
            this.imgLeanPath.LineWeight = 0F;
            this.imgLeanPath.Name = "imgLeanPath";
            this.imgLeanPath.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.imgLeanPath.Top = 0.25F;
            this.imgLeanPath.Width = 0.6875F;
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.textBox5,
            this.txtPeriods,
            this.txtSite,
            this.label7});
            this.groupHeader1.Height = 0.6875F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // gpTable
            // 
            this.gpTable.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.label2,
            this.label4,
            this.label3,
            this.line14,
            this.line15,
            this.line16,
            this.line17,
            this.line19,
            this.line20,
            this.line22});
            this.gpTable.Height = 0.2083333F;
            this.gpTable.Name = "gpTable";
            // 
            // groupFooter2
            // 
            this.groupFooter2.Height = 0F;
            this.groupFooter2.Name = "groupFooter2";
            // 
            // rptEmployeeRecognition
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.75F;
            this.PageSettings.Margins.Left = 0.75F;
            this.PageSettings.Margins.Right = 0.75F;
            this.PageSettings.Margins.Top = 0.75F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 6.885417F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.gpTable);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter2);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rptEmployeeRecognition_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCriteria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeanPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Label lblTitle;
        private DataDynamics.ActiveReports.Picture imgLogo;
        private DataDynamics.ActiveReports.TextBox txtSubTitle;
        private DataDynamics.ActiveReports.Label label2;
        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.Label label4;
        private DataDynamics.ActiveReports.Label label3;
        private DataDynamics.ActiveReports.Label label7;
        private DataDynamics.ActiveReports.Line line14;
        private DataDynamics.ActiveReports.Line line15;
        private DataDynamics.ActiveReports.Line line16;
        private DataDynamics.ActiveReports.Line line17;
        private DataDynamics.ActiveReports.Line line19;
        private DataDynamics.ActiveReports.Line line20;
        private DataDynamics.ActiveReports.Line line22;
        private DataDynamics.ActiveReports.TextBox txtSite;
        private DataDynamics.ActiveReports.TextBox textBox5;
        private DataDynamics.ActiveReports.TextBox txtPeriods;
        private DataDynamics.ActiveReports.Line line8;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.Line line12;
        private DataDynamics.ActiveReports.TextBox lblFooter;
        private DataDynamics.ActiveReports.TextBox lblWarning;
        private DataDynamics.ActiveReports.TextBox lblDB;
        private DataDynamics.ActiveReports.Picture imgLeanPath;
        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.TextBox txtCriteria;
        private DataDynamics.ActiveReports.TextBox txtAward;
        private DataDynamics.ActiveReports.TextBox txtWeek;
        private DataDynamics.ActiveReports.TextBox txtUser;
        private DataDynamics.ActiveReports.Line line18;
        private DataDynamics.ActiveReports.Line line23;
        private DataDynamics.ActiveReports.Line line24;
        private DataDynamics.ActiveReports.Line line25;
        private DataDynamics.ActiveReports.Line line27;
        private DataDynamics.ActiveReports.Line line29;
        private DataDynamics.ActiveReports.GroupHeader gpTable;
        private DataDynamics.ActiveReports.GroupFooter groupFooter2;
    }
}

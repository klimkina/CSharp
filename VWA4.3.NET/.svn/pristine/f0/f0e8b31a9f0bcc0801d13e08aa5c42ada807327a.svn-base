using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;

namespace Reports
{
    /// <summary>
    /// Summary description for rptConfigDB.
    /// </summary>
    public partial class rptConfigDB : DataDynamics.ActiveReports.ActiveReport
    {

        public UserControls.ReportParameters _InputParameters;
        bool _IsFirst;
        public rptConfigDB(UserControls.ReportParameters parameters, bool isFirst)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _InputParameters = parameters;
            _IsFirst = isFirst;
        }
		private string GetFileSize(string byteCountString)
		{
			int byteCount = 0;
			int.TryParse(byteCountString, out byteCount);
			string size = "0 Bytes";
			if (byteCount >= 1073741824)
				size = String.Format("{0:##.##}", (double)byteCount / 1073741824) + " GB";
			else if (byteCount >= 1048576)
				size = String.Format("{0:##.##}", (double)byteCount / 1048576) + " MB";
			else if (byteCount >= 1024)
				size = String.Format("{0:##.##}", (double)byteCount / 1024) + " KB";
			else
				size = String.Format("{0:##.##}", byteCount) + " Bytes";
			return size;
		}

        private void AddPageBreak()
        {
            DataDynamics.ActiveReports.PageBreak pageBreak1 = new DataDynamics.ActiveReports.PageBreak();
            // 
            // pageBreak1
            // 
            pageBreak1.Border.BottomColor = System.Drawing.Color.Black;
            pageBreak1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            pageBreak1.Border.LeftColor = System.Drawing.Color.Black;
            pageBreak1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            pageBreak1.Border.RightColor = System.Drawing.Color.Black;
            pageBreak1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            pageBreak1.Border.TopColor = System.Drawing.Color.Black;
            pageBreak1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            pageBreak1.Height = 0.0625F;
            pageBreak1.Left = 0F;
            pageBreak1.Name = "pageBreakDB";
            pageBreak1.Size = new System.Drawing.SizeF(7.125F, 0.0625F);
            pageBreak1.Top = 0F;
            pageBreak1.Width = 7.125F;
            this.groupHeader1.Controls.Add(pageBreak1);
        }

		private void rptConfigDB_ReportStart(object sender, EventArgs e)
		{
            if (!_IsFirst)
                AddPageBreak();
			if (bool.Parse(_InputParameters["Database Statistics"].ParamValue))
			{
				txtDBSize.Text = GetFileSize(new System.IO.FileInfo(VWA4Common.AppContext.DBPathName).Length.ToString());
				DataTable dt = VWA4Common.DB.Retrieve("SELECT MIN(Timestamp) FROM Weights");
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
					txtFirstWasteRecord.Text = DateTime.Parse(dt.Rows[0][0].ToString()).ToString("MM/dd/yyyy");
				dt = VWA4Common.DB.Retrieve("SELECT MAX(Timestamp) FROM Weights");
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
					txtMostRecentWaste.Text = DateTime.Parse(dt.Rows[0][0].ToString()).ToString("MM/dd/yyyy");
				txtNumBEOTypes.Text = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM BEOType").Rows[0][0].ToString();
				txtNumContainerTypes.Text = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM ContainerType").Rows[0][0].ToString();
				txtNumDaypartTypes.Text = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM DaypartType").Rows[0][0].ToString();
				txtNumDispositionTypes.Text = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM DispositionType").Rows[0][0].ToString();
				txtNumFoodTypes.Text = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM FoodType").Rows[0][0].ToString();
				txtNumLossTypes.Text = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM LossType").Rows[0][0].ToString();
				txtNumSites.Text = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM Sites").Rows[0][0].ToString();
				txtNumStationTypes.Text = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM StationType").Rows[0][0].ToString();
				txtNumTrackers.Text = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM Terminals").Rows[0][0].ToString();
				txtNumTransfers.Text = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM Transfers").Rows[0][0].ToString();
				txtNumTypeCatalogs.Text = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM TypeCatalogs").Rows[0][0].ToString();
				txtNumUserTypes.Text = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM UserType").Rows[0][0].ToString();
				txtTotalWaste.Text = VWA4Common.DB.Retrieve("SELECT COUNT(*) FROM Weights").Rows[0][0].ToString();
				txtTotalWasteCost.Text = VWA4Common.DB.Retrieve("SELECT SUM(WasteCost) FROM Weights").Rows[0][0].ToString();
				txtTotalWasteWeight.Text = VWA4Common.DB.Retrieve("SELECT SUM(Weight) FROM Weights").Rows[0][0].ToString();

                this.Document.Printer.Landscape = false;
                this.PrintWidth = this.PageSettings.PaperWidth - (this.PageSettings.Margins.Left + this.PageSettings.Margins.Right);
			//this.PrintWidth = this.PageSettings.PaperHeight - (this.PageSettings.Margins.Top + this.PageSettings.Margins.Bottom); 
			}
			else
				this.Cancel();
		}
    }
}

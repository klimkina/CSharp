using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;

namespace UserControls
{
    public partial class MemorizedReports : Form
    {
        private string _XMLStream = "";
        private string _ReportType = "";

        public string ReportType
        {
            get { return _ReportType; }
            set { _ReportType = value; }
        }
        public MemorizedReports()
        {
            InitializeComponent();
			updateProductUI();
			//_XMLStream = new MemoryStream();
        }
        public MemorizedReports(MemoryStream stream)
        {
            InitializeComponent();
			updateProductUI();
			_ReportType = "View Waste";
            _XMLStream = System.Text.Encoding.UTF8.GetString(stream.ToArray());
            txtReportName.Visible = true;
            lblReports.Text = "EnterReport Name: ";
        }
        public MemorizedReports(string report, bool isSave)
        {
            InitializeComponent();
			updateProductUI();
			_ReportType = report;
            if (isSave)
            {
                txtReportName.Visible = true;
                lblReports.Text = "EnterReport Name: ";
            }
        }

		/// <summary>
		/// Update the Product UI based on global settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void updateProductUI()
		{
			///***********
			/// Product Type
			///***********
			// Form background
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
			// Other stuff
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["ConfigXML"].Hidden = true;
            e.Layout.Bands[0].Columns["ID"].Hidden = true;
            e.Layout.Bands[0].Columns["Title"].CellActivation = Activation.ActivateOnly;
            e.Layout.Bands[0].Columns["Title"].Width = 284;
            this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
        }
        private void MemorizedReports_Load(object sender, EventArgs e)
        {
            this.ultraGrid1.DataSource = VWA4Common.VWADBUtils.MemorizedReports(_ReportType);
        }
        public string ReportName
        { get { return txtReportName.Text; } }
        public MemoryStream ConfigXML()
        {
            if (this.ultraGrid1.ActiveRow != null)
            {
                byte[] bt = System.Text.Encoding.Unicode.GetBytes(this.ultraGrid1.ActiveRow.Cells["ConfigXML"].Value.ToString());
                MemoryStream stream = new MemoryStream(bt, 0, bt.Length);
                return stream;
            }
            return null;
        }
        private int _ID = -1;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Title = "";

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtReportName.Visible)
            {
                if (txtReportName.Text == "" && this.ultraGrid1.ActiveRow != null)
                    txtReportName.Text = this.ultraGrid1.ActiveRow.Cells["Title"].Value.ToString();
                if (txtReportName.Text != "")
                {
                    bool isNew = false;
                    if (this.ultraGrid1.ActiveRow != null && this.ultraGrid1.ActiveRow.Cells["Title"].Value.Equals(txtReportName.Text))
                    {
                        if (MessageBox.Show(this, "This report name already exists! Do you want to replace it?", "Report name input",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                            return;
                    }
                    else
                        isNew = true;
                    _ID = VWA4Common.VWADBUtils.SaveXMLConfig(txtReportName.Text, _ReportType, _XMLStream, isNew);
                    _Title = txtReportName.Text;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    MessageBox.Show(this, "Report name is empty!", "Report name input",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                if(this.ultraGrid1.ActiveRow != null)
                    _ID = int.Parse(this.ultraGrid1.ActiveRow.Cells["ID"].Value.ToString()) ;
        }

        private void txtReportName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (System.Char)Keys.Return)
            {
                this.ultraGrid1.BeginUpdate();
                this.ultraGrid1.Selected.Rows.Clear();
                if(this.ultraGrid1.DisplayLayout.Bands[0].ColumnFilters.Exists("Title"))
                    this.ultraGrid1.DisplayLayout.Bands[0].ColumnFilters["Title"].FilterConditions.Add(FilterComparisionOperator.StartsWith, 
                        txtReportName.Text + e.KeyChar);
                UltraGridRow[] rows = this.ultraGrid1.Rows.GetFilteredInNonGroupByRows();
                if (this.ultraGrid1.DisplayLayout.Bands[0].ColumnFilters.Exists("Title"))
                    this.ultraGrid1.DisplayLayout.Bands[0].ColumnFilters["Title"].FilterConditions.Clear();
                if (rows != null && rows.Length > 0)
                {
                    this.ultraGrid1.ActiveRow = rows[0];
                    foreach(Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
                        row.Selected = true;
                }
                this.ultraGrid1.EndUpdate();
            }
        }

        private void ultraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            txtReportName.Text = ultraGrid1.ActiveRow.Cells["Title"].Value.ToString();
        }
    }
}

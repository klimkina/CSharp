using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using VWA4Common.DAO;
using VWA4Common.DataObject;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinEditors.UltraWinCalc;
using Infragistics.Win.UltraWinListView;

namespace Reports
{
    public partial class frmSeriesProperties : System.Windows.Forms.Form
    {
        public frmSeriesProperties(FormSeries fs)
        {
            InitializeComponent();
			updateProductUI();
			this.lblNameValue.Text += fs.Name;
            this.lblDateCreatedValue.Text += fs.CreateDate.ToShortDateString();
            this.lblLastModifiedDateValue.Text += fs.ModifiedDate.ToShortDateString();

            UltraListView ulvForms = new UltraListView();
            ulvForms.Reset();
            ulvForms.Width = 306;
            ulvForms.Height = 236;
            ulvForms.View = UltraListViewStyle.Details;
            ulvForms.ItemSettings.Appearance.Image = imageList1.Images[0];

            ulvForms.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
            ulvForms.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
            ulvForms.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
            ulvForms.ItemSettings.SelectionType = SelectionType.Single;

            UltraListViewMainColumn mainColumn = ulvForms.MainColumn;
            mainColumn.Text = "Form Name";
            mainColumn.Width = 120;
            mainColumn.DataType = typeof(System.Int32);

            UltraListViewSubItemColumn cDocType = new UltraListViewSubItemColumn();
            cDocType.Text = "Type";
            cDocType.Width = 50;
            cDocType.VisibleInDetailsView = DefaultableBoolean.True;
            cDocType.DataType = typeof(String);

            UltraListViewSubItemColumn cDataEntryTemplate = new UltraListViewSubItemColumn();
            cDataEntryTemplate.Text = "Data Entry Template";
            cDataEntryTemplate.Width = 136;
            cDataEntryTemplate.VisibleInDetailsView = DefaultableBoolean.True;
            cDataEntryTemplate.DataType = typeof(Int32);

            ulvForms.SubItemColumns.Add(cDocType);
            ulvForms.SubItemColumns.Add(cDataEntryTemplate);

            ValueList docType = new ValueList();
            ValueList dataEntryTemplate = new ValueList();

            foreach (VWA4Common.DataObject.Formx f in FormDAO.DAO.GetAllBySeriesId(fs.Id))
            {
                docType.ValueListItems.Add(f.DocumentType, f.DocumentType);
                dataEntryTemplate.ValueListItems.Add(f.DataEntryTemplateId, VWA4Common.DB.Retrieve(string.Format("select DETName from DataEntryTemplates where ID={0}", f.DataEntryTemplateId)).Rows[0]["DETName"].ToString());

                UltraListViewItem i = ulvForms.Items.Add(Guid.NewGuid().ToString(), f.Name);
                i.SubItems[0].Value = f.DocumentType;
                i.SubItems[1].Value = f.DataEntryTemplateId;
            }

            ulvForms.SubItemColumns[0].ValueList = docType;
            ulvForms.SubItemColumns[1].ValueList = dataEntryTemplate;

            this.pnlFormsInSeries.Controls.Add(ulvForms);
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
			// Form header
			pFormHdr.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			lFormTitle.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other stuff
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}

	}
}

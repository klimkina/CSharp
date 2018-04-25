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
    public partial class frmNewSeries : System.Windows.Forms.Form
    {
        private UltraListView ulvForms = new UltraListView();

        private FormSeries formSeries = new FormSeries();

        public frmNewSeries()
        {
            InitializeComponent();
            this.pop();
        }

        public frmNewSeries(FormSeries fs)
        {
            InitializeComponent();
			updateProductUI();
			this.formSeries = fs;
            this.lFormTitle.Text = "Edit Form Series";
            this.pop();
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


        private void loadFormValues()
        {
            this.txtName.Text = formSeries.Name;
        }

        private void pop()
        {
            //pop name
            this.txtName.Text = this.formSeries.Name;
            //load forms
            this.loadForms();
            //event handler
            this.ulvForms.MouseDown += new MouseEventHandler(ulvForms_MouseDown);
        }

        void ulvForms_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    Infragistics.Win.ISelectionManager sm = (sender as UltraListView) as Infragistics.Win.ISelectionManager;
                    UltraListViewItem item = (sender as UltraListView).ItemFromPoint(new Point(e.X, e.Y), true);

                    if (item.CheckState == CheckState.Checked)
                    {
                        item.CheckState = CheckState.Unchecked;
                    }
                    else
                    {
                        item.CheckState = CheckState.Checked;
                    }
                }
                catch (Exception){ }
            }
        }

        private void loadForms()
        {
            ulvForms.Width = 272;
            ulvForms.ViewSettingsDetails.CheckBoxStyle = CheckBoxStyle.CheckBox;
            ulvForms.View = UltraListViewStyle.Details;
            ulvForms.ItemSettings.Appearance.Image = imageList1.Images[0];
            ulvForms.ViewSettingsList.MultiColumn = false;
            ulvForms.Height = 115;
            ulvForms.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
            ulvForms.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
            ulvForms.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
            ulvForms.ItemSettings.SelectionType = SelectionType.Extended;

            UltraListViewMainColumn mainColumn = ulvForms.MainColumn;
            mainColumn.Text = "Name";
            mainColumn.DataType = typeof(System.Int32);

            List<VWA4Common.DataObject.Formx> formsInSeries = FormDAO.DAO.GetAllBySeriesId(this.formSeries.Id);

            foreach (VWA4Common.DataObject.Formx f in FormDAO.DAO.GetAll())
            {
                UltraListViewItem i = ulvForms.Items.Add(f.Id.ToString(), f.Name);

                if (formsInSeries.Find(delegate(VWA4Common.DataObject.Formx frm) { return frm.Id == f.Id; }) != null)
                {
                    this.ulvForms.Items[i.Index].CheckState = CheckState.Checked;
                }
            }

            this.pnlFormSeries.Controls.Add(ulvForms);
            this.ulvForms.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.formSeries.IsNew)
            {
                this.formSeries.Name = this.txtName.Text;

                this.formSeries.Id = FormSeriesDAO.DAO.Insert(this.formSeries);
                if (!this.formSeries.IsNew)
                {
                    for (int i = 0; i < ulvForms.CheckedItems.Count; i++)
                    {
                        FormFormSeries ffs = new FormFormSeries();
                        ffs.FormId = Convert.ToInt32(ulvForms.CheckedItems[i].Key);
                        ffs.FormSeriesId = this.formSeries.Id;
                        ffs.Enabled = true;
                        ffs.NumberOfCopies = 1;

                        FormFormSeriesDAO.DAO.Insert(ffs);
                    }
                }
            }
            else
            {
                this.formSeries.Name = this.txtName.Text;

                FormSeriesDAO.DAO.Update(this.formSeries);
                FormFormSeriesDAO.DAO.ClearAllByFormSeriesId(this.formSeries.Id);
                for (int i = 0; i < ulvForms.CheckedItems.Count; i++)
                {
                    FormFormSeries ffs = new FormFormSeries();
                    ffs.FormId = Convert.ToInt32(ulvForms.CheckedItems[i].Key);
                    ffs.FormSeriesId = this.formSeries.Id;
                    ffs.Enabled = true;
                    ffs.NumberOfCopies = 1;

                    FormFormSeriesDAO.DAO.Insert(ffs);
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

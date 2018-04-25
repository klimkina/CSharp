using System;
using System.IO;
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
    public partial class frmNewForm : System.Windows.Forms.Form
    {
        private OpenFileDialog fd = new OpenFileDialog();
        private VWA4Common.DataObject.Formx form = new VWA4Common.DataObject.Formx();

        private UltraListView ulvDataEntryTemplates = new UltraListView();
        private UltraListView ulvFormSeries = new UltraListView();

        public frmNewForm()
        {
            InitializeComponent();
			updateProductUI();
			this.pop();
        }

        public frmNewForm(VWA4Common.DataObject.Formx f)
        {
            InitializeComponent();
			updateProductUI();
			this.form = f;            
            this.pop();
            this.loadFormValues();
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
            this.txtName.Text = this.form.Name;
            this.lblFormDocumentValue.Text = this.form.FileName;
            //if (!string.IsNullOrEmpty(this.form.SavePath))
            //{
            //    this.ddlSaveDocument.SelectedIndex = 0;
            //}
            //else
            //{
            //    this.ddlSaveDocument.SelectedIndex = 1;
            //}
            for (int i = 0; i < this.ulvFormSeries.Items.Count; i++)
            {
                if (ulvFormSeries.Items[i].Key == this.form.FormSeries.Id.ToString())
                {
                    ulvFormSeries.Items[i].CheckState = CheckState.Checked;
                }
            }
            for (int i = 0; i < this.ulvDataEntryTemplates.Items.Count; i++)
            {
                if (ulvDataEntryTemplates.Items[i].Key == this.form.DataEntryTemplateId.ToString())
                {
                    ulvDataEntryTemplates.Items[i].CheckState = CheckState.Checked;
                }
            }
        }

        private void pop()
        {
            //populate save to list box
            this.ddlSaveDocument.Properties.Items.Add("Forms Folder");
            //this.ddlSaveDocument.Properties.Items.Add("Database");
            this.ddlSaveDocument.SelectedIndex = 0;

            //populate form series
            this.loadFormSeries();

            //load data entry templates
            this.loadDETlistbox();

            //event handlers
            this.ulvDataEntryTemplates.MouseDown += new MouseEventHandler(ulvDataEntryTemplates_MouseDown);
        }

        void ulvDataEntryTemplates_MouseDown(object sender, MouseEventArgs e)
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
                catch (Exception) { }                                              
            }            
        }

        private void loadFormSeries()
        {
            //ulvFormSeries.Width = 285;
            //ulvFormSeries.View = UltraListViewStyle.Details;
            //ulvFormSeries.ItemSettings.Appearance.Image = imageList1.Images[0];
            //ulvFormSeries.ViewSettingsList.MultiColumn = false;
            //ulvFormSeries.Height = 81;
            //ulvFormSeries.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
            //ulvFormSeries.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
            //ulvFormSeries.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
            //ulvFormSeries.ItemSettings.SelectionType = SelectionType.Extended;

            //UltraListViewMainColumn mainColumn = ulvFormSeries.MainColumn;
            //mainColumn.Text = "Name";
            //mainColumn.DataType = typeof(System.Int32);

            //foreach (FormSeries fs in FormSeriesDAO.DAO.GetAll())
            //{
            //    ulvFormSeries.Items.Add(fs.Id.ToString(), fs.Name);
            //}

            //this.pnlFormSeries.Controls.Add(ulvFormSeries);
        }

        private class DataEntryListItem
        {
            public int id = 0;
            public string name = string.Empty;

            public DataEntryListItem(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }

        private void loadDETlistbox()
        {
            ulvDataEntryTemplates.Reset();
            ulvDataEntryTemplates.Width = 285;
            ulvDataEntryTemplates.ViewSettingsDetails.CheckBoxStyle = CheckBoxStyle.CheckBox;
            ulvDataEntryTemplates.View = UltraListViewStyle.Details;
            ulvDataEntryTemplates.ItemSettings.Appearance.Image = imageList1.Images[0];

            ulvDataEntryTemplates.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
            ulvDataEntryTemplates.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
            ulvDataEntryTemplates.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
            ulvDataEntryTemplates.ItemSettings.SelectionType = SelectionType.Single;
            
            UltraListViewMainColumn mainColumn = ulvDataEntryTemplates.MainColumn;
            mainColumn.Text = "Data Entry Template";
            mainColumn.DataType = typeof(System.Int32);

            string sql = @"SELECT ID, DETName FROM DataEntryTemplates ORDER BY DETName ASC";
            DataTable formSetDataTable = new DataTable();
            formSetDataTable = VWA4Common.DB.Retrieve(sql);
            if (formSetDataTable.Rows.Count > 0)
            {
                foreach (DataRow row in formSetDataTable.Rows)
                {
                    detlistitem detitem = new detlistitem();
                    detitem.DETName = row["DETName"].ToString();
                    detitem.ID = (int)row["ID"];
                    UltraListViewItem item =
                        ulvDataEntryTemplates.Items.Add(detitem.ID.ToString(),
                        detitem.DETName);

                    if (row["ID"].ToString().Equals(this.form.DataEntryTemplateId.ToString()))
                    {
                        this.ulvDataEntryTemplates.SelectedItems.Add(item);
                    }
                }
            }
            this.panel2.Controls.Add(ulvDataEntryTemplates);
        }

        private class detlistitem
        {
            public string DETName;
            public int ID;
        }

        public void SaveDataHelper()
        {
            if (form.IsNew)
            {
                System.IO.Stream st = this.fd.OpenFile();

                this.form.Name = this.txtName.Text;
                if (this.ulvDataEntryTemplates.CheckedItems.Count > 0)
                {
                    this.form.DataEntryTemplateId = Convert.ToInt32(this.ulvDataEntryTemplates.CheckedItems[0].Key);
                }
                this.form.FileName = new System.IO.FileInfo(this.fd.FileName).Name;
                this.form.DocumentType = System.IO.Path.GetExtension(this.fd.FileName);
                this.form.DocumentLength = st.Length;

                if (Convert.ToInt32(this.ddlSaveDocument.SelectedIndex) == 0)
                {
                    this.form.SavePath = Path.Combine(Application.StartupPath, "Forms");
                    //save on disk
                    if (!Directory.Exists(this.form.SavePath))
                    {
                        Directory.CreateDirectory(this.form.SavePath);
                    }
                    File.Copy(this.fd.FileName, Path.Combine(this.form.SavePath, this.form.FileName), true);
                }
                else
                {
                    //save to byte array/blob/oleobject in database
                    this.form.DocumentData = File.ReadAllBytes(this.fd.FileName);
                }

                FormDAO.DAO.Insert(this.form);                
            }
            else
            {
                this.form.Name = this.txtName.Text;
                if (this.ulvDataEntryTemplates.CheckedItems.Count > 0)
                {
                    this.form.DataEntryTemplateId = Convert.ToInt32(this.ulvDataEntryTemplates.CheckedItems[0].Key);
                }

                if (!string.IsNullOrEmpty(this.txtPath.Text))
                {
                    System.IO.Stream st = this.fd.OpenFile();

                    this.form.FileName = new System.IO.FileInfo(this.fd.FileName).Name;
                    this.form.DocumentType = System.IO.Path.GetExtension(this.fd.FileName);
                    this.form.DocumentLength = st.Length;

                    if (Convert.ToInt32(this.ddlSaveDocument.SelectedIndex) == 0)
                    {
                        this.form.SavePath = Path.Combine(Application.StartupPath, "Forms");
                        //save on disk
                        if (!Directory.Exists(this.form.SavePath))
                        {
                            Directory.CreateDirectory(this.form.SavePath);
                        }
                        File.Copy(this.fd.FileName, Path.Combine(this.form.SavePath, this.form.FileName), true);

                    }
                    else
                    {
                        //save to byte array/blob/oleobject in database
                        this.form.DocumentData = File.ReadAllBytes(this.fd.FileName);
                    }
                }

                FormDAO.DAO.Update(this.form);
            }

            //if (this.ulvFormSeries.SelectedItems.Count > 0)
            //{
            //    for (int i = 0; i < ulvFormSeries.SelectedItems.Count; i++)
            //    {
            //        FormFormSeriesDAO.DAO.Insert(this.form.Id, (int)ulvFormSeries.SelectedItems[i].Value);
            //    }
            //}
        }
                
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            fd.InitialDirectory = Application.StartupPath;
            fd.Filter = "pdf files (.pdf)|*.pdf|All files (*.*)|*.*";
            fd.FilterIndex = 0;
            fd.Multiselect = false;

            if (fd.ShowDialog().Equals(DialogResult.OK))
            {
                this.txtPath.Text = fd.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveDataHelper();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

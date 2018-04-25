using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using VWA4Common.DAO;
using VWA4Common.DataObject;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinEditors.UltraWinCalc;
using Infragistics.Win.UltraWinListView;

namespace Reports
{
    public partial class UCManageForms : UserControl, UserControls.IVWAUserControlBase
    {
		/// Class level elements
		private bool _IsActive = false;
		VWA4Common.CommonEvents commonEvents = null;
		/// 
		/// Buffers for holding the current Transaction's data
		///
		private OpenFileDialog fd = new OpenFileDialog();
        private VWA4Common.DataObject.Formx form = new VWA4Common.DataObject.Formx();

        object lastMouseDownLocation = Point.Empty;
        private UltraListView ulvFormSeries = new UltraListView();
        private UltraListView ulvForms = new UltraListView();
        private UltraListView ulvPrintSeries = new UltraListView();

        private Point lastMouseDown = new Point();
        private UltraListViewItem dragItem = null;
        private UltraListViewItem dropItem = null;

        private List<FormFormSeries> newFfs = new List<FormFormSeries>();

        private int activePrintSeriesId = 0;
        
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

		/// <summary>
		/// Constructors
		/// </summary>
		public UCManageForms(VWA4Common.DataObject.Formx f)
        {
            this.form = f;
            InitializeComponent();
        }

		public UCManageForms()
        {
            InitializeComponent();
        }
	
		///		
		/// Interface methods for User Controls
		///		
        public void Init(DateTime firstDayOfWeek)
        {
            _IsActive = true;
			commonEvents = VWA4Common.CommonEvents.GetEvents();

            this.ulvForms.AllowDrop = true;
            this.ulvForms.DoubleClick += new EventHandler(btnEditForm_Click);
            this.ulvFormSeries.DoubleClick += new EventHandler(this.btnEditSeries_Click);
            this.ulvForms.Click += new EventHandler(ulvForms_Click);

            this.ulvForms.MouseMove += new MouseEventHandler(ulvForms_MouseMove);
            this.ulvForms.MouseDown += new MouseEventHandler(ulvForms_MouseDown);

            this.ulvFormSeries.MouseDown += new MouseEventHandler(ulvFormSeries_MouseDown);
            this.ulvFormSeries.Click += new EventHandler(ulvFormSeries_Click);

            this.ulvPrintSeries.AllowDrop = true;
            this.ulvPrintSeries.DragOver += new DragEventHandler(ulvPrintSeries_DragOver);
            this.ulvPrintSeries.DragDrop += new DragEventHandler(ulvPrintSeries_DragDrop);
            this.ulvPrintSeries.Click += new EventHandler(ulvPrintSeries_Click);

            this.ulvForms.QueryContinueDrag += new QueryContinueDragEventHandler(ulvForms_QueryContinueDrag);

            this.ulvPrintSeries.MouseDown += new MouseEventHandler(ulvPrintSeries_MouseDown);
			commonEvents.UpdateProductUIData +=
				new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);

            this.pnlPrintSeriesPanel.Visible = false;

            ////populate form series
            this.loadFormSeries();
            //populate forms
            this.loadForms();            
        }

        void ulvFormSeries_Click(object sender, EventArgs e)
        {
            this.newFfs = new List<FormFormSeries>();
            this.btnSeriesProperties.Visible = false;
            this.btnEditFormProperties.Visible = false;
        }

        private void clearPrintSeries()
        {
            this.activePrintSeriesId = 0;
            this.newFfs = new List<FormFormSeries>();
            this.ulvPrintSeries.Reset();
        }

        void ulvPrintSeries_Click(object sender, EventArgs e)
        {
            this.btnSeriesProperties.Visible = true;
            this.btnEditFormProperties.Visible = true;
        }
        
        void ulvForms_Click(object sender, EventArgs e)
        {
            this.clearPrintSeries();
            //hide print series panel
            this.pnlPrintSeriesPanel.Visible = false;
        }
	
		void commonEvents_UpdateProductUI(object sender, EventArgs e)
		{
			InitProductUI();
		}
		
		void InitProductUI()
		{
			panel1.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			labelControl6.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
		}

        void ulvPrintSeries_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point cursorPos = new Point(e.X, e.Y);
                UltraListView listView = sender as UltraListView;
                UltraListViewItem itemAtPoint = listView.ItemFromPoint(cursorPos, true);

                if (itemAtPoint != null)
                {
                    Infragistics.Win.ISelectionManager selectionManager = listView as Infragistics.Win.ISelectionManager;
                    selectionManager.SelectItem(itemAtPoint, true);
                    itemAtPoint.Activate();
                    contextMenuStrip3.Enabled = true;
                    contextMenuStrip3.Show(listView, new Point(e.X, e.Y));
                }
                else
                {
                    contextMenuStrip3.Enabled = false;
                }
            }
        }

        void ulvFormSeries_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point cursorPos = new Point(e.X, e.Y);
                UltraListView listView = sender as UltraListView;
                UltraListViewItem itemAtPoint = listView.ItemFromPoint(cursorPos, true);

                if (itemAtPoint != null)
                {
                    Infragistics.Win.ISelectionManager selectionManager = listView as Infragistics.Win.ISelectionManager;
                    selectionManager.SelectItem(itemAtPoint, true);
                    itemAtPoint.Activate();
                    contextMenuStrip2.Enabled = true;
                    contextMenuStrip2.Show(listView, new Point(e.X, e.Y));
                }
                else
                {
                    contextMenuStrip2.Enabled = false;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                Point cursorPos = new Point(e.X, e.Y);
                UltraListView listView = sender as UltraListView;
                UltraListViewItem itemAtPoint = listView.ItemFromPoint(cursorPos, true);

                if (itemAtPoint != null)
                {
                    Infragistics.Win.ISelectionManager selectionManager = listView as Infragistics.Win.ISelectionManager;
                    selectionManager.SelectItem(itemAtPoint, true);
                    itemAtPoint.Activate();

                    FormSeries fs = FormSeriesDAO.DAO.Load(Convert.ToInt32(listView.SelectedItems[0].Key));
                    this.pnlPrintSeriesPanel.Visible = true;
                    this.lblPrintSeriesName.Text = fs.Name + " Series";
                    this.loadPrintSeries(fs);
                }
            }
        }

        void ulvForms_MouseDown(object sender, MouseEventArgs e)
        {
            //this.pnlPrintSeriesPanel.Visible = false;

            if (e.Button == MouseButtons.Left)
            {
                this.lastMouseDown = e.Location;                
            }
            else if (e.Button == MouseButtons.Right)
            {
                Point cursorPos = new Point(e.X, e.Y);
                UltraListView listView = sender as UltraListView;
                UltraListViewItem itemAtPoint = listView.ItemFromPoint(cursorPos, true);

                if (itemAtPoint != null)
                {
                    Infragistics.Win.ISelectionManager selectionManager = listView as Infragistics.Win.ISelectionManager;
                    selectionManager.SelectItem(itemAtPoint, true);
                    itemAtPoint.Activate();
                    contextMenuStrip1.Enabled = true;
                    contextMenuStrip1.Show(listView, new Point(e.X, e.Y));
                }
                else
                {
                    contextMenuStrip1.Enabled = false;
                }
            }
            else
            {
                this.lastMouseDown = new Point();
            }
        }

        #region drag and drop

        private void ulvForms_MouseMove(object sender, MouseEventArgs e)
        {
            UltraListView listView = sender as UltraListView;

            //  If the mouse has moved outside the area in which it was pressed,
            //  start a drag operation
            if (!this.lastMouseDown.IsEmpty && e.Button == MouseButtons.Left)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(this.lastMouseDown, dragSize);
                dragRect.X -= dragSize.Width / 2;
                dragRect.Y -= dragSize.Height / 2;

                if (!dragRect.Contains(e.Location))
                {
                    UltraListViewItem itemAtPoint = listView.ItemFromPoint(e.Location);

                    if (itemAtPoint != null)
                    {
                        this.lastMouseDown = new Point();
                        this.dragItem = itemAtPoint;
                        listView.DoDragDrop(this.dragItem, DragDropEffects.Move);
                    }
                }
            }
        }

        private void ulvForms_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            UltraListView listView = sender as UltraListView;

            //  Cancel the drag operation if the escape key was pressed
            if (e.EscapePressed)
            {
                this.OnDragEnd(listView, true);
                e.Action = DragAction.Cancel;
            }
        }

        private void ulvPrintSeries_DragOver(object sender, DragEventArgs e)
        {
            UltraListView listView = sender as UltraListView;
            Point clientPos = listView.PointToClient(new Point(e.X, e.Y));

            if (this.dragItem != null)
            {
                this.dropItem = listView.ItemFromPoint(clientPos);
                //e.Effect = this.dropItem != null && this.dropItem != this.dragItem ? DragDropEffects.Move : DragDropEffects.None;
            }

            e.Effect = DragDropEffects.Move;
            int dragScrollAreaHeight = 8;

            Rectangle displayRect = listView.DisplayRectangle;
            Rectangle topScrollArea = displayRect;
            topScrollArea.Height = (dragScrollAreaHeight * 2);

            Rectangle bottomScrollArea = displayRect;
            bottomScrollArea.Y = bottomScrollArea.Bottom - dragScrollAreaHeight;
            bottomScrollArea.Height = dragScrollAreaHeight;

            ISelectionManager selectionManager = listView as ISelectionManager;
            if (topScrollArea.Contains(clientPos) || bottomScrollArea.Contains(clientPos))
            { selectionManager.DoDragScrollVertical(0); }
        }

        private void ulvPrintSeries_DragDrop(object sender, DragEventArgs e)
        {
            UltraListView listView = sender as UltraListView;
            this.OnDragEnd(listView, false);
        }

        private void OnDragEnd(UltraListView listView, bool canceled)
        {
            if (canceled == false && this.dragItem != null)
            {
                VWA4Common.DataObject.Formx f = FormDAO.DAO.Load(Convert.ToInt32(dragItem.Key));
                UltraListViewItem i = new UltraListViewItem();

                List<FormFormSeries> allffs = new List<FormFormSeries>();
                allffs.AddRange(FormFormSeriesDAO.DAO.GetAllByFormSeriesId(this.activePrintSeriesId));
                allffs.AddRange(this.newFfs);

                foreach (FormFormSeries ffs in allffs)
                {
                    if (ffs.FormId == f.Id && ffs.FormSeriesId == this.activePrintSeriesId)
                    {
                        MessageBox.Show("Duplicate forms cannot be added to the same series.", "Manage Forms");
                        return;
                    }
                }

                try
                {
                    FormFormSeries ffs = new FormFormSeries
                    {
                        Id = FormFormSeriesDAO.DAO.GetNextId() + this.newFfs.Count,
                        FormId = f.Id,
                        FormSeriesId = this.activePrintSeriesId,
                        Enabled = true,
                        NumberOfCopies = 1,
                        SortOrder = (dropItem == null) ? 0 : dropItem.Index + 1
                    };
                    
                    i.Key = ffs.Id.ToString();
                    i.Value = f.Name;
                    ulvPrintSeries.Items.Insert((dropItem == null) ? 0 : dropItem.Index + 1, i);

                    this.newFfs.Add(ffs);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                i.CheckState = CheckState.Checked;
                i.SubItems[0].Value = 1;
                i.SubItems[1].Value = f.Id;
            }

            this.dragItem = this.dropItem = null;
            this.lastMouseDown = new Point();
        }

        #endregion

        public void LoadData()
        {
			//commonEvents.HideTaskListControl = true;
		}
        public void SaveData()
        {
		}
		
        public bool ValidateData()
        {
            return true;
        }

        public void LeaveSheet()
        {
            SaveData();
            _IsActive = false;
        }

        public int AutoRun(string param)
        {
            return 0;
        }

        private void loadForms()
        {
            ulvForms.Reset();
            ulvForms.Width = 410;
            ulvForms.Height = 381;
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

            UltraListViewSubItemColumn cLastPrinted = new UltraListViewSubItemColumn();
            cLastPrinted.Text = "Last Printed";
            cLastPrinted.Width = 100;
            cLastPrinted.VisibleInDetailsView = DefaultableBoolean.True;
            cLastPrinted.DataType = typeof(String);

            UltraListViewSubItemColumn cDataEntryTemplate = new UltraListViewSubItemColumn();
            cDataEntryTemplate.Text = "Data Entry Template";
            cDataEntryTemplate.Width = 150;
            cDataEntryTemplate.VisibleInDetailsView = DefaultableBoolean.True;
            cDataEntryTemplate.DataType = typeof(Int32);

            ulvForms.SubItemColumns.Add(cDocType);
            ulvForms.SubItemColumns.Add(cLastPrinted);
            ulvForms.SubItemColumns.Add(cDataEntryTemplate);

            ValueList docType = new ValueList();
            ValueList lastPrinted = new ValueList();
            ValueList dataEntryTemplate = new ValueList();

            foreach (VWA4Common.DataObject.Formx f in FormDAO.DAO.GetAll())
            {   
                docType.ValueListItems.Add(f.DocumentType, f.DocumentType);
                lastPrinted.ValueListItems.Add(f.LastPrintedDate, f.LastPrintedDate);
                if(f.DataEntryTemplateId > 0){
                    dataEntryTemplate.ValueListItems.Add(f.DataEntryTemplateId, VWA4Common.DB.Retrieve(string.Format("select DETName from DataEntryTemplates where ID={0}", f.DataEntryTemplateId)).Rows[0]["DETName"].ToString());
                }
                UltraListViewItem i = ulvForms.Items.Add(f.Id.ToString(), f.Name);
                i.SubItems[0].Value = f.DocumentType;
                i.SubItems[1].Value = f.LastPrintedDate;
                i.SubItems[2].Value = f.DataEntryTemplateId > 0 ? f.DataEntryTemplateId.ToString() : "";
            }

            ulvForms.SubItemColumns[0].ValueList = docType;
            ulvForms.SubItemColumns[1].ValueList = lastPrinted;
            ulvForms.SubItemColumns[2].ValueList = dataEntryTemplate;

            this.pnlForms.Controls.Add(ulvForms);
        }

        private void loadFormSeries()
        {
            ulvFormSeries.Reset();
            ulvFormSeries.Width = pnlFormSeries.Width;
			ulvFormSeries.Height = pnlFormSeries.Height;
            ulvFormSeries.View = UltraListViewStyle.Details;
            ulvFormSeries.ItemSettings.Appearance.Image = imageList1.Images[0];

            ulvFormSeries.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
            ulvFormSeries.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
            ulvFormSeries.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
            ulvFormSeries.ItemSettings.SelectionType = SelectionType.Single;

            UltraListViewMainColumn mainColumn = ulvFormSeries.MainColumn;
            mainColumn.Text = "Form Series Name";
            mainColumn.DataType = typeof(System.Int32);
            
            foreach (VWA4Common.DataObject.FormSeries fs in FormSeriesDAO.DAO.GetAll())
            {
                UltraListViewItem i = ulvFormSeries.Items.Add(fs.Id.ToString(), fs.Name);
                
            }

            this.pnlFormSeries.Controls.Add(ulvFormSeries);
        }

        private void loadPrintSeries(FormSeries fs)
        {
            this.activePrintSeriesId = fs.Id;

            this.newFfs = new List<FormFormSeries>();
            ulvPrintSeries.Reset();
            ulvPrintSeries.Width = pnlPrintSeries.Width;
            ulvPrintSeries.Height = pnlPrintSeries.Height;
            ulvPrintSeries.ViewSettingsDetails.CheckBoxStyle = CheckBoxStyle.CheckBox;
            ulvPrintSeries.View = UltraListViewStyle.Details;
            ulvPrintSeries.ItemSettings.Appearance.Image = imageList1.Images[0];

            ulvPrintSeries.ViewSettingsDetails.SubItemColumnsVisibleByDefault = true;
            ulvPrintSeries.ViewSettingsDetails.AutoFitColumns = AutoFitColumns.ResizeAllColumns;
            ulvPrintSeries.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
            ulvPrintSeries.ItemSettings.SelectionType = SelectionType.Single;

            UltraListViewMainColumn mainColumn = ulvPrintSeries.MainColumn;
            mainColumn.Text = "Enabled";
            mainColumn.DataType = typeof(System.Int32);

            UltraListViewSubItemColumn cNumberOfCopies = new UltraListViewSubItemColumn();
            cNumberOfCopies.Text = "# Copies";
            cNumberOfCopies.Width = 50;
            cNumberOfCopies.VisibleInDetailsView = DefaultableBoolean.True;
            cNumberOfCopies.DataType = typeof(Int32);

            UltraListViewSubItemColumn cFormId = new UltraListViewSubItemColumn();
            cFormId.Text = "FormId";
            cFormId.VisibleInDetailsView = DefaultableBoolean.False;
            cFormId.DataType = typeof(Int32);

            ulvPrintSeries.SubItemColumns.Add(cNumberOfCopies);
            ulvPrintSeries.SubItemColumns.Add(cFormId);

            List<FormFormSeries> allffs = FormFormSeriesDAO.DAO.GetAllByFormSeriesId(fs.Id);
            allffs.AddRange(this.newFfs);
            foreach (FormFormSeries ffs in allffs)
            {
                VWA4Common.DataObject.Formx f = FormDAO.DAO.Load(ffs.FormId);
                UltraListViewItem i = ulvPrintSeries.Items.Add(ffs.Id.ToString(), f.Name);
                i.CheckState = ffs.Enabled ? CheckState.Checked : CheckState.Unchecked;
                i.SubItems[0].Value = ffs.NumberOfCopies;
                i.SubItems[1].Value = ffs.FormId;
            }

            this.pnlPrintSeries.Controls.Add(ulvPrintSeries);
        }
	
        private class FormData
        {
            public int formId = 0;
            public string formName = string.Empty;
            public string dataEntryTemplateName = string.Empty;

            public FormData(int id, string fn, string detn)
            {
                this.formId = id;
                this.formName = fn;
                this.dataEntryTemplateName = detn;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }
        
        private void bDone_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.pnlPrintSeriesPanel.Visible = false;

            frmNewForm create = new frmNewForm();
            create.FormClosed += new FormClosedEventHandler(create_FormClosed);

            create.ShowDialog();
        }

        void create_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.loadForms();
            this.loadFormSeries();
        }

        private void btnEditForm_Click(object sender, EventArgs e)
        {
            if (this.ulvForms.SelectedItems.Count > 0)
            {
                frmNewForm edit = new frmNewForm(FormDAO.DAO.Load(Convert.ToInt32(this.ulvForms.SelectedItems[0].Key)));
                edit.FormClosed += new FormClosedEventHandler(create_FormClosed);

                edit.ShowDialog();
            }
        }

        private void btnRemoveForm_Click(object sender, EventArgs e)
        {
            if (this.ulvForms.SelectedItems.Count > 0)
            {
                VWA4Common.DataObject.Formx f = FormDAO.DAO.Load(Convert.ToInt32(this.ulvForms.SelectedItems[0].Key));
                if (MessageBox.Show(string.Format("Are you sure you want to delete Form '{0}'?", f.Name), "Delete Form", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    FormDAO.DAO.Delete(f);
                    this.loadForms();
                    this.loadFormSeries();
                }
            }
        }

        private void btnCreateSeries_Click(object sender, EventArgs e)
        {
            frmNewSeries create = new frmNewSeries();
            create.FormClosed += new FormClosedEventHandler(create_FormClosed);

            create.ShowDialog();
        }

        private void btnEditSeries_Click(object sender, EventArgs e)
        {
            if (this.ulvFormSeries.SelectedItems.Count > 0)
            {
                frmNewSeries edit = new frmNewSeries(FormSeriesDAO.DAO.Load(Convert.ToInt32(this.ulvFormSeries.SelectedItems[0].Key)));
                edit.FormClosed += new FormClosedEventHandler(create_FormClosed);

                edit.ShowDialog();
            }
        }

        private void btnRemoveSeries_Click(object sender, EventArgs e)
        {
            if (this.ulvFormSeries.SelectedItems.Count > 0)
            {
                VWA4Common.DataObject.FormSeries fs = FormSeriesDAO.DAO.Load(Convert.ToInt32(this.ulvFormSeries.SelectedItems[0].Key));
                if (MessageBox.Show(string.Format("Are you sure you want to delete Form Series '{0}'?", fs.Name), "Delete Form Series", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    FormSeriesDAO.DAO.Delete(fs);
                }
                this.loadForms();
                this.loadFormSeries();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnEditForm_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnRemoveForm_Click(sender, e);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ulvForms.SelectedItems.Count > 0)
            {
                frmFormProperties prop = new frmFormProperties(FormDAO.DAO.Load(Convert.ToInt32(this.ulvForms.SelectedItems[0].Key)));
                prop.ShowDialog();
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ulvForms.SelectedItems.Count > 0)
            {
                List<FormFormSeries> ffs = new List<FormFormSeries>();
                FormFormSeries fs = new FormFormSeries();
                fs.FormId = Convert.ToInt32(this.ulvForms.SelectedItems[0].Key);
                ffs.Add(fs);

                VWA4Common.DataObject.Formx f = FormDAO.DAO.Load(fs.FormId);
                f.LastPrintedDate = DateTime.Now.ToShortDateString();
                FormDAO.DAO.Update(f);

                rptFormSeries rpt = new rptFormSeries(ffs);
                rpt.Run();
            }
        }

        private void editSeriesMenuItem_Click(object sender, EventArgs e)
        {
            this.btnEditSeries_Click(sender, e);
        }

        private void deleteSeriesMenuItem_Click(object sender, EventArgs e)
        {
            this.btnRemoveSeries_Click(sender, e);
        }

        private void propertiesSeriesMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ulvFormSeries.SelectedItems.Count > 0)
            {
                frmSeriesProperties prop = new frmSeriesProperties(FormSeriesDAO.DAO.Load(Convert.ToInt32(this.ulvFormSeries.SelectedItems[0].Key)));
                prop.ShowDialog();
            }
        }

        private void printSeriesMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ulvFormSeries.SelectedItems.Count > 0)
            {
                foreach (VWA4Common.DataObject.Formx f in FormDAO.DAO.GetAllBySeriesId(Convert.ToInt32(this.ulvFormSeries.SelectedItems[0].Key)))
                {
                    f.LastPrintedDate = DateTime.Now.ToShortDateString();
                    FormDAO.DAO.Update(f);
                }
                rptFormSeries rpt = new rptFormSeries(FormSeriesDAO.DAO.Load(Convert.ToInt32(this.ulvFormSeries.SelectedItems[0].Key)));
                rpt.Run();
            }
        }

        private void btnSavePrintSeries_Click(object sender, EventArgs e)
        {
            int order = 1;
            foreach (UltraListViewItem i in ulvPrintSeries.Items)
            {
                FormFormSeries ffs = new FormFormSeries();
                try
                {
                    ffs = FormFormSeriesDAO.DAO.Load(Convert.ToInt32(i.Key));
                }
                catch (Exception)
                {
                    ffs.Id = 0;
                }

                ffs.FormId = Convert.ToInt32(i.SubItems[1].Value);
                ffs.FormSeriesId = this.activePrintSeriesId;
                ffs.Enabled = i.CheckState.Equals(CheckState.Checked) ? true : false;
                ffs.SortOrder = order++;
                ffs.NumberOfCopies = Convert.ToInt32(i.SubItems[0].Value);

                FormFormSeriesDAO.DAO.InsertOrUpdate(ffs);                
            }
            this.newFfs = new List<FormFormSeries>();
            MessageBox.Show(string.Format("{0} has been saved.", this.lblPrintSeriesName.Text), "Manage Forms");
        }

        private void editFormFormSeries_Click(object sender, EventArgs e)
        {
            if (ulvPrintSeries.SelectedItems.Count > 0)
            {
                FormFormSeries editFfs = new FormFormSeries();
                try
                {
                    editFfs = FormFormSeriesDAO.DAO.Load(Convert.ToInt32(ulvPrintSeries.SelectedItems[0].Key));
                }
                catch (Exception)
                {
                    foreach (FormFormSeries ffs in this.newFfs)
                    {
                        if (ffs.Id == Convert.ToInt32(ulvPrintSeries.SelectedItems[0].Key))
                        {
                            editFfs = ffs;
                            break;
                        }
                    }
                }

                frmEditFormFormSeries edit = new frmEditFormFormSeries(editFfs);
                edit.FormClosed += new FormClosedEventHandler(editFormFormSeries_FormClosed);
                edit.ShowDialog();              
            }
        }

        void editFormFormSeries_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.loadPrintSeries(FormSeriesDAO.DAO.Load(this.activePrintSeriesId));
        }

        private void deleteFormFormSeries_Click(object sender, EventArgs e)
        {
            if (this.ulvPrintSeries.SelectedItems.Count > 0)
            {
                FormFormSeries ffs = FormFormSeriesDAO.DAO.Load(Convert.ToInt32(ulvPrintSeries.SelectedItems[0].Key));
                VWA4Common.DataObject.Formx f = FormDAO.DAO.Load(ffs.FormId);
                FormSeries fs = FormSeriesDAO.DAO.Load(ffs.FormSeriesId);
                if (MessageBox.Show(string.Format("Are you sure you want to delete Form '{0}' from Form Series '{1}'?", f.Name, fs.Name), "Delete Form", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    FormFormSeriesDAO.DAO.Delete(ffs);
                }
                this.ulvPrintSeries.Items.Remove(this.ulvPrintSeries.SelectedItems[0]);
            }
        }

        private void propertiesFormFormSeries_Click(object sender, EventArgs e)
        {
            if (this.ulvPrintSeries.SelectedItems.Count > 0)
            {
                FormFormSeries editFfs = new FormFormSeries();
                try
                {
                    editFfs = FormFormSeriesDAO.DAO.Load(Convert.ToInt32(ulvPrintSeries.SelectedItems[0].Key));
                }
                catch (Exception)
                {
                    foreach (FormFormSeries ffs in this.newFfs)
                    {
                        if (ffs.Id == Convert.ToInt32(ulvPrintSeries.SelectedItems[0].Key))
                        {
                            editFfs = ffs;
                            break;
                        }
                    }
                }

                frmFormFormSeriesProperties prop = new frmFormFormSeriesProperties(editFfs);
                prop.ShowDialog();
            }
        }

        private void printFormFormSeries_Click(object sender, EventArgs e)
        {
            if (this.ulvFormSeries.SelectedItems.Count > 0)
            {
                foreach (VWA4Common.DataObject.Formx f in FormDAO.DAO.GetAllBySeriesId(Convert.ToInt32(this.ulvPrintSeries.SelectedItems[0].Key)))
                {
                    f.LastPrintedDate = DateTime.Now.ToShortDateString();
                    FormDAO.DAO.Update(f);
                }
                rptFormSeries rpt = new rptFormSeries(FormSeriesDAO.DAO.Load(Convert.ToInt32(this.ulvPrintSeries.SelectedItems[0].Key)));
                rpt.Run();
            }
        }

		private void button1_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

        private void PrintThisSeries_Click(object sender, EventArgs e)
        {
            List<FormFormSeries> ffs = new List<FormFormSeries>();
            foreach (UltraListViewItem i in ulvPrintSeries.Items)
            {
                ffs.Add(FormFormSeriesDAO.DAO.Load(Convert.ToInt32(i.Key)));
            }

            rptFormSeries rpt = new rptFormSeries(ffs);
            rpt.Run();
        }

        private void btnSeriesProperties_Click(object sender, EventArgs e)
        {
            propertiesFormFormSeries_Click(sender, e);            
        }

        private void btnEditPrintSeries_Click(object sender, EventArgs e)
        {
            editFormFormSeries_Click(sender, e);
        }
    }
}

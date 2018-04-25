using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using VWA4Common.DAO;
using VWA4Common.DataObject;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace UserControls
{
    public partial class UCManageLogSheet : UserControl
    {
        private LogSheet logSheet = new LogSheet();

        private const int UNIT_TYPE = 0;
        private const int FOOD_TYPE = 1;
        private const int LOSS_TYPE = 2;

        private int foodTypeCount = 0;
        private int lossTypeCount = 0;
        private int containerTypeCount = 0;

        public LogSheet LogSheet
        {
            get { return this.logSheet; }
            set { this.logSheet = value; }
        }

        public UCManageLogSheet()
        {
            InitializeComponent();
            this.Initialize();
        }

        public UCManageLogSheet(LogSheet logSheet)
        {
            this.LogSheet = logSheet;
            InitializeComponent();
            this.Initialize();
        }

        public void Initialize()
        {
            this.lstFoodTypes.DoubleClick += new EventHandler(lstFoodTypes_DoubleClick);
            this.lstLossTypes.DoubleClick += new EventHandler(lstLossReasons_DoubleClick);
            this.lstUnits.DoubleClick += new EventHandler(lstAvailableContainerTypes_DoubleClick);

            this.loadSelected();
            this.populateUnits();
            this.populateFoodTypes();
            this.populateLossTypes();
            this.populateSites();
            this.populateTypes();
        }

        private void loadSelected()
        {
            //load selected
            TreeListNode snode = this.lstSelectedTypes.AppendNode(null, null);
            snode.SetValue("displayName", "Unit Types");
            snode.SetValue("typeId", "-1");
            snode.SetValue("typeName", "");

            snode = this.lstSelectedTypes.AppendNode(null, null);
            snode.SetValue("displayName", "Food Types");
            snode.SetValue("typeId", "-1");
            snode.SetValue("typeName", "");

            snode = this.lstSelectedTypes.AppendNode(null, null);
            snode.SetValue("displayName", "Loss Types");
            snode.SetValue("typeId", "-1");
            snode.SetValue("typeName", "");
        }

        private void populateUnits()
        {
            foreach (ContainerType ct in ContainerTypeDAO.DAO.GetAllContainerTypes())
            {
                TreeListNode node = this.lstUnits.AppendNode(null, null);
                node.SetValue("containerName", ct.Name);
                node.SetValue("containerId", ct.Id);
            }
        }

        private void populateFoodTypes()
        {
            foreach (FoodCategory fcat in FoodCategoryDAO.DAO.GetAllChildFoodCategories())
            {
                TreeListNode node = this.lstFoodTypes.AppendNode(null, null);
                node.SetValue("foodName", fcat.Name);
                foreach (FoodType ft in FoodTypeDAO.DAO.GetAllFoodTypesByCategoryId(fcat.Id))
                {
                    TreeListNode cnode = this.lstFoodTypes.AppendNode(null, node.Id);
                    cnode.SetValue("foodName", ft.Name);
                    cnode.SetValue("foodTypeID", ft.Id);
                }
            }
        }

        private void populateLossTypes()
        {
            foreach (LossCategory lcat in LossCategoryDAO.DAO.GetAllChildLossCategories())
            {
                TreeListNode node = this.lstLossTypes.AppendNode(null, null);
                node.SetValue("lossName", lcat.Name);
                foreach (LossType lt in LossTypeDAO.DAO.GetAllLossTypesByCategoryId(lcat.Id))
                {
                    TreeListNode cnode = this.lstLossTypes.AppendNode(null, node.Id);
                    cnode.SetValue("lossName", lt.Name);
                    cnode.SetValue("lossTypeID", lt.Id);
                }
            }
        }

        private void populateSites()
        {
            this.ddlSite.DataSource = SiteDAO.DAO.GetAllSites();
            this.ddlSite.DisplayMember = "LicensedSite";
            this.ddlSite.ValueMember = "Id";
        }

        private void populateTypes()
        {
            this.ddlTypes.DataSource = LogSheetTypeDAO.DAO.GetAllLogSheetTypes();
            this.ddlTypes.DisplayMember = "TypeName";
            this.ddlTypes.ValueMember = "ID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

        private List<FoodType> getSelectedFoodTypes()
        {
            List<FoodType> l = new List<FoodType>();
            foreach (TreeListNode node in this.lstSelectedTypes.Nodes[FOOD_TYPE].Nodes)
            {
                l.Add(FoodTypeDAO.DAO.Load(node.GetValue("typeId").ToString()));
            }
            return l;
        }

        private List<LossType> getSelectedLossTypes()
        {
            List<LossType> l = new List<LossType>();
            foreach (TreeListNode node in this.lstSelectedTypes.Nodes[LOSS_TYPE].Nodes)
            {
                l.Add(LossTypeDAO.DAO.Load(node.GetValue("typeId").ToString()));
            }
            return l;
        }

        private List<ContainerType> getSelectedContainerTypes()
        {
            List<ContainerType> l = new List<ContainerType>();
            foreach (TreeListNode node in this.lstSelectedTypes.Nodes[UNIT_TYPE].Nodes)
            {
                l.Add(ContainerTypeDAO.DAO.Load(node.GetValue("typeId").ToString()));
            }
            return l;
        }

        private void populateLogSheet()
        {
            LogSheet ls = new LogSheet();

            ls.LogSheetTypeId = Convert.ToInt32(this.ddlTypes.SelectedValue);
            ls.SiteId = Convert.ToInt32(this.ddlSite.SelectedValue);
            ls.Header = this.txtHeader.Text;
            ls.Name = this.txtName.Text;
            ls.ContainerTypes = this.getSelectedContainerTypes();
            ls.FoodTypes = this.getSelectedFoodTypes();
            ls.LossTypes = this.getSelectedLossTypes();

            this.LogSheet = ls;

            //LogSheetDAO.DAO.Insert(Convert.ToInt32(this.lstTypes.SelectedValue), Convert.ToInt32(this.ddlSites.SelectedValue), 
            //    this.txtHeader.Text, this.txtName.Text, this.getSelectedFoodTypes(), this.getSelectedLossTypes(), 
            //    this.getSelectedContainerTypes());
        }

        #region events

        public delegate void ViewReportEventHandler(object sender, EventArgs e);
        private ViewReportEventHandler viewReport;
        public event ViewReportEventHandler ViewReport
        {
            add { viewReport += value; }
            remove { viewReport -= value; }
        }
        public void SetViewReport()
        {
            OnViewReport(EventArgs.Empty);
        }
        protected virtual void OnViewReport(EventArgs e)
        {
            if (viewReport != null)
                viewReport(this, e);
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            this.populateLogSheet();
            if (sender != null)
                SetViewReport();
        }
        
        void lstLossReasons_DoubleClick(object sender, EventArgs e)
        {
            if (this.lossTypeCount < 4)
            {
                TreeListNode pnode = this.lstSelectedTypes.Nodes[LOSS_TYPE];
                TreeListNode node = this.lstSelectedTypes.AppendNode(null, pnode.Id);
                node.SetValue("displayName", this.lstLossTypes.FocusedNode.GetValue("lossName"));
                node.SetValue("typeId", this.lstLossTypes.FocusedNode.GetValue("lossTypeID"));
                node.SetValue("typeName", "Loss");

                this.lossTypeCount++;
            }
        }

        void lstFoodTypes_DoubleClick(object sender, EventArgs e)
        {
            if (this.foodTypeCount < 12)
            {
                TreeListNode pnode = this.lstSelectedTypes.Nodes[FOOD_TYPE];
                TreeListNode node = this.lstSelectedTypes.AppendNode(null, pnode.Id);
                node.SetValue("displayName", this.lstFoodTypes.FocusedNode.GetValue("foodName"));
                node.SetValue("typeId", this.lstFoodTypes.FocusedNode.GetValue("foodTypeID"));
                node.SetValue("typeName", "Food");

                this.foodTypeCount++;
            }
        }

        void lstAvailableContainerTypes_DoubleClick(object sender, EventArgs e)
        {
            if (this.containerTypeCount < 6)
            {
                TreeListNode pnode = this.lstSelectedTypes.Nodes[UNIT_TYPE];
                TreeListNode node = this.lstSelectedTypes.AppendNode(null, pnode.Id);
                node.SetValue("displayName", this.lstUnits.FocusedNode.GetValue("containerName"));
                node.SetValue("typeId", this.lstUnits.FocusedNode.GetValue("containerId"));
                node.SetValue("typeName", "Container");

                this.containerTypeCount++;
            }
        }
        #endregion
    }
}

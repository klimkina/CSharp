using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinEditors.UltraWinCalc;
using Infragistics.Win.UltraWinListView;
using VWA4Common;
using VWA4Common.DAO;
using VWA4Common.DataObject;

namespace UserControls
{
	public partial class UCManageTags : UserControl, IVWAUserControlBase
	{
		/// Class level elements
		public bool Initialized;
		bool SkipSelectedIndexChangedHandler;
		private Dictionary<string, Tag> tags_listview;

		private DBDetector dbDetector = null; // subscribe for db change
		VWA4Common.CommonEvents commonEvents = null;
		/// 
		/// Buffers for holding the current Tag's data
		///
		Tag CurrTag = new Tag();
		List<Tag> TagList = new List<Tag>();
		List<TagsFoodType> TagsFoodTypeList = new List<TagsFoodType>();

		/// General purpose enhanced combo box item
		class ComboBoxItem
		{
			public string Name;
			public int ID;
			public ComboBoxItem(string Name, int ID)
			{
				this.Name = Name;
				this.ID = ID;
			}
			// override ToString() function
			public override string ToString()
			{
				return this.Name;
			}
		}
		ComboBoxItem cbi = null;

		/// <summary>
		/// Constructor.
		/// </summary>
		public UCManageTags()
		{
			InitializeComponent();
		}

		///		
		/// Interface methods for User Controls
		///		

		public void Init(DateTime firstDayOfWeek)
		{
			Initialized = false;
			if (dbDetector == null)
			{
				dbDetector = DBDetector.GetDBDetector();
				//dbDetector.PathChanged += new DBDetectorEventHandler(dbDetector_PathChanged);
				//dbDetector.WeekChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);
				//dbDetector.DBPathChanged += new DBDetectorEventHandler(dbDetector_WeekChanged);
				//dbDetector.AdjustmentsChanged += new DBDetectorEventHandler(dbDetector_AdjustmentsChanged);
				dbDetector.UserLogin += new DBDetectorLoginEventHandler(dbDetector_UserLogin);
			}
			if (commonEvents == null)
			{
				commonEvents = VWA4Common.CommonEvents.GetEvents();
				commonEvents.UpdateProductUIData +=
					new VWA4Common.UpdateProductUIDataEventHandler(commonEvents_UpdateProductUI);
			}

			//InitProductUI();
			ulvTagList.ItemSettings.SelectionType = SelectionType.Single;
			_IsActive = true;
		}
		/// <summary>
		/// Update the Product UI based on global settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void commonEvents_UpdateProductUI(object sender, EventArgs e)
		{
			///***********
			/// Product Type
			///***********
			// Task background
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
			// Task header
			panel1.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			lTaskName.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other labels
		}

		public int AutoRun(string param)
		{
			Initialized = true;
			return 0;
		}

		private bool _IsActive = false;
		public bool IsActive
		{
			get { return _IsActive; }
			set { _IsActive = value; }
		}
		public void LeaveSheet()
		{
			_IsActive = false;
		}
		/// <summary>
		/// Standard Load Data method.
		/// </summary>
		public void LoadData()
		{
			Initialized = false;
			///
			/// Load all the tags
			/// 
			TagList = TagsDAO.DAO.GetAllTags();
			// Load them into the list view
			LoadTags();
			LoadFoodTypes();
			Initialized = true;
		}
		public void SaveData()
		{

		}

		public bool ValidateData()
		{ return true; }


		/// 
		/// Support Methods
		/// 

		private void LoadTags()
		{
			TagList = TagsDAO.DAO.GetAllTags();
			ulvTagList.Reset();
			ulvTagList.View = UltraListViewStyle.List;
			ulvTagList.ItemSettings.Appearance.Image = imageList1.Images[0];
			ulvTagList.ItemSettings.SelectedAppearance.Image = imageList1.Images[1];
			ulvTagList.ItemSettings.SelectedAppearance.FontData.Bold = DefaultableBoolean.False;
			ulvTagList.ItemSettings.SelectedAppearance.ForeColor = Color.Black;
			ulvTagList.ItemSettings.SelectedAppearance.BackColor = Color.MistyRose;
			//ulvTagList.ItemSettings.SelectedAppearance.BorderColor = Color.MistyRose;
			//ulvTagList.ItemSettings.SelectedAppearance.BackColor2 = SystemColors.Highlight;
			//ulvTagList.ItemSettings.SelectedAppearance.BackGradientStyle = GradientStyle.Vertical;


			ulvTagList.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
			UltraListViewMainColumn mainColumn = ulvTagList.MainColumn;
			mainColumn.Text = "Tag Name";
			mainColumn.DataType = typeof(System.String);
			/// Load 'er up
			for (int i = 0; i < TagList.Count; i++)
			{
				UltraListViewItem item = ulvTagList.Items.Add(TagList[i].ID.ToString(), TagList[i].TagName);
				//item.Tag = TagList[i];
			}
			ulvTagList.Refresh();
			bDeleteTag.Enabled = (ulvTagList.SelectedItems.Count > 0);
		}

		/// <summary>
		/// Load up the Food Types, and if a tag is selected, then check
		/// the food types that are associated with that tag.
		/// </summary>
		private void LoadFoodTypes()
		{
			ucFoodTypes.EnableCheckboxes = false;
			ucFoodTypes.ShowPrice = false;
			ucFoodTypes.InitTreeView("0", "Food", "");
			ucFoodTypes.Refresh();

		}

		private void LoadTaggedFoodTypes(string tagName)
		{
			TagsFoodTypeList = TagsFoodTypeDAO.DAO.GetAllByTagName(tagName);
			LoadTaggedFoodTypes();
		}

		private void LoadTaggedFoodTypes(int tagID)
		{
			TagsFoodTypeList = TagsFoodTypeDAO.DAO.GetAllByTagID(tagID);
			LoadTaggedFoodTypes();
		}

		private void LoadTaggedFoodTypes()
		{
			// Load the listview
			ulvTaggedFoodTypes.Reset();
			ulvTaggedFoodTypes.View = UltraListViewStyle.List;
			ulvTaggedFoodTypes.ItemSettings.Appearance.Image = imageList1.Images[1];

			ulvTaggedFoodTypes.ItemSettings.SubItemsVisibleInToolTipByDefault = false;
			UltraListViewMainColumn mainColumn = ulvTaggedFoodTypes.MainColumn;
			mainColumn.Text = "Food Type Name";
			mainColumn.DataType = typeof(System.String);
			/// Load 'er up
			for (int i = 0; i < TagsFoodTypeList.Count; i++)
			{
				UltraListViewItem item = new UltraListViewItem();
				ulvTaggedFoodTypes.Items.Add(TagsFoodTypeList[i].FoodTypeID, TagsFoodTypeList[i].FoodTypeName);
				//item.Tag = TagsFoodTypeList[i];
			}
			ulvTaggedFoodTypes.Refresh();
			ulvTagList.Focus();
		}

		///		
		/// Event Handlers and supporting routines
		///		

		private void dbDetector_UserLogin(object sender, LoginEventArgs e)
		{
			if (this.IsActive && !e.IsLogin) // ||  !bool.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetDBManagerPermission("Enter Waste Data")))
				CloseTaskSheet();
		}
		private void CloseTaskSheet()
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

		private void bNewTag_Click(object sender, EventArgs e)
		{
			frmAddNewTag frm = new frmAddNewTag();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				// We added a new tag
				LoadData();
				SetCurrTag(frm.TagNew);
			}
			ulvTagList.Focus();
		}

		private void SetCurrTag(Tag newcurrtag)
		{
			CurrTag = newcurrtag;
			foreach (UltraListViewItem item in ulvTagList.Items)
			{
				if (newcurrtag.TagName == item.Text)
				{
					ulvTagList.SelectedItems.Add(item);
					bDeleteTag.Enabled = (ulvTagList.SelectedItems.Count > 0);
					ulvTagList.Focus();
					return;
				}

			}
			ulvTagList.Focus();
		}

		//private void ulvTagList_Click(object sender, EventArgs e)
		//{
		//    if (ulvTagList.SelectedItems.Count <= 0) return;
		//    //
		//    string itemkey = ulvTagList.SelectedItems[0].Key;
		//    CurrTag = (Tag)ulvTagList.SelectedItems[0].Tag;
		//    // 
		//    LoadTaggedFoodTypes(CurrTag.ID);
		//}

		private void ucFoodTypes_TreeViewIDChanged(object sender, UCTreeView.TreeViewEventArgs e)
		{
			// if Food Type is not already in the tag list, add it
			TagsFoodType tftreturn = TagsFoodTypeList.Find(
				delegate(TagsFoodType tft)
				{
					return tft.FoodTypeID == e.ID;
				}
				);
			if (tftreturn == null)
			{
				// Food Type doesn't already exist - add it
				TagsFoodType tftnew = new TagsFoodType();
				tftnew.FoodTypeID = e.ID;
				tftnew.FoodTypeName = e.Name;
				tftnew.TagID = CurrTag.ID;
				tftnew.TagName = CurrTag.TagName;
				int idret = TagsFoodTypeDAO.DAO.Insert(tftnew);
				LoadTaggedFoodTypes(tftnew.TagID);
			}
			ulvTagList.Focus();
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			commonEvents.TaskSheetKey = "dashboard";
		}

		private void ulvTagList_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
		{
			if (e.SelectedItems.Count > 0)
			{
				UltraListViewItem item = e.SelectedItems[0];
				int selectedtagID = int.Parse(item.Key);
				CurrTag = TagsDAO.DAO.Load(selectedtagID);
				LoadTaggedFoodTypes(selectedtagID);
			}
			else
			{
				//ClearTaggedFoodTypes();
			}
			ulvTagList.Focus();
		}

		private void ulvTagList_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{	// Change this to false if you want to maintain
				// the existing selection.
				//bool clearExisting = false;
				Point cursorPos = new Point(e.X, e.Y);
				UltraListView listView = sender as UltraListView;
				// Use the UltraListView's 'ItemFromPoint' method to hit test for an
				// UltraListViewItem. Note that we specify true for the 'selectableAreaOnly'
				// parameter, so that we only get a hit when the cursor is over the text
				// or image area of the item.
				UltraListViewItem itemAtPoint = listView.ItemFromPoint(cursorPos, true);
				// If we got a reference to an item, populate the context menu
				// accordingly and return
				if (itemAtPoint != null)
				{
					//this.ulvMethodsList.ContextMenuStrip = null;
					Infragistics.Win.ISelectionManager selectionManager =
						listView as Infragistics.Win.ISelectionManager;
					selectionManager.SelectItem(itemAtPoint, true);
					itemAtPoint.Activate();
					contextMenuStrip1.Enabled = true;
				}
				else
				{
					contextMenuStrip1.Enabled = false;
					//this.ulvMethodsList.ContextMenuStrip = cmsListViewStyle;
				}
			}
		}

		private void tsmRemoveFoodType_Click(object sender, EventArgs e)
		{
			UltraListViewItem item = ulvTaggedFoodTypes.SelectedItems[0];

			TagsFoodTypeDAO.DAO.Delete(item.Key);
			LoadTaggedFoodTypes(CurrTag.ID);
		}

		private void tsmDeleteTag_Click(object sender, EventArgs e)
		{
			DeleteCurrentTag();
		}

		private void ClearTaggedFoodTypes()
		{
			ulvTaggedFoodTypes.Reset();
			ulvTaggedFoodTypes.Refresh();
		}


		private void ulvTaggedFoodTypes_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{	// Change this to false if you want to maintain
				// the existing selection.
				//bool clearExisting = false;
				Point cursorPos = new Point(e.X, e.Y);
				UltraListView listView = sender as UltraListView;
				// Use the UltraListView's 'ItemFromPoint' method to hit test for an
				// UltraListViewItem. Note that we specify true for the 'selectableAreaOnly'
				// parameter, so that we only get a hit when the cursor is over the text
				// or image area of the item.
				UltraListViewItem itemAtPoint = listView.ItemFromPoint(cursorPos, true);
				// If we got a reference to an item, populate the context menu
				// accordingly and return
				if (itemAtPoint != null)
				{
					//this.ulvMethodsList.ContextMenuStrip = null;
					Infragistics.Win.ISelectionManager selectionManager =
						listView as Infragistics.Win.ISelectionManager;
					selectionManager.SelectItem(itemAtPoint, true);
					itemAtPoint.Activate();
					contextMenuStrip2.Enabled = true;
				}
				else
				{
					contextMenuStrip2.Enabled = false;
					//this.ulvMethodsList.ContextMenuStrip = cmsListViewStyle;
				}
			}
		}

		private void bDeleteTag_Click(object sender, EventArgs e)
		{
			DeleteCurrentTag();
		}

		private void ulvTagList_Click(object sender, EventArgs e)
		{
			bDeleteTag.Enabled = (ulvTagList.SelectedItems.Count > 0);
		}

		private void DeleteCurrentTag()
		{
			if (ulvTagList.SelectedItems.Count > 0)
			{
				// work around Infragistics Tag stuff doesn't work right
				string selectedtagID = ulvTagList.SelectedItems[0].Key;
				Tag tt = TagsDAO.DAO.Load(int.Parse(selectedtagID));

				if (MessageBox.Show("Really delete Tag '" + tt.TagName + "'?"
					+ "\r(Associated Food Types will be removed first)", "Confirm Delete Tag", MessageBoxButtons.YesNo) ==
					DialogResult.Yes)
				{
					// First clear out all the Tagged Food Types
					TagsFoodTypeDAO.DAO.ClearAllByTagID(tt.ID);
					// Then delete the tag itself
					TagsDAO.DAO.Delete(tt.ID);
					LoadTags();
					ClearTaggedFoodTypes();
				}
			}
			ulvTagList.Focus();
		}

	}
}

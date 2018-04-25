using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class frmEnterTransUnits : Form
	{
		/// Properties
		/// 
		private decimal _GrossWeight = 0;
		public decimal GrossWeight
		{
			get
			{
				return _GrossWeight;
			}
		}
		private int _NItems = 1;
		public int NItems
		{
			get
			{
				return _NItems;
			}
		}
		private string _UnitsMode = "";
		public string UnitsMode
		{
			get
			{
				return _UnitsMode;
			}
		}
		// Globals
		decimal containerWt, totalWt;
		bool Initialized;
		decimal wtmodefoodweight;
		int wtmodemultiplier;
		string selectedfoodtypeid = "";
		string selectedcontainertypeid = "";
		decimal selectednumcontainers = 0;
		int selectedeachformatid = 0;
		decimal selectedeachitemcount = 0;
		string selecteditemname = "";
		string selectedeachformatname = "";
		int priortabindex = 0;

		/// <summary>
		/// Clean up UI behavior issues when first invoking this form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmEnterTransUnits_Shown(object sender, EventArgs e)
		{
			tabControl1.Focus();
			cdTransactionWt.EditValue = "0.";
			switch (tabControl1.SelectedIndex)
			{
				case 0:
					{
						cdTransactionWt.EditValue = wtmodefoodweight;
						cdTransactionWt.Value = wtmodefoodweight;
						cdTransactionWt.Focus();
						cdTransactionWt.SelectAll();
						cdTransactionWt.SelectAll();
						cdTransactionWt.Focus();
						break;
					}
				case 1:
					{
						if ((selectedfoodtypeid != "") && (selectedfoodtypeid != null) && (selectedcontainertypeid != "") && (selectedcontainertypeid != null))
						{
							ceNumofContainers.EditValue = selectednumcontainers;
							ceNumofContainers.Update();
							ceNumofContainers.Focus();
							ceNumofContainers.SelectAll();
						}
						break;
					}
				case 2:
					{
						if (selectedeachformatid > 0)
						{
							ceItemCount.Focus();
							ceItemCount.Update();
							ceItemCount.SelectAll();
						}
						break;
					}
			}
		}


		/// <summary>
		/// Basic constructor - init to Weight mode
		/// </summary>
		/// <param name="transmultiplier">nItems to initialize to.  Must be at least 1</param>
		public frmEnterTransUnits(int transmultiplier, decimal currtotalwt, decimal currcontainerwt)
		{
			InitializeComponent();
			//
			Initialized = false;
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
			containerWt = currcontainerwt;
			totalWt = currtotalwt;
			tabControl1.SelectedIndex = 1;	// Pre-Init to force event to happen later
			selectedfoodtypeid = "";
			selectedcontainertypeid = "";
			cdTransactionWt.Text = "";
			if (transmultiplier >= 1) neTransMultiplier.Value = transmultiplier;
			else neTransMultiplier.Value = 1;
			updateProductUI();
			Initialized = true;
			tabControl1.SelectedIndex = 0;	// Init to Weight w/event
			initTab();

		}
		
		/// <summary>
		/// Constructor - init to Weight mode but initialize food and container types already selected.
		/// </summary>
		/// <param name="foodtype">Food TypeID to initialize to.  Can be blank.</param>
		/// <param name="containertype">Container TypeID to initialize to.  Can be blank.</param>
		/// <param name="wtfoodweight">Initialize the food weight to this.</param>
		/// <param name="wtmultiplier">nItems to initialize to.  Must be at least 1</param>
		public frmEnterTransUnits(string foodtype, string containertype, decimal wtfoodweight,
			int wtmultiplier, decimal currcontainerwt)
		{
			InitializeComponent();
			//
			Initialized = false;
			containerWt = currcontainerwt;
			totalWt = wtfoodweight;
			selectedfoodtypeid = foodtype;
			selectedcontainertypeid = containertype;
			wtmodefoodweight = wtfoodweight;
			wtmodemultiplier = wtmultiplier;
			selectednumcontainers = 0;
			selectedeachformatid = 0;
			selectedeachitemcount = 0;
			tabControl1.SelectedIndex = 0;	// Init to Weight (no event happens)
			updateProductUI();
			Initialized = true;
			initTab();
		}

		/// <summary>
		/// Constructor - init to Volume mode but initialize food and container types already selected.
		/// </summary>
		/// <param name="foodtype">Food TypeID to initialize to.  Can be blank.</param>
		/// <param name="containertype">Container TypeID to initialize to.  Can be blank.</param>
		/// <param name="volcontainermultiplier">Container multiplier to initialize to.  
		/// Must be at least 1</param>
		public frmEnterTransUnits(string foodtype, string containertype, decimal volcontainermultiplier
			, decimal currtotalwt, decimal currcontainerwt)
		{
			InitializeComponent();
			//
			Initialized = false;
			containerWt = currcontainerwt;
			totalWt = currtotalwt;
			selectedfoodtypeid = foodtype;
			selectedcontainertypeid = containertype;
			selectednumcontainers = volcontainermultiplier;
			selectedeachformatid = 0;
			selectedeachitemcount = 0;
			updateProductUI();
			Initialized = true;
			tabControl1.SelectedIndex = 1;	// Init to Volume  (no event happens)
			initTab();
		}

		/// <summary>
		/// Constructor - init to Each mode but initialize food and container types already selected.
		/// </summary>
		/// <param name="foodtype">Food TypeID to initialize to.  Can be blank.</param>
		/// <param name="containertype">Container TypeID to initialize to.  Can be blank.</param>
		/// <param name="itemtype">Each item format TypeID to initialize to.  Can be zero.</param>
		/// <param name="itemcount">Each item count to initialize to.  Can be zero.</param>
		public frmEnterTransUnits(string foodtype, string containertype, int eachitemtype,
			decimal eachitemcount, decimal currtotalwt, decimal currcontainerwt)
		{
			InitializeComponent();
			//
			Initialized = false;
			containerWt = currcontainerwt;
			totalWt = currtotalwt;
			selectedfoodtypeid = foodtype;
			selectedcontainertypeid = containertype;
			selectedeachformatid = eachitemtype;
			selectedeachitemcount = eachitemcount;
			selectednumcontainers = 0;
			///
			updateProductUI();
			
			Initialized = true;
			tabControl1.SelectedIndex = 2;	// Init to Each  (no event happens)
			initTab();
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

		private void cdTransactionWt_EditValueChanged(object sender, EventArgs e)
		{
			checkQuantityReady();
		}

		private void checkQuantityReady()
		{
			// Check Whether the Quantity is filled out, take appropriate action
			switch (tabControl1.SelectedIndex)
			{
				case 0: // Weight
					{
						if (cdTransactionWt.Text != "") bDone.Show();
						else bDone.Hide();
						break;
					}
				case 1: // Volume
					{
						if ((ceNumofContainers.Text != "") &&
							(lCurrFoodType.Text != "") && (lCurrContainerType.Text != ""))
						{
							bDone.Show();
						}
						else bDone.Hide();
						break;
					}
				case 2: // Each
					{
						if ((lFoodEach_TypeName.Text != "") &&
						(lItemEach_TypeName.Text != "") && (ceItemCount.Text != ""))
						{
							bDone.Show();
						}
						else bDone.Hide();
						break;
					}
			}
		}

		/// <summary>
		/// Choose Food type from volume tab.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChooseFood_Vol_Click(object sender, EventArgs e)
		{
			decimal volumeweight = 0;
			decimal volumeunits = 0;
			int volumeunittype = 0;
			frmTypePicker tp = new frmTypePicker(VWA4Common.GlobalSettings.SessionTracker_TermID, "food");
			if (tp.ShowDialog() == DialogResult.OK)
			{
				/// Note that the return values are in Global Settings - indicate to caller
				if (VWA4Common.GlobalSettings.GetFoodVolumeData(tp.TypeIDSelected,
					out volumeweight, out volumeunits, out volumeunittype))
				{ // Food Type Has volume data
					selectedfoodtypeid = tp.TypeIDSelected;
					lCurrFoodType.Text = tp.TypeNameSelected;
					VWA4Common.GlobalSettings.frmUnits_FoodTypeID = selectedfoodtypeid;
					VWA4Common.GlobalSettings.frmUnits_FoodTypeIDUpdated = true;

					//sFoodTypeID = VWA4Common.GlobalSettings.frmTypePicker_TypeIDSelected;
					//sFoodTypeName = VWA4Common.GlobalSettings.frmTypePicker_TypeNameSelected;
					//sFoodTypeCost = VWA4Common.GlobalSettings.frmTypePicker_FoodTypeCostSelected;
					checkQuantityReady();
					return;
				}
				else
				{ // Food Type doesn't have volume data
					MessageBox.Show("Selected Food Type has no volume data configured for it!");
					VWA4Common.GlobalSettings.frmUnits_FoodTypeIDUpdated = false;
					lCurrFoodType.Text = "";
					bDone.Hide();
				}
			}
			else
				VWA4Common.GlobalSettings.frmUnits_FoodTypeIDUpdated = false;
		}

		/// <summary>
		/// Choose container type from Volume tab.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChooseContainer_Vol_Click(object sender, EventArgs e)
		{
			decimal volume = 0;
			int volumeunittype = 0;
			frmTypePicker tp = new frmTypePicker(VWA4Common.GlobalSettings.SessionTracker_TermID, "container");
			if (tp.ShowDialog() == DialogResult.OK)
			{


				/// Note that the return values are in Global Settings - indicate to caller
				if (VWA4Common.GlobalSettings.GetContainerVolumeData(tp.TypeIDSelected,
					out volume, out volumeunittype))
				{ // Container Type Has volume data
					lCurrContainerType.Text = tp.TypeNameSelected;
					selectedcontainertypeid = 
						tp.TypeIDSelected;
					VWA4Common.GlobalSettings.frmUnits_ContainerTypeID = selectedcontainertypeid;
					VWA4Common.GlobalSettings.frmUnits_ContainerTypeUpdated = true;
					
					//sContainerTypeName = VWA4Common.GlobalSettings.frmTypePicker_TypeNameSelected;
					//sContainerTypeCost = VWA4Common.GlobalSettings.frmTypePicker_ContainerTypeCostSelected;
					//sSingleContainerWt = VWA4Common.GlobalSettings.frmTypePicker_ContainerWtSelected;
					//lCurrContainerType.Text = sContainerTypeName;
					//decimal dSingleContainerWt = decimal.Parse(sSingleContainerWt);
					//sTotalTareWt = (dSingleContainerWt * nItems_CurrTrans).ToString();
					checkQuantityReady();
					return;
				}
				else
				{ // Container Type doesn't have volume data
					MessageBox.Show("Selected Container Type has no volume data configured for it!");
					VWA4Common.GlobalSettings.frmUnits_ContainerTypeUpdated = false;
					lCurrContainerType.Text = "";
					bDone.Hide();
				}
			}
			else
				VWA4Common.GlobalSettings.frmUnits_ContainerTypeUpdated = false;
		}

		/// <summary>
		/// Choose Food Type from Each tab.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChooseFood_Each_Click(object sender, EventArgs e)
		{
			frmTypePicker tp = new frmTypePicker(VWA4Common.GlobalSettings.SessionTracker_TermID, "food");
			if (tp.ShowDialog() == DialogResult.OK)
			{
				selectedfoodtypeid = tp.TypeIDSelected;
				/// Set a pack type as default for chosen food type
				if (VWA4Common.GlobalSettings.GetEachFormatDefault(selectedfoodtypeid, out selectedeachformatid,
					out selectedeachformatname))
				{
					// An Each Format was picked - get the name
					decimal eachquantity = 0;
					decimal wtmultiplier = 0;
					int unitswtid = 0;
					int order = 0;
					string description = "";
					// Get Item name from Item ID
					VWA4Common.GlobalSettings.GetEachFormatDataFromID(
						selectedeachformatid, out selectedeachformatname, out eachquantity,
						out wtmultiplier, out unitswtid, out order, out description);
					lItemEach_TypeName.Text = selectedeachformatname;
					lFoodEach_TypeName.Text = tp.TypeNameSelected;
					VWA4Common.GlobalSettings.frmUnits_FoodTypeIDUpdated = true;
				}
				else
				{
					MessageBox.Show("No Each Formats defined for " + tp.TypeNameSelected);
					selectedfoodtypeid = "";
					selectedeachformatname = "";
					selectedeachformatid = 0;
					lItemEach_TypeName.Text = "";
					VWA4Common.GlobalSettings.frmUnits_FoodTypeIDUpdated = false;
				}

				checkQuantityReady();
				return;
			}
			else
				VWA4Common.GlobalSettings.frmUnits_FoodTypeIDUpdated = false;
		}

		/// <summary>
		/// Choose Items type from Each tab.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChooseItem_Each_Click(object sender, EventArgs e)
		{
			if ((selectedfoodtypeid != "") && (selectedfoodtypeid != null))
			{
				frmEachFormatPicker fp = new frmEachFormatPicker(selectedfoodtypeid);
				if (fp.ShowDialog() == DialogResult.OK)
				{
					selectedeachformatid = int.Parse(VWA4Common.GlobalSettings.frmEachFormats_FormatIDSelected);
					// An Each Format was picked - get the name
					selectedeachformatname = "";
					decimal eachquantity = 0;
					decimal wtmultiplier = 0;
					int unitswtid = 0;
					int order = 0;
					string description = "";
					// Get Item name from Item ID
					VWA4Common.GlobalSettings.GetEachFormatDataFromID(
						selectedeachformatid, out selectedeachformatname, out eachquantity,
						out wtmultiplier, out unitswtid, out order, out description);
					lItemEach_TypeName.Text = selectedeachformatname;
					checkQuantityReady();
					return;
				}
			}
			else
			{
				MessageBox.Show("You must select a Food Type before you can select an Item Type!");
			}
		}

		private void ceNumofContainers_EditValueChanged(object sender, EventArgs e)
		{
			checkQuantityReady();
		}

		/// <summary>
		/// Change the Tab index.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tabControl1_TabIndexChanged(object sender, EventArgs e)
		{
			if (!Initialized) return;
			initTab();
		}

		private void initTab()
		{
			decimal fvolumeweight = 0;
			decimal fvolumeunits = 0;
			int fvolumeunittype = 0;
			decimal cvolume = 0;
			int cvolumeunittype = 0;
			bDone.Hide();
			switch (tabControl1.SelectedIndex)
			{
				case 0: // Weight
					{
						lFormTitle.Text = "Enter Gross Waste Weight";
						if (wtmodefoodweight < 0) wtmodefoodweight = 0;
						if (wtmodemultiplier < 1) wtmodemultiplier = 1;
						neTransMultiplier.Value = wtmodemultiplier;
						cdTransactionWt.EditValue = wtmodefoodweight;
						cdTransactionWt.Value = wtmodefoodweight;
						cdTransactionWt.Focus();
						cdTransactionWt.Update();
						cdTransactionWt.SelectAll();
						break;
					}
				case 1: // Volume
					{
						/// Check to make sure if Food and Container Types are already selected,
						/// that they have volume information
						lCurrFoodType.Text = "";
						lCurrContainerType.Text = "";
						if (selectednumcontainers < 0) selectednumcontainers = 0;
						ceNumofContainers.Value = selectednumcontainers;
						if ((selectedfoodtypeid != "") && (selectedfoodtypeid != null))
						{
							if (!VWA4Common.GlobalSettings.GetFoodVolumeData(selectedfoodtypeid,
								out fvolumeweight, out fvolumeunits, out fvolumeunittype))
							{ // Food Type not qualified for volume entry
								if (MessageBox.Show("Food Type is already selected in Current Transaction.\n It does not support volume-based data entry.\n"
									+ "\nProceed anyway?", "Food Type Volume Error", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
								{
									// Abort switch to Volume tab
									tabControl1.SelectedIndex = priortabindex;
									return;
								}
								// Continue - user will supply a new Food Type
							}
							else
							{ // Food Type is qualified for volume entry - get the name
								string rettypename = "";
								VWA4Common.GlobalSettings.GetTypeNameFromTypeID("food",
									selectedfoodtypeid, out rettypename);
								lCurrFoodType.Text = rettypename;
							}
						}
						if ((selectedcontainertypeid != "") && (selectedcontainertypeid != null))
						{
							// Container
							if (!VWA4Common.GlobalSettings.GetContainerVolumeData(selectedcontainertypeid,
								out cvolume, out cvolumeunittype))
							{ // Container Type not qualified for volume entry
								if (MessageBox.Show("Container Type is already selected in Current Transaction.\n It does not support volume-based data entry.\n"
									+ "\nProceed anyway?", "Container Type Volume Error", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
								{
									// Abort switch to Volume tab
									tabControl1.SelectedIndex = priortabindex;
									return;
								}
								// Continue - user will supply a new Food Type
							}
							else
							{ // Container Type is qualified for volume entry - get the name
								string rettypename = "";
								VWA4Common.GlobalSettings.GetTypeNameFromTypeID("container",
									selectedcontainertypeid, out rettypename);
								lCurrContainerType.Text = rettypename;
							}
						}


						if ((selectedfoodtypeid != "") && (selectedfoodtypeid != null) && (selectedcontainertypeid != "") && (selectedcontainertypeid != null))
						{
							ceNumofContainers.EditValue = selectednumcontainers;
							ceNumofContainers.Focus(); 
							ceNumofContainers.SelectAll();
						}
						lFormTitle.Text = "Enter Volume Data";
						break;
					}

				case 2: // Each
					{
						lFoodEach_TypeName.Text = "";
						string eachformatname = "";
						lItemEach_TypeName.Text = "";
						if (selectedeachitemcount < 0) selectedeachitemcount = 0;
						if ((selectedfoodtypeid != "") && (selectedfoodtypeid != null))
						{
							string rettypename = "";
							VWA4Common.GlobalSettings.GetTypeNameFromTypeID("food",
								selectedfoodtypeid, out rettypename);
							lFoodEach_TypeName.Text = rettypename;
							// Food Type has to be selected before Each Format can be selected
							lItemEach_TypeName.Text = "";
							if (selectedeachformatid > 0)
							{
								decimal eachquantity = 0;
								decimal wtmultiplier = 0;
								int unitswtid = 0;
								int order = 0;
								string description = "";
								// Get Item name from Item ID
								VWA4Common.GlobalSettings.GetEachFormatDataFromID(
									selectedeachformatid, out eachformatname, out eachquantity,
									out wtmultiplier, out unitswtid, out order, out description);
							}
							else /// Add an auto-select for first if not already chosen
							{
								VWA4Common.GlobalSettings.GetEachFormatDefault(selectedfoodtypeid,
									out selectedeachformatid, out eachformatname);
							}

						}
						else
						{
							// make sure each format type is also null
							selectedeachformatid = 0;
							selectedeachformatname = "";
						}
						lItemEach_TypeName.Text = eachformatname;
						ceItemCount.Value = selectedeachitemcount;
						ceItemCount.Focus();
						ceItemCount.Update();
						ceItemCount.SelectAll();
						lFormTitle.Text = "Enter Item Data";
						break;
					}
			}
			// We changed the tab index - so...
			/// Clear out all data - reinitialize
			VWA4Common.GlobalSettings.frmUnits_ContainerTypeUpdated = false;
			VWA4Common.GlobalSettings.frmUnits_FoodTypeIDUpdated = false;
		}


		private void ceItemCount_EditValueChanged(object sender, EventArgs e)
		{
			checkQuantityReady();
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			// Save the Data and exit
			switch (tabControl1.SelectedIndex)
			{
				case 0: // Weight
					{
						if (cdTransactionWt.Value > 0)
						{
							//VWA4Common.GlobalSettings.frmUnits_UnitsMode = "Wt";
							_UnitsMode = "Wt";
							//
							//VWA4Common.GlobalSettings.frmUnits_Wt_TransWt =
							//    cdTransactionWt.Value.ToString();
							//VWA4Common.GlobalSettings.frmUnits_Wt_TransMultiplier =
							//    neTransMultiplier.Value.ToString();
							_NItems = int.Parse(neTransMultiplier.Value.ToString());
							_GrossWeight = cdTransactionWt.Value * _NItems ;
							if ((containerWt > cdTransactionWt.Value))
							{
								MessageBox.Show("Current container type weight (" + containerWt.ToString() +
									") is greater than the total weight you entered!\n Please enter a higher food weight - can't have negative net (food waste) weight.");
								return;
							}
						}
						else
						{
							MessageBox.Show("Food Weight must be greater than 0.0 lbs!");
							return;
						}
						break;
					}
				case 1: // Volume
					{
						if (ceNumofContainers.Value > 0)
						{
							//VWA4Common.GlobalSettings.frmUnits_UnitsMode = "Vol";
							_UnitsMode = "Vol";
							//
							VWA4Common.GlobalSettings.frmUnits_FoodTypeID =
								selectedfoodtypeid;
							VWA4Common.GlobalSettings.frmUnits_ContainerTypeID =
								selectedcontainertypeid;
							VWA4Common.GlobalSettings.frmUnits_Vol_ContainerMultiplier =
								ceNumofContainers.Value.ToString("######.##");
						}
						else
						{
							MessageBox.Show("Number of containers must be greater than 0.0!");
						return;
						}
						break;
					}
				case 2: // Each
					{
						if (ceItemCount.Value > 0)
						{
							//VWA4Common.GlobalSettings.frmUnits_UnitsMode = "Each";
							_UnitsMode = "Each";
							//
							VWA4Common.GlobalSettings.frmUnits_FoodTypeID =
								selectedfoodtypeid;
							VWA4Common.GlobalSettings.frmUnits_Each_EachFormatID =
								selectedeachformatid.ToString();
							VWA4Common.GlobalSettings.frmUnits_Each_ItemCount =
								ceItemCount.Value.ToString("######.##");
						}
						else
						{
							MessageBox.Show("Item count must be greater than 0.0!");
							return;
						}
						break;
					}
			}
			DialogResult = DialogResult.OK;
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void cdTransactionWt_EditValueChanged_1(object sender, EventArgs e)
		{
			bDone.Show();
		}

		private void ceItemCount_Click(object sender, EventArgs e)
		{
			ceItemCount.Focus();
			ceItemCount.SelectAll();
		}

		private void ceNumofContainers_Click(object sender, EventArgs e)
		{
			ceNumofContainers.Focus();
			ceNumofContainers.SelectAll();
		}

		private void neTransMultiplier_Click(object sender, EventArgs e)
		{
			neTransMultiplier.Focus();
			neTransMultiplier.SelectAll();
		}

		private void cdTransactionWt_Click(object sender, EventArgs e)
		{
			cdTransactionWt.Focus();
				cdTransactionWt.SelectAll();
		}

	}
}

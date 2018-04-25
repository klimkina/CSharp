using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class frmTypePicker : Form
	{
		private string _TypeIDSelected = "";
		public string TypeIDSelected
		{
			get
			{
				return _TypeIDSelected;
			}
		}

		private string _TypeNameSelected = "";
		public string TypeNameSelected
		{
			get
			{
				return _TypeNameSelected;
			}
		}

		private double _FoodCostofSelectedFoodType = -1;
		public double FoodCostofSelectedFoodType
		{
			get
			{
				return _FoodCostofSelectedFoodType;
			}
		}

		private double _ContainerCostofSelectedContainerType = -1;
		public double ContainerCostofSelectedContainerType
		{
			get
			{
				return _ContainerCostofSelectedContainerType;
			}
		}

		private double _ContainerWtofSelectedContainerType = -1;
		public double ContainerWtofSelectedContainerType
		{
			get
			{
				return _ContainerWtofSelectedContainerType;
			}
		}

		public frmTypePicker(string termID, string type)
		{
			InitializeComponent();

			Init(termID, type);
		}

		void Init(string termID, string type)
		{
			updateProductUI();
			string typex = type;
			if (typex == "beo") typex = "event order";
			lFormTitle.Text = "Select " + typex;
			ucTrackerViewer1.Clear();
			ucTrackerViewer1.TermID = termID;
			ucTrackerViewer1.LoadTree(type);
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


		private void ucTrackerViewer1_TrackerButtonChanged(object sender, UCTrackerViewer.TrackerViewerEventArgs e)
		{
			_TypeIDSelected = e.TypeID;
			_TypeNameSelected = e.Name;
			
			
			string typename = ucTrackerViewer1.TypeName;

			// Determine Selected Type and handle data above and beyond the TypeID and TypeName
			switch (typename.ToLower())
			{
				case "food":
					{
						_FoodCostofSelectedFoodType = ucTrackerViewer1.Cost;
						break;
					}
				case "container":
					{
						_ContainerCostofSelectedContainerType = ucTrackerViewer1.Cost;
						_ContainerWtofSelectedContainerType = ucTrackerViewer1.TareWeight;
						break;
					}
			}
			DialogResult = DialogResult.OK;
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			VWA4Common.GlobalSettings.frmTypePicker_TypeIDSelected = string.Empty;
			VWA4Common.GlobalSettings.frmTypePicker_TypeNameSelected = string.Empty;
			DialogResult = DialogResult.Cancel;
		}

	}
}

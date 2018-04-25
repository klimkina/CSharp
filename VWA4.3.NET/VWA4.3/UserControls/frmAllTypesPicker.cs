using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
	public partial class frmAllTypesPicker : Form
	{
		public frmAllTypesPicker()
		{
			InitializeComponent();
			Init("Food", "Select Food Type");
		}

		public frmAllTypesPicker(string typedim, string titletext)
		{
			InitializeComponent();
			Init(typedim, titletext);
		}

		private string _TypeID = "";
		public string TypeID
		{
			get { return _TypeID; }
		}
		private string _TypeName = "";
		public string TypeName
		{
			get { return _TypeName; }
		}

		private void Init(string typedim, string titletext)
		{
			ucTreeView1.InitTreeView(VWA4Common.GlobalSettings.CurrentTypeCatalogID.ToString(),
			typedim, "0");
			lType.Text = titletext;
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}
		private void ucTreeView1_TreeViewIDChanged(object sender, UCTreeView.TreeViewEventArgs e)
		{
			_TypeID = e.ID;
			_TypeName = e.Name;
			DialogResult = DialogResult.OK;
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void frmAllTypesPicker_Load(object sender, EventArgs e)
		{

		}

	}
}

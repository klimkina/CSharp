using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class CustomTypeIDFilter : Form
    {
        public CustomTypeIDFilter(string typeCatalog, string typeName)
        {
            InitializeComponent();
            this.label1.Text = "Change selected " + typeName + "Types to: ";
            this.ucTreeView1.EnableCheckboxes = false;
            this.ucTreeView1.InitTreeView(typeCatalog, typeName, "");
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}
        public CustomTypeIDFilter(string typeCatalog, string typeName, string id)
        {
            InitializeComponent();
            this.Width += 100;
            this.label1.Text = "Check " + typeName + "Types to Display: ";
            this.ucTreeView1.EnableCheckboxes = true;
            this.ucTreeView1.InitTreeView(typeCatalog, typeName, id);
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}
        public string GetFilters()
        {
            return ucTreeView1.GetTreeFilters();
        }
        public string GetFilters(ref string filterDisplay)
        {
            return ucTreeView1.GetTreeFilters(ref filterDisplay);
        }
        public string TypeID()
        {
            return ucTreeView1.ID;
        }
    }
}

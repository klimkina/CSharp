using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using System.Text.RegularExpressions;

namespace UserControls
{
    public partial class CustomReplace : Form
    {
        private bool _IsValueList = false;
        private string _ColumnName;
        public CustomReplace() : this("", typeof(string))
        {
        }
        public CustomReplace(string columnName, Type columnType)
        {
            InitializeComponent();
            _ColumnName = columnName;
            if (_ColumnName == "Timestamp") 
                smartDateTimePicker1.Visible = true;
            else
            {
                this.Height -= 20;
                ultraMaskedEdit1.Visible = true;
                ultraMaskedEdit1.MinValue = 0;

                if (columnType == typeof(int))
                {
                    this.ultraMaskedEdit1.SpinButtonDisplayStyle = SpinButtonDisplayStyle.OnRight;
                    // You can also set the style of the spin buttons.
                    this.ultraMaskedEdit1.SpinButtonStyle = UIElementButtonStyle.PopupBorderless;
                    // The SpinWrap property gets/sets a value indicating whether the control's spin button
                    // should wrap the value of a spinnable section. If true the spin button will wrap the
                    // value incremented/decremented based on its Min/Max value.
                    this.ultraMaskedEdit1.SpinWrap = true;

                    ultraMaskedEdit1.InputMask = "nnnnnnnnn";
                }
                else if (Regex.IsMatch(_ColumnName, "Cost")) //double non-negative
                    ultraMaskedEdit1.InputMask = "nnn,nnn,nnn.nn";
                else
                    ultraMaskedEdit1.InputMask = "nnn,nnn,nnn.nnnnnn";
            }
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}
        public CustomReplace(string columnName, ValueList objValueList)
        {
            InitializeComponent();
            ultraComboEditor1.Visible = true;
            this.Height -= 20;

            foreach(ValueListItem item in objValueList.ValueListItems)
                ultraComboEditor1.Items.Add(item.DataValue, item.DisplayText);
            if(objValueList.ValueListItems.Count > 0)
                ultraComboEditor1.Text = ultraComboEditor1.Items[0].ToString();
            _IsValueList = true;
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}
        public string NewValue()
        {
            if (_IsValueList)
                return ultraComboEditor1.SelectedItem.DataValue.ToString();
            else if (_ColumnName == "Timestamp")
                return smartDateTimePicker1.Value.ToString();
            else return ultraMaskedEdit1.Value.ToString();
        }
    }
}
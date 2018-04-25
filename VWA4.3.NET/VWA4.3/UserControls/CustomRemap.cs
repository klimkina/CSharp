using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Infragistics.Win.UltraWinEditors;

namespace UserControls
{
    public partial class CustomRemap : Form
    {
        private Hashtable _RemapList = new Hashtable();
        private string _Type;
        public class RemapItem
        {
            string _TypeID;
            int _Index;
            decimal _Percentage;
            double _Weight;

            public string TypeID
            {
                get { return _TypeID; }
                set { _TypeID = value; }
            }
            public int Index
            {
                get { return _Index; }
                set { _Index = value; }
            }
            public decimal Percentage
            {
                get { return _Percentage; }
                set { this._Percentage = value; }
            }
            public double Weight
            {
                get { return _Weight; }
                set { _Weight = value; }
            }
            public override string ToString()
            {
                return _TypeID + " = " + _Percentage + "%";
            }
            public RemapItem(string name, int idx)
                : this(name, idx, 0, 0)
            {
            }
            public RemapItem(string typeID, int idx, decimal percentage, double weight)
            {
                _TypeID = typeID;
                _Index = idx;
                _Percentage = percentage;
                _Weight = weight;
            }
            public RemapItem(RemapItem param)
            {
                _TypeID = param._TypeID;
                _Index = param._Index;
                _Percentage = param._Percentage;
                _Weight = param._Weight;
            }
        }

        public CustomRemap(string columnName)
        {
            InitializeComponent();
            _Type = Regex.Replace(columnName, "TypeID", "");
            label1.Text = "Remap " + _Type + " Type:";
            groupBox1.Text = "To Following " + _Type + "Types:";
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}
        public string TypeID()
        {
            return _RemapID;
        }
        private string CalcNextTypeID()
        {
            foreach (string key in _RemapList.Keys)
            {
                RemapItem ri = (RemapItem)_RemapList[key];
                if (_TotalWeight == 0)
                    return ri.TypeID;
                if (ri.Weight / _TotalWeight < (double)ri.Percentage / 100)
                    return ri.TypeID;
            }
            return "";
        }
        private double _TotalWeight;
        public string GetNextTypeID(double weight)
        {
            string next = CalcNextTypeID();
            ((RemapItem)_RemapList[next]).Weight += weight;
            _TotalWeight += weight;
            return next;
        }
        private int GetActiveControdIndex()
        {
            return int.Parse(Regex.Replace(ActiveControl.Parent.Name, "ultraTextEditor", ""));
        }
        private void ucTreeView1_Load(object sender, EventArgs e)
        {
            this.ucTreeView1.InitTreeView("0", _Type, "");
            this.ucTreeView1.Visible = true;
            this.ucTreeView1.Focus();
            this.ucTreeView1.BringToFront();
        }
        private string _RemapID = "";
        private void ucTreeView1_TreeViewIDChanged(object sender, UCTreeView.TreeViewEventArgs e)
        {
            if (ActiveControl.Parent == ultraOriginalType)
                _RemapID = e.ID;
            else
            {
                int idx = int.Parse(Regex.Replace(ActiveControl.Parent.Name, "ultraTextEditor", ""));// contro index
            
                if (_RemapList[e.ID] == null) // add two items to hash - for search by ID and by control index
                {
                    if (_RemapList[idx] != null)//hash for this index alredy exists
                        _RemapList.Remove(((RemapItem)_RemapList[idx]).TypeID);
                    else
                        _RemapList.Add(idx, new RemapItem(e.ID, idx));
                    _RemapList.Add(e.ID, new RemapItem(e.ID, idx));
                }
                else
                {
                    if (((RemapItem)_RemapList[e.ID]).Index != idx)
                        MessageBox.Show(this, "Error " + _Type + "Type already exists!", "Input Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if ( ActiveControl.Parent.GetType() == typeof(UltraTextEditor))
                ((UltraTextEditor)this.ActiveControl.Parent).Value = e.Name;
            ActiveControl.Parent.Focus();
            this.ucTreeView1.Visible = false;
        }
        private void SetTreeViewID(object sender, BeforeEditorButtonDropDownEventArgs e)
        {
            string currID = "";
            //   Set the value  
            if (ActiveControl.Parent.GetType() == typeof(UltraTextEditor))
            {
                UltraTextEditor te = this.ActiveControl.Parent as UltraTextEditor;
                if (te.Value != null && te.Value.ToString() != "")
                    if (te.Name == "ultraOriginalType")
                        currID = _RemapID;
                    else
                        currID = ((RemapItem)_RemapList[GetActiveControdIndex()]).TypeID;
            }
            ucTreeView1.ID = currID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.IsValid())// check all values before consume
            {
                if (_TotalPercent > 0)
                {
                    for (int i = 1; i < _currIndex; i++)
                    {
                        decimal percents = ((System.Windows.Forms.NumericUpDown)groupBox1.Controls.Find("numericUpDown" + (i), false)[0]).Value;
                        ((RemapItem)_RemapList[((RemapItem)_RemapList[i]).TypeID]).Percentage = percents;
                        _RemapList.Remove(i);
                    }
                    if (_TotalPercent < 100)
                        _RemapList.Add("", new RemapItem("", 0, 100 - _TotalPercent, 0)); //dummy item
                }
            }
            else
            {
                MessageBox.Show(this, "Set appropriate percents for remapping " + _Type + " Type!", "Input Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }
        private decimal _TotalPercent = 0;
        private void CalcTotalPercent(object sender, EventArgs e)
        {
            _TotalPercent += ((System.Windows.Forms.NumericUpDown)sender).Value;
        }
        private void SetMaxPercent(object sender, EventArgs e)
        {
            _TotalPercent -= ((System.Windows.Forms.NumericUpDown)sender).Value;
            ((System.Windows.Forms.NumericUpDown)sender).Maximum = 100M - _TotalPercent;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_currIndex > 2)
            {
                _currIndex--;
                if (_RemapList[_currIndex] != null)// delete from hash
                {
                    _RemapList.Remove(((RemapItem)_RemapList[_currIndex]).TypeID);
                    _RemapList.Remove(_RemapList[_currIndex]);
                }
                _TotalPercent -= ((System.Windows.Forms.NumericUpDown)groupBox1.Controls.Find("numericUpDown" + (_currIndex), false)[0]).Value;
                groupBox1.Controls.RemoveByKey("ultraTextEditor" + (_currIndex));
                groupBox1.Controls.RemoveByKey("numericUpDown" + (_currIndex));
                this.groupBox1.Height -= 25;
                this.Height -= 25;
            }
            else
                MessageBox.Show(this, "At least two " + _Type + " Types should be mapped. Use Replace for changing " + _Type + " Type!", "Input Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private int _currIndex = 3;
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (((Infragistics.Win.UltraWinEditors.UltraTextEditor)groupBox1.Controls.Find("ultraTextEditor" + (_currIndex - 1), false)[0]).Value == null ||
                this.ultraTextEditor1.Value == null)
            {
                MessageBox.Show(this, "Error - fill out previous " + _Type + "Types!", "Input Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Suspend the form layout and add two buttons.
            System.Windows.Forms.NumericUpDown numericUpDown = new System.Windows.Forms.NumericUpDown();
            Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();

            System.Drawing.Point buttonPoint = new System.Drawing.Point(this.groupBox1.Location.X, this.groupBox1.Location.Y + (_currIndex - 3)*25 - 7);
            this.groupBox1.Height += 25;
            this.Height += 25;
            // 
            // numericUpDown
            // 
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(6 + buttonPoint.X, 47 + buttonPoint.Y);
            numericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            numericUpDown.Name = "numericUpDown" + _currIndex;
            numericUpDown.TabIndex = (_currIndex - 2)*3 + 9;
            numericUpDown.Size = new System.Drawing.Size(92, 21);
            numericUpDown.Leave += new System.EventHandler(this.CalcTotalPercent);
            numericUpDown.Enter += new System.EventHandler(this.SetMaxPercent);

            // 
            // ultraTextEditor
            // 
            dropDownEditorButton.Control = ucTreeView1;
            ultraTextEditor.ButtonsRight.Add(dropDownEditorButton);
            ultraTextEditor.Location = new System.Drawing.Point(99 + buttonPoint.X, 46 + buttonPoint.Y);
            ultraTextEditor.Name = "ultraTextEditor" + _currIndex;
            ultraTextEditor.Size = new System.Drawing.Size(185, 21);
            ultraTextEditor.TabIndex = (_currIndex - 2)*3 + 10;
            ultraTextEditor.BeforeEditorButtonDropDown += new Infragistics.Win.UltraWinEditors.BeforeEditorButtonDropDownEventHandler(this.SetTreeViewID);

            this.groupBox1.Controls.AddRange(new Control[] { numericUpDown, ultraTextEditor });

            _currIndex++;
        }

        private void panel1_Validating(object sender, CancelEventArgs e)
        {
            if(this.ActiveControl.Text != "Cancel")
                if (this.ultraOriginalType.Value == null || this.ultraOriginalType.Value.ToString() == "")
                {
                    MessageBox.Show(this, "Set appropriate " + _Type + " Type for remapping!", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
        }

        private void groupBox1_Validating(object sender, CancelEventArgs e)
        {
            if (this.ultraTextEditor1.Value == null)
            {
                MessageBox.Show(this, "Set appropriate " + _Type + " Types for remapping!", "Input Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else if(this.numericUpDown1.Value <= 0)
            {
                MessageBox.Show(this, "Set appropriate Percentage for remapping!", "Input Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
                for(int i = 1; i < _currIndex; i++)
                    if (((Infragistics.Win.UltraWinEditors.UltraTextEditor)groupBox1.Controls.Find("ultraTextEditor" + (_currIndex - 1), false)[0]).Value == null)
                    {
                        MessageBox.Show(this, "Set appropriate " + _Type + " Types for remapping!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                    else if (((System.Windows.Forms.NumericUpDown)groupBox1.Controls.Find("numericUpDown" + (i), false)[0]).Value <= 0)
                    {
                        MessageBox.Show(this, "Set appropriate Percentage for remapping!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
        }
        private bool IsValid()
        {
            if (this.ultraOriginalType.Value == null || this.ultraOriginalType.Value.ToString() == "")
                return false;
            if (this.ultraTextEditor1.Value == null)
                return false;
            for (int i = 1; i < _currIndex; i++)
                if (((Infragistics.Win.UltraWinEditors.UltraTextEditor)groupBox1.Controls.Find("ultraTextEditor" + (_currIndex - 1), false)[0]).Value == null)
                    return false;
                else if (((System.Windows.Forms.NumericUpDown)groupBox1.Controls.Find("numericUpDown" + (i), false)[0]).Value <= 0)
                    return false;
            return true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            if (msg.Msg == WM_KEYDOWN)
            {
                if (keyData == Keys.Escape)
                {
                    DialogResult = DialogResult.Cancel;
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;

namespace UserControls
{
    public partial class UCComparisonSiteDetailsParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "ComparisionType", "NumShown"};
        private string[] _DefaultValues = { "Days of Week", "0" };
        private string[] _DisplayValues = { "Days of Week", "0" };
        private string[] _ParamTypes = { "ComparisionType", "Number" };

        /// <summary>
        /// Constructor
        /// </summary>
        public UCComparisonSiteDetailsParameters()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Run time initialization of comparison report parameters.
        /// </summary>
        public void InitDefault()
        {
            // Initialize parameter hash table
            _ParamTable.Clear();
            for (int i = 0; i < _ParamNames.Length; i++)
            {
                _ParamTable.Add(_ParamNames[i], new ReportParameter(_ParamNames[i], _DefaultValues[i], _DisplayValues[i], _ParamTypes[i]));
            }
            // Initialize UI controls
            cbComparision.SelectedIndex = 0;
            // Initialize the specific parameter values in the hash table
        }

        /// <summary>
        /// Hash table accessors for setting/getting all the report parameters.
        /// Get initializes the report's local hashtable per the business rules for
        /// how the report behaves and returns it; set calls HashLoad,
        /// to load the report instance's parameter hash table from the supplied one.
        /// </summary>
        public Hashtable ParamList
        {
            get
            {
                SetValues();
                return _ParamTable;
            }
            set { this.HashLoad(value); }
        }

        /// <summary>
        /// Load the report instance's parameter hash table, and initialize the UI accordingly.
        /// </summary>
        /// <param name="paramlist">Hashtable to load from.</param>
        public void HashLoad(Hashtable paramlist)
        {
            for (int i = 0; i < _ParamNames.Length; i++)
            {
                ReportParameter param;
                if (paramlist.Contains(_ParamNames[i]))
                {
                    param = (ReportParameter)paramlist[_ParamNames[i]];
                    _ParamTable[_ParamNames[i]] = param;
                }
            }
            DisplayHashValues();
        }

        /// <summary>
        /// Set report parameter UI controls from current hash table values.
        /// </summary>
        private void DisplayHashValues()
        {
            cbComparision.SelectedIndex = int.Parse(((ReportParameter)_ParamTable["ComparisionType"]).ParamValue);
            numShown.Value = int.Parse(((ReportParameter)_ParamTable["NumShown"]).ParamValue.ToString());

        }

        /// <summary>
        /// Test validity of current settings, i.e. report is ready to view or save.
        /// </summary>
        /// <returns>True if current settings are valid.</returns>
        public bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// Get parameter values for this report by name.
        /// </summary>
        /// <param name="name">Name of parameter to get.</param>
        /// <returns>Parameter value.</returns>
        public string GetValue(string name)
        {
            switch (name)
            {
                case "ComparisionType":
                    return cbComparision.SelectedIndex.ToString();
                case "NumShown":
                    return numShown.Value.ToString();
                default:
                    return "";
            }
        }

        /// <summary>
        /// Add a ReportParameter to the report.
        /// </summary>
        /// <param name="param">ReportParameter to add.</param>
        public void AddItem(ReportParameter param)
        {
            _ParamTable.Add(param.Name, param);
        }

        /// <summary>
        /// Delete a ReportParameter from the report.
        /// </summary>
        /// <param name="name">Name of ReportParameter to delete.</param>
        public void DeleteItem(string name)
        {
            _ParamTable.Remove(name);
        }

        /// <summary>
        /// Get a ReportParameter from the report.
        /// </summary>
        /// <param name="name">Name of ReportParameter to get.</param>
        /// <returns>The specified ReportParameter.</returns>
        public ReportParameter GetItem(string name)
        {
            switch (name)
            {
                case "ComparisionType":
                    return new ReportParameter(name, cbComparision.SelectedIndex.ToString(), cbComparision.SelectedItem.ToString(), "ComparisionType");
               case "NumShown":
                    return new ReportParameter(name, numShown.Value.ToString(), numShown.Value.ToString(), "Number");
                default:
                    return null;
            }
        }

        private IDictionaryEnumerator _ParamTableEnum;

        /// <summary>
        /// Get the first ReportParameter from the report.
        /// </summary>
        /// <returns>The first ReportParameter.</returns>
        public ReportParameter GetFirst()
        {
            _ParamTableEnum = _ParamTable.GetEnumerator();
            return ((ReportParameter)_ParamTableEnum.Current);
        }

        /// <summary>
        /// Get the next ReportParameter from the report, and advance the current
        /// index.  Start with GetFirst() and then enumerate through all report
        /// parameters using GetNext().
        /// </summary>
        /// <returns>The next ReportParameter.</returns>
        public ReportParameter GetNext()
        {
            if (_ParamTableEnum == null)
                _ParamTableEnum = _ParamTable.GetEnumerator();
            else
                _ParamTableEnum.MoveNext();
            return ((ReportParameter)_ParamTableEnum.Current);
        }

        /// <summary>
        /// Get a string containing a CSV list of ReportParameter names for this report.
        /// </summary>
        /// <returns>Value list, CSV format.  Same order as values returned by
        /// GetValueList().</returns>
        public string GetNameList()
        {
            string res = "";
            SetValues();
            foreach (object obj in _ParamTable)
            {
                ReportParameter param = (ReportParameter)obj;
                if (res == "")
                    res = param.Name;
                else
                    res += ", " + param.Name;
            }
            return res;
        }

        /// <summary>
        /// Get a string containing a CSV list of ReportParameter values for this report.
        /// </summary>
        /// <returns>Value list, CSV format.  Same order as names returned by
        /// GetNameList().</returns>
        public string GetValueList()
        {
            string res = "";
            SetValues();
            foreach (object obj in _ParamTable)
            {
                ReportParameter param = (ReportParameter)obj;
                if (res == "")
                    res = param.ParamValue;
                else
                    res += ", " + param.ParamValue;
            }
            return res;
        }

        /// <summary>
        /// Get a string containing a CSV list of ReportParameter display values for this report.
        /// </summary>
        /// <returns>Display value list, CSV format.  Same order as names returned by
        /// GetNameList().</returns>
        public string GetDisplayValueList()
        {
            string res = "";
            SetValues();
            foreach (object obj in _ParamTable)
            {
                ReportParameter param = (ReportParameter)obj;
                if (res == "")
                    res = param.DisplayValue;
                else
                    res += ", " + param.DisplayValue;
            }
            return res;
        }

        private bool _Active;
        /// <summary>
        /// Return/set whether this report is Active.
        /// </summary>
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        /// ****************************************************
        /// Support Methods
        /// ****************************************************

        private void SetValues()
        {
            foreach (string name in _ParamNames)
            {
                ReportParameter param = GetItem(name);
                if (param != null)
                    _ParamTable[name] = param;
            }
        }





        public class ComparisionTypeChangedEventArgs : EventArgs
        {
            private string _ComparisionType;

            public string ComparisionType
            {
                get { return _ComparisionType; }
                set { _ComparisionType = value; }
            }

            public ComparisionTypeChangedEventArgs(string name)
            {
                _ComparisionType = Regex.Match(name, "^(\\w+)").Value;
            }

        }
        public delegate void ComparisionTypeChangedEventHandler(object sender, ComparisionTypeChangedEventArgs e);
        private ComparisionTypeChangedEventHandler comparisionTypeChanged;
        public event ComparisionTypeChangedEventHandler ComparisionTypeChanged
        {
            add { comparisionTypeChanged += value; }
            remove { comparisionTypeChanged -= value; }
        }
        public void SetComparisionTypeChanged()
        {
            OnComparisionTypeChanged(new ComparisionTypeChangedEventArgs(cbComparision.SelectedItem.ToString()));
        }
        protected virtual void OnComparisionTypeChanged(ComparisionTypeChangedEventArgs e)
        {
            if (comparisionTypeChanged != null)
                comparisionTypeChanged(this, e);
        }

        private void cbComparision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender != null)
                SetComparisionTypeChanged();
        }
        
    }
}

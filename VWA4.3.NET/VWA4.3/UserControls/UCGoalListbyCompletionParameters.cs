using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UserControls
{
	public partial class UCGoalListbyCompletionParameters : UserControl, IReportParameters
	{
		private Hashtable _ParamTable = new Hashtable();
		private string[] _ParamNames = { "ReportDate", "ReportMode"};
		private string[] _DefaultValues = { DateTime.Now.ToString(), "0"};
        private string[] _DisplayValues = { DateTime.Now.ToString(), "Percent Complete" };
		private string[] _ParamTypes = { "DateTime", "ReportMode"};

		private IDictionaryEnumerator _ParamTableEnum;

		/// <summary>
		/// Constructor
		/// </summary>
		public UCGoalListbyCompletionParameters()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Run time initialization of goal list report parameters.
		/// </summary>
		public void InitDefault()
		{
			_ParamTable.Clear();
			for (int i = 0; i < _ParamNames.Length; i++)
			{
				_ParamTable.Add(_ParamNames[i], new ReportParameter(_ParamNames[i], _DefaultValues[i], _DisplayValues[i], _ParamTypes[i]));
			}
			// Initialize UI controls
			cbReportMode.Items.Clear();
			cbReportMode.Items.Add("Percent Complete");
			cbReportMode.Items.Add("Days in Goal");
			cbReportMode.Items.Add("Percent Complete and Days in Goal");
			cbReportMode.SelectedIndex = 0;
		    dtReportDate.Value = DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek);
			// Initialize the specific parameter values in the hash table
		    ((ReportParameter) _ParamTable["ReportDate"]).ParamValue = VWA4Common.VWACommon.DateToString(dtReportDate.Value);
			((ReportParameter)_ParamTable["ReportDate"]).DisplayValue = ((ReportParameter)_ParamTable["ReportDate"]).ParamValue;
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
			dtReportDate.Value = DateTime.Parse(((ReportParameter)_ParamTable["ReportDate"]).ParamValue);
			cbReportMode.SelectedIndex = int.Parse(((ReportParameter)_ParamTable["ReportMode"]).ParamValue);
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
				case "ReportDate":
					return dtReportDate.Value.ToString("yyyy/MM/dd");
				case "ReportMode":
					return cbReportMode.SelectedIndex.ToString();
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
				case "ReportDate":
					return new ReportParameter(name, dtReportDate.Value.ToString("yyyy/MM/dd"), dtReportDate.Value.ToString("MM/dd/yyyy"), "DateTime");
				case "ReportMode":
					return new ReportParameter(name, cbReportMode.SelectedIndex.ToString(), cbReportMode.SelectedItem.ToString(), "String");
				default:
					return null;
			}
		}

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
	}
}

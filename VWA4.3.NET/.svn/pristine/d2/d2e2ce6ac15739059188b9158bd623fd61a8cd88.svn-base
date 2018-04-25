using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using VWA4Common.DAO;
using VWA4Common.DataObject;

namespace UserControls
{
    public partial class UCGoalHistoryParameters : UserControl, IReportParameters
    {
        private Hashtable _ParamTable = new Hashtable();
        private string[] _ParamNames = { "StartDate", "EndDate", "GoalId" };
        private string[] _DefaultValues = { DateTime.Now.ToString(), DateTime.Now.ToString(), "-1" };
        private string[] _DisplayValues = { DateTime.Now.ToString(), DateTime.Now.ToString(), "-1" };
        private string[] _ParamTypes = { "string", "string", "int" };

        private IDictionaryEnumerator _ParamTableEnum;

        public UCGoalHistoryParameters()
        {
            InitializeComponent();
            InitDefault();
        }

		private void UCGoalHistoryParameters_Load(object sender, EventArgs e)
		{
			if (VWA4Common.GlobalSettings.Initialized)
			{
				ddlGoals.DisplayMember = "GoalName";
				ddlGoals.ValueMember = "ID";
				ddlGoals.DataSource = GoalsDAO.DAO.GetAllGoals(VWA4Common.GlobalSettings.CurrentSiteID);
				if (ddlGoals.Items.Count > 0)
				{
					var g = ddlGoals.SelectedItem as Goal;
					lblGoalStartDate.Text = g.StartDate.ToShortDateString();
					lblGoalEndDate.Text = g.TargetDate.ToShortDateString();
				}
			}
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
            // Initialize the specific parameter values in the hash table
            ((ReportParameter) _ParamTable["GoalId"]).DisplayValue = "-1";
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
            var g = (ddlGoals.SelectedItem as Goal);
            switch (name)
            {
                case "GoalId":
                    return ddlGoals.SelectedValue.ToString();
                case "StartDate":
                    return g.StartDate.ToString();
                case "EndDate":
                    return g.TargetDate.ToString();
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
            var g = (ddlGoals.SelectedItem as Goal);
            switch (name)
            {
                case "GoalId":
                    return new ReportParameter(name, g.ID.ToString(), g.ID.ToString(), "int");
                case "StartDate":
                    //return new ReportParameter(name, dtStartDate.Value.ToString(), dtStartDate.Value.ToString(), "DateTime");
                    return new ReportParameter(name, g.StartDate.ToString(), g.StartDate.ToString(), "DateTime");
                case "EndDate":
                   // return new ReportParameter(name, dtEndDate.Value.ToString(), dtEndDate.Value.ToString(), "DateTime");
                    return new ReportParameter(name, g.TargetDate.ToString(), g.TargetDate.ToString(), "DateTime");
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

        private void ddlGoals_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var g = ddlGoals.SelectedItem as Goal;
                lblGoalStartDate.Text = g.StartDate.ToShortDateString();
                lblGoalEndDate.Text = g.TargetDate.ToShortDateString();
            }
            catch(Exception)
            {
                
            }
        }
    }
}

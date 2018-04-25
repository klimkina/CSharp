using System;
using System.Collections;
using System.Text;
using System.Data;

namespace UserControls
{
    public class ReportParameters
    {
        private Hashtable _Parameters = new Hashtable();
		
		public ReportParameter this[string name]
		{
			get
			{
				return (ReportParameter)_Parameters[name];
			}
			set
			{
				_Parameters[name] = new ReportParameter(value);
			}
		}
		
		public Hashtable ParamList
		{
			get { return _Parameters; }
			set { _Parameters = value; }
		}
  
		/// <summary>
		/// Load the hashtable with the parameters for the specified memorized report.
		/// </summary>
		/// <param name="repID"></param>
		public void LoadDB(int repID)
        {
            DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM ReportParam WHERE ReportMemorized = " + repID);
            foreach (DataRow row in dt.Rows)
            { 
                _Parameters.Add(row["ParamName"], new ReportParameter(row["ParamName"].ToString(), row["ParamValue"].ToString(), 
                    row["ParamDisplayValue"].ToString(), row["ParamValueType"].ToString()));
            }
        }

		/// <summary>
		/// Save the current hashtable input parameters in the DB under the specified report ID.
		///  Current parameter values are abandoned.
		/// </summary>
		/// <param name="id">Report ID to save under.</param>
        public void SaveDB(int id)
        {
            SaveDB(id, "Input");
        }
		/// <summary>
		/// Save the current hashtable input parameters in the DB under the specified report ID.
		///  Current parameter values are abandoned.
		/// </summary>
		/// <param name="id">Report ID to save under.</param>
		/// <param name="paramType">'Input' or 'Output'.</param>
		public void SaveDB(int id, string paramType)
        {
            if (VWA4Common.DB.Retrieve("SELECT * FROM ReportParam WHERE ReportMemorized = " + id).Rows.Count > 0)
                VWA4Common.DB.Delete("DELETE FROM ReportParam WHERE ReportMemorized = " + id); // delete previous params
            if (_Parameters["ReportID"] != null)
            {
                ((ReportParameter)_Parameters["ReportID"]).DisplayValue = id.ToString();
                ((ReportParameter)_Parameters["ReportID"]).ParamValue = id.ToString();
            }
            foreach (string key in _Parameters.Keys)
            {
                VWA4Common.DB.Insert("INSERT INTO ReportParam (ParamName, ParamValue, ParamDisplayValue, ParamType, ParamValueType, ReportMemorized) VALUES( '" +
                    ((ReportParameter)_Parameters[key]).Name + "', '" +
                    ((ReportParameter)_Parameters[key]).ParamValue.Replace("'", "''") + "', '" +
                    ((ReportParameter)_Parameters[key]).DisplayValue.Replace("'", "''") + "', '" +
                    paramType + "', '" +
                    ((ReportParameter)_Parameters[key]).ParamType.Replace("'", "''") + "', " +
                    id + ")");
            }

            VWA4Common.DB.Update("UPDATE ReportMemorized SET ModifiedDate = #" + VWA4Common.VWACommon.DateToString(DateTime.Now) + 
                " # WHERE ID = " + id); 
        }
        
		/// <summary>
		/// Add new parameters, from supplied hashtable.
		/// </summary>
		/// <param name="paramlist">Hashtable containing parameters to add.</param>
		public void AddParameters(Hashtable paramlist)
        {
            foreach (string key in paramlist.Keys)
            {
                if (!_Parameters.ContainsKey(key))
                    _Parameters.Add(key, new ReportParameter((ReportParameter)paramlist[key]));
                else
                    _Parameters[key] = new ReportParameter((ReportParameter)paramlist[key]);
            }
        }

		/// <summary>
		/// Add a single parameter to the _Parameters hashtable, from supplied values.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="display"></param>
		/// <param name="type"></param>
        public void AddParameter(string key, string value, string display, string type)
        {
            _Parameters.Add(key, new ReportParameter(key, value, display, type));
        }
        public void AddParameter(ReportParameter param)
        {
            _Parameters.Add(param.Name, new ReportParameter(param.Name, param.ParamValue, param.DisplayValue, param.ParamType));
        }
    }
}

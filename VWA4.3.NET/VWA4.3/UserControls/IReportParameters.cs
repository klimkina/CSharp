using System;
using System.Collections;
using System.Text;

namespace UserControls
{
    public interface IReportParameters
    {
        /// <summary>
        /// Initialize the parameter defaults (at run time).
        /// </summary>
		void InitDefault();
		/// <summary>
		/// Hash table accessors for setting/getting all the report parameters.
		/// Get initializes the report's local hashtable per the business rules for
		/// how the report behaves and returns it; set calls HashLoad,
		/// to load the report instance's parameter hash table from the supplied one.
		/// </summary>
		Hashtable ParamList
		{ set; get; }
		/// <summary>
		/// Load the report instance's parameter hash table, and initialize the UI accordingly.
		/// </summary>
		/// <param name="paramlist">Hashtable to load from.</param>
        void HashLoad(Hashtable paramlist);
        /// <summary>
        /// Test validity of current settings, i.e. report is ready to view or save.
        /// </summary>
        /// <returns>True if current settings are valid.</returns>
		bool    IsValid();
		/// <summary>
		/// Get parameter values for this report by name.
		/// </summary>
		/// <param name="name">Name of parameter to get.</param>
		/// <returns>Parameter value.</returns>
        string  GetValue(string name);
		/// <summary>
		/// Add a ReportParameter to the report.
		/// </summary>
		/// <param name="param">ReportParameter to add.</param>
        void    AddItem(ReportParameter param);
		/// <summary>
		/// Delete a ReportParameter from the report.
		/// </summary>
		/// <param name="name">Name of ReportParameter to delete.</param>
        void    DeleteItem(string name);
		/// <summary>
		/// Get a ReportParameter from the report.
		/// </summary>
		/// <param name="name">Name of ReportParameter to get.</param>
		/// <returns>The specified ReportParameter.</returns>
        ReportParameter GetItem(string name);
		/// <summary>
		/// Get the first ReportParameter from the report.
		/// </summary>
		/// <returns>The first ReportParameter.</returns>
		ReportParameter GetFirst();
		/// <summary>
		/// Get the next ReportParameter from the report, and advance the current
		/// index.  Start with GetFirst() and then enumerate through all report
		/// parameters using GetNext().
		/// </summary>
		/// <returns>The next ReportParameter.</returns>
		ReportParameter GetNext();
		/// <summary>
		/// Get a string containing a CSV list of ReportParameter names for this report.
		/// </summary>
		/// <returns>Value list, CSV format.  Same order as values returned by
		/// GetValueList().</returns>
		string GetNameList();
		/// <summary>
		/// Get a string containing a CSV list of ReportParameter values for this report.
		/// </summary>
		/// <returns>Value list, CSV format.  Same order as names returned by
		/// GetNameList().</returns>
		string GetValueList();
		/// <summary>
		/// Get a string containing a CSV list of ReportParameter display values for this report.
		/// </summary>
		/// <returns>Display value list, CSV format.  Same order as names returned by
		/// GetNameList().</returns>
		string GetDisplayValueList();
        /// <summary>
        /// Return/set whether this report is Active.
        /// </summary>
		bool Active
        { set; get; }
    }
}

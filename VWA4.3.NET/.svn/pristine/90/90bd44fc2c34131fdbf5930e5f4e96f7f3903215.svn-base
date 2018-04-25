using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Collections;


namespace UserControls
{
    public class ImportReports
    {
        public static bool ImportReportsFromDB(string fileName)
        {
            if (File.Exists(fileName))// Open the input file for input
            {
                System.Data.OleDb.OleDbConnection connImport = new System.Data.OleDb.OleDbConnection(VWA4Common.VWACommon.GetConnectionString(fileName));
                System.Data.OleDb.OleDbConnection connTransaction = new System.Data.OleDb.OleDbConnection(VWA4Common.AppContext.WasteConnectionString);
                connTransaction.Open();
                System.Data.OleDb.OleDbTransaction transaction = connTransaction.BeginTransaction();

                try
                {
                    Hashtable OldToNewReports = new Hashtable();
                    // import all reports
                    DataTable dtReports = VWA4Common.DB.Retrieve("SELECT * FROM ReportMemorized", connImport, null);
                    if (dtReports.Rows.Count > 0)
                        foreach (DataRow rowReport in dtReports.Rows)
                        {
                            string date_time = VWA4Common.VWACommon.DateToString(DateTime.Now);
                            string oldReportID = rowReport["ID"].ToString();
                            string title = rowReport["Title"].ToString();

                            if(VWA4Common.DB.Retrieve("SELECT * FROM ReportMemorized WHERE Title = '" + title + "'").Rows.Count > 0)
                                title = "Imported " + date_time + " " + title;
                            string newReportID = VWA4Common.DB.Insert("INSERT INTO ReportMemorized(Title, ReportType, ConfigXML, CreatedDate, ModifiedDate) " +
                                " VALUES('" + title + "','" + rowReport["ReportType"].ToString() + "','" + rowReport["ConfigXML"].ToString() + "', #" +
                                date_time + "#, #" + date_time + "#)", connTransaction, transaction).ToString();

                            OldToNewReports[oldReportID] = newReportID;
                            //System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();
                            //cmd.CommandText = "INSERT INTO ReportMemorized (ConfigXML, ReportType, Title, CreatedDate, ModifiedDate) " +
                            //        "VALUES(@ConfigXML, @ReportType, @Title, @CreatedDate, @ModifiedDate)";

                            //cmd.Parameters.Add("@ConfigXML", OleDbType.Binary);
                            //cmd.Parameters.Add("@ReportType", OleDbType.VarChar, 50, "ReportType");
                            //cmd.Parameters.Add("@Title", OleDbType.VarChar, 255, "Title");

                            //cmd.Parameters.Add("@CreatedDate", OleDbType.Date, 50, "CreatedDate");
                            //cmd.Parameters.Add("@ModifiedDate", OleDbType.Date, 50, "ModifiedDate");

                            //cmd.Parameters["@ConfigXML"].Value = System.Text.Encoding.UTF8.GetBytes(arr);
                            //cmd.Parameters["@ReportType"].Value = reportType;
                            //cmd.Parameters["@Title"].Value = name;

                            //cmd.Parameters["@CreatedDate"].Value = DateTime.Now;
                            //cmd.Parameters["@ModifiedDate"].Value = DateTime.Now;

                            //cmd.Connection = conn;
                            //if (cmd.ExecuteNonQuery() <= 0)
                            //    MessageBox.Show(null, "Error saving report - report was not saved", "Error saving report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //if (isNew)
                            //    cmd.CommandText = "SELECT @@Identity";
                            //else
                            //    cmd.CommandText = "SELECT ID FROM ReportMemorized WHERE ReportMemorized.Title = '" + name + "'";
                            //id = (int)cmd.ExecuteScalar();

                            // import all report parameters
                            DataTable dtReportParameters = VWA4Common.DB.Retrieve("SELECT * FROM ReportParam WHERE ReportMemorized = " + oldReportID, connImport, null);
                            if (dtReportParameters.Rows.Count > 0)
                                foreach (DataRow rowReportParam in dtReportParameters.Rows)
                                {
                                    VWA4Common.DB.Insert("INSERT INTO ReportParam(ParamName, ParamValue, ParamDisplayValue, ParamType, " +
                                        "ParamValueType, AssignType, GlobalName, ReportMemorized) " +
                                        " VALUES('" + rowReportParam["ParamName"].ToString().Replace("'", "''") + "', '" +
                                        rowReportParam["ParamValue"].ToString().Replace("'", "''") + "', '" +
                                        rowReportParam["ParamDisplayValue"].ToString().Replace("'", "''") + "', '" +
                                        rowReportParam["ParamType"].ToString().Replace("'", "''") + "', '" +
                                        rowReportParam["ParamValueType"].ToString().Replace("'", "''") + "', '" +
                                        rowReportParam["AssignType"].ToString().Replace("'", "''") + "', '" +
                                        rowReportParam["GlobalName"].ToString().Replace("'", "''") + "', " +
                                        newReportID + ")",
                                        connTransaction, transaction).ToString();
                                }
                        }

                    // import all series
                    DataTable dtSeries = VWA4Common.DB.Retrieve("SELECT * FROM ReportSeries", connImport, null);
                    if(dtSeries.Rows.Count > 0)
                        foreach (DataRow rowSerie in dtSeries.Rows)
                        {
                            string date_time = VWA4Common.VWACommon.DateToString(DateTime.Now);
                            string oldSerieID = rowSerie["ID"].ToString();
                            // Mila todo: what to do with SiteID?
                            string newSerieID = VWA4Common.DB.Insert("INSERT INTO ReportSeries(SerieName, SiteID, CreatedDate, ModifiedDate) " +
                                " VALUES('" + rowSerie["SerieName"].ToString() + "', " + rowSerie["SiteID"].ToString() + ", #" + 
                                date_time + "#, #" + date_time + "#)", 
                                connTransaction, transaction).ToString();

                            // import all report sets
                            DataTable dtReportSets = VWA4Common.DB.Retrieve("SELECT * FROM ReportSet WHERE SerieID = " + oldSerieID, connImport, null);
                            if (dtReportSets.Rows.Count > 0)
                                foreach (DataRow rowReportSet in dtReportSets.Rows)
                                {
                                    string oldReportSetID = rowSerie["ID"].ToString();
                                    string newReportSetID = VWA4Common.DB.Insert("INSERT INTO ReportSet(ReportMemorized, [Order], Expression, SerieID) " +
                                        " VALUES(" + OldToNewReports[rowReportSet["ReportMemorized"].ToString()] + ", " +
                                        rowReportSet["Order"] + ", '" + rowReportSet["Expression"].ToString().Replace("'", "''") + "', " + rowReportSet["SerieID"] + ")",
                                        connTransaction, transaction).ToString();
                                    
                                }
                        }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured during importing Reports with message : " + ex.Message, "VWA Import Reports Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    transaction.Rollback();
                    
                }
                finally
                {
                    if (connTransaction != null && connTransaction.State != ConnectionState.Closed)
                        connTransaction.Close();

                    
                }
                
            }
            return false;
        }
    }
}

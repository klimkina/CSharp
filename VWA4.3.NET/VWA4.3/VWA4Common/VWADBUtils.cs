using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;


namespace VWA4Common
{
    public static class VWADBUtils
    {
        public static VWACommon.MyListBoxItem TypeCatalog(string termID)
        {
            VWACommon.MyListBoxItem res;
            DataTable catalogDataTable = new DataTable();

            string sql =
                @"SELECT TypeCatalogs.ID, TypeCatalogs.TypeCatalogName " +
                "FROM TypeCatalogs " +
                "WHERE TypeCatalogs.ID IN (SELECT Sites.TypeCatalogID " +
                "FROM Sites " +
                "WHERE Sites.ID IN (SELECT Terminals.SiteID " +
                "FROM Terminals " +
                "WHERE Terminals.TermID = '" + termID.Trim() + "'));";



            catalogDataTable = VWA4Common.DB.Retrieve(sql);
            

            if (catalogDataTable.Rows.Count > 0)
				res = new VWACommon.MyListBoxItem(catalogDataTable.Rows[0]["TypeCatalogName"].ToString(), catalogDataTable.Rows[0]["ID"].ToString());
            else
				res = new VWACommon.MyListBoxItem("Master", "0");

            return res;
        }
        public static DataTable MemorizedReports()
        {
            return MemorizedReports("");
        }
        public static DataTable MemorizedReports(string reportType)
        {
            string where = (reportType == "" ? "" : " WHERE ReportType = '" + reportType + "'");
            System.Data.OleDb.OleDbConnection conn = VWA4Common.DB.OpenConnection();
            DataTable reportsDataTable = new DataTable();
    
            try
            {
                System.Data.OleDb.OleDbDataAdapter da = new OleDbDataAdapter();

                da.SelectCommand = new System.Data.OleDb.OleDbCommand(
                    @"SELECT ID, Title, ReportType, ConfigXML, CreatedDate, ModifiedDate " +
                    "FROM ReportMemorized" + where, conn);
                da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[]
                        {
						    new System.Data.Common.DataTableMapping("Table", "ReportMemorized", 
						    new System.Data.Common.DataColumnMapping[]
						    {
							    new System.Data.Common.DataColumnMapping("ID", "ID"),
							    new System.Data.Common.DataColumnMapping("Title", "Title"),
                                new System.Data.Common.DataColumnMapping("ReportType", "ReportType"),
							    new System.Data.Common.DataColumnMapping("ConfigXML", "ConfigXML"),
                                new System.Data.Common.DataColumnMapping("CreatedDate", "CreatedDate"),
							    new System.Data.Common.DataColumnMapping("ModifiedDate", "ModifiedDate")
                            } 
                            )
                        }
                        );
                da.Fill(reportsDataTable);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in CreateWeightsAdapter: " + ex.Message, "Project Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                VWA4Common.DB.CloseConnection(conn);
            }
            if (reportsDataTable.Rows.Count > 0)
                return reportsDataTable;
            else
                return null;
        }

        public static int SaveXMLConfig(string name, string reportType, string arr, bool isNew)
        {
            int id = -1;
            System.Data.OleDb.OleDbConnection conn = VWA4Common.DB.OpenConnection();
                
            try
            {
                System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();

                if (isNew)
                    cmd.CommandText = "INSERT INTO ReportMemorized (ConfigXML, ReportType, Title, CreatedDate, ModifiedDate) " +
                        "VALUES(@ConfigXML, @ReportType, @Title, @CreatedDate, @ModifiedDate)";
                else
                    cmd.CommandText = "UPDATE ReportMemorized SET ReportMemorized.ConfigXML = @ConfigXML,  ReportMemorized.ReportType = @ReportType " +
                        "WHERE ReportMemorized.Title = @Title";
                cmd.Parameters.Add("@ConfigXML", OleDbType.Binary);
                cmd.Parameters.Add("@ReportType", OleDbType.VarChar, 50, "ReportType");
                cmd.Parameters.Add("@Title", OleDbType.VarChar, 255, "Title");

                cmd.Parameters.Add("@CreatedDate", OleDbType.Date, 50, "CreatedDate");
                cmd.Parameters.Add("@ModifiedDate", OleDbType.Date, 50, "ModifiedDate");

                cmd.Parameters["@ConfigXML"].Value = System.Text.Encoding.UTF8.GetBytes(arr);
                cmd.Parameters["@ReportType"].Value = reportType;
                cmd.Parameters["@Title"].Value = name;

                cmd.Parameters["@CreatedDate"].Value = DateTime.Now;
                cmd.Parameters["@ModifiedDate"].Value = DateTime.Now;

                cmd.Connection = conn;
                if (cmd.ExecuteNonQuery() <= 0)
                    MessageBox.Show(null, "Error saving report - report was not saved", "Error saving report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (isNew)
                    cmd.CommandText = "SELECT @@Identity";
                else
                    cmd.CommandText = "SELECT ID FROM ReportMemorized WHERE ReportMemorized.Title = '" + name + "'";
                id = (int)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in CreateWeightsAdapter: " + ex.Message, "Project Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                VWA4Common.DB.CloseConnection(conn);
            }
            return id;
        }
        public static void SaveXMLConfig(int id, string reportType, string arr)
        {
            System.Data.OleDb.OleDbConnection conn = VWA4Common.DB.OpenConnection();

            try
            {
                System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "UPDATE ReportMemorized SET ReportMemorized.ConfigXML = @ConfigXML,  ReportMemorized.ReportType = @ReportType, " +
                        " ReportMemorized.ModifiedDate = @ModifiedDate" +
                        " WHERE ReportMemorized.ID = @id";
                cmd.Parameters.Add("@ConfigXML", OleDbType.Binary);
                cmd.Parameters.Add("@ReportType", OleDbType.VarChar, 50, "ReportType");
                cmd.Parameters.Add("@ModifiedDate", OleDbType.Date, 50, "ModifiedDate");
                cmd.Parameters.Add("@id", OleDbType.Integer, 40, "ID");

                cmd.Parameters["@ConfigXML"].Value = System.Text.Encoding.UTF8.GetBytes(arr);
                cmd.Parameters["@ReportType"].Value = reportType;
                cmd.Parameters["@ModifiedDate"].Value = DateTime.Now;
                cmd.Parameters["@id"].Value = id;

                cmd.Connection = conn;
                if (cmd.ExecuteNonQuery() <= 0)
                    MessageBox.Show(null, "Error saving report - report was not saved", "Error saving report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in CreateWeightsAdapter: " + ex.Message, "Project Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                VWA4Common.DB.CloseConnection(conn);
            }
            
        }
        public static MemoryStream LoadXMLConfig(string name)
        {
            int i = 0;
            return LoadXMLConfig(name, ref i);
        }
        public static MemoryStream LoadXMLConfig(string name, ref int id)
        {
            try
            {
                DataTable catalogDataTable = new DataTable();

                string sql = @"SELECT ConfigXML, ID " +
                    "FROM ReportMemorized WHERE Title = '" + name + "';";
                
                catalogDataTable = VWA4Common.DB.Retrieve(sql);
                if (catalogDataTable.Rows.Count > 0)
                {
                    byte[] bt = System.Text.Encoding.Unicode.GetBytes(catalogDataTable.Rows[0]["ConfigXML"].ToString());
                    MemoryStream stream = new MemoryStream(bt, 0, bt.Length);
                    id = int.Parse(catalogDataTable.Rows[0]["ID"].ToString());
                    return stream;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in CreateWeightsAdapter: " + ex.Message, "Project Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        public static MemoryStream LoadXMLConfig(int id, ref string name)
        {
            try
            {
                DataTable catalogDataTable = new DataTable();

                string sql = @"SELECT ConfigXML, Title " +
                    "FROM ReportMemorized WHERE ID = " + id;

                catalogDataTable = VWA4Common.DB.Retrieve(sql);
                if (catalogDataTable.Rows.Count > 0)
                {
                    byte[] bt = System.Text.Encoding.Unicode.GetBytes(catalogDataTable.Rows[0]["ConfigXML"].ToString());
                    MemoryStream stream = new MemoryStream(bt, 0, bt.Length);
                    name = catalogDataTable.Rows[0]["Title"].ToString();
                    return stream;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in CreateWeightsAdapter: " + ex.Message, "Project Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
		}


        public static VWACommon.MyListBoxItem[] GetTypeCatalogs()
        {
            DataTable siteDataTable = new DataTable();

            string sql = @"SELECT ID, TypeCatalogName FROM TypeCatalogs;";
            siteDataTable = VWA4Common.DB.Retrieve(sql);

            VWACommon.MyListBoxItem[] res = new VWACommon.MyListBoxItem[siteDataTable.Rows.Count + 1];
            int i = 1;
            res[0] = new VWACommon.MyListBoxItem("Master", "0");
            foreach (DataRow row in siteDataTable.Rows)
            {
                res[i++] = new VWACommon.MyListBoxItem(row.ItemArray[0].ToString(), row.ItemArray[1].ToString());
            }
            
            return res;
        }

        public static VWACommon.MyListBoxItem[] GetSites()
        {
            DataTable siteDataTable = new DataTable();

            string sql = @"SELECT ID, LicensedSite FROM Sites WHERE Active = true;";
            siteDataTable = VWA4Common.DB.Retrieve(sql);

            VWACommon.MyListBoxItem[] res = new VWACommon.MyListBoxItem[siteDataTable.Rows.Count];
            int i = 0;
            foreach (DataRow row in siteDataTable.Rows)
            {
                res[i++] = new VWACommon.MyListBoxItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString());
            }
            
            return res;
        }
        public static string GetBEOID(string sBEONum, DateTime transferDate, int nTypeCatalog, ref string sError, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        {
            DataTable dt;
            if(nTypeCatalog == 0)
                dt = VWA4Common.DB.Retrieve("SELECT * FROM BEOType WHERE BEONumber = '" + sBEONum + "'", conn, trans);
            else
                dt = VWA4Common.DB.Retrieve("SELECT TypeID FROM BEOSubTypes " +
                                              " WHERE TypeCatalogID = " + nTypeCatalog +
                                              " AND Enabled = True " +
                                              " AND TypeID IN (SELECT TypeID FROM BEOType WHERE BEONumber = '" + sBEONum + "')", conn, trans);
            if (dt.Rows.Count == 0)
            {
                sError = (sError == "" ? "" : sError + "\n") + "EO with such EO number did not exist! EO was added automatically! \n";
                // todo: Mila Insert BEO and return generated ID
                return AutoCreateBEOID(sBEONum, transferDate, nTypeCatalog, ref sError, conn, trans);
            }
            else
            {
                if (dt.Rows.Count > 1)
                    sError = (sError == "" ? "" : sError + "\n") + "More than 1 EO with such EO number exists!";
                return dt.Rows[0].ItemArray[0].ToString();
            }
        }
        public static string AutoCreateBEOID(string sBEONum, DateTime transferDate, int nTypeCatalogID, ref string sError)
        {
            // Connect up to the database
            System.Data.OleDb.OleDbConnection conn = VWA4Common.DB.OpenConnection();
            string res = AutoCreateBEOID(sBEONum, transferDate, nTypeCatalogID, ref sError, conn, null);
            VWA4Common.DB.CloseConnection(conn);
            return res;
        }
        public static string AutoCreateBEOID(string sBEONum, DateTime transferDate, int nTypeCatalogID, ref string sError, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        {
            DataTable dt;
            string sBEOID = "";
            dt = VWA4Common.DB.Retrieve("SELECT TypeID FROM BEOSubTypes " +
                                            " WHERE TypeCatalogID = " + nTypeCatalogID +
                                            " AND Enabled = False " +
                                            " AND TypeID IN (SELECT TypeID FROM BEOType WHERE BEONumber = '" + sBEONum + "')", conn, trans);
            if (nTypeCatalogID != 0 && dt.Rows.Count > 0)// BEO ID Exists but disabled
            {
                sBEOID = dt.Rows[0][0].ToString();
                VWA4Common.DB.Update("UPDATE BEOSubTypes SET Enabled = True WHERE  TypeID = '" + sBEOID + "'", conn, trans);
                sError = (sError == "" ? "" : sError + "\n") + "EO Sub Type was Enabled for this EO Number\n";
                if (dt.Rows.Count > 1)
                    sError = (sError == "" ? "" : sError + "\n") + "More than 1 EO with such EO number exists!\n";
            }
            else 
            {
                dt = VWA4Common.DB.Retrieve("SELECT TypeID FROM BEOType " +
                                            " WHERE BEONumber = '" + sBEONum + "'", conn, trans);
                if (dt.Rows.Count > 0) // if BEONumber exists only for master, never happens in correct DB
                {
                    sBEOID = dt.Rows[0][0].ToString();
                    VWA4Common.DB.Insert("INSERT INTO BEOSubTypes (TypeCatalogID, TypeID, Enabled)" +
                    " VALUES (" + nTypeCatalogID + "'" + dt.Rows[0].ItemArray[0].ToString() + "', True)", conn, trans);
                    sError = (sError == "" ? "" : sError + "\n") + "This BEONumber existed only in master!";
                }
                else
                {
                    sBEOID = GetNextKey("BEOType", conn, trans);
                    int catID = VWA4Common.Utilities.GetQuickAddCategory("BEOCategory", "(Tracker Generated Event Orders)");
                    // create BEOID in master catalog
                    VWA4Common.DB.Insert("INSERT INTO BEOType (TypeID, TypeName, ReportTypeName, EventDate, CatID, BEONumber, ModifiedDate)" +
                        " VALUES ('" + sBEOID + "', 'AutoGenerated" + sBEONum + "', 'AutoGenerated" + sBEONum + "', #" + VWACommon.DateToString(transferDate) + "#, " +
                        catID + ", '" + 
                        sBEONum + "', #" + VWACommon.DateToString(DateTime.Now) + "#)", conn, trans);

                    dt = VWA4Common.DB.Retrieve("SELECT ID FROM TypeCatalogs;", conn, trans);
                    string[] arr = new string[dt.Rows.Count];

                    for(int i = 0; i < dt.Rows.Count; i++ )
                    {
                        string sEnabled = "False";
                        int currID = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                        if( currID == nTypeCatalogID)
                            sEnabled = "True";
                        // create BEOID in SubTypes
                        VWA4Common.DB.Insert("INSERT INTO BEOSubTypes (TypeCatalogID, TypeID, Enabled)" +
                                            " VALUES (" + currID + ", '" + sBEOID + "', " + sEnabled + ")", conn, trans);
                    }
                }
            }

            return sBEOID;
        }
        //Get the next key value for a specified table name (return as function value)
        public static string GetNextKey(string type, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        {
            string stNextKey = "";
            try
            {
                DataTable dt;
                dt = VWA4Common.DB.Retrieve("SELECT NextKeyValue FROM KeyTable WHERE TableName = '" + type + "'", conn, trans);
                
                // Handle the case where there is no existing record, i.e. no new auto-generated
                //  keys have been added yet for that table
                if(dt.Rows.Count == 0)
                { // no auto-generate keys yet for this type - initialize
                    switch(type)
                    {
                        case "FoodType" : 
                            stNextKey = "ZFT_900000001"; // 5th character must be non-zero numeric
                            break;
                        case "LossType" : 
                            stNextKey = "ZLT_900000001"; // 5th character must be non-zero numeric
                            break;
                        case  "ContainerType" :
                          stNextKey = "ZCT_900000001"; // 5th character must be non-zero numeric
                            break;
                        case  "UserType" :
                          stNextKey = "ZUS_900000001"; // 5th character must be non-zero numeric
                            break;
                        case  "StationType" :
                          stNextKey = "ZST_900000001"; // 5th character must be non-zero numeric
                            break;
                        case  "DispositionType" :
                          stNextKey = "ZDS_900000001"; // 5th character must be non-zero numeric
                            break;
                        case  "DaypartType" :
                            stNextKey = "ZDP_900000001"; // 5th character must be non-zero numeric
                            break;
                        case  "BEOType" :
                          stNextKey = "ZBE_900000001"; // 5th character must be non-zero numeric
                          break;
                        default:
                            stNextKey = type + "_900000001";
                            break;
                    }
                    VWA4Common.DB.Insert("INSERT INTO KeyTable (TableName, KeyFieldName, KeyFieldValue) VALUES ( '" + type + "', 'TypeID', '" + stNextKey + "'", conn, trans);
                }
                else
                { // Just use the next (properly structured) key and generate a new next one
                    stNextKey = dt.Rows[0].ItemArray[0].ToString();
                    int num = int.Parse(stNextKey.Substring(stNextKey.Length - 9, 9)) + 1;
                    stNextKey = stNextKey.Substring(0, stNextKey.Length - 9) + string.Format("{0:000000000}", num);
                    VWA4Common.DB.Update("UPDATE KeyTable SET NextKeyValue = '" + stNextKey + "' WHERE TableName = '" + type + "'", conn, trans);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error occured! Error raised, with message : " + ex.Message, "VWA Import File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            return stNextKey;
        }
        public static int GetProducedID(string sProducedLotNum, ref string sError, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        {
            DataTable dt;
            dt = VWA4Common.DB.Retrieve("SELECT ID FROM WeightsProduced WHERE LotNumber = '" + sProducedLotNum + "'", conn, trans);
            
            if (dt.Rows.Count == 0)
            {
                sError = (sError == "" ? "" : sError + "\n") + "Produced data with such lot number doesn't exist! \n";
                // todo: Mila Insert Produced data and return generated ID
                //return VWA4Common.DB.Insert("INSERT INTO WeightsProduced(LotNumber, [Timestamp]) " +
                //                            "VALUES('" + sProducedLotNum + "', #" + VWA4Common.VWACommon.DateToString(DateTime.Now) + "#)", 
                //                            conn, trans);
                return -1;
            }
            else
            {
                if (dt.Rows.Count > 1)
                    sError = (sError == "" ? "" : sError + "\n") + "More than 1 Produced data with such Lot number exists!";
                return int.Parse(dt.Rows[0][0].ToString());
            }
        }

        static private DateTime _MostRecents = new DateTime(0);

        static public DateTime MostRecents
        {
            get
            {
                if (_MostRecents == new DateTime(0))
                {
                    InitWeightDates();
                }
                return _MostRecents;
            }
            set 
            {
                _MostRecents = value;
            }
        }

        //static private DateTime _LeastRecents = new DateTime(0);

        //static private DateTime LeastRecents
        //{
        //    get
        //    {
        //        if (_LeastRecents == new DateTime(0))
        //        {
        //            InitWeightDates();
        //        }
        //        return _LeastRecents;
        //    }
        //}

        //static private DateTime _MaxDate = new DateTime(0);

        //static private DateTime MaxDate
        //{
        //    get
        //    {
        //        if (_MaxDate == new DateTime(0))
        //        {
        //            InitWeightDates();
        //        }
        //        return _MaxDate;
        //    }
        //}

        //static private DateTime _MinDate = new DateTime(0);

        //static private DateTime MinDate
        //{
        //    get
        //    {
        //        if (_MinDate == new DateTime(0))
        //        {
        //            InitWeightDates();
        //        }
        //        return _MinDate;
        //    }
        //}
        private const int _MinDatesDiff = 366;

        private static void InitWeightDates()
        {
            DataTable dtWeights = VWA4Common.DB.Retrieve("SELECT MAX(Weights.Timestamp) as  MostRecents, MIN(Weights.Timestamp) as  LeastRecents FROM Weights");
            DataTable dtDates = VWA4Common.DB.Retrieve("SELECT MAX(WeightDates.Timestamp) as MaxDate, MIN(WeightDates.Timestamp) as MinDate FROM WeightDates");
            if (dtWeights == null || dtWeights.Rows.Count <= 0 || dtDates == null || dtDates.Rows.Count <= 0 ||
                        dtDates.Rows[0]["MaxDate"].ToString() == "" ||
                        DateTime.Parse(dtDates.Rows[0]["MaxDate"].ToString()) < DateTime.Now ||
                        dtWeights.Rows[0]["MostRecents"].ToString() != "" &&
                        (DateTime.Parse(dtDates.Rows[0]["MaxDate"].ToString()) < DateTime.Parse(dtWeights.Rows[0]["MostRecents"].ToString()).AddDays(_MinDatesDiff) ||
                        DateTime.Parse(dtDates.Rows[0]["MinDate"].ToString()) > DateTime.Parse(dtWeights.Rows[0]["LeastRecents"].ToString()).AddDays(-_MinDatesDiff)))
            {
                DateTime curr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                DateTime date, firstdate = curr, lastdate = curr, mindate = curr, maxdate = curr;
                int diff = 0;

                if (dtWeights != null)
                {
                    if (dtWeights.Rows[0]["LeastRecents"].ToString() != "")
                        firstdate = DateTime.Parse(dtWeights.Rows[0]["LeastRecents"].ToString());
                    if (dtWeights.Rows[0]["MostRecents"].ToString() != "")
                        lastdate = DateTime.Parse(dtWeights.Rows[0]["MostRecents"].ToString());
                }
                
                if (dtDates != null)
                {
                    if (dtDates.Rows[0]["MinDate"].ToString() != "")
                        mindate = DateTime.Parse(dtDates.Rows[0]["MinDate"].ToString());
                    if (dtDates.Rows[0]["MaxDate"].ToString() != "")
                        maxdate = DateTime.Parse(dtDates.Rows[0]["MaxDate"].ToString());
                }
               
                //_MinDate = date;
                if (dtDates.Rows[0]["MinDate"].ToString() != "")
                {
                    diff = Math.Max(mindate.AddDays(_MinDatesDiff).Subtract(firstdate).Days, 0);
                    date = mindate.AddDays(-diff);
                    for (int i = 0; i < diff; i++)
                    {
                        VWA4Common.DB.Insert("INSERT INTO WeightDates([Timestamp]) VALUES (#" + VWACommon.DateToString(date) + "#)");
                        date = date.AddDays(1);
                    }
                }
                else
                {
                    date = firstdate.AddDays(-_MinDatesDiff);
                    while (date <= firstdate)
                    {
                        VWA4Common.DB.Insert("INSERT INTO WeightDates([Timestamp]) VALUES (#" + VWACommon.DateToString(date) + "#)");
                        date = date.AddDays(1);
                    }
                }
                
                if (dtDates.Rows[0]["MaxDate"].ToString() != "")
                    date = maxdate.AddDays(1);
                else
                    date = firstdate.AddDays(1);

                while (date < lastdate.AddDays(_MinDatesDiff))
                {
                    VWA4Common.DB.Insert("INSERT INTO WeightDates([Timestamp]) VALUES (#" + VWACommon.DateToString(date) + "#)");
                    date = date.AddDays(1);
                }

                _MostRecents = lastdate;
                //_LeastRecents = firstdate;
                //_MaxDate = date;
            }
            else
            {
                if(dtWeights.Rows[0]["MostRecents"].ToString() != "")
                    _MostRecents = DateTime.Parse(dtWeights.Rows[0]["MostRecents"].ToString());
                //_LeastRecents = DateTime.Parse(dt.Rows[0]["LeastRecents"].ToString());
                //_MaxDate = DateTime.Parse(dt.Rows[0]["MaxDate"].ToString());
                //_MinDate = DateTime.Parse(dt.Rows[0]["MinDate"].ToString());
            }
        }
        public static void CheckWeightDates()
        {
            DateTime date = MostRecents;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace VWA4Common
{
    /// <summary>
    /// Contains generic methods for handling database access at a fundamental level.
    /// Typically called by Query class.
    /// </summary>
    public static class DB
    {
		private const string ODC_CONNECTIONSTRING1 = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
		private const string ODC_CONNECTIONSTRING2 = @";User ID=Admin;";

        private static System.Data.OleDb.OleDbConnection _conn;
        private static System.Data.OleDb.OleDbConnection _tempconn;
        
		/// <summary>
        /// Opens the VWA4 database connection FOR THE CURRENTLY OPEN DATABASE
		/// and returns it.  If it's already open, returns immediately.
        /// </summary>
		/// <returns>Connection to database.</returns>
		public static System.Data.OleDb.OleDbConnection OpenConnection()
        {
            try
            {
                if (_conn == null)
                    _conn = new System.Data.OleDb.OleDbConnection(VWA4Common.AppContext.WasteConnectionString);
                else if (_conn.ConnectionString != VWA4Common.AppContext.WasteConnectionString)
                {
                    if (_conn.State != ConnectionState.Closed)
                        _conn.Close();
                    _conn.ConnectionString = VWA4Common.AppContext.WasteConnectionString;
                }
                //do a switch on the state of the connection
                switch (_conn.State)
                {
                    case ConnectionState.Open: //the connection is open
                        break;
                    case ConnectionState.Closed: //connection is open
                        //open the connection
                        _conn.Open();
                        break;
                    default:
                        _conn.Close();
                        _conn.Open();
                        break;
                }
            }
            catch { }
            return _conn;
        }

		/// <summary>
        /// Opens the VWA4 database connection FOR THE SPECIFIED PATH
		/// and returns it.  If it's already open, returns immediately.
        /// </summary>
		/// <param name="dbpath">Path of database to open connection to.</param>
		/// <returns>Connection to database.</returns>
        public static System.Data.OleDb.OleDbConnection OpenConnection(string dbpath)
        {
            string tempWasteConnectionString = ODC_CONNECTIONSTRING1 + dbpath + ODC_CONNECTIONSTRING2;
			try
            {
                if (_tempconn == null)
                    _tempconn = new System.Data.OleDb.OleDbConnection(tempWasteConnectionString);
                else if (_tempconn.ConnectionString != tempWasteConnectionString)
                {
                    if (_tempconn.State != ConnectionState.Closed)
                        _tempconn.Close();
                    _tempconn.ConnectionString = tempWasteConnectionString;
                }
                //do a switch on the state of the connection
                switch (_tempconn.State)
                {
                    case ConnectionState.Open: //the connection is open
                        break;
                    case ConnectionState.Closed: //connection is open
                        //open the connection
                        _tempconn.Open();
                        break;
                    default:
                        _tempconn.Close();
                        _tempconn.Open();
                        break;
                }
            }
            catch { }
            return _tempconn;
        }


        /// <summary>
        /// Closes the VWA4 database connection.
        /// </summary>
		/// <param name="conn">OleDbConnection to close.</param>
		public static void CloseConnection(System.Data.OleDb.OleDbConnection conn)
        {
            if (conn == null)
                return;
            // Close connection or remain it open for the next use
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        
		/// <summary>
        /// Generic method for Select commands that retreive a dataset from the currently
		/// open database.
        /// SQL is provided by caller, method returns the DataTable.
        /// Connection is opened and closed herein, based on the AppContext.
        /// </summary>
		/// <param name="sql">SQL query string to execute.</param>
		/// <returns>The DataTable containing the results of the query.</returns>
		public static DataTable Retrieve(string sql)
        {
            // Connect up to the database
            System.Data.OleDb.OleDbConnection conn = OpenConnection();
            DataTable dataTable = Retrieve(sql, conn, null);
            CloseConnection(conn);
            return dataTable;
        }

		/// <summary>
		/// Retrieve data from a SPECIFIED DATABASE file.
		/// </summary>
		/// <param name="dbpath">Path of database to retrieve data from.</param>
		/// <param name="sql">SQL query string to execute.</param>
		/// <returns>The DataTable containing the results of the query.</returns>
		public static DataTable Retrieve(string dbpath, string sql)
		{
			// Connect up to the database
			System.Data.OleDb.OleDbConnection conn = OpenConnection(dbpath);
			DataTable dataTable = Retrieve(sql, conn, null);
			CloseConnection(conn);
			return dataTable;
		}

		/// <summary>
		/// Retrieve data from database, based on the supplied OleDbConnection.
		/// </summary>
		/// <param name="sql">SQL query string to execute.</param>
		/// <param name="conn">OleDbConnection to desired database.</param>
		/// <param name="trans"></param>
		/// <returns></returns>
        public static DataTable Retrieve(string sql, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        {
            DataTable dataTable = new DataTable();

            try
            {
                // Connect up to the database
                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
                // Tee up the command
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql, conn);
                if (trans != null)
                    cmd.Transaction = trans;
                //
                // Issue the command
                //
                da.SelectCommand = cmd;
                da.Fill(dataTable);
            }
            catch (Exception ex)
            {
				MessageBox.Show(null, "VWA4.NET SELECT Exception: Error " + ex.Message + "!", "Select Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return dataTable;
        }
		/// <summary>
		/// Generic method for issuing simple Update commands to the current VWA4 database.
		/// </summary>
		/// <param name="sql"></param>
		public static bool Update(string sql)
		{
			// Connect up to the database
			System.Data.OleDb.OleDbConnection conn = OpenConnection();
			bool res = Update(sql, conn, null);
			CloseConnection(conn);
			return res;
		}
		
		/// <summary>
		/// Generic method for issuing simple Update commands to a SPECIFIED DATABASE file.
		/// </summary>
		/// <param name="dbpath">Path of database to retrieve data from.</param>
		/// <param name="sql"></param>
		public static bool Update(string dbpath, string sql)
		{
			// Connect up to the database
			System.Data.OleDb.OleDbConnection conn = OpenConnection(dbpath);
			bool res = Update(sql, conn, null);
			CloseConnection(conn);
			return res;
		}
		
		/// <summary>
		/// Generic method for issuing simple Update commands to the current VWA4 database,
		/// based on provided connection.
		/// </summary>
		/// <param name="sql">SQL query string to execute.</param>
		/// <param name="conn">OleDbConnection to desired database.</param>
		/// <param name="trans"></param>
		/// <returns>true if successful.</returns>
		public static bool Update(string sql, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        {
            // Connect up to the database
            int iSqlStatus;

            try
            {
                // Tee up the command
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql, conn);
                if (trans != null)
                    cmd.Transaction = trans;
                //
                // Issue the command
                //
                iSqlStatus = cmd.ExecuteNonQuery();
                //Now check the status
                if (iSqlStatus < 0)
                {
                    //DO your failed messaging here
                    MessageBox.Show(null, "VWA4.NET UPDATE ERROR: Query failed to update with status: " + iSqlStatus, "Update Error");
                }
            }
            catch (Exception ex)
            {
				MessageBox.Show(null, "VWA4.NET UPDATE Exception: Error " + ex.Message + "!", "Update Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return iSqlStatus == 0;
        }

		/// <summary>
		/// Perform Insert query on currently open database.
		/// </summary>
		/// <param name="sql">SQL query string to execute.</param>
		/// <returns>PK/ID of inserted record.</returns>
		public static int Insert(string sql)
		{
			int res = -1;
			// Connect up to the database
			System.Data.OleDb.OleDbConnection conn = OpenConnection();
			res = Insert(sql, conn, null);
			CloseConnection(conn);
			return res;
		}
		
		/// <summary>
		/// Perform Insert query on a SPECIFIED DATABASE file.
		/// </summary>
		/// <param name="dbpath">Path of database to insert data into.</param>
		/// <param name="sql">SQL query string to execute.</param>
		/// <returns>PK/ID of inserted record.</returns>
		public static int Insert(string dbpath, string sql)
		{
			int res = -1;
			// Connect up to the database
			System.Data.OleDb.OleDbConnection conn = OpenConnection(dbpath);
			res = Insert(sql, conn, null);
			CloseConnection(conn);
			return res;
		}

		/// <summary>
		/// Generic method for issuing simple Insert commands to the current VWA4 database,
		/// based on provided connection.
		/// </summary>
		/// <param name="sql">SQL query string to execute.</param>
		/// <param name="conn">OleDbConnection to desired database.</param>
		/// <param name="trans"></param>
		/// <returns>PK/ID of inserted record.</returns>
		public static int Insert(string sql, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        {
            // Connect up to the database
            int id = -1;

            try
            {
                // Tee up the command
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql, conn);
                //
                // Issue the command
                //
                if (trans != null)
                    cmd.Transaction = trans;
                int iSqlStatus = cmd.ExecuteNonQuery();
                //Now check the status
                if (iSqlStatus <= 0)
                {
                    //DO your failed messaging here
					MessageBox.Show(null, "VWA4.NET INSERT ERROR: Query Failed to insert with status: " + iSqlStatus, "Insert Error");
                }
                cmd.CommandText = "SELECT @@Identity";
                id = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
				MessageBox.Show(null, "VWA4.NET INSERT Exception: Error " + ex.Message + "!", "Insert Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return id;
        }

		/// <summary>
		/// Perform Delete query on currently open database.
		/// </summary>
		/// <param name="sql">SQL query string to execute.</param>
		/// <returns>true if successful.</returns>
		public static bool Delete(string sql)
        {
            return Update(sql);
        }

		/// <summary>
		/// Perform Delete query on currently open database.
		/// </summary>
		/// <param name="dbpath">Path of database to delete records from.</param>
		/// <param name="sql">SQL query string to execute.</param>
		/// <returns>true if successful.</returns>
		public static bool Delete(string dbpath, string sql)
		{
			return Update(dbpath, sql);
		}


		/// <summary>
		/// Generic method for issuing simple Delete commands to the current VWA4 database,
		/// based on provided connection.
		/// </summary>
		/// <param name="sql">SQL query string to execute.</param>
		/// <param name="conn">OleDbConnection to desired database.</param>
		/// <param name="trans"></param>
		/// <returns>true if successful.</returns>
		public static bool Delete(string sql, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        {
            return Update(sql, conn, trans);
        }

		/// <summary>
		/// Delete record from specified table in currently open database, based on PK/ID value.
		/// </summary>
		/// <param name="id">Value of PK/ID column to delete.</param>
		/// <param name="idName">Name of PK/ID column.</param>
		/// <param name="table">Table to delete from.</param>
		/// <returns>true if successful.</returns>
		public static bool Delete(string id, string idName, string table)
		{
			return Delete("", id, idName, table);
		}
		/// <summary>
		/// Delete record from specifiedtable, in specified database, based on PK/ID value.
		/// </summary>
		/// <param name="dbpath">Path of database to delete records from.</param>
		/// <param name="id">Value of PK/ID column to delete.</param>
		/// <param name="idName">Name of PK/ID column.</param>
		/// <param name="table">Table to delete from.</param>
		/// <returns>true if successful.</returns>
		public static bool Delete(string dbpath, string id, string idName, string table)
        {
			//Create the objects we need to insert a new record
			OleDbConnection cnDelete;
            if (dbpath == "") cnDelete = OpenConnection();
			else cnDelete = OpenConnection(dbpath);
            OleDbCommand cmdDelete = new OleDbCommand();
            string query = "DELETE FROM " + table + " WHERE " + idName + " = @id";
            int iSqlStatus;

            //Clear any parameters
            cmdDelete.Parameters.Clear();
            try
            {
                //Set the OleDbCommand Object Properties

                //Tell it what to execute
                cmdDelete.CommandText = query;
                //Tell it its a text query
                cmdDelete.CommandType = CommandType.Text;
                //Now add the parameters to our query
                //NOTE: Replace @value1.... with your parameter names in your query
                //and add all your parameters in this fashion
                cmdDelete.Parameters.AddWithValue("@id", id);
                //Set the connection of the object
                cmdDelete.Connection = cnDelete;
                iSqlStatus = cmdDelete.ExecuteNonQuery();

                //Now check the status
                if (iSqlStatus <= 0)
                    //DO your failed messaging here
					MessageBox.Show(null, "VWA4.NET DELETE ERROR: Query failed to delete with status: " + iSqlStatus, "Delete Error");
                    
            }
            catch (Exception ex) {
				MessageBox.Show(null, "VWA4.NET DELETE Exception: Error " + ex.Message, "Error");
                return false;
            }
            finally {
                //Now close the connection
                CloseConnection(cnDelete);
            }
            return iSqlStatus == 0;
        }

		/// <summary>
		/// Check for existence of table in currently open database.
		/// </summary>
		/// <param name="tablename">Table to check for.</param>
		/// <returns>true if table exists.</returns>
		public static bool TableExists(string tablename)
		{
			return TableExists("", tablename);
		}
		/// <summary>
		/// Check for existence of table in SPECIFIED database.
		/// </summary>
		/// <param name="tablename">Table to check for.</param>
		/// <returns>true if table exists.</returns>
		public static bool TableExists(string dbpath, string tablename)
		{
			// Connect up to the database
			OleDbConnection conn;
            if (dbpath == "") conn = OpenConnection();
			else conn = OpenConnection(dbpath);
			try
			{

				//the new object is the restrictions {TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME, TABLE_TYPE}
				//get all tables
				DataTable schema_tables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, tablename, "TABLE" });

				if (schema_tables.Rows.Count != 0) return true;
				return false;
			}
			finally
			{
				CloseConnection(conn);
			}

		}

		/// <summary>
		/// Check for existence of column in currently open database.
		/// </summary>
		/// <param name="tablename">Table name to check column exists in.</param>
		/// <param name="tablename">Column name to check for.</param>
		/// <returns>true if column exists in table.</returns>
		public static bool ColumnExists(string tablename, string columnname)
		{
			return ColumnExists("", tablename, columnname);
		}
		/// <summary>
		/// Check for existence of column in currently open database.
		/// </summary>
		/// <param name="tablename">Table name to check column exists in.</param>
		/// <param name="tablename">Column name to check for.</param>
		/// <returns>true if column exists in table.</returns>
		public static bool ColumnExists(string dbpath, string tablename, string columnname)
		{
			// Connect up to the database
			OleDbConnection conn;
			if (dbpath == "") conn = OpenConnection();
			else conn = OpenConnection(dbpath);
			try
			{

				//the new object is the restrictions {TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME, TABLE_TYPE}
				//get all columns for specific table
				DataTable schema_columns = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tablename, columnname });
				//get all tables
				//DataTable schema_tables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

				if (schema_columns.Rows.Count != 0) return true;
				return false;
			}
			finally
			{
				CloseConnection(conn);
			}

		}
		
		
		/// <summary>
		/// Get ID of record from SQL query, issued to currently open database.
		/// </summary>
		/// <param name="sql"></param>
		/// <returns>ID of selected record.</returns>
		public static Object GetId(string sql)
		{
			OleDbCommand cmd = new OleDbCommand(sql, OpenConnection());
			return (int)cmd.ExecuteScalar();
		}


	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VWA4Common
{
	public partial class UpdateDB : Form
	{
		public string DBPath = "";
		string dirtymsg = "";
		
		public UpdateDB()
		{
			InitializeComponent();
			if (BrowseAndSetDatabaseFile())
			{
				// Database file opened

				// We assume that the database is at least a beta v4 database, since in
				// this case it is already open.
				lDBVersion.Text = GetDBVersion(DBPath);
				lDBPath.Text = DBPath;
				ckDET.Checked = true;
				ckEachFormats.Checked = true;
				ckForms.Checked = true;
				ckBackup.Checked = true;
				this.Icon = VWA4Common.GlobalSettings.ProductIcon;
			}
			else
			{
				DialogResult = System.Windows.Forms.DialogResult.Cancel;
			}
		}
		
		public UpdateDB(string dbpath)
		{
			InitializeComponent();
			DBPath = dbpath;
			lDBPath.Text = dbpath;
			lDBVersion.Text = GetDBVersion(dbpath);
			// Make no assumptions about the database.
			if (lDBVersion.Text == "")
			{
				lDBVersion.Text = "Invalid Database - cannot upgrade!";
				lDBVersion.ForeColor = Color.Red;
				bUpgrade.Enabled = false;
			}
			else
			{
				lDBVersion.ForeColor = Color.Black;
				bUpgrade.Enabled = true;
			}
			ckDET.Checked = true;
			ckEachFormats.Checked = true;
			ckForms.Checked = true;
			ckBackup.Checked = true;
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}

		/// <summary>
		/// Check the version of a specified Database.
		/// </summary>
		/// <param name="path"></param>
		/// <returns>integer version #</returns>
		public string GetDBVersion(string dbpath)
		{
			DataTable dt;
			dt = VWA4Common.DB.Retrieve(dbpath, "SELECT VersionNum FROM DBVersion");
			if ((dt != null && dt.Rows.Count > 0))
			{
				return dt.Rows[0][0].ToString();
			}
			return "";
		}


		private void bDone_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}


		private void bOpenDB_Click(object sender, EventArgs e)
		{
			BrowseAndSetDatabaseFile();
			lDBVersion.Text = GetDBVersion(DBPath);

			if (lDBVersion.Text == "")
			{
				lDBVersion.Text = "Invalid Database - cannot upgrade!";
				lDBVersion.ForeColor = Color.Red;
				bUpgrade.Enabled = false;
			}
			else
			{
				lDBVersion.ForeColor = Color.Black;
				bUpgrade.Enabled = true;
			}
		}

		/// <summary>
		/// Present a file picker to open a specified database file.
		/// </summary>
		/// <returns></returns>
		private bool BrowseAndSetDatabaseFile()
		{
			VWA4Common.Errors.ErrorString.Clear();
			OpenFileDialog fd = new OpenFileDialog();
			fd.Title = "Select DataBase";
			fd.Filter = "Database (*.MDB)|*.mdb|" +
						"All files (*.*)|*.*";
			// InitialDirectory = current database directory
			if (VWA4Common.AppContext.DBPathName != "")
			{ // a database is open - use its path as initial
				fd.InitialDirectory = Path.GetDirectoryName(VWA4Common.AppContext.DBPathName);
			}
			else
			{ // no database is open - use the standard database directory
				fd.InitialDirectory = VWA4Common.GlobalSettings.DatabaseDir;
			}
			fd.Multiselect = false;
			if (fd.ShowDialog() == DialogResult.OK)
			{
				this.TopMost = true;
				// Set it in the Application context property
				DBPath = fd.FileName;
				this.TopMost = false;
				return true;
			}
			this.TopMost = false;
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bUpgrade_Click(object sender, EventArgs e)
		{
			if (ckBackup.Checked)
			{
				// Back the file up first
				File.Copy(DBPath, DBPath + ".bak",true);
			}
			// Upgrade to v402100
			string errstr = UpgradetoDBv402100(DBPath);
			if (errstr != "")
			{
				MessageBox.Show(errstr);
				lDBVersion.Text = "Invalid Database - cannot upgrade this file!";
				return;
			}
			errstr = UpgradetoDBv4211100(DBPath);
			if (errstr != "")
			{
				MessageBox.Show(errstr);
				lDBVersion.Text = "Invalid Database - cannot upgrade this file!";
				return;
			}
			// 
			lDBVersion.Text = GetDBVersion(DBPath);
			lDBVersion.ForeColor = Color.Green;
			if (dirtymsg =="")
				MessageBox.Show("Upgraded Successfully!", "Upgrade ValuWaste 4 Database");
			else
				MessageBox.Show("Upgraded everything successfully except:\n" + dirtymsg, "Upgrade ValuWaste 4 Database");
		}




		/// <summary>
		/// Upgrade a pre-Production Release database to v402100.
		/// </summary>
		/// <param name="dbpath"></param>
		/// <returns>Table name error encountered in ; else empty string</returns>
		public string UpgradetoDBv402100(string dbpath)
		{
			string sql;
			string currstatus = "ErrorWeights.Timestamp";
			///******************************************************************************** 
			///******************************************************************************** 
			try
			{
				///*****************************************************
				///Add StartTimestamp column
				///*****************************************************
				currstatus = "ErrorWeightsProduced.Timestamp";
				// 
				if (!VWA4Common.DB.ColumnExists(dbpath, "ErrorWeights", "StartTimestamp"))
				{
					sql = "ALTER TABLE ErrorWeights ADD StartTimestamp DATETIME";
					VWA4Common.DB.Update(dbpath, sql);
				}
				currstatus = "ErrorWeightsProduced.Timestamp";
				// 
				if (!VWA4Common.DB.ColumnExists(dbpath, "ErrorWeightsProduced", "StartTimestamp"))
				{
					sql = "ALTER TABLE ErrorWeightsProduced ADD StartTimestamp DATETIME";
					VWA4Common.DB.Update(dbpath, sql);
				}
				currstatus = "Weights.Timestamp";
				// 
				if (!VWA4Common.DB.ColumnExists(dbpath, "Weights", "StartTimestamp"))
				{
					sql = "ALTER TABLE Weights ADD StartTimestamp DATETIME";
					VWA4Common.DB.Update(dbpath, sql);
				}
				currstatus = "WeightsProduced.Timestamp";
				// 
				if (!VWA4Common.DB.ColumnExists(dbpath, "WeightsProduced", "StartTimestamp"))
				{
					sql = "ALTER TABLE WeightsProduced ADD StartTimestamp DATETIME";
					VWA4Common.DB.Update(dbpath, sql);
				}
				/// Add WasteClass column
				currstatus = "FoodType.WasteClass";
				// 
				if (!VWA4Common.DB.ColumnExists(dbpath, "FoodType", "WasteClass"))
				{
					sql = "ALTER TABLE FoodType ADD WasteClass TEXT(20)";
					VWA4Common.DB.Update(dbpath, sql);
					sql = "UPDATE FoodType SET WasteClass = 'generic_food'";
					VWA4Common.DB.Update(dbpath, sql);
				}
				///  TaskItems.Expanded and .Enabled
				currstatus = "TaskItems.Expanded";
				// Add and Init WasteClass column
				if (!VWA4Common.DB.ColumnExists(dbpath, "TaskItems", "Expanded"))
				{
					sql = "ALTER TABLE TaskItems ADD Expanded YESNO";
					VWA4Common.DB.Update(dbpath, sql);
					sql = "UPDATE TaskItems SET Expanded = TRUE";
					VWA4Common.DB.Update(dbpath, sql);
				}
				currstatus = "TaskItems.Enabled";
				// Add and Init WasteClass column
				if (!VWA4Common.DB.ColumnExists(dbpath, "TaskItems", "Enabled"))
				{
					sql = "ALTER TABLE TaskItems ADD Enabled YESNO";
					VWA4Common.DB.Update(dbpath, sql);
					sql = "UPDATE TaskItems SET Enabled = TRUE";
					VWA4Common.DB.Update(dbpath, sql);
				}

				/// Terminals.DefaultWasteClass
				currstatus = "Terminals.DefaultWasteClass";
				// Add and Init WasteClass column
				if (!VWA4Common.DB.ColumnExists(dbpath, "Terminals", "DefaultWasteClass"))
				{
					sql = "ALTER TABLE Terminals ADD DefaultWasteClass TEXT(20)";
					VWA4Common.DB.Update(dbpath, sql);
					sql = "UPDATE Terminals SET DefaultWasteClass='generic_food'";
					VWA4Common.DB.Update(dbpath, sql);
				}

				/// WasteProfiles
				currstatus = "WasteProfiles Table";
				// 
				if (!VWA4Common.DB.TableExists(dbpath, "WasteProfiles"))
				{
					sql = "CREATE TABLE WasteProfiles ("
						+ "ID COUNTER NOT NULL ,"
						+ "ProfileClass TEXT(50) ,"
						+ "ProfileName TEXT(50) ,"
						+ "CONSTRAINT PrimaryKey PRIMARY KEY (ID) "
						+ "); ";
					VWA4Common.DB.Update(dbpath, sql);
					sql = "INSERT INTO WasteProfiles (ProfileClass,ProfileName) "
						+ "VALUES("
						+ "'0',"
						+ "'Food'"
						+ ")";
					VWA4Common.DB.Update(dbpath, sql);
					sql = "INSERT INTO WasteProfiles (ProfileClass,ProfileName) "
						+ "VALUES("
						+ "'100000',"
						+ "'Non-Food'"
						+ ")";
					VWA4Common.DB.Update(dbpath, sql);
				}

				/// WasteClass
				currstatus = "WasteClass Table";
				// 
				if (!VWA4Common.DB.TableExists(dbpath, "WasteClass"))
				{
					sql = "CREATE TABLE WasteClass ("
						+ "ID COUNTER NOT NULL ,"
						+ "UniqueName TEXT(50) NOT NULL ,"
						+ "DisplayFullName TEXT(50) ,"
						+ "DisplayAbbreviatedName TEXT(50) ,"
						+ "PullDownName TEXT(50) NOT NULL ,"
						+ "Description TEXT(255) ,"
						+ "ClassXML MEMO ,"
						+ "WasteProfile TEXT(50) ,"
						+ "CONSTRAINT PrimaryKey PRIMARY KEY (ID) "
						+ "); ";
					VWA4Common.DB.Update(dbpath, sql);
					sql = "CREATE UNIQUE INDEX UnitsName ON WasteClass (UniqueName); ";
					VWA4Common.DB.Update(dbpath, sql);
					sql = "CREATE INDEX ID1 ON WasteClass (ID); ";
					VWA4Common.DB.Update(dbpath, sql);
					sql = "INSERT INTO WasteClass (UniqueName,DisplayFullName,DisplayAbbreviatedName,PullDownName,Description,WasteProfile)"
						+ "VALUES("
						+ "'generic_food',"
						+ "'Generic Food',"
						+ "'food',"
						+ "'Food Waste',"
						+ "'Standard class for undifferentiated food types.',"
						+ "'0'"
						+ ")";
					VWA4Common.DB.Update(dbpath, sql);
					sql = "INSERT INTO WasteClass (UniqueName,DisplayFullName,DisplayAbbreviatedName,PullDownName,Description,WasteProfile)"
						+ "VALUES("
						+ "'generic_nonfood',"
						+ "'Generic Non-Food',"
						+ "'non-food',"
						+ "'Non-Food Waste',"
						+ "'Standard class for undifferentiated non-food types.',"
						+ "'100000'"
						+ ")";
					VWA4Common.DB.Update(dbpath, sql);
				}
				///
				currstatus = "UnitsTime Table";
				if (VWA4Common.DB.TableExists(dbpath, "UnitsTime"))
				{ // Delete the table and rebuild with correct schema
					sql = "DROP TABLE UnitsTime;";
					VWA4Common.DB.Update(dbpath, sql);
				}	
				sql = "CREATE TABLE UnitsTime ("
					+ "ID COUNTER NOT NULL ,"
					+ "UniqueName TEXT(50) NOT NULL ,"
					+ "DisplayFullName TEXT(50) ,"
					+ "DisplayAdjective TEXT(50) ,"
					+ "DisplayAbbreviatedName TEXT(50) ,"
					+ "ConversionFactor DECIMAL(18,10)  NOT NULL ,"
					+ "Description TEXT(255) ,"
					+ "CONSTRAINT PrimaryKey PRIMARY KEY (ID) "
					+ "); ";
				VWA4Common.DB.Update(dbpath, sql);
				// Add content
				//******
				sql = "INSERT INTO UnitsTime(UniqueName,DisplayFullName"
					+ ",DisplayAdjective,DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Day','Day','Daily','day',1,'Standard Reference Time Unit');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsTime(UniqueName,DisplayFullName"
					+ ",DisplayAdjective,DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Year','Year','Yearly','yr',365,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsTime(UniqueName,DisplayFullName"
					+ ",DisplayAdjective,DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Quarter','Quarter','Quarterly','qtr',91,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsTime(UniqueName,DisplayFullName"
					+ ",DisplayAdjective,DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Month','Month','Monthly','mo',30,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsTime(UniqueName,DisplayFullName"
					+ ",DisplayAdjective,DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Week','Week','Weekly','wk',7,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsTime(UniqueName,DisplayFullName"
					+ ",DisplayAdjective,DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Hour','Hour','Hourly','hr',0.041666,'');";
				VWA4Common.DB.Update(dbpath, sql);
				
				///
				currstatus = "UnitsVolume Table";
				if (VWA4Common.DB.TableExists(dbpath, "UnitsVolume"))
				{ // Delete the table and rebuild with correct schema
					sql = "DROP TABLE UnitsVolume;";
					VWA4Common.DB.Update(dbpath, sql);
				}
				sql = "CREATE TABLE UnitsVolume ("
					+ "ID COUNTER NOT NULL ,"
					+ "UniqueName TEXT(50) NOT NULL ,"
					+ "DisplayFullName TEXT(50) ,"
					+ "DisplayAbbreviatedName TEXT(50) ,"
					+ "ConversionFactor DECIMAL(18,10)  NOT NULL ,"
					+ "Description TEXT(255) ,"
					+ "CONSTRAINT PrimaryKey PRIMARY KEY (ID) "
					+ "); ";
				VWA4Common.DB.Update(dbpath, sql);
				// Add content
				//******
				sql = "INSERT INTO UnitsVolume(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Cup','Cups','c',1,'Standard Reference Volume Unit');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsVolume(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Pint','Pints','pt',2,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsVolume(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Quart','Quarts','qt',4,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsVolume(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Gallon','Gallons','gal',16,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsVolume(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Tablespoon','Tablespoons','tbs',0.0625,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsVolume(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Teaspoon','Teaspoons','tsp',0.020833,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsVolume(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'FluidOz','Ounces','oz',0.125,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsVolume(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'HalfGallon','Half Gallons','1/2gal',8,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsVolume(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Num10Can','#10 Cans','#10 cans',12.5,'#10 Cans are approximate - 12-13 Cups per.');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsVolume(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'FiveGallon','5 Gallon Buckets','5gal',80,'');";
				VWA4Common.DB.Update(dbpath, sql);

				///
				currstatus = "UnitsWeight Table";
				if (VWA4Common.DB.TableExists(dbpath, "UnitsWeight"))
				{ // Delete the table and rebuild with correct schema
					sql = "DROP TABLE UnitsWeight;";
					VWA4Common.DB.Update(dbpath, sql);
				}
				sql = "CREATE TABLE UnitsWeight ("
					+ "ID COUNTER NOT NULL ,"
					+ "UniqueName TEXT(50) NOT NULL ,"
					+ "DisplayFullName TEXT(50) ,"
					+ "DisplayAbbreviatedName TEXT(50) ,"
					+ "ConversionFactor DECIMAL(18,10)  NOT NULL ,"
					+ "Description TEXT(255) ,"
					+ "CONSTRAINT PrimaryKey PRIMARY KEY (ID) "
					+ "); ";
				VWA4Common.DB.Update(dbpath, sql);
				// Add content
				//******
				sql = "INSERT INTO UnitsWeight(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Pound','Pounds','lb',1,'Standard Reference Weight Unit');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsWeight(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Kilogram','Kilograms','kg',2.20462262,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsWeight(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Ounce','Ounces','oz',0.0625,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsWeight(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Gram','Grams','g',0.00220462,'');";
				VWA4Common.DB.Update(dbpath, sql);
				//******
				sql = "INSERT INTO UnitsWeight(UniqueName,DisplayFullName"
					+ ",DisplayAbbreviatedName,ConversionFactor,Description) VALUES("
					+ "'Milligram','Milligrams','mg',0.00000204,'');";
				VWA4Common.DB.Update(dbpath, sql);

				///
				/// Report system upgrades
				/// 
				currstatus = "ReportMemorized";
				// Add and Init WasteClass column
				if (!VWA4Common.DB.ColumnExists(dbpath, "ReportMemorized", "CreatedDate"))
				{
					sql = "ALTER TABLE ReportMemorized ADD CreatedDate DATETIME";
					VWA4Common.DB.Update(dbpath, sql);
				}
				if (!VWA4Common.DB.ColumnExists(dbpath, "ReportMemorized", "ModifiedDate"))
				{
					sql = "ALTER TABLE ReportMemorized ADD ModifiedDate DATETIME";
					VWA4Common.DB.Update(dbpath, sql);
				}
				currstatus = "ReportSeries";
				// Add and Init WasteClass column
				if (!VWA4Common.DB.ColumnExists(dbpath, "ReportSeries", "CreatedDate"))
				{
					sql = "ALTER TABLE ReportSeries ADD CreatedDate DATETIME";
					VWA4Common.DB.Update(dbpath, sql);
				}
				if (!VWA4Common.DB.ColumnExists(dbpath, "ReportSeries", "ModifiedDate"))
				{
					sql = "ALTER TABLE ReportSeries ADD ModifiedDate DATETIME";
					VWA4Common.DB.Update(dbpath, sql);
				}
				/// Rename Old Database reports to new names
				/// 
				VWA4Common.DB.Update(dbpath, "UPDATE ReportSeries SET SerieName = 'Weekly Printed Reports' WHERE SerieName = 'Weekly Reports'");
				VWA4Common.DB.Update(dbpath, "UPDATE ReportSeries SET SerieName = 'Weekly Review Reports' WHERE SerieName = 'Weekly Review'");

				
				/// Mila
                /// Update old type of Rankings Report to Close-Up View
                /// 
				VWA4Common.DB.Update(dbpath, "UPDATE ReportMemorized SET ReportType = 'Close-Up View' WHERE ReportType = 'Rankings'");

				///
				/// Update the DBVersion
				/// 
				currstatus = "Updating DBVersion";
				sql = "UPDATE DBVersion SET VersionNum = '402100'";
				VWA4Common.DB.Update(dbpath, sql);
				//MessageBox.Show(null, VWA4Common.GlobalSettings.ProductName
				//    + " Database Successfully updated to v402100!", "Upgrade Database");

				
				///
				/// No problems?  Then you reach here and return blank/success.
				///
				return "";
			}
			catch (Exception ex)
			{
				return "ERROR DURING UPGRADE VWA4 DATABASE (402100 level) - TABLE: " + currstatus 
					+ "\nException: " + ex.ToString();
			}

		}

		/// <summary>
		/// Upgrade a pre-Production Release v402100 database to v4211100.
		/// </summary>
		/// <param name="path"></param>
		/// <returns>Table name error encountered in ; else empty string</returns>
		public string UpgradetoDBv4211100(string dbpath)
		{
			string sql = "";
			string currstatus = "";
			dirtymsg = "";
			///******************************************************************************** 
			///******************************************************************************** 
			try
			{
				if (ckDET.Checked)
				{
					///*****************************************************
					/// Add DataEntryTemplates Table
					///*****************************************************
					currstatus = "DataEntryTemplates creation";
					if (VWA4Common.DB.TableExists(dbpath, "DataEntryTemplates"))
					{ // Delete the table and rebuild with correct schema
						sql = "DROP TABLE DataEntryTemplates;";
						VWA4Common.DB.Update(dbpath, sql);
					}
					sql = "CREATE TABLE DataEntryTemplates ("
						+ "ID COUNTER NOT NULL ,"
						+ "DETName TEXT(255) NOT NULL ,"
						+ "DETDescription TEXT(255) ,"

						+ "FormSet_displayorder TEXT(255) ,"
						+ "FormSet_Backcolor LONG ,"

						+ "FormSet_Wastemode TEXT(255) ,"
						+ "FormSet_Wastemode_BackColor LONG ,"
						+ "FormSet_Wastemode_ForeColor LONG ,"

						+ "FormSet_UserType TEXT(255) ,"
						+ "FormSet_UserType_BackColor LONG ,"
						+ "FormSet_UserType_ForeColor LONG ,"

						+ "FormSet_FoodType TEXT(255) ,"
						+ "FormSet_FoodType_BackColor LONG ,"
						+ "FormSet_FoodType_ForeColor LONG ,"

						+ "FormSet_LossType TEXT(255) ,"
						+ "FormSet_LossType_BackColor LONG ,"
						+ "FormSet_LossType_ForeColor LONG ,"

						+ "FormSet_ContainerType TEXT(255) ,"
						+ "FormSet_ContainerType_BackColor LONG ,"
						+ "FormSet_ContainerType_ForeColor LONG ,"

						+ "FormSet_StationType TEXT(255) ,"
						+ "FormSet_StationType_BackColor LONG ,"
						+ "FormSet_StationType_ForeColor LONG ,"

						+ "FormSet_DispositionType TEXT(255) ,"
						+ "FormSet_DispositionType_BackColor LONG ,"
						+ "FormSet_DispositionType_ForeColor LONG ,"

						+ "FormSet_DaypartType TEXT(255) ,"
						+ "FormSet_DaypartType_BackColor LONG ,"
						+ "FormSet_DaypartType_ForeColor LONG ,"

						+ "FormSet_EventorderType TEXT(255) ,"
						+ "FormSet_EventorderType_BackColor LONG ,"
						+ "FormSet_EventorderType_ForeColor LONG ,"

						+ "Transaction_displayorder TEXT(255) ,"
						+ "Transaction_Backcolor LONG ,"

						+ "Quantity_CTDefaultMode TEXT(255) ,"
						+ "Quantity_BackColor LONG ,"
						+ "Quantity_ForeColor LONG ,"

						+ "UserNotes_TShow YESNO ,"
						+ "UserNotes_BackColor LONG ,"
						+ "UserNotes_ForeColor LONG ,"

						+ "Timestamp_NTPrefill TEXT(255) ,"
						+ "Timestamp_TFormat TEXT(255) ,"
						+ "Timestamp_Backcolor LONG ,"
						+ "Timestamp_Forecolor LONG ,"

						+ "Wastemode_CTDefaultMode TEXT(255) ,"
						+ "Wastemode_BackColor LONG ,"
						+ "Wastemode_ForeColor LONG ,"

						+ "User_CTDefaultMode TEXT(255) ,"
						+ "UserType_Backcolor LONG ,"
						+ "UserType_Forecolor LONG ,"

						+ "FoodType_CTDefaultMode TEXT(255) ,"
						+ "FoodType_Backcolor LONG ,"
						+ "FoodType_Forecolor LONG ,"

						+ "LossType_CTDefaultMode TEXT(255) ,"
						+ "LossType_Backcolor LONG ,"
						+ "LossType_Forecolor LONG ,"

						+ "ContainerType_CTDefaultMode TEXT(255) ,"
						+ "ContainerType_Backcolor LONG ,"
						+ "ContainerType_Forecolor LONG ,"

						+ "StationType_CTDefaultMode TEXT(255) ,"
						+ "StationType_Backcolor LONG ,"
						+ "StationType_Forecolor LONG ,"

						+ "DispositionType_CTDefaultMode TEXT(255) ,"
						+ "DispositionType_Backcolor LONG ,"
						+ "DispositionType_Forecolor LONG ,"

						+ "DaypartType_CTDefaultMode TEXT(255) ,"
						+ "DaypartType_Backcolor LONG ,"
						+ "DaypartType_Forecolor LONG ,"

						+ "EventOrderType_CTDefaultMode TEXT(255) ,"
						+ "EventOrderType_Backcolor LONG ,"
						+ "EventOrderType_Forecolor LONG ,"

						+ "CONSTRAINT PrimaryKey PRIMARY KEY (ID) "
						+ "); ";
					VWA4Common.DB.Update(dbpath, sql);
				}

				if (ckEachFormats.Checked)
				{
					///*****************************************************
					/// Add EachFormats Table
					///*****************************************************
					currstatus = "EachFormats creation";
					if (VWA4Common.DB.TableExists(dbpath, "EachFormats"))
					{ // Delete the table and rebuild with correct schema
						sql = "DROP TABLE EachFormats;";
						VWA4Common.DB.Update(dbpath, sql);
					}
					sql = "CREATE TABLE EachFormats ("
						+ "ID COUNTER NOT NULL ,"
						+ "EachFormatName TEXT(255) NOT NULL ,"
						+ "FoodTypeID TEXT(255) ,"
						+ "EachQuantity DECIMAL(18,6) ,"
						+ "WtMultiplier DECIMAL(18,6) ,"
						+ "UnitsWtID LONG ,"
						+ "SortOrder LONG ,"
						+ "Description TEXT(255) ,"
						+ "CONSTRAINT PrimaryKey PRIMARY KEY (ID) "
						+ "); ";
					VWA4Common.DB.Update(dbpath, sql);
				}
				if (ckForms.Checked)
				{
					///*****************************************************
					/// Add Form Table
					///*****************************************************
					currstatus = "Form creation";
					if (VWA4Common.DB.TableExists(dbpath, "Form"))
					{ // Delete the table and rebuild with correct schema
						sql = "DROP TABLE Form;";
						VWA4Common.DB.Update(dbpath, sql);
					}
					sql = "CREATE TABLE Form ("
						+ "ID COUNTER NOT NULL ,"
						+ "FormName TEXT(255) NOT NULL ,"
						+ "DataEntryTemplateId LONG ,"
						+ "SavePath TEXT(255) ,"
						+ "FileName TEXT(255) ,"
						+ "DocumentType TEXT(255) ,"
						+ "DocumentLength TEXT(255) ,"
						+ "DocumentData OLEOBJECT ,"
						+ "LastPrintDate TEXT(50) ,"
						+ "CreateDate DATETIME ,"
						+ "ModifiedDate DATETIME ,"
						+ "CONSTRAINT PrimaryKey PRIMARY KEY (ID) "
						+ "); ";
					VWA4Common.DB.Update(dbpath, sql);

					///*****************************************************
					/// Add FormFormSeries Table
					///*****************************************************
					currstatus = "FormFormSeries creation";
					if (VWA4Common.DB.TableExists(dbpath, "FormFormSeries"))
					{ // Delete the table and rebuild with correct schema
						sql = "DROP TABLE FormFormSeries;";
						VWA4Common.DB.Update(dbpath, sql);
					}
					sql = "CREATE TABLE FormFormSeries ("
						+ "ID COUNTER NOT NULL ,"
						+ "FormID LONG ,"
						+ "FormSeriesId LONG ,"
						+ "Enabled YESNO ,"
						+ "NumberOfCopies LONG ,"
						+ "SortOrder LONG ,"
						+ "CONSTRAINT PrimaryKey PRIMARY KEY (ID) "
						+ "); ";
					VWA4Common.DB.Update(dbpath, sql);

					///*****************************************************
					/// Add FormSeries Table
					///*****************************************************
					currstatus = "FormSeries creation";
					if (VWA4Common.DB.TableExists(dbpath, "FormSeries"))
					{ // Delete the table and rebuild with correct schema
						sql = "DROP TABLE FormSeries;";
						VWA4Common.DB.Update(dbpath, sql);
					}
					sql = "CREATE TABLE FormSeries ("
						+ "ID COUNTER NOT NULL ,"
						+ "ReportSeriesName TEXT(255) ,"
						+ "CreateDate DATETIME ,"
						+ "ModifiedDate DATETIME ,"
						+ "CONSTRAINT PrimaryKey PRIMARY KEY (ID) "
						+ "); ";
					VWA4Common.DB.Update(dbpath, sql);
				}
				///*****************************************************
				/// Transfers Table Update
				///*****************************************************
				currstatus = "Transfers.DataFromDate";
				if (!VWA4Common.DB.ColumnExists(dbpath, "Transfers", "DataFromDate"))
				{
					sql = "ALTER TABLE Transfers ADD DataFromDate DATETIME";
					VWA4Common.DB.Update(dbpath, sql);
				}
				///
				currstatus = "Transfers.SessionEnd";
				if (!VWA4Common.DB.ColumnExists(dbpath, "Transfers", "SessionEnd"))
				{
					sql = "ALTER TABLE Transfers ADD SessionEnd DATETIME";
					VWA4Common.DB.Update(dbpath, sql);
				}
				///
				currstatus = "Transfers.ManualDESession";
				if (!VWA4Common.DB.ColumnExists(dbpath, "Transfers", "ManualDESession"))
				{
					sql = "ALTER TABLE Transfers ADD ManualDESession YESNO";
					VWA4Common.DB.Update(dbpath, sql);
				}
				///
				currstatus = "Transfers.SessionNotes";
				if (!VWA4Common.DB.ColumnExists(dbpath, "Transfers", "SessionNotes"))
				{
					sql = "ALTER TABLE Transfers ADD SessionNotes TEXT(255)";
					VWA4Common.DB.Update(dbpath, sql);
				}
				///
				currstatus = "Transfers.User";
				if (!VWA4Common.DB.ColumnExists(dbpath, "Transfers", "User"))
				{
					MessageBox.Show("Transfers.User column is missing - Cannot programmatically add this.\n"
						+ "Please add the Transfers.User column using Access, as a Text(255) format.\n"
						+ "LeanPath Customer Support can assist with this!", "Upgrade ValuWaste 4 Database");
					dirtymsg = "- Please add Transfers.User column manually using Access.";
				//    sql = "ALTER TABLE Transfers ADD Userx TEXT(255)";
				//    VWA4Common.DB.Update(dbpath, sql);
				}

				///*****************************************************
				/// Weights Table Update
				///*****************************************************
				///
				currstatus = "Weights.DETID";
				if (!VWA4Common.DB.ColumnExists(dbpath, "Weights", "DETID"))
				{
					sql = "ALTER TABLE Weights ADD DETID LONG";
					VWA4Common.DB.Update(dbpath, sql);
				}
				currstatus = "Weights.EachFormatID_DE";
				///
				if (!VWA4Common.DB.ColumnExists(dbpath, "Weights", "EachFormatID_DE"))
				{
					sql = "ALTER TABLE Weights ADD EachFormatID_DE LONG";
					VWA4Common.DB.Update(dbpath, sql);
				}
				///
				currstatus = "Weights.QuantityString_DE";
				if (!VWA4Common.DB.ColumnExists(dbpath, "Weights", "QuantityString_DE"))
				{
					sql = "ALTER TABLE Weights ADD QuantityString_DE TEXT(255)";
					VWA4Common.DB.Update(dbpath, sql);
				}
				///
				currstatus = "Weights.StartTimestamp";
				if (!VWA4Common.DB.ColumnExists(dbpath, "Weights", "StartTimestamp"))
				{
					sql = "ALTER TABLE Weights ADD StartTimestamp DATETIME";
					VWA4Common.DB.Update(dbpath, sql);
				}
				///
				currstatus = "Weights.SaveTimestamp";
				if (!VWA4Common.DB.ColumnExists(dbpath, "Weights", "SaveTimestamp"))
				{
					sql = "ALTER TABLE Weights ADD SaveTimestamp DATETIME";
					VWA4Common.DB.Update(dbpath, sql);
				}

				///*****************************************************
				/// WeightsProduced Table Update
				///*****************************************************
				///
				///
				currstatus = "WeightsProduced.StartTimestamp";
				if (!VWA4Common.DB.ColumnExists(dbpath, "WeightsProduced", "StartTimestamp"))
				{
					sql = "ALTER TABLE WeightsProduced ADD StartTimestamp DATETIME";
					VWA4Common.DB.Update(dbpath, sql);
				}

				///
				/// Update the DBVersion
				/// 
				currstatus = "Updating DBVersion";
				sql = "UPDATE DBVersion SET VersionNum = '4211100'";
				VWA4Common.DB.Update(dbpath, sql);

				///******************************************************************************** 
				///******************************************************************************** 
				/// Success
				/// 
				return "";
			}
			catch (Exception ex)
			{
				return "ERROR DURING UPGRADE VWA4 DATABASE (4211100 level) - TABLE: " + currstatus
					+ "\nException: " + ex.ToString();
			}
		}

	}
}

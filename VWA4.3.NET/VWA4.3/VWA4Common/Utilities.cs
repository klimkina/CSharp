using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace VWA4Common
{
	public static class Utilities
	{
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
		[DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetForegroundWindow(IntPtr hWnd);
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hwnd);
		[DllImport("user32.dll")]
		private static extern Int32 ReleaseDC(IntPtr hwnd);
		public struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}
		private static int printerleftmargin;
		private static int printerrightmargin;
		private static Bitmap memoryImage;
		public static void printUserControl(Form form, string docname, int leftindent, int topindent, int width, int height)
		{
			PageSetupDialog psetup = new PageSetupDialog();
			psetup.PageSettings = new PageSettings();
			psetup.PrinterSettings = new PrinterSettings();
			psetup.PageSettings.Landscape = true;
			psetup.PageSettings.Margins = new Margins(50,50,50,50);
			psetup.ShowNetwork = false;
			if (psetup.ShowDialog() == DialogResult.OK)
			{

				psetup.Dispose();
				form.TopMost = true;
				form.Update();
				PrintDocument pdoc = new PrintDocument();
				pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
				pdoc.DocumentName = docname;
				pdoc.PrinterSettings = psetup.PrinterSettings;
				PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
				RECT srcRect;
				//Process proc = new Process();
				//proc.StartInfo.FileName = "notepad.exe";
				//proc.Start();
				//proc.WaitForInputIdle();
				//if (SetForegroundWindow(proc.MainWindowHandle))
				IntPtr handle = form.FindForm().Handle;
				if (SetForegroundWindow(handle))
				{
					GetWindowRect(handle, out srcRect);
					//int width = srcRect.Right - srcRect.Left;
					//int height = srcRect.Bottom - srcRect.Top;

					memoryImage = new Bitmap(width, height);
					Graphics screenG = Graphics.FromImage(memoryImage);

					try
					{
						screenG.CopyFromScreen(srcRect.Left + leftindent, srcRect.Top + topindent,
								0, 0, new Size(width, height),
								CopyPixelOperation.SourceCopy);
						//bmp.Save("notepad.jpg", ImageFormat.Jpeg);
						pdoc.PrinterSettings.PrintRange = psetup.PrinterSettings.PrintRange;
						pdoc.PrinterSettings.PrinterName = psetup.PrinterSettings.PrinterName;
						pdoc.DefaultPageSettings.Landscape = psetup.PageSettings.Landscape;
						pdoc.DefaultPageSettings.Margins = psetup.PageSettings.Margins;
						pdoc.DefaultPageSettings.PaperSize = psetup.PageSettings.PaperSize;
						printerleftmargin = psetup.PageSettings.Margins.Left;
						printerrightmargin = psetup.PageSettings.Margins.Right;

						
						/// Starting to work on resizing print images
						//double PicRatio = width / height;
						//double printerWidth = pdoc.PrinterSettings.DefaultPageSettings.PrintableArea.Width;
						//double printerHeight = pdoc.PrinterSettings.DefaultPageSettings.PrintableArea.Height;
						//double printerRatio = printerWidth / printerHeight;


						printPreviewDialog1.Document = pdoc;
						//printPreviewDialog1.SetDesktopLocation(700, 200);
						printPreviewDialog1.Size = new Size(800, 600);
						form.TopMost = false;
						form.Update();
						printPreviewDialog1.ShowDialog();

						//pdoc.Print();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
					finally
					{
						screenG.Dispose();
					}
				}
			}

		}

		private static void pdoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			//Single xDpi, yDpi;
			//IntPtr dc = GetDC(IntPtr.Zero);

			//using (Graphics g = Graphics.FromHdc(dc))
			//{
			//    xDpi = g.DpiX;
			//    yDpi = g.DpiY;
			//}

			//if (ReleaseDC(IntPtr.Zero) != 0)
			//{
			//    // GetLastError and handle... 
			//}

			e.Graphics.DrawImage(memoryImage, printerleftmargin, printerrightmargin);
		}


		public static void launchDelphi(int module, bool issuper, string wasteclasslevel)
		{
            try
			{
				/// Write out global transient license file for Delphi
				string pathname = VWA4Common.GlobalSettings.VirtualAppDir + "\\vwa4ddparams.txt";
				VWA4Common.GlobalSettings.WriteGlobalstoNameValueFile(pathname);
				// Launch the process, wait for it to close
				{
					Process pr = new Process();
					pr.StartInfo.FileName = Application.StartupPath + "\\" + "VWA4DD.exe";
					string super = "0";
					if (issuper) super = "1";
					pr.StartInfo.Arguments = "\"" + VWA4Common.AppContext.DBPathName + "\" " 
						+ module.ToString() + " " + super + " "	+ wasteclasslevel 
						+ " \"" + VWA4Common.GlobalSettings.VirtualAppDir + "\"";
					//UserControls.SecurityManager.GetSecurityManager()["Waste Class Level"]; // todo: load from license
					//+ VWA4Common.GlobalSettings.WasteClassLevelofCurrentDB;
					pr.Start();
					pr.WaitForExit();
					pr.Close();
				}
				/// Delete the global transient license file
				if (File.Exists(pathname))
				{
					File.Delete(pathname);
				}

				VWA4Common.GlobalSettings.ForceGVReload();
				bool isSync = VWA4Common.GlobalSettings.TrackerConfigOutofSync;//call events auto
			}
            catch (Exception ex)
            {
                MessageBox.Show("Error in Launching Delphi: \n" + ex.Message);
            }
			//// Wait for configurator to exit
			//while (pr.HasExited == false)
			//{
			//    if ((DateTime.Now.Second % 5) == 0)
			//    {
			//        System.Threading.Thread.Sleep(1000);
			//    }

			//}
		}


		/// <summary>
		/// Generates a percentage, formatted with "places" decimal places.
		/// </summary>
		/// <param name="value">Value for which a percentage is needed</param>
		/// <param name="total">Total of all values from which to generate a percentage</param>
		/// <param name="places">How many decimal places to return in the percentage string</param>
		/// <returns>string with the percentage value</returns>
		public static string GetPercentage(int value, int total, int places)
		{
			Decimal percent = 0;
			string retval = string.Empty;
			String strplaces = new String('0', places);
			//if (value == null) value = 0;
			//if (total == null) total = 0;
			if (value == 0 || total == 0)
			{
				percent = 0;
			}
			else
			{
				percent = Decimal.Divide(value, total) * 100;
				if (places > 0)
				{
					strplaces = "." + strplaces;
				}
			}
			retval = percent.ToString("#" + strplaces);
			return retval;
		}

		/// <summary>
		/// Generate and return a new Type ID for use in a VWA4 type table.
		/// </summary>
		/// <param name="prefix">First 4 characters of type, e.g. "ZUS_".</param>
		/// <param name="tablename">Table name, e.g. "UserType"</param>
		/// <returns></returns>
		public static string GetNewTypeID(string prefix, string tablename)
		{
			// Get the next typeID by querying the entire type catalog for those types that
			//  have the correct prefix, sorting results by TypeID, adding one to the numeric part of
			//  he highest numbered TypeID.
			string sql = "SELECT TypeID, Mid(TypeID, 5) AS numpart FROM " + tablename
				+ " WHERE Mid(TypeID, 1, 4) = '" + prefix + "' "
				+ "ORDER BY TypeID DESC";
			DataTable dt_types = VWA4Common.DB.Retrieve(sql);
			if (dt_types.Rows.Count > 0)
			{
				// We have existing v4 format Type IDs so generate a new one
				DataRow thisRow = dt_types.Rows[0];
				int newnumpart = int.Parse(thisRow["numpart"].ToString()) + 1;
				return prefix + newnumpart.ToString();
			}
			else
			{
				// No rows - initialize
				return prefix + "900000001";
			}

		}

		/// <summary>
		/// Check the supplied table for a conflict
		/// </summary>
		/// <param name="typename">TypeName to check.</param>
		/// <param name="tablename">Type table to check, e.g. "UserType"</param>
		/// <param name="catid">CatID of parent category to check. 0 means check all Types regardless of parentage.</param>
		/// <returns>True - conflict; false - no conflict.</returns>
		public static bool CheckTypeNameUnique(string typename, string tablename, int catid)
		{
			string sql = "SELECT * FROM " + tablename + " WHERE ";
			if (catid != 0)
			{
				sql += "(CatID=" + catid.ToString() + ") AND ";
			}
			sql += "(TypeName='" + typename + "')";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt.Rows.Count > 0)
			{ // found a match - so it's not unique
				return false;
			}
			else
			{ // unique - no match found
				return true;
			}
		}

		/// <summary>
		/// Get the CatID of the QuickAddCategory for the given tablename and CatName.  If it 
		/// isn't there, create it using the supplied name.
		/// </summary>
		/// <param name="cattablename">Category table to look in.</param>
		/// <param name="quickaddcatname">CatName of the desired Quick Add category.</param>
		/// <returns></returns>
		public static int GetQuickAddCategory(string cattablename, string quickaddcatname)
		{
			int rootcatid = 0;
			int quickaddcatid = 0;
			string sql = "SELECT * FROM " + cattablename + " WHERE ";
			sql += "(ParentCatID=0) AND (CatName='(root)')";
			DataTable dt = VWA4Common.DB.Retrieve(sql);
			if (dt.Rows.Count > 0)
			{ // found the root
				DataRow dr = dt.Rows[0];
				rootcatid = (int)dr["CatID"];
				sql = "SELECT * FROM " + cattablename + " WHERE ";
				sql += "(ParentCatID=" + rootcatid.ToString() + ") AND (CatName='"
						+ quickaddcatname + "')";
				dt = VWA4Common.DB.Retrieve(sql);
				if (dt.Rows.Count == 0)
				{ // category doesn't exist - need to create
					sql = "INSERT INTO " + cattablename + "(ParentCatID,CatName,Description)"
						+ " VALUES(" + rootcatid.ToString() + ",'" + quickaddcatname + "','"
						+ "Quick-added " + DateTime.Now.ToString("M/d/yy HH:mm:ss tt") + "')";
					quickaddcatid = VWA4Common.DB.Insert(sql);
				}
				else
				{
					dr = dt.Rows[0];
					quickaddcatid = (int)dr["CatID"];
				}
			}
				return quickaddcatid;
		}

		public static int GetIndexfromDayName(string dayname)
		{
			switch (dayname.ToLower())
			{
				case "sunday":
					{
						return 0;
					}
				case "monday":
					{
						return 1;
					}
				case "tuesday":
					{
						return 2;
					}
				case "wednesday":
					{
						return 3;
					}
				case "thursday":
					{
						return 4;
					}
				case "friday":
					{
						return 5;
					}
				case "saturday":
					{
						return 6;
					}
				default:
					{
						return -1;
					}
			}

			}


		/// <summary>
		/// Saves a  (binary or text) to the database "Files" table, using standard approach.  Filename
		/// and CurrentSiteID combination must be unique (PK), so check to make sure ahead of time
		/// whether an UPDATE or INSERT is appropriate (see isNEW parameter).
		/// </summary>
		/// <param name="filename">Filename, with extension, to save data under.</param>
		/// <param name="fileType">File type - e.g. "Image".</param>
		/// <param name="bt">Byte array with file data to store.</param>
		/// <param name="isNew">True - does an INSERT; False - does an UPDATE.</param>
		/// <param name="siteID">Associated SiteID to store for the file.</param>
		/// 
		/// <returns></returns>
		public static int SaveFiletoDB(string filename, string fileType, byte[] bt, bool isNew, int siteID)
		{
			int id = -1;
			System.Data.OleDb.OleDbConnection conn = VWA4Common.DB.OpenConnection();

			try
			{
				System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();

				if (isNew)
					cmd.CommandText = "INSERT INTO Files (FileData, FileType, Filename, SiteID) VALUES(@FileData, @FileType, @Filename, @SiteID)";
				else
					cmd.CommandText = "UPDATE Files SET Files.FileData = @FileData,  Files.FileType = @FileType "
					+ "WHERE (Files.Filename = @Filename) AND (Files.SiteID = @SiteID)";
				cmd.Parameters.Add("@FileData", OleDbType.Binary);
				cmd.Parameters.Add("@FileType", OleDbType.VarChar, 50, "FileType");
				cmd.Parameters.Add("@Filename", OleDbType.VarChar, 255, "Filename");
				cmd.Parameters.Add("@SiteID", OleDbType.Integer);
				cmd.Parameters["@FileData"].Value = bt;
				cmd.Parameters["@FileType"].Value = fileType;
				cmd.Parameters["@Filename"].Value = filename;
				cmd.Parameters["@SiteID"].Value = siteID;

				cmd.Connection = conn;
				if (cmd.ExecuteNonQuery() <= 0)
					MessageBox.Show(null, "Error saving file to database - file was not saved", "Error saving report", MessageBoxButtons.OK, MessageBoxIcon.Error);
				if (isNew)
					cmd.CommandText = "SELECT @@Identity";
				else
					cmd.CommandText = "SELECT ID FROM Files WHERE (Files.Filename ='" + filename + "') AND (Files.SiteID = "
					+ siteID.ToString() + ")";
				id = (int)cmd.ExecuteScalar();

			}
			catch (Exception ex)
			{
				MessageBox.Show(null, "Error in saving file to database.: " + ex.Message, "File Save Error",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				VWA4Common.DB.CloseConnection(conn);
			}
			return id;
		}

		/// <summary>
		/// Load a file from the database, given the unique combination of filename and siteID.
		/// </summary>
		/// <param name="filename">Filename, with extension.</param>
		/// <param name="siteID">Associated SiteID for the file.</param>
		/// <param name="filedata">File data in MemoryStream format.</param>
		/// <returns>ID of the database record for the file - 0 if unsuccessful.</returns>
		public static int LoadFilefromDB(string filename, int siteID, out byte[] filedata)
		{
			int id = 0;
			filedata = null;
			OleDbDataReader rdr;
			OleDbConnection conn;
			DataTable FilesDataTable = new DataTable();
			string sql = @"SELECT FileData, ID " +
				"FROM Files WHERE (Filename = '" + filename + "') AND (SiteID = " + siteID.ToString() + ");";

			//FilesDataTable = VWA4Common.DB.Retrieve(sql);
			conn = VWA4Common.DB.OpenConnection();
			OleDbCommand cmd = new OleDbCommand(sql, conn);
			try
			{
				rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
				while (rdr.Read())
				{
					filedata = (byte[])rdr.GetValue(0);
					id = (int)rdr.GetValue(1);
				}
				//if (FilesDataTable.Rows.Count > 0)
				//{
				//    byte[] bt = System.Text.Encoding.Unicode.GetBytes(FilesDataTable.Rows[0]["FileData"].ToString());
				//    MemoryStream stream = new MemoryStream(bt, 0, bt.Length);
				//    filedata = stream;
				//    int id = int.Parse(FilesDataTable.Rows[0]["ID"].ToString());
				//    return id;
				//}
				//else
				//{
				//    filedata = null;
				//    return 0;
				//}
				rdr.Dispose();
				conn.Close();
				return id;
			}
			catch (Exception ex)
			{
				MessageBox.Show(null, "Error in loading file from database.: " + ex.Message, "File Load Error",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
				conn.Close();
				return id;
			}
		}
 
		//Open file in to a filestream and read data in a byte array.
		public static byte[] ReadFile(string sPath)
		{
			//Initialize byte array with a null value initially.
			byte[] data = null;

			//Use FileInfo object to get file size.
			FileInfo fInfo = new FileInfo(sPath);
			long numBytes = fInfo.Length;

			//Open FileStream to read file
			FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

			//Use BinaryReader to read file stream into byte array.
			BinaryReader br = new BinaryReader(fStream);

			//When you use BinaryReader, you need to supply number of bytes to read from file.
			//In this case we want to read entire file. So supplying total number of bytes.
			data = br.ReadBytes((int)numBytes);
			return data;
		}

		public static Point CenterControlonBackgroundControl(Control backgroundcontrol, Control controltocenter)
		{
			Point locationforcentering = new Point(0,0);
			locationforcentering.X = backgroundcontrol.Width / 2 - controltocenter.Width / 2;
			locationforcentering.Y = backgroundcontrol.Height / 2 - controltocenter.Height / 2;

			return locationforcentering;
		}
	}
}

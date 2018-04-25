using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace UserControls
{
    public class ImportData
    {
        protected const int DayLag              = -7;
        public const string TransferType        = "TransferWaste";  // Transfer type
        public const string WasteRecordType     = "WData4";         // Record type
        public const string ProducedRecordType  = "PData4";         // Record type
        protected const int CorrectVersion      = 4;                // current version of VWA and Tracker
        protected const decimal Precision       = 0.01M;            // Precision for Food Cost calculations

        protected string _sErrorMsg;
        /// 
		public string ErrorMsg
        { get { return _sErrorMsg; } }
        
		protected string _sWarningMsg;
        /// 
		public string WarningMsg
		{ get { return _sWarningMsg; } }

        public static string PriorToString(bool isPrior)
        { return isPrior ? "Prior" : "New"; }
        public static bool StringToPrior(string prior)
        { return prior.ToLower() != "new"; }

        public static string PreconsumerToString(int preconsumer)
        { 
            if(preconsumer == 0)
                return "Pre";
            if(preconsumer == 1)
                return "Post";
            return "Intermediate";
        }
        public static int StringToPeconsumer(string preconsumer)
        { 
            switch(preconsumer.ToLower())
            {
                case "pre": return 0;
                case "post": return 1;
                default: return 2;
            }
        }
        public static string RecordingMethodToString(int preconsumer)
        { 
            if(preconsumer == 0)
                return "Standard";
            if(preconsumer == 1)
                return "Memorized";
            return "By volume";
        }
        public static int StringToRecordingMethod(string preconsumer)
        { 
            switch(preconsumer.ToLower())
            {
                case "standard": return 0;
                case "memorized": return 1;
                default: return 2;
            }
        }
        public static string RemoveS(string s)
        {
            if (s.Trim().Substring(0, 1) == "$")
                return s.Trim().Substring(1, s.Length - 1);
            return s;
        }

        public bool IsCorrect()
        { 
            return (_sErrorMsg == null || _sErrorMsg == ""); 
        }
        public bool IsWarning ()
        { 
            return (_sWarningMsg == null || _sWarningMsg == ""); 
        }
        virtual public void AddError(string errorMsg)
        {
            _sErrorMsg += !VWA4Common.VWACommon.NotNullOrEmpty(_sErrorMsg) ? VWA4Common.VWACommon.DateToString(DateTime.Now) : Environment.NewLine + errorMsg; 
        }
        virtual public void AddWarning(string warningMsg)
        {
            _sWarningMsg += !VWA4Common.VWACommon.NotNullOrEmpty(_sWarningMsg) ? VWA4Common.VWACommon.DateToString(DateTime.Now) : Environment.NewLine + warningMsg; 
        }
        virtual public void CheckDate(DateTime dtDate)
        {
            if (dtDate > DateTime.Now.AddDays(VWA4Common.GlobalSettings.DaysinFuturetoAllowImporting))
              AddWarning("Timestamp input error! Future date! ");
            else if (dtDate < DateTime.Now.AddDays(DayLag))
                AddWarning("Timestamp input error! Date is too old ");
        }
        virtual public bool Check()
        { return false; }
        virtual public bool Check(System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        { return false; }
        virtual public bool Init(string str, ImportData transfer, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        { return false; }
        virtual public int DBSave(System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans, bool isNew)
        { return 0; }
        virtual public int DBSave(bool isNew)
        { return 0; }
        virtual public bool DBLoad(int id)
        {
            return false;
        }
    }
    public class ImportTransfer : ImportData
    { 
        private int         _nTransKey;
		/// 
		public int TransKey
        { get { return _nTransKey; } }
        
		private string      _sTermID;           // Serial number up to 10 chars
        /// 
	    public string TermID
        { get { return _sTermID; } }
        
		private string      _sTermName;
        /// 
        public string TermName
        { get { return _sTermName; } }

        private DateTime    _dtTransTimestamp;
        /// 
		public DateTime Timestamp
		{ get { return _dtTransTimestamp; } }
        
		private bool        _bIsPrior;
        /// 
        public bool IsPrior
        { get { return _bIsPrior; } }
        
		private string      _sVWTSWVersion;     // e.g. 4.1
        /// 
        public string Version
        { get { return _sVWTSWVersion; } }
        
		private int         _nSiteID;
        /// 
        public int SiteID
        { get { return _nSiteID; } }

        private int         _nTypeCatalogID;
        /// 
        public int TypeCatalogID
        { get { return _nTypeCatalogID; } }
       
		private bool _bIsManualDESession;
		/// 
		public bool IsManualDESession
		{ get { return _bIsManualDESession; } }

		private DateTime _dtDataFromDate;
		/// 
		public DateTime DataFromDate
		{ get { return _dtDataFromDate; }
			set { _dtDataFromDate = value; }
		}

		private DateTime _dtSessionEnd;
		/// 
		public DateTime SessionEnd
		{ get { return _dtSessionEnd; }
			set { _dtSessionEnd = value; }
		}

		private string _sUser;
		/// 
		public string User
		{ get { return _sUser; }
			set { _sUser = value; }
		}

		private string _sSessionNotes;
		/// 
		public string SessionNotes
		{
			get { return _sSessionNotes; }
			set { _sSessionNotes = value; }
		}


		//
		private string      _sSiteName;
		private string      _sTypeCatalogName;

        private int         _nRecNum;
		/// 
		public int RecordsNumber
        { 
            get { return _nRecNum; }
            set { _nRecNum = value; }
        }
      
		private int         _nIncorrectRecNum;
		/// 
		public int IncorrectRecordsNumber
        {
            get { return _nIncorrectRecNum; }
            set { _nIncorrectRecNum = value; }
        }
		


      
		/// <summary>
		/// 
		/// </summary>
		public ImportTransfer()	: this(-1)
		{
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transKey"></param>
		public ImportTransfer(int transKey)
        {
            _nTransKey = transKey;
            _sTermID = "";           // Serial number up to 10 chars
            _sTermName = "";
            _dtTransTimestamp = DateTime.Now;
            _bIsPrior = false;
            _sVWTSWVersion = "4.1";     // e.g. 4.1
            _nSiteID = 0;
            _sSiteName = "";
            _nTypeCatalogID = 0;
            _sTypeCatalogName = "Master";
            _nRecNum = 0;
            _nIncorrectRecNum = 0;
			_bIsManualDESession = false;
			_dtDataFromDate = DateTime.MinValue;
			_dtSessionEnd = DateTime.MinValue;
			_sUser = "";
			_sSessionNotes = "";
		}
		/// <summary>
		/// SAR 3/18/10
		/// </summary>
		/// <param name="transKey"></param>
		public ImportTransfer(int transKey, bool isManualDESession)
		{
			_nTransKey = transKey;
			_sTermID = "";           // Serial number up to 10 chars
			_sTermName = "";
			_dtTransTimestamp = DateTime.Now;
			_bIsPrior = false;
			_sVWTSWVersion = "4.1";     // e.g. 4.1
			_nSiteID = 0;
			_sSiteName = "";
			_nTypeCatalogID = 0;
			_sTypeCatalogName = "Master";
			_nRecNum = 0;
			_nIncorrectRecNum = 0;
			_bIsManualDESession = isManualDESession;
			_dtDataFromDate = DateTime.MinValue;
			_dtSessionEnd = DateTime.MinValue;
			_sUser = "";
			_sSessionNotes = "";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="trans"></param>
		public ImportTransfer(ImportTransfer trans)
        { 
            _sTermID = trans._sTermID;           // Serial number up to 10 chars
            _sTermName = trans._sTermName;
            _dtTransTimestamp = trans._dtTransTimestamp;
            _bIsPrior = trans._bIsPrior;
            _sVWTSWVersion = trans._sVWTSWVersion;     // e.g. 4.1
            _nSiteID = trans._nSiteID;
            _sSiteName = trans._sSiteName;
            _nTypeCatalogID = trans._nTypeCatalogID;
            _sTypeCatalogName = trans._sTypeCatalogName;
            _nTransKey = trans._nTransKey;
            _nRecNum = trans._nRecNum;
            _nIncorrectRecNum = trans._nIncorrectRecNum;
			_bIsManualDESession = trans._bIsManualDESession;
			_dtDataFromDate = trans._dtDataFromDate;
			_dtSessionEnd = trans._dtSessionEnd;
			_sUser = trans._sUser;
			_sSessionNotes = "";
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtTimestamp"></param>
        /// <param name="termID"></param>
        /// <param name="termName"></param>
        /// <param name="version"></param>
        /// <param name="siteID"></param>
        /// <param name="siteName"></param>
        /// <param name="typeCatalogID"></param>
        /// <param name="typeCatalogName"></param>
        /// <param name="isPrior"></param>
		public ImportTransfer(DateTime dtTimestamp, string termID, string termName, string version, int siteID, string siteName, int typeCatalogID, 
            string typeCatalogName, bool isPrior)
        {
            _sTermID = termID;           // Serial number up to 10 chars
            _sTermName = termName;
            _dtTransTimestamp = dtTimestamp;
            _bIsPrior = isPrior;
            _sVWTSWVersion = version;     // e.g. 4.1
            _nSiteID = siteID;
            _sSiteName = siteName;
            _nTypeCatalogID = typeCatalogID;
            _sTypeCatalogName = typeCatalogName;
            _nTransKey = -1;
            _nRecNum = 0;
            _nIncorrectRecNum = 0;
			_bIsManualDESession = false;
			_dtDataFromDate = DateTime.MinValue;
			_dtSessionEnd = DateTime.MinValue;
			_sUser = "";
			_sSessionNotes = "";
		}

		/// <summary>
		/// SAR 3/18/10
		/// </summary>
		/// <param name="timestamp"></param>
		/// <param name="dataFromDate"></param>
		/// <param name="sessionEnd"></param>
		/// <param name="termID"></param>
		/// <param name="termName"></param>
		/// <param name="version"></param>
		/// <param name="siteID"></param>
		/// <param name="siteName"></param>
		/// <param name="typeCatalogID"></param>
		/// <param name="typeCatalogName"></param>
		/// <param name="isPrior"></param>
		/// <param name="isManualDESession"></param>
		public ImportTransfer(DateTime timestamp, DateTime dataFromDate, DateTime sessionEnd,
			string termID, string termName, string version, int siteID, string siteName, int typeCatalogID,
			string typeCatalogName, bool isPrior, bool isManualDESession, string user)
		{
			_sTermID = termID;           // Serial number up to 10 chars
			_sTermName = termName;
			_dtTransTimestamp = timestamp;
			_bIsPrior = isPrior;
			_sVWTSWVersion = version;     // e.g. 4.1
			_nSiteID = siteID;
			_sSiteName = siteName;
			_nTypeCatalogID = typeCatalogID;
			_sTypeCatalogName = typeCatalogName;
			_nTransKey = -1;
			_nRecNum = 0;
			_nIncorrectRecNum = 0;
			_bIsManualDESession = true;
			_dtDataFromDate = dataFromDate;
			_dtSessionEnd = sessionEnd;
			_sUser = user;
			_sSessionNotes = "";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        override public string ToString()
        { 
            return TransferType + ',' +  _sTermID + ',' +  _sTermName + ',' +
                VWA4Common.VWACommon.DateToTrackerString(_dtTransTimestamp) + ',' +  PriorToString(_bIsPrior) + ',' +
                _sVWTSWVersion + ',' + _nSiteID + ',' +  _sSiteName  + ',' +
                _nTypeCatalogID + ',' +  _sTypeCatalogName;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <param name="conn"></param>
		/// <param name="trans"></param>
		/// <returns></returns>
        public bool Init(string str, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        { 
            return Init(str, null, conn, trans); 
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <param name="transfer"></param>
		/// <param name="conn"></param>
		/// <param name="trans"></param>
		/// <returns></returns>
        override public bool Init(string str, ImportData transfer, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        { 
            string[] fields = str.Split(',');
            int i = 0;
            int version = 0;
            _sErrorMsg = _sWarningMsg = "";
            try
            {
                if (fields[i++].Equals(TransferType))
                {
                    _sTermID = fields[i++];
                    _sTermName = fields[i++];
                    _dtTransTimestamp = DateTime.Parse(fields[i++]); // remember date
                    CheckDate(_dtTransTimestamp);
                    _bIsPrior = StringToPrior(fields[i++]);
                    if (!_bIsPrior && (fields[i-1].ToLower() != "new"))
                        AddWarning("Incorrect transfer type! Assuming new type ");
                    _sVWTSWVersion = fields[i++];
                    version = int.Parse(_sVWTSWVersion.Substring(0, 1));
                    if (version < CorrectVersion) // old version of the file
                        AddError("This is the old version of the file ");
                    else
                    {
                        _nSiteID = int.Parse(fields[i++]);
                        _sSiteName = fields[i++];
                        string temp = fields[i++]; //type catalog can be omitted
                        if (temp != "")
                            _nTypeCatalogID = int.Parse(temp);
                        else
                            _nTypeCatalogID = 0;

                        _sTypeCatalogName = fields[i++];
                        if (_sTypeCatalogName == "")
                            _sTypeCatalogName = "Master";
                    }
                }
            else
              AddError("Wrong record type ID! ");
            }
            catch(Exception ex)
            {
                AddError("Error in the header: " + ex.Message);
            }
            if (version >= CorrectVersion)
            {
                // Check Duplicates
                DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM Transfers WHERE TermID = '" + _sTermID + "'  AND Timestamp = #" + 
                    VWA4Common.VWACommon.DateToString(_dtTransTimestamp) + "#", conn, trans);

                if (dt.Rows.Count != 0)
                {
                    AddError("Duplicate found!");
                    return false;
                }
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
		public bool Init(DataRow row, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        {
            return Init(row, conn, trans, false);
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		/// <param name="conn"></param>
		/// <param name="trans"></param>
		/// <param name="isDB"></param>
		/// <returns></returns>
        public bool Init(DataRow row, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans, bool isDB)
        {
            int version = 0;
            _sErrorMsg = _sWarningMsg = "";
            try
            {     
                _sTermID = row["TermID"].ToString();
                _sTermName = row["TermName"].ToString();
                _dtTransTimestamp = DateTime.Parse(row["Timestamp"].ToString()); // remember date
                _bIsPrior = bool.Parse(row["IsPrior"].ToString());

                _sVWTSWVersion = row["TrackerSWVersion"].ToString();
                version = int.Parse(_sVWTSWVersion.Substring(0, 1));
                if (version < CorrectVersion) // old version of the file
                {
                    if (isDB)
                        AddWarning("This is the old version of the file.");
                    else
                        AddError("This is the old version of the file.");
                }
                if (version >= CorrectVersion || isDB)
                {
                    DataTable dt = VWA4Common.DB.Retrieve("SELECT Sites.ID, TypeCatalogs.ID FROM Terminals " +
                        " INNER JOIN (Sites LEFT JOIN TypeCatalogs ON Sites.TypeCatalogID = TypeCatalogs.ID) ON Terminals.SiteID = Sites.ID " +
                        " WHERE Terminals.TermID = '" + _sTermID + "' AND Terminals.Active = True;");
                    if (dt.Rows.Count > 0)
                    {
                        _nSiteID = int.Parse(dt.Rows[0]["Sites.ID"].ToString());
                        string temp = dt.Rows[0]["TypeCatalogs.ID"].ToString(); //type catalog can be omitted
                        if (temp != "")
                            _nTypeCatalogID = int.Parse(temp);
                        else
                            _nTypeCatalogID = 0;
                    }
                    else
                        AddError("No terminals with such ID exists.");
                }
            }
            catch (Exception ex)
            {
                AddError("Error in the header: " + ex.Message);
            }
            if (version >= CorrectVersion || isDB)
            {
                // Check Duplicates
                DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM Transfers WHERE TermID = '" + _sTermID + "'  AND Timestamp = #" +
                    VWA4Common.VWACommon.DateToString(_dtTransTimestamp) + "#", conn, trans);

                if (dt.Rows.Count != 0)
                {
                    AddError("Duplicate found!");
                    _nTransKey = int.Parse(dt.Rows[0]["TransKey"].ToString());
                    return false;
                }
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="isNew"></param>
        /// <returns></returns>
        override public int DBSave(System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans, bool isNew)
        {
            string sql = "";
            if (isNew)
            {
                sql = "INSERT INTO Transfers([Timestamp], TermID, TrackerSWVersion, SiteID, TypeCatalogID, IsPrior) " +
                    " VALUES(#" + VWA4Common.VWACommon.DateToString(_dtTransTimestamp) + "#, '" + _sTermID + "', '" + _sVWTSWVersion + "', " +
                    _nSiteID + ", " + _nTypeCatalogID + ", " + _bIsPrior + ")";
                this._nTransKey = VWA4Common.DB.Insert(sql, conn, trans);
            }
            else
            {
                sql = "UPDATE Transfers SET [Timestamp] = #" + VWA4Common.VWACommon.DateToString(_dtTransTimestamp) + "#, " +
                    " TermID = '" + _sTermID + "', TrackerSWVersion = '" + _sVWTSWVersion + "', " +
                    " SiteID = " + _nSiteID + ", TypeCatalogID = " + _nTypeCatalogID + ", IsPrior = " + _bIsPrior;
                VWA4Common.DB.Update(sql, conn, trans);
            }
            return this._nTransKey;
        }
        /// <summary>
        /// Save the new transfer/session record.
        /// </summary>
        /// <param name="isNew"></param>
        /// <returns></returns>
		override public int DBSave(bool isNew)
        {
            string sql = "";
            if(isNew)
            {
				sql = "INSERT INTO Transfers([Timestamp], TermID, TrackerSWVersion, SiteID, TypeCatalogID, IsPrior," + 
					" ManualDESession, DataFromDate, SessionEnd, [User], SessionNotes ) " +
                    " VALUES(#" + VWA4Common.VWACommon.DateToString(_dtTransTimestamp) + "#, '" + _sTermID + "', '" + _sVWTSWVersion + "', " +
                    _nSiteID + ", " + _nTypeCatalogID + ", " + _bIsPrior + ", " + _bIsManualDESession +
					", #" + VWA4Common.VWACommon.DateToString(_dtDataFromDate) + "#, #" + VWA4Common.VWACommon.DateToString(_dtSessionEnd) + "#, " +
					"'" + _sUser + "','" + _sSessionNotes + "')";
                this._nTransKey = VWA4Common.DB.Insert(sql);
            }
            else
            {
		//        sql = "UPDATE Transfers SET [Timestamp] = #" + VWA4Common.VWACommon.DateToString(_dtTransTimestamp) + "#, " +
		//" TermID = '" + _sTermID + "', TrackerSWVersion = '" + _sVWTSWVersion + "', " +
		//" SiteID = " + _nSiteID + ", TypeCatalogID = " + _nTypeCatalogID + ", IsPrior = " + _bIsPrior;

				sql = "UPDATE Transfers SET [Timestamp] = #"
					+ VWA4Common.VWACommon.DateToString(_dtTransTimestamp) + "#, "
					+ " TermID = '" + _sTermID + "', TrackerSWVersion = '" + _sVWTSWVersion + "', "
					+ " SiteID = " + _nSiteID + ", TypeCatalogID = " + _nTypeCatalogID + ", IsPrior = " + _bIsPrior
					+ ", ManualDESession = " + _bIsManualDESession
					+ ", DataFromDate = #" + VWA4Common.VWACommon.DateToString(_dtDataFromDate)
					+ "#, SessionEnd = #" + VWA4Common.VWACommon.DateToString(_dtSessionEnd)
					+ "#, [User] = '" + _sUser + "', SessionNotes = '" + _sSessionNotes + "'"
					+ " WHERE TransKey=" + _nTransKey.ToString();
				VWA4Common.DB.Update(sql);
            }
            return this._nTransKey;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		override public bool DBLoad(int id)
        {
            DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM Transfers " +
                                            " WHERE TransKey = " + id);

            if (dt.Rows.Count == 0)
                return false;
            else
            {
                _nTransKey = id;
                _dtTransTimestamp = DateTime.Parse(dt.Rows[0]["Timestamp"].ToString());
                _sTermID = dt.Rows[0]["TermID"].ToString();
                _sVWTSWVersion = dt.Rows[0]["TrackerSWVersion"].ToString();
                _nSiteID = int.Parse(dt.Rows[0]["SiteID"].ToString());
                _nTypeCatalogID = 
					(dt.Rows[0]["TypeCatalogID"].ToString() != "" ? int.Parse(dt.Rows[0]["TypeCatalogID"].ToString()) : 0);
                _bIsPrior = bool.Parse(dt.Rows[0]["IsPrior"].ToString());
				DateTime.TryParse(dt.Rows[0]["DataFromDate"].ToString(), out _dtDataFromDate);
				//_dtDataFromDate = DateTime.Parse(dt.Rows[0]["DataFromDate"].ToString());
				DateTime.TryParse(dt.Rows[0]["SessionEnd"].ToString(), out _dtSessionEnd);
				//_dtSessionEnd = DateTime.Parse(dt.Rows[0]["SessionEnd"].ToString());
				_sUser = dt.Rows[0]["User"].ToString();
				_sSessionNotes = dt.Rows[0]["SessionNotes"].ToString();
				return true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMsg"></param>
        override public void AddError(string errorMsg)
        { 
            if(!VWA4Common.VWACommon.NotNullOrEmpty(_sErrorMsg))
                _sErrorMsg = this._dtTransTimestamp == new DateTime(0) ? VWA4Common.VWACommon.DateToString(DateTime.Now) : VWA4Common.VWACommon.DateToTrackerString(_dtTransTimestamp) +
                    " Error in Transfer Record for terminal: " + this._sTermName + " " + this._sTermID; 
            base.AddError(errorMsg); 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="warningMsg"></param>
		override public void AddWarning(string warningMsg)
        {
            if (!VWA4Common.VWACommon.NotNullOrEmpty(_sWarningMsg))
                _sWarningMsg = this._dtTransTimestamp == new DateTime(0) ? VWA4Common.VWACommon.DateToString(DateTime.Now) : VWA4Common.VWACommon.DateToTrackerString(_dtTransTimestamp) +
                    " Warning in Transfer Record for terminal: " + this._sTermName + " " + this._sTermID;
            base.AddWarning(warningMsg);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		override public bool Check()
        {
            bool res = false;
            System.Data.OleDb.OleDbConnection conn = VWA4Common.DB.OpenConnection();
            res = Check(conn, null);
            VWA4Common.DB.CloseConnection(conn);
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
		override public bool Check(System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)// returns false in case of duplicates
        {
            return Check(conn, trans, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="isDB"></param>
        /// <returns></returns>
		public bool Check(System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans, bool isDB)// returns false in case of duplicates
        { 
            DataTable dt;

            // Check TermID and SiteID corresponds
            dt = VWA4Common.DB.Retrieve("Select * from Terminals where TermID = '" + _sTermID + "'  AND SiteID = " + _nSiteID + " AND Active = True;");
            if (dt.Rows.Count == 0)
                AddError("No such SiteID for this TermID");

            // Check TermID and TermName
            if (VWA4Common.VWACommon.NotNullOrEmpty(_sTermName))
            {
                dt = VWA4Common.DB.Retrieve("SELECT * FROM Terminals WHERE TermID = '" + _sTermID + "' AND TermName = '" + _sTermName + "' AND Active = True;");
                if (dt.Rows.Count == 0)
                {
                    if(!isDB)
                        AddError("No such TermID or TermName");
                    else
                        AddWarning("Terminal Names do not correspond in different DBs");
                }
            }

            // Check SiteID and SiteName
            if (VWA4Common.VWACommon.NotNullOrEmpty(_sSiteName))
            {
                dt = VWA4Common.DB.Retrieve("SELECT * FROM Sites WHERE ID = " + _nSiteID + " AND LicensedSite = '" + _sSiteName + "' AND Active = True;");

                if (dt.Rows.Count == 0)
                    AddError("No such SiteID or SiteName");
            }

            // Check CatalogID and CatalogName
            if (VWA4Common.VWACommon.NotNullOrEmpty(_sTypeCatalogName))
            {
                if (_nTypeCatalogID != 0)  // not master
                {
                    dt = VWA4Common.DB.Retrieve("SELECT * FROM TypeCatalogs where ID = " + _nTypeCatalogID + " AND TypeCatalogName = '" + _sTypeCatalogName + "'");
                    if (dt.Rows.Count == 0)
                        AddError("No such TypeCatalogID or TypeCatalogeName");
                }
                else if (_sTypeCatalogName != "" && !(_sTypeCatalogName == "Master" || _sTypeCatalogName == "(Master Type Catalog)"))
                    AddError("Name for the master catalog should be empty");
            }

            // Check CatalogID and SiteID, For  TypeCatalogID = 0 value can be Null
            dt = VWA4Common.DB.Retrieve("SELECT * FROM Sites WHERE ID = " + _nSiteID +
                    " AND  (TypeCatalogID = " + (_nTypeCatalogID == 0 ? " 0 OR TypeCatalogID IS NULL) " : _nTypeCatalogID + ")") +
                    " AND Active = True;");

            if (dt.Rows.Count == 0)
                AddError("No such TypeCatalogID for such SiteID");

            return !VWA4Common.VWACommon.NotNullOrEmpty(_sErrorMsg); 
        }
    }
	public class ImportWeight : ImportData
    {
        private int         _nID ;
        private DateTime    _dtWeightTimestamp; // Date and time of this weight measurement
        private int         _nPreConsumer;
        private decimal     _nWeight;           // Weight for this weight measurement
        private decimal     _nWasteCost;        // Total cost of the waste in this record.
        private string      _sFoodTypeName;
        private string      _sFoodTypeID;
        private decimal     _nFoodTypeCost;
        private decimal     _nFoodTypeDiscount;
        private string      _sLossTypeName;
        private string      _sLossTypeID;
        private string      _sContainerTypeName;
        private string      _sContainerTypeID ;
        private decimal     _nContainerWeight;  // Weight for this container
        private decimal     _nContainerCost;    // Total cost of the container in this record.
        private string      _sStationTypeName;
        private string      _sStationTypeID;
        private string      _sDispositionTypeName;
        private string      _sDispositionTypeID;
        private string      _sDayPartTypeName;
        private string      _sDayPartTypeID;
        private string      _sBEOTypeID;
        private string      _sBEONum;
        private string      _sUserTypeName;
        private string      _sUserTypeID;       // User name for this weight measurement
        private string      _sUserQuestion;     // Fully qualified name of the Button that the user selected in response to the User-Defined Question, in the form:	\Menu\submenu\...\name
        private int         _nNItems;           // Number of items in this record
        private int         _nRecordingMethod;  // 0 => Standard Waste Loop	1 => Memorized Transaction	2 => Entered by Volume
        private decimal     _nProducedAmount;   // This is the number that the user entered in the Produced Amount dialog, in the units specified  below.  
        private int         _nUnitWeight;       // Internal units of measure for the weights in this transaction. 1 = lb, 2 = kg (not implemented in VW4.2)
        private string      _sUnitDisplayName;  // Units of measure name
        private string      _sUnitUniqueName;   // Essentially the key of this unit type – maintained specifically to be invariant across versions and instances of the database     
        private string      _sProducedLotNum;   // ID used to associate production data record describing the origin of the food being wasted in this record. Can be blank.
        private int         _nProducedID;       // reference to original produced data
        private decimal     _nWasteAmountUserEntry; // This is the number that the user entered in the Volume or Paper UI (Memorized Transaction) Amount dialog, in the units specified  below
        private decimal     _nUnitaryItemWeight;    //Gross Weight in lbs that corresponds with 1.0 being typed by the user as the numeric entry.  VWA supplies unitary weight here as a conversion constant, by which the numeric entry is multiplied. Accuracy to 4 decimal points. Not Tare adjusted!

        private bool        _bIsManualInput;
        private bool        _IsProduced;
		/// <summary>
		/// Added by SAR 5/18/10 (WasteLogger)
		/// </summary>
		private int _DETID;
		private DateTime _StartTimestamp;
		private DateTime _SaveTimestamp;
		private string _QuantityString_DE;
		private int _EachFormatID_DE;
		
		private ImportTransfer _transfer;

        public string LotNumber
        {
            get { return _sProducedLotNum; }
            set { _sProducedLotNum = value; }
        }
        public bool IsProduced
        {
            get { return _IsProduced; }
        }

        public string ErrorMsg
        { get { return _sErrorMsg; } }
        public string WarningMsg
        { get { return _sWarningMsg; } }
        public DateTime Timestamp
        { get { return _dtWeightTimestamp; } }

        /// <summary>
        /// Initialize weight record;
        /// </summary>
		public ImportWeight()
        {
            _nID                = 0;
            _dtWeightTimestamp  = DateTime.Now; // Date and time of this weight measurement
            _nPreConsumer       = 0;
            _nWeight            = 0;        // Weight for this weight measurement
            _nWasteCost         = 0;        // Total cost of the waste in this record.
            _sFoodTypeName      = "";
            _sFoodTypeID        = "";
            _nFoodTypeCost      = 0;
            _nFoodTypeDiscount  = 1;
            _sLossTypeName      = "";
            _sLossTypeID        = "";
            _sContainerTypeName = "";
            _sContainerTypeID   = "";
            _nContainerWeight   = 0;        // Weight for this container
            _nContainerCost     = 0;        // Total cost of the container in this record.
            _sStationTypeName   = "";
            _sStationTypeID     = "";
            _sDispositionTypeName = "";
            _sDispositionTypeID = "";
            _sDayPartTypeName   = "";
            _sDayPartTypeID     = "";
            _sBEOTypeID         = "";
            _sBEONum            = "";
            _sUserTypeName      = "";
            _sUserTypeID        = "";       // User name for this weight measurement
            _sUserQuestion      = "";       // Fully qualified name of the Button that the user selected in response to the User-Defined Question, in the form:	\Menu\submenu\...\name
            _nNItems            = 1;        // Number of items in this record
            _nRecordingMethod   = 0;        // 0 => Standard Waste Loop, 1 => Memorized Transaction 	2 => Entered by Volume
            _nProducedAmount    = 0;
            _nUnitWeight        = 1;//always lbs
            _nProducedID        = -1;       // reference to original produced data
            _sProducedLotNum    = "";       // reference to original produced data
            _sUnitDisplayName   = "";       // Units of measure, lookup from table of UOM.
            _sUnitUniqueName    = "";
            _bIsManualInput     = false;
            _nProducedAmount    = 0;
            _nWasteAmountUserEntry = 0; // This is the number that the user entered in the Volume or Paper UI (Memorized Transaction) Amount dialog, in the units specified  below
            _nUnitaryItemWeight = 0;
            _transfer           = null;
			_DETID = 0;
			_SaveTimestamp = DateTime.MinValue;
			_QuantityString_DE = "";
			_EachFormatID_DE = 0;
		}

        public ImportWeight(ImportWeight weight)
        {
            _nID                = weight._nID;
            _dtWeightTimestamp  = weight._dtWeightTimestamp;    // Date and time of this weight measurement
            _nPreConsumer       = weight._nPreConsumer;
            _nWeight            = weight._nWeight;              // Weight for this weight measurement
            _nWasteCost         = weight._nWasteCost;           // Total cost of the waste in this record.
            _sFoodTypeName      = weight._sFoodTypeName;
            _sFoodTypeID        = weight._sFoodTypeID;
            _nFoodTypeDiscount  = weight._nFoodTypeDiscount;
            _sLossTypeName      = weight._sLossTypeName;
            _nFoodTypeCost      = weight._nFoodTypeCost;
            _sLossTypeID        = weight._sLossTypeID;
            _sContainerTypeName = weight._sContainerTypeName;
            _sContainerTypeID   = weight._sContainerTypeID;
            _nContainerWeight   = weight._nContainerWeight;     // Weight for this container
            _nContainerCost     = weight._nContainerCost;       // Total cost of the container in this record.
            _sStationTypeName   = weight._sStationTypeName;
            _sStationTypeID     = weight._sStationTypeID;
            _sDispositionTypeName = weight._sDispositionTypeName;
            _sDispositionTypeID = weight._sDispositionTypeID;
            _sDayPartTypeName   = weight._sDayPartTypeName;
            _sDayPartTypeID     = weight._sDayPartTypeID;
            _sBEOTypeID         = weight._sBEOTypeID;
            _sBEONum            = weight._sBEONum;
            _sUserTypeName      = weight._sUserTypeName;  
            _sUserTypeID        = weight._sUserTypeID;         // User name for this weight measurement
            _sUserQuestion      = weight._sUserQuestion;       // Fully qualified name of the Button that the user selected in response to the User-Defined Question, in the form:	\Menu\submenu\...\name
            _nNItems            = weight._nNItems;             // Number of items in this record
            _nRecordingMethod   = weight._nRecordingMethod;        // 0 => Standard Waste Loop, 1 => Memorized Transaction 	2 => Entered by Volume
            _nUnitWeight        = weight._nUnitWeight;
            _nProducedID        = weight._nProducedID;         // reference to original produced data
            _sProducedLotNum    = weight._sProducedLotNum;     // reference to original produced data
            _sUnitDisplayName   = weight._sUnitDisplayName;    // Units of measure, lookup from table of UOM.
            _sUnitUniqueName    = weight._sUnitUniqueName;
            _nProducedAmount    = weight._nProducedAmount;
            _bIsManualInput     = weight._bIsManualInput;
            _nWasteAmountUserEntry = weight._nWasteAmountUserEntry; // This is the number that the user entered in the Volume or Paper UI (Memorized Transaction) Amount dialog, in the units specified  below
            _nUnitaryItemWeight = weight._nUnitaryItemWeight;
            _transfer           = weight._transfer;
			_DETID = 0;
			_SaveTimestamp = DateTime.MinValue;
			_QuantityString_DE = "";
			_EachFormatID_DE = 0;
		}
        public ImportWeight(int transKey, DateTime timestamp, int preConsumer, decimal weight, decimal wasteCost, 
			string foodID, decimal foodCost, decimal discount, string lossID, string containerID, decimal containerWeight, 
			decimal containerCost, string stationID, string dispositionID, string daypartID, string eoID,
            string userID, string userQuestion, int nItems, bool isManual, int memorized, string uniqueUnit, 
			string displayUnit, int producedID, string wasteAmountUserEntry, string unitaryItemWeight)
        {
            _dtWeightTimestamp  = timestamp;        // Date and time of this weight measurement
            _nPreConsumer       = preConsumer;
            _nWeight            = weight;           // Weight for this weight measurement
            _nWasteCost         = wasteCost;        // Total cost of the waste in this record.
            _sFoodTypeID        = foodID;
            _nFoodTypeDiscount  = discount;
            _nFoodTypeCost      = foodCost;
            _sLossTypeID        = lossID;
            _sContainerTypeID   = containerID;
            _nContainerWeight   = containerWeight;  // Weight for this container
            _nContainerCost     = containerCost;    // Total cost of the container in this record.
            _sStationTypeID     = stationID;
            _sDispositionTypeID = dispositionID;
            _sDayPartTypeID     = daypartID;
            _sBEOTypeID         = eoID;
            _sUserTypeID        = userID;           // User name for this weight measurement
            _sUserQuestion      = userQuestion;     // Fully qualified name of the Button that the user selected in response to the User-Defined Question, in the form:	\Menu\submenu\...\name
            _nNItems            = nItems;           // Number of items in this record
            _nRecordingMethod   = memorized;        // 0 => Standard Waste Loop, 1 => Memorized Transaction 	2 => Entered by Volume
            _nProducedID        = producedID;       // reference to original produced data
            _sUnitDisplayName   = displayUnit;               // Units of measure, lookup from table of UOM.
            _sUnitUniqueName    = uniqueUnit;
            _nProducedAmount    = 0;
            _nUnitWeight        = 1;
            _bIsManualInput     = isManual;
            _sProducedLotNum    = "";
            if(VWA4Common.VWACommon.NotNullOrEmpty(wasteAmountUserEntry))
                _nWasteAmountUserEntry = int.Parse(wasteAmountUserEntry);
            if (VWA4Common.VWACommon.NotNullOrEmpty(unitaryItemWeight))
                _nUnitaryItemWeight = decimal.Parse(unitaryItemWeight);
            _transfer           = new ImportTransfer(transKey);
            _IsProduced         = false;
			_DETID = 0;
			_SaveTimestamp = DateTime.Now;
			_DETID = 0;
			_SaveTimestamp = DateTime.MinValue;
			_QuantityString_DE = "";
			_EachFormatID_DE = 0;
		}
        public ImportWeight(int transKey, DateTime timestamp, string lotNumber, string eoID, decimal weight, decimal wasteCost, string foodID, 
            decimal foodCost, string containerID, decimal containerWeight, decimal containerCost, string stationID, string daypartID,
            string userID, string userQuestion, int nItems, bool isManual, int memorized, string uniqueUnit, string displayUnit, 
			int unitWeight, decimal producedAmount, string unitaryItemWeight)
        {
            _dtWeightTimestamp  = timestamp;            // Date and time of this weight measurement
            _sProducedLotNum    = lotNumber;
            _sBEOTypeID         = eoID;
            _nPreConsumer       = 0;
            _nWeight            = weight;               // Weight for this weight measurement
            _nWasteCost         = wasteCost;            // Total cost of the waste in this record.
            _sFoodTypeID        = foodID;
            _nFoodTypeDiscount  = 1;
            _nFoodTypeCost      = foodCost;
            _sLossTypeID        = "";
            _sContainerTypeID   = containerID;
            _nContainerWeight   = containerWeight;      // Weight for this container
            _nContainerCost     = containerCost;        // Total cost of the container in this record.
            _sStationTypeID     = stationID;
            _sDispositionTypeID = "";
            _sDayPartTypeID     = daypartID;
            _sUserTypeID        = userID;               // User name for this weight measurement
            _sUserQuestion      = userQuestion;         // Fully qualified name of the Button that the user selected in response to the User-Defined Question, in the form:	\Menu\submenu\...\name
            _nNItems            = nItems;               // Number of items in this record
            _nRecordingMethod   = memorized;            // 0 => Standard Waste Loop, 1 => Memorized Transaction 	2 => Entered by Volume
            _nProducedID        = -1;                   // reference to original produced data
            _sUnitDisplayName   = displayUnit;                   // Units of measure, lookup from table of UOM.
            _sUnitUniqueName    = uniqueUnit;
            _nUnitWeight        = unitWeight;
            _nProducedAmount    = producedAmount;
            if (VWA4Common.VWACommon.NotNullOrEmpty(unitaryItemWeight))
                _nUnitaryItemWeight = decimal.Parse(unitaryItemWeight);
            _bIsManualInput     = isManual;
            _transfer           = new ImportTransfer(transKey);
            _IsProduced         = true;
			_DETID = 0;
			_SaveTimestamp = DateTime.Now;
			_DETID = 0;
			_SaveTimestamp = DateTime.MinValue;
			_QuantityString_DE = "";
			_EachFormatID_DE = 0;
		}
        public ImportWeight(int transKey, DateTime timestamp, int preConsumer, decimal weight, decimal wasteCost, string foodID, decimal foodCost, decimal discount,
            string lossID, string containerID, decimal containerWeight, decimal containerCost, string stationID, string dispositionID, string daypartID, string eoID,
            string userID, string userQuestion, int nItems, bool isManual, int memorized, string uniqueUnit, string displayUnit, int producedID, 
            string wasteAmountUserEntry, string unitaryItemWeight, decimal producedAmount)
        {
            _dtWeightTimestamp = timestamp;        // Date and time of this weight measurement
            _nPreConsumer = preConsumer;
            _nWeight = weight;           // Weight for this weight measurement
            _nWasteCost = wasteCost;        // Total cost of the waste in this record.
            _sFoodTypeID = foodID;
            _nFoodTypeDiscount = discount;
            _nFoodTypeCost = foodCost;
            _sLossTypeID = lossID;
            _sContainerTypeID = containerID;
            _nContainerWeight = containerWeight;  // Weight for this container
            _nContainerCost = containerCost;    // Total cost of the container in this record.
            _sStationTypeID = stationID;
            _sDispositionTypeID = dispositionID;
            _sDayPartTypeID = daypartID;
            _sBEOTypeID = eoID;
            _sUserTypeID = userID;           // User name for this weight measurement
            _sUserQuestion = userQuestion;     // Fully qualified name of the Button that the user selected in response to the User-Defined Question, in the form:	\Menu\submenu\...\name
            _nNItems = nItems;           // Number of items in this record
            _nRecordingMethod = memorized;        // 0 => Standard Waste Loop, 1 => Memorized Transaction 	2 => Entered by Volume
            _nProducedID = producedID;       // reference to original produced data
            _sUnitDisplayName = displayUnit;               // Units of measure, lookup from table of UOM.
            _sUnitUniqueName = uniqueUnit;
            _nProducedAmount = producedAmount;
            _nUnitWeight = 1;
            _bIsManualInput = isManual;
            if (_nProducedAmount > 0)
                _sProducedLotNum = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");//generate lot # for DB
            else
                _sProducedLotNum = "";
            if (VWA4Common.VWACommon.NotNullOrEmpty(wasteAmountUserEntry))
                _nWasteAmountUserEntry = int.Parse(wasteAmountUserEntry);
            if (VWA4Common.VWACommon.NotNullOrEmpty(unitaryItemWeight))
                _nUnitaryItemWeight = decimal.Parse(unitaryItemWeight);
            _transfer = new ImportTransfer(transKey);
            _IsProduced = false;
			_DETID = 0;
			_SaveTimestamp = DateTime.Now;
			_DETID = 0;
			_SaveTimestamp = DateTime.MinValue;
			_QuantityString_DE = "";
			_EachFormatID_DE = 0;
		}

		/// <summary>
		/// Added by SAR 5/18/10
		/// </summary>
		public ImportWeight(int transKey, DateTime timestamp, int preConsumer, decimal weight, 
			decimal wasteCost, string foodID, decimal foodCost, decimal discount,
			string lossID, string containerID, decimal containerWeight, decimal containerCost, 
			string stationID, string dispositionID, string daypartID, string eoID,
			string userID, string userQuestion, int nItems, bool isManual, int memorized, 
			string uniqueUnit, string displayUnit, int producedID,
			string wasteAmountUserEntry, string unitaryItemWeight, decimal producedAmount,
			int detID, DateTime starttimestamp, DateTime savetimestamp, string QuantityString_DE,
			int EachFormatID_DE)
		{
			_dtWeightTimestamp = timestamp;        // Date and time of this weight measurement
			_nPreConsumer = preConsumer;
			_nWeight = weight;           // Weight for this weight measurement
			_nWasteCost = wasteCost;        // Total cost of the waste in this record.
			_sFoodTypeID = foodID;
			_nFoodTypeDiscount = discount;
			_nFoodTypeCost = foodCost;
			_sLossTypeID = lossID;
			_sContainerTypeID = containerID;
			_nContainerWeight = containerWeight;  // Weight for this container
			_nContainerCost = containerCost;    // Total cost of the container in this record.
			_sStationTypeID = stationID;
			_sDispositionTypeID = dispositionID;
			_sDayPartTypeID = daypartID;
			_sBEOTypeID = eoID;
			_sUserTypeID = userID;           // User name for this weight measurement
			_sUserQuestion = userQuestion;     // Fully qualified name of the Button that the user selected in response to the User-Defined Question, in the form:	\Menu\submenu\...\name
			_nNItems = nItems;           // Number of items in this record
			_nRecordingMethod = memorized;        // 0 => Standard Waste Loop, 1 => Memorized Transaction 	2 => Entered by Volume
			_nProducedID = producedID;       // reference to original produced data
			_sUnitDisplayName = displayUnit;               // Units of measure, lookup from table of UOM.
			_sUnitUniqueName = uniqueUnit;
			_nProducedAmount = producedAmount;
			_nUnitWeight = 1;
			_bIsManualInput = isManual;
			if (_nProducedAmount > 0)
				_sProducedLotNum = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");//generate lot # for DB
			else
				_sProducedLotNum = "";
			if (VWA4Common.VWACommon.NotNullOrEmpty(wasteAmountUserEntry))
				_nWasteAmountUserEntry = decimal.Parse(wasteAmountUserEntry);
			if (VWA4Common.VWACommon.NotNullOrEmpty(unitaryItemWeight))
				_nUnitaryItemWeight = decimal.Parse(unitaryItemWeight);
			_transfer = new ImportTransfer(transKey, isManual);
			_IsProduced = false;
			_DETID = detID;
			_StartTimestamp = starttimestamp;
			_SaveTimestamp = savetimestamp;
			_QuantityString_DE = QuantityString_DE;
			_EachFormatID_DE = EachFormatID_DE;
		}


        public decimal      GetFoodCost()
        { 
            DataTable dt;

            if (_transfer.TypeCatalogID == 0)
                dt = VWA4Common.DB.Retrieve("SELECT Cost FROM FoodType  WHERE TypeID ='" + _sFoodTypeID + "' AND Enabled = true");
            else
                dt = VWA4Common.DB.Retrieve("SELECT FoodCost FROM FoodSubTypes  WHERE TypeID ='" + _sFoodTypeID + "' AND TypeCatalogID = " + _transfer.TypeCatalogID +
                    " AND Enabled = true");
            if(dt != null && dt.Rows.Count > 0)
                return decimal.Parse(dt.Rows[0].ItemArray[0].ToString());
            return 0; 
        }
        public decimal      GetContainerCost(ref decimal weight)
        { 
            DataTable dt;

            if (_transfer.TypeCatalogID == 0)
                dt = VWA4Common.DB.Retrieve("SELECT Cost, TareWeight FROM ContainerType WHERE TypeID ='" + _sContainerTypeID + "' AND Enabled = true");
      
            else 
                dt = VWA4Common.DB.Retrieve("SELECT ContainerCost, ContainerTareWeight " +
                                    " FROM ContainerSubTypes " +
                                    " WHERE TypeID ='" + _sContainerTypeID + "'" +
                                    " AND TypeCatalogID = " + _transfer.TypeCatalogID +
                                    " AND Enabled = true");
          if(dt.Rows.Count > 0)
          {
              weight = decimal.Parse(dt.Rows[0].ItemArray[1].ToString());
              return decimal.Parse(dt.Rows[0].ItemArray[0].ToString());
          }
          else
          {
              weight = 0;
              return 0;
          }
        }
        public decimal      GetTotalFoodCost()
        {
			return GetTotalCost() - GetTotalContainerCost();
            
        }
        // total container cost for all containers
        public decimal      GetTotalContainerCost()
        {
            return _nContainerCost * _nNItems; 
        }
        // total waste cost for all food and containers
        public decimal      GetTotalCost()
        {
			WeightStruct weight = new WeightStruct(_nFoodTypeCost, _nFoodTypeDiscount, _nWeight, _nContainerCost, _nContainerWeight, _nNItems);

			//if (_nRecordingMethod == 3) return weight.WasteCostManualWtMode;
			//else
			return weight.WasteCost; 
        }

        public decimal GetWeight()
        {
            return _nWeight;
        }
        public void ConvertVolumeToPounds()
        {
            decimal res = _nProducedAmount;
            if (_nRecordingMethod == 2)
            {
                DataTable dt = VWA4Common.DB.Retrieve("SELECT VolumeWeight FROM FoodType  WHERE TypeID ='" + _sFoodTypeID + "' AND Enabled = true");

                if (dt != null && dt.Rows.Count > 0)
                    res *= decimal.Parse(dt.Rows[0]["VolumeWeight"].ToString());
                else
                    MessageBox.Show("Volume weight for this Food Type is not found!");
            
                dt = VWA4Common.DB.Retrieve("SELECT * FROM UnitsVolume WHERE UniqueName = '" + _sUnitUniqueName + "'");
                if (dt != null && dt.Rows.Count > 0)
                    res *= decimal.Parse(dt.Rows[0]["ConversionFactor"].ToString());
                else
                    MessageBox.Show("Conversion factor for this Unit is not found!");

                _nProducedAmount = res;
            }
        }
        // returns successfull update or not
        public bool Update() 
        { return false; }

        //todo: write code here
        override public string ToString()
        { return ""; }
        override public bool Init(string str, ImportData transfer, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        { 
            string[] fields = str.Split(',');
            _sErrorMsg      = _sWarningMsg = ""; // delete previouse errors
            _nID            = -1; // no ID before insert
            _transfer       = transfer as ImportTransfer;
            _nProducedID    = -1;

            int i = 0;

            try
            {
                string recType = fields[i++];
                if (recType == WasteRecordType || recType == ProducedRecordType)
                {
                    _IsProduced = recType == ProducedRecordType;
                    _dtWeightTimestamp = DateTime.Parse(fields[i++]);
                    // check date in the end cause can be exception
                    CheckDate(_dtWeightTimestamp);
                    if (_IsProduced)
                    {
                        _sProducedLotNum = fields[i++];
                        _sBEONum = fields[i++];
                    }
                    else
                        _nPreConsumer = int.Parse(fields[i++]);
                    _nWeight = decimal.Parse(fields[i++]);
                    _nWasteCost = decimal.Parse(RemoveS(fields[i++]));
                    _sFoodTypeName = fields[i++];
                    _sFoodTypeID = fields[i++];
                    _nFoodTypeCost = decimal.Parse(RemoveS(fields[i++]));
                    if (!_IsProduced)
                    {
                        _nFoodTypeDiscount = decimal.Parse(RemoveS(fields[i++]));
                        _sLossTypeName = fields[i++];
                        _sLossTypeID = fields[i++];
                    }
                    _sContainerTypeName = fields[i++];
                    _sContainerTypeID = fields[i++];
                    _nContainerWeight = decimal.Parse(fields[i++]);
                    _nContainerCost = decimal.Parse(RemoveS(fields[i++]));
                    _sStationTypeName = fields[i++];
                    _sStationTypeID = fields[i++];
                    if (!_IsProduced)
                    {
                        _sDispositionTypeName = fields[i++];
                        _sDispositionTypeID = fields[i++];
                    }
                    _sDayPartTypeName = fields[i++];
                    _sDayPartTypeID = fields[i++];
                    if (!_IsProduced)
                        _sBEONum = fields[i++];
                    _sUserTypeName = fields[i++];
                    _sUserTypeID = fields[i++];
                    _sUserQuestion = fields[i++];
                    if (fields[i] != "")
                        _nNItems = int.Parse(fields[i++]);
                    else
                    {
                        _nNItems = 1;
                        AddWarning("Incorrect Wasted number of items! Assuming 1!");
                        i++;
                    }
                    _nRecordingMethod = int.Parse(fields[i++]);
                   
                    _nProducedAmount = decimal.Parse(fields[i++]);
                    _sUnitDisplayName = fields[i++];
                    _sUnitUniqueName = fields[i++];
                    //if (!_IsProduced)
                    _sProducedLotNum = fields[i++];
                    if (_nRecordingMethod != 0 && fields[i] != "")
						_nWasteAmountUserEntry = decimal.Parse(fields[i]);
                    i++;
                    if (_nRecordingMethod == 3)
                        _nUnitaryItemWeight  = decimal.Parse(fields[i]);
                    i++;
                }
                else
                {
                    AddError("Wrong record type ID! ");
                    return false;
                }
            }
            catch(Exception ex)
            {
                AddError("Error in the row " + ex.Message);
                return false;
            }
            if (_nRecordingMethod == 0) // Standard Waste Loop
            {
                // Check Duplicates in Weights table
                DataTable dt;
                if(_IsProduced)
                    dt = VWA4Common.DB.Retrieve("SELECT * FROM WeightsProduced " +
                    " WHERE LotNumber = '" + _sProducedLotNum + "'", conn, trans);
                else
                    dt = VWA4Common.DB.Retrieve("SELECT * FROM Weights, Transfers  " +
                    " WHERE Weights.TransKey = Transfers.TransKey" +
                    " AND Weights.Timestamp = #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#" +
                    " AND Transfers.TermID = '" + _transfer.TermID + "'", conn, trans);
                if (dt.Rows.Count != 0)
                {
                    // AddError("Duplicate in Weights found!");
                    return false;
                }

            }
            return true;
        }
        public bool Init(DataRow row, ImportData transfer, bool isProduced, bool isError, System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        {
            _sErrorMsg = _sWarningMsg = ""; // delete previouse errors
            _nID = -1; // no ID before insert
            _transfer = transfer as ImportTransfer;

            try
            {
                _IsProduced = isProduced;
                _dtWeightTimestamp = DateTime.Parse(row["Timestamp"].ToString());
                _sProducedLotNum = row["LotNumber"].ToString();
                if (_IsProduced)
                {
                    _sBEOTypeID = row["EOTypeID"].ToString();
                    _nUnitWeight = int.Parse(row["UnitWeight"].ToString());
                }
                else
                {
                    _nPreConsumer = int.Parse(row["IsPreconsumer"].ToString());
                    _nFoodTypeDiscount = decimal.Parse(RemoveS(row["FoodTypeDiscount"].ToString()));
                    _sLossTypeID = row["LossTypeID"].ToString();
                    _sDispositionTypeID = row["DispositionTypeID"].ToString();
                    _sBEOTypeID = row["BEOTypeID"].ToString();
                    if (_nRecordingMethod != 0 && row["WasteAmountUserEntry"].ToString() != "")
                        _nWasteAmountUserEntry = int.Parse(row["WasteAmountUserEntry"].ToString());
                    _nNItems = int.Parse(row["NItems"].ToString());
                }
                _nWeight = decimal.Parse(row["Weight"].ToString());
                _nWasteCost = decimal.Parse(row["WasteCost"].ToString());
                _sFoodTypeID = row["FoodTypeID"].ToString();
                _nFoodTypeCost = decimal.Parse(RemoveS(row["FoodTypeCost"].ToString()));
                
                _sContainerTypeID = row["ContainerTypeID"].ToString();
                _nContainerWeight = decimal.Parse(row["ContainerWeight"].ToString());
                _nContainerCost = decimal.Parse(RemoveS(row["ContainerCost"].ToString()));
                _sStationTypeID = row["StationTypeID"].ToString();
                
                _sDayPartTypeID = row["DaypartTypeID"].ToString();
                _sUserTypeID = row["UserTypeID"].ToString();
                _sUserQuestion = row["UserQuestion"].ToString();
                
                _nRecordingMethod = int.Parse(row["IsMemorized"].ToString());

                _nProducedAmount = 0;
                decimal.TryParse(row["ProducedAmount"].ToString(), out _nProducedAmount);
                _sUnitUniqueName = row["UnitUniqueName"].ToString();
                
                if (_nRecordingMethod == 3)
                    _nUnitaryItemWeight = decimal.Parse(row["UnitaryItemWeight"].ToString());
                if (isError)
                    _sErrorMsg = row["ErrorMessage"].ToString();
                
            }
            catch (Exception ex)
            {
                AddError("Error in the row " + ex.Message);
                return false;
            }
            if (_nRecordingMethod == 0) // Standard Waste Loop
            {
                // Check Duplicates in Weights table
                DataTable dt;
                if (isError)
                {
                    if (isProduced)
                        dt = VWA4Common.DB.Retrieve("SELECT * FROM ErrorWeightsProduced " +
                        " WHERE LotNumber = '" + _sProducedLotNum + "'", conn, trans);
                    else
                        dt = VWA4Common.DB.Retrieve("SELECT * FROM ErrorWeights, Transfers  " +
                        " WHERE Weights.TransKey = Transfers.TransKey" +
                        " AND Weights.Timestamp = #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#" +
                        " AND Transfers.TermID = '" + _transfer.TermID + "'", conn, trans);
                }
                else
                {
                    if (isProduced)
                        dt = VWA4Common.DB.Retrieve("SELECT * FROM WeightsProduced " +
                        " WHERE LotNumber = '" + _sProducedLotNum + "'", conn, trans);
                    else
                        dt = VWA4Common.DB.Retrieve("SELECT * FROM Weights, Transfers  " +
                        " WHERE Weights.TransKey = Transfers.TransKey" +
                        " AND Weights.Timestamp = #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#" +
                        " AND Transfers.TermID = '" + _transfer.TermID + "'", conn, trans);
                }
                if (dt.Rows.Count != 0)
                {
                    AddError("Duplicate in Weights found!");
                    return false;
                }

            }
            return true;
        }
        //todo: write code here
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="isNew"></param>
        /// <returns></returns>
		override public int DBSave(System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans, bool isNew)
        {
            string sql;
            DataTable dt;
            if (isNew)
            {
                if (this._IsProduced)
                    sql = "INSERT INTO WeightsProduced(TransKey, [Timestamp], LotNumber, EOTypeID, Weight, FoodCost, FoodTypeID, FoodTypeCost, " +
                            " ContainerTypeID, ContainerWeight, ContainerCost, StationTypeID, DaypartTypeID, UserTypeID, UserQuestion, " +
                            " NItems, IsManualInput, IsMemorized, UnitUniqueName, UnitWeight, ProducedAmount, UnitaryItemWeight, UnitsDisplayName) VALUES(" +
                    _transfer.TransKey + ", #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, " + _sProducedLotNum + ", '" + _sBEOTypeID + "', " +
                    _nWeight + ", " + _nWasteCost + ", '" + _sFoodTypeID + "', " + _nFoodTypeCost +
                    ", '" + _sContainerTypeID + "', " + _nContainerWeight + ", " + _nContainerCost + ", '" + _sStationTypeID + "', '" +
                   _sDayPartTypeID + "', '" + _sUserTypeID + "', '" + _sUserQuestion + "', " +
                    _nNItems + ", " + _bIsManualInput + ", " + _nRecordingMethod + ", '" + _sUnitUniqueName + "', " + _nUnitWeight + ", " +
                    _nProducedAmount + ", " + (_nUnitaryItemWeight == 0 ? " NULL " : _nUnitaryItemWeight.ToString()) + ", '" + _sUnitDisplayName + "')";
                else
                {
                    if (_nProducedAmount > 0) // contains produced data - insert it first
                    {
                        if(_nProducedID <= 0 && _sProducedLotNum != "")
                        {
                            dt = VWA4Common.DB.Retrieve("SELECT * FROM WeightsProduced WHERE LotNumber = '" + _sProducedLotNum + "'");
                            if (dt != null && dt.Rows.Count > 0)
                                _nProducedID = int.Parse(dt.Rows[0]["ID"].ToString());
                        }
                        if (_nProducedID < 0)
                        {
                            ConvertVolumeToPounds();
                            sql = "INSERT INTO WeightsProduced(TransKey, [Timestamp], LotNumber, EOTypeID, Weight, FoodCost, FoodTypeID, FoodTypeCost, " +
                                " ContainerTypeID, ContainerWeight, ContainerCost, StationTypeID, DaypartTypeID, UserTypeID, UserQuestion, " +
                                " NItems, IsManualInput, IsMemorized, UnitUniqueName, UnitWeight, ProducedAmount, UnitaryItemWeight, UnitsDisplayName) VALUES(" +
                                _transfer.TransKey + ", #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, '" + _sProducedLotNum + "', '" + _sBEOTypeID + "', " +
                                _nProducedAmount + ", " + _nWasteCost + ", '" + _sFoodTypeID + "', " + _nFoodTypeCost +
                                ", '" + _sContainerTypeID + "', " + _nContainerWeight + ", " + _nContainerCost + ", '" + _sStationTypeID + "', '" +
                                _sDayPartTypeID + "', '" + _sUserTypeID + "', '" + _sUserQuestion + "', " +
                                _nNItems + ", " + _bIsManualInput + ", " + _nRecordingMethod + ", '" + _sUnitUniqueName + "', " + _nUnitWeight + ", " +
                                _nProducedAmount + ", " + (_nUnitaryItemWeight == 0 ? " NULL " : _nUnitaryItemWeight.ToString()) + ", '" + _sUnitDisplayName + "')";
                            this._nProducedID = VWA4Common.DB.Insert(sql, conn, trans);
                        }
                    }
                    sql = "INSERT INTO Weights(TransKey, [Timestamp], IsPreconsumer, Weight, WasteCost, FoodTypeID, FoodTypeCost, FoodTypeDiscount, LossTypeID, " +
                        " ContainerTypeID, ContainerWeight, ContainerCost, StationTypeID, DispositionTypeID, DaypartTypeID, BEOTypeID, UserTypeID, UserQuestion, " +
                        " NItems, IsManualInput, " + " IsMemorized, UnitUniqueName, ProducedID, UnitaryItemWeight, WasteAmountUserEntry, UnitsDisplayName) VALUES(" +
                    _transfer.TransKey + ", #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, " + _nPreConsumer + ", " + _nWeight + ", " + _nWasteCost +
                    ", '" + _sFoodTypeID + "', " + _nFoodTypeCost + ", " + _nFoodTypeDiscount +
                    ", '" + _sLossTypeID + "', '" + _sContainerTypeID + "', " + _nContainerWeight + ", " + _nContainerCost + ", '" + _sStationTypeID + "', '" +
                    _sDispositionTypeID + "', '" + _sDayPartTypeID + "', '" + _sBEOTypeID + "', '" + _sUserTypeID + "', '" + _sUserQuestion + "', " +
                    _nNItems + ", " + _bIsManualInput + ", " + _nRecordingMethod + ", '" + _sUnitUniqueName + "', " +
                    (_nProducedID <= 0 ? "NULL" : _nProducedID.ToString()) + ", " + (_nUnitaryItemWeight == 0 ? " NULL " : _nUnitaryItemWeight.ToString()) +
                    ", " + (_nWasteAmountUserEntry == 0 ? " NULL " : _nWasteAmountUserEntry.ToString()) + ", '" + _sUnitDisplayName + "')";
                }
                this._nID = VWA4Common.DB.Insert(sql, conn, trans);
            }
            else
            {
                if (this._IsProduced)
                    sql = "UPDATE WeightsProduced SET " +
                        "TransKey = " + _transfer.TransKey + ", [Timestamp] = #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, " +
                        " LotNumber = '" + _sProducedLotNum + "', EOTypeID = '" + _sBEOTypeID + "', " +
                        " Weight = " + _nWeight + ", FoodCost = " + _nWasteCost + ", FoodTypeID ='" + _sFoodTypeID + "', " +
                        " FoodTypeCost = " + _nFoodTypeCost + ", ContainerTypeID = '" + _sContainerTypeID + "', " +
                        " ContainerWeight = " + _nContainerWeight + ", ContainerCost = " + _nContainerCost + ", " +
                        " StationTypeID = '" + _sStationTypeID + "', DaypartTypeID = '" + _sDayPartTypeID + "', " +
                        " UserTypeID = '" + _sUserTypeID + "', UserQuestion = '" + _sUserQuestion + "', " +
                        " NItems = " + _nNItems + ", IsManualInput = " + _bIsManualInput + ", IsMemorized = " + _nRecordingMethod + ", " +
                        " UnitUniqueName = '" + _sUnitUniqueName + "', UnitWeight = " + _nUnitWeight + ", ProducedAmount = " + _nProducedAmount +
                        (_nUnitaryItemWeight == 0 ? "" : ", UnitaryItemWeight = " + _nUnitaryItemWeight.ToString()) +
                        ", UnitsDisplayName = '" + _sUnitDisplayName + "'";
                else
                {
                    sql = "UPDATE Weights SET " +
                        " TransKey = " + _transfer.TransKey + ", [Timestamp] = #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, " +
                        " IsPreconsumer = " + _nPreConsumer + ", Weight = " + _nWeight + ", WasteCost = " + _nWasteCost + ", " +
                        " FoodTypeID = '" + _sFoodTypeID + "', FoodTypeCost = " + _nFoodTypeCost + ", " +
                        " FoodTypeDiscount = " + _nFoodTypeDiscount + ", LossTypeID = '" + _sLossTypeID + "', " +
                        " ContainerTypeID = '" + _sContainerTypeID + "', ContainerWeight = " + _nContainerWeight + ", " +
                        " ContainerCost = " + _nContainerCost + ", StationTypeID = '" + _sStationTypeID + "', " +
                        " DispositionTypeID = '" + _sDispositionTypeID + "', DaypartTypeID = '" + _sDayPartTypeID + "', " +
                        " BEOTypeID = '" + _sBEOTypeID + "', UserTypeID = '" + _sUserTypeID + "', UserQuestion = '" + _sUserQuestion + "', " +
                        " NItems = " + _nNItems + ", IsManualInput = " + _bIsManualInput + ", " + " IsMemorized = " + _nRecordingMethod + ", " +
                        " UnitUniqueName = '" + _sUnitUniqueName + "'" + (_nProducedID < 0 ? "" : ", ProducedID = " + _nProducedID.ToString()) +
                        (_nUnitaryItemWeight == 0 ? "" : ", UnitaryItemWeight = " +_nUnitaryItemWeight.ToString()) +
                        (_nWasteAmountUserEntry == 0 ? "" : ", WasteAmountUserEntry = " + _nWasteAmountUserEntry.ToString()) +
                        ", UnitsDisplayName = '" + _sUnitDisplayName + "'";
                }
                VWA4Common.DB.Update(sql, conn, trans);
            }
            return this._nID;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isNew"></param>
        /// <returns></returns>
		override public int DBSave(bool isNew)
        {
            string sql;
            DataTable dt;
            if (isNew)
            {
                if (this._IsProduced)
                    sql = "INSERT INTO WeightsProduced(TransKey, [Timestamp], LotNumber, EOTypeID, Weight, FoodCost, FoodTypeID, FoodTypeCost, " +
                            " ContainerTypeID, ContainerWeight, ContainerCost, StationTypeID, DaypartTypeID, UserTypeID, UserQuestion, " +
                            " NItems, IsManualInput, IsMemorized, UnitUniqueName, UnitWeight, ProducedAmount, UnitaryItemWeight, UnitsDisplayName) VALUES(" +
                    _transfer.TransKey + ", #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, '" + _sProducedLotNum + "', '" + _sBEOTypeID + "', " +
                    _nWeight + ", " + _nWasteCost + ", '" + _sFoodTypeID + "', " + _nFoodTypeCost +
                    ", '" + _sContainerTypeID + "', " + _nContainerWeight + ", " + _nContainerCost + ", '" + _sStationTypeID + "', '" +
                   _sDayPartTypeID + "', '" + _sUserTypeID + "', '" + _sUserQuestion + "', " +
                    _nNItems + ", " + _bIsManualInput + ", " + _nRecordingMethod + ", '" + _sUnitUniqueName + "', " + _nUnitWeight + ", " + _nProducedAmount +
                    (_nUnitaryItemWeight == 0 ? ", NULL" : ", " +_nUnitaryItemWeight.ToString()) + ", '" + _sUnitDisplayName + "')";
                else
                {
                    if (_nProducedAmount > 0) // contains produced data - insert it first
                    {
                        if(_nProducedID <= 0 && _sProducedLotNum != "")
                        {
                            dt = VWA4Common.DB.Retrieve("SELECT * FROM WeightsProduced WHERE LotNumber = '" + _sProducedLotNum + "'");
                            if (dt != null && dt.Rows.Count > 0)
                                _nProducedID = int.Parse(dt.Rows[0]["ID"].ToString());
                        }
                        if (_nProducedID < 0)
                        {
                            ConvertVolumeToPounds();
                            sql = "INSERT INTO WeightsProduced(TransKey, [Timestamp], LotNumber, EOTypeID, Weight, FoodCost, FoodTypeID, FoodTypeCost, " +
                                " ContainerTypeID, ContainerWeight, ContainerCost, StationTypeID, DaypartTypeID, UserTypeID, UserQuestion, " +
                                " NItems, IsManualInput, IsMemorized, UnitUniqueName, UnitWeight, ProducedAmount, UnitaryItemWeight, UnitsDisplayName) VALUES(" +
                                _transfer.TransKey + ", #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, '" + _sProducedLotNum + "', '" + _sBEOTypeID + "', " +
                                _nProducedAmount + ", " + _nWasteCost + ", '" + _sFoodTypeID + "', " + _nFoodTypeCost +
                                ", '" + _sContainerTypeID + "', " + _nContainerWeight + ", " + _nContainerCost + ", '" + _sStationTypeID + "', '" +
                                _sDayPartTypeID + "', '" + _sUserTypeID + "', '" + _sUserQuestion + "', " +
                                _nNItems + ", " + _bIsManualInput + ", " + _nRecordingMethod + ", '" + _sUnitUniqueName + "', " + _nUnitWeight + ", " + _nProducedAmount +
                                (_nUnitaryItemWeight == 0 ? ", NULL" : ", " + _nUnitaryItemWeight.ToString()) + ", '" + _sUnitDisplayName + "')";
                            this._nProducedID = VWA4Common.DB.Insert(sql);
                        }
                    }
                  ///
					/// This is where new transactions get saved!!
					/// 
					sql = "INSERT INTO Weights(TransKey, [Timestamp], IsPreconsumer, Weight, WasteCost, FoodTypeID, FoodTypeCost, FoodTypeDiscount, LossTypeID, " +
                        " ContainerTypeID, ContainerWeight, ContainerCost, StationTypeID, DispositionTypeID, DaypartTypeID, BEOTypeID, UserTypeID, UserQuestion, " +
                        " NItems, IsManualInput, " +
						" IsMemorized, UnitUniqueName, ProducedID, UnitaryItemWeight, WasteAmountUserEntry, UnitsDisplayName, DETID, " +
						"StartTimestamp, SaveTimestamp, QuantityString_DE, EachFormatID_DE) VALUES(" +
                    _transfer.TransKey + ", #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, " + _nPreConsumer + ", " + _nWeight + ", " + _nWasteCost +
                    ", '" + _sFoodTypeID + "', " + _nFoodTypeCost + ", " + _nFoodTypeDiscount +
                    ", '" + _sLossTypeID + "', '" + _sContainerTypeID + "', " + _nContainerWeight + ", " + 
					_nContainerCost + ", '" + _sStationTypeID + "', '" +
                    _sDispositionTypeID + "', '" + _sDayPartTypeID + "', '" + _sBEOTypeID + "', '" + _sUserTypeID + "', '" + _sUserQuestion + "', " +
                    _nNItems + ", " + _bIsManualInput + ", " + _nRecordingMethod + ", '" + _sUnitUniqueName + "', " +
                    (_nProducedID < 0 ? "NULL" : _nProducedID.ToString()) + ", " +
                    (_nUnitaryItemWeight == 0 ? " NULL" : _nUnitaryItemWeight.ToString()) + ", " +
                    (_nWasteAmountUserEntry == 0 ? "NULL" : _nWasteAmountUserEntry.ToString()) + ", '" + 
					_sUnitDisplayName + "', " + _DETID.ToString() +
					", #" + VWA4Common.VWACommon.DateToString(_StartTimestamp) + "#, #" + VWA4Common.VWACommon.DateToString(_SaveTimestamp) + "#, '" + _QuantityString_DE + "'," +
					_EachFormatID_DE + ")";
                }
                this._nID = VWA4Common.DB.Insert(sql);
            }
            else
            {
				if (this._IsProduced)
					sql = "UPDATE WeightsProduced SET " +
						"TransKey = " + _transfer.TransKey + ", [Timestamp] = #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, " +
						" LotNumber = '" + _sProducedLotNum + "', EOTypeID = '" + _sBEOTypeID + "', " +
						" Weight = " + _nWeight + ", FoodCost = " + _nWasteCost + ", FoodTypeID ='" + _sFoodTypeID + "', " +
						" FoodTypeCost = " + _nFoodTypeCost + ", ContainerTypeID = '" + _sContainerTypeID + "', " +
						" ContainerWeight = " + _nContainerWeight + ", ContainerCost = " + _nContainerCost + ", " +
						" StationTypeID = '" + _sStationTypeID + "', DaypartTypeID = '" + _sDayPartTypeID + "', " +
						" UserTypeID = '" + _sUserTypeID + "', UserQuestion = '" + _sUserQuestion + "', " +
						" NItems = " + _nNItems + ", IsManualInput = " + _bIsManualInput + ", IsMemorized = " + _nRecordingMethod + ", " +
						" UnitUniqueName = '" + _sUnitUniqueName + "', UnitWeight = " + _nUnitWeight + ", ProducedAmount =" + _nProducedAmount +
						(_nUnitaryItemWeight == 0 ? "" : ", UnitaryItemWeight = " + _nUnitaryItemWeight.ToString()) +
						", UnitsDisplayName = '" + _sUnitDisplayName + "'";
				else
					///
					/// This is where saved transactions get updated!!
					/// 
					sql = "UPDATE Weights SET " +
						" TransKey = " + _transfer.TransKey + ", [Timestamp] = #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, " +
						" IsPreconsumer = " + _nPreConsumer + ", Weight = " + _nWeight + ", WasteCost = " + _nWasteCost + ", " +
						" FoodTypeID = '" + _sFoodTypeID + "', FoodTypeCost = " + _nFoodTypeCost + ", " +
						" FoodTypeDiscount = " + _nFoodTypeDiscount + ", LossTypeID = '" + _sLossTypeID + "', " +
						" ContainerTypeID = '" + _sContainerTypeID + "', ContainerWeight = " + _nContainerWeight + ", " +
						" ContainerCost = " + _nContainerCost + ", StationTypeID = '" + _sStationTypeID + "', " +
						" DispositionTypeID = '" + _sDispositionTypeID + "', DaypartTypeID = '" + _sDayPartTypeID + "', " +
						" BEOTypeID = '" + _sBEOTypeID + "', UserTypeID = '" + _sUserTypeID + "', UserQuestion = '" + _sUserQuestion + "', " +
						" NItems = " + _nNItems + ", IsManualInput = " + _bIsManualInput + ", " + " IsMemorized = " + _nRecordingMethod + ", " +
						" UnitUniqueName = '" + _sUnitUniqueName + "'" + (_nProducedID < 0 ? "" : ", ProducedID = " + _nProducedID.ToString()) +
						(_nUnitaryItemWeight == 0 ? "" : ", UnitaryItemWeight = " + _nUnitaryItemWeight.ToString()) +
						(_nWasteAmountUserEntry == 0 ? "" : ", WasteAmountUserEntry = " + _nWasteAmountUserEntry.ToString()) +
						", UnitsDisplayName = '" + _sUnitDisplayName + "'" + ", DETID = " + _DETID.ToString() +
						", Timestamp_DE = #" + VWA4Common.VWACommon.DateToString(_SaveTimestamp) + "#, QuantityString_DE ='" + _QuantityString_DE + "'" +
						", EachFormatID_DE = " + _EachFormatID_DE;
                VWA4Common.DB.Update(sql);
            }
            return this._nID;
        }
        //
        public int DBSaveError(System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans, bool isNew)
        {
            string sql;
            if (isNew)
            {
                if (this._IsProduced)
                    sql = "INSERT INTO ErrorWeightsProduced(TransKey, [Timestamp], LotNumber, EOTypeID, Weight, FoodCost, FoodTypeID, FoodTypeCost, " +
                            " ContainerTypeID, ContainerWeight, ContainerCost, StationTypeID, DaypartTypeID, UserTypeID, UserQuestion, " +
                            " NItems, IsManualInput, IsMemorized, UnitUniqueName, UnitWeight, ProducedAmount, Error, UnitaryItemWeight, UnitsDisplayName) VALUES(" +
                    _transfer.TransKey + ", #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, '" + _sProducedLotNum + "', '" + _sBEOTypeID + "', " +
                    _nWeight + ", " + _nWasteCost + ", '" + _sFoodTypeID + "', " + _nFoodTypeCost +
                    ", '" + _sContainerTypeID + "', " + _nContainerWeight + ", " + _nContainerCost + ", '" + _sStationTypeID + "', '" +
                   _sDayPartTypeID + "', '" + _sUserTypeID + "', '" + _sUserQuestion + "', " +
                    _nNItems + ", " + _bIsManualInput + ", " + _nRecordingMethod + ", '" + _sUnitUniqueName + "', " + _nUnitWeight + ", " + _nProducedAmount + ", '" +
                    _sErrorMsg.Replace("'", "''") + Environment.NewLine + _sWarningMsg.Replace("'", "''") + "', " +
                    (_nUnitaryItemWeight == 0 ? "NULL" : _nUnitaryItemWeight.ToString()) + ", '" + _sUnitDisplayName + "')";
                else
                {
                    if (_nProducedAmount > 0) // contains produced data - insert it first
                    {
                        if(_nProducedID <= 0 && _sProducedLotNum != "")
                        {
                            DataTable dt;
                            dt = VWA4Common.DB.Retrieve("SELECT * FROM WeightsProduced WHERE LotNumber = '" + _sProducedLotNum + "'");
                            if (dt != null && dt.Rows.Count > 0)
                                _nProducedID = int.Parse(dt.Rows[0]["ID"].ToString());
                        }
                        if (_nProducedID < 0)
                        {
                            ConvertVolumeToPounds();

                            sql = "INSERT INTO ErrorWeightsProduced(TransKey, [Timestamp], LotNumber, EOTypeID, Weight, FoodCost, FoodTypeID, FoodTypeCost, " +
                                " ContainerTypeID, ContainerWeight, ContainerCost, StationTypeID, DaypartTypeID, UserTypeID, UserQuestion, " +
                                " NItems, IsManualInput, IsMemorized, UnitUniqueName, UnitWeight, ProducedAmount, Error, UnitaryItemWeight, UnitsDisplayName) VALUES(" +
                                _transfer.TransKey + ", #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, '" + _sProducedLotNum + "', '" + _sBEOTypeID + "', " +
                                _nProducedAmount + ", " + _nWasteCost + ", '" + _sFoodTypeID + "', " + _nFoodTypeCost +
                                ", '" + _sContainerTypeID + "', " + _nContainerWeight + ", " + _nContainerCost + ", '" + _sStationTypeID + "', '" +
                                _sDayPartTypeID + "', '" + _sUserTypeID + "', '" + _sUserQuestion + "', " +
                                _nNItems + ", " + _bIsManualInput + ", " + _nRecordingMethod + ", '" + _sUnitUniqueName + "', " + _nUnitWeight + ", " +
                                _nProducedAmount + ", '" + _sErrorMsg.Replace("'", "''") + Environment.NewLine + _sWarningMsg.Replace("'", "''") + "', " +
                                (_nUnitaryItemWeight == 0 ? "NULL" : _nUnitaryItemWeight.ToString()) + ", '" + _sUnitDisplayName + "')";
                            this._nProducedID = VWA4Common.DB.Insert(sql, conn, trans);
                        }
                    }
                    sql = "INSERT INTO ErrorWeights(TransKey, [Timestamp], IsPreconsumer, Weight, WasteCost, FoodTypeID, FoodTypeCost, FoodTypeDiscount, LossTypeID, " +
                        " ContainerTypeID, ContainerWeight, ContainerCost, StationTypeID, DispositionTypeID, DaypartTypeID, BEOTypeID, UserTypeID, UserQuestion, " +
                        " NItems, IsMemorized, IsManualInput, UnitUniqueName, ProducedID, Error, UnitaryItemWeight, WasteAmountUserEntry, UnitsDisplayName) VALUES(" +
                        _transfer.TransKey + ", #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, " + _nPreConsumer + ", " + _nWeight + ", " + _nWasteCost +
                        ", '" + _sFoodTypeID + "', " + _nFoodTypeCost + ", " + _nFoodTypeDiscount +
                        ", '" + _sLossTypeID + "', '" + _sContainerTypeID + "', " + _nContainerWeight + ", " + _nContainerCost + ", '" + _sStationTypeID + "', '" +
                        _sDispositionTypeID + "', '" + _sDayPartTypeID + "', '" + _sBEOTypeID + "', '" + _sUserTypeID + "', '" + _sUserQuestion + "', " +
                        _nNItems + ", " + _nRecordingMethod + ", " + _bIsManualInput + ", '" + _sUnitUniqueName + "', " + (_nProducedID < 0 ? "NULL" : _nProducedID.ToString()) +
                        ", '" + _sErrorMsg.Replace("'", "''") + Environment.NewLine + _sWarningMsg.Replace("'", "''") + "', " +
                        (_nUnitaryItemWeight == 0 ? " NULL" : _nUnitaryItemWeight.ToString()) + ", " +
                        (_nWasteAmountUserEntry == 0 ? "NULL" : _nWasteAmountUserEntry.ToString()) + ", '" + _sUnitDisplayName + "')";
                }
                this._nID = VWA4Common.DB.Insert(sql, conn, trans);
            }
            else 
            {
                if (this._IsProduced)
                    sql = "UPDATE ErrorWeightsProduced SET " +
                        " TransKey = " + _transfer.TransKey + ", [Timestamp] = #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, " +
                        " LotNumber = '" + _sProducedLotNum + "', " + " EOTypeID = '" + _sBEOTypeID + "', " +
                        " Weight = " + _nWeight + ", " + " FoodCost = " + _nWasteCost + ", FoodTypeID = '" + _sFoodTypeID + "', " +
                        " FoodTypeCost = " + _nFoodTypeCost + ", ContainerTypeID = '" + _sContainerTypeID + "', " +
                        " ContainerWeight = " + _nContainerWeight + ", ContainerCost = " + _nContainerCost + ", " +
                        " StationTypeID = '" + _sStationTypeID + "', DaypartTypeID = '" + _sDayPartTypeID + "', " +
                        " UserTypeID = '" + _sUserTypeID + "', UserQuestion = '" + _sUserQuestion + "', " +
                        " NItems = " + _nNItems + ", IsManualInput = " + _bIsManualInput + ", IsMemorized = " + _nRecordingMethod + ", " +
                        " UnitUniqueName = '" + _sUnitUniqueName + "', " + " UnitWeight = " + _nUnitWeight + ", ProducedAmount = " + _nProducedAmount + ", " +
                        " Error = '" + _sErrorMsg.Replace("'", "''") + Environment.NewLine + _sWarningMsg.Replace("'", "''") + "'" +
                        (_nUnitaryItemWeight == 0 ? "" : ", UnitaryItemWeight = " + _nUnitaryItemWeight.ToString()) +
                        ", UnitsDisplayName = '" + _sUnitDisplayName + "'";
                else
                    sql = "UPDATE ErrorWeights SET " +
                        " TransKey = " + _transfer.TransKey + ", [Timestamp] = #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#, " +
                        " IsPreconsumer = " + _nPreConsumer + ", Weight = " + _nWeight + ", WasteCost = " + _nWasteCost + ", " +
                        " FoodTypeID = '" + _sFoodTypeID + "', " + " FoodTypeCost = " + _nFoodTypeCost + ", " +
                        " FoodTypeDiscount = " + _nFoodTypeDiscount + ", LossTypeID = '" + _sLossTypeID + "', " +
                        " ContainerTypeID = '" + _sContainerTypeID + "', ContainerWeight = " + _nContainerWeight + ", " +
                        " ContainerCost = " + _nContainerCost + ", " + " StationTypeID = '" + _sStationTypeID + "', " +
                        " DispositionTypeID = '" + _sDispositionTypeID + "', DaypartTypeID = '" + _sDayPartTypeID + "', " +
                        " BEOTypeID = '" + _sBEOTypeID + "', " + " UserTypeID = '" + _sUserTypeID + "', " +
                        " UserQuestion = '" + _sUserQuestion + "', " + " NItems = " + _nNItems + ", " +
                        " IsManualInput = " + _bIsManualInput + ", " + " IsMemorized = " + _nRecordingMethod + ", " +
                        " UnitUniqueName = '" + _sUnitUniqueName + "' " + (_nProducedID < 0 ? "" : ", ProducedID = " +_nProducedID.ToString()) + ", " +
                        " Error = '" + _sErrorMsg.Replace("'", "''") + Environment.NewLine + _sWarningMsg.Replace("'", "''") + "'" +
                        (_nUnitaryItemWeight == 0 ? "" : ", UnitaryItemWeight = " + _nUnitaryItemWeight.ToString()) +
                        (_nWasteAmountUserEntry == 0 ? "" : ", WasteAmountUserEntry" + _nWasteAmountUserEntry.ToString()) +
                        ", UnitsDisplayName = '" + _sUnitDisplayName + "'";
                VWA4Common.DB.Update(sql, conn, trans);
            }
            return this._nID;
        }
        //todo: write code here
        override public bool DBLoad(int id)
        {
            DataTable dt = VWA4Common.DB.Retrieve("SELECT * FROM Weights " +
                                            " WHERE ID = " + id);

            if (dt.Rows.Count == 0)
                return false;
            else
            {
                _nID = id;
                /*
                _transfer.TransKey = dt.Rows[0]["TransKey"];
                _dtWeightTimestamp = dt.Rows[0]["Timestamp"];
                _nPreConsumer = dt.Rows[0]["IsPreconsumer"];
                _nWeight = decimal.Parse(dt.Rows[0]["Weight"]);
                _nWasteCost = decimal.Parse(dt.Rows[0]["WasteCost"]);
                _bIsPrior = bool.Parse(dt.Rows[0]["FoodTypeID"]);
                _dtTransTimestamp = dt.Rows[0]["FoodTypeCost"];
                _sTermID = dt.Rows[0]["LossTypeID"];
                _sVWTSWVersion = dt.Rows[0]["ContainerTypeID"];
                _nSiteID = dt.Rows[0]["ContainerWeight"];
                _nTypeCatalogID = dt.Rows[0]["ContainerCost"];
                _bIsPrior = bool.Parse(dt.Rows[0]["StationTypeID"]);
                _dtTransTimestamp = dt.Rows[0]["DispositionTypeID"];
                _sTermID = dt.Rows[0]["DaypartTypeID"];
                _sVWTSWVersion = dt.Rows[0]["BEOTypeID"];
                _nSiteID = dt.Rows[0]["UserTypeID"];
                _nTypeCatalogID = dt.Rows[0]["UserQuestion"];
                _bIsPrior = bool.Parse(dt.Rows[0]["NItems"]);
                _bIsPrior = bool.Parse(dt.Rows[0]["IsManualInput"]);
                _bIsPrior = bool.Parse(dt.Rows[0]["IsMemorized"]);
                _bIsPrior = bool.Parse(dt.Rows[0]["ProducedID"]);
                _bIsPrior = bool.Parse(dt.Rows[0]["UnitUniqueName"]);
                _bIsPrior = bool.Parse(dt.Rows[0]["TermID"]);
                _sTermID = dt.Rows[0]["TypeCatalogID"];
                _sVWTSWVersion = dt.Rows[0]["TypeCatalogName"];
                _nSiteID = dt.Rows[0]["SiteID"];
                _nTypeCatalogID = dt.Rows[0]["SiteName"];
                 * */
                return true;
            }
        }

        override public void AddError(string errorMsg)
        {
            if (!VWA4Common.VWACommon.NotNullOrEmpty(_sErrorMsg))
                _sErrorMsg = this._dtWeightTimestamp == new DateTime(0) ? VWA4Common.VWACommon.DateToString(DateTime.Now) : VWA4Common.VWACommon.DateToTrackerString(_dtWeightTimestamp) +
                    " Error in Weight Record:";
            base.AddError(errorMsg);
        }
        override public void AddWarning(string warningMsg)
        {
            if (!VWA4Common.VWACommon.NotNullOrEmpty(_sWarningMsg))
                _sWarningMsg = this._dtWeightTimestamp == new DateTime(0) ? VWA4Common.VWACommon.DateToString(DateTime.Now) : VWA4Common.VWACommon.DateToTrackerString(_dtWeightTimestamp) +
                    " Warning in Weight Record:";
            base.AddWarning(warningMsg);
        }
        override public bool Check()
        {
            bool res = false;
            System.Data.OleDb.OleDbConnection conn = VWA4Common.DB.OpenConnection();
            res = Check(conn, null);
            VWA4Common.DB.CloseConnection(conn);
            return res;
        }
        override public bool Check(System.Data.OleDb.OleDbConnection conn, System.Data.OleDb.OleDbTransaction trans)
        { 
            DataTable dt;
            string sError = "", temp = "";

			if (_dtWeightTimestamp > _transfer.Timestamp)
			{
			if (_transfer.IsManualDESession)
				AddWarning("Waste record timestamp is later than session start time");
				else
				AddWarning("Waste record timestamp is later than data import time");
			}
            // Check Transfer ID exists
            dt = VWA4Common.DB.Retrieve("SELECT * FROM Transfers WHERE TransKey = " + _transfer.TransKey, conn, trans);
            if( dt.Rows.Count == 0)
                AddError("No such Transfer ID");
            // Init weight BEO Type ID
            if (VWA4Common.VWACommon.NotNullOrEmpty(_sBEONum)) //(VWA4Common.VWACommon.NotNullOrEmpty(_sBEOTypeID)) && (
                _sBEOTypeID = VWA4Common.VWADBUtils.GetBEOID(_sBEONum, _transfer.Timestamp, _transfer.TypeCatalogID, ref sError, conn, trans);
            if (VWA4Common.VWACommon.NotNullOrEmpty(sError))
                AddWarning(sError);// add error if needed
            // todo: init produced
            if(!_IsProduced && _sProducedLotNum != "" && _nProducedID < 0)
            {
                if (_nProducedAmount <= 0) // reference to existed produced data
                    _nProducedID = VWA4Common.VWADBUtils.GetProducedID(_sProducedLotNum, ref sError, conn, trans);
                else if(VWA4Common.VWADBUtils.GetProducedID(_sProducedLotNum, ref temp, conn, trans) >= 0) // if waste data contains produce - we should split record!
                    AddError("Produced record with such Lot number already exists!");
                if (VWA4Common.VWACommon.NotNullOrEmpty(sError))
                    AddError(sError);// add warning if needed
            }
            
            if (_transfer.TypeCatalogID == 0) // check for master catalog
            {
                // Check FoodTypeID exists

                dt = VWA4Common.DB.Retrieve("SELECT * FROM FoodType WHERE TypeID = '" + _sFoodTypeID + "' AND Enabled = true");

                if (dt.Rows.Count == 0)
                    AddError("No such FoodTypeID for this TypeCatalogID");

                // Check LossTypeID exists
                if (!_IsProduced)
                {
                    dt = VWA4Common.DB.Retrieve("SELECT * FROM LossType WHERE TypeID = '" + _sLossTypeID + "' AND Enabled = true");

                    if (dt.Rows.Count == 0)
                        AddError("No such LossTypeID for this TypeCatalogID");
                }
                // Check ContainerTypeID exists

                dt = VWA4Common.DB.Retrieve("SELECT * FROM ContainerType WHERE TypeID = '" + _sContainerTypeID + "' AND Enabled = true");

                if (dt.Rows.Count == 0)
                    AddError("No such ContainerTypeID for this TypeCatalogID");

                // Check StationTypeID exists
                if (VWA4Common.VWACommon.NotNullOrEmpty(_sStationTypeID))
                {
					string sql = "SELECT * FROM StationType " +
						" WHERE TypeID = '" + _sStationTypeID + "' AND Enabled = true";
					dt = VWA4Common.DB.Retrieve(sql);
                    if (dt.Rows.Count == 0)
                        AddError("No such StationTypeID for this TypeCatalogID");
                }
                // Check DispositionTypeID exists
                if (VWA4Common.VWACommon.NotNullOrEmpty(_sDispositionTypeID))
                    if (VWA4Common.DB.Retrieve("SELECT * FROM DispositionType " +
                            " WHERE TypeID = '" + _sDispositionTypeID + "' AND Enabled = true").Rows.Count == 0)
                        AddError("No such DispositionTypeID for this TypeCatalogID");

                // Check DayPartTypeID exists
                if (VWA4Common.VWACommon.NotNullOrEmpty(_sDayPartTypeID))
                    if (VWA4Common.DB.Retrieve("SELECT * FROM DayPartType " +
                    " WHERE TypeID = '" + _sDayPartTypeID + "' AND Enabled = true").Rows.Count == 0)
                        AddError("No such DayPartTypeID for this TypeCatalogID");

                // Check BEOID exists
                if (VWA4Common.VWACommon.NotNullOrEmpty(_sBEONum))
                    if (VWA4Common.DB.Retrieve("SELECT * FROM BEOType  WHERE TypeID = '" + _sBEOTypeID + "' AND Enabled = true", conn, trans).Rows.Count == 0)
                        AddError("No such BEOTypeNumber for this TypeCatalogID");

                // Check UserTypeID exists
                if (VWA4Common.VWACommon.NotNullOrEmpty(_sUserTypeID))
                    if (VWA4Common.DB.Retrieve("SELECT * FROM UserType  WHERE TypeID = '" + _sUserTypeID + "' AND Enabled = true").Rows.Count == 0)
                        AddError("No such UserTypeID for this TypeCatalogID");
            }
            else     // not master
            {
                // Check FoodTypeID exists

                dt = VWA4Common.DB.Retrieve("SELECT * FROM FoodSubTypes WHERE TypeID = '" + _sFoodTypeID + "'" +
                    " AND TypeCatalogID = " + _transfer.TypeCatalogID +
                    " AND Enabled = True;");
                if (dt.Rows.Count == 0)
                    AddError("No such FoodTypeID for this TypeCatalogID");

                // Check LossTypeID exists
                if (!_IsProduced)
                {
                    dt = VWA4Common.DB.Retrieve("SELECT * FROM LossSubTypes WHERE TypeID = '" + _sLossTypeID + "'" +
                                                " AND TypeCatalogID = " + _transfer.TypeCatalogID +
                                                " AND Enabled = True;");
                    if (dt.Rows.Count == 0)
                        AddError("No such LossTypeID for this TypeCatalogID");
                }
                // Check ContainerTypeID exists

                dt = VWA4Common.DB.Retrieve("SELECT * FROM ContainerSubTypes WHERE TypeID = '" + _sContainerTypeID + "'" +
                                            " AND TypeCatalogID = " + _transfer.TypeCatalogID +
                                            " AND Enabled = True;");
                if (dt.Rows.Count == 0)
                    AddError("No such ContainerTypeID for this TypeCatalogID");

                // Check StationTypeID exists
                if (VWA4Common.VWACommon.NotNullOrEmpty(_sStationTypeID))
                    if (VWA4Common.DB.Retrieve("SELECT * FROM StationSubTypes " +
                                " WHERE TypeID = '" + _sStationTypeID + "'" +
                                " AND TypeCatalogID = " + _transfer.TypeCatalogID +
                                " AND Enabled = True;").Rows.Count == 0)
                        AddError("No such StationTypeID for this TypeCatalogID");

                // Check DispositionTypeID exists
                if (VWA4Common.VWACommon.NotNullOrEmpty(_sDispositionTypeID))
                    if (VWA4Common.DB.Retrieve("SELECT * FROM DispositionSubTypes " +
                                " WHERE TypeID = '" + _sDispositionTypeID + "'" +
                                " AND TypeCatalogID = " + _transfer.TypeCatalogID +
                                " AND Enabled = True;").Rows.Count == 0)
                        AddError("No such DispositionTypeID for this TypeCatalogID");

                // Check DayPartTypeID exists
                if (VWA4Common.VWACommon.NotNullOrEmpty(_sDayPartTypeID))
                    if (VWA4Common.DB.Retrieve("SELECT * FROM DayPartSubTypes " +
                                " WHERE TypeID = '" + _sDayPartTypeID + "'" +
                                " AND TypeCatalogID = " + _transfer.TypeCatalogID +
                                " AND Enabled = True;").Rows.Count == 0)
                        AddError("No such DayPartTypeID for this TypeCatalogID");

                // Check BEOTypeID exists
                if (VWA4Common.VWACommon.NotNullOrEmpty(_sBEONum))
                    if (VWA4Common.DB.Retrieve("SELECT * FROM BEOSubTypes " +
                                " WHERE TypeCatalogID = " + _transfer.TypeCatalogID +
                                " AND Enabled = True " +
                                " AND TypeID = '" + _sBEOTypeID + "';", conn, trans).Rows.Count == 0)
                        AddError("No such BEOTypeID for this TypeCatalogID");

                // Check UserTypeID exists
                if (VWA4Common.VWACommon.NotNullOrEmpty(_sUserTypeID))
                    if (VWA4Common.DB.Retrieve("SELECT * FROM UserSubTypes " +
                                " WHERE TypeID = '" + _sUserTypeID + "' " +
                                " AND TypeCatalogID = " + _transfer.TypeCatalogID +
                                " AND Enabled = True;").Rows.Count == 0)
                        AddError("No such UserTypeID for this TypeCatalogID");
            }
            // Check UniqueName and DisplayName corresponds
            if (_sUnitUniqueName != "")
            {
                if (_nRecordingMethod == 2)
                    dt = VWA4Common.DB.Retrieve("SELECT * FROM UnitsVolume WHERE UniqueName = '" + _sUnitUniqueName + "'");
                else
                    dt = VWA4Common.DB.Retrieve("SELECT * FROM UnitsWeight WHERE UniqueName = '" + _sUnitUniqueName + "'");

                if (dt.Rows.Count == 0)
                {
                    if (_nRecordingMethod == 2)
                        AddWarning("No such Volume Units of Measure Unique Name");
                    else
                        AddError("No such Units of Measure Unique Name");
                }
                else if (_nRecordingMethod != 1 && _nRecordingMethod != 3)
                {
                    if (_sUnitDisplayName.Equals(""))
                        _sUnitDisplayName = dt.Rows[0]["DisplayAbbreviatedName"].ToString();
                    else if (!dt.Rows[0]["DisplayAbbreviatedName"].ToString().Equals(_sUnitDisplayName))
                        AddWarning("Units of Measure Unique Name and Units of Measure Display Abbreviated Name does not correspond each other");
                }
            }
            // Check Food Cost AND FoodTypeID consistency
            decimal nFoodCost = GetFoodCost();
            if( _nFoodTypeCost != nFoodCost )
                AddWarning(//VWA4Common.VWACommon.WasteProfile + 
					"Food Type Cost is wrong for this " + //VWA4Common.VWACommon.WasteProfile +
					"Food Type ID!");
            // Check Container Cost, Weight AND ContainerTypeID consistency
            decimal nContainerWeight = 0;
            decimal nContainerCost = GetContainerCost(ref nContainerWeight);
            if( _nContainerCost != nContainerCost )
                AddWarning("Container Cost  is wrong for this Container Type ID!");
            if( _nContainerWeight != nContainerWeight )
                AddWarning("Container Weight  is wrong for this Container Type ID!");
			///************
			///************ SAR - issue debugging 5/22/10
			///************
			///************
			///
			/// Check if( Waste cost calculated right
			decimal totalcost = GetTotalFoodCost();
			if (Math.Abs(_nWasteCost - totalcost ) > Precision)
				AddError("Waste Cost calculation error!\n(_nWasteCost = $" + _nWasteCost.ToString("####0.000")
					+ " ; totalcost = $" + totalcost.ToString("####0.000") + ")");
            // Check Duplicates in ErrorWeights table
            if (this._IsProduced)
                dt = VWA4Common.DB.Retrieve("SELECT * FROM ErrorWeightsProduced " +
                " WHERE LotNumber = '" + _sProducedLotNum + "'", conn, trans);
            else
                dt = VWA4Common.DB.Retrieve("SELECT * FROM ErrorWeights, Transfers  " +
                " WHERE ErrorWeights.TransKey = Transfers.TransKey" +
                " AND ErrorWeights.Timestamp = #" + VWA4Common.VWACommon.DateToString(_dtWeightTimestamp) + "#" +
                " AND Transfers.TermID = '" + _transfer.TermID + "'", conn, trans);
            if (dt.Rows.Count != 0)
                return false;
            return true; 
        }
    }
}

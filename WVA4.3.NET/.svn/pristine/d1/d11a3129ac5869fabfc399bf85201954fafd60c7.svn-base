using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System;

namespace UserControls 
{
    public class WeightStruct
    {
        private decimal foodCost, foodDiscount, weight, containerCost, containerWeight;
        private int nItems;

        public decimal FoodDiscount
        {
            get { return foodDiscount; }
            set { foodDiscount = value; }
        }
        public decimal FoodCost
        { set { foodCost = value; }
          get { return foodCost; } }
        public decimal Weight
        {
            set { weight = value; }
            get { return weight; }
        }
        public decimal ContainerCost
        {
            set { containerCost = value; }
            get { return containerCost; }
        }
        public decimal ContainerWeight
        {
            set { containerWeight = value; }
            get { return containerWeight; }
        }
        public int NItems
        {
            set { nItems = value; }
            get { return nItems; }
        }
		public decimal WasteCost
		{
			get { return (Math.Max(weight - containerWeight * nItems, 0) * foodCost * foodDiscount + containerCost * nItems); }
		}
		public decimal WasteCostManualWtMode
		{
			get { return (Math.Max(weight, 0) * foodCost * foodDiscount + containerCost * nItems); }
		}
		public decimal NetWeight
		{
			get { return (weight - containerWeight * nItems); }
		}
		//public decimal NetWeightManualWtMode
		//{
		//    get { return (weight * nItems); }
		//}
		public WeightStruct(string foodCost, string foodDiscount, string weight, string containerCost, string containerWeight, string nItems)
        {
            this.foodCost           = decimal.Parse(foodCost);
            this.foodDiscount       = decimal.Parse(foodDiscount);
            this.weight             = decimal.Parse(weight);
            this.containerCost      = decimal.Parse(containerCost);
            this.containerWeight    = decimal.Parse(containerWeight);
            this.nItems             = int.Parse(nItems);
        }
        public WeightStruct(decimal foodCost, decimal foodDiscount, decimal weight, decimal containerCost, decimal containerWeight, int nItems)
        {
            this.foodCost = foodCost;
            this.foodDiscount = foodDiscount;
            this.weight = weight;
            this.containerCost = containerCost;
            this.containerWeight = containerWeight;
            this.nItems = nItems;
        }
        public WeightStruct()
        {
            this.foodCost       = 0;
            this.foodDiscount   = 0;
            this.weight         = 0;
            this.containerCost  = 0;
            this.containerWeight = 0;
            this.nItems         = 1;
        }
    }

    public class WeightsData
    {
        private DataSet mvarDataSet = new DataSet();
        private OleDbConnection mvarConnection = new OleDbConnection();

        public WeightsData()
        {
            OleDbConnection connection = VWA4Common.DB.OpenConnection();
            this.Connection = connection;
        }


        public OleDbConnection Connection
        {
            get { return mvarConnection; }
            set { mvarConnection = value; GetTables(); }
        }

        private void GetTables()
        {
            OleDbCommand sc = new OleDbCommand();
            DataTable dt = new DataTable();

            System.Data.DataSet mvarDataSet = new System.Data.DataSet("WeightsData");

            sc.Connection = mvarConnection;

            try
            {
                if (mvarConnection.State != ConnectionState.Open)
                    mvarConnection.Open();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.Message, "");
            }

            //sc.CommandType = CommandType.TableDirect;

            GetTable(sc, "BEOType");
            GetTable(sc, "ContainerType");
            GetTable(sc, "DayPartType");
            GetTable(sc, "DispositionType");
            GetTable(sc, "FoodType");
            GetTable(sc, "LossType");
            GetTable(sc, "StationType");
            GetTable(sc, "UserType");
            GetTable(sc, "Terminals");
            GetTable(sc, "Sites");
            GetTable(sc, "TypeCatalogs");
            GetTable(sc, "Produced");
            GetTable(sc, "UnitsWeight");
            GetTable(sc, "WasteClass");
        }

        private void GetTable(OleDbCommand sc, string TableName)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                if (TableName.Equals("Terminals"))
                    sc.CommandText = "SELECT DISTINCT TermID, TermName FROM Terminals";
                else if (TableName.Equals("Sites"))
                    sc.CommandText = "SELECT DISTINCT ID, LicensedSite FROM Sites";
                else if (TableName.Equals("TypeCatalogs"))
                    sc.CommandText = "SELECT DISTINCT ID, TypeCatalogName FROM TypeCatalogs";
                else if (TableName.Equals("LossType"))
                    sc.CommandText = "SELECT DISTINCT TypeID, TypeName, OverproductionFlag, TrimWasteFlag, HandlingFlag FROM LossType";
                else if (TableName.Equals("Produced"))
                    sc.CommandText = "SELECT DISTINCT ID, LotNumber FROM WeightsProduced";
                else if (TableName.Equals("UnitsWeight"))
                    sc.CommandText = "SELECT DISTINCT UniqueName, DisplayFullName FROM UnitsWeight";
                else if (TableName.Equals("WasteClass"))
                    sc.CommandText = "SELECT DISTINCT UniqueName, DisplayFullName FROM WasteClass";
                else if (TableName.Equals("FoodType"))
                    sc.CommandText = "SELECT DISTINCT TypeID, TypeName, WasteClass FROM FoodType ORDER BY TypeName";
                else
                    sc.CommandText = "SELECT DISTINCT TypeID, TypeName FROM " + TableName + " ORDER BY TypeName";
                da.SelectCommand = sc;
                da.Fill(mvarDataSet, TableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataSet WeightsStatusesHierarchy
        {
            get { return mvarDataSet; }
        }
        public DataTable Terminals
        {
            get { return mvarDataSet.Tables["Terminals"]; }
        }
        public DataTable Sites
        {
            get { return mvarDataSet.Tables["Sites"]; }
        }
        public DataTable TypeCatalogs
        {
            get { return mvarDataSet.Tables["TypeCatalogs"]; }
        }
        
        public DataTable BEOType
        {
            get { return mvarDataSet.Tables["BEOType"]; }
        }

        public DataTable ContainerType
        {
            get { return mvarDataSet.Tables["ContainerType"]; }
        }

        public DataTable DayPartType
        {
            get { return mvarDataSet.Tables["DayPartType"]; }
        }
        public DataTable DispositionType
        {
            get { return mvarDataSet.Tables["DispositionType"]; }
        }
        public DataTable FoodType
        {
            get { return mvarDataSet.Tables["FoodType"]; }
        }
        public DataTable LossType
        {
            get { return mvarDataSet.Tables["LossType"]; }
        }
        public DataTable StationType
        {
            get { return mvarDataSet.Tables["StationType"]; }
        }
        public DataTable UserType
        {
            get { return mvarDataSet.Tables["UserType"]; }
        }
        public DataTable Produced
        {
            get { return mvarDataSet.Tables["Produced"]; }
        }
        public DataTable UnitUniqueName
        {
            get { return mvarDataSet.Tables["UnitsWeight"]; }
        }
        public DataTable WasteClass
        {
            get { return mvarDataSet.Tables["WasteClass"]; }
        }


        public DataSet GetWeights(int numberToReturn)
        {
            return this.GetWeights(numberToReturn, true);
        }

        public DataSet GetWeights(int numberToReturn, bool bOrderBy)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand sc = new OleDbCommand();
            DataSet ds;
            ds = new DataSet();

            sc.Connection = mvarConnection;
            if (mvarConnection.State == ConnectionState.Closed)
                mvarConnection.Open();

            sc.CommandType = CommandType.Text;

            string strSQL;
            strSQL = "SELECT TOP " + numberToReturn + " Weights.ID FROM Weights";
            if (bOrderBy)
                strSQL = strSQL + "\n\r" + "ORDER BY Weights.Timestamp";

            sc.CommandText = strSQL;
            da.SelectCommand = sc;

            //try
            {
                da.Fill(ds);
            }
            //catch
            //{
            //}

            return ds;
        }


        public int GetTypeCatalog(int nWeightID)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand sc = new OleDbCommand();
            DataSet ds = new DataSet();
            sc.Connection = mvarConnection;
            if (mvarConnection.State == ConnectionState.Closed)
                mvarConnection.Open();

            sc.CommandType = CommandType.Text;

            string strSQL = "";

            //   Note: use INNER JOIN, not JOIN (Access-specific?)
            strSQL = "SELECT TypeCatalogID" + "\n\r";
            strSQL = strSQL + "FROM Weights, " + "\n\r";
            strSQL = strSQL + "Transfers " + "\n\r";
            strSQL = strSQL + "WHERE Weights.TransKey = Transfers.TransKey AND Weights.ID = " + nWeightID.ToString();

            sc.CommandText = strSQL;
            da.SelectCommand = sc;

            try
            {
                da.Fill(ds);
            }
            catch(OleDbException e)
            {
                MessageBox.Show(e.Message, "");
            }
            if (ds.Tables[0].Rows[0][0].ToString().Equals(""))
                return 0; // handle master catalog
            return int.Parse(ds.Tables[0].Rows[0][0].ToString());

        }

        public WeightStruct GetFoodCost(int nWeightID, string sFoodTypeID)
        {
            int nTypeCatalog = GetTypeCatalog(nWeightID);
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand sc = new OleDbCommand();
            DataSet ds = new DataSet();
            sc.Connection = mvarConnection;
            if (mvarConnection.State == ConnectionState.Closed)
                mvarConnection.Open();

            sc.CommandType = CommandType.Text;

            string strSQL = "";
            if (nTypeCatalog != 0) // not master
            {
                strSQL = "SELECT FoodCost" + "\n\r";
                strSQL = strSQL + "FROM FoodSubTypes " + "\n\r";
                strSQL = strSQL + "WHERE TypeCatalogID = " + nTypeCatalog.ToString() + " AND TypeID = '" + sFoodTypeID + "'";
                strSQL = strSQL + " AND Enabled = true";
            }
            else {
                strSQL = "SELECT Cost" + "\n\r";
                strSQL = strSQL + "FROM FoodType " + "\n\r";
                strSQL = strSQL + "WHERE TypeID = '" + sFoodTypeID + "'";
            }

            sc.CommandText = strSQL;
            da.SelectCommand = sc;

            try
            {
                da.Fill(ds);
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.Message, "");
            }

            if (ds.Tables[0].Rows.Count < 1)
                return null; // FoodTypeID not found
            WeightStruct weight = new WeightStruct();
            weight.FoodCost = decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
            return weight;

        }

        public WeightStruct GetContainerCost(int nWeightID, string sContainerTypeID)
        {
            int nTypeCatalog = GetTypeCatalog(nWeightID);
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand sc = new OleDbCommand();
            DataSet ds = new DataSet();
            sc.Connection = mvarConnection;
            if (mvarConnection.State == ConnectionState.Closed)
                mvarConnection.Open();

            sc.CommandType = CommandType.Text;

            string strSQL = "";
            if (nTypeCatalog != 0) // not master
            {
                strSQL = "SELECT ContainerCost, ContainerTareWeight" + "\n\r";
                strSQL = strSQL + "FROM ContainerSubTypes " + "\n\r";
                strSQL = strSQL + "WHERE TypeCatalogID = " + nTypeCatalog.ToString() + " AND TypeID = '" + sContainerTypeID + "'";
                strSQL = strSQL + " AND Enabled = true";
            }
            else
            {
                strSQL = "SELECT Cost, TareWeight" + "\n\r";
                strSQL = strSQL + "FROM ContainerType " + "\n\r";
                strSQL = strSQL + "WHERE TypeID = '" + sContainerTypeID + "'";
            }

            sc.CommandText = strSQL;
            da.SelectCommand = sc;

            try
            {
                da.Fill(ds);
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.Message, "");
            }

            if (ds.Tables[0].Rows.Count < 1)
                return null; // FoodTypeID not found
            WeightStruct weight = new WeightStruct();
            weight.ContainerCost = decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
            weight.ContainerWeight = decimal.Parse(ds.Tables[0].Rows[0][1].ToString());
            return weight;
        }

    }	//	end class

}	//	end namespace

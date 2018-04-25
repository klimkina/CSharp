using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public class VWADiscounts
    {
        #region Member Variables

        //private WVAPath m_dbPath; 
        private DataSet m_dsDiscounts;
        private OleDbConnection m_dcDiscounts;
        private OleDbDataAdapter m_daDiscounts;
        private bool m_dbExists = false;

        #endregion Member Variables

        #region Constructor
        
        public VWADiscounts()
        {
            
            try
            {
                CreateConnection();
                CreateDataTable();
                CreateDiscountAdapter();
                this.m_dbExists = true;
            }
            catch (Exception)
            {
                this.m_dbExists = false;
            }
        }
        #endregion Constructor

        internal bool DBExists
        {
            get { return this.m_dbExists; }
        }

        internal DataSet GetDataSet
        {
            get
            {
                if (this.m_dbExists)
                    return this.m_dsDiscounts;

                return null;
            }
        }
        internal DataTable GetDataTable
        {
            get
            {
                if (this.m_dbExists)
                    return this.m_dsDiscounts.Tables["Discounts"];

                return null;
            }
        }


        private void CreateDataTable()
        {
            this.m_dsDiscounts = new DataSet();
            this.m_dsDiscounts.Tables.Add("Discounts");
        }

        public DataSet GetDiscountDetails()
        {
            return this.m_dsDiscounts;
        }
        public DataTable GetDiscountTable()
        {
            if (m_dsDiscounts == null)
            {
                m_dsDiscounts = new DataSet();
                this.CreateDiscountAdapter();
            }
            return this.m_dsDiscounts.Tables["Discounts"];
        }

        private void CreateDiscountAdapter()
        {
            OleDbDataAdapter da = new OleDbDataAdapter();

            this.m_daDiscounts = da;

            try
            {
                da.SelectCommand = new OleDbCommand("SELECT *, 0 as FakeID FROM Discounts", m_dcDiscounts);

                da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[]
                    {
						new System.Data.Common.DataTableMapping("Table", "Discounts", 
						new System.Data.Common.DataColumnMapping[]
						{
							new System.Data.Common.DataColumnMapping("ID", "ID"),
							new System.Data.Common.DataColumnMapping("FoodTypeID", "FoodTypeID"),
							new System.Data.Common.DataColumnMapping("LossTypeID", "LossTypeID"),
							new System.Data.Common.DataColumnMapping("FoodCostDiscount", "FoodCostDiscount")
						}
						)
					}
                    );

                da.Fill(this.m_dsDiscounts, "Discounts");
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in CreateDiscountsAdapter: " + ex.Message, "Project Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }	//	END private void CreateDiscountsAdapter()

        private void CreateConnection()
        {
            try
            {
                this.m_dcDiscounts = new System.Data.OleDb.OleDbConnection(VWA4Common.AppContext.WasteConnectionString);
                this.m_dcDiscounts.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in Create Discounts Connection: " + ex.Message, "Project Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateUpdateCommands()
        {
            this.m_daDiscounts.DeleteCommand = new OleDbCommand(
                    "DELETE FROM Discounts WHERE ID = @ID", this.m_dcDiscounts);
            m_daDiscounts.DeleteCommand.Parameters.Add("@ID", OleDbType.Integer, 40, "ID");

            this.m_daDiscounts.UpdateCommand = new OleDbCommand(
                    "UPDATE Discounts SET Discounts.FoodTypeID = @FoodTypeID, LossTypeID = @LossTypeID, FoodCostDiscount = @FoodCostDiscount " +
                    " WHERE ID = @ID", this.m_dcDiscounts);

            m_daDiscounts.UpdateCommand.Parameters.Add("@FoodTypeID", OleDbType.Char, 20, "FoodTypeID");
            m_daDiscounts.UpdateCommand.Parameters.Add("@LossTypeID", OleDbType.Char, 20, "LossTypeID");
            m_daDiscounts.UpdateCommand.Parameters.Add("@FoodCostDiscount", OleDbType.Decimal, 18, "FoodCostDiscount");
            m_daDiscounts.UpdateCommand.Parameters.Add("@ID", OleDbType.Integer, 40, "ID");

            this.m_daDiscounts.InsertCommand = new OleDbCommand(
                "INSERT INTO Discounts (FoodTypeID, LossTypeID,  FoodCostDiscount) " +
                " VALUES (@FoodTypeID, @LossTypeID, @FoodCostDiscount)",
                this.m_dcDiscounts);

            m_daDiscounts.InsertCommand.Parameters.Add("@FoodTypeID", OleDbType.Char, 20, "FoodTypeID");
            m_daDiscounts.InsertCommand.Parameters.Add("@LossTypeID", OleDbType.Char, 20, "LossTypeID");
            m_daDiscounts.InsertCommand.Parameters.Add("@FoodCostDiscount", OleDbType.Decimal, 18, "FoodCostDiscount");

        }

        public void UpdateData()
        {
            if (DBExists)
            {
                try
                {
                    CreateUpdateCommands();
                    this.m_daDiscounts.Update(this.m_dsDiscounts, "Discounts");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "");
                }
            }
        }

    }
}

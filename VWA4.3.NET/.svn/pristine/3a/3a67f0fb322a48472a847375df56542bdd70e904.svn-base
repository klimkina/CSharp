using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace UserControls
{
    public class VWAWeights
    {
        #region Member Variables

        //private WVAPath m_dbPath; 
        private DataSet m_dsWeightsAndTransfers;
        private DataTable m_dtWeightsProduced;
        private DataTable m_dtErrorWeights;
        private DataTable m_dtErrorWeightsProduced;
        private OleDbConnection m_dcWeights;
        private OleDbDataAdapter m_daTransfers;
        private OleDbDataAdapter m_daWeights;
        private OleDbDataAdapter m_daWeightsProduced;
        private OleDbDataAdapter m_daErrorWeights;
        private OleDbDataAdapter m_daErrorWeightsProduced;
        private bool m_dbExists = false;

        private string _DBPath = "";

        #endregion Member Variables

        #region Constructor
        public VWAWeights() : this("")
        {
        }
        public VWAWeights(string DBPath)
        {
            _DBPath = DBPath;
            if (!VWAPath.DirectoriesFound)
                return;

            try
            {
                CreateConnection();
                CreateDataSet();
                CreateDataAdapters();
                CreateDataRelations();
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
                    return this.m_dsWeightsAndTransfers;

                return null;
            }
        }

        internal string GetRootTable
        {
            get
            {
                return (this.m_dbExists ? "Transfers" : string.Empty);
            }
        }

        private void CreateDataSet()
        {
            this.m_dsWeightsAndTransfers = new DataSet();
            this.m_dtWeightsProduced = new DataTable();
        }

        private void CreateDataRelations()
        {
            DataSet ds = this.m_dsWeightsAndTransfers;

            ds.Relations.Add("Weights", ds.Tables["Transfers"].Columns["TransKey"],
                ds.Tables["Weights"].Columns["TransKey"]);
        }

        public DataSet GetTransfersWeightsDetails()
        {
            return this.m_dsWeightsAndTransfers;
        }
        public DataTable GetWeightsProducedDetails()
        {
            if (m_dtWeightsProduced == null)
            {
                m_dtWeightsProduced = new DataTable();
                this.CreateWeightsProducedAdapter();
            }
            return this.m_dtWeightsProduced;
        }
        public DataTable GetErrorWeightsDetails()
        {
            if (m_dtErrorWeights == null)
            {
                m_dtErrorWeights = new DataTable();
                this.CreateErrorWeightsAdapter();
            }
            return this.m_dtErrorWeights;
        }
        public DataTable GetErrorWeightsProducedDetails()
        {
            if (m_dtErrorWeightsProduced == null)
            {
                m_dtErrorWeightsProduced = new DataTable();
                this.CreateErrorWeightsProducedAdapter();
            }
            return this.m_dtErrorWeightsProduced;
        }
        
        private void CreateDataAdapters()
        {
            this.CreateTransfersAdapter();
            this.CreateWeightsAdapter();
            this.CreateWeightsProducedAdapter();
        }

        private void CreateTransfersAdapter()
        {
            OleDbDataAdapter da = new OleDbDataAdapter();

            this.m_daTransfers = da;

            try
            {
                da.SelectCommand = new OleDbCommand("SELECT * FROM Transfers", m_dcWeights);
                
                da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[]
                    {
						new System.Data.Common.DataTableMapping("Table", "Transfers", 
						new System.Data.Common.DataColumnMapping[]
						{
							new System.Data.Common.DataColumnMapping("TransKey", "TransKey"),
							new System.Data.Common.DataColumnMapping("Timestamp", "Timestamp"),
							new System.Data.Common.DataColumnMapping("TermID", "TermID"),
							new System.Data.Common.DataColumnMapping("TrackerSWVersion", "TrackerSWVersion"),
							new System.Data.Common.DataColumnMapping("SiteID", "SiteID"),
							new System.Data.Common.DataColumnMapping("TypeCatalogID", "TypeCatalogID"),
							new System.Data.Common.DataColumnMapping("IsPrior", "IsPrior")
						}
						)
					}
                    );
                
                da.Fill(this.m_dsWeightsAndTransfers, "Transfers");
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in CreateTransfersAdapter: " + ex.Message, "Project Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }	//	END private void CreateTransfersAdapter()

        private void CreateWeightsAdapter()
        {
            OleDbDataAdapter da = new OleDbDataAdapter();

            this.m_daWeights = da;

            try
            {
                da.SelectCommand =  new OleDbCommand("SELECT Weights.*, Weights.Timestamp AS MyTimestamp, Transfers.TermID, Transfers.Timestamp, " +
                    " TypeCatalogs.ID AS TypeCatalogID, TypeCatalogs.TypeCatalogName AS TypeCatalogName,  Sites.ID AS SiteID, Sites.LicensedSite AS SiteName, " +
                    " ProducedAmount, LossType.OverproductionFlag, LossType.TrimWasteFlag, LossType.HandlingFlag,  " +
                    " WasteClass, " +
                    " Weights.Weight - Weights.ContainerWeight * Weights.NItems AS NetWeight," +
                    " (Weights.Weight - Weights.ContainerWeight * Weights.NItems) * Weights.FoodTypeCost * FoodTypeDiscount + Weights.ContainerCost * Weights.NItems AS TotalWaste" +
                    " FROM (((Weights INNER JOIN (Transfers LEFT OUTER  JOIN (Sites LEFT OUTER  JOIN TypeCatalogs ON Sites.TypeCatalogID = TypeCatalogs.ID)  " +
                    
                    " ON Transfers.SiteID = Sites.ID) ON Weights.TransKey=Transfers.TransKey)   " +
                    " LEFT OUTER  JOIN WeightsProduced ON Weights.ProducedID = WeightsProduced.ID)  " + 
                    " LEFT JOIN LossType ON Weights.LossTypeID=LossType.TypeID) " +
                    " LEFT JOIN FoodType ON Weights.FoodTypeID = FoodType.TypeID ", m_dcWeights); //Use 0, Master for undefined TypeCatalogs
                da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[]
                    {
						new System.Data.Common.DataTableMapping("Table", "Weights", 
						new System.Data.Common.DataColumnMapping[]
						{
							new System.Data.Common.DataColumnMapping("ID", "ID"),
							new System.Data.Common.DataColumnMapping("TransKey", "TransKey"),
							new System.Data.Common.DataColumnMapping("Weights.Timestamp", "Timestamp"),
							new System.Data.Common.DataColumnMapping("IsPreconsumer", "IsPreconsumer"),
                            new System.Data.Common.DataColumnMapping("Weight", "Weight"),
							new System.Data.Common.DataColumnMapping("WasteCost", "WasteCost"),
                            new System.Data.Common.DataColumnMapping("TotalWaste", "TotalWaste"),
							new System.Data.Common.DataColumnMapping("FoodTypeID", "FoodTypeID"),
                            new System.Data.Common.DataColumnMapping("FoodTypeCost", "FoodTypeCost"),
                            new System.Data.Common.DataColumnMapping("FoodTypeDiscount", "FoodTypeDiscount"),
							new System.Data.Common.DataColumnMapping("LossTypeID", "LossTypeID"),
                            new System.Data.Common.DataColumnMapping("ContainerTypeID", "ContainerTypeID"),
							new System.Data.Common.DataColumnMapping("ContainerWeight", "ContainerWeight"),
							new System.Data.Common.DataColumnMapping("ContainerCost", "ContainerCost"),
							new System.Data.Common.DataColumnMapping("StationTypeID", "StationTypeID"),
                            new System.Data.Common.DataColumnMapping("DispositionTypeID", "DispositionTypeID"),
							new System.Data.Common.DataColumnMapping("DaypartTypeID", "DaypartTypeID"),
							new System.Data.Common.DataColumnMapping("BEOTypeID", "BEOTypeID"),
							new System.Data.Common.DataColumnMapping("UserTypeID", "UserTypeID"),
                            new System.Data.Common.DataColumnMapping("UserQuestion", "UserQuestion"),
							new System.Data.Common.DataColumnMapping("NItems", "NItems"),
							new System.Data.Common.DataColumnMapping("IsManualInput", "IsManualInput"),
							new System.Data.Common.DataColumnMapping("IsMemorized", "IsMemorized"),
                            new System.Data.Common.DataColumnMapping("ProducedID", "NProducedID"),
							new System.Data.Common.DataColumnMapping("UnitUniqueName", "UnitUniqueName"),
                            new System.Data.Common.DataColumnMapping("UnitsDisplayName", "UnitsDisplayName"),
                            new System.Data.Common.DataColumnMapping("ProducedAmount", "ProducedAmount"),
                            new System.Data.Common.DataColumnMapping("UnitaryItemWeight", "UnitaryItemWeight"),
                            new System.Data.Common.DataColumnMapping("WasteAmountUserEntry", "WasteAmountUserEntry"),
                            new System.Data.Common.DataColumnMapping("MyTimestamp", "MyTimestamp"),
							new System.Data.Common.DataColumnMapping("TermID", "TermID"),
                            new System.Data.Common.DataColumnMapping("LossType.OverproductionFlag", "OverproductionFlag"),
							new System.Data.Common.DataColumnMapping("LossType.TrimWasteFlag", "TrimWasteFlag"),
							new System.Data.Common.DataColumnMapping("LossType.HandlingFlag", "HandlingFlag"),
                            new System.Data.Common.DataColumnMapping("WasteClass", "WasteClass"),
                            new System.Data.Common.DataColumnMapping("Transfers.Timestamp", "Transfers.Timestamp"),
                            new System.Data.Common.DataColumnMapping("TypeCatalogID", "TypeCatalogID"),
							new System.Data.Common.DataColumnMapping("TypeCatalogs.TypeCatalogName", "TypeCatalogName"),
                            new System.Data.Common.DataColumnMapping("SiteID", "SiteID"),
							new System.Data.Common.DataColumnMapping("SiteName", "SiteName"),
							new System.Data.Common.DataColumnMapping("NetWeight", "NetWeight")
						}
						)
					}
                    );

                da.Fill(this.m_dsWeightsAndTransfers, "Weights");
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in CreateWeightsAdapter: " + ex.Message, "Project Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }	//	END private void CreateWeightsAdapter()

        private void CreateWeightsProducedAdapter()
        {
            OleDbDataAdapter da = new OleDbDataAdapter();

            this.m_daWeightsProduced = da;

            try
            {
                da.SelectCommand = new OleDbCommand("SELECT WeightsProduced.*, WeightsProduced.Timestamp AS MyTimestamp, Transfers.TermID, Transfers.Timestamp, TypeCatalogs.ID AS TypeCatalogID, TypeCatalogs.TypeCatalogName AS TypeCatalogName, " +
                    " Sites.ID AS SiteID, Sites.LicensedSite AS SiteName,  " +
                    " WeightsProduced.Weight - WeightsProduced.ContainerWeight * WeightsProduced.NItems AS NetWeight, WasteClass" +
                    " FROM ((WeightsProduced INNER JOIN (Transfers LEFT OUTER  JOIN (Sites LEFT OUTER  JOIN TypeCatalogs ON Sites.TypeCatalogID = TypeCatalogs.ID)  " +
                    " ON Transfers.SiteID = Sites.ID) ON WeightsProduced.TransKey=Transfers.TransKey))" +
                    " LEFT JOIN FoodType ON WeightsProduced.FoodTypeID = FoodType.TypeID ", m_dcWeights); //Use 0, Master for undefined TypeCatalogs
                da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[]
                    {
						new System.Data.Common.DataTableMapping("Table", "WeightsProduced", 
						new System.Data.Common.DataColumnMapping[]
						{
							new System.Data.Common.DataColumnMapping("ID", "ID"),
							new System.Data.Common.DataColumnMapping("TransKey", "TransKey"),
							new System.Data.Common.DataColumnMapping("WeightsProduced.Timestamp", "Timestamp"),
							new System.Data.Common.DataColumnMapping("LotNumber", "LotNumber"),
                            new System.Data.Common.DataColumnMapping("EOTypeID", "EOTypeID"),
                            new System.Data.Common.DataColumnMapping("Weight", "Weight"),
							new System.Data.Common.DataColumnMapping("WasteCost", "WasteCost"),
							new System.Data.Common.DataColumnMapping("FoodTypeID", "FoodTypeID"),
                            new System.Data.Common.DataColumnMapping("FoodTypeCost", "FoodTypeCost"),
                            new System.Data.Common.DataColumnMapping("ContainerTypeID", "ContainerTypeID"),
							new System.Data.Common.DataColumnMapping("ContainerWeight", "ContainerWeight"),
							new System.Data.Common.DataColumnMapping("ContainerCost", "ContainerCost"),
							new System.Data.Common.DataColumnMapping("StationTypeID", "StationTypeID"),
							new System.Data.Common.DataColumnMapping("DaypartTypeID", "DaypartTypeID"),
							new System.Data.Common.DataColumnMapping("UserTypeID", "UserTypeID"),
                            new System.Data.Common.DataColumnMapping("UserQuestion", "UserQuestion"),
							new System.Data.Common.DataColumnMapping("NItems", "NItems"),
							new System.Data.Common.DataColumnMapping("IsManualInput", "IsManualInput"),
							new System.Data.Common.DataColumnMapping("IsMemorized", "IsMemorized"),
                            new System.Data.Common.DataColumnMapping("UnitUniqueName", "UnitUniqueName"),
                            new System.Data.Common.DataColumnMapping("UnitsDisplayName", "UnitsDisplayName"),
							new System.Data.Common.DataColumnMapping("UnitWeight", "UnitWeight"),
							new System.Data.Common.DataColumnMapping("ProducedAmount", "ProducedAmount"),
                            new System.Data.Common.DataColumnMapping("UnitaryItemWeight", "UnitaryItemWeight"),
                            new System.Data.Common.DataColumnMapping("MyTimestamp", "MyTimestamp"),
							new System.Data.Common.DataColumnMapping("TermID", "TermID"),
                            new System.Data.Common.DataColumnMapping("TypeCatalogID", "TypeCatalogID"),
                            new System.Data.Common.DataColumnMapping("Transfers.Timestamp", "Transfers.Timestamp"),
							new System.Data.Common.DataColumnMapping("TypeCatalogs.TypeCatalogName", "TypeCatalogName"),
                            new System.Data.Common.DataColumnMapping("SiteID", "SiteID"),
							new System.Data.Common.DataColumnMapping("SiteName", "SiteName"),
							new System.Data.Common.DataColumnMapping("NetWeight", "NetWeight"),
                            new System.Data.Common.DataColumnMapping("WasteClass", "WasteClass")
						}
						)
					}
                    );

                da.Fill(this.m_dtWeightsProduced);
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in CreateWeightsProducedAdapter: " + ex.Message, "Project Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }	//	END private void CreateWeightsProducedAdapter()
        private void CreateErrorWeightsAdapter()
        {
            OleDbDataAdapter da = new OleDbDataAdapter();

            this.m_daErrorWeights = da;

            try
            {
                da.SelectCommand = new OleDbCommand("SELECT ErrorWeights.*, ErrorWeights.Timestamp AS MyTimestamp, Transfers.TermID, Transfers.Timestamp, " +
                    " TypeCatalogs.ID AS TypeCatalogID, TypeCatalogs.TypeCatalogName AS TypeCatalogName,  Sites.ID AS SiteID, Sites.LicensedSite AS SiteName, " +
                    " ProducedAmount, LossType.OverproductionFlag, LossType.TrimWasteFlag, LossType.HandlingFlag,  " +
                    " ErrorWeights.Weight - ErrorWeights.ContainerWeight * ErrorWeights.NItems AS NetWeight, WasteClass" +
                    " FROM (((ErrorWeights INNER JOIN (Transfers LEFT OUTER  JOIN (Sites LEFT OUTER  JOIN TypeCatalogs ON Sites.TypeCatalogID = TypeCatalogs.ID)  " +
                    " ON Transfers.SiteID = Sites.ID) ON ErrorWeights.TransKey=Transfers.TransKey)   " +
                    " LEFT OUTER  JOIN WeightsProduced ON ErrorWeights.ProducedID = WeightsProduced.ID)  " +
                    " LEFT JOIN LossType ON ErrorWeights.LossTypeID=LossType.TypeID)" +
                    " LEFT JOIN FoodType ON ErrorWeights.FoodTypeID = FoodType.TypeID ", m_dcWeights); //Use 0, Master for undefined TypeCatalogs
                da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[]
                    {
						new System.Data.Common.DataTableMapping("Table", "ErrorWeights", 
						new System.Data.Common.DataColumnMapping[]
						{
							new System.Data.Common.DataColumnMapping("ID", "ID"),
							new System.Data.Common.DataColumnMapping("TransKey", "TransKey"),
							new System.Data.Common.DataColumnMapping("ErrorWeights.Timestamp", "Timestamp"),
							new System.Data.Common.DataColumnMapping("IsPreconsumer", "IsPreconsumer"),
                            new System.Data.Common.DataColumnMapping("Weight", "Weight"),
							new System.Data.Common.DataColumnMapping("WasteCost", "WasteCost"),
							new System.Data.Common.DataColumnMapping("FoodTypeID", "FoodTypeID"),
                            new System.Data.Common.DataColumnMapping("FoodTypeCost", "FoodTypeCost"),
							new System.Data.Common.DataColumnMapping("LossTypeID", "LossTypeID"),
                            new System.Data.Common.DataColumnMapping("ContainerTypeID", "ContainerTypeID"),
							new System.Data.Common.DataColumnMapping("ContainerWeight", "ContainerWeight"),
							new System.Data.Common.DataColumnMapping("ContainerCost", "ContainerCost"),
							new System.Data.Common.DataColumnMapping("StationTypeID", "StationTypeID"),
                            new System.Data.Common.DataColumnMapping("DispositionTypeID", "DispositionTypeID"),
							new System.Data.Common.DataColumnMapping("DaypartTypeID", "DaypartTypeID"),
							new System.Data.Common.DataColumnMapping("BEOTypeID", "BEOTypeID"),
							new System.Data.Common.DataColumnMapping("UserTypeID", "UserTypeID"),
                            new System.Data.Common.DataColumnMapping("UserQuestion", "UserQuestion"),
							new System.Data.Common.DataColumnMapping("NItems", "NItems"),
							new System.Data.Common.DataColumnMapping("IsManualInput", "IsManualInput"),
							new System.Data.Common.DataColumnMapping("IsMemorized", "IsMemorized"),
                            new System.Data.Common.DataColumnMapping("ProducedID", "NProducedID"),
							new System.Data.Common.DataColumnMapping("UnitUniqueName", "UnitUniqueName"),
                            new System.Data.Common.DataColumnMapping("UnitsDisplayName", "UnitsDisplayName"),
                            new System.Data.Common.DataColumnMapping("Error", "Error"),
                            new System.Data.Common.DataColumnMapping("ProducedAmount", "ProducedAmount"),
                            new System.Data.Common.DataColumnMapping("UnitaryItemWeight", "UnitaryItemWeight"),
                            new System.Data.Common.DataColumnMapping("WasteAmountUserEntry", "WasteAmountUserEntry"),
                            new System.Data.Common.DataColumnMapping("MyTimestamp", "MyTimestamp"),
							new System.Data.Common.DataColumnMapping("TermID", "TermID"),
                            new System.Data.Common.DataColumnMapping("LossType.OverproductionFlag", "OverproductionFlag"),
							new System.Data.Common.DataColumnMapping("LossType.TrimWasteFlag", "TrimWasteFlag"),
							new System.Data.Common.DataColumnMapping("LossType.HandlingFlag", "HandlingFlag"),
                            new System.Data.Common.DataColumnMapping("Transfers.Timestamp", "Transfers.Timestamp"),
                            new System.Data.Common.DataColumnMapping("TypeCatalogID", "TypeCatalogID"),
							new System.Data.Common.DataColumnMapping("TypeCatalogs.TypeCatalogName", "TypeCatalogName"),
                            new System.Data.Common.DataColumnMapping("SiteID", "SiteID"),
							new System.Data.Common.DataColumnMapping("SiteName", "SiteName"),
							new System.Data.Common.DataColumnMapping("NetWeight", "NetWeight"),
                            new System.Data.Common.DataColumnMapping("WasteClass", "WasteClass")
						}
						)
					}
                    );

                da.Fill(this.m_dtErrorWeights);
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in CreateErrorWeightsAdapter: " + ex.Message, "Project Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }	//	END private void CreateErrorWeightsAdapter()
        private void CreateErrorWeightsProducedAdapter()
        {
            OleDbDataAdapter da = new OleDbDataAdapter();

            this.m_daErrorWeightsProduced = da;

            try
            {
                da.SelectCommand = new OleDbCommand("SELECT ErrorWeightsProduced.*, ErrorWeightsProduced.Timestamp AS MyTimestamp, Transfers.TermID, Transfers.Timestamp, TypeCatalogs.ID AS TypeCatalogID, TypeCatalogs.TypeCatalogName AS TypeCatalogName, " +
                    " Sites.ID AS SiteID, Sites.LicensedSite AS SiteName,  " +
                    " ErrorWeightsProduced.Weight - ErrorWeightsProduced.ContainerWeight * ErrorWeightsProduced.NItems AS NetWeight, WasteClass" +
                    " FROM ((ErrorWeightsProduced INNER JOIN (Transfers LEFT OUTER  JOIN (Sites LEFT OUTER  JOIN TypeCatalogs ON Sites.TypeCatalogID = TypeCatalogs.ID)  " +
                    " ON Transfers.SiteID = Sites.ID) ON ErrorWeightsProduced.TransKey=Transfers.TransKey))" +
                    " LEFT JOIN FoodType ON ErrorWeightsProduced.FoodTypeID = FoodType.TypeID ", m_dcWeights); //Use 0, Master for undefined TypeCatalogs
                da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[]
                    {
						new System.Data.Common.DataTableMapping("Table", "ErrorWeightsProduced", 
						new System.Data.Common.DataColumnMapping[]
						{
							new System.Data.Common.DataColumnMapping("ID", "ID"),
							new System.Data.Common.DataColumnMapping("TransKey", "TransKey"),
							new System.Data.Common.DataColumnMapping("ErrorWeightsProduced.Timestamp", "Timestamp"),
							new System.Data.Common.DataColumnMapping("LotNumber", "LotNumber"),
                            new System.Data.Common.DataColumnMapping("EOTypeID", "EOTypeID"),
                            new System.Data.Common.DataColumnMapping("Weight", "Weight"),
							new System.Data.Common.DataColumnMapping("WasteCost", "WasteCost"),
							new System.Data.Common.DataColumnMapping("FoodTypeID", "FoodTypeID"),
                            new System.Data.Common.DataColumnMapping("FoodTypeCost", "FoodTypeCost"),
                            new System.Data.Common.DataColumnMapping("ContainerTypeID", "ContainerTypeID"),
							new System.Data.Common.DataColumnMapping("ContainerWeight", "ContainerWeight"),
							new System.Data.Common.DataColumnMapping("ContainerCost", "ContainerCost"),
							new System.Data.Common.DataColumnMapping("StationTypeID", "StationTypeID"),
							new System.Data.Common.DataColumnMapping("DaypartTypeID", "DaypartTypeID"),
							new System.Data.Common.DataColumnMapping("UserTypeID", "UserTypeID"),
                            new System.Data.Common.DataColumnMapping("UserQuestion", "UserQuestion"),
							new System.Data.Common.DataColumnMapping("NItems", "NItems"),
							new System.Data.Common.DataColumnMapping("IsManualInput", "IsManualInput"),
							new System.Data.Common.DataColumnMapping("IsMemorized", "IsMemorized"),
                            new System.Data.Common.DataColumnMapping("UnitUniqueName", "UnitUniqueName"),
                            new System.Data.Common.DataColumnMapping("UnitsDisplayName", "UnitsDisplayName"),
							new System.Data.Common.DataColumnMapping("UnitWeight", "UnitWeight"),
							new System.Data.Common.DataColumnMapping("ProducedAmount", "ProducedAmount"),
                            new System.Data.Common.DataColumnMapping("UnitaryItemWeight", "UnitaryItemWeight"),
                            new System.Data.Common.DataColumnMapping("MyTimestamp", "MyTimestamp"),
							new System.Data.Common.DataColumnMapping("TermID", "TermID"),
                            new System.Data.Common.DataColumnMapping("TypeCatalogID", "TypeCatalogID"),
                            new System.Data.Common.DataColumnMapping("Transfers.Timestamp", "Transfers.Timestamp"),
							new System.Data.Common.DataColumnMapping("TypeCatalogs.TypeCatalogName", "TypeCatalogName"),
                            new System.Data.Common.DataColumnMapping("SiteID", "SiteID"),
							new System.Data.Common.DataColumnMapping("SiteName", "SiteName"),
							new System.Data.Common.DataColumnMapping("Error", "Error"),
							new System.Data.Common.DataColumnMapping("NetWeight", "NetWeight"),
                            new System.Data.Common.DataColumnMapping("WasteClass", "WasteClass")
						}
						)
					}
                    );

                da.Fill(this.m_dtErrorWeightsProduced);
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Error in CreateErrorWeightsProducedAdapter: " + ex.Message, "Project Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }	//	END private void CreateErrorWeightsProducedAdapter()

        private void CreateConnection()
        {
            if (_DBPath == "")
                _DBPath = VWA4Common.AppContext.WasteConnectionString;
            this.m_dcWeights = new System.Data.OleDb.OleDbConnection(VWA4Common.VWACommon.GetConnectionString(_DBPath));
        }

        private void CreateUpdateCommands()
        {
            this.m_daTransfers.DeleteCommand = new OleDbCommand(
                    "DELETE FROM Transfers WHERE TransKey = @TransKey", this.m_dcWeights);
            m_daTransfers.DeleteCommand.Parameters.Add("@TransKey", OleDbType.Integer, 40, "TransKey");
            
            this.m_daTransfers.UpdateCommand = new OleDbCommand(
                    "UPDATE Transfers SET Transfers.Timestamp = @Timestamp, TermID = @TermID, TrackerSWVersion = @TrackerSWVersion, SiteID = @SiteID, " +
                    "TypeCatalogID = @TypeCatalogID, IsPrior = @IsPrior WHERE TransKey = @TransKey", this.m_dcWeights);

            m_daTransfers.UpdateCommand.Parameters.Add("@Timestamp", OleDbType.DBTimeStamp, 22, "Timestamp");
            m_daTransfers.UpdateCommand.Parameters.Add("@TermID", OleDbType.VarChar, 255, "TermID");
            m_daTransfers.UpdateCommand.Parameters.Add("@TrackerSWVersion", OleDbType.Char, 12, "TrackerSWVersion");
            m_daTransfers.UpdateCommand.Parameters.Add("@SiteID", OleDbType.Integer, 40, "SiteID");
            m_daTransfers.UpdateCommand.Parameters.Add("@TypeCatalogID", OleDbType.Integer, 40, "TypeCatalogID");
            m_daTransfers.UpdateCommand.Parameters.Add("@IsPrior", OleDbType.Boolean, 1, "IsPrior");
            m_daTransfers.UpdateCommand.Parameters.Add("@TransKey", OleDbType.Integer, 40, "TransKey");

            this.m_daWeights.DeleteCommand = new OleDbCommand("DELETE FROM Weights WHERE ID = @ID", this.m_dcWeights);
            m_daWeights.DeleteCommand.Parameters.Add("@ID", OleDbType.Integer, 40, "ID");

            this.m_daWeights.UpdateCommand = new OleDbCommand(
                "UPDATE Weights SET TransKey = @TransKey, Weights.Timestamp = @Timestamp,  " +
                " IsPreconsumer = @IsPreconsumer, Weight = @Weight, WasteCost = @WasteCost, " +
                " FoodTypeID = @FoodTypeID, FoodTypeCost = @FoodTypeCost, LossTypeID = @LossTypeID, ContainerTypeID = @ContainerTypeID, " +
                " ContainerWeight = @ContainerWeight, ContainerCost = @ContainerCost, StationTypeID = @StationTypeID, " +
                " DispositionTypeID = @DispositionTypeID, DaypartTypeID = @DaypartTypeID, BEOTypeID = @BEOTypeID, " +
                " UserTypeID = @UserTypeID, UserQuestion = @UserQuestion, NItems = @NItems, IsManualInput = @IsManualInput, " +
                " IsMemorized = @IsMemorized, ProducedID = @ProducedID, UnitUniqueName = @UnitUniqueName, " +
                " UnitaryItemWeight = @UnitaryItemWeight, WasteAmountUserEntry = @WasteAmountUserEntry, UnitsDisplayName = @UnitsDisplayName WHERE ID = @ID", this.m_dcWeights);

            m_daWeights.UpdateCommand.Parameters.Add("@TransKey", OleDbType.Integer, 40, "TransKey");
            m_daWeights.UpdateCommand.Parameters.Add("@Timestamp", OleDbType.DBTimeStamp, 22, "MyTimestamp");
            m_daWeights.UpdateCommand.Parameters.Add("@IsPreconsumer", OleDbType.Integer, 40, "IsPreconsumer");
            m_daWeights.UpdateCommand.Parameters.Add("@Weight", OleDbType.Decimal, 40, "Weight");
            m_daWeights.UpdateCommand.Parameters.Add("@WasteCost", OleDbType.Currency, 40, "WasteCost");
            m_daWeights.UpdateCommand.Parameters.Add("@FoodTypeID", OleDbType.VarChar, 255, "FoodTypeID");
            m_daWeights.UpdateCommand.Parameters.Add("@FoodTypeCost", OleDbType.Currency, 40, "FoodTypeCost");
            m_daWeights.UpdateCommand.Parameters.Add("@LossTypeID", OleDbType.VarChar, 255, "LossTypeID");
            m_daWeights.UpdateCommand.Parameters.Add("@ContainerTypeID", OleDbType.VarChar, 255, "ContainerTypeID");
            m_daWeights.UpdateCommand.Parameters.Add("@ContainerWeight", OleDbType.Decimal, 40, "ContainerWeight");
            m_daWeights.UpdateCommand.Parameters.Add("@ContainerCost", OleDbType.Currency, 40, "ContainerCost");
            m_daWeights.UpdateCommand.Parameters.Add("@StationTypeID", OleDbType.VarChar, 255, "StationTypeID");
            m_daWeights.UpdateCommand.Parameters.Add("@DispositionTypeID", OleDbType.VarChar, 255, "DispositionTypeID");
            m_daWeights.UpdateCommand.Parameters.Add("@DaypartTypeID", OleDbType.VarChar, 255, "DaypartTypeID");
            m_daWeights.UpdateCommand.Parameters.Add("@BEOTypeID", OleDbType.VarChar, 255, "BEOTypeID");
            m_daWeights.UpdateCommand.Parameters.Add("@UserTypeID", OleDbType.VarChar, 255, "UserTypeID");
            m_daWeights.UpdateCommand.Parameters.Add("@UserQuestion", OleDbType.VarChar, 255, "UserQuestion");
            m_daWeights.UpdateCommand.Parameters.Add("@NItems", OleDbType.Integer, 40, "NItems");
            m_daWeights.UpdateCommand.Parameters.Add("@IsManualInput", OleDbType.Boolean, 1, "IsManualInput");
            m_daWeights.UpdateCommand.Parameters.Add("@IsMemorized", OleDbType.Integer, 40, "IsMemorized");
            m_daWeights.UpdateCommand.Parameters.Add("@ProducedID", OleDbType.Integer, 40, "ProducedID");
            m_daWeights.UpdateCommand.Parameters.Add("@UnitUniqueName", OleDbType.VarChar, 50, "UnitUniqueName");
            m_daWeights.UpdateCommand.Parameters.Add("@UnitaryItemWeight", OleDbType.Integer, 40, "UnitaryItemWeight");
            m_daWeights.UpdateCommand.Parameters.Add("@WasteAmountUserEntry", OleDbType.Decimal, 40, "WasteAmountUserEntry");
            m_daWeights.UpdateCommand.Parameters.Add("@UnitsDisplayName", OleDbType.VarChar, 50, "UnitsDisplayName");
            m_daWeights.UpdateCommand.Parameters.Add("ID", OleDbType.Integer, 40, "ID");

            this.m_daWeights.InsertCommand = new OleDbCommand(
                "INSERT INTO Weights (TransKey, Timestamp,  IsPreconsumer, Weight, WasteCost, " +
                " FoodTypeID, FoodTypeCost, LossTypeID, ContainerTypeID, ContainerWeight, ContainerCost, StationTypeID, " +
                " DispositionTypeID, DaypartTypeID, BEOTypeID, UserTypeID, UserQuestion, NItems, IsManualInput, " +
                " IsMemorized, ProducedID, UnitUniqueName, UnitaryItemWeight, WasteAmountUserEntry) " +
                " VALUES (@TransKey, @Timestamp, @IsPreconsumer, @Weight, @WasteCost, @FoodTypeID, @FoodTypeCost, @LossTypeID, @ContainerTypeID, " +
                " @ContainerWeight, @ContainerCost, @StationTypeID, @DispositionTypeID, @DaypartTypeID, @BEOTypeID, " +
                " @UserTypeID, @UserQuestion, @NItems, @IsManualInput, @IsMemorized, @ProducedID, @UnitUniqueName, @UnitaryItemWeight, " +
                " @WasteAmountUserEntry, UnitsDisplayName = @UnitsDisplayName)", 
                this.m_dcWeights);

            m_daWeights.InsertCommand.Parameters.Add("@TransKey", OleDbType.Integer, 40, "TransKey");
            m_daWeights.InsertCommand.Parameters.Add("@Timestamp", OleDbType.DBTimeStamp, 22, "MyTimestamp");
            m_daWeights.InsertCommand.Parameters.Add("@IsPreconsumer", OleDbType.Integer, 40, "IsPreconsumer");
            m_daWeights.InsertCommand.Parameters.Add("@Weight", OleDbType.Decimal, 40, "Weight");
            m_daWeights.InsertCommand.Parameters.Add("@WasteCost", OleDbType.Currency, 40, "WasteCost");
            m_daWeights.InsertCommand.Parameters.Add("@FoodTypeID", OleDbType.VarChar, 255, "FoodTypeID");
            m_daWeights.InsertCommand.Parameters.Add("@FoodTypeCost", OleDbType.Currency, 40, "FoodTypeCost");
            m_daWeights.InsertCommand.Parameters.Add("@LossTypeID", OleDbType.VarChar, 255, "LossTypeID");
            m_daWeights.InsertCommand.Parameters.Add("@ContainerTypeID", OleDbType.VarChar, 255, "ContainerTypeID");
            m_daWeights.InsertCommand.Parameters.Add("@ContainerWeight", OleDbType.Decimal, 40, "ContainerWeight");
            m_daWeights.InsertCommand.Parameters.Add("@ContainerCost", OleDbType.Currency, 40, "ContainerCost");
            m_daWeights.InsertCommand.Parameters.Add("@StationTypeID", OleDbType.VarChar, 255, "StationTypeID");
            m_daWeights.InsertCommand.Parameters.Add("@DispositionTypeID", OleDbType.VarChar, 255, "DispositionTypeID");
            m_daWeights.InsertCommand.Parameters.Add("@DaypartTypeID", OleDbType.VarChar, 255, "DaypartTypeID");
            m_daWeights.InsertCommand.Parameters.Add("@BEOTypeID", OleDbType.VarChar, 255, "BEOTypeID");
            m_daWeights.InsertCommand.Parameters.Add("@UserTypeID", OleDbType.VarChar, 255, "UserTypeID");
            m_daWeights.InsertCommand.Parameters.Add("@UserQuestion", OleDbType.VarChar, 255, "UserQuestion");
            m_daWeights.InsertCommand.Parameters.Add("@NItems", OleDbType.Integer, 40, "NItems");
            m_daWeights.InsertCommand.Parameters.Add("@IsManualInput", OleDbType.Boolean, 1, "IsManualInput");
            m_daWeights.InsertCommand.Parameters.Add("@IsMemorized", OleDbType.Integer, 40, "IsMemorized");
            m_daWeights.InsertCommand.Parameters.Add("@ProducedID", OleDbType.Integer, 40, "ProducedID");
            m_daWeights.InsertCommand.Parameters.Add("@UnitUniqueName", OleDbType.VarChar, 50, "UnitUniqueName");
            m_daWeights.InsertCommand.Parameters.Add("@UnitaryItemWeight", OleDbType.Integer, 40, "UnitaryItemWeight");
            m_daWeights.InsertCommand.Parameters.Add("@WasteAmountUserEntry", OleDbType.Decimal, 40, "WasteAmountUserEntry");
            m_daWeights.InsertCommand.Parameters.Add("@UnitsDisplayName", OleDbType.VarChar, 50, "UnitsDisplayName");
            m_daWeights.InsertCommand.Parameters.Add("ID", OleDbType.Integer, 40, "ID");

            if (this.m_daWeightsProduced != null)
            {
                this.m_daWeightsProduced.DeleteCommand = new OleDbCommand("DELETE FROM WeightsProduced WHERE ID = @ID", this.m_dcWeights);
                m_daWeightsProduced.DeleteCommand.Parameters.Add("@ID", OleDbType.Integer, 40, "ID");
                this.m_daWeightsProduced.UpdateCommand = new OleDbCommand(
                    "UPDATE WeightsProduced SET TransKey = @TransKey, WeightsProduced.Timestamp = @Timestamp,  " +
                    " LotNumber = @LotNumber, EOTypeID = @EOTypeID, Weight = @Weight, FoodCost = @FoodCost, " +
                    " FoodTypeID = @FoodTypeID, FoodTypeCost = @FoodTypeCost, ContainerTypeID = @ContainerTypeID, " +
                    " ContainerWeight = @ContainerWeight, ContainerCost = @ContainerCost, StationTypeID = @StationTypeID, " +
                    " DaypartTypeID = @DaypartTypeID, " +
                    " UserTypeID = @UserTypeID, UserQuestion = @UserQuestion, NItems = @NItems, IsManualInput = @IsManualInput, " +
                    " IsMemorized = @IsMemorized, UnitUniqueName = @UnitUniqueName, UnitWeight = @UnitWeight, ProducedAmount = @ProducedAmount, " +
                    " UnitaryItemWeight = @UnitaryItemWeight, UnitsDisplayName = @UnitsDisplayName WHERE ID = @ID", this.m_dcWeights);

                m_daWeightsProduced.UpdateCommand.Parameters.Add("@TransKey", OleDbType.Integer, 40, "TransKey");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@Timestamp", OleDbType.DBTimeStamp, 22, "MyTimestamp");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@LotNumber", OleDbType.VarChar, 50, "LotNumber");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@EOTypeID", OleDbType.VarChar, 255, "EOTypeID");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@Weight", OleDbType.Decimal, 40, "Weight");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@FoodCost", OleDbType.Currency, 40, "FoodCost");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@FoodTypeID", OleDbType.VarChar, 255, "FoodTypeID");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@FoodTypeCost", OleDbType.Currency, 40, "FoodTypeCost");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@ContainerTypeID", OleDbType.VarChar, 255, "ContainerTypeID");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@ContainerWeight", OleDbType.Decimal, 40, "ContainerWeight");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@ContainerCost", OleDbType.Currency, 40, "ContainerCost");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@StationTypeID", OleDbType.VarChar, 255, "StationTypeID");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@DaypartTypeID", OleDbType.VarChar, 255, "DaypartTypeID");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@UserTypeID", OleDbType.VarChar, 255, "UserTypeID");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@UserQuestion", OleDbType.VarChar, 255, "UserQuestion");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@NItems", OleDbType.Integer, 40, "NItems");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@IsManualInput", OleDbType.Boolean, 1, "IsManualInput");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@IsMemorized", OleDbType.Integer, 40, "IsMemorized");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@UnitUniqueName", OleDbType.VarChar, 50, "UnitUniqueName");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@UnitWeight", OleDbType.Integer, 40, "UnitWeight");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@ProducedAmount", OleDbType.Decimal, 40, "ProducedAmount");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@UnitaryItemWeight", OleDbType.Integer, 40, "UnitaryItemWeight");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("@UnitsDisplayName", OleDbType.VarChar, 50, "UnitsDisplayName");
                m_daWeightsProduced.UpdateCommand.Parameters.Add("ID", OleDbType.Integer, 40, "ID");

                this.m_daWeightsProduced.InsertCommand = new OleDbCommand(
                    "INSERT INTO WeightsProduced (TransKey, [Timestamp],  " +
                    " LotNumber, EOTypeID, Weight, FoodCost,  FoodTypeID, FoodTypeCost, ContainerTypeID, " +
                    " ContainerWeight, ContainerCost, StationTypeID,  DaypartTypeID, " +
                    " UserTypeID, UserQuestion, NItems, IsManualInput, IsMemorized, UnitUniqueName, UnitWeight, ProducedAmount, UnitaryItemWeight) " +
                    " VALUES( @TransKey, @Timestamp, @LotNumber, @EOTypeID, @Weight, @FoodCost, " +
                    " @FoodTypeID, @FoodTypeCost, @ContainerTypeID, @ContainerWeight, @ContainerCost, @StationTypeID, " +
                    " @DaypartTypeID, @UserTypeID, @UserQuestion, @NItems, @IsManualInput, " +
                    " @IsMemorized, @UnitUniqueName, @UnitWeight, @ProducedAmount, @UnitaryItemWeight, UnitsDisplayName = @UnitsDisplayName)", this.m_dcWeights);

                m_daWeightsProduced.InsertCommand.Parameters.Add("@TransKey", OleDbType.Integer, 40, "TransKey");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@Timestamp", OleDbType.DBTimeStamp, 22, "MyTimestamp");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@LotNumber", OleDbType.VarChar, 50, "LotNumber");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@EOTypeID", OleDbType.VarChar, 255, "EOTypeID");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@Weight", OleDbType.Decimal, 40, "Weight");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@FoodCost", OleDbType.Currency, 40, "FoodCost");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@FoodTypeID", OleDbType.VarChar, 255, "FoodTypeID");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@FoodTypeCost", OleDbType.Currency, 40, "FoodTypeCost");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@ContainerTypeID", OleDbType.VarChar, 255, "ContainerTypeID");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@ContainerWeight", OleDbType.Decimal, 40, "ContainerWeight");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@ContainerCost", OleDbType.Currency, 40, "ContainerCost");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@StationTypeID", OleDbType.VarChar, 255, "StationTypeID");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@DaypartTypeID", OleDbType.VarChar, 255, "DaypartTypeID");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@UserTypeID", OleDbType.VarChar, 255, "UserTypeID");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@UserQuestion", OleDbType.VarChar, 255, "UserQuestion");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@NItems", OleDbType.Integer, 40, "NItems");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@IsManualInput", OleDbType.Boolean, 1, "IsManualInput");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@IsMemorized", OleDbType.Integer, 40, "IsMemorized");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@UnitUniqueName", OleDbType.VarChar, 50, "UnitUniqueName");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@UnitWeight", OleDbType.Integer, 40, "UnitWeight");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@ProducedAmount", OleDbType.Decimal, 40, "ProducedAmount");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@UnitaryItemWeight", OleDbType.Integer, 40, "UnitaryItemWeight");
                m_daWeightsProduced.InsertCommand.Parameters.Add("@UnitsDisplayName", OleDbType.VarChar, 50, "UnitsDisplayName");
                m_daWeightsProduced.InsertCommand.Parameters.Add("ID", OleDbType.Integer, 40, "ID");
            }
            if (this.m_daErrorWeights != null)
            {
                this.m_daErrorWeights.DeleteCommand = new OleDbCommand("DELETE FROM ErrorWeights WHERE ID = @ID", this.m_dcWeights);
                m_daErrorWeights.DeleteCommand.Parameters.Add("@ID", OleDbType.Integer, 40, "ID");
                this.m_daErrorWeights.UpdateCommand = new OleDbCommand(
                    "UPDATE WeightsError SET TransKey = @TransKey, WeightsError.Timestamp = @Timestamp,  " +
                    " IsPreconsumer = @IsPreconsumer, Weight = @Weight, WasteCost = @WasteCost, " +
                    " FoodTypeID = @FoodTypeID, FoodTypeCost = @FoodTypeCost, LossTypeID = @LossTypeID, ContainerTypeID = @ContainerTypeID, " +
                    " ContainerWeight = @ContainerWeight, ContainerCost = @ContainerCost, StationTypeID = @StationTypeID, " +
                    " DispositionTypeID = @DispositionTypeID, DaypartTypeID = @DaypartTypeID, BEOTypeID = @BEOTypeID, " +
                    " UserTypeID = @UserTypeID, UserQuestion = @UserQuestion, NItems = @NItems, IsManualInput = @IsManualInput, " +
                    " IsMemorized = @IsMemorized, ProducedID = @ProducedID, UnitUniqueName = @UnitUniqueName, " +
                    " UnitaryItemWeight = @UnitaryItemWeight, WasteAmountUserEntry = @WasteAmountUserEntry, UnitsDisplayName = @UnitsDisplayName, Error = @Error WHERE ID = @ID", this.m_dcWeights);

                m_daErrorWeights.UpdateCommand.Parameters.Add("@TransKey", OleDbType.Integer, 40, "TransKey");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@Timestamp", OleDbType.DBTimeStamp, 22, "MyTimestamp");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@IsPreconsumer", OleDbType.Integer, 40, "IsPreconsumer");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@Weight", OleDbType.Decimal, 40, "Weight");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@WasteCost", OleDbType.Currency, 40, "WasteCost");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@FoodTypeID", OleDbType.VarChar, 255, "FoodTypeID");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@FoodTypeCost", OleDbType.Currency, 40, "FoodTypeCost");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@LossTypeID", OleDbType.VarChar, 255, "LossTypeID");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@ContainerTypeID", OleDbType.VarChar, 255, "ContainerTypeID");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@ContainerWeight", OleDbType.Decimal, 40, "ContainerWeight");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@ContainerCost", OleDbType.Currency, 40, "ContainerCost");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@StationTypeID", OleDbType.VarChar, 255, "StationTypeID");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@DispositionTypeID", OleDbType.VarChar, 255, "DispositionTypeID");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@DaypartTypeID", OleDbType.VarChar, 255, "DaypartTypeID");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@BEOTypeID", OleDbType.VarChar, 255, "BEOTypeID");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@UserTypeID", OleDbType.VarChar, 255, "UserTypeID");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@UserQuestion", OleDbType.VarChar, 255, "UserQuestion");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@NItems", OleDbType.Integer, 40, "NItems");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@IsManualInput", OleDbType.Boolean, 1, "IsManualInput");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@IsMemorized", OleDbType.Integer, 40, "IsMemorized");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@ProducedID", OleDbType.Integer, 40, "ProducedID");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@UnitUniqueName", OleDbType.VarChar, 50, "UnitUniqueName");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@UnitaryItemWeight", OleDbType.Integer, 40, "UnitaryItemWeight");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@WasteAmountUserEntry", OleDbType.Decimal, 40, "WasteAmountUserEntry");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@UnitsDisplayName", OleDbType.VarChar, 50, "UnitsDisplayName");
                m_daErrorWeights.UpdateCommand.Parameters.Add("@Error", OleDbType.VarChar, 255, "Error");
                m_daErrorWeights.UpdateCommand.Parameters.Add("ID", OleDbType.Integer, 40, "ID");
            }
            if (this.m_daErrorWeightsProduced != null)
            {
                this.m_daErrorWeightsProduced.DeleteCommand = new OleDbCommand("DELETE FROM ErrorWeightsProduced WHERE ID = @ID", this.m_dcWeights);
                m_daErrorWeightsProduced.DeleteCommand.Parameters.Add("@ID", OleDbType.Integer, 40, "ID");

                this.m_daErrorWeightsProduced.UpdateCommand = new OleDbCommand(
                    "UPDATE ErrorWeightsProduced SET TransKey = @TransKey, ErrorWeightsProduced.Timestamp = @Timestamp,  " +
                    " LotNumber = @LotNumber, EOTypeID = @EOTypeID, Weight = @Weight, FoodCost = @FoodCost, " +
                    " FoodTypeID = @FoodTypeID, FoodTypeCost = @FoodTypeCost, ContainerTypeID = @ContainerTypeID, " +
                    " ContainerWeight = @ContainerWeight, ContainerCost = @ContainerCost, StationTypeID = @StationTypeID, " +
                    " DaypartTypeID = @DaypartTypeID, " +
                    " UserTypeID = @UserTypeID, UserQuestion = @UserQuestion, NItems = @NItems, IsManualInput = @IsManualInput, " +
                    " IsMemorized = @IsMemorized, UnitUniqueName = @UnitUniqueName, UnitWeight = @UnitWeight, ProducedAmount = @ProducedAmount, " +
                    " UnitaryItemWeight = @UnitaryItemWeight, UnitsDisplayName = @UnitsDisplayName, Error = @Error WHERE ID = @ID", this.m_dcWeights);

                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@TransKey", OleDbType.Integer, 40, "TransKey");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@Timestamp", OleDbType.DBTimeStamp, 22, "MyTimestamp");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@LotNumber", OleDbType.VarChar, 50, "LotNumber");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@EOTypeID", OleDbType.VarChar, 255, "EOTypeID");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@Weight", OleDbType.Decimal, 40, "Weight");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@FoodCost", OleDbType.Currency, 40, "FoodCost");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@FoodTypeID", OleDbType.VarChar, 255, "FoodTypeID");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@FoodTypeCost", OleDbType.Currency, 40, "FoodTypeCost");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@ContainerTypeID", OleDbType.VarChar, 255, "ContainerTypeID");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@ContainerWeight", OleDbType.Decimal, 40, "ContainerWeight");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@ContainerCost", OleDbType.Currency, 40, "ContainerCost");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@StationTypeID", OleDbType.VarChar, 255, "StationTypeID");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@DaypartTypeID", OleDbType.VarChar, 255, "DaypartTypeID");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@UserTypeID", OleDbType.VarChar, 255, "UserTypeID");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@UserQuestion", OleDbType.VarChar, 255, "UserQuestion");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@NItems", OleDbType.Integer, 40, "NItems");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@IsManualInput", OleDbType.Boolean, 1, "IsManualInput");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@IsMemorized", OleDbType.Integer, 40, "IsMemorized");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@UnitUniqueName", OleDbType.VarChar, 50, "UnitUniqueName");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@UnitWeight", OleDbType.Integer, 40, "UnitWeight");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@ProducedAmount", OleDbType.Decimal, 40, "ProducedAmount");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@UnitaryItemWeight", OleDbType.Integer, 40, "UnitaryItemWeight");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@UnitsDisplayName", OleDbType.VarChar, 50, "UnitsDisplayName");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("@Error", OleDbType.VarChar, 255, "Error");
                m_daErrorWeightsProduced.UpdateCommand.Parameters.Add("ID", OleDbType.Integer, 40, "ID");
            }
        }

        public void UpdateData()
        {
            if (DBExists)
            {
                try
                {
                    CreateUpdateCommands();
                    if (m_dtErrorWeights != null || m_dtErrorWeightsProduced != null) //errors
                        CheckErrors();
                    this.m_daTransfers.Update(this.m_dsWeightsAndTransfers, "Transfers");
                    this.m_daWeights.Update(m_dsWeightsAndTransfers, "Weights");
                    if(m_daWeightsProduced !=null)
                        this.m_daWeightsProduced.Update(m_dtWeightsProduced);
                    if (m_daErrorWeights != null)
                        this.m_daErrorWeights.Update(m_dtErrorWeights);
                    if (m_daErrorWeightsProduced != null)
                        this.m_daErrorWeightsProduced.Update(m_dtErrorWeightsProduced);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "");
                }
            }
        }
        private void CheckErrors() // check - if errors were corrected - move them to another table
        {
            DataRow row;
            string sql;

            if(m_dtErrorWeights != null)
                for (int i = 0; i < m_dtErrorWeights.Rows.Count; i++)
                {
                    row = m_dtErrorWeights.Rows[i];
                    if (row.RowState == DataRowState.Modified)
                    {
                        int producedID = -1;
                        int.TryParse(row["ProducedID"].ToString(), out producedID);

                        ImportWeight data = new ImportWeight(int.Parse(row["TransKey"].ToString()), DateTime.Parse(row["MyTimestamp"].ToString()),
                            int.Parse(row["IsPreconsumer"].ToString()), decimal.Parse(row["Weight"].ToString()),
                            decimal.Parse(row["WasteCost"].ToString()), row["FoodTypeID"].ToString(), decimal.Parse(row["FoodTypeCost"].ToString()),
                            decimal.Parse(row["FoodTypeDiscount"].ToString()), row["LossTypeID"].ToString(), row["ContainerTypeID"].ToString(),
                            decimal.Parse(row["ContainerWeight"].ToString()), decimal.Parse(row["ContainerCost"].ToString()), row["StationTypeID"].ToString(),
                            row["DispositionTypeID"].ToString(), row["DaypartTypeID"].ToString(), row["BEOTypeID"].ToString(),
                            row["UserTypeID"].ToString(), row["UserQuestion"].ToString(), int.Parse(row["NItems"].ToString()),
                            bool.Parse(row["IsManualInput"].ToString()), int.Parse(row["IsMemorized"].ToString()), row["UnitUniqueName"].ToString(),
                            row["UnitsDisplayName"].ToString(), producedID, row["UnitaryItemWeight"].ToString(), row["WasteAmountUserEntry"].ToString());
                        data.Check();
                        if (data.IsCorrect())
                        {
                            sql = "INSERT INTO Weights(TransKey, [Timestamp], IsPreconsumer, Weight, WasteCost, FoodTypeID, FoodTypeCost, FoodTypeDiscount, LossTypeID, " +
                                " ContainerTypeID, ContainerWeight, ContainerCost, StationTypeID, DispositionTypeID, DaypartTypeID, BEOTypeID, UserTypeID, UserQuestion, " +
                                " NItems, IsManualInput, " + " IsMemorized, UnitUniqueName, ProducedID, UnitaryItemWeight, WasteAmountUserEntry, UnitsDisplayName) VALUES(" +
                                row["TransKey"] + ", #" + row["MyTimestamp"] + "#, " + row["IsPreconsumer"] + ", " +
                                row["Weight"] + ", " + row["WasteCost"] +
                                ", '" + row["FoodTypeID"] + "', " + row["FoodTypeCost"] + ", " + row["FoodTypeDiscount"] +
                                ", '" + row["LossTypeID"] + "', '" + row["ContainerTypeID"] + "', " + row["ContainerWeight"] + ", " +
                                row["ContainerCost"] + ", '" + row["StationTypeID"] + "', '" +
                                row["DispositionTypeID"] + "', '" + row["DaypartTypeID"] + "', '" +
                                row["BEOTypeID"] + "', '" + row["UserTypeID"] + "', '" + row["UserQuestion"] + "', " +
                                row["NItems"] + ", " + row["IsManualInput"] + ", " + row["IsMemorized"] + ", '" + row["UnitUniqueName"] + "', " +
                                (producedID <= 0 ? "NULL" : producedID.ToString()) + ", " + 
                                (row["UnitaryItemWeight"].ToString() == "" ? "NULL" : row["UnitaryItemWeight"]) + ", " + 
                                (row["WasteAmountUserEntry"].ToString() == "" ? "NULL" : row["WasteAmountUserEntry"]) + 
                                ", '" + row["UnitsDisplayName"] + "')";

                            VWA4Common.DB.Insert(sql);
                            //m_dsWeightsAndTransfers.Tables["Weights"].Rows.Add(new object[] { null, row["TransKey"], row["MyTimestamp"],
                            //row["IsPreconsumer"], row["Weight"],row["WasteCost"], row["FoodTypeID"], row["FoodTypeCost"],
                            //row["FoodTypeDiscount"], row["LossTypeID"], row["ContainerTypeID"], row["ContainerWeight"], row["ContainerCost"], row["StationTypeID"],
                            //row["DispositionTypeID"], row["DaypartTypeID"], row["BEOTypeID"], row["UserTypeID"], row["UserQuestion"], row["NItems"],
                            //row["IsManualInput"], row["IsMemorized"], row["UnitUniqueName"], (producedID <=0) ? null : row["ProducedID"]});
                            m_dtErrorWeights.Rows[i].Delete();

                        }
                    }
                }
            if (m_dtErrorWeightsProduced != null)
                for (int i = 0; i < m_dtErrorWeightsProduced.Rows.Count; i++ )
                {
                    row = m_dtErrorWeightsProduced.Rows[i];
                    if (row.RowState == DataRowState.Modified)
                    {
                        ImportWeight data = new ImportWeight(int.Parse(row["TransKey"].ToString()), DateTime.Parse(row["MyTimestamp"].ToString()),
                            row["LotNumber"].ToString(), row["EOTypeID"].ToString(), decimal.Parse(row["Weight"].ToString()),
                            decimal.Parse(row["FoodCost"].ToString()), row["FoodTypeID"].ToString(), decimal.Parse(row["FoodTypeCost"].ToString()),
                            row["ContainerTypeID"].ToString(), decimal.Parse(row["ContainerWeight"].ToString()),
                            decimal.Parse(row["ContainerCost"].ToString()), row["StationTypeID"].ToString(), row["DaypartTypeID"].ToString(),
                            row["UserTypeID"].ToString(), row["UserQuestion"].ToString(), int.Parse(row["NItems"].ToString()),
                            bool.Parse(row["IsManualInput"].ToString()), int.Parse(row["IsMemorized"].ToString()), row["UnitUniqueName"].ToString(),
                            row["UnitsDisplayName"].ToString(), int.Parse(row["UnitWeight"].ToString()), decimal.Parse(row["ProducedAmount"].ToString()), 
                            row["UnitaryItemWeight"].ToString());
                        data.Check();
                        if (data.IsCorrect())
                        {
                            sql = "INSERT INTO WeightsProduced(TransKey, [Timestamp], LotNumber, EOTypeID, Weight, FoodCost, FoodTypeID, FoodTypeCost, " +
                                " ContainerTypeID, ContainerWeight, ContainerCost, StationTypeID, DaypartTypeID, UserTypeID, UserQuestion, " +
                                " NItems, IsManualInput, IsMemorized, UnitUniqueName, UnitWeight, ProducedAmount, UnitaryItemWeight, UnitsDisplayName) VALUES(" +
                                row["TransKey"] + ", #" + row["MyTimestamp"] + "#, '" + row["LotNumber"] + "', '" + row["EOTypeID"] + "', " +
                                row["Weight"] + ", " + row["FoodCost"] + ", '" + row["FoodTypeID"] + "', " + row["FoodTypeCost"] +
                                ", '" + row["ContainerTypeID"] + "', " + row["ContainerWeight"] + ", " + row["ContainerCost"] + ", '" + row["StationTypeID"] + "', '" +
                                row["DaypartTypeID"] + "', '" + row["UserTypeID"] + "', '" + row["UserQuestion"] + "', " +
                                row["NItems"] + ", " + row["IsManualInput"] + ", " + row["IsMemorized"] + ", '" + row["UnitUniqueName"] + "', " +
                                row["UnitWeight"] + ", " + row["ProducedAmount"] + ", " +
                                (row["UnitaryItemWeight"].ToString() == "" ? "NULL" : row["UnitaryItemWeight"]) + ", '" + 
                                row["UnitsDisplayName"] + "')";
                            VWA4Common.DB.Insert(sql);
                            //this.m_dtWeightsProduced.Rows.Add(new object[] { null, row["TransKey"], row["MyTimestamp"],
                            //row["LotNumber"], row["EOTypeID"], row["Weight"],row["FoodCost"], row["FoodTypeID"], row["FoodTypeCost"],
                            //row["ContainerTypeID"], row["ContainerWeight"], row["ContainerCost"], row["StationTypeID"],
                            //row["DaypartTypeID"], row["UserTypeID"], row["UserQuestion"], row["NItems"],
                            //row["IsManualInput"], row["IsMemorized"], row["UnitUniqueName"], row["UnitWeight"] });
                            m_dtErrorWeightsProduced.Rows[i].Delete();
                        }
                    }
            }
        }
        public void ExportToXML(string fileName, string filter, UCViewWeights.DisplayMode mode)
        {
            try
            {
                DataView dataView = null;
                if (mode == UCViewWeights.DisplayMode.Weights || mode == UCViewWeights.DisplayMode.Both)
                    dataView = m_dsWeightsAndTransfers.Tables["Weights"].DefaultView;
                else if(mode == UCViewWeights.DisplayMode.ErrorWeights)
                    dataView = m_dsWeightsAndTransfers.Tables["ErrorWeights"].DefaultView;
                else if(mode == UCViewWeights.DisplayMode.Produced)
                    dataView = m_dsWeightsAndTransfers.Tables["WeightsProduced"].DefaultView;
                else if (mode == UCViewWeights.DisplayMode.ErrorProduced)
                    dataView = m_dsWeightsAndTransfers.Tables["ErrorWeightsProduced"].DefaultView;
                if (Regex.IsMatch(filter, @"Weights\."))
                    filter = Regex.Replace(filter, @"Weights\.", "");
                filter = Regex.Replace(filter, "Timestamp", "MyTimestamp");
                try
                {
                    if (filter != null && filter != "")
                        dataView.RowFilter = filter;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(null, "Error applying filters: " + ex.Message, "Error in XML Export: filters can't be applyed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(dataView.ToTable());
                ds.WriteXml(fileName, XmlWriteMode.WriteSchema);
                ds.Clear();
                dataView.RowFilter = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(null, "Error exporting to " + fileName + ": " + ex.Message, "Error in XML Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

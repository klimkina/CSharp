using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DataObject;
using System.Data;

namespace VWA4Common.DAO
{
    public class FoodTypeDAO
    {
        public static readonly FoodTypeDAO DAO = new FoodTypeDAO();

        private FoodTypeDAO() { }

        public FoodType Load(string id)
        {
            return this.getDataObject(DB.Retrieve(string.Format(@"SELECT * FROM FoodType WHERE TypeID='{0}'", id)).Rows[0]);
        }

        public bool Update(FoodType ls)
        {
            string sql = string.Format(@"UPDATE FoodType SET CatID={0}, ", ls.CatId);
            sql += string.Format("TypeName='{0}', ", ls.Name);
            sql += string.Format("ReportTypeName='{0}', ", ls.ReportName);
            sql += string.Format("SpanishTypeName='{0}', ", ls.SpanishName);
            sql += string.Format("Cost='{0}', ", ls.Cost);
            sql += string.Format("Rank='{0}', ", ls.Rank);
            sql += string.Format("Enabled='{0}', ", ls.Enabled);
            sql += string.Format("ModifiedDate='{0}', ", ls.ModifiedDate);
            sql += string.Format("Description='{0}', ", ls.Description);
            sql += string.Format("SpareProperty1='{0}', ", ls.SpareProperty1);
            sql += string.Format("SpareProperty2='{0}', ", ls.SpareProperty2);
            sql += string.Format("SpareProperty3='{0}', ", ls.SpareProperty3);
            sql += string.Format("VolumeWeight='{0}', ", ls.VolumeWeight);
            sql += string.Format("VolumeUnits='{0}', ", ls.VolumeUnits);
            sql += string.Format("VolumeUnitType='{0}', ", ls.VolumeUnitType);
            sql += string.Format("WasteClass='{0}' ", ls.WasteClass);
            sql += string.Format("WHERE TypeID='{0}'", ls.Id);
            return DB.Update(sql);
        }

        public int Insert(FoodType ft)
        {
            return this.Insert(ft.CatId, ft.Name, ft.ReportName, ft.SpanishName, ft.Cost, ft.Rank, ft.Enabled, ft.ModifiedDate, ft.Description,
                ft.SpareProperty1, ft.SpareProperty2, ft.SpareProperty3, ft.VolumeWeight, ft.VolumeUnits, ft.VolumeUnitType, ft.WasteClass);
        }

        public int Insert(int catId, string name, string reportName, string spanishName, double cost, int rank, bool enabled,
            DateTime modifiedDate, string description, int spareProperty1, int spareProperty2, int spareProperty3, int volumeWeight, int volumeUnits,
            int volumeUnitType, string wasteClass)
        {
            string sql = "INSERT INTO FoodType ";
            sql += "(CatID, TypeName, ReportTypeName, SpanishTypeName, Cost, Rank, Enabled, ModifiedDate, Description, SpareProperty1, ";
            sql += "SpareProperty2, SpareProperty3, VolumeWeight, VolumeUnits, VolumeUnitType, WasteClass) VALUES (";
            sql += string.Format("{0}, ", catId);
            sql += string.Format("'{0}', ", name);
            sql += string.Format("'{0}', ", reportName);
            sql += string.Format("'{0}', ", spanishName);
            sql += string.Format("{0}, ", cost);
            sql += string.Format("{0}, ", enabled);
            sql += string.Format("#{0}#, ", modifiedDate);
            sql += string.Format("'{0}', ", description);
            sql += string.Format("{0}, ", spareProperty1);
            sql += string.Format("{0}, ", spareProperty2);
            sql += string.Format("{0}, ", spareProperty3);
            sql += string.Format("{0}, ", volumeWeight);
            sql += string.Format("{0}, ", volumeUnits);
            sql += string.Format("{0}, ", volumeUnitType);
            sql += string.Format("'{0}'", wasteClass);
            sql += ")";

            return DB.Insert(sql);
        }

        public bool Delete(int id)
        {
            return DB.Delete(string.Format(@"DELETE FROM FoodType WHERE TypeID='{0}'", id));
        }

        public List<FoodType> GetAllFoodTypes()
        {
            return this.getDataObjects(DB.Retrieve(@"SELECT * FROM FoodType"));
        }

        public List<FoodType> GetAllFoodTypes(int limit)
        {
            return this.getDataObjects(DB.Retrieve(string.Format(@"SELECT TOP {0} * FROM FoodType", limit)));
        }

        public List<FoodType> GetAllFoodTypesByLogSheetId(int logSheetId)
        {
            string sql = string.Format(@"SELECT * FROM FoodType ft INNER JOIN LogSheetFoodTypes lsft on lsft.TypeId=ft.TypeId WHERE lsft.LogSheetId={0}", logSheetId);
            return this.getDataObjects(DB.Retrieve(sql));
        }

        public List<FoodType> GetAllFoodTypesByCategoryId(int catId)
        {
            return this.getDataObjects(DB.Retrieve(string.Format(@"SELECT * FROM FoodType WHERE CatID={0}", catId)));
        }

        private List<FoodType> getDataObjects(DataTable table)
        {
            List<FoodType> l = new List<FoodType>();
            foreach (DataRow row in table.Rows)
            {
                l.Add(this.getDataObject(row));
            }
            return l;
        }

        private FoodType getDataObject(DataRow row)
        {
            FoodType ls = new FoodType();

            ls.Id = row[0].ToString();
            ls.CatId = Convert.ToInt32(row[1]);
            ls.Name = row[2].ToString();
            ls.ReportName = row[3].ToString();
            ls.SpanishName = row[4].ToString();
            ls.Cost = Convert.ToDouble(row[5]);
            ls.Rank = Convert.ToInt32(row[6]);
            ls.Enabled = Boolean.Parse(row[7].ToString());
            ls.ModifiedDate = DateTime.Parse(row[8].ToString());
            ls.Description = row[9].ToString();
            ls.SpareProperty1 = Convert.ToInt32(row[10]);
            ls.SpareProperty2 = Convert.ToInt32(row[11]);
            ls.SpareProperty3 = Convert.ToInt32(row[12]);
            ls.VolumeWeight = Convert.ToInt32(row[13]);
            ls.VolumeUnits = Convert.ToInt32(row[14]);
            ls.VolumeUnitType = Convert.ToInt32(row[15]);
            ls.WasteClass = row[16].ToString();

            return ls;
        }
    }
}

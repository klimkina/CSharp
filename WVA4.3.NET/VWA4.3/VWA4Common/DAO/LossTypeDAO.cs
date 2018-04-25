using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DataObject;
using System.Data;

namespace VWA4Common.DAO
{
    public class LossTypeDAO
    {
        public static readonly LossTypeDAO DAO = new LossTypeDAO();

        private LossTypeDAO() { }

        public LossType Load(string id)
        {
            return this.getDataObject(DB.Retrieve(string.Format(@"SELECT * FROM LossType WHERE TypeID='{0}'", id)).Rows[0]);
        }

        public bool Update(LossType ls)
        {
            string sql = string.Format("UPDATE LossType SET CatID='{0}', ", ls.CatId);
            sql += string.Format("TypeName='{0}', ", ls.Name);
            sql += string.Format("ReportTypeName='{0}', ", ls.ReportName);
            sql += string.Format("SpanishTypeName='{0}', ", ls.SpanishName);
            sql += string.Format("OverproductionFlag='{0}, ", ls.OverProductionFlag);
            sql += string.Format("TrimWasteFlag='{0}, ", ls.TrimWasteFlag);
            sql += string.Format("HandlingFlag='{0}, ", ls.HandlingFlag);
            sql += string.Format("Rank='{0}, ", ls.Rank);
            sql += string.Format("Enabled='{0}, ", ls.Enabled);
            sql += string.Format("ModifiedDate='{0}, ", ls.ModifiedDate);
            sql += string.Format("Description='{0} ", ls.Description);
            sql += string.Format("WHERE TypeID='{0}'", ls.Id);

            return DB.Update(sql);
        }

        public bool Delete(int id)
        {
            return DB.Delete(string.Format(@"DELETE FROM LossType WHERE TypeID='{0}'", id));
        }

        public List<LossType> GetAllLossTypes()
        {
            return this.getDataObjects(DB.Retrieve(@"SELECT * FROM LossType"));
        }

        public List<LossType> GetAllLossTypesByLogSheetId(int logSheetId)
        {
            string sql = string.Format(@"SELECT * FROM LossType lt INNER JOIN LogSheetLossTypes lsft on lsft.TypeId=lt.TypeId WHERE lsft.LogSheetId={0}", logSheetId);
            return this.getDataObjects(DB.Retrieve(sql));
        }

        public List<LossType> GetAllLossTypesByCategoryId(int catId)
        {
            return this.getDataObjects(DB.Retrieve(string.Format(@"SELECT * FROM LossType WHERE CatID={0}", catId)));
        }

        private List<LossType> getDataObjects(DataTable table)
        {
            List<LossType> l = new List<LossType>();
            foreach (DataRow row in table.Rows)
            {
                l.Add(this.getDataObject(row));
            }
            return l;
        }

        private LossType getDataObject(DataRow row)
        {
            LossType ls = new LossType();

            ls.Id = row[0].ToString();
            ls.Name = row[1].ToString();
            ls.CatId = Convert.ToInt32(row[2].ToString());
            ls.ReportName = row[3].ToString();
            ls.SpanishName = row[4].ToString();
            ls.OverProductionFlag = Boolean.Parse(row[5].ToString());
            ls.TrimWasteFlag = Boolean.Parse(row[6].ToString());
            ls.HandlingFlag = Boolean.Parse(row[7].ToString());
            ls.Rank = Convert.ToInt32(row[8]);
            ls.Enabled = Boolean.Parse(row[9].ToString());
            ls.ModifiedDate = DateTime.Parse(row[10].ToString());
            ls.Description = row[11].ToString();

            return ls;
        }
    }
}

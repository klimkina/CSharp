using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DataObject;
using System.Data;

namespace VWA4Common.DAO
{
    public class ContainerTypeDAO
    {
        public static readonly ContainerTypeDAO DAO = new ContainerTypeDAO();

        private ContainerTypeDAO() { }

        public ContainerType Load(string id)
        {
            return this.getDataObject(DB.Retrieve(string.Format(@"SELECT * FROM ContainerType WHERE TypeID='{0}'", id)).Rows[0]);
        }

        public bool Update(ContainerType ct)
        {
            string sql = string.Format(@"UPDATE ContainerType SET CatID={0}, ", ct.CatId);
            sql += string.Format("TypeName='{0}', ", ct.Name);
            sql += string.Format("ReportTypeName='{0}', ", ct.ReportName);
            sql += string.Format("SpanishTypeName='{0}', ", ct.SpanishName);
            sql += string.Format("TareWeight={0}, ", ct.TareWeight);
            sql += string.Format("Cost={0}, ", ct.Cost);
            sql += string.Format("Volume={0}, ", ct.Volume);
            sql += string.Format("VolumeUnitType={0}, ", ct.VolumeUnitType);
            sql += string.Format("Rank={0}, ", ct.Rank);
            sql += string.Format("Enabled='{0}', ", ct.Enabled);
            sql += string.Format("ModifiedDate='{0}', ", ct.ModifiedDate);
            sql += string.Format("Description='{0}', ", ct.Description);
            sql += string.Format("WHERE TypeID='{0}'", ct.Id);
            return DB.Update(sql);
        }

        public int Insert(ContainerType ct)
        {
            return this.Insert(ct.CatId, ct.Name, ct.ReportName, ct.SpanishName, ct.TareWeight, ct.Cost, ct.Volume, ct.VolumeUnitType, ct.Rank, ct.Enabled, ct.ModifiedDate, ct.Description);
        }

        public int Insert(int catId, string name, string reportName, string spanishName, double tareWeight, double cost, double volume,
            int volumeUnitType, int rank, bool enabled, DateTime modifiedDate, string description)
        {
            string sql = "INSERT INTO ContainerType ";
            sql += "(CatID, TypeName, ReportTypeName, SpanishTypeName, TareWeight, Cost, Volume, VolumeUnitType, Rank, Enabled, ";
            sql += "ModifiedDate, Description) VALUES (";
            sql += string.Format("{0}, ", catId);
            sql += string.Format("'{0}', ", name);
            sql += string.Format("'{0}', ", reportName);
            sql += string.Format("'{0}', ", spanishName);
            sql += string.Format("{0}, ", tareWeight);
            sql += string.Format("{0}, ", cost);
            sql += string.Format("{0}, ", volume);
            sql += string.Format("{0}, '", volumeUnitType);
            sql += string.Format("{0}, ", rank);
            sql += string.Format("'{0}', ", enabled);
            sql += string.Format("'{0}', ", modifiedDate);
            sql += string.Format("'{0}'", description);
            sql += ")";

            return DB.Insert(sql);
        }

        public bool Delete(int id)
        {
            return DB.Delete(string.Format(@"DELETE FROM ContainerType WHERE TypeID='{0}'", id));
        }

        public List<ContainerType> GetAllContainerTypes()
        {
            return this.getDataObjects(DB.Retrieve(@"SELECT * FROM ContainerType"));
        }

        public List<ContainerType> GetAllContainerTypesByLogSheetId(int logSheetId)
        {
            string sql = string.Format(@"SELECT * FROM ContainerType ft INNER JOIN LogSheetContainerTypes lsft on lsft.TypeId=ft.TypeId WHERE lsft.LogSheetId={0}", logSheetId);
            return this.getDataObjects(DB.Retrieve(sql));
        }

        private List<ContainerType> getDataObjects(DataTable table)
        {
            List<ContainerType> l = new List<ContainerType>();
            foreach (DataRow row in table.Rows)
            {
                l.Add(this.getDataObject(row));
            }
            return l;
        }

        private ContainerType getDataObject(DataRow row)
        {
            ContainerType ct = new ContainerType();

            ct.Id = row[0].ToString();
            ct.Name = row[1].ToString();
            ct.CatId = Convert.ToInt32(row[2].ToString());
            ct.ReportName = row[3].ToString();
            ct.SpanishName = row[4].ToString();
            ct.TareWeight = Convert.ToDouble(row[5].ToString());
            ct.Cost = Convert.ToDouble(row[6].ToString());
            ct.Volume = Convert.ToDouble(row[7].ToString());
            ct.VolumeUnitType = Convert.ToInt32(row[8].ToString());
            ct.Rank = Convert.ToInt32(row[9].ToString());
            ct.Enabled = bool.Parse(row[10].ToString());
            ct.ModifiedDate = DateTime.Parse(row[11].ToString());
            ct.Description = row[12].ToString();

            return ct;
        }
    }
}

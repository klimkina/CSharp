using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DataObject;
using System.Data;

namespace VWA4Common.DAO
{
    public class ContainerCategoryDAO
    {
        public static readonly ContainerCategoryDAO DAO = new ContainerCategoryDAO();

        private ContainerCategoryDAO() { }

        public ContainerCategory Load(int id)
        {
            return this.getDataObject(DB.Retrieve(string.Format(@"SELECT * FROM ContainerCategory WHERE CatID={0}", id)).Rows[0]);
        }

        public bool Update(ContainerCategory cc)
        {
            string sql = string.Format(@"UPDATE ContainerCategory SET ");
            sql += string.Format("ParentCatID={0}, ", cc.ParentCatId);
            sql += string.Format("CatName='{0}', ", cc.Name);
            sql += string.Format("SpanishCatName='{0}', ", cc.SpanishName);
            sql += string.Format("Rank={0}, ", cc.Rank);
            sql += string.Format("Description='{0}', ", cc.Description);
            sql += string.Format("WHERE CatID='{0}'", cc.Id);
            return DB.Update(sql);
        }

        public int Insert(ContainerCategory cc)
        {
            return this.Insert(cc.ParentCatId, cc.Name, cc.SpanishName, cc.Rank, cc.Description);
        }

        public int Insert(int parentCatId, string catName, string spanishCatName, int rank, string description)
        {
            string sql = "INSERT INTO ContainerCategory ";
            sql += "(ParentCatID, CatName, SpanishCatName, Rank, Description";
            sql += ") VALUES (";
            sql += string.Format("{0}, ", parentCatId);
            sql += string.Format("'{0}', ", catName);
            sql += string.Format("'{0}', ", spanishCatName);
            sql += string.Format("{0}, ", rank);
            sql += string.Format("'{0}'", description);
            sql += ")";

            return DB.Insert(sql);
        }

        public bool Delete(int id)
        {
            return DB.Delete(string.Format(@"DELETE FROM ContainerCategory WHERE CatID='{0}'", id));
        }

        public List<ContainerCategory> GetAllContainerTypes()
        {
            return this.getDataObjects(DB.Retrieve(@"SELECT * FROM ContainerCategory"));
        }

        private List<ContainerCategory> getDataObjects(DataTable table)
        {
            List<ContainerCategory> l = new List<ContainerCategory>();
            foreach (DataRow row in table.Rows)
            {
                l.Add(this.getDataObject(row));
            }
            return l;
        }

        private ContainerCategory getDataObject(DataRow row)
        {
            ContainerCategory cc = new ContainerCategory();

            cc.Id = Convert.ToInt32(row[0].ToString());
            cc.ParentCatId = Convert.ToInt32(row[1].ToString());
            cc.Name = row[2].ToString();
            cc.SpanishName = row[3].ToString();
            cc.Rank = Convert.ToInt32(row[4].ToString());
            cc.Description = row[5].ToString();

            return cc;
        }
    }
}

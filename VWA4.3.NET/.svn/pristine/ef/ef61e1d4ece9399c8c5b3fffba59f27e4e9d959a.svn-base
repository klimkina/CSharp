using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DataObject;
using System.Data;

namespace VWA4Common.DAO
{
    public class FoodCategoryDAO
    {
        public static readonly FoodCategoryDAO DAO = new FoodCategoryDAO();

        private FoodCategoryDAO() { }

        public FoodCategory Load(int id)
        {
            return this.getDataObject(DB.Retrieve(string.Format(@"SELECT * FROM FoodCategory WHERE CatID='{0}'", id)).Rows[0]);
        }

        public bool Update(FoodCategory ls)
        {
            string sql = string.Format(@"UPDATE FoodCategory SET ");
            sql += string.Format("ParentCatID='{0}', ", ls.ParentCatID);
            sql += string.Format("CatName='{0}', ", ls.Name);
            sql += string.Format("SpanishCatName='{0}', ", ls.SpanishName);
            sql += string.Format("Rank='{0}', ", ls.Rank);
            sql += string.Format("Description='{0}' ", ls.Description);
            sql += string.Format("WHERE CatID='{0}'", ls.Id);

            return DB.Update(sql);
        }

        public bool Delete(int id)
        {
            return DB.Delete(string.Format(@"DELETE FROM FoodCategory WHERE CatID='{0}'", id));
        }

        public List<FoodCategory> GetAllFoodCategories()
        {
            return this.getDataObjects(DB.Retrieve(@"SELECT * FROM FoodCategory"));
        }

        public List<FoodCategory> GetAllChildFoodCategories()
        {
            return this.getDataObjects(DB.Retrieve(@"SELECT * FROM FoodCategory WHERE ParentCatID <> 0"));
        }

        private List<FoodCategory> getDataObjects(DataTable table)
        {
            List<FoodCategory> l = new List<FoodCategory>();
            foreach (DataRow row in table.Rows)
            {
                l.Add(this.getDataObject(row));
            }
            return l;
        }

        private FoodCategory getDataObject(DataRow row)
        {
            FoodCategory ls = new FoodCategory();
            ls.Id = Convert.ToInt32(row["CatID"]);
            ls.ParentCatID = Convert.ToInt32(row["ParentCatID"]);
            ls.Name = row["CatName"].ToString();
            ls.SpanishName = row["SpanishCatName"].ToString();
            ls.Rank = Convert.ToInt32(row["Rank"]);
            ls.Description = row["Description"].ToString();

            return ls;
        }
    }
}

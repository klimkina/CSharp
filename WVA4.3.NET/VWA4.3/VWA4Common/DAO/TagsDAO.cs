using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using VWA4Common.DataObject;

namespace VWA4Common.DAO
{
    public class TagsDAO
    {
        public static readonly TagsDAO DAO = new TagsDAO();

		private TagsDAO() { }

        public int GetNextId()
        {
            try
            {
				return Convert.ToInt32(DB.GetId(string.Format(@"SELECT MAX(ID) FROM Tags"))) + 1;
            }
            catch (InvalidCastException)
            {
                return 0;
            }            
        }

		public List<Tag> GetAllTags()
		{
			return this.getDataObjects(DB.Retrieve(@"SELECT * FROM Tags Order By TagName ASC"));
		}
		
		public Tag Load(int id)
        {
			return this.getDataObject(DB.Retrieve(string.Format(@"SELECT * FROM Tags WHERE ID={0}", id)).Rows[0]);
        }

		public Tag GetByTagName(int tagName)
        {
            try
            {
				return this.getDataObject(DB.Retrieve(string.Format("select * from Tags where TagName={0}", tagName)).Rows[0]);
            }
            catch (Exception)
            {
				return new Tag();
            }
        }

        public bool Exists(string tagName)
        {
            if (DB.Retrieve(string.Format("select ID from Tags where TagName='{0}'", tagName)).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

		public int Insert(Tag tag)
        {
            return this.Insert(tag.TagName, tag.TagDescription);
        }

        public int Insert(string TagName, string TagDescription)
        {
            string sql = "INSERT INTO Tags ";
			sql += "(TagName, TagDescription";
            sql += ") VALUES (";
			sql += string.Format("'{0}', ", TagName);
			sql += string.Format("'{0}'", TagDescription);
            sql += ")";

            return DB.Insert(sql);
        }

		public bool InsertOrUpdate(Tag tag)
        {
            if (tag.IsNew)
            {
                this.Insert(tag);
                return true;
            }
            else
            {
                return this.Update(tag);
            }
        }

        public bool Update(Tag tag)
        {
            string sql = "UPDATE Tags SET ";
            sql += string.Format("TagName='{0}', ", tag.TagName);
            sql += string.Format("TagDescription='{0}' ", tag.TagDescription);
            sql += string.Format(" WHERE ID={0}", tag.ID);

            return DB.Update(sql);
        }

        public bool DeletebyTagName(int tagname)
        {
            return DB.Delete(string.Format(@"delete from Tags where TagName='{0}'", tagname));
        }

        public bool Delete(Tag tag)
        {
            return this.Delete(tag.ID);
        }

        public bool Delete(int id)
        {
            return DB.Delete(string.Format(@"DELETE FROM Tags WHERE ID={0}", id));
        }

        private List<Tag> getDataObjects(DataTable table)
        {
            List<Tag> l = new List<Tag>();
            foreach (DataRow row in table.Rows)
            {
                l.Add(this.getDataObject(row));
            }
            return l;
        }

        private Tag getDataObject(DataRow row)
        {
            Tag tag = new Tag();

            tag.ID = Convert.ToInt32(row[0].ToString());
            tag.TagName = row[1].ToString();
            tag.TagDescription = row[2].ToString();

            return tag;
        }
    }
}

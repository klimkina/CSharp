using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DataObject;
using System.Data;
using VWA4Common.DataObject;

namespace VWA4Common.DAO
{
	public class TagsFoodTypeDAO
	{
			public static readonly TagsFoodTypeDAO DAO = new TagsFoodTypeDAO();

			private TagsFoodTypeDAO() { }

			public int GetNextId()
			{
				try
				{
					return Convert.ToInt32(DB.GetId(string.Format(@"SELECT MAX(ID) FROM TagsFoodType"))) + 1;
				}
				catch (InvalidCastException)
				{
					return 0;
				}
			}

			public TagsFoodType Load(int id)
			{
				return this.getDataObject(DB.Retrieve(string.Format(@"SELECT * FROM TagsFoodType WHERE ID={0}", id)).Rows[0]);
			}

			public TagsFoodType GetByTagId(int tagID)
			{
				try
				{
					return this.getDataObject(DB.Retrieve(string.Format("select * from TagsFoodType where TagID={0}", tagID)).Rows[0]);
				}
				catch (Exception)
				{
					return new TagsFoodType();
				}
			}

			public TagsFoodType GetByTagIdAndFoodTypeId(int tagID, string foodTypeID)
			{
				try
				{
					return this.getDataObject(DB.Retrieve(string.Format("select * from TagsFoodType where TagId={0} and FoodTypeId='{1}'", tagID, foodTypeID)).Rows[0]);
				}
				catch (Exception)
				{
					return new TagsFoodType();
				}
			}

			public List<TagsFoodType> GetAllByFoodTypeID(string foodTypeID)
			{
				return this.getDataObjects(DB.Retrieve(string.Format("select * from TagsFoodType where FoodTypeID='{0}'", foodTypeID)));
			}

			public List<TagsFoodType> GetAllByTagID(int tagID)
			{
				return this.getDataObjects(DB.Retrieve(string.Format("select * from TagsFoodType where TagID={0}", tagID)));
			}
			
		public List<TagsFoodType> GetAllByTagName(string tagName)
			{
				return this.getDataObjects(DB.Retrieve(string.Format("select * from TagsFoodType where TagName='{0}'", tagName)));
			}

			public bool Exists(int tagID, string foodTypeID)
			{
				if (DB.Retrieve(string.Format("select ID from TagsFoodType where TagID={0} AND FoodTypeID='{1}'", tagID, foodTypeID)).Rows.Count > 0)
				{
					return true;
				}
				return false;
			}

			public int Insert(TagsFoodType tft)
			{
				return this.Insert(tft.TagID, tft.FoodTypeID);
			}

			public int Insert(int tagID, string foodTypeID)
			{
				string sql = "INSERT INTO TagsFoodType ";
				sql += "(TagId, FoodTypeId";
				sql += ") VALUES (";
				sql += string.Format("{0}, ", tagID);
				sql += string.Format("'{0}' ", foodTypeID);
				sql += ")";

				return DB.Insert(sql);
			}

			public bool InsertOrUpdate(TagsFoodType tft)
			{
				if (tft.IsNew)
				{
					this.Insert(tft);
					return true;
				}
				else
				{
					return this.Update(tft);
				}
			}

			public bool Update(TagsFoodType tft)
			{
				string sql = "UPDATE TagsFoodType SET ";
				sql += string.Format("TagId={0}, ", tft.TagID);
				sql += string.Format("FoodTypeId='{0}' ", tft.FoodTypeID);
				sql += string.Format(" WHERE ID={0}", tft.ID);

				return DB.Update(sql);
			}

			public bool ClearAllByFoodTypeID(string foodTypeID)
			{
				return DB.Delete(string.Format(@"delete from TagsFoodType where FoodTypeId='{0}'", foodTypeID));
			}
			public bool ClearAllByTagID(int tagID)
			{
				return DB.Delete(string.Format(@"delete from TagsFoodType where TagID={0}", tagID.ToString()));
			}

			public bool Delete(TagsFoodType ffs)
			{
				return this.Delete(ffs.ID);
			}

			public bool Delete(int id)
			{
				return DB.Delete(string.Format(@"DELETE FROM TagsFoodType WHERE ID={0}", id));
			}
			public bool Delete(string foodtypeid)
			{
				return DB.Delete(string.Format(@"DELETE FROM TagsFoodType WHERE FoodTypeID='{0}'", foodtypeid));
			}

			private List<TagsFoodType> getDataObjects(DataTable table)
			{
				List<TagsFoodType> l = new List<TagsFoodType>();
				foreach (DataRow row in table.Rows)
				{
					l.Add(this.getDataObject(row));
				}
				return l;
			}

			private TagsFoodType getDataObject(DataRow row)
			{
				TagsFoodType f = new TagsFoodType();

				f.ID = Convert.ToInt32(row["ID"].ToString());
				f.TagID = Convert.ToInt32(row["TagID"].ToString());
				f.FoodTypeID = row["FoodTypeID"].ToString();
				DataTable dt = DB.Retrieve("select TypeName from FoodType where TypeID='" + f.FoodTypeID + "'");
				f.FoodTypeName = dt.Rows[0]["TypeName"].ToString();
				dt = DB.Retrieve("select TagName from Tags where ID=" + f.TagID);
				f.TagName = dt.Rows[0]["TagName"].ToString();

				return f;
			}
		}
}

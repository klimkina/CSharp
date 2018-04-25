using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DataObject;
using System.Data;

namespace VWA4Common.DAO
{
    public class UnitsVolumeDAO
    {
        public static readonly UnitsVolumeDAO DAO = new UnitsVolumeDAO();

        private UnitsVolumeDAO() { }

        public UnitsVolume Load(int id)
        {
            return this.getDataObject(DB.Retrieve(string.Format(@"SELECT * FROM UnitsVolume WHERE ID={0}", id)).Rows[0]);
        }

        public bool Update(UnitsVolume uv)
        {
            string sql = string.Format(@"UPDATE UnitsVolume SET ");
            sql += string.Format("UniqueName={0}, ", uv.Name);
            sql += string.Format("DisplayFullName='{0}', ", uv.DisplayFullName);
            sql += string.Format("DisplayAbbreviatedName='{0}', ", uv.DisplayAbbreviatedName);
            sql += string.Format("ConversionFactor={0}, ", uv.ConversionFactor);
            sql += string.Format("Description='{0}', ", uv.Description);
            sql += string.Format("WHERE CatID='{0}'", uv.Id);
            return DB.Update(sql);
        }

        public int Insert(UnitsVolume uv)
        {
            return this.Insert(uv.Name, uv.DisplayFullName, uv.DisplayAbbreviatedName, uv.ConversionFactor, uv.Description);
        }

        public int Insert(string uniqueName, string displayFullName, string displayAbbreviatedName, double conversionFactor, string description)
        {
            string sql = "INSERT INTO UnitsVolume ";
            sql += "(uniqueName, DisplayFullName, DisplayAbbreviatedName, ConversionFactor, Description";
            sql += ") VALUES (";
            sql += string.Format("'{0}', ", uniqueName);
            sql += string.Format("'{0}', ", displayFullName);
            sql += string.Format("'{0}', ", displayAbbreviatedName);
            sql += string.Format("{0}, ", conversionFactor);
            sql += string.Format("'{0}'", description);
            sql += ")";

            return DB.Insert(sql);
        }

        public bool Delete(int id)
        {
            return DB.Delete(string.Format(@"DELETE FROM UnitsVolume WHERE ID='{0}'", id));
        }

        private List<UnitsVolume> getDataObjects(DataTable table)
        {
            List<UnitsVolume> l = new List<UnitsVolume>();
            foreach (DataRow row in table.Rows)
            {
                l.Add(this.getDataObject(row));
            }
            return l;
        }

        private UnitsVolume getDataObject(DataRow row)
        {
            UnitsVolume uv = new UnitsVolume();

            uv.Id = Convert.ToInt32(row[0].ToString());
            uv.Name = row[1].ToString();
            uv.DisplayFullName = row[2].ToString();
            uv.DisplayAbbreviatedName = row[3].ToString();
            uv.ConversionFactor = Convert.ToDouble(row[4].ToString());
            uv.Description = row[5].ToString();

            return uv;
        }
    }
}

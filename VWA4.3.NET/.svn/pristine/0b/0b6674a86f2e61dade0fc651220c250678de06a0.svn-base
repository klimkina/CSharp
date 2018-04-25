using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using VWA4Common.DataObject;

namespace VWA4Common.DAO
{
    public class SiteDAO
    {
        public static readonly SiteDAO DAO = new SiteDAO();

        private SiteDAO() { }

        public Site Load(int id)
        {
            return this.getDataObject(DB.Retrieve(string.Format(@"SELECT * FROM Sites WHERE ID={0}", id)).Rows[0]);
        }

        public int Insert(Site s)
        {
            return this.Insert(s.LicensedSite, s.TypeCatalogId, s.Customer, s.BusinessUnit, s.Region, s.District, s.LTGroup, s.ProgramStartDate, s.StartOfValidData, s.VolumeAdjust, s.Active, 
                s.ModifiedDate);
        }

        public int Insert(string licensedSite, int typeCatalogId, int customer, int businessUnit, int region, int district, int ltGroup, DateTime programStartDate,
            DateTime startOfValidData, double volumeAdjust, bool active, DateTime modifiedDate)
        {
            string sql = string.Empty;
            sql = "INSERT INTO Site ";
            sql += "(LicensedSite, TypeCatalogID, Customer, BusinessUnit, Region, District, LTGroup, ProgramStartDate, StartofValidDate, VolumeAdjust, Active, ModifiedDate) VALUES (";
            sql += string.Format("'{0}', ", licensedSite);
            sql += string.Format("{0}, ", typeCatalogId);
            sql += string.Format("{0}, ", customer);
            sql += string.Format("{0}, ", businessUnit);
            sql += string.Format("{0}, ", region);
            sql += string.Format("{0}, ", district);
            sql += string.Format("{0}, ", ltGroup);
            sql += string.Format("'{0}', ", programStartDate);
            sql += string.Format("'{0}', ", startOfValidData);
            sql += string.Format("{0}, ", volumeAdjust);
            sql += string.Format("'{0}', ", active);
            sql += string.Format("'{0}'", modifiedDate);
            sql += ")";

            return DB.Insert(sql);
        }

        public bool Update(Site s)
        {
            string sql = string.Format(@"UPDATE Site SET ");
            sql += string.Format("LicensedSite='{0}', ", s.LicensedSite);
            sql += string.Format("TypeCatalogId={0}, ", s.TypeCatalogId);
            sql += string.Format("Customer={0}, ", s.Customer);
            sql += string.Format("BusinessUnit={0}, ", s.BusinessUnit);
            sql += string.Format("Region={0}, ", s.Region);
            sql += string.Format("District={0}, ", s.District);
            sql += string.Format("LTGroup={0}, ", s.LTGroup);
            sql += string.Format("ProgramStartDate='{0}', ", s.ProgramStartDate);
            sql += string.Format("StartofValidData='{0}', ", s.StartOfValidData);
            sql += string.Format("VolumeAdjust={0}, ", s.VolumeAdjust);
            sql += string.Format("Active='{0}', ", s.Active);
            sql += string.Format("ModifiedDate='{0}' ", s.ModifiedDate);
            sql += string.Format("where Id={0}", s.Id);

            return DB.Update(sql);
        }

        public bool Delete(int id)
        {
            return DB.Delete(string.Format(@"DELETE FROM Sites WHERE ID={0}", id));
        }

        public List<Site> GetAllSites()
        {
            return this.getDataObjects(DB.Retrieve(@"SELECT * FROM Sites"));
        }

        private List<Site> getDataObjects(DataTable table)
        {
            List<Site> l = new List<Site>();
            foreach (DataRow row in table.Rows)
            {
                l.Add(this.getDataObject(row));
            }
            return l;
        }

        private Site getDataObject(DataRow row)
        {
            Site s = new Site();

            s.Id = Convert.ToInt32(row[0].ToString());
            s.LicensedSite = row[1].ToString();
            s.TypeCatalogId = Convert.ToInt32(row[2].ToString());
            s.Customer = Convert.ToInt32(row[3].ToString());
            s.BusinessUnit = Convert.ToInt32(row[4].ToString());
            s.Region = Convert.ToInt32(row[5].ToString());
            s.District = Convert.ToInt32(row[6].ToString());
            s.LTGroup = Convert.ToInt32(row[7].ToString());
            s.ProgramStartDate = row[8].ToString() != string.Empty ? DateTime.Parse(row[8].ToString()) : new DateTime();
            s.StartOfValidData = row[9].ToString() != string.Empty ? DateTime.Parse(row[9].ToString()) : new DateTime();
            s.VolumeAdjust = Convert.ToInt32(row[10].ToString());
            s.Active = bool.Parse(row[11].ToString());
            s.ModifiedDate = DateTime.Parse(row[12].ToString());

            return s;
        }
    }
}

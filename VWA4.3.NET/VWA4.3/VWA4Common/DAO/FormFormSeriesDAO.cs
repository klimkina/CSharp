using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DataObject;
using System.Data;

namespace VWA4Common.DAO
{
    public class FormFormSeriesDAO
    {
        public static readonly FormFormSeriesDAO DAO = new FormFormSeriesDAO();

        private FormFormSeriesDAO() { }

        public int GetNextId()
        {
            try
            {
                return Convert.ToInt32(DB.GetId(string.Format(@"SELECT MAX(ID) FROM FormFormSeries"))) + 1;
            }
            catch (InvalidCastException)
            {
                return 0;
            }            
        }

        public FormFormSeries Load(int id)
        {
            return this.getDataObject(DB.Retrieve(string.Format(@"SELECT * FROM FormFormSeries WHERE ID={0}", id)).Rows[0]);
        }

        public FormFormSeries GetByFormId(int formId)
        {
            try
            {
                return this.getDataObject(DB.Retrieve(string.Format("select * from FormFormSeries where FormId={0}", formId)).Rows[0]);
            }
            catch (Exception)
            {
                return new FormFormSeries();
            }
        }

        public FormFormSeries GetByFormIdAndFormSeriesId(int formId, int formSeriesId)
        {
            try
            {
                return this.getDataObject(DB.Retrieve(string.Format("select * from FormFormSeries where FormId={0} and FormSeriesId={1}", formId, formSeriesId)).Rows[0]);
            }
            catch (Exception)
            {
                return new FormFormSeries();
            }
        }

        public List<FormFormSeries> GetAllByFormSeriesId(int formSeriesId)
        {
            return this.getDataObjects(DB.Retrieve(string.Format("select * from FormFormSeries where FormSeriesID={0} order by SortOrder", formSeriesId)));
        }

        public bool Exists(int formId, int formSeriesId)
        {
            if (DB.Retrieve(string.Format("select ID from FormFormSeries where FormID={0} AND FormSeriesID={1}", formId, formSeriesId)).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public int Insert(FormFormSeries ffs)
        {
            return this.Insert(ffs.FormId, ffs.FormSeriesId, ffs.Enabled, ffs.NumberOfCopies, ffs.SortOrder);
        }

        public int Insert(int formId, int formSeriesId, bool enabled, int numberOfCopies, int sortOrder)
        {
            string sql = "INSERT INTO FormFormSeries ";
            sql += "(FormId, FormSeriesId, Enabled, NumberOfCopies, SortOrder";
            sql += ") VALUES (";
            sql += string.Format("{0}, ", formId);
            sql += string.Format("{0}, ", formSeriesId);
            sql += string.Format("{0}, ", enabled);
            sql += string.Format("{0}, ", numberOfCopies);
            sql += string.Format("{0}", sortOrder);
            sql += ")";

            return DB.Insert(sql);
        }

        public bool InsertOrUpdate(FormFormSeries ffs)
        {
            if (ffs.IsNew)
            {
                this.Insert(ffs);
                return true;
            }
            else
            {
                return this.Update(ffs);
            }
        }

        public bool Update(FormFormSeries ffs)
        {
            string sql = "UPDATE FormFormSeries SET ";
            sql += string.Format("FormId={0}, ", ffs.FormId);
            sql += string.Format("FormSeriesId={0}, ", ffs.FormSeriesId);
            sql += string.Format("Enabled={0}, ", ffs.Enabled);
            sql += string.Format("NumberOfCopies={0}, ", ffs.NumberOfCopies);
            sql += string.Format("SortOrder={0} ", ffs.SortOrder);
            sql += string.Format(" WHERE ID={0}", ffs.Id);

            return DB.Update(sql);
        }

        public bool ClearAllByFormSeriesId(int formSeriesId)
        {
            return DB.Delete(string.Format(@"delete from FormFormSeries where FormSeriesId={0}", formSeriesId));
        }

        public bool Delete(FormFormSeries ffs)
        {
            return this.Delete(ffs.Id);
        }

        public bool Delete(int id)
        {
            return DB.Delete(string.Format(@"DELETE FROM FormFormSeries WHERE ID={0}", id));
        }

        private List<FormFormSeries> getDataObjects(DataTable table)
        {
            List<FormFormSeries> l = new List<FormFormSeries>();
            foreach (DataRow row in table.Rows)
            {
                l.Add(this.getDataObject(row));
            }
            return l;
        }

        private FormFormSeries getDataObject(DataRow row)
        {
            FormFormSeries f = new FormFormSeries();

            f.Id = Convert.ToInt32(row[0].ToString());
            f.FormId = Convert.ToInt32(row[1].ToString());
            f.FormSeriesId = Convert.ToInt32(row[2].ToString());
            f.Enabled = Boolean.Parse(row[3].ToString());
            f.NumberOfCopies = Convert.ToInt32(row[4].ToString());
            f.SortOrder = Convert.ToInt32(row[5].ToString());

            return f;
        }
    }
}

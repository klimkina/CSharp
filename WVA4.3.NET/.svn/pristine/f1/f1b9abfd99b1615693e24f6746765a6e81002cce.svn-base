using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DataObject;
using System.Data;

namespace VWA4Common.DAO
{
    public class FormSeriesDAO
    {
        public static readonly FormSeriesDAO DAO = new FormSeriesDAO();

        private FormSeriesDAO() { }

        public FormSeries Load(int id)
        {
            return this.getDataObject(DB.Retrieve(string.Format(@"SELECT * FROM FormSeries WHERE ID={0}", id)).Rows[0]);
        }

        public FormSeries GetByFormId(int formId)
        {
            try
            {
                return this.getDataObject(DB.Retrieve(string.Format("select * from FormSeries where ID={0}", FormFormSeriesDAO.DAO.GetByFormId(formId).FormSeriesId)).Rows[0]);
            }
            catch (Exception)
            {
                return new FormSeries();
            }
        }

        public int Insert(FormSeries fs)
        {
            return this.Insert(fs.Name, fs.CreateDate, fs.ModifiedDate);
        }

        public int Insert(string ReportSeriesName, DateTime CreateDate, DateTime ModifiedDate)
        {
            string sql = "INSERT INTO FormSeries ";
            sql += "(ReportSeriesName, CreateDate, ModifiedDate";
            sql += ") VALUES (";
            sql += string.Format("'{0}', ", ReportSeriesName);
            sql += string.Format("'{0}', ", CreateDate);
            sql += string.Format("'{0}'", ModifiedDate);
            sql += ")";

            return DB.Insert(sql);
        }

        public bool Update(FormSeries fs)
        {
            string sql = "UPDATE FormSeries SET ";
            sql += string.Format("ReportSeriesName='{0}'", fs.Name);
            sql += string.Format(" WHERE ID={0}", fs.Id);

            return DB.Update(sql);
        }

        public List<FormSeries> GetAll()
        {
            return this.getDataObjects(DB.Retrieve(@"SELECT * FROM FormSeries"));
        }

        public bool Delete(FormSeries fs)
        {
            if (this.Delete(fs.Id))
            {
                foreach (FormFormSeries ffs in FormFormSeriesDAO.DAO.GetAllByFormSeriesId(fs.Id))
                {
                    FormFormSeriesDAO.DAO.Delete(ffs);
                }
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            return DB.Delete(string.Format(@"DELETE FROM FormSeries WHERE ID={0}", id));
        }

        private List<FormSeries> getDataObjects(DataTable table)
        {
            List<FormSeries> l = new List<FormSeries>();
            foreach (DataRow row in table.Rows)
            {
                l.Add(this.getDataObject(row));
            }
            return l;
        }

        private FormSeries getDataObject(DataRow row)
        {
            FormSeries f = new FormSeries();

            f.Id = Convert.ToInt32(row[0].ToString());
            f.Name = row[1].ToString();
            f.CreateDate = DateTime.Parse(row[2].ToString());
            f.ModifiedDate = DateTime.Parse(row[3].ToString());

            return f;
        }
    }
}

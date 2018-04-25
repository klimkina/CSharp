using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DataObject;
using System.Data;

namespace VWA4Common.DAO
{
    public class FormDAO
    {
        public static readonly FormDAO DAO = new FormDAO();

        private FormDAO() { }

        public Formx Load(int id)
        {
            return this.getDataObject(DB.Retrieve(string.Format(@"SELECT * FROM Form WHERE ID={0}", id)).Rows[0]);
        }

        public List<Formx> GetAll()
        {
            return this.getDataObjects(DB.Retrieve(string.Format(@"SELECT * From Form")));
        }

        public List<Formx> GetAllBySeriesId(int formSeriesId)
        {
            return this.getDataObjects(DB.Retrieve(string.Format(string.Format(@"SELECT frm.ID, frm.FormName, frm.DataEntryTemplateId, frm.SavePath, frm.FileName, frm.DocumentType, frm.DocumentLength, frm.DocumentData, frm.LastPrintDate, frm.CreateDate, frm.ModifiedDate from Form frm inner join formformseries ffs on ffs.FormId = frm.ID where ffs.FormSeriesId = {0} order by ffs.SortOrder", formSeriesId))));
        }

        public int Insert(Formx f)
        {
            return this.Insert(f.Name, f.DataEntryTemplateId, f.SavePath, f.FileName, f.DocumentType, f.DocumentLength, f.DocumentData, f.CreateDate, f.ModifiedDate);
        }

        public int Insert(string FormName, int DataEntryTemplateId, string SavePath, string FileName, string DocumentType, long DocumentLength, byte[] DocumentData, DateTime CreateDate, DateTime ModifiedDate)
        {
            string sql = "INSERT INTO Form ";
            sql += "(FormName, DataEntryTemplateId, SavePath, FileName, DocumentType, DocumentLength, DocumentData, LastPrintDate, CreateDate, ModifiedDate";
            sql += ") VALUES (";
            sql += string.Format("'{0}', ", FormName);
            sql += string.Format("{0}, ", DataEntryTemplateId);
            sql += string.Format("'{0}', ", SavePath);
            sql += string.Format("'{0}', ", FileName);
            sql += string.Format("'{0}', ", DocumentType);
            sql += string.Format("{0}, ", DocumentLength);
            sql += string.Format("'{0}', ", DocumentData);
            sql += string.Format("'', ");
            sql += string.Format("'{0}', ", CreateDate);
            sql += string.Format("'{0}'", ModifiedDate);
            sql += ")";

            return DB.Insert(sql);
        }

        public bool Update(Formx f)
        {
            string sql = "UPDATE Form SET ";
            sql += string.Format("FormName='{0}', ", f.Name);
            sql += string.Format("DataEntryTemplateId={0}, ", f.DataEntryTemplateId);
            sql += string.Format("SavePath='{0}', ", f.SavePath);
            sql += string.Format("FileName='{0}', ", f.FileName);
            sql += string.Format("DocumentType='{0}', ", f.DocumentType);
            sql += string.Format("DocumentLength={0}, ", f.DocumentLength);
            sql += string.Format("DocumentData='{0}', ", f.DocumentData);
            sql += string.Format("LastPrintDate='{0}', ", f.LastPrintedDate);
            sql += string.Format("CreateDate='{0}', ", f.CreateDate);
            sql += string.Format("ModifiedDate='{0}'", f.ModifiedDate);
            sql += string.Format(" WHERE ID={0}", f.Id);

            return DB.Update(sql);
        }

        public bool Delete(Formx f)
        {
            return this.Delete(f.Id);
        }

        public bool Delete(int id)
        {
            return DB.Delete(string.Format(@"DELETE FROM Form WHERE ID={0}", id));
        }

        private List<Formx> getDataObjects(DataTable table)
        {
            List<Formx> l = new List<Formx>();
            foreach (DataRow row in table.Rows)
            {
                l.Add(this.getDataObject(row));
            }
            return l;
        }

        private Formx getDataObject(DataRow row)
        {
            Formx f = new Formx();

            f.Id = Convert.ToInt32(row[0].ToString());
            f.Name = row[1].ToString();
            f.DataEntryTemplateId = Convert.ToInt32(row[2].ToString());
            f.SavePath = row[3].ToString();
            f.FileName = row[4].ToString();
            f.DocumentType = row[5].ToString();
            f.DocumentLength = Convert.ToInt32(row[6].ToString());
            f.DocumentData = (byte[])(row[7]);
            f.LastPrintedDate = row[8].ToString();
            f.CreateDate = DateTime.Parse(row[9].ToString());
            f.ModifiedDate = DateTime.Parse(row[10].ToString());

            f.FormSeries = FormSeriesDAO.DAO.GetByFormId(f.Id);

            return f;
        }
    }
}

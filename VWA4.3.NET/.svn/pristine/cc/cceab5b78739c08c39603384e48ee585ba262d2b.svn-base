using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DAO;

namespace VWA4Common.DataObject
{
    public class Formx
    {
        private int id = 0;
        private string name = string.Empty;
        private int dataEntryTemplateId = 0;
        private string savePath = string.Empty;
        private string fileName = string.Empty;
        private string documentType = string.Empty;
        private long documentLength = 0;
        private byte[] documentData = null;
        private string lastPrintedDate = string.Empty;
        private DateTime createDate = DateTime.Now;
        private DateTime modifiedDate = DateTime.Now;
        private FormSeries formSeries = new FormSeries();

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int DataEntryTemplateId
        {
            get { return this.dataEntryTemplateId; }
            set { this.dataEntryTemplateId = value; }
        }
        public string SavePath
        {
            get { return this.savePath; }
            set { this.savePath = value; }
        }
        public string FileName
        {
            get { return this.fileName; }
            set { this.fileName = value; }
        }
        public string DocumentType
        {
            get { return this.documentType; }
            set { this.documentType = value; }
        }
        public long DocumentLength
        {
            get { return this.documentLength; }
            set { this.documentLength = value; }
        }
        public byte[] DocumentData
        {
            get { return this.documentData; }
            set { this.documentData = value; }
        }
        public string LastPrintedDate
        {
            get { return this.lastPrintedDate; }
            set { this.lastPrintedDate = value; }
        }
        public DateTime CreateDate
        {
            get { return this.createDate; }
            set { this.createDate = value; }
        }
        public DateTime ModifiedDate
        {
            get { return this.modifiedDate; }
            set { this.modifiedDate = value; }
        }
        public FormSeries FormSeries
        {
            get { return this.formSeries; }
            set { this.formSeries = value; }
        }
        public bool IsNew
        {
            get
            {
                if (this.Id == 0)
                    return true;
                return false;
            }
        }
    }
}

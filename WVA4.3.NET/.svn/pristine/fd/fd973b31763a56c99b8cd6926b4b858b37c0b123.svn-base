using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.DAO;

namespace VWA4Common.DataObject
{
    public class FormFormSeries
    {
        private int id = 0;
        private int formId = 0;
        private int formSeriesId = 0;
        private bool enabled = false;
        private int numberOfCopies = 0;
        private int sortOrder = 0;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int FormId
        {
            get { return this.formId; }
            set { this.formId = value; }
        }
        public int FormSeriesId
        {
            get { return this.formSeriesId; }
            set { this.formSeriesId = value; }
        }
        public bool Enabled
        {
            get { return this.enabled; }
            set { this.enabled = value; }
        }
        public int NumberOfCopies
        {
            get { return this.numberOfCopies; }
            set { this.numberOfCopies = value; }
        }
        public int SortOrder
        {
            get { return this.sortOrder; }
            set { this.sortOrder = value; }
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

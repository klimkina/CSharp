using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicenseManager4Web.Entities.Written
{
    public class License
    {
        public int ID { get; set; }
        public int SiteID { get; set; }
        public int ClientID { get; set; }
        public string LicenseID { get; set; }
        public int Product { get; set; }
        public int LicenseType { get; set; }
        public string GeneratedBy { get; set; }
        public DateTime GeneratedTime { get; set; }
    }
}
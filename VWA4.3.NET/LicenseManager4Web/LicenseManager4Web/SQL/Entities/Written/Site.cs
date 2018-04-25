using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicenseManager4Web.Entities.Written
{
    public class Site
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string SiteName { get; set; }
        public string SalesForceId { get; set; }
    }
}
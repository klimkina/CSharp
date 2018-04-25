using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicenseManager4Web.Entities.Written
{
    public class Client
    {
        public int ID { get; set; }
        public string ClientName { get; set; }
        public int NumberOfSites { get; set; }
        public string SalesForceId { get; set; }
    }
}
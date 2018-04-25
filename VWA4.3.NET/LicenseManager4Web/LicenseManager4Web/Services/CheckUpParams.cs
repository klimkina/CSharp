using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LicenseManager4Web.Entities.Written;

namespace LicenseManager4Web.Services
{
    public class CheckUpParams
    {
        public string Token { get; set; }
        public List<Update> AvailableUpdates { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace LicenseManager4Web.Entities.Written
{
    public enum LicenseType
    {
        [Description("Site")]
        Site = 0,
        [Description("CPU")]
        CPU = 1
    }
}
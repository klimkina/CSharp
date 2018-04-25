using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace LicenseManager4Web.Entities.Written
{
    public enum AllowedWasteClassesType
    {
        [Description("Food")]
        Food = 0,
        [Description("Non-Food")]
        NonFood = 1,
        [Description("All Waste Classes")]
        AllWasteClasses = 2
    }
}
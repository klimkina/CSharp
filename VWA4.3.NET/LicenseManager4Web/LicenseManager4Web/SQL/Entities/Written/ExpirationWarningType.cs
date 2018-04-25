using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace LicenseManager4Web.Entities.Written
{
    public enum ExpirationWarningType
    {
        [Description("On Program Start")]
        OnProgramStart=0,
        [Description("On Program Exit")]
        OnProgramExit=1,
        [Description("On Program Start and Exit")]
        OnProgramStartAndExit = 2,
        [Description("During Operation")]
        DuringOperation = 3,
    }
}
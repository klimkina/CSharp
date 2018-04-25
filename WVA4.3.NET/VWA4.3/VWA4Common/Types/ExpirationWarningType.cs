using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel;

namespace VWA4Common.Security.Types
{
    public enum ExpirationWarningType
    {
        [Description("On Program Start")]
        OnProgramStart = 0,
        [Description("On Program Exit")]
        OnProgramExit = 1,
        [Description("On Program Start and Exit")]
        OnProgramStartAndExit = 2,
        [Description("During Operation")]
        DuringOperation = 3,
    }
}
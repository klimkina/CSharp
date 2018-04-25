using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel;

namespace VWA4Common.Security.Types
{
    public enum DefaultUserLevelType
    {
        [Description("User")]
        User=0,
        [Description("Manager")]
        Manager = 1,
        [Description("Super")]
        Administrator=2
    }
}
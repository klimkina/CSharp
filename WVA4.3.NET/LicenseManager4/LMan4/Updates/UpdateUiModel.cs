using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMan4.com.updatemanager;

namespace LMan4.Updates
{
    public class UpdateUiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UpdateType Type { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

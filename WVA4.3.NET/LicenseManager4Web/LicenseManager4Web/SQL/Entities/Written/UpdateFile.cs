using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicenseManager4Web.Entities.Written
{
    public class UpdateFile
    {
        public Guid Id { get; set; }
        public Guid UpdateId { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public string InstallPath { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Text;

namespace VWA4Common.Security
{
    public static class UpdateData
    {
        public static Guid ApplicationId
        {
            get
            {
                try
                {
                    TextReader tr = new StreamReader("update.dat");
                    // ReSharper disable AssignNullToNotNullAttribute
                    var aid = (Guid)SqlGuid.Parse(tr.ReadLine());
                    // ReSharper restore AssignNullToNotNullAttribute
                    tr.Close();

                    return aid;
                }
                catch(Exception)
                {
                    return Guid.Empty;
                }
            }
            set
            {
                TextWriter tw = new StreamWriter("update.dat", false);
                tw.WriteLine(value);
                tw.Close();
            }
        }
    }
}

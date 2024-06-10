using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outpost31.Core.Configuration;

namespace Outpost31.Core.NtstWebService
{
    public class NtstWebServiceSecurity
    {
        public string WebServiceUser { get; set; }
        public string WebServicePassword { get; set; }

        public static NtstWebServiceSecurity BuildDefaultSecurityObject()
        {
            return new NtstWebServiceSecurity()
            {
                WebServiceUser = "TINGENWEBSERVICE",
                WebServicePassword = "undefined"
            };
        }

        public static NtstWebServiceSecurity Load(string ntstWebServiceSecurityPath, string ntstWebServiceSecurityFileName)
        {
            var ntstWebServiceSecurityFilePath = $@"{ntstWebServiceSecurityPath}\{ntstWebServiceSecurityFileName}";

            if (!File.Exists(ntstWebServiceSecurityFilePath))
            {
                if (!Directory.Exists(ntstWebServiceSecurityPath))
                {
                    Directory.CreateDirectory(ntstWebServiceSecurityPath);
                }

                Utilities.DuJson.ExportToLocalFile<NtstWebServiceSecurity>(BuildDefaultSecurityObject(), ntstWebServiceSecurityFilePath);
            }

            return Utilities.DuJson.ImportFromLocalFile<NtstWebServiceSecurity>(ntstWebServiceSecurityFilePath);
        }
    }
}

/*

-----------------
Development notes
-----------------

*/
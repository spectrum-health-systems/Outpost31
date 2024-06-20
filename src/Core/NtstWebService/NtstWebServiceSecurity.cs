// u240613.1255

using System.IO;

/* This class is not yet implemented, but I'm leaving it here for future reference. 
 */

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

- Not yet implemented.

*/
// u240709.0000_code
// u240709.0000_documentation

using System.IO;

/* PLEASE NOTE
 * This class is not yet implemented, but I'm leaving it here for future reference. 
 */

namespace Outpost31.Core.NtstWebService
{
    /// <summary>TBD</summary>
    public class NtstWebServiceSecurity
    {
        /// <summary>TBD</summary>
        public string WebServiceUser { get; set; }

        /// <summary>TBD</summary>
        public string WebServicePassword { get; set; }

        /// <summary>TBD</summary>
        public static NtstWebServiceSecurity BuildDefaultSecurityObject()
        {
            return new NtstWebServiceSecurity()
            {
                WebServiceUser = "TINGENWEBSERVICE",
                WebServicePassword = "undefined"
            };
        }

        /// <summary>TBD</summary>
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
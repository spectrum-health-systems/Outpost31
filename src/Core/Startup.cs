// u250204_code
// u250204_documentation

using System.IO;
using System.Reflection;

namespace Outpost31.Core
{
    /// <summary>Performs startup processes.</summary>
    /// <include file='XmlDoc/Outpost31.Core_doc.xml' path='Outpost31.Core/Type[@name="Class"]/Startup/*'/>
    public static class Startup
    {
        /// <summary>The executing Assembly name.</summary>
        /// <remarks>A required component for writing log files, defined here so it can be used throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Get the Avatar System Code that the Tingen Web Service will use.</summary>
        /// <returns>The Avatar System Code the Tingen Web Service will use.</returns>
        /// <include file='XmlDoc/Outpost31.Core_doc.xml' path='Outpost31.Core/Type[@name="Method"]/GetSystemCode/*'/>
        public static string GetSystemCode()
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
               * need to create a log file here, use a Primeval Log.
               */

            const string systemCodeFilePath = @"./AppData/Runtime/system.code";
            string systemCode               = "UNKNOWN";

            if (File.Exists(systemCodeFilePath))
            {
                //[?] Test to make sure this works, and the ".ToLower()" doesn't need to be in the if...then statement
                switch (File.ReadAllText(systemCodeFilePath.ToLower()))
                {
                    case "live":
                        systemCode = "LIVE";
                        break;

                    case "uat":
                        systemCode = "UAT";
                        break;
                }
            }

            return systemCode;
        }


        public static string GetTngnMode()
        {


            return "";

        }

    }
}
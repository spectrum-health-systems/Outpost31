// u240818.1245_code
// u240818.1245_documentation

using System.IO;

namespace Outpost31.Core.Configuration
{
    /// <summary>The Tingen configuration settings.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Configuration_doc.xml' path='Outpost31/Cs[@name="ConfigSettings"]/ConfigSettings/*'/>
    public class ConfigSettings
    {
        /// <summary>Determines the available Tingen web service functionality.</summary>
        /// <include file='XmlDoc/Outpost31.Core.Configuration_doc.xml' path='Outpost31/Cs[@name="ConfigSettings"]/TingenMode/*'/>
        public string TingenMode { get; set; }

        /// <summary>Determines the available Open Incident Module functionality.</summary>
        /// <include file='XmlDoc/Outpost31.Core.Configuration_doc.xml' path='Outpost31/Cs[@name="ConfigSettings"]/ModOpenIncidentMode/*'/>
        public string ModOpenIncidentMode { get; set; }

        /// <summary>Determines the available Netsmart web service functionality.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Term[@name="Term"]/NotImplemented/*'/>
        public string NtstWebServicesMode { get; set; }

        /// <summary>Determines the session Trace Log level.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Term[@name="Term"]/TraceLevel/*'/>
        public int TraceLevel { get; set; }

        /// <summary>Determines the Trace Log delay.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Term[@name="Term"]/TraceDelay/*'/>
        public int TraceDelay { get; set; }

        /// <summary>Build a default Tingen configuration object.</summary>
        /// <returns>An data structure with default Tingen configuration values.</returns>
        /// <include file='XmlDoc/Outpost31.Core.Configuration_doc.xml' path='Outpost31/Cs[@name="ConfigSettings"]/BuildDefaultObject/*'/>
        public static ConfigSettings BuildDefaultObject()
        {
            /* [DN01] */

            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
             */

            return new ConfigSettings
            {
                TingenMode          = "enabled",
                ModOpenIncidentMode = "enabled",
                NtstWebServicesMode = "disabled",
                TraceLevel          = 1,
                TraceDelay          = 10
            };
        }

        ///// <summary></summary>
        ///// <param name="configPath">Path to the Tingen configuration file.</param>
        ///// <remarks>
        /////  <para>
        /////   - The configuration file path is created in <b>Tingen.asmx.cs</b><br/>
        /////   -
        /////  </para>
        ///// </remarks>
        ///// <returns>The Tingen configuration settings.</returns>
        /////

        /// <summary>Load the Tingen configuration file.</summary>
        /// <param name="configPath">Path to the Tingen configuration file.</param>
        /// <returns>The necessary AvatarNX data.</returns>
        /// <include file='XmlDoc/Outpost31.Core.Configuration_doc.xml' path='Outpost31/Cs[@name="ConfigSettings"]/Load/*'/>
        public static ConfigSettings Load(string configPath, string configFileName)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
             */

            var configFilePath = $@"{configPath}\{configFileName}";

            if (!File.Exists(configFilePath))
            {
                if (!Directory.Exists(configPath))
                {
                    Directory.CreateDirectory(configPath);
                }

                Utilities.DuJson.ExportToLocalFile<ConfigSettings>(BuildDefaultObject(), configFilePath);
            }

            return Utilities.DuJson.ImportFromLocalFile<ConfigSettings>(configFilePath);
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

-----------------
[DN01] 240818
-----------------
Name this something more descriptive.

*/
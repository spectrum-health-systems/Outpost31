// u240818.1245_code
// 241031_documentation

using System.IO;

namespace Outpost31.Core.Configuration
{
    /// <summary>The Tingen configuration settings.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Configuration.ConfigurationSettings_doc.xml' path='Outpost31.Core.Configuration.ConfigurationSettings/Type[@name="Class"]/ConfigSettings/*'/>
    public class ConfigSettings
    {
        /// <summary>Determines the available Tingen web service functionality.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Modes"]/StandardModes/*'/>
        public string TingenMode { get; set; }

        /// <summary>Determines the available Open Incident Module functionality.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Modes"]/StandardModes/*'/>
        public string ModOpenIncidentMode { get; set; }

        /// <summary>Determines the available Netsmart web service functionality.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Other"]/NotImplemented/*'/>
        public string NtstWebServicesMode { get; set; }

        /// <summary>Determines the session Trace Log level.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Logs"]/TraceLevel/*'/>
        public int TraceLevel { get; set; }

        /// <summary>Determines the Trace Log delay.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Logs"]/TraceDelay/*'/>
        public int TraceDelay { get; set; }

        /* [DN01] */
        /// <summary>Build a default Tingen configuration object.</summary>
        /// <returns>An data structure with default Tingen configuration values.</returns>
        /// <include file='XmlDoc/Outpost31.Core.Configuration.ConfigurationSettings_doc.xml' path='Outpost31.Core.Configuration.ConfigurationSettings/Type[@name="Method"]/BuildDefaultObject/*'/>
        public static ConfigSettings BuildDefaultObject()
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
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

        /// <summary>Load the Tingen configuration file.</summary>
        /// <param name="configPath">Path to the Tingen configuration file.</param>
        /// <returns>The necessary AvatarNX data.</returns>
        /// <include file='XmlDoc/Outpost31.Core.Configuration.ConfigurationSettings_doc.xml' path='Outpost31.Core.Configuration.ConfigurationSettings/Type[@name="Method"]/Load/*'/>
        public static ConfigSettings Load(string configPath, string configFileName)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
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
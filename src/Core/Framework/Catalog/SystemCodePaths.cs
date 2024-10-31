// u240821.1037_code
// u241031_documentation

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>System Code paths for Tingen.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Framework.Catalog.SystemCodePaths_doc.xml' path='Outpost31.Core.Framework.Catalog.SystemCodePaths/Type[@name="Class"]/SystemCodePaths/*'/>
    public class SystemCodePaths
    {
        /// <summary>Root path for System Code data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="RootPath"]/SystemCodeData/*'/>
        public string Root { get; set; }

        /* [DN01] */
        /// <summary>Path for System Code configuration data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="DataPath"]/Config/*'/>
        public string Config { get; set; }

        /// <summary>Path for System Code session data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="DataPath"]/Session/*'/>
        public string Sessions { get; set; }

        /// <summary>Current session path.</summary>
        /// <remarks>This is set at runtime.</remarks>
        public string CurrentSession { get; set; }

        /// <summary>Path for Tingen Extensions.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Other"]/NotImplemented/*'/>
        public string Extensions { get; set; }

        /// <summary>Path for Tingen security-related data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Other"]/NotImplemented/*'/>
        public string Security { get; set; }

        /// <summary>Path for temporary data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="DataPath"]/Temporary/*'/>
        public string Temporary { get; set; }

        /* [DN02] */
        /// <summary>Root for message data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Messages\</c>"</remarks>
        public string MessageRoot { get; set; }

        /// <summary>Path for alert data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/Alerts/*'/>
        public string Alerts { get; set; }

        /// <summary>Path for error data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="DataPath"]/Alerts/*'/>
        public string Errors { get; set; }

        /// <summary>Path for warning data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="DataPath"]/Warnings/*'/>
        public string Warnings { get; set; }

        /* [DN02] */
        /// <summary>Root for exported data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Exports\</c>"</remarks>
        public string ExportRoot { get; set; }

        /// <summary>Path for exported reports.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Exports\Reports\</c>"</remarks>
        public string Reports { get; set; }

        /* [DN02] */
        /// <summary>Root for imported data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Imports\</c>"</remarks>
        public string ImportRoot { get; set; }

        /// <summary>Path for imported data from Avatar.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="DataPath"]/FromAvatar/*'/>
        public string FromAvatar { get; set; }

        /* [DN03] */
        /// <summary>Path for imported templates.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="DataPath"]/Templates/*'/>
        public string Templates { get; set; }

        /* [DN02] */
        /// <summary>Root for support data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Support\</c>"</remarks>
        public string SupportRoot { get; set; }

        /// <summary>Path for admin data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="DataPath"]/Admin/*'/>
        public string Admin { get; set; }

        /// <summary>Path for archived data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="DataPath"]/Archive/*'/>
        public string Archive { get; set; }

        /// <summary>Path for debugging data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="DataPath"]/Debug/*'/>
        public string Debugging { get; set; }

        /// <summary>Path for log data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="DataPath"]/Logs/*'/>
        public string Logs { get; set; }

        /// <summary>Builds the system code paths object.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <param name="avSystemCode">The Avatar System Code.</param>
        /// <returns>The System Code data paths.</returns>
        public static SystemCodePaths BuildObject(string tnDataRoot, string avSystemCode)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

            string systemCodeRoot    = $@"{tnDataRoot}\{avSystemCode}";
            const string messageRoot = "Messages";
            const string exportRoot  = "Exports";
            const string importRoot  = "Imports";
            const string supportRoot = "Support";

            return new SystemCodePaths
            {
                Root           = systemCodeRoot,
                Config         = $@"{systemCodeRoot}\Config",
                Sessions       = $@"{systemCodeRoot}\Sessions",
                CurrentSession = "defined-at-runtime",
                Extensions     = $@"{systemCodeRoot}\Extensions",
                Security       = $@"{systemCodeRoot}\Security",
                MessageRoot    = $@"{systemCodeRoot}\{messageRoot}",
                Alerts         = $@"{systemCodeRoot}\{messageRoot}\Alerts",
                Errors         = $@"{systemCodeRoot}\{messageRoot}\Errors",
                Warnings       = $@"{systemCodeRoot}\{messageRoot}\Warnings",
                ImportRoot     = $@"{systemCodeRoot}\{importRoot}",
                FromAvatar     = $@"{systemCodeRoot}\{importRoot}\FromAvatar",
                Templates      = $@"{systemCodeRoot}\{importRoot}\Templates",
                ExportRoot     = $@"{systemCodeRoot}\{exportRoot}",
                Reports        = $@"{systemCodeRoot}\{exportRoot}\Reports",
                SupportRoot    = $@"{systemCodeRoot}\{supportRoot}",
                Admin          = $@"{systemCodeRoot}\{supportRoot}\Admin",
                Archive        = $@"{systemCodeRoot}\{supportRoot}\Archive",
                Debugging      = $@"{systemCodeRoot}\{supportRoot}\Debugging",
                Logs           = $@"{systemCodeRoot}\{supportRoot}\Logs",
                Temporary      = $@"{systemCodeRoot}\Temporary"
            };
        }

        /// <summary>Returns a list of required System Code paths.</summary>
        /// <param name="systemCodePaths">The System Code paths.</param>
        /// <returns>The list of required System Code paths.</returns>
        public static List<string> RequiredPaths(SystemCodePaths systemCodePaths)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

            return new List<string>
            {
                systemCodePaths.Root,
                systemCodePaths.Config,
                systemCodePaths.Sessions,
                systemCodePaths.CurrentSession,
                systemCodePaths.Extensions,
                systemCodePaths.Security,
                systemCodePaths.Temporary,
                systemCodePaths.MessageRoot,
                systemCodePaths.Alerts,
                systemCodePaths.Errors,
                systemCodePaths.Warnings,
                systemCodePaths.ExportRoot,
                systemCodePaths.Reports,
                systemCodePaths.ImportRoot,
                systemCodePaths.FromAvatar,
                systemCodePaths.Templates,
                systemCodePaths.SupportRoot,
                systemCodePaths.Admin,
                systemCodePaths.Archive,
                systemCodePaths.Debugging,
                systemCodePaths.Logs
            };
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

-----------------
[DN01] 241018
-----------------
Rename this to SystemCodeConfig?

-----------------
[DN02] 241018
-----------------
Rename or better documentation for these.

-----------------
[DN03] 241018
-----------------
Rename to "tinplates"

*/
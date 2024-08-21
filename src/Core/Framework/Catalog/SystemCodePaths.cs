// u240821.1037_code
// u240821.1020_documentation

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>System Code paths for Tingen.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31/Cs[@name="SystemCodePaths"]/SystemCodePaths/*'/>
    public class SystemCodePaths
    {
        /// <summary>Root path for System Code data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\</c>"</remarks>
        public string Root { get; set; }

        /// <summary>Path for System Code configuration data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Config\</c>"</remarks>
        public string Config { get; set; }

        /// <summary>Path for System Code session data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Sessions\</c>"</remarks>
        public string Sessions { get; set; }

        /// <summary>Current session path.</summary>
        /// <remarks>This is set at runtime.</remarks>
        public string CurrentSession { get; set; }

        /// <summary>Path for Tingen Extensions.</summary>
        /// <remarks>Future functionality.</remarks>
        public string Extensions { get; set; }

        /// <summary>Path for Tingen security-related data.</summary>
        /// <remarks>Future functionality.</remarks>
        public string Security { get; set; }

        /// <summary>Path for temporary data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\</c>"</remarks>
        public string Temporary { get; set; }

        /// <summary>Root for message data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Messages\</c>"</remarks>
        public string MessageRoot { get; set; }

        /// <summary>Path for alert data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\MessagesAlerts\</c>"</remarks>
        public string Alerts { get; set; }

        /// <summary>Path for error data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\MessagesErrors\</c>"</remarks>
        public string Errors { get; set; }

        /// <summary>Path for warning data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\MessagesWarnings\</c>"</remarks>
        public string Warnings { get; set; }

        /// <summary>Root for exported data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Exports\</c>"</remarks>
        public string ExportRoot { get; set; }

        /// <summary>Path for exported reports.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Exports\Reports\</c>"</remarks>
        public string Reports { get; set; }

        /// <summary>Root for imported data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Imports\</c>"</remarks>
        public string ImportRoot { get; set; }

        /// <summary>Path for imported data from Avatar.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Imports\FromAvatar\</c>"</remarks>
        public string FromAvatar { get; set; }

        /// <summary>Path for imported templates.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Imports\Templates\</c>"</remarks>
        public string Templates { get; set; }

        /// <summary>Root for support data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Support\</c>"</remarks>
        public string SupportRoot { get; set; }

        /// <summary>Path for admin data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Support\Admin\</c>"</remarks>
        public string Admin { get; set; }

        /// <summary>Path for archived data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Support\Archive\</c>"</remarks>
        public string Archive { get; set; }

        /// <summary>Path for debugging data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Support\Debugging\</c>"</remarks>
        public string Debugging { get; set; }

        /// <summary>Path for log data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\%SystemCode%\Support\Logs\</c>"</remarks>
        public string Logs { get; set; }

        /// <summary>Builds the system code paths object.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <param name="avSystemCode">The Avatar System Code.</param>
        /// <returns>The System Code data paths.</returns>
        public static SystemCodePaths BuildObject(string tnDataRoot, string avSystemCode)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
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
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
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
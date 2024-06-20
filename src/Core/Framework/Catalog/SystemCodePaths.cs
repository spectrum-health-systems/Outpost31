// u240617.1031

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>System code paths for Tingen.</summary>
    /// <remarks>
    ///  <para>
    ///   - More comments here, but this is the important stuff.
    ///  </para>
    /// </remarks>
    public class SystemCodePaths
    {
        /* System code paths.
         */

        /// <summary>Root path for system code files.</summary>
        /// <value>C:\TingenData\%SystemCode%</value>
        public string Root { get; set; }

        /// <summary>Path for system code configuration files.</summary>
        /// <value>C:\TingenData\%SystemCode%\Config</value>
        public string Config { get; set; }

        /// <summary>Path for system code session files.</summary>
        /// <value>C:\TingenData\%SystemCode%\Sessions</value>
        public string Sessions { get; set; }

        /// <summary>Current session path.</summary>
        /// <remarks>
        ///  <para>
        ///   - Set at runtime.
        ///  </para>
        /// </remarks>
        public string CurrentSession { get; set; }

        /// <summary>Path for Tingen Extensions.</summary>
        /// <remarks>
        ///  <para>
        ///   - Future functionality.
        ///  </para>
        /// </remarks>
        public string Extensions { get; set; }

        /// <summary>Path for Tingen security-related files.</summary>
        /// <remarks>
        ///  <para>
        ///   - Future functionality.
        ///  </para>
        /// </remarks>
        public string Security { get; set; }

        /// <summary>Path for temporary files.</summary>
        /// <remarks>
        ///  <para>
        ///   - Temporary files.
        ///  </para>
        /// </remarks>
        public string Temporary { get; set; }

        /* Message paths
         */

        /// <summary>Root for message files.</summary>
        /// <value>C:\TingenData\%SystemCode%\Messages</value>
        public string MessageRoot { get; set; }

        /// <summary>Path for alert messages.</summary>
        /// <value>C:\TingenData\%SystemCode%\Messages\Alerts</value>
        public string Alerts { get; set; }

        /// <summary>Path for error messages.</summary>
        /// <value>C:\TingenData\%SystemCode%\Messages\Errors</value>
        public string Errors { get; set; }

        /// <summary>Path for warning messages.</summary>
        /// <value>C:\TingenData\%SystemCode%\Messages\Warnings</value>
        public string Warnings { get; set; }

        /* Exported data paths
         */

        /// <summary>Root for exported data files.</summary>
        /// <value>C:\TingenData\%SystemCode%\Exports</value>
        public string ExportRoot { get; set; }

        /// <summary>Path for exported reports.</summary>
        /// <value>C:\TingenData\%SystemCode%\Exports\Reports</value>
        public string Reports { get; set; }

        /* Imported data paths
         */

        /// <summary>Root for imported data files.</summary>
        /// <value>C:\TingenData\%SystemCode%\Imports</value>
        public string ImportRoot { get; set; }

        /// <summary>Path for imported data from Avatar.</summary>
        /// <value>C:\TingenData\%SystemCode%\Imports\FromAvatar</value>
        public string FromAvatar { get; set; }

        /// <summary>Path for imported templates.</summary>
        /// <value>C:\TingenData\%SystemCode%\Imports\Templates</value>
        public string Templates { get; set; }

        /* Support paths
         */

        /// <summary>Root for support files.</summary>
        /// <value>C:\TingenData\%SystemCode%\Support</value>
        public string SupportRoot { get; set; }

        /// <summary>Path for admin files.</summary>
        /// <value>C:\TingenData\%SystemCode%\Support\Admin</value>
        public string Admin { get; set; }

        /// <summary>Path for archived files.</summary>
        /// <value>C:\TingenData\%SystemCode%\Support\Archive</value>
        public string Archive { get; set; }

        /// <summary>Path for debugging files.</summary>
        /// <value>C:\TingenData\%SystemCode%\Support\Debugging</value>
        public string Debugging { get; set; }

        /// <summary>Path for log files.</summary>
        /// <value>C:\TingenData\%SystemCode%\Support\Logs</value>
        public string Logs { get; set; }

        /// <summary>Builds the system code paths object.</summary>
        /// <param name="tnDataRoot"></param>
        /// <param name="avSystemCode"></param>
        /// <returns></returns>
        public static SystemCodePaths BuildObject(string tnDataRoot, string avSystemCode)
        {
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
                CurrentSession = "not-defined-yet",
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

        /// <summary>Returns a list of required paths.</summary>
        /// <param name="systemCodePaths"></param>
        /// <returns></returns>
        public static List<string> RequiredPaths(SystemCodePaths systemCodePaths)
        {
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

-----------------
Development notes
-----------------

- Review all XML comments.
- Better way to do RequiredPaths()?

*/
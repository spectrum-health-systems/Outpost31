// u240607.1011

using System.Collections.Generic;
using System.Security.Permissions;

namespace Outpost31.Core.Framework.Catalog
{
    public class SystemCodePaths
    {
        /* System code paths.
         */
        public string Root { get; set; }
        public string Config { get; set; }
        public string Sessions { get; set; }
        public string CurrentSession { get; set; }
        public string Extensions { get; set; }
        public string Security { get; set; }
        public string Temporary { get; set; }

        /* Message paths
         */
        public string MessageRoot { get; set; }
        public string Alerts { get; set; }
        public string Errors { get; set; }
        public string Warnings { get; set; }

        /* Exported data paths
         */
        public string ExportRoot { get; set; }
        public string Reports { get; set; }

        /* Imported data paths
         */
        public string ImportRoot { get; set; }
        public string FromAvatar { get; set; }
        public string Templates { get; set; }

        /* Support paths
         */
        public string SupportRoot {get; set; }
        public string Admin { get; set; }
        public string Archive { get; set; }
        public string Debugging { get; set; }
        public string Logs { get; set; }




        public static SystemCodePaths BuildObject(string tnDataRoot, string avSystemCode)
        {
            var systemCodeRoot = $@"{tnDataRoot}\{avSystemCode}";
            var messageRoot    = "Messages";
            var exportRoot     = "Exports";
            var importRoot     = "Imports";
            var supportRoot    = "Support";



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

*/
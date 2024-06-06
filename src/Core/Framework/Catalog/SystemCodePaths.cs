using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    public class SystemCodePaths
    {
        public string Root { get; set; }
        public string Admin { get; set; }
        public string Archive { get; set; }
        public string Config { get; set; }
        public string Debug { get; set; }
        public string Extensions { get; set; }
        public string Logs { get; set; }
        public string Alerts { get; set; }
        public string Errors { get; set; }
        public string Warnings { get; set; }
        public string ExportData { get; set; }
        public string ImportData { get; set; }
        public string Reports { get; set; }
        public string Sessions { get; set; }

        public string CurrentSession { get; set; }
        public string Templates { get; set; }
        public string Temporary { get; set; }


        public static SystemCodePaths Build(string tingenDataRoot, string avatarSystemCode)
        {
            var systemCodeRoot = $@"{tingenDataRoot}\{avatarSystemCode}";

            return new SystemCodePaths
            {
                Root           = systemCodeRoot,
                Admin          = $@"{systemCodeRoot}\Admin",
                Alerts         = $@"{systemCodeRoot}\Alerts",
                Archive        = $@"{systemCodeRoot}\Archive",
                Config         = $@"{systemCodeRoot}\Config",
                CurrentSession = "not-defined-yet",
                Debug          = $@"{systemCodeRoot}\Debug",
                Errors         = $@"{systemCodeRoot}\Errors",
                ExportData     = $@"{systemCodeRoot}\ExportData",
                Extensions     = $@"{systemCodeRoot}\Extensions",
                ImportData     = $@"{systemCodeRoot}\ImportData",
                Logs           = $@"{systemCodeRoot}\Logs",
                Reports        = $@"{systemCodeRoot}\Reports",
                Sessions       = $@"{systemCodeRoot}\Sessions",
                Templates      = $@"{systemCodeRoot}\Templates",
                Temporary      = $@"{systemCodeRoot}\Temporary",
                Warnings       = $@"{systemCodeRoot}\Warnings"
            };
        }

        public static List<string> Required(SystemCodePaths systemCodePaths)
        {
            return new List<string>
            {
                systemCodePaths.Root,
                systemCodePaths.Admin,
                systemCodePaths.Archive,
                systemCodePaths.Config,
                systemCodePaths.Debug,
                systemCodePaths.Extensions,
                systemCodePaths.Logs,
                systemCodePaths.Alerts,
                systemCodePaths.Errors,
                systemCodePaths.Warnings,
                systemCodePaths.ExportData,
                systemCodePaths.ImportData,
                systemCodePaths.Reports,
                systemCodePaths.Sessions,
                systemCodePaths.CurrentSession,
                systemCodePaths.Templates,
                systemCodePaths.Temporary
            };
        }
    }
}

/*
Development notes
-----------------

*/
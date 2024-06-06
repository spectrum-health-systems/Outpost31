// u240605.1106

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    public class RemotePaths
    {
        public string Root { get; set; }
        public string Alerts { get; set; }
        public string Errors { get; set; }
        public string ExportData { get; set; }
        public string Reports { get; set; }
        public string Warnings { get; set; }

        public static RemotePaths Build(string tingenDataRoot)
        {
            var remoteRoot = $@"{tingenDataRoot}\Remote\";

            return new RemotePaths
            {
                Root       = remoteRoot,
                Alerts     = $@"{remoteRoot}\Alerts",
                Errors     = $@"{remoteRoot}\Errors",
                ExportData = $@"{remoteRoot}\ExportData",
                Reports    = $@"{remoteRoot}\Reports",
                Warnings   = $@"{remoteRoot}\Warnings"
            };
        }

        public static List<string> Required(RemotePaths remotePaths)
        {
            return new List<string>
            {
                remotePaths.Root,
                remotePaths.Alerts,
                remotePaths.Errors,
                remotePaths.ExportData,
                remotePaths.Reports,
                remotePaths.Warnings
            };
        }

    }
}

/*
Development notes
-----------------

*/
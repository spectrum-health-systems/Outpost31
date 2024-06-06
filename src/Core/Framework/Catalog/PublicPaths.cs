// u240605.1157

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    public class PublicPaths
    {
        public string Root { get; set; }
        public string Alerts { get; set; }
        public string Errors { get; set; }
        public string ExportData { get; set; }
        public string Reports { get; set; }
        public string Warnings { get; set; }

        public static PublicPaths Build(string tingenDataRoot)
        {
            var publicRoot = $@"{tingenDataRoot}\Public\";

            return new PublicPaths
            {
                Root       = publicRoot,
                Alerts     = $@"{publicRoot}\Alerts",
                Errors     = $@"{publicRoot}\Errors",
                ExportData = $@"{publicRoot}\ExportData",
                Reports    = $@"{publicRoot}\Reports",
                Warnings   = $@"{publicRoot}\Warnings"
            };
        }

        public static List<string> Required(PublicPaths publicPaths)
        {
            return new List<string>
            {
                publicPaths.Root,
                publicPaths.Alerts,
                publicPaths.Errors,
                publicPaths.ExportData,
                publicPaths.Reports,
                publicPaths.Warnings
            };
        }
    }
}

/*
Development notes
-----------------

*/
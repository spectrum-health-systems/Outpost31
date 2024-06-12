// u240607.1009

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    public class PublicPaths
    {
        public string Root { get; set; }
        public string Alerts { get; set; }
        public string Errors { get; set; }
        public string Exports { get; set; }
        public string Reports { get; set; }
        public string Warnings { get; set; }

        public static PublicPaths BuildObject(string tnDataRoot)
        {
            var publicRoot = $@"{tnDataRoot}\Public\";

            return new PublicPaths
            {
                Root     = publicRoot,
                Alerts   = $@"{publicRoot}\Alerts",
                Errors   = $@"{publicRoot}\Errors",
                Exports  = $@"{publicRoot}\Exports",
                Reports  = $@"{publicRoot}\Reports",
                Warnings = $@"{publicRoot}\Warnings"
            };
        }

        public static List<string> RequiredPaths(PublicPaths publicPaths)
        {
            return new List<string>
            {
                publicPaths.Root,
                publicPaths.Alerts,
                publicPaths.Errors,
                publicPaths.Exports,
                publicPaths.Reports,
                publicPaths.Warnings
            };
        }
    }
}

/*

-----------------
Development notes
-----------------

*/
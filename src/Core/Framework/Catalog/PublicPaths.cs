// u240821.0938_code
// u240821.0938_documentation

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>Public paths for Tingen.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31/Cs[@name="PublicPaths"]/PublicPaths/*'/>
    public class PublicPaths
    {
        /// <summary>The root path for public data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Public\</c>"</remarks>
        public string Root { get; set; }

        /// <summary>The public path for alerts.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Public\Alerts\</c>"</remarks>
        public string Alerts { get; set; }

        /// <summary>Path for public error messages.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Public\Errors\</c>"</remarks>
        public string Errors { get; set; }

        /// <summary>Path for public exported data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Public\Exports\</c>"</remarks>
        public string Exports { get; set; }

        /// <summary>Path for public reports.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Public\Reports\</c>"</remarks>
        public string Reports { get; set; }

        /// <summary>Path for public warning messages.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Public\Warnings\</c>"</remarks>
        public string Warnings { get; set; }

        /// <summary>Builds the public paths data structure.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <returns>The Tingen public paths data structure.</returns>
        public static PublicPaths BuildObject(string tnDataRoot)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
             */

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

        /// <summary>Returns a list of required public paths.</summary>
        /// <param name="publicPaths">The Tingen public paths.</param>
        /// <returns>The list of required public paths.</returns>
        public static List<string> RequiredPaths(PublicPaths publicPaths)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
             */

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
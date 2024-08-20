// u240709.0000_code
// u240709.0000_documentation

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>Public paths for Tingen.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31/Cs[@name="PublicPaths"]/PublicPaths/*'/>
    public class PublicPaths
    {
        /// <summary>The root path for public data.</summary>
        /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31/Cs[@name="PublicPaths"]/Root/*'/>
        public string Root { get; set; }

        /// <summary>The public path for alerts.</summary>
        /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31/Cs[@name="PublicPaths"]/Alerts/*'/>
        public string Alerts { get; set; }

        /// <summary>Path for public error data.</summary>
        /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31/Cs[@name="PublicPaths"]/Errors/*'/>
        public string Errors { get; set; }

        /// <summary>Path for public export data.</summary>
        /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31/Cs[@name="PublicPaths"]/Exports/*'/>
        public string Exports { get; set; }

        /// <summary>Path for public report data.</summary>
        // <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31/Cs[@name="PublicPaths"]/Reports/*'/>
        public string Reports { get; set; }

        /// <summary>Path for public warning data.</summary>
        /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31/Cs[@name="PublicPaths"]/Warnings/*'/>
        public string Warnings { get; set; }

        /// <summary>Builds the public paths object.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <returns>A collection of public paths.</returns>
        /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31/Cs[@name="PublicPaths"]/BuildObject/*'/>
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
        /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31/Cs[@name="PublicPaths"]/RequiredPaths/*'/>
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
// u240821.0938_code
// u241021_documentation

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>Public paths for Tingen.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31.Core.Framework/Cs[@name="PublicPaths"]/PublicPaths/*'/>
    public class PublicPaths
    {
        /// <summary>The root path for public data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Public\</c>"</remarks>
        public string Root { get; set; }

        /// <summary>The public path for alerts.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/Alerts/*'/>
        public string Alerts { get; set; }

        /// <summary>Path for public error messages.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/Errors/*'/>
        public string Errors { get; set; }

        /// <summary>Path for public exported data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/Exports/*'/>
        public string Exports { get; set; }

        /// <summary>Path for public reports.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/Reports/*'/>
        public string Reports { get; set; }

        /// <summary>Path for public warning messages.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/Warnings/*'/>
        public string Warnings { get; set; }

        /// <summary>Builds the public paths data structure.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <returns>The Tingen public paths data structure.</returns>
        public static PublicPaths BuildObject(string tnDataRoot)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been been initialized yet, so if you
             * need to create a logfile here, use a Primeval Log.
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
            /* Trace Logs can't go here because the logging infrastructure hasn't been been initialized yet, so if you
             * need to create a logfile here, use a Primeval Log.
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

/*
=================
DEVELOPMENT NOTES
=================

None.

*/
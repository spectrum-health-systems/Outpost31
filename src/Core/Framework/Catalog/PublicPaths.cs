// u240620.1221

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>Public paths for Tingen.</summary>
    /// <remarks>
    ///  <para>
    ///   - Public paths are used to store data that is accessible to specific users that have access to these locations.
    ///  </para>
    /// </remarks>
    public class PublicPaths
    {
        /// <summary>Root path for public data.</summary>
        /// <value>C:\TingenData\Public</value>
        public string Root { get; set; }

        /// <summary>Path for public alert data.</summary>
        /// <value>C:\TingenData\Public\Alerts</value>
        public string Alerts { get; set; }

        /// <summary>Path for public error data.</summary>
        /// <value>C:\TingenData\Public\Errors</value>
        public string Errors { get; set; }

        /// <summary>Path for public export data.</summary>
        /// <value
        public string Exports { get; set; }

        /// <summary>Path for public report data.</summary>
        /// <value>C:\TingenData\Public\Reports</value>
        public string Reports { get; set; }

        /// <summary>Path for public warning data.</summary>
        /// <value>C:\TingenData\Public\Warnings</value>
        public string Warnings { get; set; }

        /// <summary>Builds the public paths object.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <returns>A collection of public paths.</returns>
        public static PublicPaths BuildObject(string tnDataRoot)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

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
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

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

- Better way to do RequiredPaths()?

*/
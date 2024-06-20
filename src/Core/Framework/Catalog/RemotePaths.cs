// u240620.1226

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>Remote paths for Tingen.</summary>
    /// <remarks>
    ///  <para>
    ///   - Remote paths are used to store data that is accessible to specific users that have access to these locations.
    ///  </para>
    /// </remarks>
    public class RemotePaths
    {
        /// <summary>Root path for remote data.</summary>
        /// <value>C:\TingenData\Remote</value>
        public string Root { get; set; }

        /// <summary>Path for remote alert data.</summary>
        /// <value>C:\TingenData\Remote\Alerts</value>
        public string Alerts { get; set; }

        /// <summary>Path for remote error data.</summary>
        /// <value>C:\TingenData\Remote\Errors</value>
        public string Errors { get; set; }

        /// <summary>Path for remote export data.</summary>
        /// <value>C:\TingenData\Remote\Exports</value>
        public string Exports { get; set; }

        /// <summary>Path for remote report data.</summary>
        /// <value>C:\TingenData\Remote\Reports</value>
        public string Reports { get; set; }

        /// <summary>Path for remote session data.</summary>
        /// <value>C:\TingenData\Remote\Sessions</value>
        public string Sessions { get; set; }

        /// <summary>Current session path.</summary>
        /// <remarks>
        ///  <para>
        ///   - Set at runtime.
        ///  </para>
        /// </remarks>
        public string CurrentSession { get; set; }

        /// <summary>Path for remote warning files.</summary>
        /// <value>C:\TingenData\Remote\Warnings</value>
        public string Warnings { get; set; }

        /// <summary>Builds the remote paths object.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <returns>A collection of remote paths.</returns>
        public static RemotePaths BuildObject(string tnDataRoot)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            var remoteRoot = $@"{tnDataRoot}\Remote\";

            return new RemotePaths
            {
                Root           = remoteRoot,
                Alerts         = $@"{remoteRoot}\Alerts",
                Errors         = $@"{remoteRoot}\Errors",
                Exports        = $@"{remoteRoot}\Exports",
                Reports        = $@"{remoteRoot}\Reports",
                Sessions       = $@"{remoteRoot}\Sessions",
                CurrentSession = "undefined",
                Warnings       = $@"{remoteRoot}\Warnings"
            };
        }

        /// <summary>Returns a list of required paths.</summary>
        /// <param name="remotePaths">The Tingen remote paths.</param>
        /// <returns>The list of required remote paths.</returns>
        public static List<string> RequiredPaths(RemotePaths remotePaths)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            return new List<string>
            {
                remotePaths.Root,
                remotePaths.Alerts,
                remotePaths.Errors,
                remotePaths.Exports,
                remotePaths.Reports,
                remotePaths.Sessions,
                remotePaths.Warnings
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
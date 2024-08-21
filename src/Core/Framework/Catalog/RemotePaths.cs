// u2240821.1008_code
// u240821.1008_documentation

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
        /// <remarks>Should be "<c>%tnDataRoot%\Remote</c>"</remarks>
        public string Root { get; set; }

        /// <summary>Path for remote alert data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Remote\Alerts\</c>"</remarks>
        public string Alerts { get; set; }

        /// <summary>Path for remote error data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Remote\Errors\</c>"</remarks>
        public string Errors { get; set; }

        /// <summary>Path for remote export data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Remote\Exports\</c>"</remarks>
        public string Exports { get; set; }

        /// <summary>Path for remote report data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Remote\Reports\</c>"</remarks>
        public string Reports { get; set; }

        /// <summary>Path for remote session data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Remote\Sessions\</c>"</remarks>
        public string Sessions { get; set; }

        /// <summary>Current session path.</summary>
        /// <remarks>This is set at runtime.</remarks>
        public string CurrentSession { get; set; }

        /// <summary>Path for remote warning files.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Remote\Warnings\</c>"</remarks>
        public string Warnings { get; set; }

        /// <summary>Builds the remote paths object.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <returns>The Tingen remote paths data structure.</returns>
        public static RemotePaths BuildObject(string tnDataRoot)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
             */

            var remoteRoot = $@"{tnDataRoot}\Remote\";

            return new RemotePaths
            {
                Root           = remoteRoot,
                Alerts         = $@"{remoteRoot}\Alerts",
                Errors         = $@"{remoteRoot}\Errors",
                Exports        = $@"{remoteRoot}\Exports",
                Reports        = $@"{remoteRoot}\Reports",
                Sessions       = $@"{remoteRoot}\Sessions",
                CurrentSession = "set-at-runtime",
                Warnings       = $@"{remoteRoot}\Warnings"
            };
        }

        /// <summary>Returns a list of required paths.</summary>
        /// <param name="remotePaths">The Tingen remote paths.</param>
        /// <returns>The list of required remote paths.</returns>
        public static List<string> RequiredPaths(RemotePaths remotePaths)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
             */

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
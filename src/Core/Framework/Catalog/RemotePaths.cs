// u2240617.1023

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>Remote paths for Tingen.</summary>
    public class RemotePaths
    {
        /// <summary>Root path for remote files.</summary>
        /// <value>C:\TingenData\Remote</value>
        public string Root { get; set; }

        /// <summary>Path for remote alert files.</summary>
        /// <value>C:\TingenData\Remote\Alerts</value>
        public string Alerts { get; set; }

        /// <summary>Path for remote error files.</summary>
        /// <value>C:\TingenData\Remote\Errors</value>
        public string Errors { get; set; }

        /// <summary>Path for remote export files.</summary>
        /// <value>C:\TingenData\Remote\Exports</value>
        public string Exports { get; set; }

        /// <summary>Path for remote report files.</summary>
        /// <value>C:\TingenData\Remote\Reports</value>
        public string Reports { get; set; }

        /// <summary>Path for remote session files.</summary>
        /// <value>C:\TingenData\Remote\Sessions</value>
        public string Sessions { get; set; }

        /// <summary>Current session path.</summary>
        /// <remarks>
        ///  <para>
        ///   - Set at runtime.
        ///  </para>
        /// </remarks>>
        public string CurrentSession { get; set; }

        /// <summary>Path for remote warning files.</summary>
        /// <value>C:\TingenData\Remote\Warnings</value>
        public string Warnings { get; set; }

        /// <summary>Builds the remote path object.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <returns>The remote paths</returns>
        public static RemotePaths BuildObject(string tnDataRoot)
        {
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
        /// <param name="remotePaths"></param>
        /// <returns></returns>
        public static List<string> RequiredPaths(RemotePaths remotePaths)
        {
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

-----------------
Development notes
-----------------

- Better way to do RequiredPaths()?

*/
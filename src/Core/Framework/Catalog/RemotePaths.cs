// u2240821.1008_code
// u241021_documentation

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>Remote paths for Tingen.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31.Core.Framework/Cs[@name="RemotePaths"]/RemotePaths/*'/>
    public class RemotePaths
    {
        /// <summary>Root path for remote data.</summary>
        /// <remarks>Should be "<c>%tnDataRoot%\Remote</c>"</remarks>
        public string Root { get; set; }

        /// <summary>Path for remote alert data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/Alerts/*'/>
        public string Alerts { get; set; }

        /// <summary>Path for remote error data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/Errors/*'/>
        public string Errors { get; set; }

        /// <summary>Path for remote export data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/Exports/*'/>
        public string Exports { get; set; }

        /// <summary>Path for remote report data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/Reports/*'/>
        public string Reports { get; set; }

        /* [DN01] */
        /// <summary>Path for remote session data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/Sessions/*'/>
        public string Sessions { get; set; }

        /* [DN01] */
        /// <summary>Current session path.</summary>
        /// <remarks>This is set at runtime.</remarks>
        public string CurrentSession { get; set; }

        /// <summary>Path for remote warning files.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/Warnings/*'/>
        public string Warnings { get; set; }

        /// <summary>Builds the remote paths object.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <returns>The Tingen remote paths data structure.</returns>
        public static RemotePaths BuildObject(string tnDataRoot)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been been initialized yet, so if you
             * need to create a logfile here, use a Primeval Log.
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
            /* Trace Logs can't go here because the logging infrastructure hasn't been been initialized yet, so if you
             * need to create a logfile here, use a Primeval Log.
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

/*
=================
DEVELOPMENT NOTES
=================

-----------------
[DN01] 241018
-----------------
Rename these to "SessionData" and "CurrentSessionData"?

*/
// u240605.1536

using System.Collections.Generic;
using Microsoft.SqlServer.Server;

namespace Outpost31.Core.Framework
{
    /// <summary>This class contains pre-defined information for the Tingen Framework.</summary>
    public static class FrameworkCatalog
    {
        /// <summary>Build data paths.</summary>
        /// <remarks>
        ///  <para>
        ///   - Defined here so they are in one location, can be easily changed, and used in multiple classes.<br/>
        ///   - When a new path is added to <b>TingenFramework.Properties.cs</b>, a new entry needs to be added here.
        ///  </para>
        /// </remarks>
        public static Dictionary<string, string> DataPaths(string dataRoot, string systemCode, string avatarUserName, string datestamp, string timestamp, string scriptParameter)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            return new Dictionary<string, string>
            {
                { "TingenDataRoot",   $@"{dataRoot}" },
                { "AvatarSystemCode", $@"{dataRoot}\{systemCode}" },
                { "RawDataRoot",      $@"{dataRoot}\{systemCode}\RawData" },
                { "MessageRoot",      $@"{dataRoot}\{systemCode}\Message" },
                { "PublicRoot",       $@"{dataRoot}\Public"},
                { "RemoteRoot",       $@"{dataRoot}\Remote" },
                { "Admin",            $@"{dataRoot}\{systemCode}\Admin" },
                { "Alert",            $@"{dataRoot}\{systemCode}\Message\Alert" },
                { "Archive",          $@"{dataRoot}\{systemCode}\Archive" },
                { "Config",           $@"{dataRoot}\{systemCode}\Config" },
                { "Debug",            $@"{dataRoot}\{systemCode}\Debug" },
                { "Error",            $@"{dataRoot}\{systemCode}\Message\Error" },
                { "Export",           $@"{dataRoot}\{systemCode}\RawData\Export" },
                { "Extension",        $@"{dataRoot}\{systemCode}\Extension" },
                { "Import",           $@"{dataRoot}\{systemCode}\RawData\Import" },
                { "Log",              $@"{dataRoot}\{systemCode}\Log" },
                { "Report",           $@"{dataRoot}\{systemCode}\Report" },
                { "Session",          $@"{dataRoot}\{systemCode}\Session\{datestamp}\{avatarUserName}\{timestamp}-{scriptParameter}" },
                { "Template",         $@"{dataRoot}\{systemCode}\Template" },
                { "Temporary",        $@"{dataRoot}\{systemCode}\Temporary" },
                { "Warning",          $@"{dataRoot}\{systemCode}\Message\Warning" },
                { "PublicAlert",      $@"{dataRoot}\Public\Alert" },
                { "PublicError",      $@"{dataRoot}\Public\Error" },
                { "PublicExport",     $@"{dataRoot}\Public\Export" },
                { "PublicReport",     $@"{dataRoot}\Public\Report" },
                { "PublicWarning",    $@"{dataRoot}\Public\Warning" },
                { "RemoteAlert",      $@"{dataRoot}\Remote\Alert" },
                { "RemoteError",      $@"{dataRoot}\Remote\Error" },
                { "RemoteExport",     $@"{dataRoot}\Remote\Export" },
                { "RemoteReport",     $@"{dataRoot}\Remote\Report" },
                { "RemoteWarning",    $@"{dataRoot}\Remote\Warning" }
            };
        }

        /// <summary>List of paths where service status files are located.</summary>
        /// <param name="tnFramework">The Tingen Framework object.</param>
        /// <remarks>
        ///  <para>
        ///   - A <i>service status file</i> is a file that contains information about the web-service.<br/>
        ///   - Examples of service status files are <b>Current-Tingen-%SystemCode%Settings.md</b> and the <b>MODE-FILE</b>.<br/>
        ///   - Service status file should be located in a few places so different groups/staff have access to them.
        ///  </para>
        /// </remarks>
        /// <returns>Paths for the service status files locations.</returns>
        public static List<string> ServiceStatusUpdatePaths(TingenFramework framework)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            return new List<string>
            {
                framework.DataRoot.Tingen,
                framework.DataRoot.SystemCode,
                framework.DataRoot.Remote
            };
        }
    }
}

/*

Development notes
-----------------

- Review DataPaths() method to make sure it is valid, accurate, and effecient
- Make sure all of these locations are verified in an efficient manner

*/
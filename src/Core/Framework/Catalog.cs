// u240603.1707

using System.Collections.Generic;
using System.Reflection;

namespace Outpost31.Core.Framework
{
    /// <summary>This class contains pre-defined information for the Tingen Framework.</summary>
    public static class Catalog
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Executing assembly is defined here so it can be used when creating log files.
        ///   </para>
        /// </remarks>
        public static string Asm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Create postfixes for Tingen directory paths.</summary>
        /// <remarks>
        ///  <para>
        ///   These are defined here so they are in one location, can be easily changed, and used in multiple classes.<br/><br/>
        ///   When a new path property is added to TingenFramework.Properties.cs, a new entry needs to be added here.
        ///  </para>
        /// </remarks>
        public static Dictionary<string, string> DataPaths(string dataRoot, string systemCode, string date)
        {
            /* <!-- For debugging: LogEvent.Primeval(asm); --> */ // To be removed.

            return new Dictionary<string, string>
            {
                { "TingenDataRoot",   $@"{dataRoot}" },
                { "AvatarSystemCode", $@"{dataRoot}\{systemCode}" },
                { "RawDataRoot",      $@"{dataRoot}\{systemCode}\RawData" },
                { "MessageRoot",      $@"{dataRoot}\{systemCode}\Message" },
                { "PublicRoot",       $@"{dataRoot}\Public"},
                { "RemoteRoot",       $@"{dataRoot}\Remote" },
                { "SessionRoot",      $@"{dataRoot}\{systemCode}\Session\{date}" },
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

        /// <summary>Create a list of paths where service status files are located.</summary>
        /// <param name="tnFramework">The Tingen Framework object.</param>
        /// <remarks>
        ///  <para>
        ///   The ServiceStatusPaths should be in a few places, so different groups/staff/applications have access to them.
        ///  </para>
        /// </remarks>
        /// <returns>Paths for the service status files locations.</returns>
        public static List<string> ServiceStatusPaths(TingenFramework framework)
        {
            /* <!-- For debugging: LogEvent.Primeval(asm); --> */ // To be removed.

            return new List<string>
            {
                framework.DataRoot.Tingen,
                framework.DataRoot.SystemCode,
                framework.DataRoot.Remote
            };
        }
    }
}
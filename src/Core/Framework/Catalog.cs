// u240603.1707

using System;
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
        ///    The executing assembly is defined at the start of the class so it can be easily used throughout the class when creating
        ///    log files.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Create postfixes for Tingen directory paths.</summary>
        /// <remarks>
        ///  <para>
        ///   These are defined here so they are in one location, can be easily changed, and used in multiple classes.<br/><br/>
        ///   When a new path property is added to TingenFramework.Properties.cs, a new entry needs to be added here.
        ///  </para>
        /// </remarks>
        public static Dictionary<string, string> DataPaths(string tingenDataRoot, string avatarSystemCode)
        {
            /* Can't put a trace log here, so we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName);

            return new Dictionary<string, string>
            {
                { "TingenDataRoot",   $@"{tingenDataRoot}" },
                { "AvatarSystemCode", $@"{tingenDataRoot}\{avatarSystemCode}" },
                { "RawDataRoot",      $@"{tingenDataRoot}\{avatarSystemCode}\RawData" },
                { "MessageRoot",      $@"{tingenDataRoot}\{avatarSystemCode}\Message" },
                { "PublicRoot",       $@"{tingenDataRoot}\Public"},
                { "RemoteRoot",       $@"{tingenDataRoot}\Remote" },
                { "SessionRoot",      $@"{tingenDataRoot}\{avatarSystemCode}\Session\{DateTime.Now:yyMMdd}" },
                { "Admin",            $@"{tingenDataRoot}\{avatarSystemCode}\Admin" },
                { "Alert",            $@"{tingenDataRoot}\{avatarSystemCode}\Message\Alert" },
                { "Archive",          $@"{tingenDataRoot}\{avatarSystemCode}\Archive" },
                { "Config",           $@"{tingenDataRoot}\{avatarSystemCode}\Config" },
                { "Debug",            $@"{tingenDataRoot}\{avatarSystemCode}\Debug" },
                { "Error",            $@"{tingenDataRoot}\{avatarSystemCode}\Message\Error" },
                { "Export",           $@"{tingenDataRoot}\{avatarSystemCode}\RawData\Export" },
                { "Extension",        $@"{tingenDataRoot}\{avatarSystemCode}\Extension" },
                { "Import",           $@"{tingenDataRoot}\{avatarSystemCode}\RawData\Import" },
                { "Log",              $@"{tingenDataRoot}\{avatarSystemCode}\Log" },
                { "Report",           $@"{tingenDataRoot}\{avatarSystemCode}\Report" },
                { "Template",         $@"{tingenDataRoot}\{avatarSystemCode}\Template" },
                { "Temporary",        $@"{tingenDataRoot}\{avatarSystemCode}\Temporary" },
                { "Warning",          $@"{tingenDataRoot}\{avatarSystemCode}\Message\Warning" },
                { "PublicAlert",      $@"{tingenDataRoot}\Public\Alert" },
                { "PublicError",      $@"{tingenDataRoot}\Public\Error" },
                { "PublicExport",     $@"{tingenDataRoot}\Public\Export" },
                { "PublicReport",     $@"{tingenDataRoot}\Public\Report" },
                { "PublicWarning",    $@"{tingenDataRoot}\Public\Warning" },
                { "RemoteAlert",      $@"{tingenDataRoot}\Remote\Alert" },
                { "RemoteError",      $@"{tingenDataRoot}\Remote\Error" },
                { "RemoteExport",     $@"{tingenDataRoot}\Remote\Export" },
                { "RemoteReport",     $@"{tingenDataRoot}\Remote\Report" },
                { "RemoteWarning",    $@"{tingenDataRoot}\Remote\Warning" }
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
        public static List<string> ServiceStatusPaths(TingenFramework tnFramework)
        {
            /* Can't put a trace log here, so we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName);

            return new List<string>
            {
                tnFramework.TingenDataRoot,
                tnFramework.SystemCodeRoot,
                tnFramework.RemoteRoot
            };
        }
    }
}
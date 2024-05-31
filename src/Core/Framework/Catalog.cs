// u240530.0910

using System.Collections.Generic;

namespace Outpost31.Core.Framework
{
    /// <summary>This class contains pre-defined information for the Tingen Framework.</summary>
    public static class Catalog
    {
        /// <summary>Create postfixes for Tingen directory paths.</summary>
        /// <remarks>
        ///  <para>
        ///   These are defined here so they are in one location, can be easily changed, and used in multiple classes.<br/><br/>
        ///   When a new path property is added to TingenFramework.Properties.cs, a new entry needs to be added here.
        ///  </para>
        /// </remarks>
        public static Dictionary<string, string> PathPostfixes(string avatarSystemCode)
        {
            //Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.Framework.Catalog.PathPostfixes()]"); /* <- For development use only */

            var pathPostFixes = new Dictionary<string, string>
            {
                { "SystemCodePath", $@"{avatarSystemCode}" },
                { "Admin",          $@"{avatarSystemCode}\Admin" },
                { "Alerts",         $@"{avatarSystemCode}\Messages\Alerts" },
                { "Archive",        $@"{avatarSystemCode}\Archive" },
                { "Configs",        $@"{avatarSystemCode}\Configs" },
                { "Data",           $@"{avatarSystemCode}\Data" },
                { "Debug",          $@"{avatarSystemCode}\Debug" },
                { "Errors",         $@"{avatarSystemCode}\Messages\Errors" },
                { "Exports",        $@"{avatarSystemCode}\Data\Export" },
                { "Extensions",     $@"{avatarSystemCode}\Extensions" },
                { "Imports",        $@"{avatarSystemCode}\Data\Import" },
                { "Logs",           $@"{avatarSystemCode}\Logs" },
                { "Messages",       $@"{avatarSystemCode}\Messages" },
                { "Reports",        $@"{avatarSystemCode}\Reports" },
                { "Templates",      $@"{avatarSystemCode}\Templates" },
                { "Temporary",      $@"{avatarSystemCode}\Temporary" },
                { "Warnings",       $@"{avatarSystemCode}\Messages\Warnings" },
                { "Public",         $@"Public"},
                { "PublicAlerts",   $@"Public\Messages\Alerts" },
                { "PublicExports",  $@"Public\Exports" },
                { "PublicReports",  $@"Public\Reports" },
                { "PublicWarnings", $@"Public\Messages\Warnings" },
                { "Remote",         $@"Remote" },
                { "RemoteAlerts",   $@"Remote\Alerts" },
                { "RemoteErrors",   $@"Remote\Errors" },
                { "RemoteExports",  $@"Remote\Exports" },
                { "RemoteReports",  $@"Remote\Reports" },
                { "RemoteWarnings", $@"Remote\Warnings" }
            };

            return pathPostFixes;
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
            //Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.Framework.Catalog.ServiceStatusPaths()]"); /* <- For development use only */

            return new List<string>
            {
                tnFramework.SystemCodePath,
                tnFramework.RemotePath
            };
        }
    }
}
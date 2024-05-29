// u240525.1957

using System.Collections.Generic;

namespace Outpost31.Core.Framework
{
    public static class Catalog
    {
        /// <summary>Create postfixes for Tingen directories.</summary>
        /// <remarks>
        ///     - These are defined here so that they can be easily changed, and can be used in multiple classes.
        /// </remarks>
        public static Dictionary<string, string> PathPostfixes(string avatarSystemCode)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Framework.Catalog.PathPostfixes()]"); /* <- For development use only */

            var test = new Dictionary<string, string>
            {
                { "Admin",          $@"{avatarSystemCode}\Admin" },
                { "Alerts",         $@"{avatarSystemCode}\Messages\Alerts" },
                { "Archive",        $@"{avatarSystemCode}\Archive" },
                { "Configs",        $@"{avatarSystemCode}\Configs" },
                { "Data",           $@"{avatarSystemCode}\Data" },
                { "Debug",          $@"{avatarSystemCode}\Debug" },
                { "Extensions",     $@"{avatarSystemCode}\Extensions" },
                { "Errors",         $@"{avatarSystemCode}\Messages\Errors" },
                { "Exports",        $@"{avatarSystemCode}\Data\Export" },
                { "Imports",        $@"{avatarSystemCode}\Data\Import" },
                { "Logs",           $@"{avatarSystemCode}\Logs" },
                { "Messages",       $@"{avatarSystemCode}\Messages" },
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
                { "RemoteWarnings", $@"Remote\Warnings" },
                { "Reports",        $@"{avatarSystemCode}\Reports" },
                { "SystemCodePath", $@"{avatarSystemCode}" },
                { "Templates",      $@"{avatarSystemCode}\Templates" },
                { "Temporary",      $@"{avatarSystemCode}\Temporary" },
                { "Warnings",       $@"{avatarSystemCode}\Messages\Warnings" }
            };

            return test;
        }

        public static List<string> ServiceStatusPaths(TingenFramework tnFramework)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Framework.Catalog.ServiceStatusPaths()]"); /* <- For development use only */

            return new List<string>
            {
                tnFramework.SystemCodePath,
                tnFramework.RemotePath
            };
        }
    }
}
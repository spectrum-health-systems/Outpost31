// u240531.1125

using System;

namespace Outpost31.Core.Session
{
    public static class Catalog
    {
        public static string CurrentSettings(TingenSession tnSession)
        {
            Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.Session.Catalog.CurrentSettings()]"); /* <- For development use only */

            return $"# Current Tingen Settings{Environment.NewLine}" +
                   $"> v24.10.11 b240502  {Environment.NewLine}" +
                   $"> Last updated: {DateTime.Now}{Environment.NewLine}" +
                   Environment.NewLine +
                   $"## Tingen{Environment.NewLine}" +
                   $"Mode: {tnSession.TingenMode}  {Environment.NewLine}" +
                   $"System Code: {tnSession.AvatarSystemCode.ToUpper()}  {Environment.NewLine}" +
                   $"Log Mode: {tnSession.LogMode}  {Environment.NewLine}" +
                   $"Log Delay: {tnSession.LogDelay}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"## Modules{Environment.NewLine}" +
                   Environment.NewLine +
                   $"### Admin Module{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Enabled: {tnSession.ModAdminEnabled}  {Environment.NewLine}" +
                   $"Whitelist: {tnSession.ModAdminWhitelist}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"## Paths{Environment.NewLine}" +
                   Environment.NewLine +
                   $"### Root paths{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Tingen data root: {tnSession.TnFramework.TingenDataRoot}  {Environment.NewLine}" +
                   $"System Code root: {tnSession.TnFramework.SystemCodeRoot}  {Environment.NewLine}" +
                   $"Raw data root: {tnSession.TnFramework.RawDataRoot}  {Environment.NewLine}" +
                   $"Messages root: {tnSession.TnFramework.MessageRoot}  {Environment.NewLine}" +
                   $"Public data root: {tnSession.TnFramework.PublicRoot}  {Environment.NewLine}" +
                   $"Remote data root: {tnSession.TnFramework.RemoteRoot}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"### System Code paths{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Admin data: {tnSession.TnFramework.AdminPath}  {Environment.NewLine}" +
                   $"Alerts: {tnSession.TnFramework.AlertPath}  {Environment.NewLine}" +
                   $"Archived data: {tnSession.TnFramework.ArchivePath}  {Environment.NewLine}" +
                   $"Configuration files: {tnSession.TnFramework.ConfigPath}  {Environment.NewLine}" +
                   $"Debugging information: {tnSession.TnFramework.DebugPath}  {Environment.NewLine}" +
                   $"Errors: {tnSession.TnFramework.ErrorPath}  {Environment.NewLine}" +
                   $"Exported data: {tnSession.TnFramework.ExportPath}  {Environment.NewLine}" +
                   $"Extensions: {tnSession.TnFramework.ExtensionPath}  {Environment.NewLine}" +
                   $"Imported data: {tnSession.TnFramework.ImportPath}  {Environment.NewLine}" +
                   $"Logs: {tnSession.TnFramework.LogPath}  {Environment.NewLine}" +
                   $"Reports: {tnSession.TnFramework.ReportPath}  {Environment.NewLine}" +
                   $"Templates: {tnSession.TnFramework.TemplatePath}  {Environment.NewLine}" +
                   $"Temporary data: {tnSession.TnFramework.TemporaryPath}  {Environment.NewLine}" +
                   $"Warnings: {tnSession.TnFramework.WarningPath}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"### Public data{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Alerts: {tnSession.TnFramework.PublicAlertPath}  {Environment.NewLine}" +
                   $"Errors: {tnSession.TnFramework.PublicErrorPath}  {Environment.NewLine}" +
                   $"Exported data: {tnSession.TnFramework.PublicExportPath}  {Environment.NewLine}" +
                   $"Reports: {tnSession.TnFramework.PublicReportPath}  {Environment.NewLine}" +
                   $"Warnings: {tnSession.TnFramework.PublicWarningPath}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"### Remote data{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Alerts: {tnSession.TnFramework.RemoteAlertPath}  {Environment.NewLine}" +
                   $"Errors: {tnSession.TnFramework.RemoteErrorPath}  {Environment.NewLine}" +
                   $"Exported data: {tnSession.TnFramework.RemoteExportPath}  {Environment.NewLine}" +
                   $"Reports: {tnSession.TnFramework.RemoteReportPath}  {Environment.NewLine}" +
                   $"Warnings: {tnSession.TnFramework.RemoteWarningPath}  {Environment.NewLine}";
        }
    }
}

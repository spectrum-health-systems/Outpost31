// u240605.1103

using System;
using System.Reflection;
using Outpost31.Core.Logger;

namespace Outpost31.Core.Session
{
    /// <summary>Soon.</summary>
    public static class Catalog
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string Asm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Soon.</summary>
        /// <param name="tnSession"></param>
        /// <returns></returns>
        public static string CurrentSettings(TingenSession tnSession)
        {
            LogEvent.Trace(1, tnSession.TraceLogs, Asm);

            return $"# Current Tingen Settings{Environment.NewLine}" +
                   $"> v{tnSession.Config.TingenVersionBuild}  {Environment.NewLine}" +
                   $"> Last updated: {DateTime.Now}{Environment.NewLine}" +
                   Environment.NewLine +
                   $"## Tingen{Environment.NewLine}" +
                   $"Mode: {tnSession.Config.TingenMode}  {Environment.NewLine}" +
                   $"System Code: {tnSession.AvatarData.SystemCode.ToUpper()}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"## Logging{Environment.NewLine}" +
                   Environment.NewLine +
                   $"### Trace logs{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Trace log mode: {tnSession.TraceLogs.TraceLogLevel}  {Environment.NewLine}" +
                   $"Trace log delay: {tnSession.TraceLogs.TraceLogDelay}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"## Modules{Environment.NewLine}" +
                   Environment.NewLine +
                   $"### Admin Module{Environment.NewLine}" +
                   Environment.NewLine +
                   //$"Enabled: {tnSession.ModAdminEnabled}  {Environment.NewLine}" +
                   //$"Whitelist: {tnSession.ModAdminWhitelist}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"## Paths{Environment.NewLine}" +
                   Environment.NewLine +
                   $"### Root paths{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Tingen data root: {tnSession.Framework.DataRoot.Tingen}  {Environment.NewLine}" +
                   $"System Code root: {tnSession.Framework.DataRoot.SystemCode}  {Environment.NewLine}" +
                   $"Raw data root: {tnSession.Framework.DataRoot.RawData}  {Environment.NewLine}" +
                   $"Messages root: {tnSession.Framework.DataRoot.Message}  {Environment.NewLine}" +
                   $"Public data root: {tnSession.Framework.DataRoot.Public}  {Environment.NewLine}" +
                   $"Remote data root: {tnSession.Framework.DataRoot.Remote}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"### System Code paths{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Admin data: {tnSession.Framework.SystemCodePath.Admin}  {Environment.NewLine}" +
                   $"Alerts: {tnSession.Framework.SystemCodePath.Alert}  {Environment.NewLine}" +
                   $"Archived data: {tnSession.Framework.SystemCodePath.Archive}  {Environment.NewLine}" +
                   $"Configuration files: {tnSession.Framework.SystemCodePath.Config}  {Environment.NewLine}" +
                   $"Debugging information: {tnSession.Framework.SystemCodePath.Debug}  {Environment.NewLine}" +
                   $"Errors: {tnSession.Framework.SystemCodePath.Error}  {Environment.NewLine}" +
                   $"Exported data: {tnSession.Framework.SystemCodePath.Export}  {Environment.NewLine}" +
                   $"Extensions: {tnSession.Framework.SystemCodePath.Extension}  {Environment.NewLine}" +
                   $"Imported data: {tnSession.Framework.SystemCodePath.Import}  {Environment.NewLine}" +
                   $"Logs: {tnSession.Framework.SystemCodePath.Log}  {Environment.NewLine}" +
                   $"Reports: {tnSession.Framework.SystemCodePath.Report}  {Environment.NewLine}" +
                   $"Templates: {tnSession.Framework.SystemCodePath.Template}  {Environment.NewLine}" +
                   $"Temporary data: {tnSession.Framework.SystemCodePath.Temporary}  {Environment.NewLine}" +
                   $"Warnings: {tnSession.Framework.SystemCodePath.Warning}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"### Public data{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Alerts: {tnSession.Framework.PublicPath.Alert}  {Environment.NewLine}" +
                   $"Errors: {tnSession.Framework.PublicPath.Error}  {Environment.NewLine}" +
                   $"Exported data: {tnSession.Framework.PublicPath.Export}  {Environment.NewLine}" +
                   $"Reports: {tnSession.Framework.PublicPath.Report}  {Environment.NewLine}" +
                   $"Warnings: {tnSession.Framework.PublicPath.Warning}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"### Remote data{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Alerts: {tnSession.Framework.RemotePath.Alert}  {Environment.NewLine}" +
                   $"Errors: {tnSession.Framework.RemotePath.Error}  {Environment.NewLine}" +
                   $"Exported data: {tnSession.Framework.RemotePath.Export}  {Environment.NewLine}" +
                   $"Reports: {tnSession.Framework.RemotePath.Report}  {Environment.NewLine}" +
                   $"Warnings: {tnSession.Framework.RemotePath.Warning}  {Environment.NewLine}";
        }
    }
}

/*

Development notes
-----------------

- Module enabled/disabled information should be here.
- Module whitelists, should be in the Module configuration.
- Add other Modules information

*/
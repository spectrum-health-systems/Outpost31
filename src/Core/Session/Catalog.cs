// u240607.1023

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
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Soon.</summary>
        /// <param name="tnSession"></param>
        /// <returns></returns>
        public static string CurrentSettings(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            return $"# Current Tingen Settings{Environment.NewLine}" +
                   $"> Version {tnSession.TnVersion} [Build {tnSession.TnBuild}]  {Environment.NewLine}" +
                   $"> Last updated: {DateTime.Now}{Environment.NewLine}" +
                   Environment.NewLine +
                   $"## Tingen{Environment.NewLine}" +
                   $"Mode: {tnSession.TnConfig.TingenMode}  {Environment.NewLine}" +
                   $"System Code: {tnSession.AvData.AvatarSystemCode.ToUpper()}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"## Logging{Environment.NewLine}" +
                   Environment.NewLine +
                   $"### Trace logs{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Trace log level: {tnSession.TnConfig.TraceLevel}  {Environment.NewLine}" +
                   $"Trace log delay: {tnSession.TnConfig.TraceDelay}  {Environment.NewLine}" +
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
                   $"### Tingen{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Root: {tnSession.TnPath.Tingen.Root}  {Environment.NewLine}" +
                   $"Primeval: {tnSession.TnPath.Tingen.Primeval}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"### System Code{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Root: {tnSession.TnPath.SystemCode.Root}  {Environment.NewLine}" +
                   $"Admin: {tnSession.TnPath.SystemCode.Admin}  {Environment.NewLine}" +
                   $"Alerts: {tnSession.TnPath.SystemCode.Alerts}  {Environment.NewLine}" +
                   $"Archive: {tnSession.TnPath.SystemCode.Archive}  {Environment.NewLine}" +
                   $"Configuration: {tnSession.TnPath.SystemCode.Config}  {Environment.NewLine}" +
                   $"Debugging: {tnSession.TnPath.SystemCode.Debug}  {Environment.NewLine}" +
                   $"Errors: {tnSession.TnPath.SystemCode.Errors}  {Environment.NewLine}" +
                   $"Exports: {tnSession.TnPath.SystemCode.ExportData}  {Environment.NewLine}" +
                   $"Extensions: {tnSession.TnPath.SystemCode.Extensions}  {Environment.NewLine}" +
                   $"Imports: {tnSession.TnPath.SystemCode.ImportData}  {Environment.NewLine}" +
                   $"Logs: {tnSession.TnPath.SystemCode.Logs}  {Environment.NewLine}" +
                   $"Reports: {tnSession.TnPath.SystemCode.Reports}  {Environment.NewLine}" +
                   $"Sessions: {tnSession.TnPath.SystemCode.Sessions}  {Environment.NewLine}" +
                   $"Templates: {tnSession.TnPath.SystemCode.Templates}  {Environment.NewLine}" +
                   $"Temporary data: {tnSession.TnPath.SystemCode.Temporary}  {Environment.NewLine}" +
                   $"Warnings: {tnSession.TnPath.SystemCode.Warnings}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"### Public{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Root: {tnSession.TnPath.Public.Root}  {Environment.NewLine}" +
                   $"Alerts: {tnSession.TnPath.Public.Alerts}  {Environment.NewLine}" +
                   $"Errors: {tnSession.TnPath.Public.Errors}  {Environment.NewLine}" +
                   $"Exports: {tnSession.TnPath.Public.ExportData}  {Environment.NewLine}" +
                   $"Reports: {tnSession.TnPath.Public.Reports}  {Environment.NewLine}" +
                   $"Warnings: {tnSession.TnPath.Public.Warnings}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"### Remote{Environment.NewLine}" +
                   Environment.NewLine +
                   $"Root: {tnSession.TnPath.Remote.Root}  {Environment.NewLine}" +
                   $"Alerts: {tnSession.TnPath.Remote.Alerts}  {Environment.NewLine}" +
                   $"Errors: {tnSession.TnPath.Remote.Errors}  {Environment.NewLine}" +
                   $"Exports: {tnSession.TnPath.Remote.ExportData}  {Environment.NewLine}" +
                   $"Reports: {tnSession.TnPath.Remote.Reports}  {Environment.NewLine}" +
                   $"Warnings: {tnSession.TnPath.Remote.Warnings}  {Environment.NewLine}";
        }

        public static string SessionDetails(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            return $"# Session details{Environment.NewLine}" +
                   Environment.NewLine +
                   $"**Session date:** {tnSession.Date}  {Environment.NewLine}" +
                   $"**Session time:** {tnSession.Time}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"## Avatar details{Environment.NewLine}" +
                   Environment.NewLine +
                   $"**Script Parameter:** {tnSession.AvData.SentScriptParameter}  {Environment.NewLine}" +
                   $"**System Code:** {tnSession.AvData.AvatarSystemCode}  {Environment.NewLine}" +
                   Environment.NewLine +
                   $"### OptionObjects{Environment.NewLine}" +
                   Environment.NewLine +
                   $"#### SentObject{Environment.NewLine}" +
                   Environment.NewLine +
                   $"```json{Environment.NewLine}" +
                   $"{tnSession.AvData.SentOptionObject.ToJson()}{Environment.NewLine}" +
                   $"```{Environment.NewLine}" +
                   $"#### WorkObject{Environment.NewLine}" +
                   Environment.NewLine +
                   $"```json{Environment.NewLine}" +
                   $"{tnSession.AvData.WorkOptionObject.ToJson()}{Environment.NewLine}" +
                   $"```{Environment.NewLine}" +
                   $"#### ReturnObject{Environment.NewLine}" +
                   Environment.NewLine +
                   $"```json{Environment.NewLine}" +
                   $"{tnSession.AvData.ReturnOptionObject.ToJson()}{Environment.NewLine}" +
                   $"```{Environment.NewLine}" +
                   Environment.NewLine +
                   $"<br>" +
                   $"<br>" +
                   $"***" +
                   Environment.NewLine +
                   $"**Tingen details**  {Environment.NewLine}" +
                   $"**Version:** {tnSession.TnVersion}  {Environment.NewLine}" +
                   $"**Mode:** {tnSession.TnConfig.TingenMode}  {Environment.NewLine}" +
                   $"**Trace log level:** {tnSession.TnConfig.TraceLevel.ToString()}  {Environment.NewLine}";
        }
    }
}

/*

-----------------
Development notes
-----------------

- Verify all of the data is here
- Module enabled/disabled information should be here.
- Module whitelists, should be in the Module configuration.
- Add other Modules information

*/
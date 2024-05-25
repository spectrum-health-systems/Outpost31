// u240525.1402

using System;
using Outpost31.Core.Avatar;
using Outpost31.Core.Configuration;
using Outpost31.Core.Framework;
using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Session
{
    /// <summary>Contains Tingen session logic.</summary>
    /// <remarks>
    ///     Properties for the Tingen session are located in <b>TingenSession.Properties.cs.</b>
    /// </remarks>
    public partial class TingenSession
    {

        /// <summary>Loads the object.</summary>
        /// <param name="configFilePath">The path to the Tingen configuration file.</param>
        /// <param name="sentOptionObject">The OptionObject sent from Avatar.</param>
        /// <param name="sentScriptParameter">The ScriptParameter sent from Avatar.</param>
        /// <remarks>
        ///     AbSession contains all of the information that Tingen needs to do what it does, including data from:
        ///     <list type="bullet">
        ///         <item>The Tingen configuration file, which contains data that does not change between sessions</item>
        ///         <item>Static data that is specific to the current session, such as framework components</item>
        ///         <item>Runtime settings that are specific to the current session, such as the session timestamp</item>
        ///         <item>The <paramref name="sentOptionObject"/> and <paramref name="sentScriptParameter"/></item>
        ///         <item>Abatab Modules</item>
        ///     </list>
        ///     All strings in this method have been converted to lowercase to make it easlier to compare going forward.
        /// </remarks>
        /// <returns>An AbSession object.</returns>
        public static TingenSession Load(string configFilePath, OptionObject2015 sentOptionObject, string sentScriptParameter)
        {
            Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Session.TingenSession.Load()]"); /* <- For development use only */

            var tnConfig = TingenConfiguration.Load(configFilePath);

            return new TingenSession
            {
                TingenMode       = tnConfig.TingenMode.ToLower(),
                TingenVersion    = tnConfig.TingenVersionBuild.Split('-')[0],
                TingenBuild      = tnConfig.TingenVersionBuild.Split('-')[1],
                AvatarSystemCode = tnConfig.AvatarSystemCode.ToLower(),
                SessionTimestamp = DateTime.Now.ToString("yyyyMMdd-HHmmssfffffff"),
                LogMode          = tnConfig.LogMode,
                LogDelay         = tnConfig.LogDelay,
                TnFramework      = TingenFramework.BuildComponents(tnConfig.TingenDataRoot, tnConfig.AvatarSystemCode),
                AvComponents     = AvatarData.Setup(sentScriptParameter, sentOptionObject)

            };
        }

        ///////// <summary>Builds the Abatab Framework components.</summary>
        ///////// <param name="tingenDataRoot">The Abatab root directory.</param>
        ///////// <param name="avatarSystemCode">The Avatar System Code</param>
        ///////// <remarks>
        /////////     This method build the following Abatab framework components:
        /////////     <list type="table">
        /////////         <item>
        /////////             <term>Directory paths</term>
        /////////             <description>Required directory paths</description>
        /////////         </item>
        /////////         <item>
        /////////             <term>Service status paths</term>
        /////////             <description>Paths where service status files are located</description>
        /////////         </item>
        /////////     </list>
        ///////// </remarks>
        ///////// <returns>The Abatab Framework components.</returns>
        //////private static TingenFramework BuildFrameworkComponents(string tingenDataRoot, string avatarSystemCode)
        //////{
        //////    //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Session.TingenSession.BuildFrameworkComponents()]"); /* <- For development use only */

        //////    var pathPostfix = Framework.Catalog.PathPostfixes(avatarSystemCode);

        //////    var tnFramework =  new TingenFramework
        //////    {
        //////        AlertPath         = $@"{tingenDataRoot}\{pathPostfix["Alerts"]}",
        //////        ConfigPath        = $@"{tingenDataRoot}\{pathPostfix["Configs"]}",
        //////        DebugPath         = $@"{tingenDataRoot}\{pathPostfix["Debugglers"]}",
        //////        ErrorPath         = $@"{tingenDataRoot}\{pathPostfix["Errors"]}",
        //////        ExportPath        = $@"{tingenDataRoot}\{pathPostfix["Exports"]}",
        //////        ImportPath        = $@"{tingenDataRoot}\{pathPostfix["Imports"]}",
        //////        LogPath           = $@"{tingenDataRoot}\{pathPostfix["Logs"]}",
        //////        PublicAlertPath   = $@"{tingenDataRoot}\{pathPostfix["PublicAlerts"]}",
        //////        PublicExportPath  = $@"{tingenDataRoot}\{pathPostfix["PublicExports"]}",
        //////        PublicReportPath  = $@"{tingenDataRoot}\{pathPostfix["PublicReports"]}",
        //////        PublicWarningPath = $@"{tingenDataRoot}\{pathPostfix["PublicWarnings"]}",
        //////        RemotePath        = $@"{tingenDataRoot}\{pathPostfix["Remote"]}",
        //////        ReportPath        = $@"{tingenDataRoot}\{pathPostfix["Reports"]}",
        //////        SystemCodePath    = $@"{tingenDataRoot}\{avatarSystemCode}",
        //////        ServicePath       = $@"{tingenDataRoot}\{pathPostfix["Service"]}",
        //////        TemplatesPath     = $@"{tingenDataRoot}\{pathPostfix["Templates"]}",
        //////        TemporaryPath     = $@"{tingenDataRoot}\{pathPostfix["Temporary"]}",
        //////        WarningPath       = $@"{tingenDataRoot}\{pathPostfix["Warnings"]}",
        //////    };

        //////    // FIX tnFramework.ServiceStatusPaths = Abatab.Core.Framework.Catalog.DisabledNotificationFiles(abFramework);

        //////    return tnFramework;
        //////}

        //private static AvatarComponents BuildAvatarComponents(string sentScriptParameter, string avatarSystemCode, OptionObject2015 sentOptionObject)
        //{
        //    //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Session.TingenSession.BuildAvatarComponents()]"); /* <- For development use only */

        //    var scriptParameterComponent = ParseScriptParameter(sentScriptParameter);

        //    var avComponents = new AvatarComponents
        //    {
        //        AvatarSystemCode    = avatarSystemCode.ToLower(),
        //        SentScriptParameter = sentScriptParameter,
        //        ScriptModule        = scriptParameterComponent["Module"],
        //        ScriptCommand       = scriptParameterComponent["Command"],
        //        ScriptAction        = scriptParameterComponent["Action"],
        //        ScriptOption        = scriptParameterComponent["Option"],
        //        SentOptionObject    = sentOptionObject,
        //        WorkOptionObject    = sentOptionObject,
        //        ReturnOptionObject  = null
        //    };

        //    return avComponents;
        //}

        //private static Dictionary<string, string> ParseScriptParameter(string sentScriptParameter)
        //{
        //    //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Session.TingenSession.ParseScriptParameter()]"); /* <- For development use only */

        //    var scriptParameterComponent = SetComponentToUndefined();
        //    var numberOfComponents       = sentScriptParameter.Split('-').Length;

        //    for (int component = 0; component < numberOfComponents; component++)
        //    {
        //        switch (component)
        //        {
        //            case 0:
        //                scriptParameterComponent["Module"] = sentScriptParameter.Split('-')[component].ToLower();
        //                break;

        //            case 1:
        //                scriptParameterComponent["Command"] = sentScriptParameter.Split('-')[1].ToLower();
        //                break;

        //            case 2:
        //                scriptParameterComponent["Action"] = sentScriptParameter.Split('-')[2].ToLower();
        //                break;

        //            case 3:
        //                scriptParameterComponent["Option"] = sentScriptParameter.Split('-')[3].ToLower();
        //                break;

        //            default:
        //                break;
        //        }
        //    }

        //    return scriptParameterComponent;
        //}

        //private static Dictionary<string, string> SetComponentToUndefined()
        //{
        //    //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Session.TingenSession.SetComponentToUndefined()]"); /* <- For development use only */

        //    return new Dictionary<string, string>
        //    {
        //        {"Module",  "undefined" },
        //        {"Command", "undefined" },
        //        {"Action",  "undefined" },
        //        {"Option",  "undefined" }
        //    };
        //}

        private static void WriteSesssionLog(TingenSession tnSession)
        {


            //string sessionBody = Abatab.Core.Catalog.InstanceDetails.Build(DuJson.ConvertToString(abSession), abSession.AbFramework.TemplatesPath);

        }

        public static void Run(TingenSession tnSession)
        {
            //LogEvent.Primeval("[START]"); /* For development use. */

            //Abatab.Core.Session.ParseScriptModule.Run(abSession);

            //LogEvent.Primeval("[END]"); /* For development use. */
        }
    }
}

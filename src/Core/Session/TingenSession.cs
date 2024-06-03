// u240603.1721

using System;
using System.Reflection;
using Outpost31.Core.Avatar;
using Outpost31.Core.Configuration;
using Outpost31.Core.Framework;
using Outpost31.Core.Logger;
using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Session
{
    /// <summary>Contains Tingen session logic.</summary>
    /// <remarks>
    ///  <para>
    ///   Properties for the Tingen session are located in <b>TingenSession.Properties.cs.</b>
    ///  </para>
    /// </remarks>
    public partial class TingenSession
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    The executing assembly is defined at the start of the class so it can be easily used throughout the class when creating
        ///    log files.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Loads the object.</summary>
        /// <param name="configFilePath">The path to the Tingen configuration file.</param>
        /// <param name="sentOptionObject">The OptionObject sent from Avatar.</param>
        /// <param name="sentScriptParameter">The ScriptParameter sent from Avatar.</param>
        /// <remarks>
        ///  <para>
        ///   AbSession contains all of the information that Tingen needs to do what it does, including data from:
        ///   <list type="bullet">
        ///    <item>The Tingen configuration file, which contains data that does not change between sessions</item>
        ///    <item>Static data that is specific to the current session, such as framework components</item>
        ///    <item>Runtime settings that are specific to the current session, such as the session timestamp</item>
        ///    <item>The <paramref name="sentOptionObject"/> and <paramref name="sentScriptParameter"/></item>
        ///    <item>Abatab Modules</item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///     All strings in this method have been converted to lowercase to make it easlier to compare going forward.
        ///  </para>
        /// </remarks>
        /// <returns>An AbSession object.</returns>
        public static TingenSession Build(string configFilePath, OptionObject2015 sentOptionObject, string sentScriptParameter)
        {
            /* Can't put a trace log here, so we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName);

            LogEvent.Primeval(AssemblyName, configFilePath);

            var tnConfig = TingenConfiguration.Load(configFilePath);

            LogEvent.Primeval(AssemblyName, tnConfig.ToString());

            var tnSession = new TingenSession
            {
                TingenMode       = tnConfig.TingenMode.ToLower(),
                TingenVersion    = tnConfig.TingenVersionBuild.Split('-')[0],
                TingenBuild      = tnConfig.TingenVersionBuild.Split('-')[1],
                AvatarSystemCode = tnConfig.AvatarSystemCode.ToLower(),
                DateStamp        = DateTime.Now.ToString("yyMMdd"),
                TimeStamp        = DateTime.Now.ToString("HHmmss"),
                TnFramework      = TingenFramework.Build(tnConfig.TingenDataRoot, tnConfig.AvatarSystemCode),
                AvData           = DataFromAvatar.Build(sentOptionObject, sentScriptParameter),
            };

            LogEvent.Primeval(AssemblyName, tnSession.ToString());

            tnSession.CurrentSessionPath = $@"{tnSession.TnFramework.SessionRoot}\{tnSession.AvData.SentOptionObject.OptionUserId}";

            LogEvent.Primeval(AssemblyName, tnSession.CurrentSessionPath);

            tnSession.TraceInfo          = TraceLog.BuildInfo(tnConfig.TraceLogMode, tnConfig.TraceLogDelay, tnSession.CurrentSessionPath);

            LogEvent.Primeval(AssemblyName, tnSession.TraceInfo.ToString());

            return tnSession;
        }

        public static void Initialize(TingenSession tnSession)
        {
            LogEvent.Trace(tnSession, AssemblyName);

            Maintenance.VerifyDirectory(tnSession.CurrentSessionPath);
        }
    }
}
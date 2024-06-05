// u240605.1127

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
    public class TingenSession
    {
        /// <summary>The session datestamp.</summary>
        public string DateStamp { get; set; }
        /// <summary>The session timestamp.</summary>
        public string TimeStamp { get; set; }

        /// <summary>The current session path</summary>
        public string SessionPath { get; set; }

        /// <summary>Config</summary>
        public TingenConfig Config { get; set; }

        /// <summary>Tingen Framework information.</summary>
        /// <remarks>
        ///  <para>
        ///   See <b>Outpost31.Core.Configuration.TingenFramework.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public TingenFramework Framework { get; set; }

        /// <summary>Avatar components .</summary>
        /// <remarks>
        ///  <para>
        ///   See <b>Outpost31.Core.Configuration.TingenFramework.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public AvatarData AvatarData { get; set; }

        /// <summary>Trace log information.</summary>
        public TraceLog TraceLogs { get; set; }

        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Executing assembly is defined here so it can be used when creating log files.
        ///   </para>
        /// </remarks>
        public static string Asm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Loads the object.</summary>
        /// <param name="configFilePath">The path to the Tingen configuration file.</param>
        /// <param name="sentObject">The OptionObject sent from Avatar.</param>
        /// <param name="sentParameter">The ScriptParameter sent from Avatar.</param>
        /// <remarks>
        ///  <para>
        ///   AbSession contains all of the information that Tingen needs to do what it does, including data from:
        ///   <list type="bullet">
        ///    <item>The Tingen configuration file, which contains data that does not change between sessions</item>
        ///    <item>Static data that is specific to the current session, such as framework components</item>
        ///    <item>Runtime settings that are specific to the current session, such as the session timestamp</item>
        ///    <item>The <paramref name="sentObject"/> and <paramref name="sentParameter"/></item>
        ///    <item>Abatab Modules</item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///     All strings in this method have been converted to lowercase to make it easlier to compare going forward.
        ///  </para>
        /// </remarks>
        /// <returns>An AbSession object.</returns>
        public static TingenSession Build(OptionObject2015 sentObject, string sentParameter, string systemCode, string configFilePath)
        {
            /* <!-- For debugging: LogEvent.Primeval(asm); --> */ // To be removed.

            var tnConfig = TingenConfig.Load(configFilePath);

            var tnSession = new TingenSession
            {
                DateStamp  = DateTime.Now.ToString("yyMMdd"),
                TimeStamp  = DateTime.Now.ToString("HHmmss"),
                Config     = TingenConfig.Load(configFilePath)
            };

            tnSession.SessionPath = $@"{tnSession.Framework.DataRoot.Session}\{tnSession.AvatarData.SentObject.OptionUserId}\{DateTime.Now:HHmmss}";
            tnSession.Framework   = TingenFramework.Build(tnConfig.TingenDataRoot, systemCode, tnSession.DateStamp);
            tnSession.AvatarData  = AvatarData.BuildNew(sentObject, sentParameter, systemCode);
            tnSession.TraceLogs   = TraceLog.BuildInfo(tnSession.SessionPath, tnConfig.TraceLogLevel, tnConfig.TraceLogDelay);

            return tnSession;
        }

        /// <summary>Soon.</summary>
        /// <param name="tnSession"></param>
        public static void Initialize(TingenSession tnSession)
        {
            /* Can't do any logging here. Sorry! */

            ////var requiredDirectories = new List<string>
            ////{
            ////   tnSession.Framework.
            ////};

            Maintenance.VerifyDirectory(tnSession.SessionPath);
        }
    }
}

/*

Development notes
-----------------

*/
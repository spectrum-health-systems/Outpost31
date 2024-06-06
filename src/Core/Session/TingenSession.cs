// u240605.1127

using System;
using System.Collections.Generic;
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
        public TraceLog TraceInfo { get; set; }

        /// <summary>Builds the Tingen Session object.</summary>
        /// <param name="configFile">The path to the Tingen configuration file.</param>
        /// <param name="sentObject">The OptionObject sent from Avatar.</param>
        /// <param name="sentParameter">The ScriptParameter sent from Avatar.</param>
        /// <remarks>
        ///  <para>
        ///   The Tingen Session contains all of the information that Tingen needs to do what it does, including:
        ///   <list type="bullet">
        ///    <item>Configuration settings (user-definable settings from the <paramref name="configFile"/>)</item>
        ///    <item>Static settings (these do not change between sessions)</item>
        ///    <item>Runtime settings (unique to the current session)</item>
        ///    <item>Data sent from Avatar, including the <paramref name="sentObject"/> and <paramref name="sentParameter"/></item>
        ///    <item>Data derived from the <paramref name="sentObject"/> or <paramref name="sentParameter"/>.</item>
        ///    <item>Required Tingen Module details.</item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///   <b>More information about this method:</b><br/>
        ///   This method is one of the most important in Tingen, as it builds the Tingen Session object.<br/><br/>
        ///   The Session object is built in this order:
        ///   <list type="number">
        ///    <item>A basic TingenSession object is initalized with the current date, time, configuration settings, and Avatar data.</item>
        ///    <item>Framework information is added seperately.</item>
        ///    <item>Trace log information is added seperately.</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        /// <returns>An Tingen Session object.</returns>
        public static TingenSession Build(OptionObject2015 sentObject, string sentParameter, string systemCode, string configFile)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            var tnConfig = TingenConfig.Load(configFile);

            var tnSession = new TingenSession
            {
                DateStamp  = DateTime.Now.ToString("yyMMdd"),
                TimeStamp  = DateTime.Now.ToString("HHmmss"),
                Config     = TingenConfig.Load(configFile),
                AvatarData = AvatarData.BuildNew(sentObject, sentParameter, systemCode)
            };

            tnSession.Framework  = TingenFramework.Build(tnConfig.TingenDataRoot, systemCode, sentObject.OptionUserId, tnSession.DateStamp, tnSession.TimeStamp, tnSession.AvatarData.SentScriptParameter);
            tnSession.TraceInfo  = TraceLog.BuildInfo(tnSession.Framework.SystemCodePath.Session, tnConfig.TraceLogLevel, tnConfig.TraceLogDelay);

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

            Maintenance.VerifyDirectory(tnSession.Framework.SystemCodePath.Session);
        }
    }
}

/*

Development notes
-----------------

- Do we need to verify the session path?

*/
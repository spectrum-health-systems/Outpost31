﻿// u240607.1023

using System;
using System.Collections.Generic;
using System.IO;
using Outpost31.Core.Avatar;
using Outpost31.Core.Configuration;
using Outpost31.Core.Framework;
using Outpost31.Core.Logger;
using Outpost31.Module.OpenIncident;
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
        public string TnVersion { get; set; }

        public string TnBuild { get; set; }

        /// <summary>The session datestamp.</summary>
        public string Date { get; set; }
        /// <summary>The session timestamp.</summary>
        public string Time { get; set; }

        /// <summary>Config</summary>
        public ConfigSettings TnConfig { get; set; }

        /// <summary>Tingen Framework information.</summary>
        /// <remarks>
        ///  <para>
        ///   See <b>Outpost31.Core.Configuration.TingenFramework.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public Paths TnPath { get; set; }

        /// <summary>Avatar components .</summary>
        /// <remarks>
        ///  <para>
        ///   See <b>Outpost31.Core.Configuration.TingenFramework.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public AvatarData AvData { get; set; }


        /// <summary>Trace log information.</summary>
        public TraceLog TraceInfo { get; set; }

        /// <summary>Module to open an incident.</summary>
        ///
        public ModuleOpenIncident ModOpenIncident { get; set; }

        /// <summary>Builds the Tingen Session object.</summary>
        /// <param name="configFile">The path to the Tingen configuration file.</param>
        /// <param name="sentOptionObject">The OptionObject sent from Avatar.</param>
        /// <param name="sentScriptParameter">The ScriptParameter sent from Avatar.</param>
        /// <remarks>
        ///  <para>
        ///   The Tingen Session contains all of the information that Tingen needs to do what it does, including:
        ///   <list type="bullet">
        ///    <item>Configuration settings (user-definable settings from the <paramref name="configFile"/>)</item>
        ///    <item>Static settings (these do not change between sessions)</item>
        ///    <item>Runtime settings (unique to the current session)</item>
        ///    <item>Data sent from Avatar, including the <paramref name="sentOptionObject"/> and <paramref name="sentScriptParameter"/></item>
        ///    <item>Data derived from the <paramref name="sentOptionObject"/> or <paramref name="sentScriptParameter"/>.</item>
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
        ///    <item>Module objects are added seperately.</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        /// <returns>An Tingen Session object.</returns>
        public static TingenSession Build(OptionObject2015 sentOptionObject, string sentScriptParameter, string tnVersion)
        {
            var staticVar = BuildStaticVars();

            var tnSession = new TingenSession
            {
                TnVersion = tnVersion,
                TnBuild   = staticVar["tnBuild"],
                Date      = DateTime.Now.ToString("yyMMdd"),
                Time      = DateTime.Now.ToString("HHmmss"),
                TnConfig  = ConfigSettings.Load($@"{staticVar["tnDataRoot"]}\{staticVar["avSystemCode"]}\Config", staticVar["tnConfigFileName"]),
                AvData    = AvatarData.BuildObject(sentOptionObject, sentScriptParameter, staticVar["avSystemCode"]),
                TnPath    = Paths.Build(staticVar["tnDataRoot"], staticVar["avSystemCode"])
            };

            //////tnSession.Path = Paths.Build(tnSession.Config.TingenDataRoot, avSystemCode);

            /* The session-specific path is built here. */
            tnSession.TnPath.SystemCode.CurrentSession = $@"{tnSession.TnPath.SystemCode.Sessions}\{tnSession.Date}\{sentOptionObject.OptionUserId}\{tnSession.Time}";

            /* Trace info */
            tnSession.TraceInfo = TraceLog.BuildInfo(tnSession.TnPath.SystemCode.CurrentSession, tnSession.TnConfig.TraceLevel, tnSession.TnConfig.TraceDelay);

            // Module stuff
            if (tnSession.TnConfig.ModOpenIncidentMode == "enabled" && tnSession.AvData.SentScriptParameter.ToLower().StartsWith("openincident"))
            {
                tnSession.ModOpenIncident = ModuleOpenIncident.Load($@"{tnSession.TnPath.SystemCode.Config}\ModOpenIncident.config", tnSession.TnPath.SystemCode.Sessions, tnSession.AvData.WorkOptionObject, tnSession.TraceInfo);
            }
            else
            {
                tnSession.ModOpenIncident = new ModuleOpenIncident();
            }

            Initialize(tnSession); // somewhere else?

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

            Maintenance.VerifyDirectory(tnSession.TnPath.SystemCode.CurrentSession);
        }

        public static void WriteSessionDetails(TingenSession tnSession)
        {
            var sessionDetailFilePath = $@"{tnSession.TnPath.SystemCode.CurrentSession}\Session.md";

            File.WriteAllText(sessionDetailFilePath, Catalog.SessionDetails(tnSession));
        }

        public static Dictionary<string, string> BuildStaticVars()
        {
            return new Dictionary<string, string>
            {
                { "tnBuild",          "240610.0753" },
                { "avSystemCode",     "UAT" },
                { "tnDataRoot",       @"C:\TingenData" },
                { "tnConfigFileName", "Tingen.config" }
            };
        }
    }
}

/*

-----------------
Development notes
-----------------

- Do we need to verify the session path?

*/
// u241021.1131_code
// u241021_documentation

using System;
using System.Collections.Generic;
using System.Reflection;
using Outpost31.Core.Avatar;
using Outpost31.Core.Configuration;
using Outpost31.Core.Framework;
using Outpost31.Core.Logger;
using Outpost31.Core.NtstWebService;
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
        /// <summary>The Tingen version.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="TingenInfo"]/TingenVersion/*'/>
        public string TnVersion { get; set; }

        /// <summary>The Tingen build.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="TingenInfo"]/TingenBuild/*'/>
        public string TnBuild { get; set; }

        /// <summary>The session datestamp.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="SessionInfo"]/SessionDate/*'/>
        public string Date { get; set; }

        /// <summary>The session timestamp.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="SessionInfo"]/SessionTime/*'/>
        public string Time { get; set; }

        /// <summary>Return the cloned OptionObject.</summary>
        /// <remarks>Do we return the cloned object?</remarks>
        /// <returns>True/False.</returns>
        public bool ReturnClonedOptionObject { get; set; }

        /// <summary>Config</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="TingenInfo"]/TingenConfig/*'/>
        public ConfigSettings TnConfig { get; set; }

        /* [DN01] */
        /// <summary>Tingen Framework information.</summary>
        /// <remarks>NEED XML Build path stuff?</remarks>
        /// <returns>Paths stuff</returns>
        public Paths TnPath { get; set; }

        /// <summary>Avatar components .</summary>
        /// <remarks>NEED XML Avatar data</remarks>
        /// <returns>Avatar data</returns>
        public AvatarData AvData { get; set; }

        /// <summary>Not used.</summary>
        /// <remarks>Not used.</remarks>
        /// <returns>Netsmart web service security information.</returns>
        public NtstWebServiceSecurity NtstWebServiceSecurity { get; set; }

        /// <summary>Trace log information.</summary>
        /// <remarks>NEED XML Trace log information.</remarks>
        public TraceLog TraceInfo { get; set; }

        /// <summary>Module to open an incident.</summary>
        /// <remarks>NEED XML</remarks>
        /// <returns>What it returns</returns>
        public ModuleOpenIncident ModOpenIncident { get; set; }

        /// <summary>Builds the Tingen Session object.</summary>
        /// <param name="configFile">The path to the Tingen configuration file.</param>
        /// <param name="sentOptionObject">The OptionObject sent from Avatar.</param>
        /// <param name="sentScriptParameter">The ScriptParameter sent from Avatar.</param>
        /// <returns>An Tingen Session object.</returns>
        /// <include file='XmlDoc/Outpost31.Core.Session_doc.xml' path='Outpost31.Core.Session/Cs[@name="TingenSession"]/Build/*'/>
        public static TingenSession Build(OptionObject2015 sentOptionObject, string sentScriptParameter, string tnVersion)
        {
            LogEvent.Primeval(Assembly.GetExecutingAssembly().GetName().Name, "TingenSession.Build()");

            var staticVar = BuildStaticVars();
            var configPath = $@"{staticVar["tnDataRoot"]}\{staticVar["avSystemCode"]}\Config";

            var tnSession = new TingenSession
            {
                TnVersion = tnVersion,
                TnBuild   = staticVar["tnBuild"],
                Date      = DateTime.Now.ToString("yyMMdd"),
                Time      = DateTime.Now.ToString("HHmmss"),
                ReturnClonedOptionObject = false,
                TnConfig  = ConfigSettings.Load(configPath, staticVar["tnConfigFileName"]),
                AvData    = AvatarData.BuildObject(sentOptionObject, sentScriptParameter),
                TnPath    = Paths.Build(staticVar["tnDataRoot"], staticVar["avSystemCode"])
            };

            LogEvent.Primeval(Assembly.GetExecutingAssembly().GetName().Name, "Tingen Session created");

            /* The session-specific path is built here. */
            tnSession.TnPath.SystemCode.CurrentSession = $@"{tnSession.TnPath.SystemCode.Sessions}\{tnSession.Date}\{sentOptionObject.OptionUserId}\{tnSession.Time}-{tnSession.AvData.SentScriptParameter}";
            tnSession.TnPath.Remote.CurrentSession     = $@"{tnSession.TnPath.Remote.Sessions}\{sentOptionObject.OptionUserId}\{tnSession.Date}";

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

            tnSession.NtstWebServiceSecurity =tnSession.TnConfig.NtstWebServicesMode == "enabled"
                ? NtstWebServiceSecurity.Load(tnSession.TnPath.SystemCode.Config, staticVar["ntstSecurityFileName"])
                : new NtstWebServiceSecurity();

            Initialize(tnSession); // somewhere else?

            return tnSession;
        }

        /// <summary>Soon.</summary>
        /// <param name="tnSession"></param>
        public static void Initialize(TingenSession tnSession)
        {
            Maintenance.VerifyDirectory(tnSession.TnPath.SystemCode.CurrentSession);
            Maintenance.VerifyDirectory(tnSession.TnPath.Remote.CurrentSession);
        }

        /// <summary>TBD</summary>
        public static void WriteSessionDetails(TingenSession tnSession)
        {
            Utilities.DuFile.WriteLocal($@"{tnSession.TnPath.SystemCode.CurrentSession}\Session.md", Catalog.SessionDetails(tnSession));
            Utilities.DuFile.WriteLocal($@"{tnSession.TnPath.Remote.CurrentSession}\{tnSession.Time}-{tnSession.AvData.SentScriptParameter}.md", Catalog.SessionDetails(tnSession));
        }

        /// <summary>TBD</summary>
        public static Dictionary<string, string> BuildStaticVars()
        {
            return new Dictionary<string, string>
            {
                { "tnBuild",              "241212.1608" },
                { "avSystemCode",         "UAT" },
                { "tnDataRoot",           @"C:\TingenData" },
                { "tnConfigFileName",     "Tingen.config" },
                { "ntstSecurityFileName", "NtstSecurity.config" }
            };
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

- Do we need to verify the session path?

-----------------
[DN01] 241021
-----------------
Rename "Paths"?

*/
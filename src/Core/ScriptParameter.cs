// u240817.1048_code
// u240817.1048_documentation

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core
{
    /// <summary>Parse the Script Parameter components passed from Avatar.</summary>
    public static class ScriptParameter
    {
        /// <summary>Assembly name for logging purposes.</summary>
        /// <remarks>The assembly name is defined here so it can be used to write log files throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Parses the original Script Parameter sent from Avatar.</summary>
        /// <param name="tnSession">The TingenSession object for this session.</param>
        /// <include file='XmlDoc/Outpost31.Core_doc.xml' path='Outpost31/Cs[@name="ScriptParameter"]/ParseSent/*'/>
        public static void ParseSent(TingenSession tnSession)
        {
            LogEvent.Trace(1, ExeAsm, tnSession.TraceInfo);

            /* [01] */
            if (tnSession.AvData.SentScriptParameter.StartsWith("admin"))
            {
                LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);

                ParseAdminModule(tnSession);
            }
            else if (tnSession.AvData.SentScriptParameter.StartsWith("openincident"))
            {
                if (tnSession.TnConfig.ModOpenIncidentMode == "enabled")
                {
                    if ((tnSession.ModOpenIncident.Whitelist.Count == 0) || (tnSession.ModOpenIncident.Whitelist.Contains(tnSession.AvData.SentOptionObject.OptionUserId)))
                    {
                        LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);
                        ParseOpenIncidentModule(tnSession);
                    }
                    else
                    {
                        LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);
                        Core.Avatar.ReturnObject.Finalize(tnSession, "clone", "");
                    }
                }
                else
                {
                    LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);
                    //tnSession.ReturnClonedOptionObject = true; /* Not sure what this is 240806 */
                    Core.Avatar.ReturnObject.Finalize(tnSession, "clone", "");
                }
            }
            else if (tnSession.AvData.SentScriptParameter.StartsWith("testing"))
            {
                LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);

                ParseTestingModule(tnSession);
            }
            else
            {
                LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);
            }
        }

        /// <summary>test</summary>
        /// <param name="tnSession"></param>
        private static void ParseAdminModule(TingenSession tnSession)
        {
            LogEvent.Trace(1, ExeAsm, tnSession.TraceInfo);

            switch (tnSession.AvData.SentScriptParameter)
            {
                case "admin-service-update-mode":
                    LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);
                    Module.Admin.Service.Status.UpdateMode(tnSession.TnPath.Remote.Root, tnSession.AvData.SystemCode, tnSession.TnConfig.TingenMode, tnSession.TraceInfo);
                    break;

                case "admin-service-update-currentsettings":
                    LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);
                    Module.Admin.Service.Status.UpdateSettings(tnSession);
                    break;

                case "admin-service-update-all":
                    LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);
                    Module.Admin.Service.Status.UpdateAll(tnSession);
                    break;

                default:
                    break;
            }
        }

        private static void ParseOpenIncidentModule(TingenSession tnSession)
        {
            LogEvent.Trace(1, ExeAsm, tnSession.TraceInfo, tnSession.AvData.SentScriptParameter);

            switch (tnSession.AvData.SentScriptParameter)
            {
                case "openincident-verify-originalauthorisopening":
                    LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);
                    Module.OpenIncident.Verify.OriginalAuthorIsOpening(tnSession);
                    break;

                case "openincident-verify-originalauthorissubmitting":
                    LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);
                    Module.OpenIncident.Verify.OriginalAuthorIsSubmitting(tnSession);
                    break;

                default:
                    break;
            }
        }

        private static void ParseTestingModule(TingenSession tnSession)
        {
            LogEvent.Trace(1, ExeAsm, tnSession.TraceInfo);

            switch (tnSession.AvData.SentScriptParameter)
            {
                default:
                    break;
            }
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

-----------------
[DN01] 240817
-----------------
Does it make more sense to use a switch statement here? It may be easier to read and maintain.

*/
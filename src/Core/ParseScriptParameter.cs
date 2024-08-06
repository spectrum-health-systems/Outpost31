// u240806.1224_code
// u240806.1224_documentation

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core
{
    /// <summary>Parse the Script Parameter passed from Avatar.</summary>
    /// <include file='XMLDoc/Outpost31_doc.xml' path='Doc/Sec[@name="ParseScriptParameter}"]/ParseScriptParameter/*'/>
    public static class ParseScriptParameter
    {
        /// <summary>Assembly name for logging purposes.</summary>
        /// <remarks> The assembly name is defined here so it can be used to write log files throughout the class.</remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Parses the original Script Parameter sent from Avatar.</summary>
        /// <param name="tnSession">The TingenSession object for this session.</param>
        /// <include file='XMLDoc/Outpost31.Core_doc.xml' path='Doc/Sec[@name="ParseScriptParameter}"]/ParseSentParameter/*'/>
        public static void ParseSentParameter(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            /* [01] */
            if (tnSession.AvData.SentScriptParameter.StartsWith("admin"))
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);

                ParseAdminModule(tnSession);
            }
            else if (tnSession.AvData.SentScriptParameter.StartsWith("openincident"))
            {
                if (tnSession.TnConfig.ModOpenIncidentMode == "enabled")
                {
                    if ((tnSession.ModOpenIncident.Whitelist.Count == 0) || (tnSession.ModOpenIncident.Whitelist.Contains(tnSession.AvData.SentOptionObject.OptionUserId)))
                    {
                        LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                        ParseOpenIncidentModule(tnSession);
                    }
                    else
                    {
                        LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                        Core.Avatar.ReturnObject.Finalize(tnSession, "clone", "");
                    }
                }
                else
                {
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    //tnSession.ReturnClonedOptionObject = true; /* Not sure what this is 240806 */
                    Core.Avatar.ReturnObject.Finalize(tnSession, "clone", "");
                }
            }
            else if (tnSession.AvData.SentScriptParameter.StartsWith("testing"))
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);

                ParseTestingModule(tnSession);
            }
            else
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
            }
        }

        private static void ParseAdminModule(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            switch (tnSession.AvData.SentScriptParameter)
            {
                case "admin-service-update-mode":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    Module.Admin.Service.Status.UpdateMode(tnSession.TnPath.Remote.Root, tnSession.AvData.SystemCode, tnSession.TnConfig.TingenMode, tnSession.TraceInfo);
                    break;

                case "admin-service-update-currentsettings":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    Module.Admin.Service.Status.UpdateSettings(tnSession);
                    break;

                case "admin-service-update-all":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    Module.Admin.Service.Status.UpdateAll(tnSession);
                    break;

                default:
                    break;
            }
        }

        private static void ParseOpenIncidentModule(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo, tnSession.AvData.SentScriptParameter);

            switch (tnSession.AvData.SentScriptParameter)
            {
                case "openincident-verify-originalauthorisopening":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    Module.OpenIncident.Verify.OriginalAuthorIsOpening(tnSession);
                    break;

                case "openincident-verify-originalauthorissubmitting":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    Module.OpenIncident.Verify.OriginalAuthorIsSubmitting(tnSession);
                    break;

                default:
                    break;
            }
        }

        private static void ParseTestingModule(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

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

[01]
Does it make more sense to use a switch statement here? It may be easier to read and maintain.


*/
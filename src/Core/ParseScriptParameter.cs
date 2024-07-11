// u240620.1356

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core
{
    /// <summary>Soon.</summary>
    public static class ParseScriptParameter
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Executing assembly is defined here so it can be used when creating log files.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>OLD Determines which Tingen <i>Module</i> will be doing the work this session.</summary>
        /// <param name="tnSession">The Tingen session object.</param>
        /// <remarks>
        ///  <para> When a new Tingen Module is added, this method needs to be updated.
        ///   <example>
        ///    To add a new Tingen Module named "NewModule", the following code <c>else if</c> needs be added
        ///     <code>
        ///      else if (tnSession.AvComponents.ScriptModule == "newmodule")
        ///      {
        ///          Outpost31.Module.NewModule.ParseScriptCommand.ParseCommand(tnSession);
        ///      }
        ///     </code>
        ///    </example>
        ///   </para>
        /// </remarks>
        public static void Parse(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

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
                    //tnSession.ReturnClonedOptionObject = true;
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

_Documentation updated ------
*/
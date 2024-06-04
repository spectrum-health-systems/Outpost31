// u240603.1712

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core
{
    public static class Roundhouse
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    The executing assembly is defined at the start of the class so it can be easily used throughout the class when creating
        ///    log files.
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
            LogEvent.Trace(1, tnSession, AssemblyName);

            if (tnSession.TingenMode == "development")
            {
                LogEvent.Trace(2, tnSession, AssemblyName);

                // TODO
                //PrimevalLog.DevelopmentCleanup();
            }

            switch (tnSession.AvData.SentScriptParameter)
            {
                case "admin-service-mode-update":
                    LogEvent.Trace(2, tnSession, AssemblyName);
                    Module.Admin.Service.ModeUpdate(tnSession.TingenMode, tnSession.AvatarSystemCode, tnSession.TnFramework.ServiceStatusPaths, tnSession.TraceInfo);
                    break;

                case "admin-service-currentsettings-update":
                    LogEvent.Trace(2, tnSession, AssemblyName);
                    Module.Admin.Service.CurrentSettingsUpdate(tnSession);
                    break;

                case "admin-service-all-update":
                    LogEvent.Trace(2, tnSession, AssemblyName);
                    Module.Admin.Service.AllUpdate(tnSession);
                    break;

                case "admin-framework-archive-all":
                    LogEvent.Trace(2, tnSession, AssemblyName);
                    break;

                case "admin-framework-archive-logs":
                    LogEvent.Trace(2, tnSession, AssemblyName);
                    break;

                case "common-field-lock-id":
                    LogEvent.Trace(2, tnSession, AssemblyName);
                    break;

                case "common-field-save-id":
                    LogEvent.Trace(2, tnSession, AssemblyName);
                    break;

                default:
                    LogEvent.Trace(2, tnSession, AssemblyName);
                    // TODO: Exit gracefully
                    break;
            }
        }
    }
}
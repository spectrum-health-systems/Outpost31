// u240605.1102

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core
{
    /// <summary>Soon.</summary>
    public static class Roundhouse
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Executing assembly is defined here so it can be used when creating log files.
        ///   </para>
        /// </remarks>
        public static string Asm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

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
            LogEvent.Trace(1, tnSession, Asm);

            if (tnSession.TingenMode == "development")
            {
                LogEvent.Trace(2, tnSession, Asm);

                // TODO
                //PrimevalLog.DevelopmentCleanup();
            }

            switch (tnSession.AvatarData.ScriptParameter)
            {
                case "admin-service-mode-update":
                    LogEvent.Trace(2, tnSession, Asm);
                    Module.Admin.Service.ModeUpdate(tnSession.TingenMode, tnSession.AvatarSystemCode, tnSession.Framework.ServiceStatusPaths, tnSession.TraceLogs);
                    break;

                case "admin-service-currentsettings-update":
                    LogEvent.Trace(2, tnSession, Asm);
                    Module.Admin.Service.CurrentSettingsUpdate(tnSession);
                    break;

                case "admin-service-all-update":
                    LogEvent.Trace(2, tnSession, Asm);
                    Module.Admin.Service.AllUpdate(tnSession);
                    break;

                case "admin-framework-archive-all":
                    LogEvent.Trace(2, tnSession, Asm);
                    break;

                case "admin-framework-archive-logs":
                    LogEvent.Trace(2, tnSession, Asm);
                    break;

                case "common-field-lock-id":
                    LogEvent.Trace(2, tnSession, Asm);
                    break;

                case "common-field-save-id":
                    LogEvent.Trace(2, tnSession, Asm);
                    break;

                default:
                    LogEvent.Trace(2, tnSession, Asm);
                    // TODO: Exit gracefully
                    break;
            }
        }
    }
}

/*

Development notes
-----------------

*/
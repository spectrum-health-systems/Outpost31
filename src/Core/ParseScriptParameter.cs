// u240607.1024

using System;
using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;
using Outpost31.Module.Testing.NtstWebService;

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

            if (tnSession.TnConfig.TingenMode == "development")
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);

                // TODO - broken?
                //PrimevalLog.DevelopmentCleanup();
            }

            if (tnSession.AvData.SentScriptParameter.StartsWith("admin"))
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);

                ParseAdminModule(tnSession);
            }
            else if (tnSession.AvData.SentScriptParameter.StartsWith("openincident"))
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);

                ParseOpenIncidentModule(tnSession);
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



            //switch (tnSession.AvData.SentScriptParameter)
            //{
            //    /* Admin Module */

            //    case "admin-service-mode-update":
            //        LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
            //        Module.Admin.Service.Status.UpdateMode(tnSession.TnConfig.TingenMode, tnSession.AvData.AvatarSystemCode, tnSession.TnConfig.TingenMode, tnSession.TraceInfo);
            //        break;

            //    case "admin-service-currentsettings-update":
            //        LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
            //        Module.Admin.Service.Status.UpdateSettings(tnSession);
            //        break;

            //    case "admin-service-all-update":
            //        LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
            //        Module.Admin.Service.Status.UpdateAll(tnSession);
            //        break;

            //    /* Open Incident Module */

            //    case "openincident-verify-authorisviewing":
            //        LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
            //        Module.OpenIncident.Action.Verify.AuthorIsViewing(tnSession);
            //        break;

            //    /* Fall through */

            //    default:
            //        LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
            //        // TODO: Exit gracefully
            //        break;
            //}
        }

        private static void ParseAdminModule(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            switch (tnSession.AvData.SentScriptParameter)
            {
                case "admin-service-update-mode":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);

                    Module.Admin.Service.Status.UpdateMode(tnSession.TnPath.Remote.Root, tnSession.AvData.AvatarSystemCode, tnSession.TnConfig.TingenMode, tnSession.TraceInfo);

                    break;

                case "admin-service-update-currentsettings":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);

                    Module.Admin.Service.Status.UpdateSettings(tnSession);
                    break;

                case "admin-service-update-all":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);

                    Module.Admin.Service.Status.UpdateAll(tnSession);
                    break;
            }
        }

        private static void ParseOpenIncidentModule(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            switch (tnSession.AvData.SentScriptParameter)
            {
                case "openincident-verify-authorisviewing":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    // Module.OpenIncident.Verify.AuthorIsViewing(tnSession);
                    break;
            }
        }

        private static void ParseTestingModule(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            switch (tnSession.AvData.SentScriptParameter)
            {
                case "testing-ntstwebservice-usermgmt-doesuserexist":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    Module.Testing.NtstWebService.UserMgmt.DoesExist(tnSession);
                    break;
            }
        }
    }
}

/*

-----------------
Development notes
-----------------

*/
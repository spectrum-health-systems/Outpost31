// u240531.0722

using Outpost31.Core.Session;

namespace Outpost31.Core
{
    public static class Roundhouse
    {
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
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Common.Parse.Module()]"); /* <- For development use only */

            //var module  = tnSession.AvComponents.ScriptModule;
            //var command = tnSession.AvComponents.ScriptCommand;
            //var action  = tnSession.AvComponents.ScriptAction;
            //var option  = tnSession.AvComponents.ScriptOption;

            switch (tnSession.AvData.SentScriptParameter)
            {
                case "admin-service-mode-update":
                    Outpost31.Core.Debuggler.PrimevalLog.Create($"[{tnSession.AvData.SentScriptParameter}/admin-service-mode-update]"); /* <- For development use only */
                    Module.Admin.Service.ModeUpdate(tnSession.TingenMode, tnSession.AvatarSystemCode, tnSession.TnFramework.ServiceStatusPaths);
                    break;

                case "admin-framework-archive-all":
                    break;

                case "admin-framework-archive-logs":
                    break;

                case "common-field-lock-id":
                    break;

                case "common-field-save-id":
                    break;

                default:
                    // TODO: Exit gracefully
                    break;
            }
        }
    }
}
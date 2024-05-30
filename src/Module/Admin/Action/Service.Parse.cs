// u240530.1211

using System.Collections.Generic;
using Outpost31.Core.Session;

namespace Outpost31.Module.Admin.Action
{
    /// <summary>Parsing logic for the <b>Service</b> Command of the Admin (see Service.cs for more information about this class).</summary>
    public static partial class Service
    {
        /// <summary>Parses the script Action for the Admin Module's "Service" Command.</summary>
        /// <remarks>
        ///  <para>
        ///   Valid Admin Actions:
        ///   <list type="table">
        ///     <item>
        ///      <term>Status</term>
        ///      <description>Request the status of the Tingen web service.</description>
        ///     </item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public static void ParseAction(TingenSession tnSession)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.Action.Service.ParseAction()]"); /* <- For development use only */

            switch (tnSession.AvComponents.ScriptAction)
            {
                case "status":
                    ParseStatusOption(tnSession);
                    break;

                default:
                    break;
            }
        }

        /// <summary>Parses the script Option for the Admin Module's "Status" Action.</summary>
        public static void ParseStatusOption(TingenSession tnSession)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.Action.Service.ParseStatusOption()]"); /* <- For development use only */

            switch (tnSession.AvComponents.ScriptOption)
            {
                case "update":
                    Outpost31.Module.Admin.Action.Service.StatusUpdate(tnSession.TingenMode, tnSession.AvatarSystemCode, tnSession.TnFramework.ServiceStatusPaths);
                    break;

                default:
                    break;
            }
        }
    }
}
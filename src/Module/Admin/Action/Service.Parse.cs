using Outpost31.Core.Session;

namespace Outpost31.Module.Admin.Action
{
    public static partial class Service
    {
        public static void ParseAction(TingenSession tnSession)
        {
            Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.Action.Service.ParseAction()]"); /* <- For development use only */

            switch (tnSession.AvComponents.ScriptAction)
            {
                case "status":
                    ParseStatusOption(tnSession);
                    break;

                default:
                    break;
            }

        }

        public static void ParseStatusOption(TingenSession tnSession)
        {
            Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.Action.Service.ParseStatusOption()]"); /* <- For development use only */

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

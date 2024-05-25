using Outpost31.Core.Session;

namespace Outpost31.Module.Admin
{
    public static class ParseScriptCommand
    {
        public static void ParseCommand(TingenSession tnSession)
        {
            Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.ParseScriptCommand()]"); /* <- For development use only */

            switch (tnSession.AvComponents.ScriptCommand)
            {
                case "service":
                    Outpost31.Module.Admin.Action.Service.ParseAction(tnSession);
                    break;

                default:
                    break;
            }
        }
    }
}

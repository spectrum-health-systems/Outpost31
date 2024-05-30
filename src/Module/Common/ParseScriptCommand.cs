// u240530.1557

using Outpost31.Core.Session;

namespace Outpost31.Module.Common
{
    public static class ParseScriptCommand
    {
        public static void ParseCommand(TingenSession tnSession)
        {
            Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.ParseCommand()]"); /* <- For development use only */

            switch (tnSession.AvComponents.ScriptCommand)
            {
                case "field":
                    Outpost31.Module.Common.Action.Field.ParseAction(tnSession);
                    break;

                default:
                    break;
            }
        }
    }
}

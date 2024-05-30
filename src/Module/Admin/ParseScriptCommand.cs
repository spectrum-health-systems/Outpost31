// u240530.1259

using Outpost31.Core.Session;

namespace Outpost31.Module.Admin
{
    /// <summary>Contains the logic for parsing the script Command for the Admin Module.</summary>
    public static class ParseScriptCommand
    {
        /// <summary>Parses the script Command.</summary>
        public static void ParseCommand(TingenSession tnSession)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.ParseCommand()]"); /* <- For development use only */

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
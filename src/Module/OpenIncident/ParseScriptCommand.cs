// u240530.1231

using Outpost31.Core.Session;

namespace Outpost31.Module.OpenIncident
{
    /// <summary>Contains the logic for parsing the script Command for the OpenIncident Module.</summary>
    public static class ParseScriptCommand
    {
        /// <summary>Parses the script Command.</summary>
        public static void ParseCommand(TingenSession tnSession)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.OpenIncident.ParseScriptCommand()]"); /* <- For development use only */
            
            switch (tnSession.AvComponents.ScriptCommand)
            {
                case "verifyauthor":
                    Outpost31.Module.OpenIncident.Action.VerifyAuthor.ParseAction(tnSession);
                    break;

                default:
                    break;
            }
        }
    }
}
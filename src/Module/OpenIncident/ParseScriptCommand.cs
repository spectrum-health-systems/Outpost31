// u240528.1744

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outpost31.Core.Session;

namespace Outpost31.Module.OpenIncident
{
    public static class ParseScriptCommand
    {
        public static void ParseCommand(TingenSession tnSession)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.OpenIncident.ParseScriptCommand()]"); /* <- For development use only */
            Outpost31.Core.Debuggler.Primeval.Log($"[001]");
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
// u240528.1744

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outpost31.Core.Session;

namespace Outpost31.Module.OpenIncident.Action
{
    public static partial class VerifyAuthor
    {
        public static void ParseAction(TingenSession tnSession)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.Action.Service.ParseAction()]"); /* <- For development use only */
            Outpost31.Core.Debuggler.Primeval.Log($"[zz]");
            switch (tnSession.AvComponents.ScriptAction)
            {
                case "isoriginal":
                    IsOriginal(tnSession);
                    break;

                case "saveoriginal":
                    SaveOriginal(tnSession);
                    break;

                default:
                    break;
            }

        }
    }
}

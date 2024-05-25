// u240525.1957

using Outpost31.Core.Session;

namespace Outpost31.Core.Common
{
    /// <summary>Parses the <b>Module</b> component of the ScriptParameter.</summary>
    public static class ParseScriptModule
    {
        /// <summary>Determines which Tingen <i>Module</i> will be doing the work this session.</summary>
        /// <param name="tnSession">The Tingen session object.</param>
        public static void Run(TingenSession tnSession)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Common.ParseScriptModule.Run()]"); /* <- For development use only */

            if (tnSession.AvComponents.ScriptModule == "admin")
            {
                Outpost31.Module.Admin.ParseScriptCommand.ParseCommand(tnSession);
            }
            else if (tnSession.AvComponents.ScriptModule == "testing")
            {
                // Testing module goes here!
            }
            else
            {
                // Exit gracefully.
            }
        }
    }
}
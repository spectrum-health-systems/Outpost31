// u240530.0736

using Outpost31.Core.Session;

namespace Outpost31.Core.Common
{
    /// <summary>Parses the <i>Module</i> component of the ScriptParameter.</summary>
    public static class ParseScriptModule
    {
        /// <summary>Determines which Tingen <i>Module</i> will be doing the work this session.</summary>
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
        public static void ParseModule(TingenSession tnSession)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Common.ParseScriptModule.ParseModule()]"); /* <- For development use only */

            if (tnSession.AvComponents.ScriptModule == "admin")
            {
                Outpost31.Module.Admin.ParseScriptCommand.ParseCommand(tnSession);
            }
            else if (tnSession.AvComponents.ScriptModule == "openincident")
            {
                Outpost31.Module.OpenIncident.ParseScriptCommand.ParseCommand(tnSession);
            }
            else
            {
                // TODO Need to add code here to exit gracefully.
            }
        }
    }
}
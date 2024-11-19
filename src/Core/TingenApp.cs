// u2241119.0831_code
// u241119_documentation

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core
{
    /// <summary>High level logic for the Tingen application.</summary>
    /// <include file='XmlDoc/Outpost31.Core_doc.xml' path='Outpost31/Cs[@name="TingenApp"]/TingenApp/*'/>
    public static class TingenApp
    {
        /// <summary>The executing Assembly name.</summary>
        /// <remarks>A required component for writing log files, defined here so it can be used throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Starts the Tingen web service.</summary>
        /// <param name="tnSession">The TingenSession object for this session.</param>
        /// <include file='XmlDoc/Outpost31.Core_doc.xml' path='Outpost31/Cs[@name="TingenApp"]/StartApp/*'/>
        public static void StartApp(TingenSession tnSession)
        {
            LogEvent.Trace(1, ExeAsm, tnSession.TraceInfo);

            /* [DN01] */
            switch (tnSession.TnConfig.TingenMode)
            {
                case "disabled":
                    LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);

                    Framework.Refresh.RefreshOnDisable(tnSession);

                    //tnSession.ReturnClonedOptionObject = true; /* Not sure what this is 240806 */

                    Core.Avatar.ReturnObject.Finalize(tnSession, "clone", "");

                    break;

                case "enabled":
                    LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);

                    ScriptParameter.ParseSent(tnSession);

                    break;

                /* [DN02] */
                default: // Tingen is in an unknown state
                    LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);

                    Framework.Refresh.RefreshOnUnknown(tnSession);

                    break;
            }
        }

        /// <summary>Stops the Tingen web service.</summary>
        /// <param name="tnSession">The TingenSession object for this session.</param>
        public static void StopApp(TingenSession tnSession)
        {
            LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);

            /* Not sure what this is 240806 */
            //if (tnSession.ReturnClonedOptionObject == true)
            //{
            //    Core.Avatar.ReturnObject.Finalize(tnSession, "clone", "");
            //}
            // Else, we assume the ReturnOptionObject was formatted correctly by whatever work was done. // <-- DON'T ASSUME

            TingenSession.WriteSessionDetails(tnSession);
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

-----------------
[DN01] 240817
-----------------
As of v24.8, the TingenMode must be either "enabled" or "disabled".

If the TingenMode is "enable" or "disable" (which I've done when testing, so it's not an edge case), the Tingen will enter an "unknown"
state.

For now, users should verify that the TingenMode is "enabled" or "disabled", but it may make sense to catch other valuessuch as
"enable" or "disable".

[DN02] 240817
It may be worth adding other modes:

- "development": This mode would remove all Primeval logs and all UAT Session data, and would be useful for testing.
- "passthrough": This mode would be a mix between "enabled" and "disabled", where Tingen would run and create logs, but
                 would not make any modifications to the OptionObject.
*/
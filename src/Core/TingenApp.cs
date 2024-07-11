// u240620.1357

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core
{
    public static class TingenApp
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;


        /// <summary>Start the Tingen web service.</summary>
        /// <param name="tnSession">The TingenSession object for this session.</param>
        public static void Start(TingenSession tnSession)
        {
            // TODO: catch "enable" and "disable"?

            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            switch (tnSession.TnConfig.TingenMode)
            {
                case "disabled":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    Framework.Refresh.RefreshOnDisable(tnSession);
                    //tnSession.ReturnClonedOptionObject = true;
                    Core.Avatar.ReturnObject.Finalize(tnSession, "clone", "");

                    break;

                case "enabled":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    ParseScriptParameter.Parse(tnSession);

                    break;

                default:
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    Framework.Refresh.RefreshOnUnknown(tnSession);

                    break;
            }
        }

        /// <summary>Handles any logic related to stopping Tingen.</summary>
        public static void Stop(TingenSession tnSession)
        {
            LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);

            //if (tnSession.ReturnClonedOptionObject == true)
            //{
            //    Core.Avatar.ReturnObject.Finalize(tnSession, "clone", "");
            //}
            // Else, we assume the ReturnOptionObject was formmated correctly by whatever work was done.

            TingenSession.WriteSessionDetails(tnSession);
        }
    }
}


/*
=================
DEVELOPMENT NOTES
=================

- Add a "development" mode:
    - Removes all Primeval logs
    - Removes all Session data (UAT only)

_Documentation updated ------
*/
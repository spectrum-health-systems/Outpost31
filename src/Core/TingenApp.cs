// u240607.0917

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
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            switch (tnSession.TnConfig.TingenMode)
            {
                case "disabled":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    Framework.Refresh.RefreshOnDisable(tnSession);

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

            if (tnSession.TnConfig.TingenMode == "disabled")
            {
                Core.Avatar.OptionObjects.ReturnClone(tnSession);
            }
            // Else, we assume the ReturnOptionObject was formmated correctly by whatever work was done.

            TingenSession.WriteSessionDetails(tnSession);
        }
    }
}

/*

-----------------
Development notes
-----------------

*/

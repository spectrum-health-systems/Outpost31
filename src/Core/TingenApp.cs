// u240607.0917

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
                tnSession.AvData.ReturnOptionObject = tnSession.AvData.SentOptionObject.Clone(); // TODO move to core functionality
            }
            else
            {
                tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone(); // TODO move to core functionality
            }

        }
    }
}

/*

-----------------
Development notes
-----------------

*/

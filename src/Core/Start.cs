using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core
{
    public static class Start
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        public static void WebApp(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            switch (tnSession.TnConfig.TingenMode)
            {
                case "disabled":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);

                    Outpost31.Core.Framework.Refresh.RefreshOnDisable(tnSession);

                    //Stop.WebApp(tnSession);

                    break;

                case "development":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);

                    Outpost31.Core.Framework.Refresh.RefreshOnDevelopment(tnSession);

                    Outpost31.Core.Roundhouse.Parse(tnSession);
                    //Start.WebApp(tnSession);

                    //Stop.WebApp(tnSession);

                    break;

                default: // "enabled"
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);

                    Outpost31.Core.Roundhouse.Parse(tnSession);
                    //Start.WebApp(tnSession);

                    //Stop.WebApp(tnSession);

                    break;
            }

        }
    }
}

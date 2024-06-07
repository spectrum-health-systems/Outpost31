using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core
{
    public static class Stop
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
            LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);

            if (tnSession.TnConfig.TingenMode == "disabled")
            {
                tnSession.AvData.ReturnOptionObject = tnSession.AvData.SentOptionObject.Clone(); // TODO move to core functionality
            }
            else
            {
                tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone(); // TODO move to core functionality
            }

            ////var path = $@"{tnSession.TnPath.SystemCode.CurrentSession}\Session.md";

            ////File.WriteAllText(path, Catalog.SessionDetails(tnSession));
        }
    }
}

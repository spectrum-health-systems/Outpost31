// u240603.1703

using System.Reflection;
using System.Runtime.CompilerServices;
using Outpost31.Core.Session;

namespace Outpost31.Core.Logger
{
    /// <summary>Provides logging functionality.</summary>
    public static class LogEvent
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    The executing assembly is defined at the start of the class so it can be easily used throughout the class when creating
        ///    log files.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Creates a trace log.</summary>
        /// <remarks>
        ///  <para>
        ///    Trace logs are used to record major session events.
        ///  </para>
        /// </remarks>
        public static void Trace(TingenSession tnSession, string assemblyName, string fileContent = "Trace log.", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            /* Since we can't put a trace log here, we'll use a Primeval log to debug.
             */
            //LogEvent.Primeval(AssemblyName);

            TraceLog.Create(tnSession.TraceInfo, assemblyName, fileContent, callPath, callMember, callLine);
        }

        public static void Trace(TraceLog traceInfo, string assemblyName, string fileContent = "Trace log.", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            /* Since we can't put a trace log here, we'll use a Primeval log to debug.
             */
            //LogEvent.Primeval(AssemblyName);

            TraceLog.Create(traceInfo, assemblyName, fileContent, callPath, callMember, callLine);
        }

        public static void Primeval(string assemblyName, string fileContent = "[TINGEN PRIMEVAL LOG]", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            /* Can't do any logging here.
             */

            PrimevalLog.Create(assemblyName, fileContent, callPath, callMember, callLine);
        }
    }
}
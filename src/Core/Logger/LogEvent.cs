// u240605.1157

using System.Reflection;
using System.Runtime.CompilerServices;

namespace Outpost31.Core.Logger
{
    /// <summary>Provides logging functionality.</summary>
    public static class LogEvent
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string Asm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;


        /* THIS IS PROBABLY DEPRECIATED
         */
        ///// <summary>Creates a trace log.</summary>
        ///// <remarks>
        /////  <para>
        /////    Trace logs are used to record major session events.
        /////  </para>
        ///// </remarks>
        //public static void Trace(int traceLevel, TingenSession tnSession, string assemblyName, [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        //{
        //    //* For debugging */
        //    //LogEvent.Primeval(Asm);

        //    TraceLog.Create(traceLevel, tnSession.TraceLogs, assemblyName, callPath, callMember, callLine);
        //}

        /// <summary>Creates a trace log.</summary>
        /// <remarks>
        ///  <para>
        ///    Trace logs are used to record major session events.
        ///  </para>
        /// </remarks>
        public static void Trace(int traceLevel, TraceLog traceInfo, string assemblyName, string fileContent = "Trace log.", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            TraceLog.Create(traceLevel, traceInfo, assemblyName, callPath, callMember, callLine);
        }

        public static void Primeval(string assemblyName, string fileContent = "[TINGEN PRIMEVAL LOG]", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            /* Can't do any logging here. Sorry! */

            PrimevalLog.Create(assemblyName, fileContent, callPath, callMember, callLine);
        }
    }
}

/*

Development notes
-----------------

*/
// u240605.1157

using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Outpost31.Core.Logger
{
    /// <summary>Provides logging functionality.</summary>
    public static class LogEvent
    {
        /// <summary>Creates a trace log.</summary>
        /// <remarks>
        ///  <para>
        ///    Trace logs are used to record major session events.
        ///  </para>
        /// </remarks>
        //public static void Trace(int traceLevel, TraceLog traceInfo, string assemblyName, string fileContent = "Trace log.", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        public static void Trace(int logLevel, string asm, TraceLogInfo traceInfo, string fileContent = "Trace log.", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            TraceLogInfo.Create(asm, logLevel, traceInfo, callPath, callMember, callLine);
        }

        public static void Primeval(string asm, string fileContent = "[TINGEN PRIMEVAL LOG]", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            /* Can't do any logging here. Sorry! */

            PrimevalLog.Create(asm, fileContent, callPath, callMember, callLine);
        }
    }
}

/*

Development notes
-----------------

*/
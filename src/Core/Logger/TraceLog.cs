// u240605.1115

using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Outpost31.Core.Logger
{
    /// <summary>Soon.</summary>
    public partial class TraceLog
    {
        /// <summary>Build the trace log information.</summary>
        /// <param name="mode"></param>
        /// <param name="delay"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static TraceLog BuildInfo(string path, int mode, int delay)
        {
            return new TraceLog
            {
                TraceLogPath  = $@"{path}\Tracelog",
                TraceLogLevel = mode,
                TraceLogDelay = delay
            };
        }

        /// <summary>Soon.</summary>
        /// <param name="traceLevel"></param>
        /// <param name="traceInfo"></param>
        /// <param name="assemblyName"></param>
        /// <param name="callPath"></param>
        /// <param name="callMember"></param>
        /// <param name="callLine"></param>
        public static void Create(int traceLevel, TraceLog traceInfo, string assemblyName, [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            var calledClass = callPath.Split('\\').Last();

            if (traceLevel <= traceInfo.TraceLogLevel)
            {
                Thread.Sleep(traceInfo.TraceLogDelay);
                SimpleTrace(assemblyName, traceInfo.TraceLogPath, calledClass, callMember, callLine);
            }
        }

        /// <summary>Soon.</summary>
        /// <param name="assemblyName"></param>
        /// <param name="sessionPath"></param>
        /// <param name="calledClass"></param>
        /// <param name="calledMethod"></param>
        /// <param name="calledLine"></param>
        public static void SimpleTrace(string assemblyName, string sessionPath, string calledClass, string calledMethod, int calledLine)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            var filePath = $@"{sessionPath}\{DateTime.Now:fffffff}-{calledClass}-{calledLine}.trace";

            File.WriteAllText(filePath, "");
        }
    }
}

/*

Development notes
-----------------

- Move properties from TraceLog.Properties.cs to here.
*/
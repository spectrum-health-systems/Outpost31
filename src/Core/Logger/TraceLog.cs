// u240605.1115

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Outpost31.Core.Logger
{
    /// <summary>Soon.</summary>
    public class TraceLogInfo
    {
        public string LogPath { get; set; }
        public int LogLevel { get; set; }
        public int LogDelay { get; set; }

        /// <summary>Build the trace log information.</summary>
        /// <param name="traceLogLevel"></param>
        /// <param name="traceLogDelay"></param>
        /// <param name="traceLogPath"></param>
        /// <returns></returns>
        public static TraceLogInfo Build(string traceLogPath, int traceLogLevel, int traceLogDelay)
        {
            return new TraceLogInfo
            {
                LogPath  = traceLogPath,
                LogLevel = traceLogLevel,
                LogDelay = traceLogDelay
            };
        }

        /// <summary>Soon.</summary>
        /// <param name="traceLevel"></param>
        /// <param name="traceInfo"></param>
        /// <param name="assemblyName"></param>
        /// <param name="callPath"></param>
        /// <param name="callMember"></param>
        /// <param name="callLine"></param>
        public static void Create(string asm, int logLevel, TraceLogInfo traceInfo, [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            var calledClass = callPath.Split('\\').Last();

            if (logLevel <= traceInfo.LogLevel)
            {
                Thread.Sleep(traceInfo.LogDelay);
                SimpleTrace(asm, traceInfo.LogPath, calledClass, callMember, callLine);
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
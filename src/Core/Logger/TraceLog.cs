// u240620.1354

using System;
using System.IO;
using System.Threading;

namespace Outpost31.Core.Logger
{
    /// <summary>Soon.</summary>
    public class TraceLog
    {
        public string TraceLogPath { get; set; }
        public int TraceLogLevel { get; set; }
        public int TraceLogDelay { get; set; }

        /// <summary>Build the trace log information.</summary>
        /// <remarks>
        /// The <b>TraceLogPath</b> is the same as the <b>tnSession.Framework.SystemCodePath.Session</b> It's here so we can easily pass all the data
        /// </remarks>
        /// <param name="traceLogLevel"></param>
        /// <param name="traceLogDelay"></param>
        /// <param name="traceLogPath"></param>
        /// <returns></returns>
        public static TraceLog BuildInfo(string traceLogPath, int traceLogLevel, int traceLogDelay)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            return new TraceLog
            {
                TraceLogPath  = traceLogPath,
                TraceLogLevel = traceLogLevel,
                TraceLogDelay = traceLogDelay
            };
        }

        /// <summary>Soon.</summary>
        /// <param name="traceLevel"></param>
        /// <param name="traceInfo"></param>
        /// <param name="assemblyName"></param>
        /// <param name="callPath"></param>
        /// <param name="callMember"></param>
        /// <param name="callLine"></param>
        public static void Create(int logLevel, string assemblyName, TraceLog traceInfo, string fromClass, string fromMethod, int line)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            if (logLevel <= traceInfo.TraceLogLevel)
            {
                Thread.Sleep(traceInfo.TraceLogDelay);

                var traceLogPath = $@"{traceInfo.TraceLogPath}\{DateTime.Now:mmssfffffff}_{assemblyName}-{fromClass}-{fromMethod}-{line}.trace";

                File.Create(traceLogPath).Dispose();

            }
        }

        /// <summary>Soon.</summary>
        /// <param name="logLevel"></param>
        /// <param name="assemblyName"></param>
        /// <param name="traceInfo"></param>
        /// <param name="fromClass"></param>
        /// <param name="fromMethod"></param>
        /// <param name="line"></param>
        /// <param name="message"></param>
        public static void Create(int logLevel, string assemblyName, TraceLog traceInfo, string fromClass, string fromMethod, int line, string message)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            if (logLevel <= traceInfo.TraceLogLevel)
            {
                Thread.Sleep(traceInfo.TraceLogDelay);

                var traceLogPath = $@"{traceInfo.TraceLogPath}\{DateTime.Now:mmssfffffff}_{assemblyName}-{fromClass}-{fromMethod}-{line}.trace";

                File.WriteAllText(traceLogPath, message);
            }
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

_Documentation updated ------
*/
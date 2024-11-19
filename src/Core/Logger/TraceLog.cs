// u240709.0000_code
// u241021_documentation

using System;
using System.IO;
using System.Threading;

namespace Outpost31.Core.Logger
{
    /// <summary>Trace logs.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Logger.TraceLog_doc.xml' path='Outpost31.Core.Logger.TraceLog/Type[@name="Class"]/TraceLog/*'/>
    public class TraceLog
    {
        /// <summary>Path to the TraceLog</summary>
        /// <include file='XmlDoc/Outpost31.Core.Logger.TraceLog_doc.xml' path='Outpost31.Core.Logger.TraceLog/Type[@name="Property"]/TraceLogPath/*'/>
        public string TraceLogPath { get; set; }

        /// <summary>TraceLogLevel</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Logs"]/TraceLevel/*'/>
        public int TraceLogLevel { get; set; }

        /// <summary>TraceLogDelay</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Logs"]/TraceDelay/*'/>
        public int TraceLogDelay { get; set; }

        /// <summary>Build the trace log information.</summary>
        /// <param name="traceLogLevel">TraceLog level</param>
        /// <param name="traceLogDelay">TraceLog delay</param>
        /// <param name="traceLogPath">TraceLog path</param>
        /// <remarks>Builds the Trace Log information.</remarks>
        /// <returns>TraceLog information.</returns>
        public static TraceLog BuildInfo(string traceLogPath, int traceLogLevel, int traceLogDelay)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

            return new TraceLog
            {
                TraceLogPath  = traceLogPath,
                TraceLogLevel = traceLogLevel,
                TraceLogDelay = traceLogDelay
            };
        }

        /* [DN01] */
        /// <summary>Create a TraceLog</summary>
        /// <param name="traceLevel">TraceLog level</param>
        /// <param name="traceInfo">Tracelog information</param>
        /// <param name="assemblyName">Executing assembly</param>
        /// <param name="callPath">Called class</param>
        /// <param name="callMember">Called method</param>
        /// <param name="callLine">Called line</param>
        /// <include file='XmlDoc/Outpost31.Core.Logger.TraceLog_doc.xml' path='Outpost31.Core.Logger.TraceLog/Type[@name="Method"]/Create/*'/>
        public static void Create(int logLevel, string assemblyName, TraceLog traceInfo, string fromClass, string fromMethod, int line)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

            if (logLevel <= traceInfo.TraceLogLevel)
            {
                Thread.Sleep(traceInfo.TraceLogDelay);

                var traceLogPath = $@"{traceInfo.TraceLogPath}\{DateTime.Now:mmssfffffff}_{assemblyName}-{fromClass}-{fromMethod}-{line}.trace";

                File.Create(traceLogPath).Dispose();
            }
        }

        /* [DN01] */
        /// <summary>Soon.</summary>
        /// <param name="logLevel">TraceLog level</param>
        /// <param name="assemblyName">Executing assembly</param>
        /// <param name="traceInfo">Tracelog information</param>
        /// <param name="fromClass">Called class</param>
        /// <param name="fromMethod">Called method</param>
        /// <param name="line">Called line</param>
        /// <param name="message">Log message</param>
        /// <include file='XmlDoc/Outpost31.Core.Logger.TraceLog_doc.xml' path='Outpost31.Core.Logger.TraceLog/Type[@name="Method"]/Create_WithMessage/*'/>
        public static void Create(int logLevel, string assemblyName, TraceLog traceInfo, string fromClass, string fromMethod, int line, string message)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

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

-----------------
[DN01] 241021
-----------------
These should standardized.

*/
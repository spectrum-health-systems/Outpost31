﻿// u241231.1058_code
// u241231_documentation

using System.Linq;
using System.Runtime.CompilerServices;

namespace Outpost31.Core.Logger
{
    /// <summary>Provides logging functionality.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Logger.LogEvent_doc.xml' path='Outpost31.Core.Logger.LogEvent/Type[@name="Class"]/LogEvent/*'/>

    public static class LogEvent
    {
        /// <summary>Log a trace event.</summary>
        /// <include file='XmlDoc/Outpost31.Core.Logger.LogEvent_doc.xml' path='Outpost31.Core.Logger.LogEvent/Type[@name="Method"]/Trace/*'/>
        public static void Trace(int logLevel, string assemblyName, TraceLog traceInfo, string message = "", [CallerFilePath] string fromPath = "", [CallerMemberName] string fromMethod = "", [CallerLineNumber] int line = 0)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

            var fromClass = fromPath.Split('\\').Last();

            if (string.IsNullOrEmpty(message))
            {
                TraceLog.Create(logLevel, assemblyName, traceInfo, fromClass, fromMethod, line);
            }
            else
            {
                TraceLog.Create(logLevel, assemblyName, traceInfo, fromClass, fromMethod, line, message);
            }
        }

        /// <summary>Log a primeval event.</summary>
        /// <include file='XmlDoc/Outpost31.Core.Logger.LogEvent_doc.xml' path='Outpost31.Core.Logger.LogEvent/Type[@name="Method"]/Primeval/*'/>

        public static void Primeval(string assemblyName, string message = "Tingen primeval log", [CallerFilePath] string fromPath = "", [CallerMemberName] string fromMethod = "", [CallerLineNumber] int line = 0)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet.
             *
             * You can't put a Primeval Log here either, since that may result in an infinite loop/stack overflow
             * when Primeval log directory is being refreshed.
             *
             * So, no logging for you!
             */

            var fromClass = fromPath.Split('\\').Last();

            PrimevalLog.Create(assemblyName, message, fromClass, fromMethod, line);
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

*/
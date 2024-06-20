// u240620.1337

using System.Linq;
using System.Runtime.CompilerServices;

namespace Outpost31.Core.Logger
{
    /// <summary>Provides logging functionality.</summary>
    public static class LogEvent
    {
        /// <summary>Log a trace event.</summary>
        /// <remarks>
        ///  <para>
        ///   Trace logs are used to record information about the application's execution.
        ///   <list type="bullet">
        ///    <item>Records information about Tingen's execution</item>
        ///    <item>Used when debugging/troublshooting during development, and should probably be disabled in production</item>
        ///    <item>Important details are in the filename: <b>%assemblyName%-%calledClass%-%calledMethod%-%lineNumber.trace</b></item>
        ///    <item>Do not contain any data</item>   
        ///    <item>To ensure all logs are captured, filenames start with a timestamp: <b>ssfffffff_</b></item>
        ///    <item>Extension is <b>.trace</b></item>
        ///   </list>
        ///   - More information about Trace logs <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#logging">here</see>.
        ///  </para>
        /// </remarks>
        public static void Trace(int logLevel, string assemblyName, TraceLog traceInfo, string message = "", [CallerFilePath] string fromPath = "", [CallerMemberName] string fromMethod = "", [CallerLineNumber] int line = 0)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

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
        /// <remarks>
        ///  <para>
        ///   Primeval logs are vary simple logs that can be created with very little information.
        ///   <list type="bullet">
        ///    <item>Do not require any paramaters</item>
        ///    <item>Used when debugging/troublshooting during development, and should be disabled in production</item>
        ///    <item>Important details can be found in the file contents</item>
        ///    <item>May have custom messages (the default message is "Tingen primeval log"</item>
        ///    <item>To ensure all logs are captured, filenames are timestamped <b>yyMMddHHmmssfffffff</b></item>
        ///    <item>Extenstion is <b>.primeval</b></item>
        ///   </list>
        ///   - More information about Primeval logs <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#logging">here</see>.
        ///  </para>
        /// </remarks>

        public static void Primeval(string assemblyName, string message = "Tingen primeval log", [CallerFilePath] string fromPath = "", [CallerMemberName] string fromMethod = "", [CallerLineNumber] int line = 0)
        {
            /* Can't create any logs here! Sorry! */

            var fromClass = fromPath.Split('\\').Last();

            PrimevalLog.Create(assemblyName, message, fromClass, fromMethod, line);
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

- Is there a more efficient way of doing this (see https://rules.sonarsource.com/csharp/RSPEC-6608/):

  var calledClass = calledPath.Split('\\').Last();

- Make sure that passing the entire TingenSession object OR the traceInfo object work the same.

_Documentation updated 240620
*/
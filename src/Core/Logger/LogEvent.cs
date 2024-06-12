// u240607.1019

using System.Linq;
using System.Runtime.CompilerServices;

namespace Outpost31.Core.Logger
{
    /// <summary>Provides logging functionality.</summary>
    public static class LogEvent
    {
        /// <summary>Logs a trace event.</summary>
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
        ///  </para>
        /// </remarks>
        public static void Trace(int logLevel, string assemblyName, TraceLog traceInfo, string message = "", [CallerFilePath] string fromPath = "", [CallerMemberName] string fromMethod = "", [CallerLineNumber] int line = 0)
        {
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

        /// <summary>Logs a primeval event.</summary>
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
        ///  </para>
        /// </remarks>

        public static void Primeval(string assemblyName, string message = "Tingen primeval log", [CallerFilePath] string fromPath = "", [CallerMemberName] string fromMethod = "", [CallerLineNumber] int line = 0)
        {
            var fromClass = fromPath.Split('\\').Last();

            PrimevalLog.Create(assemblyName, message, fromClass, fromMethod, line);
        }
    }
}

/*

-----------------
Development notes
-----------------

- Is there a more efficient way of doing this (see https://rules.sonarsource.com/csharp/RSPEC-6608/):

  var calledClass = calledPath.Split('\\').Last();

- Make sure that passing the entire TingenSession object OR the traceInfo object work the same.

*/
// u240525.1402

using System;
using System.IO;
using System.Threading;

namespace Outpost31.Core.Debuggler
{
    public static class Primeval
    {
        /// <summary>Creates a primeval log.</summary>
        /// <param name="fileContent">The content of the log file.</param>
        /// <remarks>
        ///     - Primeval logs the simplest log possible, and do not require any parameters.
        ///     - Only used for testing purposes, should be commented out in production.
        ///     - Since Debuggler logs may be created very quickly, and possible at the same time, a sleep is added to
        ///       ensure the logs are unique.
        /// </remarks>
        /// <example>
        ///     To create a simple Primeval log with the default content of "[Abatab Primeval log]":
        ///     <code>
        ///         Outpost31.Core.Debuggler.Primeval.Log();
        ///     </code>
        ///     To create a Primeval log with custom content:
        ///     <code>
        ///         Outpost31.Core.Debuggler.Primeval.Log("your-content-goes-here")
        ///     </code>
        /// </example>
        public static void Log(string fileContent = "[Abatab Primeval log]")
        {
            Thread.Sleep(100);
            var datetime    = DateTime.Now.ToString("yyMMdd-HHmmssfffffff");
            var filePath    = $@"C:\TingenData\Primeval\{datetime}.primeval_log";

            File.WriteAllText(filePath, fileContent);
        }
    }
}
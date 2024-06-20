// u240620.1344

using System;
using System.IO;
using System.Threading;

namespace Outpost31.Core.Logger
{
    /// <summary>Primeval logs</summary>

    public static class PrimevalLog
    {
        /// <summary>Primeval log path.</summary>
        /// <remarks>
        ///   <para>
        ///    - Primeval logs are written to <i>C:\TingenData\Primeval\</i>, defined here so it can be easily changed if needed.
        ///   </para>
        /// </remarks>
        public static string PrimevalLogPath { get; set; } = @"C:\TingenData\Primeval";

        /// <summary>Creates a Primeval log.</summary>
        /// <param name="assemblyName"></param>
        /// <param name="message"></param>
        /// <param name="fromClass"></param>
        /// <param name="fromMethod"></param>
        /// <param name="line"></param>
        /// <remarks>
        ///  <para>
        ///    - Before a Primeval log is written, the Primeval log path is verified to ensure it exists.<br/>
        ///    - Log files may be created quickly - and possibly at the same time - so a pause is added to ensure logs are unique.
        ///  </para>
        /// </remarks>
        ///    <example>
        ///    To create a simple Primeval log:
        ///    <code>
        ///     LogEvent.Primeval(AssemblyName);
        ///     LogEvent.Primeval(Assembly.GetExecutingAssembly().GetName().Name);
        ///    </code>
        ///    To create a Primeval log with custom content:
        ///    <code>
        ///     LogEvent.Primeval(AssemblyName, message);
        ///     LogEvent.Primeval(Assembly.GetExecutingAssembly().GetName().Name, message);
        ///    </code>
        ///   </example>
        public static void Create(string assemblyName, string message, string fromClass, string fromMethod, int line)
        {
            Framework.Maintenance.VerifyDirectory(PrimevalLogPath);

            var fileContent = LoggerCatalog.StandardContent(assemblyName, fromClass, fromMethod, line.ToString(), message);
            var filePath    = $@"{PrimevalLogPath}\{DateTime.Now:yyMMddHHmmssfffffff}.primeval";

            Thread.Sleep(100);
            File.WriteAllText(filePath, fileContent);
        }

        /// <summary> Removes old Primeval logs.</summary>
        /// <remarks>
        ///  <para>
        ///   - Not currently used.
        ///  </para>
        /// </remarks>
        public static void DevelopmentCleanup()
        {
            Framework.Maintenance.RefreshDirectory(PrimevalLogPath);
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

_Documentation updated 240620
*/
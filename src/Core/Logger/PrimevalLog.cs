// u240709.0000_code
// u241021_documentation

using System;
using System.IO;
using System.Threading;

namespace Outpost31.Core.Logger
{
    /// <summary>Primeval logs</summary>
    /// <include file='XmlDoc/Outpost31.Core.Logger.PrimevalLog_doc.xml' path='Outpost31.Core.Logger.PrimevalLog/Type[@name="Class"]/PrimevalLog/*'/>
    public static class PrimevalLog
    {
        /// <summary>Primeval log path.</summary>
        /// <remarks>Why this is important, and why it is what it is.</remarks>
        public static string PrimevalLogPath { get; set; } = @"C:\TingenData\Primeval";

        /* [DN01] */
        /// <summary>Creates a Primeval log.</summary>
        /// <param name="assemblyName">The executing assembly name.</param>
        /// <param name="message">The log message</param>
        /// <param name="fromClass">The path of the calling class.</param>
        /// <param name="fromMethod">The path of the calling method</param>
        /// <param name="line">The line of code</param>
        /// <include file='XmlDoc/Outpost31.Core.Logger.PrimevalLog_doc.xml' path='Outpost31.Core.Logger.PrimevalLog/Type[@name="Method"]/Create/*'/>
        public static void Create(string assemblyName, string message, string fromClass, string fromMethod, int line)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet.
             *
             * You can't put a Primeval Log here either, since that may result in an infinite loop/stack overflow
             * when Primeval log directory is being refreshed.
             *
             * So, no logging for you!
             */

            Framework.Maintenance.VerifyDirectory(PrimevalLogPath);

            var fileContent = LoggerCatalog.StandardContent(assemblyName, fromClass, fromMethod, line.ToString(), message);
            var filePath    = $@"{PrimevalLogPath}\{DateTime.Now:yyMMddHHmmssfffffff}.primeval";

            Thread.Sleep(100);
            File.WriteAllText(filePath, fileContent);
        }

        /// <summary>Removes old Primeval logs.</summary>
        /// <remarks>Not currently used.</remarks>
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

-----------------
[DN01] 241021
-----------------
These should standardized.

*/
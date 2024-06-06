// u240605.1113

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
        ///    Primeval logs are always stored in the same <i>hardcoded</i>location: <b>C:\TingenData\Primeval\</b>, which is defined
        ///    here so it can be easily changed if needed.
        ///   </para>
        /// </remarks>
        public static string PrimevalLogPath { get; set; } = @"C:\TingenData\Primeval";

        /// <summary>Creates a Primeval log.</summary>
        /// <param name="fileContent">The content of the log file.</param>
        /// <remarks>
        ///  <para>
        ///    Before a Primeval log is written, the Primeval log path is verified to ensure it exists. Technically this slows things<br/>
        ///    down, but it's a good practice to ensure the path is there before trying to write to it. And since Primeval logs<br/>
        ///    should only be used for testing/debugging, the slowdown is acceptable.<br/><br/>
        ///    Log files may be created very quickly - and possibly at the same time - so a pause is added to ensure logs are unique.
        ///  </para>
        ///  <para>
        ///   Primeval logs are created with the following content:
        ///   <list type="table">
        ///    <item>
        ///     <term>assemblyName</term>
        ///     <description>Logic for the TingenConfiguration class</description>
        ///    </item>
        ///    <item>
        ///     <term>TingenConfiguration.Properties.cs</term>
        ///     <description>Properties for the TingenConfiguration class</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///
        ///  <para>
        ///    <example>
        ///    To create a simple Primeval log with the default content of "[TINGEN PRIMEVAL LOG]":
        ///    <code>
        ///     Outpost31.Core.Debuggler.Primeval.Log();
        ///    </code>
        ///    To create a Primeval log with custom content:
        ///    <code>
        ///     Outpost31.Core.Debuggler.Primeval.Log("your-content-goes-here")
        ///    </code>
        ///   </example>
        ///  </para>
        /// </remarks>
        public static void Create(string assemblyName, string message, string fromClass, string fromMethod, int line)
        {
            /* Can't do any logging here. Sorry! */

            Framework.Maintenance.VerifyDirectory(PrimevalLogPath);

            var fileContent = LoggerCatalog.StandardContent(assemblyName, fromClass, fromMethod, line.ToString(), message);
            var filePath    = $@"{PrimevalLogPath}\{DateTime.Now:yyMMddHHmmssfffffff}.primeval";

            Thread.Sleep(100);
            File.WriteAllText(filePath, fileContent);
        }

        /// <summary> Removes old Primeval logs.</summary>
        public static void DevelopmentCleanup()
        {
            /* Can't do any logging here. Sorry! */

            Framework.Maintenance.RefreshDirectory(PrimevalLogPath);
        }
    }
}

/*

Development notes
-----------------

*/
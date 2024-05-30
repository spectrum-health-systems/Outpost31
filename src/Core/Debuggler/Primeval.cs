// u240530.0930

using System;
using System.IO;
using System.Threading;

namespace Outpost31.Core.Debuggler
{
    public static class Primeval
    {
        /// <summary>Creates a Primeval log.</summary>
        /// <param name="fileContent">The content of the log file.</param>
        /// <remarks>
        ///  <para>
        ///   Primeval logs:
        ///   <list type="bullet">
        ///    <item>Are the simplest logs available</item>
        ///    <item>Do not require any parameters</item>
        ///    <item>Are used for testing/debugging, and should be commented out in production.</item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///    Log files may be created very quickly - and possibly at the same time - so a pause is added to ensure logs are unique.
        ///  </para>
        ///  <para>
        ///    <example>
        ///    To create a simple Primeval log with the default content of "[Abatab Primeval log]":
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
        public static void Log(string fileContent = "[Abatab Primeval log]")
        {
            Thread.Sleep(100);
            var datetime    = DateTime.Now.ToString("yyMMdd-HHmmssfffffff");
            var filePath    = $@"C:\TingenData\Primeval\{datetime}.primeval_log";

            File.WriteAllText(filePath, fileContent);
        }
    }
}
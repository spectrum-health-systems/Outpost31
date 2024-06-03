// u240603.1623

using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Outpost31.Core.Logger
{
    /// <summary>Debugging tools for Outpost31.</summary>
    /// <remarks>
    ///  <para>
    ///   Primeval logs:
    ///   <list type="bullet">
    ///    <item>Are the simplest logs available</item>
    ///    <item>Do not require any parameters</item>
    ///    <item>Are used for testing/debugging, and should be commented out in production</item>
    ///   </list>
    ///  </para>
    /// </remarks>
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
        public static void Create(string assemblyName, string fileContent = "[TINGEN PRIMEVAL LOG]", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            Framework.Maintenance.VerifyDirectory(PrimevalLogPath);

            Thread.Sleep(100);
            var callPathNew = callPath.Split('\\').Last();

            var content = $"[ASSEMBLY NAME] {assemblyName}{Environment.NewLine}" +
                          $"    [CALL PATH] {callPathNew}{Environment.NewLine}" +
                          $"  [CALL MEMBER] {callMember}{Environment.NewLine}" +
                          $"  [LINE NUMBER] {callLine}{Environment.NewLine}" +
                          Environment.NewLine +
                          $"      [CONTENT] {fileContent}";

            var filePath = $@"{PrimevalLogPath}\{DateTime.Now:yyMMddHHmmssfffffff}.primeval";

            File.WriteAllText(filePath, content);
        }

        /// <summary> Removes old Primeval logs.</summary>
        public static void DevelopmentCleanup()
        {
            // TODO

            Framework.Maintenance.RefreshDirectory(PrimevalLogPath);
        }
    }
}
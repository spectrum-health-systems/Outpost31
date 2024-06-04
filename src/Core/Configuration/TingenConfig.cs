// u240604.1539

using System.IO;
using System.Reflection;

namespace Outpost31.Core.Configuration
{
    /// <summary>Tingen configuration.</summary>
    /// <remarks>
    ///  <para>
    ///   - Logic for this class is in  <see cref="TingenConfig.cs"/> class.<br/>
    ///   - Properties for this class is in <see cref="TingenConfig.Properties.cs"/><br/>
    ///   - The Tingen configuration file is located in <b>Tingen\%SystemCode%\Config\</b>.
    ///  </para>
    ///  <para>
    ///   Tingen configuration settings:
    ///   <list type="bullet">
    ///    <item>Specific to Tingen, not other components/modules/etc.</item>
    ///    <item>Do not change between Tingen sessions</item>
    ///    <item>Can be modified by the user to suit their environments</item>
    ///   </list>
    ///  </para>
    /// </remarks>
    public class TingenConfig
    {
        /// <summary>Determines what Tingen does, if anything.</summary>
        /// <remarks>
        ///  <para>
        ///   The TingenMode can be:
        ///   <list type="table">
        ///    <item>
        ///     <term>Enabled (default)</term>
        ///     <description>Tingen is enabled, and will do work</description>
        ///    </item>
        ///    <item>
        ///     <term>Disabled</term>
        ///     <description>Tingen is disabled, and will not do any work</description>
        ///    </item>
        ///    <item>
        ///     <term>Development</term>
        ///     <description>Tingen is enabled, and development/debugging data is reset at execution</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///   When <i>disabled</i>, Tingen becomes a pass-through, and the sentOptionObject is returned unmodified.<br/><br/>
        ///   Setting the mode to <i>disabled</i> is the equivalent of disabling ScriptLink on every form that uses Tingen.<br/><br/>
        ///   When the mode is set to <i>development</i>, Tingen is enabled and works normally. However,<br/>
        ///   any development-related data, such as debugging logs or testing data, is reset at execution.
        ///  </para>
        /// </remarks>
        public string TingenMode { get; set; }

        /// <summary>The current Tingen version and build.</summary>
        /// <remarks>
        ///  <para>
        ///   The format is <b>%version%-%build%</b> (e.g., <c>24.5.0-240525.1310)</c>
        ///  </para>
        /// </remarks>
        public string TingenVersionBuild { get; set; }

        /// <summary>The root path for Tingen data.</summary>
        /// <remarks>
        ///  <para>
        ///   All non-service Tingen data is located here.<br/><br/>
        ///   The default value is "<c>C:\TingenData\</c>"
        ///  </para>
        /// </remarks>
        public string TingenDataRoot { get; set; }

        /// <summary>The Avatar System Code.</summary>
        /// <remarks>
        ///  <para>
        ///   The Avatar System Code can be one of the following:
        ///   <list type="table">
        ///    <item>
        ///     <term>LIVE</term>
        ///     <description>Tingen will access data in the production environment.</description>
        ///    </item>
        ///    <item>
        ///     <term>UAT</term>
        ///     <description>Tingen will access data in the testing environment.</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///   The System Code also determines where Tingen data is written (ex: "<c>C:\TingenData\UAT\</c>").
        ///  </para>
        /// </remarks>
        //public string AvatarSystemCode { get; set; }

        /// <summary>The Tingen log mode.</summary>
        /// <remarks>
        ///  <para>
        ///   Tingen has a number of log modes, which determine how Tingen logs data.
        ///   <list type="table">
        ///    <item>
        ///     <term>0</term>
        ///     <description>Logging is disabled (no logs are written).</description>
        ///    </item>
        ///    <item>
        ///     <term>1</term>
        ///     <description>Trace logs are created.</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///   Logs are written to <i>%TingenDataRoot%\%AvatarSystemCode%\Logs</i> (ex: "<c>C:\TingenData\UAT\Logs</c>").
        ///  </para>
        /// </remarks>
        public int TraceLogLevel { get; set; }

        /// <summary>The delay between log writes.</summary>
        /// <remarks>
        ///  <para>
        ///   In some cases, logs may be written to quickly and cause files to be overwritten.<br/>
        ///   By including a short delay, the logs can
        ///   be written in a way that prevents this from happening.<br/><br/>
        ///   The default value is <c>100</c> (milliseconds).
        ///  </para>
        /// </remarks>
        public int TraceLogDelay { get; set; }

        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Executing assembly is defined here so it can be used when creating log files.
        ///   </para>
        /// </remarks>
        public static string Asm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Builds a default Tingen configuration object.</summary>
        /// <remarks>
        ///  <para>
        ///   - Default values for the Tingen configuration settings.<br/>
        ///   - When a new version of Tingen is released, these need to be verified/updated.
        ///  </para>
        /// </remarks>
        /// <returns>An object with default Tingen configuration values.</returns>
        public static TingenConfig BuildDefaultConfig()
        {
            /* <!-- For debugging: LogEvent.Primeval(asm); --> */ // To be removed.

            return new TingenConfig
            {
                TingenMode         = "enabled",
                TingenVersionBuild = "24.6.0-240604.1534",
                TingenDataRoot     = @"C:\TingenData",
                //AvatarSystemCode   = "UAT",
                TraceLogLevel      = 0,
                TraceLogDelay      = 0
            };
        }

        /// <summary>Loads the Tingen configuration file.</summary>
        /// <param name="configFilePath">Path to the Tingen configuration file.</param>
        /// <remarks>
        ///  <para>
        ///   - The configuration file is <i>hardcoded</i> to <b>Tingen\%SystemCode%\Configs\</b>.<br/>
        ///   - If the configuration file does not exist, a configuration file with default values will be created.
        ///  </para>
        /// </remarks>
        /// <returns>The Tingen configuration settings.</returns>
        public static TingenConfig Load(string configFilePath)
        {
            /* <!-- For debugging: LogEvent.Primeval(asm); --> */ // To be removed.

            if (!File.Exists(configFilePath))
            {
                Utilities.DuJson.ExportToLocalFile<TingenConfig>(BuildDefaultConfig(), configFilePath);
            }

            return Utilities.DuJson.ImportFromLocalFile<TingenConfig>(configFilePath);
        }
    }
}

/*

Development notes

- Remove the Primeval calls, potentially replace with Tracelogs.
- If logs aren't written, remove the Asm property.

*/
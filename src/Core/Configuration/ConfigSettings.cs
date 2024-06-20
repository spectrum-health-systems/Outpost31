// u240620.1203

using System.IO;

namespace Outpost31.Core.Configuration
{
    /// <summary>Tingen configuration settings.</summary>
    /// <remarks>
    ///  <para>
    ///   - The Tingen configuration file is located in <i>"TingenData\%SystemCode%\Config\Tingen.config"</i>.
    ///  </para>
    ///  <para>
    ///   Tingen configuration settings:
    ///   <list type="bullet">
    ///    <item>Are specific to Tingen core functionality (other components/modules have their own configurations)</item>
    ///    <item>Do not change between Tingen sessions</item>
    ///    <item>Can be modified by the user to suit their environment</item>
    ///   </list>
    ///  </para>
    ///  <para>
    ///   - More information about configuring Tingen <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#tingen-configuration">here.</see>
    ///  </para>
    /// </remarks>
    public class ConfigSettings
    {
        /// <summary>Determines what Tingen does, if anything.</summary>
        /// <remarks>
        ///  <para>
        ///   Valid Tingen modes:
        ///   <list type="table">
        ///    <item>
        ///     <term>Enabled (default)</term>
        ///     <description>Tingen is enabled, and will hand work off to the requested <i>Tingen Module</i>.</description>
        ///    </item>
        ///    <item>
        ///     <term>Disabled</term>
        ///     <description>Tingen is disabled, and the sentObject is returned to Avatar unmodified.</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///  - There is logic to catch <i>"enable"</i> and <i>"disable"</i>, since I kept making that mistake.<br/>
        ///  - More information about Tingen modes <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#tingen-modes">here.</see>
        ///  </para>
        /// </remarks>
        public string TingenMode { get; set; }

        /// <summary>Determines if the <b>Open Incident Module</b> is enabled.</summary>
        /// <remarks>
        ///  <para>
        ///   Valid Open Incident Module modes:
        ///   <list type="table">
        ///    <item>
        ///     <term>Enabled (default)</term>
        ///     <description>The Open Incident Module is enabled.</description>
        ///    </item>
        ///    <item>
        ///     <term>Disabled</term>
        ///     <description>The Open Incident Module is disabled., and the sentObject is returned to Avatar unmodified.</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///  - Disabling this module not affect other modules, or Tingen as a whole.
        ///  - More information about Tingen modes <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#tingen-modes">here.</see>
        ///  </para>
        /// </remarks>
        public string ModOpenIncidentMode { get; set; }

        /// <summary>Determines if the NTST web services are enabled.</summary>
        /// <remarks>
        ///  <para>
        ///   - Currently not used, but will be in the future.<br/>
        ///   - This should be set to "<b>disabled</b>" until the NTST web services are implemented.
        ///  </para>
        /// </remarks>
        public string NtstWebServices { get; set; }

        /// <summary>The trace logging level.</summary>
        /// <remarks>
        ///  <para>
        ///   - Trace logs with a level less than or equal to the <paramref name="TraceLevel"/> will be written.<br/>
        ///   - Trace logs are written to <i>"%TingenDataRoot%\%AvatarSystemCode%\YYMM\%OptionUserId%\HHMMSS\"</i>.<br/>
        ///   - More information about trace logs can be found <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#logging">here</see>.
        ///  </para>
        /// </remarks>
        ///   <example>
        ///    If the TraceLogLevel is set to "<c>2</c>", the following log calls will be executed:<br/>
        ///    <c>LogEvent.Trace(1, tnSession.TraceLogs, Asm);</c><br/>
        ///    <c>LogEvent.Trace(2, tnSession.TraceLogs, Asm);</c><br/><br/>
        ///    If the TraceLogLevel is set to "<c>2</c>", the following log calls will <i>not</i> be executed:<br/>
        ///    <c>LogEvent.Trace(4, tnSession.TraceLogs, Asm);</c><br/>
        ///    <c>LogEvent.Trace(5, tnSession.TraceLogs, Asm);</c>
        ///   </example>
        /// <value>
        ///  0 (default)
        /// </value>
        public int TraceLevel { get; set; }

        /// <summary>The delay between trace log writes.</summary>
        /// <remarks>
        ///  <para>
        ///   - In some cases, logs may be written too quickly, and cause files to be overwritten.<br/>
        ///   - By including a short delay, the logs can be written in a way that prevents this from happening.<br/>
        ///  </para>
        /// </remarks>
        /// <value>
        ///  10 (default)
        /// </value>
        public int TraceDelay { get; set; }

        /// <summary>Build a default Tingen configuration object.</summary>
        /// <remarks>
        ///  <para>
        ///   - These are the default values for the Tingen configuration settings.<br/>
        ///   - When a new version of Tingen is released, these need to be verified/updated.<br/>
        ///   - More information about configuring Tingen <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#tingen-configuration">here.</see>
        ///  </para>
        /// </remarks>
        /// <returns>An object with default Tingen configuration values.</returns>
        public static ConfigSettings BuildDefaultObject()
        {
            return new ConfigSettings
            {
                TingenMode          = "enabled",
                ModOpenIncidentMode = "enabled",
                NtstWebServices     = "disabled",
                TraceLevel          = 3,
                TraceDelay          = 10
            };
        }

        /// <summary>Loads the Tingen configuration file.</summary>
        /// <param name="configPath">Path to the Tingen configuration file.</param>
        /// <remarks>
        ///  <para>
        ///   - The configuration file path is created in <b>Tingen.asmx.cs</b><br/>
        ///   - If the configuration file does not exist, a configuration file with default values will be created.
        ///  </para>
        /// </remarks>
        /// <returns>The Tingen configuration settings.</returns>
        public static ConfigSettings Load(string configPath, string configFileName)
        {
            var configFilePath = $@"{configPath}\{configFileName}";

            if (!File.Exists(configFilePath))
            {
                if (!Directory.Exists(configPath))
                {
                    Directory.CreateDirectory(configPath);
                }

                Utilities.DuJson.ExportToLocalFile<ConfigSettings>(BuildDefaultObject(), configFilePath);
            }

            return Utilities.DuJson.ImportFromLocalFile<ConfigSettings>(configFilePath);
        }
    }
}

/*

=================
DEVELOPMENT NOTES
=================

- Rename this directory to "Configs"?
- Create a "blacklist" that will allow certain users to bypass Tingen?

*/
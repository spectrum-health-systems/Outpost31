﻿// u240607.1007

using System.IO;

namespace Outpost31.Core.Configuration
{
    /// <summary>Tingen configuration.</summary>
    /// <remarks>
    ///  <para>
    ///   - The Tingen configuration file is located in <b>TingenData\%SystemCode%\Config\Tingen.config</b>.
    ///  </para>
    ///  <para>
    ///   Tingen configuration settings:
    ///   <list type="bullet">
    ///    <item>Are specific to Tingen core functionality (other components/modules have their own configurations)</item>
    ///    <item>Do not change between Tingen sessions</item>
    ///    <item>Can be modified by the user to suit their environment</item>
    ///   </list>
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
        ///    <item>
        ///     <term>Development</term>
        ///     <description>Tingen is enabled, and development/debugging data is reset at execution.</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///   <b>More information about the Tingen mode setting:</b><br/>
        ///   Setting the mode to <i>disabled</i> is the equivalent of disabling ScriptLink calls on every form that uses Tingen. This
        ///   is a good way to "turn off" the web service quickly, without having to modify every form that uses it.<br/><br/>
        ///   When disabled, the majority of the work is done in <b>Tingen.asmx.cs</b>, not in Outpost31, so it should have an
        ///   insignificant affect on Avatar's performance.<br/><br/>
        ///   You can also enable/disable individual Modules, Commands, and Actions via their associated configuration files.
        ///   This allows you to disable specific functionality without affecting the rest of Tingen.<br/><br/>
        ///  </para>
        /// </remarks>
        public string TingenMode { get; set; }

        /// <summary>Soon.</summary>
        public string ModOpenIncidentMode { get; set; }

        /// <summary>Determines if the NTST web services are enabled.</summary>
        public string NtstWebServices { get; set; }


        /// <summary>The trace log level.</summary>
        /// <remarks>
        ///  <para>
        ///   Trace logs are written to <b>%TingenDataRoot%\%AvatarSystemCode%\YYMM\%OptionUserId%\HHMMSS\TraceLogs\%</b>.
        ///  </para>
        ///  <para>
        ///   <b>More information about the trace log level:</b><br/>
        ///   Trace logs calls include a <i>log level</i> parameter.<br/><br/>
        ///   If the log level of the call is <i>less than or equal</i> to the TraceLogLevel, the log will be written. Otherwise,
        ///   the log will be skipped.<br/><br/>
        ///   This allows you to place log calls throughout the code, and then control the amount of logging that is done when Tingen
        ///   is executed.<br/><br/>
        ///   <example>
        ///    If the TraceLogLevel is set to "<c>2</c>", the following log calls will be executed:<br/>
        ///    <c>LogEvent.Trace(1, tnSession.TraceLogs, Asm);</c><br/>
        ///    <c>LogEvent.Trace(2, tnSession.TraceLogs, Asm);</c><br/><br/>
        ///    If the TraceLogLevel is set to "<c>2</c>", the following log calls will <i>not</i> be executed:<br/>
        ///    <c>LogEvent.Trace(4, tnSession.TraceLogs, Asm);</c><br/>
        ///    <c>LogEvent.Trace(5, tnSession.TraceLogs, Asm);</c>
        ///   </example>
        ///  </para>
        /// </remarks>
        public int TraceLevel { get; set; }

        /// <summary>The delay between trace log writes.</summary>
        /// <remarks>
        ///  <para>"
        ///   - In some cases, logs may be written too quickly, and cause files to be overwritten.<br/>
        ///   - By including a short delay, the logs can be written in a way that prevents this from happening.<br/><br/>
        ///  </para>
        /// </remarks>"
        public int TraceDelay { get; set; }

        /// <summary>Build a default Tingen configuration object.</summary>
        /// <remarks>
        ///  <para>
        ///   - These are the default values for the Tingen configuration settings.<br/>
        ///   - When a new version of Tingen is released, these need to be verified/updated.
        ///  </para>
        ///  <para>
        ///   Default values:
        ///   <list type="table">
        ///    <item>
        ///     <term>TingenMode</term>
        ///     <description>"Enabled"</description>
        ///    </item>
        ///    <item>
        ///     <term>TingenVersionBuild</term>
        ///     <description><b>%version%-%build%</b> (ex: <b>24.5.0-240525.1310)</b></description>
        ///    </item>
        ///    <item>
        ///     <term>TingenDataRoot</term>
        ///     <description>@"C:\TingenData"</description>
        ///    </item>
        ///    <item>
        ///     <term>TraceLogLevel</term>
        ///     <description>0</description>
        ///    </item>
        ///    <item>
        ///     <term>TraceLogDelay</term>
        ///     <description>0</description>
        ///    </item>
        ///   </list>
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

-----------------
Development notes
-----------------

- Create a "blacklist" that will allow certain users to bypass Tingen?

*/
// u240709.0000_code
// u240709.0000_documentation

using System.IO;

namespace Outpost31.Core.Configuration
{
    /// <summary>The Tingen configuration settings.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Configuration_doc.xml' path='Doc/Sec[@name="configuration"]/ConfigSettings/*'/>
    public class ConfigSettings
    {
        /// <summary>Determines the Tingen Mode for the session.</summary>
        /// <include file='XmlDoc/Outpost31.Core.Configuration_doc.xml' path='Doc/Sec[@name="configuration"]/TingenMode/*'/>
        public string TingenMode { get; set; }

        /// <summary>Determines if the Open Incident Module functionality is enabled.</summary>
        /// <include file='XmlDoc/Outpost31.Core.Configuration_doc.xml' path='Doc/Sec[@name="configuration"]/ModOpenIncidentMode/*'/>
        public string ModOpenIncidentMode { get; set; }

        /// <summary>Determines if the Netmart web services functionality is enabled.</summary>
        /// <include file='XmlDoc/Outpost31.Core.Configuration_doc.xml' path='Doc/Sec[@name="configuration"]/NtstWebServicesMode/*'/>
        public string NtstWebServicesMode { get; set; }

        /// <summary>Determines the session Trace Log level.</summary>
        /// <include file='XmlDoc/Outpost31.Core.Configuration_doc.xml' path='Doc/Sec[@name="configuration"]/TraceLevel/*'/> 
        public int TraceLevel { get; set; }

        /// <summary>Determines the <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#trace-logs">Trace Log delay</a>.</summary>
        /// <value>10 (default)</value> 
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
            // TODO: Name this something else.

            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            return new ConfigSettings
            {
                TingenMode          = "enabled",
                ModOpenIncidentMode = "enabled",
                NtstWebServicesMode = "disabled",
                TraceLevel          = 3,
                TraceDelay          = 10
            };
        }

        ///// <summary></summary>
        ///// <param name="configPath">Path to the Tingen configuration file.</param>
        ///// <remarks>
        /////  <para>
        /////   - The configuration file path is created in <b>Tingen.asmx.cs</b><br/>
        /////   - 
        /////  </para>
        ///// </remarks>
        ///// <returns>The Tingen configuration settings.</returns>
        ///// 

        /// <summary>Load the Tingen configuration file.</summary>
        /// <param name="configPath">Path to the Tingen configuration file.</param>
        /// <remarks>
        ///     <para>
        ///         <b>About this method</b><br/>
        ///         - The configuration file path is created when the session is initialzied.<br/>
        ///         - If the configuration file does not exist, a configuration file with default values will be created.<br/>
        ///     </para>
        ///     <para>
        ///         <b>More information</b><br/>
        ///         <a href="http://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#tingen-configuration">Configuring Tingen</a>
        ///     </para>
        /// </remarks>
        /// <returns>The necessary AvatarNX data.</returns>
        public static ConfigSettings Load(string configPath, string configFileName)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

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
/// 

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
///  - Disabling this module not affect other modules, or Tingen as a whole.<br/>
///  - More information about Tingen modes <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#tingen-modes">here.</see>
///  </para>
/// </remarks>

/// <summary>Determines if the NTST web services are enabled.</summary>
/// <remarks>
///  <para>
///   - Currently not used, but will be in the future.<br/>
///   - This should be set to "<b>disabled</b>" until the NTST web services are implemented.
///  </para>
/// </remarks>
/// 

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
/// 


/// <summary>The delay between trace log writes.</summary>
/// <remarks>
///  <para>
///   - In some cases, logs may be written too quickly, and cause files to be overwritten.<br/>
///   - By including a short delay, the logs can be written in a way that prevents this from happening.
///  </para>
/// </remarks>
/// <value>
///  10 (default)
/// </value>
// u240603.1754

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Outpost31.Core.Logger;

namespace Outpost31.Core.Configuration
{
    /// <summary>Tingen-specific configuration.</summary>
    /// <remarks>
    ///  <para>
    ///   This is part of a partial class:
    ///   <list type="table">
    ///    <item>
    ///     <term>TingenConfiguration.cs</term>
    ///     <description>Logic for the TingenConfiguration class</description>
    ///    </item>
    ///    <item>
    ///     <term>TingenConfiguration.Properties.cs</term>
    ///     <description>Properties for the TingenConfiguration class</description>
    ///    </item>
    ///   </list>
    ///  </para>
    ///  <para>
    ///   Tingen configuration settings:
    ///   <list type="bullet">
    ///    <item>Are specific to only to Tingen, not other components</item>
    ///    <item>Are stored in an external, hardcoded JSON-formatted file located in <b>Tingen\%SystemCode%\Configs\</b></item>
    ///    <item>Do not change between Tingen sessions</item>
    ///    <item>Can be modified by the user to suit their environments</item>
    ///   </list>
    ///  </para>
    /// </remarks>
    public partial class TingenConfiguration
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    The executing assembly is defined at the start of the class so it can be easily used throughout the class when creating
        ///    log files.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Builds a default Tingen configuration object.</summary>
        /// <remarks>
        ///  <para>
        ///   The default values for the Tingen configuration settings.<br/><br/>
        ///   When a new version of Tingen is released, these need to be verified/updated.
        ///  </para>
        /// </remarks>
        /// <returns>An object with default Tingen configuration values.</returns>
        public static TingenConfiguration BuildDefault()
        {
            /* Can't put a trace log here, so we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName);

            return new TingenConfiguration
            {
                TingenMode         = "enabled",
                TingenVersionBuild = "24.6.0-240603.1755",
                TingenDataRoot     = @"C:\TingenData",
                AvatarSystemCode   = "UAT",
                TraceLogLevel      = 1,
                TraceLogDelay      = 100,
                ModAdminEnabled    = true,
                ModAdminWhitelist  = new List<string>()
            };
        }

        /// <summary>Loads the Tingen configuration file.</summary>
        /// <param name="configFilePath">Path to the Tingen configuration file.</param>
        /// <remarks>
        ///  <para>
        ///   The configuration file is <i>hardcoded</i> to <b>Tingen\%SystemCode%\Configs\</b>.<br/><br/>
        ///   If the configuration file does not exist, a configuration file with default values will be created.
        ///  </para>
        /// </remarks>
        /// <returns>The Tingen configuration settings.</returns>
        public static TingenConfiguration Load(string configFilePath)
        {
            /* Can't put a trace log here, so we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName);

            LogEvent.Primeval(AssemblyName, configFilePath);

            //Framework.Maintenance.VerifyDirectory(configFilePath);

            LogEvent.Primeval(AssemblyName, "1");

            VerifyConfigurationExists(configFilePath);

            LogEvent.Primeval(AssemblyName, "2");

            return Utilities.DuJson.ImportFromLocalFile<TingenConfiguration>(configFilePath);
        }

        /// <summary>Get the path to the Tingen configuration file.</summary>
        /// <param name="systemCode">The Avatar System Code.</param>
        /// <remarks>
        ///  <para>
        ///   The <paramref name="systemCode"/> parameter is passed from Tingen.asmx.cs when the Tingen session is started.<br/><br/>
        ///   Even though this is a simple, one line method, this way we can easily change the path.
        ///  </para>
        /// </remarks>
        /// <returns>The path to the Tingen configuration file.</returns>
        public static string GetPath(string systemCode)
        {

            /* For development: "UAT".
             * For production: "LIVE".
             */

            /* Can't put a trace log here, so we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName);

            return $@"C:\TingenData\{systemCode}\Config\Tingen.config";
        }

        /// <summary>Verifies that the configuration file exists, and creates a new one if it does not.</summary>
        /// <param name="configFilePath">The path to the Tingen configuration file.</param>
        private static void VerifyConfigurationExists(string configFilePath)
        {
            /* Can't put a trace log here, so we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName);

            LogEvent.Primeval(AssemblyName, configFilePath);

            if (!File.Exists(configFilePath))
            {
                LogEvent.Primeval(AssemblyName, "3");

                CreateNew(configFilePath);
            }
        }

        /// <summary>Creates a new Tingen configuration file.</summary>
        /// <param name="configFilePath">The path to the Tingen configuration file.</param>
        private static void CreateNew(string configFilePath)
        {
            /* Can't put a trace log here, so we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName);

            LogEvent.Primeval(AssemblyName, configFilePath);

            var defaultConfiguration = BuildDefault();

            LogEvent.Primeval(AssemblyName, "4");

            Utilities.DuJson.ExportToLocalFile<TingenConfiguration>(defaultConfiguration, configFilePath);

            LogEvent.Primeval(AssemblyName, "777");
        }
    }
}
// u240531.0849

using System.Collections.Generic;
using System.IO;

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
        /// <summary>Builds a default Tingen configuration object.</summary>
        /// <remarks>
        ///  <para>
        ///   The default values for the Tingen configuration settings.<br/><br/>
        ///   When a new version of Tingen is released, these need to be verified/updated.
        ///  </para>
        /// </remarks>
        /// <returns>An object with default Tingen configuration values.</returns>
        public static TingenConfiguration Build()
        {
            Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.Configuration.TingenConfiguration.Build()]"); /* <- For development use only */

            return new TingenConfiguration
            {
                TingenMode         = "enabled",
                TingenVersionBuild = "24.5.0-240531.1044",
                TingenDataRoot     = @"C:\TingenData",
                AvatarSystemCode   = "UAT",
                LogMode            = 1,
                LogDelay           = 0,
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
            Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.Configuration.TingenConfiguration.Load()]"); /* <- For development use only */

            VerifyExists(configFilePath);

            return Utilities.DuJson.ImportFromLocalFile<TingenConfiguration>(configFilePath);
        }

        /// <summary>Get the path to the Tingen configuration file.</summary>
        /// <param name="systemCode">The Avatar System Code.</param>
        /// <remarks>
        ///  <para>
        ///   The <paramref name="systemCode"/> parameter is passed from Tingen.asmx.cs when the Tingen session is started.
        ///  </para>
        /// </remarks>
        /// <returns>The path to the Tingen configuration file.</returns>
        public static string GetPath(string systemCode)
        {
            //Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.Configuration.TingenConfiguration.GetPath()]"); /* <- For development use only */

            return $@"C:\TingenData\{systemCode}\Config\Tingen.config";
        }

        /// <summary>Verifies that the configuration file exists, and creates a new one if it does not.</summary>
        /// <param name="configFilePath">The path to the Tingen configuration file.</param>
        private static void VerifyExists(string configFilePath)
        {
            Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.Configuration.TingenConfiguration.VerifyExists()]"); /* <- For development use only */

            if (!File.Exists(configFilePath))
            {
                CreateNew(configFilePath);
            }
        }

        /// <summary>Creates a new Tingen configuration file.</summary>
        /// <param name="configFilePath">The path to the Tingen configuration file.</param>
        private static void CreateNew(string configFilePath)
        {
            Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.Configuration.TingenConfiguration.CreateNew()]"); /* <- For development use only */

            var tingenConfig = Build();

            Utilities.DuJson.ExportToLocalFile<TingenConfiguration>(tingenConfig, configFilePath);
        }
    }
}
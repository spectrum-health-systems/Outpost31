// u240525.1957

using System.Collections.Generic;
using System.IO;

namespace Outpost31.Core.Configuration
{
    /// <summary>Tingen configuration logic.</summary>
    /// <remarks>
    ///     - Properties for the Tingen configuration are located in TingenConfiguration.Properties.cs.
    ///     - Configuration settings:
    ///         - Do not change between Tingen sessions.
    ///         - Are stored in an external JSON file located in Tingen\%SystemCode%\Configs\.
    ///         - Can be modified by the user.
    /// </remarks>
    public partial class TingenConfiguration
    {
        /// <summary>Builds the default Tingen configuration object.</summary>
        /// <remarks>
        ///     - <c>TingenMode</c> determines if Tingen is <b>enabled</b> or <b>disabled</b>.
        /// </remarks>
        /// <returns>A TingenConfiguration object with default values.</returns>
        public static TingenConfiguration Build()
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Configuration.TingenConfiguration.Build()]"); /* <- For development use only */

            return new TingenConfiguration
            {
                TingenMode         = "enabled",
                TingenVersionBuild = "24.5.0-240525.1849",
                TingenDataRoot     = @"C:\TingenData",
                AvatarSystemCode   = "UAT",
                LogMode            = 1,
                LogDelay           = 0,
                ModAdminEnabled    = true,
                ModAdminWhitelist  = new List<string>()
            };
        }

        /// <summary>Loads the Tingen configuration file.</summary>
        /// <param name="configFilePath">The path to the Tingen configuration file.</param>
        /// <returns>The Tingen configuration settings.</returns>
        public static TingenConfiguration Load(string configFilePath)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Configuration.TingenConfiguration.Load()]"); /* <- For development use only */

            VerifyFileExists(configFilePath);

            return Utilities.DuJson.ImportFromLocalFile<TingenConfiguration>(configFilePath);
        }

        /// <summary>Verifies that the configuration file exists, and creates a new one if it does not.</summary>
        /// <param name="configFilePath">The path to the Tingen configuration file.</param>
        private static void VerifyFileExists(string configFilePath)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Configuration.TingenConfiguration.VerifyFileExists()]"); /* <- For development use only */

            if (!File.Exists(configFilePath))
            {
                CreateNew(configFilePath);
            }

        }

        /// <summary>Creates a new Tingen configuration file.</summary>
        /// <param name="configFilePath">The path to the Tingen configuration file.</param>
        private static void CreateNew(string configFilePath)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Configuration.TingenConfiguration.CreateNew()]"); /* <- For development use only */

            var configuration = Build();

            Utilities.DuJson.ExportToLocalFile<TingenConfiguration>(configuration, configFilePath);
        }
    }
}
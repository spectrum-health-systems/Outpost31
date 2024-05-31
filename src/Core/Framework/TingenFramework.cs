// u240531.0811

/* =====================================================================================================================
 * Adding new framework components to Tingen
 * -----------------------------------------
 * When adding a new framework component to Tingen, you need to do the following:
 *
 * First, add the new component as a property to the TingenFramework class in TingenFramework.Properties.cs.
 * 
 * If the new component is a path:
 *  - Add an entry for the path to Framework.Catalog.PathPostfixes()
 *  - Add an entry for the path to TingenFramework.Build()
 * ================================================================================================================== */

namespace Outpost31.Core.Framework
{
    /// <summary>The Tingen Framwork.</summary>
    /// <remarks>
    ///  <para>
    ///   This is part of a partial class:
    ///   <list type="table">
    ///    <item>
    ///     <term>TingenFramework.cs</term>
    ///     <description>Logic for the TingenFramework class</description>
    ///    </item>
    ///    <item>
    ///     <term>TingenFramework.Properties.cs</term>
    ///     <description>Properties for the TingenFramework class</description>
    ///    </item>
    ///   </list>
    ///  </para>
    ///  <para>
    ///   The Tingen Framework is comprised of:
    ///   <list type = "bullet">
    ///    <item>The Tingen directory structure</item>
    ///    <item>Tingen core data/files</item>
    ///    <item>Tingen maintenance procedures</item>
    ///   </list>
    ///  </para>
    /// </remarks>
    public partial class TingenFramework
    {
        /// <summary>Builds the Tingen Framework components.</summary>
        /// <param name="tingenDataRoot">The Tingen data root directory.</param>
        /// <param name="avatarSystemCode">The Avatar System Code</param>
        /// <remarks>
        ///  <para>
        ///   When a new path property is added to TingenFramework.Properties.cs, a new entry needs to be added here.
        ///  </para>
        ///  <para>
        ///   This method build the following Tingen framework components:
        ///   <list type="table">
        ///    <item>
        ///     <term>Directory paths</term>
        ///     <description>Required directory paths</description>
        ///    </item>
        ///    <item>
        ///     <term>Service status paths</term>
        ///     <description>Paths where service status files are located</description>
        ///    </item>
        ///   </list>
        ///  </para>
        /// </remarks>
        /// <returns>The Abatab Framework components.</returns>
        public static TingenFramework Build(string tingenDataRoot, string avatarSystemCode)
        {
            Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.Session.TingenSession.BuildComponents()]"); /* <- For development use only */

            var dataPaths = Framework.Catalog.DataPaths(tingenDataRoot, avatarSystemCode);

            Outpost31.Core.Debuggler.PrimevalLog.Create($"[{tingenDataRoot}]");

            var tnFramework = new TingenFramework
            {
                TingenDataRoot    = dataPaths["TingenDataRoot"],
                SystemCodeRoot    = dataPaths["AvatarSystemCode"],
                RawDataRoot       = dataPaths["RawDataRoot"],
                MessageRoot       = dataPaths["MessageRoot"],
                PublicRoot        = dataPaths["PublicRoot"],
                RemoteRoot        = dataPaths["RemoteRoot"],
                AdminPath         = dataPaths["Admin"],
                AlertPath         = dataPaths["Alert"],
                ArchivePath       = dataPaths["Archive"],
                ConfigPath        = dataPaths["Config"],
                DebugPath         = dataPaths["Debug"],
                ErrorPath         = dataPaths["Error"],
                ExportPath        = dataPaths["Export"],
                ExtensionPath     = dataPaths["Extension"],
                ImportPath        = dataPaths["Import"],
                LogPath           = dataPaths["Log"],
                ReportPath        = dataPaths["Report"],
                TemplatePath      = dataPaths["Template"],
                TemporaryPath     = dataPaths["Temporary"],
                WarningPath       = dataPaths["Warning"],
                PublicAlertPath   = dataPaths["PublicAlert"],
                PublicErrorPath   = dataPaths["PublicError"],
                PublicExportPath  = dataPaths["PublicExport"],
                PublicReportPath  = dataPaths["PublicReport"],
                PublicWarningPath = dataPaths["PublicWarning"],
                RemoteAlertPath   = dataPaths["RemoteAlert"],
                RemoteErrorPath   = dataPaths["RemoteError"],
                RemoteExportPath  = dataPaths["RemoteExport"],
                RemoteReportPath  = dataPaths["RemoteReport"],
                RemoteWarningPath = dataPaths["RemoteWarning"]
            };

            Outpost31.Core.Debuggler.PrimevalLog.Create($"[POST-POST-PREFIX]");

            tnFramework.ServiceStatusPaths = Catalog.ServiceStatusPaths(tnFramework);

            Outpost31.Core.Debuggler.PrimevalLog.Create($"[POST-POST-POST-PREFIX]");

            return tnFramework;
        }
    }
}
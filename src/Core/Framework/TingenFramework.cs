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
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Session.TingenSession.BuildComponents()]"); /* <- For development use only */

            var pathPostfix = Framework.Catalog.PathPostfixes(avatarSystemCode);

            var tnFramework =  new TingenFramework
            {
                SystemCodePath    = $@"{tingenDataRoot}\{avatarSystemCode}",
                AdminPath         = $@"{tingenDataRoot}\{pathPostfix["Admin"]}",
                AlertPath         = $@"{tingenDataRoot}\{pathPostfix["Alerts"]}",
                ArchivePath       = $@"{tingenDataRoot}\{pathPostfix["Archive"]}",
                ConfigPath        = $@"{tingenDataRoot}\{pathPostfix["Configs"]}",
                DataPath          = $@"{tingenDataRoot}\{pathPostfix["Data"]}",
                DebugPath         = $@"{tingenDataRoot}\{pathPostfix["Debug"]}",
                ErrorPath         = $@"{tingenDataRoot}\{pathPostfix["Errors"]}",
                ExportPath        = $@"{tingenDataRoot}\{pathPostfix["Exports"]}",
                ExtensionsPath    = $@"{tingenDataRoot}\{pathPostfix["Extensions"]}",
                ImportPath        = $@"{tingenDataRoot}\{pathPostfix["Imports"]}",
                LogPath           = $@"{tingenDataRoot}\{pathPostfix["Logs"]}",
                MessagePath       = $@"{tingenDataRoot}\{pathPostfix["Messages"]}",
                ReportPath        = $@"{tingenDataRoot}\{pathPostfix["Reports"]}",
                TemplatesPath     = $@"{tingenDataRoot}\{pathPostfix["Templates"]}",
                TemporaryPath     = $@"{tingenDataRoot}\{pathPostfix["Temporary"]}",
                WarningPath       = $@"{tingenDataRoot}\{pathPostfix["Warnings"]}",
                PublicPath        = $@"{tingenDataRoot}\{pathPostfix["Public"]}",
                PublicAlertPath   = $@"{tingenDataRoot}\{pathPostfix["PublicAlerts"]}",
                PublicExportPath  = $@"{tingenDataRoot}\{pathPostfix["PublicExports"]}",
                PublicReportPath  = $@"{tingenDataRoot}\{pathPostfix["PublicReports"]}",
                PublicWarningPath = $@"{tingenDataRoot}\{pathPostfix["PublicWarnings"]}",
                RemotePath        = $@"{tingenDataRoot}\{pathPostfix["Remote"]}",
                RemoteAlertPath   = $@"{tingenDataRoot}\{pathPostfix["RemoteAlerts"]}",
                RemoteErrorPath   = $@"{tingenDataRoot}\{pathPostfix["RemoteErrors"]}",
                RemoteReportPath  = $@"{tingenDataRoot}\{pathPostfix["RemoteReports"]}",
                RemoteWarningPath = $@"{tingenDataRoot}\{pathPostfix["RemoteWarnings"]}"
            };

            tnFramework.ServiceStatusPaths = Catalog.ServiceStatusPaths(tnFramework);

            return tnFramework;
        }
    }
}
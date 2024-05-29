// u240525.1957

namespace Outpost31.Core.Framework
{
    public partial class TingenFramework
    {
        /// <summary>Builds the Tingen Framework components.</summary>
        /// <param name="tingenDataRoot">The Tingen data root directory.</param>
        /// <param name="avatarSystemCode">The Avatar System Code</param>
        /// <remarks>
        ///     This method build the following Tingen framework components:
        ///     <list type="table">
        ///         <item>
        ///             <term>Directory paths</term>
        ///             <description>Required directory paths</description>
        ///         </item>
        ///         <item>
        ///             <term>Service status paths</term>
        ///             <description>Paths where service status files are located</description>
        ///         </item>
        ///     </list>
        /// </remarks>
        /// <returns>The Abatab Framework components.</returns>
        public static TingenFramework BuildComponents(string tingenDataRoot, string avatarSystemCode)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Session.TingenSession.BuildFrameworkComponents()]"); /* <- For development use only */

            var pathPostfix = Framework.Catalog.PathPostfixes(avatarSystemCode);

            var tnFramework =  new TingenFramework
            {
                AlertPath         = $@"{tingenDataRoot}\{pathPostfix["Alerts"]}",
                ArchivePath       = $@"{tingenDataRoot}\{pathPostfix["Archive"]}",
                ConfigPath        = $@"{tingenDataRoot}\{pathPostfix["Configs"]}",
                DataPath          = $@"{tingenDataRoot}\{pathPostfix["Data"]}",
                DebugPath         = $@"{tingenDataRoot}\{pathPostfix["Debug"]}",
                ErrorPath         = $@"{tingenDataRoot}\{pathPostfix["Errors"]}",
                ExportPath        = $@"{tingenDataRoot}\{pathPostfix["Exports"]}",
                ImportPath        = $@"{tingenDataRoot}\{pathPostfix["Imports"]}",
                LogPath           = $@"{tingenDataRoot}\{pathPostfix["Logs"]}",
                MessagePath       = $@"{tingenDataRoot}\{pathPostfix["Messages"]}",
                PublicPath        = $@"{tingenDataRoot}\{pathPostfix["Public"]}",
                PublicAlertPath   = $@"{tingenDataRoot}\{pathPostfix["PublicAlerts"]}",
                PublicExportPath  = $@"{tingenDataRoot}\{pathPostfix["PublicExports"]}",
                PublicReportPath  = $@"{tingenDataRoot}\{pathPostfix["PublicReports"]}",
                PublicWarningPath = $@"{tingenDataRoot}\{pathPostfix["PublicWarnings"]}",
                RemotePath        = $@"{tingenDataRoot}\{pathPostfix["Remote"]}",
                RemoteAlertPath   = $@"{tingenDataRoot}\{pathPostfix["RemoteAlerts"]}",
                RemoteErrorPath   = $@"{tingenDataRoot}\{pathPostfix["RemoteErrors"]}",
                RemoteReportPath  = $@"{tingenDataRoot}\{pathPostfix["RemoteReports"]}",
                RemoteWarningPath = $@"{tingenDataRoot}\{pathPostfix["RemoteWarnings"]}",
                ReportPath        = $@"{tingenDataRoot}\{pathPostfix["Reports"]}",
                SystemCodePath    = $@"{tingenDataRoot}\{avatarSystemCode}",
                TemplatesPath     = $@"{tingenDataRoot}\{pathPostfix["Templates"]}",
                TemporaryPath     = $@"{tingenDataRoot}\{pathPostfix["Temporary"]}",
                WarningPath       = $@"{tingenDataRoot}\{pathPostfix["Warnings"]}",
            };

            tnFramework.ServiceStatusPaths = Catalog.ServiceStatusPaths(tnFramework);

            return tnFramework;
        }
    }
}

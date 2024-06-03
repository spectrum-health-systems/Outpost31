// u240603.1731

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

using System.Reflection;

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
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    The executing assembly is defined at the start of the class so it can be easily used throughout the class when creating
        ///    log files.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

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
            /* Can't put a trace log here, so we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName);

            var dataPath = Framework.Catalog.DataPaths(tingenDataRoot, avatarSystemCode);

            var tnFramework = new TingenFramework
            {
                TingenDataRoot    = dataPath["TingenDataRoot"],
                SystemCodeRoot    = dataPath["AvatarSystemCode"],
                RawDataRoot       = dataPath["RawDataRoot"],
                MessageRoot       = dataPath["MessageRoot"],
                PublicRoot        = dataPath["PublicRoot"],
                RemoteRoot        = dataPath["RemoteRoot"],
                SessionRoot       = dataPath["SessionRoot"],
                AdminPath         = dataPath["Admin"],
                AlertPath         = dataPath["Alert"],
                ArchivePath       = dataPath["Archive"],
                ConfigPath        = dataPath["Config"],
                DebugPath         = dataPath["Debug"],
                ErrorPath         = dataPath["Error"],
                ExportPath        = dataPath["Export"],
                ExtensionPath     = dataPath["Extension"],
                ImportPath        = dataPath["Import"],
                LogPath           = dataPath["Log"],
                ReportPath        = dataPath["Report"],
                TemplatePath      = dataPath["Template"],
                TemporaryPath     = dataPath["Temporary"],
                WarningPath       = dataPath["Warning"],
                PublicAlertPath   = dataPath["PublicAlert"],
                PublicErrorPath   = dataPath["PublicError"],
                PublicExportPath  = dataPath["PublicExport"],
                PublicReportPath  = dataPath["PublicReport"],
                PublicWarningPath = dataPath["PublicWarning"],
                RemoteAlertPath   = dataPath["RemoteAlert"],
                RemoteErrorPath   = dataPath["RemoteError"],
                RemoteExportPath  = dataPath["RemoteExport"],
                RemoteReportPath  = dataPath["RemoteReport"],
                RemoteWarningPath = dataPath["RemoteWarning"]
            };

            tnFramework.ServiceStatusPaths = Catalog.ServiceStatusPaths(tnFramework);

            return tnFramework;
        }
    }
}
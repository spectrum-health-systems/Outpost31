// u240531.1229

using System.Collections.Generic;

namespace Outpost31.Core.Framework
{
    /// <summary>Avatar-specific data. (see DataFromAvatar.Properties.cs for more information about this class).</summary>

    /// <summary>Logic for the Tingen Framework data (see TingenFramework.Properties.cs for more information about this class).</summary>
    public partial class TingenFramework
    {
        /*
         * Data roots
         */

        /// <summary>The Tingen data root.</summary>
        public string TingenDataRoot { get; set; }

        /// <summary>The Avatar System Code root</summary>
        public string SystemCodeRoot { get; set; }

        /// <summary>Raw data is located here.</summary>
        /// <remarks>
        ///  <para>
        ///   This directory contains the following subdirectories:
        ///   <list type="bullet">
        ///    <item>Export\</item>
        ///    <item>Import\</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public string RawDataRoot { get; set; }

        /// <summary>Messages are here.</summary>
        /// <remarks>
        ///  <para>
        ///   This directory contains the following subdirectories:
        ///   <list type="bullet">
        ///    <item>Alert\</item>
        ///    <item>Error\</item>
        ///    <item>Warning\</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public string MessageRoot { get; set; }

        /// <summary>Public data is located here.</summary>
        /// <remarks>
        ///  <para>
        ///   Public data is available to users that have access to the %TingenDataRoot%\Public directory.
        ///  </para>
        ///  <para>
        ///   This directory contains the following subdirectories:
        ///   <list type="bullet">
        ///    <item>Alert\</item>
        ///    <item>Error\</item>
        ///    <item>Export\</item>
        ///    <item>Report\</item>
        ///    <item>Warning\</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public string PublicRoot { get; set; }

        /// <summary>Remote data is located here.</summary>
        /// <remarks>
        ///  <para>
        ///   Remote data is available to users that have access to the %TingenDataRoot%\Remote directory.
        ///  </para>
        ///  <para>
        ///   This directory contains the following subdirectories:
        ///   <list type="bullet">
        ///    <item>Alert\</item>
        ///    <item>Error\</item>
        ///    <item>Export\</item>
        ///    <item>Report\</item>
        ///    <item>Warning\</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public string RemoteRoot { get; set; }

        /*
         * System Code-specific paths
         */

        /// <summary>Sytem Code-specific administration data is located here.</summary>
        public string AdminPath { get; set; }

        /// <summary>Sytem Code-specific alerts are located here.</summary>
        public string AlertPath { get; set; }

        /// <summary>Sytem Code-specific archived data is located here.</summary>
        public string ArchivePath { get; set; }

        /// <summary>Sytem Code-specific configuration files are located here.</summary>
        public string ConfigPath { get; set; }

        /// <summary>Sytem Code-specific debug data is located here.</summary>
        public string DebugPath { get; set; }

        /// <summary>Sytem Code-specific error messages are located here.</summary>
        public string ErrorPath { get; set; }

        /// <summary>Sytem Code-specific exported data is located here.</summary>
        public string ExportPath { get; set; }

        /// <summary>Sytem Code-specific extensions are located here.</summary>
        public string ExtensionPath { get; set; }

        /// <summary>Sytem Code-specific imported data is located here.</summary>
        public string ImportPath { get; set; }

        /// <summary>Sytem Code-specific log files are located here.</summary>
        public string LogPath { get; set; }

        /// <summary>Sytem Code-specific reports are located here.</summary>
        public string ReportPath { get; set; }

        /// <summary>Sytem Code-specific templates are located here.</summary>
        public string TemplatePath { get; set; }

        /// <summary>Sytem Code-specific temporary data is located here.</summary>
        public string TemporaryPath { get; set; }

        /// <summary>Sytem Code-specific warnings are located here.</summary>
        public string WarningPath { get; set; }

        /*
         * Public paths
         */

        /// <summary>Public alerts are located here.</summary>
        public string PublicAlertPath { get; set; }

        /// <summary>Public errors are located here.</summary>
        public string PublicErrorPath { get; set; }

        /// <summary>Public exports are located here.</summary>
        public string PublicExportPath { get; set; }

        /// <summary>Public reports are located here.</summary>
        public string PublicReportPath { get; set; }

        /// <summary>Public warnings are located here.</summary>
        public string PublicWarningPath { get; set; }

        /*
         * Remote paths
         */

        /// <summary>Remote alerts are located here.</summary>
        public string RemoteAlertPath { get; set; }

        /// <summary>Remote errors are located here.</summary>
        public string RemoteErrorPath { get; set; }

        /// <summary>Remote exports are located here.</summary>
        public string RemoteExportPath { get; set; }

        /// <summary>Remote reports are located here.</summary>
        public string RemoteReportPath { get; set; }

        /// <summary>Remote warnings are located here.</summary>
        public string RemoteWarningPath { get; set; }

        /*
         * Other paths
         */

        public List<string> ServiceStatusPaths { get; set; }
    }
}
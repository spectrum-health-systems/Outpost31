// u240530.1131

using System.Collections.Generic;

namespace Outpost31.Core.Framework
{
    /// <summary>Avatar-specific data. (see DataFromAvatar.Properties.cs for more information about this class).</summary>

    /// <summary>Logic for the Tingen Framework data (see TingenFramework.Properties.cs for more information about this class).</summary>
    public partial class TingenFramework
    {
        /// <summary>The Avatar System Code path</summary>
        public string SystemCodePath { get; set; }

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

        /// <summary>Sytem Code-specific data files are located here.</summary>
        /// <remarks>
        ///  <para>
        ///   This directory contains the following subdirectories:
        ///   <list type="bullet">
        ///    <item>Export\</item>
        ///    <item>Import\</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public string DataPath { get; set; }

        /// <summary>Sytem Code-specific debugging information is located here.</summary>
        public string DebugPath { get; set; }

        /// <summary>Sytem Code-specific error messages are located here.</summary>
        public string ErrorPath { get; set; }

        /// <summary>Sytem Code-specific exported data is located here.</summary>
        public string ExportPath { get; set; }

        /// <summary>Sytem Code-specific extensions are located here.</summary>
        public string ExtensionsPath { get; set; }

        /// <summary>Sytem Code-specific imported data is located here.</summary>
        public string ImportPath { get; set; }

        /// <summary>Sytem Code-specific log files are located here.</summary>
        public string LogPath { get; set; }

        /// <summary>Sytem Code-specific messages are located here.</summary>
        /// <remarks>
        ///  <para>
        ///   This directory contains the following subdirectories:
        ///   <list type="bullet">
        ///    <item>Alerts\</item>
        ///    <item>Errors\</item>
        ///    <item>Warnings\</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public string MessagePath { get; set; }

        /// <summary>Sytem Code-specific reports are located here.</summary>
        public string ReportPath { get; set; }

        /// <summary>Sytem Code-specific templates are located here.</summary>
        public string TemplatesPath { get; set; }

        /// <summary>Sytem Code-specific temporary data is located here.</summary>
        public string TemporaryPath { get; set; }

        /// <summary>Sytem Code-specific warnings are located here.</summary>
        public string WarningPath { get; set; }

        /*
         * Public paths
         */

        /// <summary>Public data is located here.</summary>
        /// <remarks>
        ///  <para>
        ///   Public data is available to users that have access to the %TingenDataRoot%\Public directory.
        ///  </para>
        ///  <para>
        ///   This directory contains the following subdirectories:
        ///   <list type="bullet">
        ///    <item>Alerts\</item>
        ///    <item>Errors\</item>
        ///    <item>Exports\</item>
        ///    <item>Reports\</item>   
        ///    <item>Warnings\</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public string PublicPath { get; set; }

        /// <summary>Public alerts are located here.</summary>
        public string PublicAlertPath { get; set; }

        /// <summary>Public exports are located here.</summary>
        public string PublicExportPath { get; set; }

        /// <summary>Public reports are located here.</summary>
        public string PublicReportPath { get; set; }

        /// <summary>Public warnings are located here.</summary>
        public string PublicWarningPath { get; set; }

        /*
         * Remote paths
         */

        /// <summary>Remote data is located here.</summary>
        /// <remarks>
        ///  <para>
        ///   Remote data is available to users that have access to the %TingenDataRoot%\Remote directory.
        ///  </para>
        ///  <para>
        ///   This directory contains the following subdirectories:
        ///   <list type="bullet">
        ///    <item>Alerts\</item>
        ///    <item>Errors\</item>
        ///    <item>Exports\</item>
        ///    <item>Reports\</item>   
        ///    <item>Warnings\</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public string RemotePath { get; set; }
        public string RemoteAlertPath { get; set; }
        public string RemoteErrorPath { get; set; }
        public string RemoteReportPath { get; set; }
        public string RemoteWarningPath { get; set; }

        /*
         * Other paths
         */

        public List<string> ServiceStatusPaths { get; set; }

    }
}
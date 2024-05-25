// u240525.1402

using System.Collections.Generic;

namespace Outpost31.Core.Framework
{
    public partial class TingenFramework
    {
        public string AlertPath { get; set; }
        public string ArchivePath { get; set; }
        public string ConfigPath { get; set; }
        public string DataPath { get; set; }
        public string DebugPath { get; set; }
        public string ErrorPath { get; set; }
        public string ExportPath { get; set; }
        public string ImportPath { get; set; }
        public string LogPath { get; set; }
        public string MessagePath { get; set; }
        public string PublicPath { get; set; }
        public string PublicAlertPath { get; set; }
        public string PublicExportPath { get; set; }
        public string PublicReportPath { get; set; }
        public string PublicWarningPath { get; set; }
        public string RemotePath { get; set; }
        public string RemoteAlertPath { get; set; }
        public string RemoteErrorPath { get; set; }
        public string RemoteReportPath { get; set; }
        public string RemoteWarningPath { get; set; }
        public string ReportPath { get; set; }
        public string SystemCodePath { get; set; }
        public string TemplatesPath { get; set; }
        public string TemporaryPath { get; set; }
        public string WarningPath { get; set; }
        public List<string> ServiceStatusPaths { get; set; }
    }
}

// u241119.0832_code
// u241119_documentation

using System.IO;
using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Module.Admin.Service
{
    /// <summary>TBD</summary>
    public static class Status
    {
        /// <summary>The executing Assembly name.</summary>
        /// <remarks>A required component for writing log files, defined here so it can be used throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>TBD</summary>
        public static void UpdateAll(TingenSession tnSession)
        {
            LogEvent.Trace(1, ExeAsm, tnSession.TraceInfo);

            UpdateMode(tnSession.TnPath.Remote.Root, tnSession.AvData.SystemCode, tnSession.TnConfig.TingenMode, tnSession.TraceInfo);

            UpdateSettings(tnSession);

            Core.Avatar.ReturnObject.Finalize(tnSession, "info", "All statuses updated.");
        }

        /// <summary>TBD</summary>
        public static void UpdateMode(string remoteRoot, string avSystemCode, string tnMode, TraceLog traceInfo)
        {
            LogEvent.Trace(1, ExeAsm, traceInfo);

            foreach (var file in Directory.GetFiles(remoteRoot))
            {
                LogEvent.Trace(2, ExeAsm, traceInfo);

                if (file.Contains($"TINGEN {avSystemCode.ToUpper()} IS CURRENTLY"))
                {
                    LogEvent.Trace(3, ExeAsm, traceInfo);

                    File.Delete(file);
                }
            }

            if (tnMode == "enabled" || tnMode == "disabled")
            {
                LogEvent.Trace(2, ExeAsm, traceInfo);
                File.WriteAllText($@"{remoteRoot}\TINGEN {avSystemCode.ToUpper()} IS CURRENTLY {tnMode.ToUpper()}", "");
            }
            else
            {
                LogEvent.Trace(2, ExeAsm, traceInfo);
                File.WriteAllText($@"{remoteRoot}\TINGEN {avSystemCode.ToUpper()} IS CURRENTLY IN AN UNKNOWN STATE", "");
            }
        }

        /// <summary>TBD</summary>
        public static void UpdateSettings(TingenSession tnSession)
        {
            LogEvent.Trace(1, ExeAsm, tnSession.TraceInfo);

            var remoteRoot       = tnSession.TnPath.Remote.Root;
            var settingsFileName = $"Current-Tingen-{tnSession.AvData.SystemCode}-settings.md";
            var settingsFilePath = $@"{remoteRoot}\{settingsFileName}";

            if (File.Exists($@"{settingsFilePath}"))
            {
                LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);

                File.Delete($@"{settingsFilePath}");
            }

            File.WriteAllText($@"{settingsFilePath}", Outpost31.Core.Session.Catalog.CurrentSettings(tnSession));
        }
    }
}

/* DEVELOPMENT NOTES
 
- Need to also finalize the OO in "settings" and "mode", not just "all"

 */
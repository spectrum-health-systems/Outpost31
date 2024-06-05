// u240605.1135

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Module.Admin
{
    /// <summary>Soon.</summary>
    public static class Service
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string Asm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Soon.</summary>
        /// <param name="tnSession"></param>
        public static void AllUpdate(TingenSession tnSession)
        {
            LogEvent.Trace( 1, Asm, tnSession.TraceInfo);

            ModeUpdate(tnSession.Config.TingenMode, tnSession.AvatarData.SystemCode, tnSession.Framework.OtherPath.ServiceStatusPaths, tnSession.TraceInfo);
            CurrentSettingsUpdate(tnSession);
        }

        /// <summary>Write a file indicating the status of the Tingen web service.</summary>
        /// <param name="tingenMode">The current Tingen web service mode.</param>
        /// <param name="avatarSystemCode">The Avatar System Code.</param>
        /// <param name="statusFilePaths">Paths where the status file will be written.</param>
        /// <remarks>
        ///  <para>
        ///   Prior to creating the status file, any existing status files are deleted.<br/><br/>
        ///   Status files are written to the various paths for various uses.
        ///  </para>
        /// </remarks>
        public static void ModeUpdate(string tingenMode, string avatarSystemCode, List<string> statusFilePaths, TraceLogInfo traceInfo)
        {
            /* Trace log info for this method. */
            //Dictionary<string, string> traceInfo = LogInfo.TraceLog(Asm, tnSession.Config, tnSession.Framework);

            LogEvent.Trace( 1, Asm, traceInfo);

            DeleteModeUpdateFiles(avatarSystemCode, statusFilePaths, traceInfo);

            string statusFileName;

            switch (tingenMode)
            {
                case "enabled":
                    statusFileName = $"TINGEN {avatarSystemCode.ToUpper()} IS CURRENTLY ENABLED";
                    break;

                case "disabled":
                    statusFileName = $"TINGEN {avatarSystemCode.ToUpper()} IS CURRENTLY DISABLED";
                    break;

                default:
                    statusFileName = $"TINGEN {avatarSystemCode.ToUpper()} IS CURRENTLY IN AN UNKNOWN STATE";
                    break;
            }

            WriteModeUpdateFiles(statusFileName, statusFilePaths, traceInfo);
        }

        /// <summary>Soon.</summary>
        /// <param name="tnSession"></param>
        public static void CurrentSettingsUpdate(TingenSession tnSession)
        {
            LogEvent.Trace(2, Asm, tnSession.TraceInfo);

            var currentSettingsFileName = $"Current-Tingen-{tnSession.AvatarData.SystemCode}-settings.md";

            DeleteCurrentSettingFiles(currentSettingsFileName, tnSession.Framework.OtherPath.ServiceStatusPaths, tnSession.TraceInfo);

            var currentSettings = Outpost31.Core.Session.Catalog.CurrentSettings(tnSession);

            WriteCurrentSettingsFiles(currentSettingsFileName, currentSettings, tnSession.Framework.OtherPath.ServiceStatusPaths, tnSession.TraceInfo);

            //Outpost31.Core.Session.Catalog.CurrentSettings(tnSession);
        }

        /// <summary>Soon.</summary>
        /// <param name="currentSettingsFileName"></param>
        /// <param name="statusFilePaths"></param>
        /// <param name="traceInfo"></param>
        private static void DeleteCurrentSettingFiles(string currentSettingsFileName, List<string> statusFilePaths, TraceLogInfo traceInfo)
        {
            LogEvent.Trace(1, Asm, traceInfo);

            foreach (var path in statusFilePaths)
            {
                var statusFileName = $@"{path}\{currentSettingsFileName}";

                if (File.Exists(statusFileName))
                {
                    File.Delete(statusFileName);
                }
            }
        }

        /// <summary>Create the status files.</summary>
        /// <param name="statusFileName">The name of the status file to write.</param>
        /// <param name="statusFilePaths">Paths where the status file will be written.</param>
        private static void WriteCurrentSettingsFiles(string currentSettingFileName, string currentSettingContent, List<string> statusFilePaths, TraceLogInfo traceInfo)
        {
            LogEvent.Trace(1, Asm, traceInfo);

            foreach (var path in statusFilePaths)
            {
                if (!File.Exists($@"{path}\{currentSettingFileName}"))
                {
                    File.WriteAllText($@"{path}\{currentSettingFileName}", currentSettingContent);
                }
            }
        }

        /// <summary>Delete existing status files.</summary>
        /// <param name="avatarSystemCode">The Avatar System Code.</param>
        /// <param name="statusFilePaths">Paths where the status file will be written.</param>
        private static void DeleteModeUpdateFiles(string avatarSystemCode, List<string> statusFilePaths, TraceLogInfo traceInfo)
        {
            LogEvent.Trace(1, Asm, traceInfo);

            foreach (var path in statusFilePaths)
            {
                string existingStatusFile = Directory.GetFiles(path).Where(directoryFiles => directoryFiles.Contains($"TINGEN {avatarSystemCode.ToUpper()} IS CURRENTLY")).FirstOrDefault();

                if (File.Exists(existingStatusFile))
                {
                    File.Delete(existingStatusFile);
                }
            }
        }

        /// <summary>Create the status files.</summary>
        /// <param name="statusFileName">The name of the status file to write.</param>
        /// <param name="statusFilePaths">Paths where the status file will be written.</param>
        private static void WriteModeUpdateFiles(string statusFileName, List<string> statusFilePaths, TraceLogInfo traceInfo)
        {
            LogEvent.Trace(1, Asm, traceInfo);

            foreach (var path in statusFilePaths)
            {
                if (!File.Exists($@"{path}\{statusFileName}"))
                {
                    File.WriteAllText($@"{path}\{statusFileName}", $"{DateTime.Now}");
                }
            }
        }
    }
}

/*

Development notes
-----------------

*/
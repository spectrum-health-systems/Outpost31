// u240606.1450

using System.IO;
using System.Linq;
using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Module.Admin.Service
{
    /// <summary>Soon.</summary>
    public static class Status
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        public static void UpdateAll(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            UpdateMode(tnSession.TnPath.Remote.Root, tnSession.AvData.AvatarSystemCode, tnSession.TnConfig.TingenMode, tnSession.TraceInfo);

            UpdateSettings(tnSession);
        }

        public static void UpdateMode(string remoteRoot, string avSystemCode, string tnMode, TraceLog traceInfo)
        {
            LogEvent.Trace(1, AssemblyName, traceInfo);

            string existingStatusFile = Directory.GetFiles(remoteRoot).Where(directoryFiles => directoryFiles.Contains($"TINGEN {avSystemCode.ToUpper()} IS CURRENTLY")).FirstOrDefault();

            foreach (var file in Directory.GetFiles(remoteRoot))
            {
                LogEvent.Primeval(Assembly.GetExecutingAssembly().GetName().Name);
                if (file.Contains($"TINGEN {avSystemCode.ToUpper()} IS CURRENTLY"))
                {
                    LogEvent.Primeval(Assembly.GetExecutingAssembly().GetName().Name);
                    File.Delete(file);
                }

                //LogEvent.Primeval(Assembly.GetExecutingAssembly().GetName().Name, file);


            }

            LogEvent.Primeval(Assembly.GetExecutingAssembly().GetName().Name, remoteRoot);

            File.WriteAllText($@"{remoteRoot}\TINGEN {avSystemCode.ToUpper()} IS CURRENTLY {tnMode.ToUpper()}", "");

            LogEvent.Primeval(Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static void UpdateSettings(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            var remoteRoot       = tnSession.TnPath.Remote.Root;
            var settingsFileName = $"Current-Tingen-{tnSession.AvData.AvatarSystemCode}-settings.md";
            var settingsFilePath = $@"{remoteRoot}\{settingsFileName}";

            if (File.Exists($@"{settingsFilePath}"))
            {
                File.Delete($@"{settingsFilePath}");
            }

            File.WriteAllText($@"{settingsFilePath}", Outpost31.Core.Session.Catalog.CurrentSettings(tnSession));
        }
    }
}

/*
Development notes
-----------------

*/
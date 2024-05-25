using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Outpost31.Module.Admin.Action
{
    public static partial class Service
    {
        public static void StatusUpdate(string tingenMode, string avatarSystemCode, List<string> serviceStatusPaths)
        {
            Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.Action.Service.StatusUpdate()]"); /* <- For development use only */

            Outpost31.Core.Debuggler.Primeval.Log($"[avatarSystemCode] {avatarSystemCode.ToUpper()}");

            DeleteExistingStatusFiles(avatarSystemCode, serviceStatusPaths);

            Outpost31.Core.Debuggler.Primeval.Log($"[1]");

            string statusFileName;

            Outpost31.Core.Debuggler.Primeval.Log($"[2]");

            switch (tingenMode)
            {
                case "enabled":
                    Outpost31.Core.Debuggler.Primeval.Log($"[3]");
                    statusFileName = $"TINGEN {avatarSystemCode.ToUpper()} IS CURRENTLY ENABLED";
                    Outpost31.Core.Debuggler.Primeval.Log($"[3a]");
                    break;

                case "disabled":
                    Outpost31.Core.Debuggler.Primeval.Log($"[4]");
                    statusFileName = $"TINGEN {avatarSystemCode.ToUpper()} IS CURRENTLY DISABLED";
                    break;

                default:
                    Outpost31.Core.Debuggler.Primeval.Log($"[5]");
                    statusFileName = $"TINGEN {avatarSystemCode.ToUpper()}  IS CURRENTLY IN AN UNKNOWN STATE";
                    break;
            }

            Outpost31.Core.Debuggler.Primeval.Log($"[6]");

            CreateStatusFiles(statusFileName, serviceStatusPaths);
        }

        private static void DeleteExistingStatusFiles(string avatarSystemCode, List<string> serviceStatusPaths)
        {
            Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.Action.Service.DeleteExistingStatusFiles()]"); /* <- For development use only */

            foreach (var path in serviceStatusPaths)
            {
                string existingStatusFile = Directory.GetFiles(path).Where(directoryFiles => directoryFiles.Contains($"TINGEN {avatarSystemCode.ToUpper()} IS CURRENTLY")).FirstOrDefault();

                if (File.Exists(existingStatusFile))
                {
                    File.Delete(existingStatusFile);
                }
            }
        }

        private static void CreateStatusFiles(string statusFileName, List<string> serviceStatusPaths)
        {
            Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.Action.Service.CreateStatusFiles()]"); /* <- For development use only */


            foreach (var path in serviceStatusPaths)
            {
                if (!File.Exists($@"{path}\{statusFileName}"))
                {
                    File.WriteAllText($@"{path}\{statusFileName}", "ok");
                    //File.Create($@"{path}\{statusFileName}");
                }
            }
        }
    }
}
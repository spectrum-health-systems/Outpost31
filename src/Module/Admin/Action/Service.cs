// u240525.1957

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Outpost31.Module.Admin.Action
{
    public static partial class Service
    {
        public static void StatusUpdate(string tingenMode, string avatarSystemCode, List<string> serviceStatusPaths)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.Action.Service.StatusUpdate()]"); /* <- For development use only */

            DeleteExistingStatusFiles(avatarSystemCode, serviceStatusPaths);

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
                    statusFileName = $"TINGEN {avatarSystemCode.ToUpper()}  IS CURRENTLY IN AN UNKNOWN STATE";
                    break;
            }

            CreateStatusFiles(statusFileName, serviceStatusPaths);
        }

        private static void DeleteExistingStatusFiles(string avatarSystemCode, List<string> serviceStatusPaths)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.Action.Service.DeleteExistingStatusFiles()]"); /* <- For development use only */

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
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Admin.Action.Service.CreateStatusFiles()]"); /* <- For development use only */


            foreach (var path in serviceStatusPaths)
            {
                if (!File.Exists($@"{path}\{statusFileName}"))
                {
                    File.WriteAllText($@"{path}\{statusFileName}", "ok");
                }
            }
        }
    }
}
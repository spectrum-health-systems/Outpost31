// u240531.0725

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Outpost31.Module.Admin
{
    public static class Service
    {
        /// <summary>Write a file indicating the status of the Tingen web service.</summary>
        /// <param name="tingenMode">The current Tingen web service mode.</param>
        /// <param name="avatarSystemCode">The Avatar System Code.</param>
        /// <param name="serviceStatusPaths">Paths where the status file will be written.</param>
        /// <remarks>
        ///  <para>
        ///   Prior to creating the status file, any existing status files are deleted.<br/><br/>
        ///   Status files are written to the various paths for various uses.
        ///  </para>
        /// </remarks>
        public static void ModeUpdate(string tingenMode, string avatarSystemCode, List<string> serviceStatusPaths)
        {
            //Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Module.Admin.Action.Service.StatusUpdate()]"); /* <- For development use only */

            DeleteExistingLocalStatusFiles(avatarSystemCode, serviceStatusPaths);

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

            WriteLocalStatusFiles(statusFileName, serviceStatusPaths);
        }

        /// <summary>Delete existing status files.</summary>
        /// <param name="avatarSystemCode">The Avatar System Code.</param>
        /// <param name="serviceStatusPaths">Paths where the status file will be written.</param>
        private static void DeleteExistingLocalStatusFiles(string avatarSystemCode, List<string> serviceStatusPaths)
        {
            //Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Module.Admin.Action.Service.DeleteExistingStatusFiles()]"); /* <- For development use only */

            foreach (var path in serviceStatusPaths)
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
        /// <param name="serviceStatusPaths">Paths where the status file will be written.</param>
        private static void WriteLocalStatusFiles(string statusFileName, List<string> serviceStatusPaths)
        {
            //Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Module.Admin.Action.Service.CreateStatusFiles()]"); /* <- For development use only */


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

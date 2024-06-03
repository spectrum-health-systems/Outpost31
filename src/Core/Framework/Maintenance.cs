// u240603.1702

using System.Reflection;

namespace Outpost31.Core.Framework
{
    public static class Maintenance
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    The executing assembly is defined at the start of the class so it can be easily used throughout the class when creating
        ///    log files.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        public static void CleanSessionData()
        {
            /* Can't put a trace log here, so we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName);

            // Clean up temporary files
            // Clean up log files
            // Clean up cache files
            // Clean up session files
        }

        public static void RefreshDirectory(string directoryPath)
        {
            /* Can't do logging here, sorry!
             */

            /* This method may be called by Outpost31.Core.Debuggler.PrimevalLog.DevelopmentCleanup(), and to avoid a possible
             * infinate loop/stack overflow, we'll skip creating a Primeval log when refreshing the Primeval log directories. Since
             * the directories are going to be refreshed, any log we created would be deleted anyway. For all other refreshes, create a
             * Primeval log.
             */
            if (!directoryPath.Contains("Primeval"))
            {
                //LogEvent.Primeval(AssemblyName);
            }
            else
            {
                // TODO maybe put a trace log here.
            }

            if (System.IO.Directory.Exists(directoryPath))
            {
                System.IO.Directory.Delete(directoryPath, true);
                System.IO.Directory.CreateDirectory(directoryPath);
            }
        }

        public static void VerifyDirectory(string directoryPath)
        {
            /* Can't do logging here, sorry!
             */

            /* This method may be called by Outpost31.Core.Debuggler.PrimevalLog.Create(), and attempting verify the path to Primeval
             * logs when creating one causes a infinate loop/stack overflow. Therefore, if the path contains "Primeval", do not create
             * a Primeval log, just verify that the directory exists. For all other verifications, create a Primeval log.
             */
            if (!directoryPath.Contains("Primeval"))
            {
                //LogEvent.Primeval(AssemblyName);
            }
            else
            {
                // TODO maybe put a trace log here.
            }

            if (!System.IO.Directory.Exists(directoryPath))
            {
                System.IO.Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
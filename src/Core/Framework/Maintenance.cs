// u240605.1111

using System.Collections.Generic;
using System.Reflection;
using Outpost31.Core.Session;

namespace Outpost31.Core.Framework
{
    public static class Maintenance
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Soon.</summary>
        public static void CleanSessionData()
        {
            //* For debugging */
            //LogEvent.Primeval(Asm);

            // Clean up temporary files
            // Clean up log files
            // Clean up cache files
            // Clean up session files
        }

        public static void DevelopmentModeCleanup(string primeval, string sessions)
        {
            Outpost31.Core.Framework.Maintenance.RefreshDirectory(primeval);
            Outpost31.Core.Framework.Maintenance.RefreshDirectory(sessions);
        }

        public static void VerifyFrameworkStructure(TingenSession tnSession)
        {
            Outpost31.Core.Framework.Maintenance.VerifyDirectories(Outpost31.Core.Framework.Catalog.TingenPaths.Required(tnSession.TnPath.Tingen));
            Outpost31.Core.Framework.Maintenance.VerifyDirectories(Outpost31.Core.Framework.Catalog.PublicPaths.Required(tnSession.TnPath.Public));
            Outpost31.Core.Framework.Maintenance.VerifyDirectories(Outpost31.Core.Framework.Catalog.RemotePaths.Required(tnSession.TnPath.Remote));
            Outpost31.Core.Framework.Maintenance.VerifyDirectories(Outpost31.Core.Framework.Catalog.SystemCodePaths.Required(tnSession.TnPath.SystemCode));
        }


        /// <summary>Delete a directory, then recreate it.</summary>
        /// <remarks>
        ///  <para>
        ///   <b>A note about this method and logging:</b><br/>
        ///   This method may be called by <b>Outpost31.Core.Debuggler.PrimevalLog.DevelopmentCleanup()</b>. To avoid a possible infinate
        ///   loop/stack overflow situation, we'll skip creating a Primeval log when refreshing the Primeval log directories.<br/><br/>
        ///   Since the directories are going to be refreshed, any log we created would be deleted anyway.
        ///  </para>
        /// </remarks>
        /// <param name="directoryPath">The path to the directory to refresh.</param>
        public static void RefreshDirectory(string directoryPath)
        {
            /* See method comments for logging information. */

            if (!directoryPath.Contains("Primeval"))
            {
                /* For debugging purposes, use a Primeval log here. */
            }
            else
            {
                // TODO Trace log here.
            }

            if (System.IO.Directory.Exists(directoryPath))
            {
                System.IO.Directory.Delete(directoryPath, true);
                System.IO.Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>Verify a directory exists, and create it if it does not.</summary>
        /// <remarks>
        ///  <para>
        ///   <b>A note about this method and logging:</b><br/>
        ///   This method may be called by <b>Outpost31.Core.Debuggler.PrimevalLog.DevelopmentCleanup()</b>. To avoid a possible infinate
        ///   loop/stack overflow situation, we'll skip creating a Primeval log when refreshing the Primeval log directories.<br/><br/>
        ///   Since the directories are going to be refreshed, any log we created would be deleted anyway.Prototype b240605-stable.01
        ///  </para>
        /// </remarks>
        /// <param name="directoryPath">The path to the directory to verify.</param>
        public static void VerifyDirectory(string directoryPath)
        {
            /* See method comments for logging information. */

            if (!directoryPath.Contains("Primeval"))
            {
                /* For debugging purposes, use a Primeval log here. */
            }
            else
            {
                // TODO Trace log here.
            }

            if (!System.IO.Directory.Exists(directoryPath))
            {
                System.IO.Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>Verify a list of directories exist, and create them if they do not.</summary>
        /// <remarks>
        ///  <para>
        ///   <b>A note about this method and logging:</b><br/>
        ///   This method may be called by <b>Outpost31.Core.Debuggler.PrimevalLog.DevelopmentCleanup()</b>. To avoid a possible infinate
        ///   loop/stack overflow situation, we'll skip creating a Primeval log when refreshing the Primeval log directories.<br/><br/>
        ///   Since the directories are going to be refreshed, any log we created would be deleted anyway.
        ///  </para>
        /// </remarks>
        /// <param name="directoryPaths">The list of directories to verify.</param>
        public static void VerifyDirectories(List<string> directoryPaths)
        {
            /* See method comments for logging information. */

            foreach (var directoryPath in directoryPaths)
            {
                if (!directoryPath.Contains("Primeval"))
                {
                    /* For debugging purposes, use a Primeval log here. */
                }
                else
                {
                    // TODO Trace log here.
                }

                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
            }
        }
    }
}

/*

Development notes
-----------------

*/
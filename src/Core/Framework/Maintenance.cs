// u240820.1345_code
// u241114_documentation

using System.Collections.Generic;
using System.Reflection;
using Outpost31.Core.Session;

namespace Outpost31.Core.Framework
{
    /// <summary>Methods for maintaining the Tingen framework.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Framework.Maintenance_doc.xml' path='Outpost31.Core.Framework.Maintenance/Type[@name="Class"]/Maintenance/*'/>
    public static class Maintenance
    {
        /// <summary>The executing assembly name.</summary>
        /// <remarks>This is defined here so it can be used to write log files throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Verify the Tingen framework.</summary>
        /// <param name="tnSession">The Tingen Session object.</param>
        /// <include file='XmlDoc/Outpost31.Core.Framework.Maintenance_doc.xml' path='Outpost31.Core.Framework.Maintenance/Type[@name="Method"]/VerifyFramework/*'/>
        public static void VerifyFramework(TingenSession tnSession)
        {
            VerifyDirectories(Catalog.TingenPaths.RequiredPaths(tnSession.TnPath.Tingen));
            VerifyDirectories(Catalog.PublicPaths.RequiredPaths(tnSession.TnPath.Public));
            VerifyDirectories(Catalog.RemotePaths.RequiredPaths(tnSession.TnPath.Remote));
            VerifyDirectories(Catalog.SystemCodePaths.RequiredPaths(tnSession.TnPath.SystemCode));
        }

        /// <summary>Delete a directory, then recreate it.</summary>
        /// <param name="directoryPath">The path to the directory to refresh.</param>
        /// <include file='XmlDoc/Outpost31.Core.Framework.Maintenance_doc.xml' path='Outpost31.Core.Framework.Maintenance/Type[@name="Method"]/RefreshDirectory/*'/>
        public static void RefreshDirectory(string directoryPath)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

            if (directoryPath.Contains("Primeval"))
            {
                /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet.
                 *
                 * You can't put a Primeval log here either, since that may result in an infinite loop/stack overflow
                 * when Primeval log directory is being refreshed.
                 *
                 * So, no logging for you!
                 */
            }
            else
            {
                /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet.
                 *
                 * Use a Primeval Log here at your own risk!
                 */
            }

            if (System.IO.Directory.Exists(directoryPath))
            {
                /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet.
                 *
                 * Creating a Primeval log here is not recommended. If you need to debug this method, you'll need to
                 * insert some of the logic above to avoid infinite loops/stack overflows.
                 */

                System.IO.Directory.Delete(directoryPath, true);
                System.IO.Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>Verify a directory exists, and create it if it does not.</summary>
        /// <param name="directoryPath">The path to the directory to verify.</param>
        /// <include file='XmlDoc/Outpost31.Core.Framework.Maintenance_doc.xml' path='Outpost31.Core.Framework.Maintenance/Type[@name="Method"]/VerifyDirectory/*'/>
        public static void VerifyDirectory(string directoryPath)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

            if (directoryPath.Contains("Primeval"))
            {
                /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet.
                 *
                 * You can't put a Primeval Log here either, since that may result in an infinite loop/stack overflow
                 * when Primeval log directory is being refreshed.
                 *
                 * So, no logging for you!
                 */
            }
            else
            {
                /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet.
                 *
                 * Use a Primeval Log here at your own risk!
                 */
            }

            if (!System.IO.Directory.Exists(directoryPath))
            {
                /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet.
                 *
                 * Creating a Primeval log here is not recommended. If you need to debug this method, you'll need to
                 * insert some of the logic above to avoid infinite loops/stack overflows.
                 */

                System.IO.Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>Verify a list of directories exist, and create them if they do not.</summary>
        /// <param name="directoryPaths">The list of directories to verify.</param>
        /// <include file='XmlDoc/Outpost31.Core.Framework.Maintenance_doc.xml' path='Outpost31.Core.Framework.Maintenance/Type[@name="Method"]/VerifyDirectories/*'/>
        public static void VerifyDirectories(List<string> directoryPaths)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

            foreach (var directoryPath in directoryPaths)
            {
                if (directoryPath.Contains("Primeval"))
                {
                    /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet.
                    *
                    * You can't put a Primeval Log here either, since that may result in an infinite loop/stack overflow
                    * when Primeval log directory is being refreshed.
                    *
                    * So, no logging for you!
                    */
                }
                else
                {
                    /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet.
                     *
                     * Use a Primeval Log here at your own risk!
                     */
                }

                if (!System.IO.Directory.Exists(directoryPath))
                {
                    /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet.
                     *
                     * Creating a Primeval log here is not recommended. If you need to debug this method, you'll need to
                     * insert some of the logic above to avoid infinite loops/stack overflows.
                     */
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
            }
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

-----------------
[DN--] 2241021
-----------------
Can this be cleaned up?

*/
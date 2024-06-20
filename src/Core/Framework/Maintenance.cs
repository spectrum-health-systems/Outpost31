// u240620.1254

using System.Collections.Generic;
using System.Reflection;
using Outpost31.Core.Session;

namespace Outpost31.Core.Framework
{
    /// <summary>Methods for maintaining the Tingen framework.</summary>
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
            // TODO
        }

        /// <summary>Verify the Tingen framework.</summary>
        /// <param name="tnSession">The Tingen Session object.</param>
        public static void VerifyFramework(TingenSession tnSession)
        {
            /*[1]*/
            VerifyDirectories(Catalog.TingenPaths.RequiredPaths(tnSession.TnPath.Tingen));
            VerifyDirectories(Catalog.PublicPaths.RequiredPaths(tnSession.TnPath.Public));
            VerifyDirectories(Catalog.RemotePaths.RequiredPaths(tnSession.TnPath.Remote));
            VerifyDirectories(Catalog.SystemCodePaths.RequiredPaths(tnSession.TnPath.SystemCode));
        }

        /// <summary>Delete a directory, then recreate it.</summary>
        /// <param name="directoryPath">The path to the directory to refresh.</param>
        public static void RefreshDirectory(string directoryPath)
        {
            /* Trace logs cannot be used here, and Primeval logs may cause an infinate loop/stack overflow.
             * If you need to debug this method, use a Primeval log in the "else" statement below.
             */

            if (directoryPath.Contains("Primeval"))
            {
                /*[2]*/
                /* You can't put a Trace log here, since this method may be called prior to the Tingen Session being initialized.
                 *
                 * You can't put a Primeval log here either, since that may result in an infinate loop/stack overflow when Primeval
                 * log directory is being refreshed.
                 *
                 * So, no logging for you!
                 */
            }
            else
            {
                /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */
            }

            if (System.IO.Directory.Exists(directoryPath))
            {
                /* Createing logs here is not recommended. If you need to debug this method, you'll need to insert some of the logic
                 * above to avoid infinate loops/stack overflows.
                 */
                System.IO.Directory.Delete(directoryPath, true);
                System.IO.Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>Verify a directory exists, and create it if it does not.</summary>
        /// <remarks>
        /// <param name="directoryPath">The path to the directory to verify.</param>
        public static void VerifyDirectory(string directoryPath)
        {
            /* Trace logs cannot be used here, and Primeval logs may cause an infinate loop/stack overflow.
             * If you need to debug this method, use a Primeval log in the "else" statement below.
             */

            if (directoryPath.Contains("Primeval"))
            {
                /*[2]*/
                /* You can't put a Trace log here, since this method may be called prior to the Tingen Session being initialized.
                 *
                 * You can't put a Primeval log here either, since that may result in an infinate loop/stack overflow when Primeval
                 * log directory is being refreshed.
                 *
                 * So, no logging for you!
                 */
            }
            else
            {
                /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */
            }

            if (!System.IO.Directory.Exists(directoryPath))
            {
                /* Createing logs here is not recommended. If you need to debug this method, you'll need to insert some of the logic
                 * above to avoid infinate loops/stack overflows.
                 */
                System.IO.Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>Verify a list of directories exist, and create them if they do not.</summary>
        /// <remarks>
        /// <param name="directoryPaths">The list of directories to verify.</param>
        public static void VerifyDirectories(List<string> directoryPaths)
        {
            /* Trace logs cannot be used here, and Primeval logs may cause an infinate loop/stack overflow.
             * If you need to debug this method, use a Primeval log in the "else" statement below.
             */

            foreach (var directoryPath in directoryPaths)
            {
                if (directoryPath.Contains("Primeval"))
                {
                    /*[2]*/
                    /* You can't put a Trace log here, since this method may be called prior to the Tingen Session being initialized.
                     *
                     * You can't put a Primeval log here either, since that may result in an infinate loop/stack overflow when Primeval
                     * log directory is being refreshed.
                     *
                     * So, no logging for you!
                     */
                }
                else
                {
                    /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */
                }

                if (!System.IO.Directory.Exists(directoryPath))
                {
                    /* Createing logs here is not recommended. If you need to debug this method, you'll need to insert some of the logic
                     * above to avoid infinate loops/stack overflows.
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

[1] - Probably don't need to pass the entire TingenSession object to this method. Just pass the TingenPaths object.
[2] - Verify this works as expected (it used to be !directoryPath.Contains("Primeval")).

_Documentation updated 240620
*/
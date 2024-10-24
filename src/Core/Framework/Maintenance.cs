﻿// u240820.1345_code
// u240820.1345_documentation

using System.Collections.Generic;
using System.Reflection;
using Outpost31.Core.Session;

namespace Outpost31.Core.Framework
{
    /// <summary>Methods for maintaining the Tingen framework.</summary>
    public static class Maintenance
    {
        /// <summary>Assembly name for logging purposes.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Type[@name="Property"]/AssemblyName/*'/>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Verify the Tingen framework.</summary>
        /// <param name="tnSession">The Tingen Session object.</param>
        public static void VerifyFramework(TingenSession tnSession)
        {
            VerifyDirectories(Catalog.TingenPaths.RequiredPaths(tnSession.TnPath.Tingen));
            VerifyDirectories(Catalog.PublicPaths.RequiredPaths(tnSession.TnPath.Public));
            VerifyDirectories(Catalog.RemotePaths.RequiredPaths(tnSession.TnPath.Remote));
            VerifyDirectories(Catalog.SystemCodePaths.RequiredPaths(tnSession.TnPath.SystemCode));
        }

        /// <summary>Delete a directory, then recreate it.</summary>
        /// <param name="directoryPath">The path to the directory to refresh.</param>
        public static void RefreshDirectory(string directoryPath)
        {
            /* Trace logs cannot be used here, and Primeval logs may cause an infinite loop/stack overflow.
             * If you need to debug this method, use a Primeval log in the "else" statement below.
             */

            if (directoryPath.Contains("Primeval"))
            {
                /* You can't put a Trace log here, since this method may be called prior to the Tingen Session being initialized.
                 *
                 * You can't put a Primeval log here either, since that may result in an infinite loop/stack overflow when Primeval
                 * log directory is being refreshed.
                 *
                 * So, no logging for you!
                 */
            }
            else
            {
                /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
                 */
            }

            if (System.IO.Directory.Exists(directoryPath))
            {
                /* Creating logs here is not recommended. If you need to debug this method, you'll need to insert some of the logic
                 * above to avoid infinite loops/stack overflows.
                 */
                System.IO.Directory.Delete(directoryPath, true);
                System.IO.Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>Verify a directory exists, and create it if it does not.</summary>
        /// <remarks></remarks>
        /// <param name="directoryPath">The path to the directory to verify.</param>
        public static void VerifyDirectory(string directoryPath)
        {
            /* Trace logs cannot be used here, and Primeval logs may cause an infinite loop/stack overflow.
             * If you need to debug this method, use a Primeval log in the "else" statement below.
             */

            if (directoryPath.Contains("Primeval"))
            {
                /* You can't put a Trace log here, since this method may be called prior to the Tingen Session being initialized.
                 *
                 * You can't put a Primeval log here either, since that may result in an infinite loop/stack overflow when Primeval
                 * log directory is being refreshed.
                 *
                 * So, no logging for you!
                 */
            }
            else
            {
                /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
                 */
            }

            if (!System.IO.Directory.Exists(directoryPath))
            {
                /* Creating logs here is not recommended. If you need to debug this method, you'll need to insert some of the logic
                 * above to avoid infinite loops/stack overflows.
                 */
                System.IO.Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>Verify a list of directories exist, and create them if they do not.</summary>
        /// <remarks>
        /// <param name="directoryPaths">The list of directories to verify.</param>
        public static void VerifyDirectories(List<string> directoryPaths)
        {
            /* Trace logs cannot be used here, and Primeval logs may cause an infinite loop/stack overflow.
             * If you need to debug this method, use a Primeval log in the "else" statement below.
             */

            foreach (var directoryPath in directoryPaths)
            {
                if (directoryPath.Contains("Primeval"))
                {
                    /* You can't put a Trace log here, since this method may be called prior to the Tingen Session being initialized.
                     *
                     * You can't put a Primeval log here either, since that may result in an infinite loop/stack overflow when Primeval
                     * log directory is being refreshed.
                     *
                     * So, no logging for you!
                     */
                }
                else
                {
                    /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
                     */
                }

                if (!System.IO.Directory.Exists(directoryPath))
                {
                    /* Creating logs here is not recommended. If you need to debug this method, you'll need to insert some of the logic
                     * above to avoid infinite loops/stack overflows.
                     */
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
            }
        }
    }
}
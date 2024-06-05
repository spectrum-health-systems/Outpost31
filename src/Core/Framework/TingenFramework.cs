// u240605.1144

/* =====================================================================================================================
 * Adding new framework components to Tingen
 * -----------------------------------------
 * When adding a new framework component to Tingen, you need to do the following:
 *
 * First, add the new component as a property to the TingenFramework class in TingenFramework.Properties.cs.
 *
 * If the new component is a path:
 *  - Add an entry for the path to Framework.Catalog.PathPostfixes()
 *  - Add an entry for the path to TingenFramework.Build()
 * ================================================================================================================== */

using System.Collections.Generic;
using System.IO;
using Outpost31.Core.Session;

namespace Outpost31.Core.Framework
{
    /// <summary>The Tingen Framwork.</summary>
    /// <remarks>
    ///  <para>
    ///   The Tingen Framework is comprised of:
    ///   <list type = "bullet">
    ///    <item>The Tingen directory structure</item>
    ///    <item>Tingen core data/files</item>
    ///    <item>Tingen maintenance procedures</item>
    ///   </list>
    ///  </para>
    /// </remarks>
    public class TingenFramework
    {
        /// <summary>Soon.</summary>
        public DataRoots DataRoot { get; set; }

        /// <summary>Soon.</summary>
        public SystemCodePaths SystemCodePath { get; set; }

        /// <summary>Soon.</summary>
        public PublicPaths PublicPath { get; set; }

        /// <summary>Soon.</summary>
        public RemotePaths RemotePath { get; set; }

        /// <summary>Soon.</summary>
        public OtherPaths OtherPath { get; set; }

        /// <summary>Builds the Tingen Framework components.</summary>
        /// <param name="tingenDataRoot">The Tingen data root directory.</param>
        /// <param name="avatarSystemCode">The Avatar System Code</param>
        /// <remarks>
        ///  Soon.
        /// </remarks>
        /// <returns>The Abatab Framework components.</returns>
        public static TingenFramework Build(string tingenDataRoot, string avatarSystemCode, string avatarUserName, string datestamp, string timestamp)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            var dataPath = FrameworkCatalog.DataPaths(tingenDataRoot, avatarSystemCode,  avatarUserName, datestamp, timestamp);

            var tnFramework = new TingenFramework
            {
                DataRoot = new DataRoots
                {
                    Tingen     = dataPath["TingenDataRoot"],
                    SystemCode = dataPath["AvatarSystemCode"],
                    RawData    = dataPath["RawDataRoot"],
                    Message    = dataPath["MessageRoot"],
                    Public     = dataPath["PublicRoot"],
                    Remote     = dataPath["RemoteRoot"]
                },
                SystemCodePath = new SystemCodePaths
                {
                    Admin     = dataPath["Admin"],
                    Archive   = dataPath["Archive"],
                    Config    = dataPath["Config"],
                    Debug     = dataPath["Debug"],
                    Extension = dataPath["Extension"],
                    Log       = dataPath["Log"],
                    Report    = dataPath["Report"],
                    Session   = dataPath["Session"],
                    Template  = dataPath["Template"],
                    Temporary = dataPath["Temporary"]
                },
                PublicPath = new PublicPaths
                {
                    Alert   = dataPath["PublicAlert"],
                    Error   = dataPath["PublicError"],
                    Export  = dataPath["PublicExport"],
                    Report  = dataPath["PublicReport"],
                    Warning = dataPath["PublicWarning"]
                },
                RemotePath = new RemotePaths
                {
                    Alert   = dataPath["RemoteAlert"],
                    Error   = dataPath["RemoteError"],
                    Export  = dataPath["RemoteExport"],
                    Report  = dataPath["RemoteReport"],
                    Warning = dataPath["RemoteWarning"]
                },
                OtherPath = new OtherPaths
                {
                    ServiceStatusPaths = new List<string>()
                }

            };

            tnFramework.OtherPath.ServiceStatusPaths = FrameworkCatalog.ServiceStatusUpdatePaths(tnFramework);

            return tnFramework;
        }

        // DEPRECIATED
        //public static void VerifyRequiredDirectories(TingenSession tnSession)
        //{
        //    if (!Directory.Exists(tnSession.Framework.SystemCodePath.Session))
        //    {
        //        Directory.CreateDirectory(tnSession.Framework.SystemCodePath.Session);
        //    }
        //}
    }
}

/*

Development notes
-----------------
- Move the block of text at the top to documentation.

*/
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

using System.Reflection;

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


        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Builds the Tingen Framework components.</summary>
        /// <param name="tingenDataRoot">The Tingen data root directory.</param>
        /// <param name="avatarSystemCode">The Avatar System Code</param>
        /// <remarks>
        ///  Soon.
        /// </remarks>
        /// <returns>The Abatab Framework components.</returns>
        public static TingenFramework Build(string tingenDataRoot, string avatarSystemCode, string date)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            var dataPath = Framework.Catalog.DataPaths(tingenDataRoot, avatarSystemCode, date);

            var tnFramework = new TingenFramework
            {
                DataRoot = new DataRoots
                {
                    Tingen     = dataPath["TingenDataRoot"],
                    SystemCode = dataPath["AvatarSystemCode"],
                    RawData    = dataPath["RawDataRoot"],
                    Message    = dataPath["MessageRoot"],
                    Public     = dataPath["PublicRoot"],
                    Remote     = dataPath["RemoteRoot"],
                    Session    = dataPath["SessionRoot"]
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

            };

            tnFramework.OtherPath.ServiceStatusPaths = Catalog.ServiceStatusPaths(tnFramework);

            return tnFramework;
        }
    }
}

/*

Development notes
-----------------
- Remove the Primeval calls, potentially replace with Tracelogs.
- If logs aren't written, remove the Asm property.

*/
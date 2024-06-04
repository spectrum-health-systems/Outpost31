// u240603.1731

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
    ///   This is part of a partial class:
    ///   <list type="table">
    ///    <item>
    ///     <term>TingenFramework.cs</term>
    ///     <description>Logic for the TingenFramework class</description>
    ///    </item>
    ///    <item>
    ///     <term>TingenFramework.Properties.cs</term>
    ///     <description>Properties for the TingenFramework class</description>
    ///    </item>
    ///   </list>
    ///  </para>
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
        public DataRoots DataRoot { get; set; }
        public SystemCodePaths SystemCodePath { get; set; }
        public PublicPaths PublicPath { get; set; }
        public RemotePaths RemotePath { get; set; }
        public OtherPaths OtherPath { get; set; }


        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    The executing assembly is defined at the start of the class so it can be easily used throughout the class when creating
        ///    log files.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Builds the Tingen Framework components.</summary>
        /// <param name="tingenDataRoot">The Tingen data root directory.</param>
        /// <param name="avatarSystemCode">The Avatar System Code</param>
        /// <remarks>
        ///  <para>
        ///   When a new path property is added to TingenFramework.Properties.cs, a new entry needs to be added here.
        ///  </para>
        ///  <para>
        ///   This method build the following Tingen framework components:
        ///   <list type="table">
        ///    <item>
        ///     <term>Directory paths</term>
        ///     <description>Required directory paths</description>
        ///    </item>
        ///    <item>
        ///     <term>Service status paths</term>
        ///     <description>Paths where service status files are located</description>
        ///    </item>
        ///   </list>
        ///  </para>
        /// </remarks>
        /// <returns>The Abatab Framework components.</returns>
        public static TingenFramework Build(string tingenDataRoot, string avatarSystemCode, string date)
        {
            /* <!-- For debugging: LogEvent.Primeval(asm); --> */ // To be removed.

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
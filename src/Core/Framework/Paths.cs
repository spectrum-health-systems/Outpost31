// u240617.1054

using Outpost31.Core.Framework.Catalog;

namespace Outpost31.Core.Framework
{
    /// <summary>The Tingen Framework.</summary>
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
    public class Paths
    {
        /// <summary>Paths for Tingen.</summary>
        public TingenPaths Tingen { get; set; }

        /// <summary>Paths for system code.</summary>
        public SystemCodePaths SystemCode { get; set; }

        /// <summary>Paths for public files.</summary>
        public PublicPaths Public { get; set; }

        /// <summary>Paths for remote files.</summary>
        public RemotePaths Remote { get; set; }

        /// <summary>Builds the paths object.</summary>
        /// <param name="tnDataRoot"></param>
        /// <param name="avSystemCode"></param>
        /// <returns></returns>
        public static Paths Build(string tnDataRoot, string avSystemCode)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            return new Paths
            {
                Tingen     = TingenPaths.BuildObject(tnDataRoot),
                Public     = PublicPaths.BuildObject(tnDataRoot),
                Remote     = RemotePaths.BuildObject(tnDataRoot),
                SystemCode = SystemCodePaths.BuildObject(tnDataRoot, avSystemCode)
            };
        }
    }
}

/*

-----------------
Development notes
-----------------

*/
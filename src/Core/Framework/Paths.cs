// u240606.1336

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
        public TingenPaths Tingen { get; set; }
        public SystemCodePaths SystemCode { get; set; }
        public PublicPaths Public { get; set; }
        public RemotePaths Remote { get; set; }

        public static Paths Build(string tnDataRoot, string avSystemCode)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            return new Paths
            {
                Tingen     = TingenPaths.Build(tnDataRoot),
                Public     = PublicPaths.Build(tnDataRoot),
                Remote     = RemotePaths.Build(tnDataRoot),
                SystemCode = SystemCodePaths.Build(tnDataRoot, avSystemCode)
            };
        }
    }
}

/*

Development notes
-----------------

*/
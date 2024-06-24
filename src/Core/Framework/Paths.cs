// u240624.0843_code
// u240624.0843_documentation

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
        /// <summary>Tingen data paths.</summary>
        public TingenPaths Tingen { get; set; }

        /// <summary>System code data paths.</summary>
        public SystemCodePaths SystemCode { get; set; }

        /// <summary>Public data paths.</summary>
        public PublicPaths Public { get; set; }

        /// <summary>Remote data paths.</summary>
        public RemotePaths Remote { get; set; }

        /// <summary>Builds the paths object.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <param name="avSystemCode">The Avatar System Code.</param>
        /// <returns>The Tingen data paths</returns>
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
// u240709.0000_code
// u241021_documentation

using Outpost31.Core.Framework.Catalog;

namespace Outpost31.Core.Framework
{
    /// <summary>The Tingen Framework.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31.Core.Framework/Cs[@name="Paths"]/Paths/*'/>
    public class Paths
    {
        /// <summary>Tingen data paths.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/TingenDataRoot/*'/>
        public TingenPaths Tingen { get; set; }

        /// <summary>System code data paths.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/SystemCodesDataRoot/*'/>
        public SystemCodePaths SystemCode { get; set; }

        /// <summary>Public data paths.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/PublicDataRoot/*'/>
        public PublicPaths Public { get; set; }

        /// <summary>Remote data paths.</summary>
        public RemotePaths Remote { get; set; }

        /// <summary>Builds the paths object.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <param name="avSystemCode">The Avatar System Code.</param>
        /// <remarks>Builds the paths object.</remarks>
        /// <returns>The Tingen data paths.</returns>
        public static Paths Build(string tnDataRoot, string avSystemCode)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been been initialized yet, so if you
             * need to create a logfile here, use a Primeval Log.
             */

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
=================
DEVELOPMENT NOTES
=================

None.

*/
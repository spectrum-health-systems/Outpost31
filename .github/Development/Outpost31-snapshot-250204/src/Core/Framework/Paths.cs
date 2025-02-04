// u240709.0000_code
// u241021_documentation

using Outpost31.Core.Framework.Catalog;

namespace Outpost31.Core.Framework
{
    /// <summary>The Tingen Framework paths.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Framework.Paths_doc.xml' path='Outpost31.Core.Framework.Paths/Type[@name="Class"]/Paths/*'/>
    public class Paths
    {
        /// <summary>Tingen data paths.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="RootPath"]/TingenData/*'/>
        public TingenPaths Tingen { get; set; }

        /// <summary>System code data paths.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="RootPath"]/SystemCodeData/*'/>
        public SystemCodePaths SystemCode { get; set; }

        /// <summary>Public data paths.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="RootPath"]/PublicData/*'/>
        public PublicPaths Public { get; set; }

        /// <summary>Remote data paths.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="RootPath"]/RemoteData/*'/>
        public RemotePaths Remote { get; set; }

        /// <summary>Builds the paths object.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <param name="avSystemCode">The Avatar System Code.</param>
        /// <remarks>Builds the paths object.</remarks>
        /// <returns>The Tingen data paths.</returns>
        public static Paths Build(string tnDataRoot, string avSystemCode)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
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
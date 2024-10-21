// u240821.1043_code
// u241021_documentation

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>Specific to Tingen.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Framework_doc.xml' path='Outpost31.Core.Framework/Cs[@name="TingenPaths"]/TingenPaths/*'/>
    public class TingenPaths
    {
        /// <summary>Root path for Tingen data.</summary>
        /// <value>C:\TingenData</value>
        public string Root { get; set; }

        /// <summary>Path for Tingen Primeval data.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="Paths"]/Primeval/*'/>
        /// <value>C:\TingenData\Primeval</value>
        public string Primeval { get; set; }

        /// <summary>Builds the Tingen path object.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <returns>A collection of Tingen paths.</returns>
        public static TingenPaths BuildObject(string tnDataRoot)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been been initialized yet, so if you
             * need to create a logfile here, use a Primeval Log.
             */

            return new TingenPaths
            {
                Root     = tnDataRoot,
                Primeval = $@"{tnDataRoot}\Primeval"
            };
        }

        /// <summary>Returns a list of required Tingen paths.</summary>
        /// <param name="tnPaths">The Tingen paths.</param>
        /// <returns>The list of required Tingen paths.</returns>
        public static List<string> RequiredPaths(TingenPaths tnPaths)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been been initialized yet, so if you
             * need to create a logfile here, use a Primeval Log.
             */

            return new List<string>
            {
                tnPaths.Root,
                tnPaths.Primeval
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
// u240620.1249
using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>Specific to Tingen.</summary>
    public class TingenPaths
    {
        /// <summary>Root path for Tingen data.</summary>
        /// <value>C:\TingenData</value>
        public string Root { get; set; }

        /// <summary>Path for Tingen Primeval data.</summary>
        /// <value>C:\TingenData\Primeval</value>
        public string Primeval { get; set; }

        /// <summary>Builds the Tingen path object.</summary>
        /// <param name="tnDataRoot">The Tingen data root.</param>
        /// <returns>A collection of Tingen paths.</returns>
        public static TingenPaths BuildObject(string tnDataRoot)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

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
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

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

- Better way to do RequiredPaths()?

_Documentation updated 240620
*/
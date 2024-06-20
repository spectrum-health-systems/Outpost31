// u240607.1012

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>Specific to Tingen.</summary>
    public class TingenPaths
    {
        /// <summary>Root path for Tingen files.</summary>
        /// <value>C:\TingenData</value>
        public string Root { get; set; }

        /// <summary>Path for Tingen Primeval files.</summary>
        /// <value>C:\TingenData\Primeval</value>
        public string Primeval { get; set; }

        /// <summary>Builds the Tingen path object.</summary>
        /// <param name="tnDataRoot"></param>
        /// <returns></returns>
        public static TingenPaths BuildObject(string tnDataRoot)
        {
            return new TingenPaths
            {
                Root     = tnDataRoot,
                Primeval = $@"{tnDataRoot}\Primeval"
            };
        }

        /// <summary>Returns a list of required paths.</summary>
        /// <param name="tnPaths"></param>
        /// <returns></returns>
        public static List<string> RequiredPaths(TingenPaths tnPaths)
        {
            return new List<string>
            {
                tnPaths.Root,
                tnPaths.Primeval
            };
        }
    }
}

/*

-----------------
Development notes
-----------------

- Better way to do RequiredPaths()?

*/
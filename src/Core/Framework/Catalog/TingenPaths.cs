// u240607.1012

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>Specific to Tingen.</summary>
    public class TingenPaths
    {
        public string Root { get; set; }
        public string Primeval { get; set; }

        public static TingenPaths BuildObject(string tnDataRoot)
        {
            return new TingenPaths
            {
                Root     = tnDataRoot,
                Primeval = $@"{tnDataRoot}\Primeval"
            };
        }

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

*/
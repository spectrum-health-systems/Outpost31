// u240606.1145

using System.Collections.Generic;

namespace Outpost31.Core.Framework.Catalog
{
    /// <summary>Specific to Tingen.</summary>
    public class TingenPaths
    {
        public string Root { get; set; }
        public string Primeval { get; set; }

        public static TingenPaths Build(string tingenDataRoot)
        {
            return new TingenPaths
            {
                Root     = tingenDataRoot,
                Primeval = $@"{tingenDataRoot}\Primeval"
            };
        }

        public static List<string> Required(TingenPaths tingenPaths)
        {
            return new List<string>
            {
                tingenPaths.Root,
                tingenPaths.Primeval
            };
        }
    }
}

/*
Development notes
-----------------

*/
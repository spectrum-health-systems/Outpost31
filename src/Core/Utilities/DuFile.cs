// u241021.1131_code
// u241023_documentation

using System.IO;

namespace Outpost31.Core.Utilities
{
    /// <summary>Does things with files.</summary>
    public static class DuFile
    {
        /// <summary>Writes text to a file.</summary>
        public static void WriteLocal(string filePath, string fileContent)
        {
            File.WriteAllText(filePath, fileContent);
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

*/

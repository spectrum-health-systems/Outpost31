﻿// uXXXXXX.XXXX_code
// uXXXXXX.XXXX_documentation

using System.IO;

namespace Outpost31.Core.Utilities
{
    /// <summary>TBD</summary>
    public static class DuFile
    {
        /// <summary>TBD</summary>
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

_Documentation updated ------
*/

using System.IO;

namespace Outpost31.Core.Utilities
{
    public static class DuFile
    {
        public static void WriteLocal(string filePath, string fileContent)
        {
            File.WriteAllText(filePath, fileContent);
        }
    }
}

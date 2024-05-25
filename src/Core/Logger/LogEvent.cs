// u240525.1402

using System.IO;

namespace Outpost31.Core.Logger
{
    public static class LogEvent
    {
        /// <summary>Creates a trace log.</summary>
        /// <remarks>
        ///     - Trace logs are used to record major session events.
        /// </remarks>
        public static void Trace(string filePath, string fileContent)
        {
            Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Logger.LogEvent.Trace()]"); /* <- For development use only */

            File.WriteAllText(filePath, fileContent);
        }
    }
}

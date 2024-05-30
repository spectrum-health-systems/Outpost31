// u240530.1117

using System.IO;

namespace Outpost31.Core.Logger
{
    /// <summary>Provides logging functionality.</summary>
    public static class LogEvent
    {
        /// <summary>Creates a trace log.</summary>
        /// <remarks>
        ///  <para>
        ///    Trace logs are used to record major session events.
        ///  </para>
        /// </remarks>
        public static void Trace(string filePath, string fileContent)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Logger.LogEvent.Trace()]"); /* <- For development use only */

            File.WriteAllText(filePath, fileContent);
        }
    }
}
// u240603.1725

using System;

namespace Outpost31.Core.Logger
{
    /// <summary>Log catalog for the Outpost31.Core.Logger namespace.</summary>
    public static class Catalog
    {
        /// <summary></summary>
        /// <param name="assemblyName"></param>
        /// <param name="callPath"></param>
        /// <param name="callMember"></param>
        /// <param name="callLine"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string VerboseContent(string assemblyName, string callPath, string callMember, string callLine, string message)
        {
            return $"[ASSEMBLY NAME] {assemblyName}{Environment.NewLine}" +
                   $"    [CALL PATH] {callPath}{Environment.NewLine}" +
                   $"  [CALL MEMBER] {callMember}{Environment.NewLine}" +
                   $"  [LINE NUMBER] {callLine}{Environment.NewLine}" +
                   $"    [TIMESTAMP] {DateTime.Now:HHmmssfffffff}{Environment.NewLine}" +
                   Environment.NewLine +
                   $"{message}";
        }
    }
}

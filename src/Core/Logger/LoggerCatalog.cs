// u240617.1056

using System;

namespace Outpost31.Core.Logger
{
    /// <summary>Log catalog for the Outpost31.Core.Logger namespace.</summary>
    public static class LoggerCatalog
    {
        /// <summary>Soon.</summary>
        /// <param name="assemblyName"></param>
        /// <param name="callPath"></param>
        /// <param name="callMember"></param>
        /// <param name="callLine"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string StandardContent(string assemblyName, string calledClass, string calledMethod, string line, string message)
        {

            return $"[ASSEMBLY] {assemblyName}{Environment.NewLine}" +
                   $"   [CLASS] {calledClass}{Environment.NewLine}" +
                   $"  [METHOD] {calledMethod}(){Environment.NewLine}" +
                   $"    [LINE] {line}{Environment.NewLine}" +
                   Environment.NewLine +
                   $" [MESSAGE] {message}";
        }
    }
}

/*

-----------------
Development notes
-----------------

*/
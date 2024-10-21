// u240709.0000_code
// u241021_documentation

using System;

namespace Outpost31.Core.Logger
{
    /// <summary>Log catalog for the Outpost31.Core.Logger namespace.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Logger_doc.xml' path='Outpost31.Core.Logger/Cs[@name="LoggerCatalog"]/LoggerCatalog/*'/>
    public static class LoggerCatalog
    {
        /* [DN01] */
        /// <summary>Basic log information</summary>
        /// <param name="assemblyName">The executing assembly name.</param>
        /// <param name="callPath">The path of the calling class.</param>
        /// <param name="callMember">The path of the calling method</param>
        /// <param name="callLine">The line of code</param>
        /// <param name="message">The log message</param>
        /// <returns>The basic log content.</returns>
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
=================
DEVELOPMENT NOTES
=================

-----------------
[DN01] 241021
-----------------
These should standardized.

*/
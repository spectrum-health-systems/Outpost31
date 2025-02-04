// u241119.0834_code
// u241212_documentation

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;

namespace Outpost31.Module.OpenIncident
{
    /// <summary>TBD</summary>
    /// INCLUDE FILE
    public class ModuleOpenIncident
    {
        /// <summary>The executing Assembly name.</summary>
        /// <remarks>A required component for writing log files, defined here so it can be used throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>TBD</summary>
        public List<string> Whitelist { get; set; }

        /// <summary>TBD</summary>
        public List<string> Blacklist { get; set; }

        /// <summary>TBD</summary>
        public string OriginalFullName { get; set; }

        /// <summary>TBD</summary>
        public string CurrentFullName { get; set; }

        /// <summary>TBD</summary>
        public int PersonCompletingIncidentFormFieldId { get; set; }

        /// <summary>TBD</summary>
        public string FormOpenMessage { get; set; }

        /// <summary>TBD</summary>
        public string FormOpenErrorCode { get; set; }

        /// <summary>TBD</summary>
        public string FormSubmitMessage { get; set; }

        /// <summary>TBD</summary>
        public string FormSubmitErrorCode { get; set; }

        /// <summary>TBD</summary>
        public static ModuleOpenIncident BuildDefaultModOpenIncident(TraceLog traceInfo)
        {
            /* Can/should we put a log file here? */

            return new ModuleOpenIncident
            {
                Whitelist                           = new List<string>(),
                Blacklist                           = new List<string>(),
                OriginalFullName                    = string.Empty,
                CurrentFullName                     = string.Empty,
                PersonCompletingIncidentFormFieldId = 32,
                FormOpenMessage                     = "Since you are not the original author of this incident, you will only be able to view it and will not be able to submit modifications.",
                FormOpenErrorCode                   = "info",
                FormSubmitMessage                   = "Since you are not the original author of this incident, you cannot submit modifications to this incident.",
                FormSubmitErrorCode                 = "error"
            };
        }

        /// <summary>TBD</summary>
        public static ModuleOpenIncident Load(string modConfigFilePath, string currentSessionPath, OptionObject2015 workOptionObject, TraceLog traceInfo)
        {
            /* Can/should we put a log file here? */

            if (!File.Exists(modConfigFilePath))
            {
                /* Can/should we put a log file here? */

                Outpost31.Core.Utilities.DuJson.ExportToLocalFile<ModuleOpenIncident>(BuildDefaultModOpenIncident(traceInfo), modConfigFilePath);
            }

            return Outpost31.Core.Utilities.DuJson.ImportFromLocalFile<ModuleOpenIncident>(modConfigFilePath);
        }

        /// <summary>TBD</summary>
        public static string GetFullName(string filePath, string avatarName, TraceLog traceInfo)
        {
            /* Can/should we put a log file here? */

            var fullName = "";

            foreach (string entry in File.ReadLines($@"{filePath}\USERID_User Description.txt"))
            {
                /* Can/should we put a log file here? */

                if (entry.StartsWith(avatarName))
                {
                    /* Can/should we put a log file here? */

                    var entryComponent = entry.Split('^');

                    fullName = entryComponent[1];

                    break;
                }
            }

            return fullName;
        }

        /// <summary>TBD</summary>
        public static void GetAuthorInformation(TingenSession tnSession)
        {
            tnSession.ModOpenIncident.OriginalFullName = tnSession.AvData.SentOptionObject.GetFieldValue("32");

            tnSession.ModOpenIncident.CurrentFullName = GetFullName(tnSession.TnPath.SystemCode.FromAvatar, tnSession.AvData.SentOptionObject.OptionUserId, tnSession.TraceInfo);
        }
    }
}

/* DEVELOPMENT NOTES
 */
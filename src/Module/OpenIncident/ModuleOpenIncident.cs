// uXXXXXX.XXXX_code
// uXXXXXX.XXXX_documentation
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;

namespace Outpost31.Module.OpenIncident
{
    /// <summary>TBD</summary>
    public class ModuleOpenIncident
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

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
            /* Log file? */

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
            /* Log file? */

            if (!File.Exists(modConfigFilePath))
            {
                /* Log file? */

                Outpost31.Core.Utilities.DuJson.ExportToLocalFile<ModuleOpenIncident>(BuildDefaultModOpenIncident(traceInfo), modConfigFilePath);
            }

            return Outpost31.Core.Utilities.DuJson.ImportFromLocalFile<ModuleOpenIncident>(modConfigFilePath);
        }

        /// <summary>TBD</summary>
        public static string GetFullName(string filePath, string avatarName, TraceLog traceInfo)
        {
            /* Log file? */

            var fullName = "";

            foreach (string entry in File.ReadLines($@"{filePath}\USERID_User Description.txt"))
            {
                /* Log file? */

                if (entry.StartsWith(avatarName))
                {
                    /* Log file? */

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

/*
=================
DEVELOPMENT NOTES
=================

_Documentation updated ------
*/
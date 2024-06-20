// u240607.1046

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;

namespace Outpost31.Module.OpenIncident
{
    public class ModuleOpenIncident
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;
        public List<string> Whitelist { get; set; }
        public List<string> Blacklist { get; set; }
        public string OriginalFullName { get; set; }
        public string CurrentFullName { get; set; }
        public int PersonCompletingIncidentFormFieldId { get; set; }
        public string FormOpenMessage { get; set; }
        public string FormOpenErrorCode { get; set; }
        public string FormSubmitMessage { get; set; }
        public string FormSubmitErrorCode { get; set; }

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

        public static void GetAuthorInformation(TingenSession tnSession)
        {
            tnSession.ModOpenIncident.OriginalFullName = tnSession.AvData.SentOptionObject.GetFieldValue("32");

            tnSession.ModOpenIncident.CurrentFullName = GetFullName(tnSession.TnPath.SystemCode.FromAvatar, tnSession.AvData.SentOptionObject.OptionUserId, tnSession.TraceInfo);
        }
    }
}

/*

-----------------
Development notes
-----------------

*/

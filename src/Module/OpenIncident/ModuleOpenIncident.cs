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

        public static ModuleOpenIncident BuildDefaultModOpenIncident(TraceLog traceInfo)
        {
            //LogEvent.Trace(1, AssemblyName, traceInfo);

            return new ModuleOpenIncident
            {
                Whitelist                           = new List<string>(),
                Blacklist                           = new List<string>(),
                OriginalFullName                    = string.Empty,
                CurrentFullName                     = string.Empty,
                PersonCompletingIncidentFormFieldId = 32
            };
        }

        public static ModuleOpenIncident Load(string modConfigFilePath, string currentSessionPath, OptionObject2015 workOptionObject, TraceLog traceInfo)
        {
            //LogEvent.Trace(1, AssemblyName, traceInfo);

            if (!File.Exists(modConfigFilePath))
            {
                //LogEvent.Trace(2, AssemblyName, traceInfo);

                Outpost31.Core.Utilities.DuJson.ExportToLocalFile<ModuleOpenIncident>(BuildDefaultModOpenIncident(traceInfo), modConfigFilePath);
            }

            return Outpost31.Core.Utilities.DuJson.ImportFromLocalFile<ModuleOpenIncident>(modConfigFilePath);
        }


        public static string GetFullName(string filePath, string avatarName, TraceLog traceInfo)
        {
            LogEvent.Trace(1, AssemblyName, traceInfo);

            var fullName = "";

            foreach (string line in File.ReadLines($@"{filePath}\USERID_User Description.txt"))
            {
                /* don't put log here, slow */

                if (line.StartsWith(avatarName))
                {
                    var line2 = line.Split('^');

                    fullName = line2[1];

                    //return line2[1];

                    break;
                }
            }

            LogEvent.Primeval(Assembly.GetExecutingAssembly().GetName().Name, $"{fullName}");

            return fullName;
        }


        public static void GetAuthorInformation(TingenSession tnSession)
        {
            tnSession.ModOpenIncident.OriginalFullName = tnSession.AvData.SentOptionObject.GetFieldValue("32");

            tnSession.ModOpenIncident.CurrentFullName = GetFullName(tnSession.TnPath.SystemCode.FromAvatar, tnSession.AvData.SentOptionObject.OptionUserId, tnSession.TraceInfo);

            //var match = ImportedFile.GetFullName(tnSession.TnPath.SystemCode.FromAvatar, tnSession.AvData.SentOptionObject.OptionUserId, tnSession.ModOpenIncident.OriginalFullName, tnSession.TraceInfo);
        }
    }

}

/*

-----------------
Development notes
-----------------

*/

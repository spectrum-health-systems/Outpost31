using System.Collections.Generic;
using System.IO;
using ScriptLinkStandard.Objects;

namespace Outpost31.Module.OpenIncident
{
    public class ModuleOpenIncident
    {
        public List<string> Whitelist { get; set; }
        public List<string> Blacklist { get; set; }
        public int PersonCompletingIncidentFormFieldId { get; set; }

        public static ModuleOpenIncident BuildDefaultModOpenIncident()
        {
            return new ModuleOpenIncident
            {
                Whitelist                           = new List<string>(),
                Blacklist                           = new List<string>(),
                PersonCompletingIncidentFormFieldId = 32
            };
        }

        public static ModuleOpenIncident Load(string modConfigFilePath, string currentSessionPath, OptionObject2015 workOptionObjectObject)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            if (!File.Exists(modConfigFilePath))
            {
                Outpost31.Core.Utilities.DuJson.ExportToLocalFile<ModuleOpenIncident>(BuildDefaultModOpenIncident(), modConfigFilePath);
            }

            return Outpost31.Core.Utilities.DuJson.ImportFromLocalFile<ModuleOpenIncident>(modConfigFilePath);
        }

    }

}

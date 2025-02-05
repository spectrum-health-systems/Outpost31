﻿// u241021.1131_code
// u241023_documentation

using System.IO;
using System.Text.Json;

namespace Outpost31.Core.Utilities
{
    /// <summary>Provides JSON functionality.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Utilities_doc.xml' path='Outpost31.Core.Utilities/Cs[@name="DuJson"]/DuJSon/*'/>
    public static class DuJson
    {
        /// <summary>Export JSON data to an external file.</summary>
        /// <typeparam name="JsonObject">The JSON object type.</typeparam>
        /// <param name="jsonObject">The JSON object.</param>
        /// <param name="filePath">The export file path.</param>
        /// <param name="formatJson">Determines if the JSON data is formatted.</param>
        /// <include file='XmlDoc/Outpost31.Core.Utilities_doc.xml' path='Outpost31.Core.Utilities/Cs[@name="DuJson"]/ExportToLocalFile/*'/>
        public static void ExportToLocalFile<JsonObject>(JsonObject jsonObject, string filePath, bool formatJson = true)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

            JsonSerializerOptions jsonFormat = new JsonSerializerOptions();

            jsonFormat.WriteIndented = formatJson;

            string fileContent = JsonSerializer.Serialize(jsonObject, jsonFormat);

            File.WriteAllText(filePath, fileContent);
        }

        /// <summary>Convert a JSON object to a string[].</summary>
        /// <typeparam name="JsonObject">The JSON object type.</typeparam>
        /// <param name="jsonObject">The JSON object.</param>
        /// <returns>A JSON object as a string[].</returns>
        public static string ConvertToString<JsonObject>(JsonObject jsonObject)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

            return JsonSerializer.Serialize(jsonObject);
        }

        /// <summary>Import JSON data from an external file.</summary>
        /// <typeparam name="JsonObject">The JSON object type.</typeparam>
        /// <param name="filePath">The import file path.</param>
        /// <returns>The contents of the file as a JSON object.</returns>
        /// <include file='XmlDoc/Outpost31.Core.Utilities_doc.xml' path='Outpost31.Core.Utilities/Cs[@name="DuJson"]/ImportToLocalFile/*'/>
        public static JsonObject ImportFromLocalFile<JsonObject>(string filePath)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

            var configurationFileContents = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<JsonObject>(configurationFileContents);
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

*/
﻿// uXXXXXX.XXXX_code
// uXXXXXX.XXXX_documentation

using System.IO;
using System.Text.Json;

namespace Outpost31.Core.Utilities
{
    /// <summary>Provides JSON functionality.</summary>
    public static class DuJson
    {
        /// <summary>Export JSON data to an external file.</summary>
        /// <typeparam name="JsonObject">The JSON object type.</typeparam>
        /// <param name="jsonObject">The JSON object.</param>
        /// <param name="filePath">The export file path.</param>
        /// <param name="formatJson">Determines if the JSON data is formatted.</param>
        /// <remarks>
        ///  <para>
        ///   <example>
        ///    To call DuJson.ExportToLocalFile():
        ///    <code>
        ///     TheObject theObject = new TheObject();
        ///     DuJson.ExportToLocalFile&lt;TheObject&gt;(theObject, "/Path/To/Export/File");
        ///    </code>
        ///   </example>
        ///  </para>
        /// </remarks>
        public static void ExportToLocalFile<JsonObject>(JsonObject jsonObject, string filePath, bool formatJson = true)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

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
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            return JsonSerializer.Serialize(jsonObject);
        }

        /// <summary>Import JSON data from an external file.</summary>
        /// <typeparam name="JsonObject">The JSON object type.</typeparam>
        /// <param name="filePath">The import file path.</param>
        /// <remarks>
        ///  <para>
        ///   <example>
        ///    To call DuJson.ImportFromLocalFile():
        ///    <code>
        ///      TheObject theObject = DuJson.ImportFromLocalFile&lt;TheObject&gt;("/Path/To/Import/File");
        ///    </code>
        ///   </example>
        ///  </para>
        /// </remarks>
        /// <returns>The contents of the file as a JSON object.</returns>
        public static JsonObject ImportFromLocalFile<JsonObject>(string filePath)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            var configurationFileContents = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<JsonObject>(configurationFileContents);
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

- Change "configurationFileContents" to "fileContents"

_Documentation updated ------
*/
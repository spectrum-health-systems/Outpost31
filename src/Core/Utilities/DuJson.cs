// u240525.1402

using System.IO;
using System.Text.Json;

namespace Outpost31.Core.Utilities
{
    /// <summary>Provides JSON data export and import functionality.</summary>
    public static class DuJson
    {
        /// <summary>Export JSON data to an external file.</summary>
        /// <typeparam name="JsonObject">The JSON object type.</typeparam>
        /// <param name="jsonObject">The JSON object.</param>
        /// <param name="filePath">The export file path.</param>
        /// <param name="formatJson">Determines if the JSON data is formatted.</param>
        /// <example>
        ///     To call DuJson.ExportToLocalFile():
        ///     <code>
        ///         TheObject theObject = new TheObject();
        ///         DuJson.ExportToLocalFile<TheObject>(theObject, "/Path/To/Export/File");
        /// </code>
        /// </example>
        public static void ExportToLocalFile<JsonObject>(JsonObject jsonObject, string filePath, bool formatJson = true)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Utilities.DuJson.ExportToLocalFile()]"); /* <- For development use only */

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
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Utilities.DuJson.ConvertToString()]"); /* <- For development use only */

            return JsonSerializer.Serialize(jsonObject);
        }

        /// <summary>Import JSON data from an external file.</summary>
        /// <typeparam name="JsonObject">The JSON object type.</typeparam>
        /// <param name="filePath">The import file path.</param>
        /// <example>
        ///     To call DuJson.ImportFromLocalFile():
        ///     <code>
        ///         TheObject theObject = DuJson.ImportFromLocalFile<TheObject>("/Path/To/Import/File");
        ///     </code>
        /// </example>
        /// <returns>The contents of the file as a JSON object.</returns>
        public static JsonObject ImportFromLocalFile<JsonObject>(string filePath)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Utilities.DuJson.ImportFromLocalFile()]"); /* <- For development use only */

            var configurationFileContents = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<JsonObject>(configurationFileContents);
        }
    }
}

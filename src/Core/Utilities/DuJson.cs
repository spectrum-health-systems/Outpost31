﻿// u240530.1255

using System.IO;
using System.Reflection;
using System.Text.Json;
using Outpost31.Core.Logger;

namespace Outpost31.Core.Utilities
{
    /// <summary>Provides JSON functionality.</summary>
    public static class DuJson
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    The executing assembly is defined at the start of the class so it can be easily used throughout the class when creating
        ///    log files.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

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
            /* Since this method may be called prior to the creation of the TingenSession, we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName, "Exporting to local JSON-formatted file.");

            LogEvent.Primeval(AssemblyName, filePath);

            JsonSerializerOptions jsonFormat = new JsonSerializerOptions();

            jsonFormat.WriteIndented = formatJson;

            string fileContent = JsonSerializer.Serialize(jsonObject, jsonFormat);

            LogEvent.Primeval(AssemblyName, filePath);

            LogEvent.Primeval(AssemblyName, fileContent);

            //File.WriteAllText(@"C:\TingenData\UAT\Config\Tingen.config", "test");
            File.WriteAllText(filePath, fileContent);

            LogEvent.Primeval(AssemblyName, "&&&");
        }

        /// <summary>Convert a JSON object to a string[].</summary>
        /// <typeparam name="JsonObject">The JSON object type.</typeparam>
        /// <param name="jsonObject">The JSON object.</param>
        /// <returns>A JSON object as a string[].</returns>
        public static string ConvertToString<JsonObject>(JsonObject jsonObject)
        {
            /* Since this method may be called prior to the creation of the TingenSession, we'll use a Primeval log for debugging.
 */
            //LogEvent.Primeval(AssemblyName, "Converting local JSON-formatted file to a string.");

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
            /* Since this method may be called prior to the creation of the TingenSession, we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName, "Importing from local JSON-formatted file.");

            var configurationFileContents = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<JsonObject>(configurationFileContents);
        }
    }
}
// u240620.1359

using System.IO;
using System.Reflection;
using Outpost31.Core.Logger;

namespace Outpost31.Module.Common.Action
{
    /// <summary>Field operations.</summary>
    public static partial class Field
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Compare the values of two form field IDs to determine if they are the same.</summary>
        /// <param name="field01Value">The value of the first field.</param>
        /// <param name="field02Value">The value of the second field.</param>
        /// <remarks>
        ///  <example>
        ///   To call FieldOperation.Compare():
        ///   <code>
        ///    var value1 = tnSession.AvComponents.SentOptionObject.GetFieldValue("10001")
        ///    var value2 = tnSession.AvComponents.SentOptionObject.GetFieldValue("10002");
        ///    Outpost31.Module.Common.FieldOperation.SaveValue(value1, value1);
        ///   </code>
        ///  </example>
        /// </remarks>
        /// <returns>True (the fields values are the same) or false(the field values are different).</returns>
        public static bool CompareValue(string field01Value, string field02Value, TraceLog traceInfo)
        {
            LogEvent.Trace(1, AssemblyName, traceInfo);

            return field01Value == field02Value;
        }

        /// <summary>Locks a field so that it cannot be edited.</summary>
        /// <param name="fieldId">The field ID to be locked.</param>
        public static void Lock(string fieldId)
        {
            // TODO: Future functionality.
            /* Not sure what the best way to do this is.
             * Also, the "fieldId" may need to be an int.
             */
        }

        /// <summary>Saves the value of a field to a file.</summary>
        /// <param name="valueToSave">The value to save.</param>
        /// <param name="filePath">The file path.</param>
        /// <remarks>
        ///  <para>
        ///   <example>
        ///    To call FieldOperation.Compare():
        ///    <code>
        ///     var fieldValue = tnSession.AvComponents.SentOptionObject.GetFieldValue("10001")
        ///     var filePath = $@"{tnSession.TnFramework.TemporaryPath}\{currentAvatarUser}-%filename%.%extension%";
        ///     Outpost31.Module.Common.FieldOperation.SaveValue(originalAuthor, filePath);
        ///    </code>
        ///   </example>
        ///  </para>
        ///  <para>
        ///   To ensure that any sensitive data is removed at the end of a session, the filePath should adhere to the following standards:
        ///   <list type="bullet">
        ///    <item>The filename should always start with the <c>currentAvatarUser</c></item>
        ///    <item>The <c>filePath</c> should be in <c>tnSession.TnFramework.TemporaryPath</c></item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///   Since the <c>filePath</c> is user-definable, we will verify that the <c>filePath</c> doesn't exist before (re)creating it.
        ///  </para>
        /// </remarks>
        public static void SaveValue(string valueToSave, string filePath, TraceLog traceInfo)
        {
            LogEvent.Trace(1, AssemblyName, traceInfo);

            // TODO: Might want to encrypt this data.

            if (!File.Exists(filePath))
            {
                LogEvent.Trace(2, AssemblyName, traceInfo);

                File.Create(filePath);
            }

            File.WriteAllText(filePath, valueToSave);
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

_Documentation updated ------
*/
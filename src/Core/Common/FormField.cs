// u240530.0749

using System.IO;

namespace Outpost31.Module.Common
{
    /// <summary> Logic for operations that target form fields.</summary>
    public static class FieldOperation
    {
        /// <summary>Compares the values of two form field IDs to determine if they are the same.</summary>
        /// <param name="field01Value">The value of the first field.</param>
        /// <param name="field02Value">The value of the second field.</param>
        /// <remarks>
        ///     <example>
        ///         To call FieldOperation.Compare():
        ///         <code>
        ///             var value1 = tnSession.AvComponents.SentOptionObject.GetFieldValue("10001")
        ///             var value2 = tnSession.AvComponents.SentOptionObject.GetFieldValue("10002");
        ///
        ///             Outpost31.Module.Common.FieldOperation.SaveValue(value1, value1);
        ///         </code>
        ///     </example>
        /// </remarks>
        /// <returns>True (the fields values are the same) or false(the field values are different).</returns>
        public static bool Compare(string field01Value, string field02Value)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Common.FieldOperation.Compare()]"); /* <- For development use only */

            return field01Value == field02Value;
        }

        /// <summary>Saves the value of a field to a file.</summary>
        /// <param name="valueToSave">The value to save.</param>
        /// <param name="filePath">The file path.</param>
        /// <remarks>
        ///     <example>
        ///         To call FieldOperation.Compare():
        ///         <code>
        ///             var fieldValue = tnSession.AvComponents.SentOptionObject.GetFieldValue("10001")
        ///             var filePath = $@"{tnSession.TnFramework.TemporaryPath}\{currentAvatarUser}-%filename%.%extension%";
        ///
        ///             Outpost31.Module.Common.FieldOperation.SaveValue(originalAuthor, filePath);
        ///         </code>
        ///     </example>
        ///     <para>
        /// </para>
        ///         To ensure that any sensitive data is removed at the end of a session, the filePath should adhere to
        ///         the following standards:
        ///         <list type="bullet">
        ///             <item>The filename should always start with the <c>currentAvatarUser</c></item>
        ///             <item>The <c>filePath</c> should be in <c>tnSession.TnFramework.TemporaryPath</c></item>
        ///         </list>
        /// </remarks>
        public static void SaveValue(string valueToSave, string filePath)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Common.FieldOperation.SaveValue()]"); /* <- For development use only */

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            File.WriteAllText(filePath, valueToSave);
        }
    }
}
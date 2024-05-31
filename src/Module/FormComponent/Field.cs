// u240530.1503

using System.IO;

namespace Outpost31.Module.Common.Action
{
    /// <summary>Field operations.</summary>
    public static partial class Field
    {
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
        public static bool CompareValue(string field01Value, string field02Value)
        {
            Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.Common.FieldOperation.Compare()]"); /* <- For development use only */

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
        public static void SaveValue(string valueToSave, string filePath)
        {
            Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.Common.FieldOperation.SaveValue()]"); /* <- For development use only */

            // TODO: Might want to encrypt this data.

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            File.WriteAllText(filePath, valueToSave);
        }
    }
}
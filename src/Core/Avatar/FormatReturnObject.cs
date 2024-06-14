// u240614.1217

using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Formats the <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">returnOptionObject</see> so it can be returned to Avatar.</summary>
    /// <remarks>
    ///  <para>
    ///   There are two ways to format the <paramref name="returnOptionObject"/>
    ///   <list type="table">
    ///    <item>
    ///     <term>Using ScriptLinkStandard.Helpers</term>
    ///     <description>Easier, notconfigurable.</description>
    ///    </item>
    ///    <item>
    ///     <term>Using numerical error codes</term>
    ///     <description>More complex, but configurable.</description>
    ///    </item>
    ///   </list>
    ///  </para>
    /// </remarks>
    ///  <example>
    ///   To return a formatted returnOptionObject with an error message to Avatar using ScriptLinkStandard.Helpers:<br/>
    ///   <code>
    ///    Core.Avatar.FormatReturnObject.AsError(tnSession, "There was an error!.");
    ///   </code>
    ///   <br/>
    ///   To return a formatted returnOptionObject with an error message <i>without</i> using ScriptLinkStandard.Helpers:<br/>
    ///   <code>
    ///    Core.Avatar.FormatReturnObject.AsErrorCode(tnSession, errorCode, "There was an error!.");
    ///   </code>
    ///  </example>
    ///  <returns>A clone of the sentOptionObject, formatted for return to Avatar.</returns>
    public static class FormatReturnObject
    {
        /// <summary>Format an unmodified <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">OptionObject</see> for to Avatar.</summary>
        /// <param name="tnSession">The Tingen session object.</param>        
        /// <remarks>
        ///  <para>
        ///   - Since the <paramref name="SentOptionObject"/> is never modified, the <paramref name="ReturnOptionObject"/> is an exact copy of the original data.<br/>
        ///   - The user won't get a popup message, but the data will be returned to Avatar.<br/>
        ///   - This is the equivilant of returning "ErrorCode 0"<br/>
        ///  </para>
        /// </remarks>
        ///  <example>
        ///   To return an unmodified, formatted returnOptionObject:<br/>
        ///   <code>
        ///    Core.Avatar.FormatReturnObject.AsSentObjectClone(tnSession);
        ///   </code>
        ///  </example>
        public static void AsSentObjectClone(TingenSession tnSession)
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.SentOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.None, "");
        }

        /// <summary>Format an <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">OptionObject</see> for return to Avatar marked as a success.</summary>
        /// <param name="tnSession">The Tingen session object.</param>
        /// <remarks>
        ///  <para>
        ///   - The user won't get a popup message, but the data will be returned to Avatar.<br/>
        ///   - This is the equivilant of returning "ErrorCode 0"<br/>
        ///  </para>
        /// </remarks>
        ///  <example>
        ///   To return a formatted OptionObject marked as a success:<br/>
        ///   <code>
        ///    Core.Avatar.FormatReturnObject.AsNone(tnSession);
        ///   </code>
        ///  </example>

        public static void AsNone(TingenSession tnSession)
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.None, "");
        }

        /// <summary>Format a <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">OptionObject</see> for return to Avatar marked as an error.</summary>
        /// <param name="tnSession">The Tingen session object.</param>
        /// <remarks>
        ///  <para>
        ///   The user will get a popup message with the <paramref name="errorMessage"/> with the following options:
        ///   <list type="table">
        ///    <item>
        ///     <term>OK</term>
        ///     <description>The script will stop processing, and the user will be returned to the form</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///   - The user will not be able to submit the form until the error is resolved.<br/>
        ///   - No data is returned to Avatar.<br/>
        ///   - This is the equivilant of returning "ErrorCode 1"<br/>
        ///  </para>
        /// </remarks>
        ///  <example>
        ///   To return an formatted returnOptionObject marked as an error:<br/>
        ///   <code>
        ///    Core.Avatar.FormatReturnObject.AsError(tnSession, errorMessage);
        ///   </code>
        ///  </example>
        public static void AsError(TingenSession tnSession, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.Error, errorMessage);
        }

        /// <summary>Format a <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">OptionObject</see> for return to Avatar with a OK/Cancel choice.</summary>
        /// <param name="tnSession">The Tingen session object.</param>
        /// <remarks>
        ///  <para>
        ///   The user will get a popup message with the <paramref name="errorMessage"/> with the following options:
        ///   <list type="table">
        ///    <item>
        ///     <term>OK</term>
        ///     <description>Whatever the user was doing will continue.</description>
        ///    </item>
        ///    <item>
        ///     <term>Cancel</term>
        ///     <description>The script will stop processing, and whatever the user was doing will end.</description>
        ///    </item>    
        ///   </list>
        ///  </para>
        ///  <para>
        ///   - Clicking "OK" will ignore the warning, and data will be returned to Avatar.<br/>
        ///   - Clicking "Cancel" will stop the script from processing, and no data will be returned to Avatar.<br/>
        ///   - This is the equivilant of returning "ErrorCode 2"<br/>
        ///  </para>
        /// </remarks>
        ///  <example>
        ///   To return a formatted returnOptionObject with an OK/Cancel choice:<br/>
        ///   <code>
        ///    Core.Avatar.FormatReturnObject.AsOkCancel(tnSession, errorMessage);
        ///   </code>
        ///  </example>

        public static void AsOkCancel(TingenSession tnSession, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.OkCancel, errorMessage);
        }

        /// <summary>Format a <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">OptionObject</see> for return to Avatar marked as warning/information.</summary>
        /// <param name="tnSession">The Tingen session object.</param>        
        /// <remarks>
        ///  <para>
        ///   The user will get a popup message with the <paramref name="errorMessage"/> with the following options:
        ///   <list type="table">
        ///    <item>
        ///     <term>OK</term>
        ///     <description>Whatever the user was doing will continue.</description>
        ///    </item>
        ///    </list>
        ///  </para>
        ///  <para>
        ///   - Clicking "OK" will close the popup, and let the user continue what they were doing..<br/>
        ///   - This is the equivilant of returning "ErrorCode 3"<br/>
        ///  </para>
        /// </remarks>
        ///  <example>
        ///   To return a formatted returnOptionObject with an informational/warning message:<br/>
        ///   <code>
        ///    Core.Avatar.FormatReturnObject.AsInfo(tnSession, errorMessage);
        ///   </code>
        ///  </example>

        public static void AsInfo(TingenSession tnSession, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.Info, errorMessage);
        }

        /// <summary>Format a <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">OptionObject</see> for return to Avatar with a Yes/No choice.</summary>
        /// <param name="tnSession">The Tingen session object.</param>        /// <remarks>
        ///  <para>
        ///   The user will get a popup message with the <paramref name="errorMessage"/> with the following options:
        ///   <list type="table">
        ///    <item>
        ///     <term>Yes</term>
        ///     <description>Whatever the user was doing will continue.</description>
        ///    </item>
        ///    <item>
        ///     <term>No</term>
        ///     <description>The script will stop processing, and whatever the user was doing will end.</description>
        ///    </item>    
        ///   </list>
        ///  </para>
        ///  <para>
        ///   - Clicking "Yes" will close the popup and continue.<br/>
        ///   - Clicking "No" will close the popup and stop the script from processing.<br/>
        ///   - This is the equivilant of returning "ErrorCode 4"<br/>
        ///  </para>
        /// </remarks>
        ///  <example>
        ///   To return a formatted returnOptionObject with a Yes/No choice:<br/>
        ///   <code>
        ///    Core.Avatar.FormatReturnObject.AsYesNo(tnSession, errorMessage);
        ///   </code>
        ///  </example>

        public static void AsYesNo(TingenSession tnSession, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.YesNo, errorMessage);
        }

        /// <summary>Format a <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">OptionObject</see> to open an external URL.</summary>
        /// <param name="tnSession">The Tingen session object.</param>
        /// <remarks>
        ///  <para>
        ///   - This is the equivilant of returning "ErrorCode 5"<br/>
        ///  </para>
        /// </remarks>
        ///  <example>
        ///   To return a formatted returnOptionObject that opens a URL:<br/>
        ///   <code>
        ///    Core.Avatar.FormatReturnObject.AsOpenUrl(tnSession, errorMessage);
        ///   </code>
        ///  </example>
        public static void AsOpenUrl(TingenSession tnSession, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.OpenUrl, errorMessage);
        }

        /// <summary>Format a <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">OptionObject</see> with an OK/Cancel choice to open a form.</summary>
        /// <param name="tnSession">The Tingen session object.</param>
        /// <remarks>
        ///  <para>
        ///   The user will get a popup message with the <paramref name="errorMessage"/> with the following options:
        ///   <list type="table">
        ///    <item>
        ///     <term>OK</term>
        ///     <description>Open the form.</description>
        ///    </item>
        ///    <item>
        ///     <term>Cancel</term>
        ///     <description>Don't open the form.</description>
        ///    </item>    
        ///   </list>
        ///  </para>
        ///  <para>
        ///   - Can only be used on Form Load and Field events.<br/>
        ///   - This is the equivilant of returning "ErrorCode 6"<br/>
        ///  </para>
        /// </remarks>
        ///  <example>
        ///   To return a formatted returnOptionObject that gives a Yes/No choice to open a form:<br/>
        ///   <code>
        ///    Core.Avatar.FormatReturnObject.AsOpenForm(tnSession, errorMessage);
        ///   </code>
        ///  </example>
        public static void AsOpenForm(TingenSession tnSession, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.OpenForm, errorMessage);
        }

        /// <summary>Format a <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">OptionObject</see> to be returned to Avatar.</summary>
        /// <param name="tnSession">The Tingen session object.</param>
        /// <remarks>
        ///  <para>
        ///   The following are valid error codes:
        ///   <list type="table">
        ///    <item>
        ///     <term>0</term>
        ///     <description>Success - Returns the OptionObject without a message</description>
        ///    </item>
        ///    <item>
        ///     <term>1</term>
        ///     <description>Error - Stops the script from processing, user is required to fix the error</description>
        ///    </item>
        ///    <item>
        ///     <term>2</term>
        ///     <description>OK/Cancel</description>
        ///    </item>
        ///    <item>
        ///     <term>3</term>
        ///     <description>Info - Displays an informational/warning message</description>
        ///    </item>
        ///    <item>
        ///     <term>4</term>
        ///     <description>Yes/No</description>
        ///    </item>
        ///    <item>
        ///     <term>5</term>
        ///     <description>OpenURL - Opens an URL in a browser</description>
        ///    </item>
        ///    <item>
        ///     <term>6</term>
        ///     <description>OpenForm - Presents an OK/Cancel dialog to open a form (only be used on Form Load and Field events).</description>
        ///    </item>   
        ///   </list>
        ///  </para>
        /// </remarks>
        ///  <example>
        ///   To return a formatted returnOptionObject:<br/>
        ///   <code>
        ///    Core.Avatar.FormatReturnObject.AsErrorCode(tnSession, errorCode, errorMessage);
        ///   </code>
        ///  </example>

        public static void AsErrorCode(TingenSession tnSession, int errorCode, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(errorCode, errorMessage);
        }
    }
}

/*

-----------------
Development notes
-----------------

- Move clone logic somewhere common, since each of these methods does the same thing.
- Consider just using AsErrorCode() ?
- Verify all documentation tables and examples are correct.
- Verify trace logs cannot be used here.
- Limit what is passed to these methods (not the entire session object).

*/
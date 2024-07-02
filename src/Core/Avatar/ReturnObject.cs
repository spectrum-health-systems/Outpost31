// u240624.0843_code
// u240702.1515_documentation

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core.Avatar
{
    /// <summary>Finalizes an OptionObject so it can be returned to AvatarNX.</summary>
    /// <remarks>
    ///     <para>
    ///         <b>About this class</b><br/>
    ///         Before returning an OptionObject to AvatarNX, it must be finalized. That's what this class does. It finalizes the <br/>
    ///         OptionObject so it can be returned to AvatarNX.
    ///     </para>
    ///     <para>
    ///         <b>More information</b><br/>
    ///         <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">OptionObjects</a><br/>
    ///     </para>
    ///     <para>
    ///         <b>Also...</b><br/>
    ///         Please see the <a href="https://github.com/spectrum-health-systems/Tingen-Documentation">Tingen documentation</a> for more information.
    ///     </para>
    /// </remarks>
    public static class ReturnObject
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///     <b>About this property</b><br/>
        ///     The assembly name is defined here so it can be used to write log files throughout the class.
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Finalize an <paramref name="OptionObject"/> to be returned to AvatarNX.</summary>
        /// <param name="sentOptionObject">The OptionObject sent from AvatarNX.</param>
        /// <param name="sentScriptParameter">The ScriptParameter sent from AvatarNX.</param>
        /// <remarks>
        ///     <para>
        ///         <b>About this method</b><br/>
        ///         The finalization process is a two part process:
        ///         <list type="number">
        ///             <item>
        ///                 <term>Assign an error code to the returnOptionObject</term>
        ///             </item>
        ///             <item>
        ///                 <term>Verify the returnOptionObject cointains all required data</term>
        ///             </item>
        ///         </list>
        ///         And here is the list of valid error codes:
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Error code</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>0</term>
        ///                 <description>Success - Returns the OptionObject without a message</description>
        ///             </item>
        ///             <item>
        ///                 <term>1</term>
        ///                 <description> Error - Stops the script from processing and displays an message with an "OK" button</description>
        ///             </item>
        ///             <item>
        ///                 <term>2</term>
        ///                 <description>OKCancel - Displays a message with "OK" and "Cancel" buttons.</description>
        ///             </item>
        ///             <item>
        ///                 <term>3</term>
        ///                 <description>Info - Displays an informational warning message with an "OK" button.</description>
        ///             </item>
        ///             <item>
        ///                 <term>4</term>
        ///                 <description>YesNo - Displays a message with "Yes" and "No" buttons.</description>
        ///             </item>
        ///             <item>
        ///                 <term>5</term>
        ///                 <description>OpenURL - Opens an URL in a browser</description>
        ///             </item>
        ///             <item>
        ///                 <term>6</term>
        ///                 <description>OpenForm - Presents an OK/Cancel dialog to open a form (only be used on Form Load and Field events).</description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <example>
        ///         To return a formatted returnOptionObject:<br/>
        ///         <code>
        ///             Core.Avatar.FormatReturnObject.AsErrorCode(tnSession, errorCode, errorMessage);
        ///         </code>
        ///     </example>
        ///     <para>
        ///         <b>More information</b><br/>
        ///         <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">OptionObjects</a><br/>
        ///     </para>
        /// </remarks>
        /// <returns>The necessary AvatarNX data.</returns>
        public static void Finalize(TingenSession tnSession, string errorCode, string errorMessage = "")
        {
            // TODO: split this into two methods: AssignErrorCode() and Finalize()

            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();

            switch (errorCode.ToLower())
            {
                case "clone":
                case "none":
                case "success":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(0, errorMessage);
                    break;

                case "error":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(1, errorMessage);
                    break;

                case "okcancel":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(2, errorMessage);
                    break;

                case "info":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(3, errorMessage);
                    break;

                case "yesno":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(4, errorMessage);
                    break;

                case "openurl":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(5, errorMessage);
                    break;

                case "openform":
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(6, errorMessage);
                    break;

                default:
                    LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                    // TODO: Graceful error handling.
                    break;
            }
        }
    }
}


/// <summary>Finalizes an OptionObject so it can be returned to AvatarNX.</summary>
/// <remarks>
///     <para>
///         <b>About this class</b><br/>
///         Before returning an OptionObject to AvatarNX, it must be finalized.<br/><br/>
///         The finalization process is a two part process:
///         <list type="number">
///             <item>
///                 <term>Assign an error code</term>
///                 <description>An error code is assigned to the OptionObject.</description>
///             </item>
///             <item>
///                 <term>Format</term>
///                 <description>Tthe OptionObject is formatted properly.</description>
///             </item>
///         </list>
///         This class assigns the error code to the OptionObject.
///         The
///     </para>
///     <para>
///         <b>More information</b><br/>
///         <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">OptionObjects</a><br/>
///     </para>
///     <para>
///         <b>Also...</b><br/>
///         Please see the <a href="https://github.com/spectrum-health-systems/Tingen-Documentation">Tingen documentation</a> for more information.
///     </para>
/// </remarks>
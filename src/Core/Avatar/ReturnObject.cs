// u240620.1129

using System.Diagnostics;
using Outpost31.Core.Logger;
using System.Reflection;
using Outpost31.Core.Session;
using Outpost31.Module.OpenIncident;

namespace Outpost31.Core.Avatar
{
    /// <summary>Logic specific to the <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">returnOptionObject</see>.</summary>
    /// <remarks>
    ///  <para>
    ///  </para>
    /// </remarks>
    public static class ReturnObject
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Format an <paramref name="OptionObject"/> to be returned to Avatar.</summary>
        /// <param name="tnSession">The Tingen session object.</param>
        /// <remarks>
        ///  <para>
        ///   - The returnOptionObject must be propery formatted when returned to Avatar.
        ///  </para>
        ///  <para>
        ///   Part of the finalization process is assigning a valid error code to the returnOptionObject:
        ///   <list type="table">
        ///    <item>
        ///     <term>0</term>
        ///     <description>Success - Returns the OptionObject without a message</description>
        ///    </item>
        ///    <item>
        ///     <term>1</term>
        ///     <description> Error - Stops the script from processing and displays an message with an "OK" button</description>
        ///    </item>
        ///    <item>
        ///     <term>2</term>
        ///     <description>OKCancel - Displays a message with "OK" and "Cancel" buttons.</description>
        ///    </item>
        ///    <item>
        ///     <term>3</term>
        ///     <description>Info - Displays an informational warning message with an "OK" button.</description>
        ///    </item>
        ///    <item>
        ///     <term>4</term>
        ///     <description>YesNo - Displays a message with "Yes" and "No" buttons.</description>
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
        ///  <para>
        ///   - <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">SentOptionObject</see>
        ///  </para>
        /// </remarks>
        ///  <example>
        ///   To return a formatted returnOptionObject:<br/>
        ///   <code>
        ///    Core.Avatar.FormatReturnObject.AsErrorCode(tnSession, errorCode, errorMessage);
        ///   </code>
        ///  </example>
        public static void Finalize(TingenSession tnSession, string errorCode, string errorMessage = "")
        {
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
                    // TODO: If the errorCode is not recognized, default to an error.
                    break;
            }
        }
    }
}

/*

=================
DEVELOPMENT NOTES
=================

- Verify there are no issues with a Trace Log being generated.
- Limit what is passed to these methods (not the entire session object).

*/
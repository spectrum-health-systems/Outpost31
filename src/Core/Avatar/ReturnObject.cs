// u240709.0000_code
// u240709.0000_documentation

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core.Avatar
{
    /// <summary>Finalizes an OptionObject so it can be returned to AvatarNX.</summary>
    /// <include file='XMLDoc/Outpost31.Core.Avatar_doc.xml' path='Doc/Sec[@name="returnobject"]/ReturnObject/*'/>
    public static class ReturnObject
    {
        /// <summary>Assembly name for logging purposes.</summary>
        /// <include file='XMLDoc/Outpost31_doc.xml' path='Doc/Sec[@name="outpost31"]/AssemblyName/*'/>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Finalize an OptionObject so it can be returned to Avatar.</summary>
        /// <param name="tnSession">The Tingen session object.</param>
        /// <param name="errorCode">The OptionObject error code.</param>
        /// <param name="errorMessage">The OptionObject error message.</param>
        /// <include file='XMLDoc/Outpost31.Core.Avatar_doc.xml' path='Doc/Sec[@name="returnobject"]/Finalize/*'/>
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
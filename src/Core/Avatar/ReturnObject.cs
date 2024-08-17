// u240817.1814_code
// u240817.1814_documentation

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core.Avatar
{
    /// <summary>Finalizes an OptionObject so it can be returned to AvatarNX.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Avatar_doc.xml' path='Outpost31/Cs[@name="ReturnObject"]/ReturnObject/*'/>
    public static class ReturnObject
    {
        /// <summary>Assembly name for logging purposes.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Term[@name="Term"]/AssemblyName/*'/>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Finalize an OptionObject so it can be returned to Avatar.</summary>
        /// <param name="tnSession">The <see cref="TingenSession"/> object.</param>
        /// <param name="errorCode">The OptionObject <see href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Static/OptionObject-error-codes.md">error code</see>.</param>
        /// <param name="errorMessage">The OptionObject error message .</param>
        /// <include file='XmlDoc/Outpost31.Core.Avatar_doc.xml' path='Outpost31/Cs[@name="ReturnObject"]/Finalize/*'/>
        public static void Finalize(TingenSession tnSession, string errorCode, string errorMessage = "")
        {
            /* [DN01] */

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

/*
=================
DEVELOPMENT NOTES
=================

-----------------
[DN01] 240817
-----------------
Maybe split this into two methods: AssignErrorCode() and Finalize()?


*/
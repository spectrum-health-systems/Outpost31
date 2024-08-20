// u240820.1131_code
// u240820.1131_documentation

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core.Avatar
{
    /// <summary>Logic for the ReturnOptionObject data structure.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Avatar_doc.xml' path='Outpost31/Cs[@name="ReturnObject"]/ReturnObject/*'/>
    public static class ReturnObject
    {
        /// <summary>Assembly name for logging purposes.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Type[@name="Property"]/AssemblyName/*'/>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Finalize an OptionObject so it can be returned to Avatar.</summary>
        /// <param name="tnSession">The Tingen Session data structure object.</param>
        /// <param name="errorString">The OptionObject error string.</param>
        /// <param name="errorMessage">The OptionObject error message .</param>
        /// <include file='XmlDoc/Outpost31.Core.Avatar_doc.xml' path='Outpost31/Cs[@name="ReturnObject"]/Finalize/*'/>
        public static void Finalize(TingenSession tnSession, string errorString, string errorMessage = "")
        {
            /* [DN01] */

            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();

            switch (errorString.ToLower())
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
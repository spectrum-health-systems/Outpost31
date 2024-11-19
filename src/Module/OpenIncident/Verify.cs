// uXXXXXX.XXXX_code
// uXXXXXX.XXXX_documentation

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Module.OpenIncident
{
    /// <summary>VerifyAuthor command.</summary>
    public static partial class Verify
    {
        /// <summary>The executing Assembly name.</summary>
        /// <remarks>A required component for writing log files, defined here so it can be used throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>TBD</summary>
        public static void OriginalAuthorIsOpening(TingenSession tnSession)
        {
            LogEvent.Trace(1, ExeAsm, tnSession.TraceInfo);

            ModuleOpenIncident.GetAuthorInformation(tnSession);

            if (tnSession.ModOpenIncident.OriginalFullName != tnSession.ModOpenIncident.CurrentFullName)
            {
                LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);
                Core.Avatar.ReturnObject.Finalize(tnSession, tnSession.ModOpenIncident.FormOpenErrorCode, tnSession.ModOpenIncident.FormOpenMessage);
            }
            else
            {
                LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);
                Core.Avatar.ReturnObject.Finalize(tnSession, "none");
            }
        }

        /// <summary>Verify the Avatar user is the same as the original author.</summary>
        /// <param name="tnSession"></param>
        public static void OriginalAuthorIsSubmitting(TingenSession tnSession)
        {
            LogEvent.Trace(1, ExeAsm, tnSession.TraceInfo);

            ModuleOpenIncident.GetAuthorInformation(tnSession);

            if (tnSession.ModOpenIncident.OriginalFullName != tnSession.ModOpenIncident.CurrentFullName)
            {
                LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);
                Core.Avatar.ReturnObject.Finalize(tnSession, tnSession.ModOpenIncident.FormSubmitErrorCode, tnSession.ModOpenIncident.FormSubmitMessage);
            }
            else
            {
                LogEvent.Trace(2, ExeAsm, tnSession.TraceInfo);
                Core.Avatar.ReturnObject.Finalize(tnSession, "none");
            }
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

*/
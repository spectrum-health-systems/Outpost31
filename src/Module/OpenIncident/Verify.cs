// u240617.1146

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Module.OpenIncident
{
    /// <summary>VerifyAuthor command.</summary>
    public static partial class Verify
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        public static void OriginalAuthorIsOpening(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            ModuleOpenIncident.GetAuthorInformation(tnSession);

            if (tnSession.ModOpenIncident.OriginalFullName != tnSession.ModOpenIncident.CurrentFullName)
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                Core.Avatar.ReturnObject.Finalize(tnSession, tnSession.ModOpenIncident.FormOpenErrorCode, tnSession.ModOpenIncident.FormOpenMessage);
            }
            else
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                Core.Avatar.ReturnObject.Finalize(tnSession, "none");
            }
        }

        /// <summary>Verify the Avatar user is the same as the original author.</summary>
        /// <param name="tnSession"></param>
        public static void OriginalAuthorIsSubmitting(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            ModuleOpenIncident.GetAuthorInformation(tnSession);

            if (tnSession.ModOpenIncident.OriginalFullName != tnSession.ModOpenIncident.CurrentFullName)
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                Core.Avatar.ReturnObject.Finalize(tnSession, tnSession.ModOpenIncident.FormSubmitErrorCode, tnSession.ModOpenIncident.FormSubmitMessage);
            }
            else
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                Core.Avatar.ReturnObject.Finalize(tnSession, "none");
            }
        }
    }
}

/*

-----------------
Development notes
-----------------

*/
// u240607.1049

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

        //public static void GetAuthorInformation(TingenSession tnSession)
        //{
        //    tnSession.ModOpenIncident.OriginalFullName = tnSession.AvData.SentOptionObject.GetFieldValue("32");

        //    tnSession.ModOpenIncident.CurrentFullName = ImportedFile.GetFullName(tnSession.TnPath.SystemCode.FromAvatar, tnSession.AvData.SentOptionObject.OptionUserId, tnSession.TraceInfo);

        //        //var match = ImportedFile.GetFullName(tnSession.TnPath.SystemCode.FromAvatar, tnSession.AvData.SentOptionObject.OptionUserId, tnSession.ModOpenIncident.OriginalFullName, tnSession.TraceInfo);
        //}

        /// <summary>Verify the Avatar user is the same as the original author.</summary>
        /// <param name="tnSession"></param>
        public static void OriginalAuthorIsSubmitting(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            ModuleOpenIncident.GetAuthorInformation(tnSession);

            if (tnSession.ModOpenIncident.OriginalFullName != tnSession.ModOpenIncident.CurrentFullName)
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                Core.Avatar.OptionObjects.ReturnError(tnSession, "Not the original author.");
            }
            else
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                Core.Avatar.OptionObjects.ReturnSuccess(tnSession);
            }
        }

        public static void OriginalAuthorIsOpening(TingenSession tnSession)
        {
            LogEvent.Trace(1, AssemblyName, tnSession.TraceInfo);

            //var originalAuthor = tnSession.AvData.SentOptionObject.GetFieldValue("32");

            //var fullAuthor = ImportedFile.GetFullName(tnSession.TnPath.SystemCode.FromAvatar, tnSession.AvData.SentOptionObject.OptionUserId, originalAuthor, tnSession.TraceInfo);

            ModuleOpenIncident.GetAuthorInformation(tnSession);

            if (tnSession.ModOpenIncident.OriginalFullName != tnSession.ModOpenIncident.CurrentFullName)
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                Core.Avatar.OptionObjects.ReturnInfo(tnSession, "Since you are not the original author, you will only be able to view this.");
            }
            else
            {
                LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
                Core.Avatar.OptionObjects.ReturnSuccess(tnSession);
            }
        }
    }
}

/*

-----------------
Development notes
-----------------

*/
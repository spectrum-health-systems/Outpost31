// u240604.1511

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core.Avatar
{
    /// <summary>Logic for OptionObjects.</summary>
    public static class OptionObjects
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Executing assembly is defined here so it can be used when creating log files.
        ///   </para>
        /// </remarks>
        public static string Asm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Clone the SentOptionObject to the ReturnOptionObject.</summary>
        /// <remarks>
        ///  <para>
        ///   - No changes are made to the data.
        ///  </para>
        /// </remarks>
        public static void CloneSentToReturn(TingenSession tnSession)
        {
            LogEvent.Trace(1, tnSession.TraceLogs, Asm);

            tnSession.AvatarData.ReturnObject = tnSession.AvatarData.SentObject.Clone();
        }
    }
}

/*

Development notes

*/
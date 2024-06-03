// u240603.1742

using System.Reflection;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;

namespace Outpost31.Core.Avatar
{
    public static class TheOptionObject
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    The executing assembly is defined at the start of the class so it can be easily used throughout the class when creating
        ///    log files.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Clones the SentOptionObject to the ReturnOptionObject (so, no work).</summary>
        public static void ReturnClonedSent(TingenSession tnSession)
        {
            LogEvent.Trace(tnSession, AssemblyName);

            tnSession.AvData.ReturnOptionObject = tnSession.AvData.SentOptionObject.Clone();
        }

        /// <summary>No work is done.</summary>
        /// <param name="tnSession"></param>
        public static void NoWork(TingenSession tnSession)
        {
            LogEvent.Trace(tnSession, AssemblyName);

            // TODO

            //tnSession.AvData.ReturnOptionObject = tnSession.AvData.SentOptionObject.ToReturnOptionObject();

        }

        /// <summary>Error1</summary>
        /// <param name="tnSession"></param>
        /// <param name="errorMessage"></param>
        public static void Error1(TingenSession tnSession, string errorMessage)
        {
            LogEvent.Trace(tnSession, AssemblyName);

            // TODO

            //tnSession.AvData.ReturnOptionObject = tnSession.AvData.SentOptionObject.ToReturnOptionObject(1, errorMessage);
        }
    }
}

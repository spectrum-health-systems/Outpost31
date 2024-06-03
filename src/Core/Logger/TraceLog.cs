// u240603.1706

using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Outpost31.Core.Logger
{
    public partial class TraceLog
    {
        /// <summary>Build the trace log information.</summary>
        /// <param name="mode"></param>
        /// <param name="delay"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static TraceLog BuildInfo(int mode, int delay, string path)
        {
            return new TraceLog
            {
                TraceLogMode       = mode,
                TraceLogDelay      = delay,
                CurrentSessionPath = path
            };
        }

        public static void Create(TraceLog traceInfo, string assemblyName, string fileContent = "Trace log.", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            /* Can't put a trace log here, so we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName, "Creating a trace log.");

            var calledClass = callPath.Split('\\').Last();

            switch (traceInfo.TraceLogMode)
            {
                case 1:
                    /* Can't put a trace log here, so we'll use a Primeval log for debugging.
                     */
                    //LogEvent.Primeval(AssemblyName);
                    Thread.Sleep(traceInfo.TraceLogDelay);
                    SimpleTrace(assemblyName, traceInfo.CurrentSessionPath, calledClass, callMember, callLine);
                    break;

                case 2:
                    /* Can't put a trace log here, so we'll use a Primeval log for debugging.
                     */
                    //LogEvent.Primeval(AssemblyName);
                    Thread.Sleep(traceInfo.TraceLogDelay);
                    StandardTrace();
                    break;

                case 3:
                    /* Can't put a trace log here, so we'll use a Primeval log for debugging.
                     */
                    //LogEvent.Primeval(AssemblyName);
                    Thread.Sleep(traceInfo.TraceLogDelay);
                    VerboseTrace();
                    break;

                case 0:
                default:
                    /* Can't put a trace log here, so we'll use a Primeval log for debugging.
                     */
                    //LogEvent.Primeval(AssemblyName);
                    // gracefully exit
                    break;
            }
        }


        private static void SimpleTrace(string assemblyName, string sessionPath, string calledClass, string calledMethod, int calledLine)
        {
            /* Can't put a trace log here, so we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName);

            var filePath = $@"{sessionPath}\{calledClass}-{calledMethod}-{calledLine}.trace";

            File.WriteAllText(filePath, "");
        }

        private static void StandardTrace()
        {
            // TODO
        }

        private static void VerboseTrace()
        {
            // TODO
        }

    }
}

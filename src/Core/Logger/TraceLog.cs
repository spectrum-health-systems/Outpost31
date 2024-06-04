// u240603.1706

using System;
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
        public static TraceLog BuildInfo(string path, int mode, int delay)
        {
            return new TraceLog
            {
                TraceLogPath  = $@"{path}\Tracelog",
                TraceLogLevel = mode,
                TraceLogDelay = delay
            };
        }

        public static void Create(int traceLevel, TraceLog traceInfo, string assemblyName, [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            //* For debugging */
            //LogEvent.Primeval(Asm);

            var calledClass = callPath.Split('\\').Last();

            if (traceLevel <= traceInfo.TraceLogLevel)
            {
                Thread.Sleep(traceInfo.TraceLogDelay);
                SimpleTrace(assemblyName, traceInfo.TraceLogPath, calledClass, callMember, callLine);
            }
        }

        public static void SimpleTrace(string assemblyName, string sessionPath, string calledClass, string calledMethod, int calledLine)
        {
            //* For debugging */
            //LogEvent.Primeval(Asm);

            var filePath = $@"{sessionPath}\{DateTime.Now:fffffff}-{calledClass}-{calledLine}.trace";

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

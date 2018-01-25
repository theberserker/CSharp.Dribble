using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CSharp.Dribble.Exam70483.Diagnostics
{
    public class Tracing
    {
        public static void DoTrace()
        {
            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            traceSource.TraceInformation("Tracingapplication..");
            traceSource.TraceEvent(TraceEventType.Critical, 0,"Criticaltrace");
            traceSource.TraceData(TraceEventType.Information, 1,
            new object[] { "a", "b", "c" });
            traceSource.Flush();
            traceSource.Close();
            // Outputs:
            // myTraceSource Information: 0 : Tracing application..
            // myTraceSource Critical: 0 : Critical trace
            // myTraceSource Information: 1 : a, b, c
        }

        public static void ConfigureTextWriteTraceListener()
        {
            Stream outputFile = File.Create("tracefile.txt");
            //TextWriterTraceListener textListener = new TextWriterTraceListener(outputFile); // .NET CORE?
            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            traceSource.Listeners.Clear();
            //traceSource.Listeners.Add(textListener);
            traceSource.TraceInformation("Traceoutput");
            traceSource.Flush();
            traceSource.Close();
        }
    }
}

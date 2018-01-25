using System;
using System.Diagnostics;
using System.Linq;

namespace CSharp.Dribble.Exam70483.Diagnostics
{
    public class PerfCounters
    {
        public static void DoSample()
        {
            if (CreatePerformanceCounters())
            {
                Console.WriteLine("Createdperformancecounters");
                Console.WriteLine("Pleaserestartapplication");
                Console.ReadKey();
                return;
            }
            var totalOperationsCounter = new PerformanceCounter("MyCategory", "# operations executed", "", false);
            var operationsPerSecondCounter = new PerformanceCounter("MyCategory", "# operations / sec", "", false);
            totalOperationsCounter.Increment();
            operationsPerSecondCounter.Increment();
        }
        private static bool CreatePerformanceCounters()
        {
            if (!PerformanceCounterCategory.Exists("MyCategory"))
            {
                CounterCreationDataCollection counters = new CounterCreationDataCollection
                {
                    new CounterCreationData("# operations executed", "Totalnumberofoperationsexecuted", PerformanceCounterType.NumberOfItems32),
                    new CounterCreationData("# operations / sec", "Numberofoperationsexecutedpersecond", PerformanceCounterType.RateOfCountsPerSecond32)
                };

                // HA! Depricated...
                PerformanceCounterCategory.Create("MyCategory", "SamplecategoryforCodeproject", counters);
            }

            return true;

        }
    }
}
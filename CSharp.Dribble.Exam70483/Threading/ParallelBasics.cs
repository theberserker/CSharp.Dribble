using System;
using System.Threading.Tasks;

namespace CSharp.Dribble.Exam70483.Threading
{
    public static class ParallelBasics
    {

        /// <summary>
        /// You can cancel the loop by using the ParallelLoopState object. You have two options to do this Break or Stop.
        /// Break ensures that all iterations that are currently running will be finished.
        /// Stop just terminates everything.
        /// 
        /// When breaking the parallel loop, the result variable has an IsCompleted value of false and a
        /// LowestBreakIteration of 500. When you use the Stop method, the LowestBreakIteration is null.
        /// </summary>
        public static void TerminatingAParallel()
        {
            ParallelLoopResult result = Parallel.
                For(0, 1000, (int i, ParallelLoopState loopState) =>
                {
                    if (i == 500)
                    {
                        Console.WriteLine("Breaking loop");
                        loopState.Break();
                    }
                    return;
                });

            var r = result;
        }
    }
}

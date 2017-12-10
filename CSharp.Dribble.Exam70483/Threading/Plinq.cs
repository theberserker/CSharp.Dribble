using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Dribble.Exam70483.Threading
{
    public static class Plinq
    {
        public static void ParallelOrdered()
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers
                .AsParallel()
                .AsOrdered()
                .Where(i => i % 2 == 0)
                .ToArray();

            foreach (int i in parallelResult)
                Console.WriteLine(i);
        }

        /// <summary>
        /// Shows how you can use the AsSequential operator to make sure that the Take method doesn't mess up your order
        /// </summary>
        public static void ParallelOrderedSequential()
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers
                .AsParallel()
                .AsOrdered()
                .Where(i => i % 2 == 0)
                .AsSequential(); // This converts it from ParallelQuery<TSource> to IEnumerable<TSource>

            foreach (int i in parallelResult.Take(5))
                Console.WriteLine(i);
        }

        /// <summary>
        /// Shows how exceptions in PLINQ executions are wrapped in the AggregateException.
        /// 
        /// Displays:
        /// 4
        /// 6
        /// 8
        /// 2
        /// 12
        /// 14
        /// 16
        /// 18
        /// There where 2 exceptions
        /// </summary>
        public static void HowExceptionsAreHandled()
        {
            var numbers = Enumerable.Range(0, 20);
            try
            {
                var parallelResult = numbers.AsParallel()
                .Where(i => IsEven(i));
                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count);
            }
        }
        public static bool IsEven(int i)
        {
            if (i % 10 == 0) throw new ArgumentException("i");
            return i % 2 == 0;
        }
    }
}

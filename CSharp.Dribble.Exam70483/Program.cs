using CSharp.Dribble.Exam70483.Threading;
using System;
using System.Threading;

namespace CSharp.Dribble.Exam70483
{
    public static class Program
    {
        public static void Main()
        {
            //ThreadBasics2.MainMethod();
            //TaskBasics2.WaitAny();
            ParallelBasics.TerminatingAParallel();
            Console.ReadKey();
        }
    }
}
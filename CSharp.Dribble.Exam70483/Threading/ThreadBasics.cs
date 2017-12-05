using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSharp.Dribble.Exam70483.Threading
{
    public static class ThreadBasics1
    {
        private static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc:{ 0}", i);
                Thread.Sleep(0);
            }
        }

        public static void MainMethod()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5);
            t.Join();
        }
    }


    /// <summary>
    /// If you want to use local data in a thread and initialize it for each thread, you can use the ThreadLocal<T> class
    /// </summary>
    public static class ThreadBasics2
    {
        // This is going to be local for each thread.
        public static ThreadLocal<int> _field = new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);

        public static void MainMethod()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("ThreadA: {0}", x);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("ThreadB: {0}", x);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
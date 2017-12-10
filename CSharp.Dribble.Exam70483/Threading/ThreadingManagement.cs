using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Dribble.Exam70483.Threading
{
    public class ThreadingManagement
    {

        /// <summary>
        /// ... deadlock, wwhere both threads wait on each other, causing neither to ever complete.Listing 1-37 shows an example of a deadlock.
        /// 
        /// ... AS: This actually doesn't cause a deadlock. Figure out what poet has missed.
        /// </summary>
        public static void DeadlockSample_Book()
        {
            object lockA = new object();
            object lockB = new object();
            var up = Task.Run(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock (lockB)
                    {
                        Console.WriteLine("LockedAandB");
                    }
                }
            });
            lock (lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("LockedBandA");
                }
            }
            up.Wait();
        }

        /// <summary>
        /// My take on fixing the <see cref="DeadlockSample_Book"/>
        /// </summary>
        public static void DeadlockSample_My()
        {
            object lockA = new object();
            object lockB = new object();
            var up = Task.Run(() =>
            {
                lock (lockA)
                {
                    lock (lockB)
                    {
                        Console.WriteLine("LockedAandB");
                    }
                }
            });
            lock (lockB)
            {
                Thread.Sleep(1000);
                lock (lockA)
                {
                    Console.WriteLine("LockedBandA");
                }
            }
            up.Wait();
        }

        /// <summary>
        /// Referring to Listing 1-35, the essential problem was that the operations of adding and subtracting were not atomic.
        /// This because n++ is translated into n = n + 1, both a read and a write. Making operations atomic is the job of the Interlocked class.
        /// Interlocked guarantees that the increment and decrement operations are executed atomically. 
        /// No other thread will see any intermediate results. Of course, adding and subtracting is a simple operation.If you have more complex operations, you would still have to use a lock. 
        /// </summary>
        public static void InterlockedExample()
        {
            int n = 0;
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    Interlocked.Increment(ref n);
            });

            for (int i = 0; i < 1000000; i++)
                Interlocked.Decrement(ref n);

            up.Wait();
            Console.WriteLine(n);
        }

        static int value = 1;

        /// <summary>
        /// Compare and exchange as a nonatomic operation.
        /// Task t1 starts running and sees that value is equal to 1. At the same time, t2 changes the value to 3 and then t1 changes it back to 2. 
        /// 
        /// AS: This is also a bug in the docu, I guess; see the part: "AS: Um... no, it displays 3!!!!"
        /// It displays 3, since it looks like that nothing assures us that t1 will start executing before t2!! And thus, I get (always result 3).
        /// It would display coorectly if we'd use Thread.Sleep also before running a t2.
        /// </summary>
        public static void CompareAndExchangeAsNonatomicOperation()
        {
            Task t1 = Task.Run(() =>
            {
                if (value == 1)
                {
                    // Removing the following line will change the output; AS: Um.... no, it will not!!!!
                    Thread.Sleep(1000);
                    value = 2;
                }
            });
            Task t2 = Task.Run(() =>
                    {
                        value = 3;
                    });
            Task.WaitAll(t1, t2);
            Console.WriteLine(value); // Displays 2; AS: Um... no, it displays 3!!!!
        }

        /// <summary>
        /// Will check if value == 1 and if it is, t1 will set it to 2, and t2 to 3.
        /// </summary>
        public static void CompareAndExchangeAsInterlocked()
        {
            Task t1 = Task.Run(() =>
            {
                Interlocked.CompareExchange(ref value, 2, 1);
            });
            Thread.Sleep(100);
            Task t2 = Task.Run(() =>
            {
                Interlocked.CompareExchange(ref value, 3, 1);
            });
            Task.WaitAll(t1, t2);
            Console.WriteLine(value); // Displays 2
        }
    }
}

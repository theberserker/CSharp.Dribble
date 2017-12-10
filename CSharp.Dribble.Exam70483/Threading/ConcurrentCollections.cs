using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Dribble.Exam70483.Threading
{
    public class ConcurrentCollections
    {
        /// <summary>
        /// One Task listens for new items being added to the collection. It blocks if there are no items available. The other Task adds items to the collection.
        /// The program terminates when the user doesn’t enter any data. Until that, every string entered is added by the write Task and removed by the read Task
        /// </summary>
        public static void BlockingCollectionUsage()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });
            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });
            write.Wait();
        }

        /// <summary>
        /// Same as <see cref="BlockingCollectionUsage"/>, but with removed the while(true) statements...
        /// By using the GetConsumingEnumerable method, you get an IEnumerable that blocks until it finds a new item. 
        /// That way, you can use a foreach with your BlockingCollection to enumerate it.
        /// </summary>
        public static void BlockingCollectionUsage2()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                foreach (string v in col.GetConsumingEnumerable())
                    Console.WriteLine(v);
            });
            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });
            write.Wait();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ConcurrentBagExample()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(42);
            bag.Add(21);
            int result;

            if (bag.TryTake(out result))
                Console.WriteLine(result);

            // One thing to keep in mind is that the TryPeek method is not very useful in a multithreaded
            // environment.It could be that another thread removes the item before you can access it.
            if (bag.TryPeek(out result))
                Console.WriteLine("There is a nextitem:{0}", result);
        }

        /// <summary>
        /// ConcurrentBag also implements IEnumerable<T>, so you can iterate over it. 
        /// This operation is made thread-safe by making a snapshot of the collection when you start iterating it, 
        /// so items added to the collection after you started iterating it won’t be visible.
        /// 
        /// The below code displays:
        /// 42
        /// </summary>
        public static void ConcurrentBagExample2()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });
            Task.Run(() =>
            {
                foreach (int i in bag)
                    Console.WriteLine(i);
            }).Wait();
        }
    }
}

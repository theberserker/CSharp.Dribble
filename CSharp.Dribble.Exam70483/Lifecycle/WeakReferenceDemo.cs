using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Dribble.Exam70483.Lifecycle
{
    public class WeakReferenceDemo
    {
        static WeakReference data;

        public static void Run()
        {
            object result = GetData();
            // GC.Collect(); Uncommenting this line will make data.Target null
            result = GetData();
        }


        /// <summary>
        /// The GetData function checks that the WeakReference still contains data. If not, the data is
        /// loaded again and saved in the WeakReference.The interesting thing is that uncommenting
        /// the line GC.Collect() frees the memory that the WeakReference points to.If garbage collection
        /// has not occurred, the data inside WeakReference.Target can be accessed and returned to the caller
        /// </summary>
        private static object GetData()
        {
            if (data == null)
            {
                data = new WeakReference(LoadLargeList());
            }
            if (data.Target == null)
            {
                data.Target = LoadLargeList();
            }
            return data.Target;
        }

        private static IList<string> LoadLargeList()
        {
            return new List<string>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Dribble.Exam70483
{
    public static class Enumerating
    {
        static IList<int> _arr;
        //static IEnumerable<int> _arr;

        static Enumerating()
        {
            var arr = new[] { 1, 2, 3 };
            //_arr = arr;
            _arr = arr.ToList();
        }

        /// <summary>
        /// Alles gut.
        /// </summary>
        public static void DoubleEnumeration()
        {
            foreach (var item in _arr)
            {
                foreach (var inner in _arr)
                {
                    Console.WriteLine($"item: {inner}");
                }
            }
        }

        public static void RemovalOfItemThrows()
        {
            foreach (var item in _arr)
            {
                _arr.Remove(item);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Dribble.Exam70483.Encryption
{
    /// <summary>
    /// By using hashing, you can improve the design of the set class. You split the data in a set of buckets.
    /// Each bucket contains a subgroup of all the items in the set.Listing 3-22 shows how you can do this.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Set<T>
    {
        private List<T>[] buckets = new List<T>[100];
        public void Insert(T item)
        {
            int bucket = GetBucket(item.GetHashCode());
            if (Contains(item, bucket))
                return;
            if (buckets[bucket] == null)
                buckets[bucket] = new List<T>();
            buckets[bucket].Add(item);
        }
        public bool Contains(T item)
        {
            return Contains(item, GetBucket(item.GetHashCode()));
        }

        /// <summary>
        /// Now your items are distributed over a hundred buckets instead of one single bucket. 
        /// When you see whether an item exists, you first calculate the hash code, go to the corresponding bucket, and look for the item.
        /// </summary>
        /// <param name="hashcode"></param>
        /// <returns>Bucket number</returns>
        private int GetBucket(int hashcode)
        {
            // A Hash code can be negative. To make sure that you end up with a positive
            // value cast the value to an unsigned int. The unchecked block makes sure that
            // you can cast a value larger then int to an int safely.
            unchecked
            {
                return (int)((uint)hashcode % (uint)buckets.Length);
            }
        }
        private bool Contains(T item, int bucket)
        {
            if (buckets[bucket] != null)
                foreach (T member in buckets[bucket])
                    if (member.Equals(item))
                        return true;
            return false;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Dribble.Exam70483.Assorted
{
    public class MyEnumerable : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class MyEnumerator : IEnumerator
    {
        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    class MyClass<T> : IComparable<T>
    {
        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }
    }

    class MyClass : IComparable
    {
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

    class MyClass2 : IComparer
    {
        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }
    }
    class MyClass2<T> : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            throw new NotImplementedException();
        }
    }
}

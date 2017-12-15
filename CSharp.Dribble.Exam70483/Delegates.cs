using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharp.Dribble.Exam70483
{
    public class Multicasting
    {
        public void MethodOne()
        {
            Console.WriteLine("MethodOne");
        }
        public void MethodTwo()
        {
            Console.WriteLine("MethodTwo");
        }
        public delegate void Del();

        public void Multicast()
        {
            Del d = MethodOne;
            d += MethodTwo;
            d();
        }
        // Displays
        // MethodOne
        // MethodTwo
    }

    /// <summary>
    /// Because both StreamWriter and StringWriter inherit from TextWriter, you can use the CovarianceDel with both methods.
    /// </summary>
    public class Covariance
    {
        public delegate TextWriter CovarianceDel();
        public StreamWriter MethodStream() { return null; }
        public StringWriter MethodString() { return null; }

        public void Method()
        {
            CovarianceDel del;
            del = MethodStream;
            del = MethodString;
        }
    }

    /// <summary>
    /// Because the method DoSomething can work with a TextWriter, it surely can also work with a StreamWriter.
    /// Because of contravariance, you can call the delegate and pass an instance of StreamWriter to the DoSomething method.
    /// </summary>
    public class Contravariance
    {
        void DoSomething(TextWriter tw) { }
        public delegate void ContravarianceDel(StreamWriter tw);

        public void Method()
        {
            ContravarianceDel del = DoSomething;    
        }
    }
}

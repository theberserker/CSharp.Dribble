﻿using CSharp.Dribble.Exam70483.CreateAndUseTypes;
using CSharp.Dribble.Exam70483.Diagnostics;
using CSharp.Dribble.Exam70483.Encryption;
using CSharp.Dribble.Exam70483.Serialization;
using CSharp.Dribble.Exam70483.Threading;
using CSharp.Dribble.Exam70483.Validation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Dribble.Exam70483
{
    public static class Program
    {
        public static void Main()
        {
            //ThreadBasics2.MainMethod();
            //TaskBasics2.WaitAny();
            //ParallelBasics.TerminatingAParallel();
            ConcurrentCollections.BlockingCollectionUsage();
            //ConcurrentCollections.BlockingCollectionUsage2();
            //Enumerating.RemovalOfItemThrows();
            //ThreadingManagement.DeadlockSample_Book();
            //ThreadingManagement.A();

            //ExceptionHandling.FailFast();

            //Parsing.CultureSpecific();

            //Symetric.EncryptSomeText();

            //BuildConfigurationDifferences.DoWork();

            //Tracing.DoTrace();

            //ObjectInheritanceToXmlAndBack.Do();

            //XmlDataContract.Do();
            //XmlDataContract.DoJson();

            //var a = new InstantiationSequence(1);

            //OverflowChecking.CheckedThrows();

            PerfCounters.DoSample();

            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Dribble.Exam70483.CreateAndUseTypes
{
    public class MyBase
    {
        protected event Action SomethingHappened;
        protected int baseValue;
        public MyBase()
        {
            Console.WriteLine($"In {typeof(MyBase)}");
            baseValue = 1;
        }
    }

    public class InstantiationSequence : MyBase
    {
        public int A { get; }
        public bool B { get; set; }
        
        public InstantiationSequence()
        {
            Console.WriteLine($"In {typeof(InstantiationSequence)} parameterless constructor.");

            B = true;
        }

        public InstantiationSequence(int a) : this()
        {
            Console.WriteLine($"In {typeof(InstantiationSequence)} constructor(int a).");

            this.A = a;
        }

        private void OnSomethingHappened()
        {
            base.SomethingHappened += () => { Console.WriteLine("Something happened and event invoked."); };
        }
    }
}

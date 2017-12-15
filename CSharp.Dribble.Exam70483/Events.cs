using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Dribble.Exam70483
{
    public class Pub
    {
        public Action OnChange { get; set; }
        public void Raise()
        {
            if (OnChange != null)
            {
                OnChange();
            }
        }
    }

    public class Pub2
    {
        /// <summary>
        /// ome special syntax to initialize the event to an empty delegate. 
        /// This way, you can remove the null check around raising the event because you can be certain that the event is never null.
        /// 
        /// Instead of using the Action type for your event, you should use the EventHandler or EventHandler.
        /// </summary>
        public event Action OnChange = delegate { };
        public void Raise()
        {
            OnChange();
        }
    }

    public class MyArgs : EventArgs
    {
        public MyArgs(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
    }

    public class Pub3
    {
        public event EventHandler<MyArgs> OnChange = delegate { };
        public void Raise()
        {
            OnChange(this, new MyArgs(42));
        }
    }

    /// <summary>
    /// Although the event implementation uses a public field, you can still customize addition and removal of subscribers.This is called a custom event accessor
    /// </summary>
    public class Pub4
    {
        private event EventHandler<MyArgs> onChange = delegate { };
        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock (onChange)
                {
                    onChange += value;
                }
            }
            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }
        public void Raise()
        {
            onChange(this, new MyArgs(42));
        }
    }

    /// <summary>
    /// Manually raising events with exception handling
    /// </summary>
    public class Pub5
    {
        public event EventHandler OnChange = delegate { };
        public void Raise()
        {
            var exceptions = new List<Exception>();
            foreach (Delegate handler in OnChange.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }

    public class SubscriberToPubClasses
    {
        /// <summary>
        /// Although this system works, there are a couple of weaknesses. 
        /// 1. If you change the subscribe line for method 2 to the following, you would effectively remove the first subscriber by using = instead of += 
        /// 2. Nothing prevents outside users of the class from raising the event. By just calling p.OnChange() every user of the class can raise the event to all subscribers
        /// 
        /// ... this is solved by the event keyword as displayed in <see cref="Pub2"/>
        /// </summary>
        public void CreateAndRaise()
        {
            Pub p = new Pub();
            p.OnChange += () => Console.WriteLine("Eventraised to method 1");
            p.OnChange += () => Console.WriteLine("Eventraised to method 2");
            p.Raise();
        }

        public void CreateAndRaise3()
        {
            Pub3 p = new Pub3();
            p.OnChange += (sender, e) => Console.WriteLine("Eventraised:{0}", e.Value);
            p.Raise();
        }

        public void CreateAndRaise5()
        {
            Pub5 p = new Pub5();
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 called");
            p.OnChange += (sender, e) => { throw new Exception(); };
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 called");
            try
            {
                p.Raise();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerExceptions.Count);
            }
        }
        // Displays
        // Subscriber 1 called
        // Subscriber 3 called
    }
}

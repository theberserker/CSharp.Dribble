using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Dribble.Exam70483.CreateAndUseTypes
{
    public class Person
    {
        public string Name { get; set; }
    }

    public class Employee : Person
    {
    }

    /// <summary>
    /// Used to dempnstrate covariance.
    /// </summary>
    public delegate Person GetPersonDelegate();

    /// <summary>
    /// Used to demonstrate contravariance
    /// </summary>
    public delegate void PassEmployeeDelegate(Employee e);


    public class DelegateCoAndContraVariance
    {
        public Employee GetEmployee() => new Employee();

        public void WorkWithPerson(Person p) { }


        public void Covariance()
        {
            GetPersonDelegate d = GetEmployee;
            //d += GetEmployee;
        }

        public void Contravariance()
        {
            PassEmployeeDelegate d = WorkWithPerson;
        }
    }

    public class TestBase
    {
        public event EventHandler EventName;    

        protected void OnEvent()
        {
            if (EventName != null)
            {
                EventName(this, EventArgs.Empty);
            }
        }
    }
    public class Test : TestBase
    {
        void Method()
        {
            EventArgs args = EventArgs.Empty;

            // THIS WON'T WORK! You can't invoke inherited event directly
            //if (base.EventName != null) 
            //base.EventName(this, args);
        }
    }
}

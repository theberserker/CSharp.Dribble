using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Dribble.Exam70483.Flow
{
    public class FlowAdvanced
    {
        /// <summary>
        /// The end point of a switch statement should not be reachable. You need to have a statement such as break or return that explicitly exits the switch statement, or you need to throw an exception. This avoids the fall-through behavior that C++ has. This makes it possible for switch sections to appear in any order without affecting behavior. 
        /// 
        /// If you have a code that doesn't break/return/throw in the case, the compiler error is e.g.: Control cannot fall out of switch from final case label ('case 'y':')
        /// </summary>
        /// <param name="input"></param>
        void CheckWithSwitch(char input)
        {
            switch (input)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    {
                        Console.WriteLine("Input is a vowel");

                        break;
                    }
                case 'y':
                    {
                        Console.WriteLine("Input is sometimes a vowel.");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Input is a consonant");
                        break;
                    }

            }
        }

        /// <summary>
        /// Instead of implicitly falling through to another label, you can use the goto statement.
        /// AS: I'd avoid code like such :)
        /// </summary>
        public static void GotoInSwitch()
        {
            int i = 1;
            switch (i)
            {
                case 1:
                    {
                        Console.WriteLine("Case1");
                        goto case 2;
                    }
                case 2:
                    {
                        Console.WriteLine("Case2");
                        break;
                    }
            }
            // Displays
            // Case 1
            // Case 2
        }

        /// <summary>
        /// You can also use multiple statements in each part of your for loop
        /// </summary>
        public static void MultipleStatementsFor()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            for (int x = 0, y = values.Length - 1; ((x < values.Length) && (y >= 0)); x++, y--)
            {
                Console.Write(values[x]);
                Console.Write(values[y]);
            }
            // Displays
            // 162534435261
        }

        public class Person
        {
            public string FirstName;
            public string LastName;
        }

        /// <summary>
        /// If you change the value of e.Current to something else, the iterator pattern can’t determine what to do when e.MoveNext is called.
        /// </summary>
        void CannotChangeForeachIterationVariable()
        {
            var people = new List<Person>
            {
                new Person() {FirstName="John",LastName="Doe"},
                new Person() {FirstName="Jane",LastName="Doe"},
            };
            foreach (Person p in people)
            {
                p.LastName = "Changed"; // This is allowed
                // p = new Person(); // This gives a compile error
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace CSharp.Dribble.Exam70483
{
    /// <summary>
    /// The line Program Complete won’t be executed if 42 is entered. Instead the application shuts down immediately.
    /// </summary>
    public class ExceptionHandling
    {
        public static void FailFast()
        {
            string s = Console.ReadLine();
            try
            {
                int i = int.Parse(s);
                if (i == 42) Environment.FailFast("Special number entered.");
            }
            finally
            {
                Console.WriteLine("Program complete.");
            }

        }

        /// <summary>
        /// In C# 5, a new option is added for rethrowing an exception. You can use the ExceptionDispatchInfo.Throw method, which can be found in the System.Runtime.ExceptionServices namespace.
        /// This method can be used to throw an exception and preserve the original stacktrace. You can use this method even outside of a catch block, as shown in Listing 1-97.
        /// When looking at the stack trace, you see this line, which shows where the original exception stack trace ends and the ExceptionDispatchInfo.Throw is used:
        /// --- End ofstack tracefrom previouslocation whereexception wasthrown---
        /// This feature can be used when you want to catch an exception in one thread and throw it on another thread. 
        /// By using the ExceptionDispatchInfo class, you can move the exception data between threads and throw it.The.NET Framework uses this when dealing with the async/await feature added in C# 5. 
        /// An exception that’s thrown on an async thread will be captured and rethrown on the executing thread.
        /// </summary>
        public void A()
        {
            ExceptionDispatchInfo possibleException = null;
            try
            {
                string s = Console.ReadLine();
                int.Parse(s);
            }
            catch (FormatException ex)
            {
                possibleException = ExceptionDispatchInfo.Capture(ex);
            }
            if (possibleException != null)
            {
                possibleException.Throw();
            }
            // Displays
            // Unhandled Exception: System.FormatException: 
            // Input string was not in a correct format.
            //   at System.Number.StringToNumber(String str, NumberStyles options, 
            //         NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
            //   at System.Number.ParseInt32(String s, NumberStyles style, 
            //         NumberFormatInfo info)
            //   at System.Int32.Parse(String s)
            //   at ExceptionHandling.Program.Main() in c:\Users\Wouter\Documents\
            //      Visual Studio 2012\Projects\ExamRefProgrammingInCSharp\Chapter1\
            // Program.cs:line  17
            //--- End of stack trace from previous location where exception was thrown ---
            //   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
            //   at ExceptionHandling.Program.Main() in c:\Users\Wouter\Documents\
            //      Visual Studio 2012\Projects\ExamRefProgrammingInCSharp\Chapter1\
            // Program.cs:line 6

        }
    }
}

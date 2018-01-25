using CSharp.Dribble.Exam70483.Exceptions;
using System;
using static System.Console; // importing a static class

namespace CSharp.Dribble.Exam70483.LanguageFeatures
{
    public class CSharpV6
    {
        /// <summary>
        /// OUT Parameter Declaration During Method Call
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ConvertToIntegerAndCheckForGreaterThan10(string value)
        {
            if (int.TryParse(value, out int convertedValue) && convertedValue > 10)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Await in the catch block
        /// </summary>
        //public async void Process()
        //{
        //    try
        //    {
        //        Processor processor = new Processor();
        //        await processor.ProccessAsync();
        //    }
        //    catch (Exception exception)
        //    {
        //        ExceptionLogger logger = new ExceptionLogger();
        //        // Catch operation also can be aync now!!
        //        await logger.HandleExceptionAsync(exception);
        //    }
        //}


        public async void ExceptionFilters()
        {
            try
            {
                throw new ApplicationException();
            }
            // Catches and handles only non sql exceptions
            catch (Exception exception) when (exception.GetType() != typeof(OrderProcessingException))
            {
                // 2 features used here: using an earlier imported static class, and string interpolation.
                WriteLine($"Some other exception than {nameof(OrderProcessingException)} has occoured: {exception}");
            }
        }
    }
}

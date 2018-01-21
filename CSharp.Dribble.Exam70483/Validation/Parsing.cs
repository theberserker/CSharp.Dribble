using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CSharp.Dribble.Exam70483.Validation
{
    public class Parsing
    {
        public static void CultureSpecific()
        {
            CultureInfo english = new CultureInfo("En");
            CultureInfo dutch = new CultureInfo("Nl");
            string value ="€19,95";
            decimal d = decimal.Parse(value, NumberStyles.Currency, dutch);
            Console.WriteLine(d.ToString(english)); // Displays 19.95

            //DateTimeStyles.
        }
    }
}

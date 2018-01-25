using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Dribble.Exam70483
{
    public static class OverflowChecking
    {
        public static void CheckedThrows()
        {
            int ten = 10;
            // Checked expression.
            Console.WriteLine(checked(2147483647 + ten));

            // Checked block.
            checked
            {
                int i3 = 2147483647 + ten;
                Console.WriteLine(i3);
            }
        }


    }
}

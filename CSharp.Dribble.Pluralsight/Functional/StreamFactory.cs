using System;
using System.Collections.Generic;
using System.IO;

namespace CSharp.Dribble.Pluralsight.Functional
{
    internal class StreamFactory
    {
        internal static Stream GetStream()
        {
            var dict = new Dictionary<int, string>
                {
                    { 1, "1" },
                    { 2, "2" },
                    { 3, "3" }
                };
            // TODO: Serialize and return a memorystream
            return new MemoryStream();
        }
    }
}
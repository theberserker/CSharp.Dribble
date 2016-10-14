using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Dribble.Pluralsight.Functional
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendFormattedLine(this StringBuilder @this, string s, params object[] @params)
        {
            return @this.AppendFormat(s, @params);
        }

        public static StringBuilder AppendLineWhen(this StringBuilder @this, Func<bool> predicate, string value)
        {
            return predicate() ? @this.AppendLine(value) : @this;
        }
    }
}

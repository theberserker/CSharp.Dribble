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

        public static StringBuilder AppendWhen(this StringBuilder @this, Func<bool> predicate, Func<StringBuilder, StringBuilder> func)
        {
            return predicate() ? func(@this) : @this;
        }

        public static StringBuilder AppendSequence<T>(
            this StringBuilder @this, 
            IEnumerable<T> sequence,
            Func<StringBuilder, T, StringBuilder> func)
        {
            //StringBuilder sb = null;
            //foreach (var item in sequence)
            //{
            //    sb = (sb == null) ? (sb = func(@this, item)) : func(@this, item);
            //}
            //return @this;

            return sequence.Aggregate(@this, func);
        }
    }
}

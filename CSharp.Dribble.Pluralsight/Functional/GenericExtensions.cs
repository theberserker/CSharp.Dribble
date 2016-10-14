using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Dribble.Pluralsight.Functional
{
    public static class GenericExtensions
    {
        public static TResult Map<TSource, TResult>(this TSource @this, Func<TSource, TResult> func) => func(@this);
        

        public static T Tee<T>(this T @this, Action<T> action)
        {
            action(@this);
            return @this;
        }
    }
}

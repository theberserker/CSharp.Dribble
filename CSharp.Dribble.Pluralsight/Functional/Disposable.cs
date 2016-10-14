using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Dribble.Pluralsight.Functional
{
    public static class Disposable
    {
        public static TResult Using<TDisposable, TResult>(
            Func<TDisposable> factory, // we prefer the factory over an instance, sice we want control of our object's lifecycle (if it would come from the outside we wouldn't be fully controlling the disposable's lifecycle!)
            Func<TDisposable, TResult> map) where TDisposable: IDisposable
        {
            using (var disposable = factory())
            {
                return map(disposable);
            }
        }
    }
}

using System.Threading.Tasks;

namespace CSharp.Dribble.Exam70483.Threading
{
    /// <summary>
    /// The SleepAsyncA method uses a thread from the thread pool while sleeping. 
    /// The second method, however, which has a completely different implementation, does not occupy a thread while waiting for the timer to run.The second method gives you scalability
    /// </summary>
    public static class AsyncAwait
    {
        public Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }

        public Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);
            return tcs.Task;
        }
    }
}

using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Dribble.Exam70483.Threading
{
    /// <summary>
    /// If you want, you can disable the flow of the SynchronizationContext. Maybe your continuation
    /// code can run on any thread because it doesn’t need to update the UI after it’s finished.
    /// By disabling the SynchronizationContext, your code performs better. Listing 1-20 shows an
    /// example of a button event handler in a WPF application that downloads a website and then
    /// puts the result in a label.
    /// </summary>
    public static class AsyncAwait
    {
        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    HttpClient httpClient = new HttpClient();
        //    string content = await httpClient
        //        .GetStringAsync("http://www.microsoft.com")

        //    .ConfigureAwait(false);


        //// This example throws an exception; the Output.Content line is not executed on the UI thread because of the ConfigureAwait(false). 
        //    Output.Content = content;
        //}
    }
}

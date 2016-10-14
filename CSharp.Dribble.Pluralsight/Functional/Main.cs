using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharp.Dribble.Pluralsight.Functional
{
    public class Main
    {
        public string Invoke()
        {
            var timeDoc = 
                Disposable
                    .Using(
                        () => new System.Net.WebClient(),
                        client => XDocument.Parse(client.DownloadString("http://time.gov/actualtime.cgi"))); // TODO: async!

            return timeDoc.Root.Attribute("time").Value;
        }

        public string Invoke1()
        {
            var buffer = 
                Disposable.Using(
                    StreamFactory.GetStream,
                    stream =>
                        {
                            var b = new byte[stream.Length];
                            stream.Read(b, 0, (int)stream.Length);
                            return b;
                        });

            var options = Encoding
                            .UTF8
                            .GetString(buffer)
                            .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                            .Select((s, ix) => Tuple.Create(ix, s))
                            .ToDictionary(k => k.Item1, v => v.Item2);

            var selectBox = BuildSelectBox(options, "TheDoctors", false);
            return selectBox;
        }

        // Introduce Tee, so we can read the stream in one go and get back the object we were working on (performs an action on an item and returns item)
        // Introduce Map, so we can chain map the read bytes directly to the Encoding.UTF8.GetString and get it's result
        //      - the options parameter is now our root variable
        public string Invoke2()
        {
            var options = 
                Disposable.Using(
                    StreamFactory.GetStream,
                        stream => new byte[stream.Length].Tee(b => stream.Read(b, 0, (int)stream.Length))
                    .Map(Encoding.UTF8.GetString))
                    .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select((s, ix) => Tuple.Create(ix, s))
                    .ToDictionary(k => k.Item1, v => v.Item2);

            var selectBox = BuildSelectBox(options, "TheDoctors", false);
            return selectBox;
        }

        // Also use the Map 
        public string Invoke3()
        {
            var selectBox =
                Disposable.Using(
                    StreamFactory.GetStream,
                        stream => new byte[stream.Length].Tee(b => stream.Read(b, 0, (int)stream.Length))
                    .Map(Encoding.UTF8.GetString))
                    .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select((s, ix) => Tuple.Create(ix, s))
                    .ToDictionary(k => k.Item1, v => v.Item2)
                    .Map(kvp => BuildSelectBox(kvp, "TheDoctors", true));

            return selectBox;
        }

        public string BuildSelectBox(IDictionary<int, string> options, string id, bool includeUnknown)
        {
            var sb = new StringBuilder()
                .AppendFormattedLine("append formatted {0}", "line")
                .ToString();

            return sb;
        }
    }
}

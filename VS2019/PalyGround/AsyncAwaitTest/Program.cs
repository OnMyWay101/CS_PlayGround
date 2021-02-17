using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwaitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FetchAndShowBody("https://www.bilibili.com/video/BV1XJ411Q7B2?t=2");
            Console.WriteLine("Method returned");

            Console.ReadLine();
        }

        private static async void FetchAndShowHeaders(string url)
        {
            using (var w = new HttpClient())
            {
                var req = new HttpRequestMessage(HttpMethod.Head, url);
                //异步：返回
                HttpResponseMessage response = await w.SendAsync(req, HttpCompletionOption.ResponseHeadersRead);
                //异步：阻塞
                //HttpResponseMessage response = w.SendAsync(req, HttpCompletionOption.ResponseHeadersRead).Result;
                Console.WriteLine("SendAsync after");
                var headerStrings =
                    from header in response.Headers
                    select header.Key + ": " + string.Join(",", header.Value);
                string headerList = string.Join(Environment.NewLine, headerStrings);
                Console.WriteLine(headerList);
            }
        }

        private static async void FetchAndShowBody(string url)
        {
            using (var w = new HttpClient())
            {
                Stream body = await w.GetStreamAsync(url);
                using (var bodyTextReader = new StreamReader(body))
                {
                    while (!bodyTextReader.EndOfStream)
                    {
                        string line = await bodyTextReader.ReadLineAsync();
                        Console.WriteLine(line);
                        await Task.Delay(TimeSpan.FromMilliseconds(1000));
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace asyncAwait
{
    /// <summary>
    /// 测试例程：走进异步编程的世界 - 开始接触 async/await
    /// 来源：https://www.cnblogs.com/liqingwen/p/5831951.html
    /// </summary>
    class FirstTest
    {
        //创建计时器
        private static readonly Stopwatch _watch = new Stopwatch();

        public static void Example1()
        {
            _watch.Start();

            const string url1 = "http://www.cnblogs.com/";
            const string url2 = "http://www.cnblogs.com/liqingwen/";

            //var result1 = CountCharacters(1, url1);
            //var result2 = CountCharacters(2, url2);
            Task<int> t1 = CountCharactersAsync(1, url1);
            Task<int> t2 = CountCharactersAsync(2, url2);

            for (int i = 0; i < 3; i++)
            {
                WasteTime(i + 1);
            }

            //Console.WriteLine($"{url1} 的字符个数：{result1}");
            //Console.WriteLine($"{url2} 的字符个数：{result2}");
            Console.WriteLine($"{url1} 的字符个数：{t1.Result}");
            Console.WriteLine($"{url2} 的字符个数：{t2.Result}");
        }

        /// <summary>
        /// 计算网页的字符数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private static int CountCharacters(int id, string url)
        {
            //Todo
            //return 0;

            var wc = new WebClient();
            Console.WriteLine($"开始调用 id = {id} :{_watch.ElapsedMilliseconds} ms");

            var result = wc.DownloadString(url);
            Console.WriteLine($"调用完成 id = {id} :{_watch.ElapsedMilliseconds} ms");

            return result.Length;
        }

        private static async Task<int> CountCharactersAsync(int id, string url)
        {
            var wc = new WebClient();
            Console.WriteLine($"开始调用 id = {id} :{_watch.ElapsedMilliseconds} ms");

            var result = await wc.DownloadStringTaskAsync(url);
            Console.WriteLine($"调用完成 id = {id} :{_watch.ElapsedMilliseconds} ms");

            Console.WriteLine($"time2:开始调用 id = {id} :{_watch.ElapsedMilliseconds} ms");

            var result2 = await wc.DownloadStringTaskAsync(url);
            Console.WriteLine($"time2:调用完成 id = {id} :{_watch.ElapsedMilliseconds} ms");

            return result2.Length;
        }

        /// <summary>
        /// 消耗一定的时间
        /// </summary>
        /// <param name="num"></param>
        private static void WasteTime(int id)
        {
            var s = "";

            for(var i = 0; i < 6000; i++)
            {
                s += i;
            }
            Console.WriteLine($"调用完成 id = {id} 的 WasteTime方法完成:{_watch.ElapsedMilliseconds} ms");
        }
    }
}

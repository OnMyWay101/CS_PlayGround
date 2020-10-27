using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now1 = DateTime.Now;
            Console.WriteLine("now1:year({0}),month({1}),day({2}),hour({3}),minute({4}),second({5})", 
                now1.Year, now1.Month, now1.Day, now1.Hour, now1.Minute, now1.Second);

            Console.ReadLine();

            DateTime now2 = DateTime.Now;
            Console.WriteLine("now2:year({0}),month({1}),day({2}),hour({3}),minute({4}),second({5})",
                now2.Year, now2.Month, now2.Day, now2.Hour, now2.Minute, now2.Second);

            TimeSpan span = now2 - now1;
            Console.WriteLine(
                "span:days({0}),hours({1}, minutes({2}),seconds({3}),millSeconds({4}),totalMs({5})",
                span.Days, span.Hours, span.Minutes, span.Seconds, span.Milliseconds, span.TotalMilliseconds);
            Console.ReadLine();

        }
    }
}

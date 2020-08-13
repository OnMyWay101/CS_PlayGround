using System;


namespace MyTimeSpan
{
    class Program
    {
        static void Main(string[] args)
        {
            Example_1();
            Console.ReadLine();
        }

        static void Example_1()
        {
            DateTime data1 = new DateTime(2010, 1, 1, 2, 3, 4);
            DateTime data2 = new DateTime(2010, 8, 1, 4, 3, 5);

            TimeSpan interval = data2 - data1;
            Console.WriteLine("{0} - {1} = {2}", data2, data1, interval.ToString());

            Console.WriteLine("   {0,-35} {1,20}", "value of days component:", interval.Days);
            Console.WriteLine("   {0} {1,20}", "value of days component:", interval.Days);
            Console.WriteLine("   {0,-20} {1,20}", "value of days component:", interval.Days);
            Console.WriteLine("   {0,-35} {1,10}", "value of days component:", interval.Days);
            Console.WriteLine("   {0,-35} {1,20}", "Total Number of Days:", interval.TotalDays);
            Console.WriteLine("   {0,-35} {1,20}", "Value of Hours Component:", interval.Hours);
            Console.WriteLine("   {0,-35} {1,20}", "Total Number of Hours:", interval.TotalHours);
            Console.WriteLine("   {0,-35} {1,20}", "Value of Minutes Component:", interval.Minutes);
            Console.WriteLine("   {0,-35} {1,20}", "Total Number of Minutes:", interval.TotalMinutes);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Seconds Component:", interval.Seconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Seconds:", interval.TotalSeconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Milliseconds Component:", interval.Milliseconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Milliseconds:", interval.TotalMilliseconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Ticks:", interval.Ticks);
        }
    }
}

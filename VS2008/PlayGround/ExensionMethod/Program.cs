using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello Extension Methods";
            Console.WriteLine(s.WordCount().ToString());
            Console.ReadLine();
        }
    }

    public static class MyExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}

using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var myTuple = Tuple.Create(10, 20, 30);
            System.Console.WriteLine(myTuple.Item1);
            System.Console.WriteLine(myTuple.Item2);
            System.Console.WriteLine(myTuple.Item3);
        }
    }
}

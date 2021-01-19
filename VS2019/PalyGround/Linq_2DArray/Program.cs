using System;
using System.Collections;
using System.Linq;

namespace Linq_2DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    array[i, j] = (i + 1) * (j + 1);

            //var intQuery = from i in array.Cast<int>()
            //                where i > 5
            //                select i;

            //foreach (int i in intQuery)
            //    Console.WriteLine(i);
            var intQuery = array.Cast<int>().Max();
      
            Console.WriteLine(intQuery);
        }
    }
}

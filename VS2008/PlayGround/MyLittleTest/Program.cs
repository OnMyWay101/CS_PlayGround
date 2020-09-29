using System;

namespace MyLittleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 16;
            int[,] matrix = new int[num, num];
            
            Console.WriteLine("matrix length is {0}", matrix.Length);
            Console.WriteLine("{0} sqrt is {1}", matrix.Length, TestSqrt(matrix.Length));

            matrix[0, 0] = 0;
            matrix[1, 1] = 1;
            Console.WriteLine(" matrix[0, 0] = {0}", matrix[0, 0]);
            Console.WriteLine(" matrix[1, 1] = {0}", matrix[1, 1]);

            Console.ReadKey();
        }

        static int TestSqrt(int num)
        {
            return (int)Math.Sqrt(num);
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamTest
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] testBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7 };
            byte[] readBuf = new byte[7];

            MemoryStream ms = new MemoryStream(testBytes);
            int readNum = ms.Read(readBuf, 0, 7);
            Console.WriteLine("readNum = " + readNum);
            Console.ReadLine();
        }
    }
}

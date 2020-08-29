using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ByteArrayToString
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[] { 0x1, 0x2, 0x3 , 0x4, 0x15};
            Console.WriteLine("data[0]:" + data[0].ToString());
            Console.WriteLine("data[1]:" + data[1].ToString());
            Console.WriteLine("data[4]:" + data[4].ToString());
            Console.WriteLine("data.ToString.:" + data.ToString());

            //16进制显示
            Console.WriteLine("data[4]:0x" + Convert.ToString(data[4], 16));
            Console.ReadLine();
        }
    }
}

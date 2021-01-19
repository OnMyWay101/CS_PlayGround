using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TcpClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Connect.Example_ConnectWait();
            Console.ReadLine();
        }
    }
}

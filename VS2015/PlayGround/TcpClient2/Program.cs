using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient2.ConnectTest();
            Console.ReadLine();
        }
    }

    public class TcpClient2
    {
        TcpClient _client;
        IPAddress _ipAddr;
        int _port;

        public TcpClient2(string serverip, int port)
        {
            _port = port;
            _ipAddr = IPAddress.Parse(serverip);
        }

        //连接服务器
        public void Connect()
        {
            using (_client = new TcpClient())
            {
                IAsyncResult ar = _client.BeginConnect(_ipAddr, _port, null, null);
                if (ar.AsyncWaitHandle.WaitOne(4000, false))//等4000ms
                {
                    //连接成功
                    Console.WriteLine("connect success!");
                }
                else
                {
                    //连接失败
                    Console.WriteLine("connect failed!timeout.");
                }
            }

        }

        private void Recv()
        {

        }

        public static void ConnectTest()
        {
            //var tcpClient = new TcpClient2("192.168.9.9", 20100);
            var tcpClient = new TcpClient2("127.0.0.2", 20100);
            Console.WriteLine("Begin Connecting:");
            Task.Factory.StartNew(LogTime);
            tcpClient.Connect();
        }

        private static void LogTime()
        {
            int i = 0;

            Console.WriteLine("log time(s):");
            while (true)
            {
                Thread.Sleep(1000);
                i++;
                Console.WriteLine(i);
            }
        }
    }
}

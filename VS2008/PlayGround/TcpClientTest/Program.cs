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
            Example_Tcp();
            Console.ReadLine();
        }

        static void Example_Tcp()
        {
            //string host = "www.baidu.com";
            string host = "127.0.0.1";
            int port = 8080;
            int timeout = 50000;

            //Create TCP client and connect
            using (var _client = new TcpClient(AddressFamily.InterNetwork))
            {
                IPAddress ipAddr = IPAddress.Parse(host);
                Console.Write("Connecting ");
                while (!_client.Connected)
                {
                    try 
                    { 
                        _client.Connect(ipAddr, port);
                    }
                    catch(SocketException se)
                    {
                        Console.Write(".");
                        //连接异常，休息一下
                        Thread.Sleep(1000);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Connected! ");
                using (var _netStream = _client.GetStream())
                {
                    _netStream.ReadTimeout = timeout;

                    // Write a message over the socket
                    string message = "Hello World!";
                    byte[] dataToSend = Encoding.ASCII.GetBytes(message);
                    _netStream.Write(dataToSend, 0, dataToSend.Length);

                    // Read server response
                    byte[] recvData = new byte[256];
                    int bytes = _netStream.Read(recvData, 0, recvData.Length);
                    message = Encoding.ASCII.GetString(recvData, 0, bytes);
                    Console.WriteLine(string.Format("Server: {0}", message));
                }
            }
        }

        static void Example_ConnectWait()
        {
            //string host = "www.baidu.com";
            string host = "127.0.0.1";
            int port = 8080;
            int timeout = 5000;

            //Create TCP client and connect
            using (var _client = new TcpClient(AddressFamily.InterNetwork))
            {
                IPAddress ipAddr = IPAddress.Parse(host);
                //研究一下这个异步如何实现
                IAsyncResult ar = _client.BeginConnect(ipAddr, port, null, null);
                System.Threading.WaitHandle wh = ar.AsyncWaitHandle;
                wh.WaitOne(new TimeSpan(50), false);
                //wh.WaitOne(-1);
                wh.Close();

                using (var _netStream = _client.GetStream())
                {
                    _netStream.ReadTimeout = timeout;

                    // Write a message over the socket
                    string message = "Hello World!";
                    byte[] dataToSend = Encoding.ASCII.GetBytes(message);
                    _netStream.Write(dataToSend, 0, dataToSend.Length);

                    // Read server response
                    byte[] recvData = new byte[256];
                    int bytes = _netStream.Read(recvData, 0, recvData.Length);
                    message = Encoding.ASCII.GetString(recvData, 0, bytes);
                    Console.WriteLine(string.Format("Server: {0}", message));
                }
            }
        }

    }
}

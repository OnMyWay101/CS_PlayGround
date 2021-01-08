using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TcpClientTest
{
    class Connect
    {
        public static ManualResetEvent connectDone = new ManualResetEvent(false);

        private static void ConnctCallback(IAsyncResult ar)
        {
            try
            {
                Console.WriteLine("ConnctCallback!");
                connectDone.Set();
                TcpClient t = (TcpClient)ar.AsyncState;
                t.EndConnect(ar);
            }
            catch
            {
                return;
            }

        }

        public static void Example_Tcp()
        {
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
                    catch (SocketException se)
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
                    while (true)
                    {
                        DoOneComunication(_netStream, timeout);
                    }
                }
            }
        }

        public static void Example_ConnectWait()
        {
            string host = "127.0.0.1";
            int port = 8080;
            int timeout = 5000;

            //Create TCP client and connect
            using (var client = new TcpClient(AddressFamily.InterNetwork))
            {
                IPAddress ipAddr = IPAddress.Parse(host);

                connectDone.Reset();
                client.BeginConnect(ipAddr, port, ConnctCallback, client);
                Console.WriteLine("After BeginConnect!");
                connectDone.WaitOne();
                Console.WriteLine("After WaitOne!");
                if (!client.Connected)
                {
                    Console.WriteLine("Connect failed!");
                    return;
                }
                using (var _netStream = client.GetStream())
                {
                    DoOneComunication(_netStream, timeout);
                }
            }
        }

        private static void DoOneComunication(NetworkStream ns, int timeout)
        {
            ns.ReadTimeout = timeout;

            // Write a message over the socket
            string message = "Hello World!";
            byte[] dataToSend = Encoding.ASCII.GetBytes(message);
            ns.Write(dataToSend, 0, dataToSend.Length);

            // Read server response
            byte[] recvData = new byte[256];
            int bytes = ns.Read(recvData, 0, recvData.Length);
            message = Encoding.ASCII.GetString(recvData, 0, bytes);
            Console.WriteLine(string.Format("Server: {0}", message));
        }
    }
}

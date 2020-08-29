using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace UDP_ClientRecieve
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[1024];
            string stringData = String.Empty;
            //IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 8641);
            IPEndPoint serverIEP = new IPEndPoint(IPAddress.Any, 0);

            Socket sock = new Socket(AddressFamily.InterNetwork,SocketType.Dgram, ProtocolType.Udp);
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
            sock.Bind(iep);

            EndPoint serverEP = (EndPoint)serverIEP;
            Console.WriteLine("Ready to receive…");

            while (true)
            {
                if (sock.Available > 0)
                {
                    int recv = sock.ReceiveFrom(data, ref serverEP);
                    for (int i = 0; i < recv; i++)
                    {
                        stringData += String.Format(" 0x{0} ,",Convert.ToString(data[i], 16));
                    }
                    Console.WriteLine("received: {0} from: {1}", stringData, serverEP.ToString());
                    stringData = String.Empty;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
            sock.Close();
            Console.ReadKey();
        }
    }
}

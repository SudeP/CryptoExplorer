using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp1
{
    public class SocketClient
    {
        public event EventHandler Exception;
        private readonly int port;
        private readonly IPAddress ipAddress;
        private readonly IPEndPoint ipEndPoint;
        private Socket sender;
        public SocketClient()
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            ipAddress = host.AddressList[0];
            port = 11000;
            ipEndPoint = new IPEndPoint(ipAddress, port);
        }
        public SocketClient([NotNull]IPAddress ipAddress, int port = 11000)
        {
            this.ipAddress = ipAddress;
            this.port = port;
            ipEndPoint = new IPEndPoint(this.ipAddress, this.port);
        }
        public SocketClient([NotNull]IPEndPoint ipEndPoint)
        {
            this.ipEndPoint = ipEndPoint;
            ipAddress = ipEndPoint.Address;
            port = ipEndPoint.Port;
        }
        public int Send(string message)
        {
            try
            {
                byte[] bytes = new byte[1024];

                sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(ipEndPoint);

                byte[] msg = Encoding.ASCII.GetBytes(message);

                int bytesSent = sender.Send(msg);

                sender.Shutdown(SocketShutdown.Both);

                sender.Close();

                return bytesSent;
            }
            catch (Exception e)
            {
                Exception(e, null);
                return -1;
            }
        }
    }
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SocketListener
    {
        public event EventHandler Receive;
        public event EventHandler Exception;
        private bool isRunnig;
        private readonly int port;
        private readonly IPAddress ipAddress;
        private readonly IPEndPoint ipEndPoint;
        private Socket handler;
        private Socket listener;
        public SocketListener()
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            ipAddress = host.AddressList[0];
            port = 11000;
            ipEndPoint = new IPEndPoint(ipAddress, port);
        }
        public SocketListener([NotNull]IPAddress ipAddress, int port = 11000)
        {
            this.ipAddress = ipAddress;
            this.port = port;
            ipEndPoint = new IPEndPoint(this.ipAddress, this.port);
        }
        public SocketListener([NotNull]IPEndPoint ipEndPoint)
        {
            this.ipEndPoint = ipEndPoint;
            ipAddress = ipEndPoint.Address;
            port = ipEndPoint.Port;
        }
        public void Start()
        {
            Task.Factory.StartNew(_Start);
        }
#pragma warning disable IDE1006 // Naming Styles
        private void _Start()
#pragma warning restore IDE1006 // Naming Styles
        {
            try
            {
                isRunnig = true;
                listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(ipEndPoint);
                listener.Listen(10);
                handler = listener.Accept();
                string data = null;
                while (true)
                {
                    if (!isRunnig)
                        break;
                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.Length > 0)
                    {
                        data = null;
                        Receive(data, null);
                    }
                }
            }
            catch (Exception e)
            {
                Exception(e, null);
            }
        }
        public void Stop()
        {
            try
            {
                isRunnig = false;
                listener.Dispose();
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch { }
        }
    }
}

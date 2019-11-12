using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace BTC.Tools
{
    public class SocketListener
    {
        public static readonly Encoding DefaultEncoding = Encoding.UTF8;
        public event EventHandler Receive;
        public event EventHandler Exception;
        private bool isRunnig;
        private readonly int port;
        private readonly IPAddress ipAddress;
        private readonly IPEndPoint ipEndPoint;
        private Socket handler;
        private Socket listener;
        private readonly Encoding encoding;
        public SocketListener(Encoding encoding)
        {
            this.encoding = encoding;
            IPHostEntry host = Dns.GetHostEntry("localhost");
            ipAddress = host.AddressList[0];
            port = 11000;
            ipEndPoint = new IPEndPoint(ipAddress, port);
        }
        public SocketListener(Encoding encoding, [NotNull]IPAddress ipAddress, int port = 11000)
        {
            this.encoding = encoding;
            this.ipAddress = ipAddress;
            this.port = port;
            ipEndPoint = new IPEndPoint(this.ipAddress, this.port);
        }
        public SocketListener(Encoding encoding, [NotNull]IPEndPoint ipEndPoint)
        {
            this.encoding = encoding;
            this.ipEndPoint = ipEndPoint;
            ipAddress = ipEndPoint.Address;
            port = ipEndPoint.Port;
        }
        public void Start()
        {
            isRunnig = true;
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(ipEndPoint);
            listener.Listen(10);
            Thread thread = new Thread(_Start);
            thread.Start();
        }
#pragma warning disable IDE1006 // Naming Styles
        private void _Start()
#pragma warning restore IDE1006 // Naming Styles
        {
            xcontinue:
            try
            {
                handler = listener.Accept();
                string data = null;
                while (true)
                {
                    if (!isRunnig)
                        break;
                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += encoding.GetString(bytes, 0, bytesRec);
                    if (data.Length > 0)
                    {
                        Receive?.Invoke(data, null);
                        handler = listener.Accept();
                        data = null;
                    }
                }
            }
            catch (Exception e)
            {
                Exception?.Invoke(e, null);
            }
            if (isRunnig)
                goto xcontinue;
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

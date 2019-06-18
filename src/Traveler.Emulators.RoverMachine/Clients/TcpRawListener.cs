using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Traveler.Emulators.RoverMachine.Clients
{
    public class TcpRawListener
    {
        private readonly TcpListener _tcpListener;

        public TcpRawListener(int port)
        {
            _tcpListener = new TcpListener(IPAddress.Loopback, port);
        }

        public void StartListening(IReceiver receiver)
        {
            this._tcpListener.Start();
            while (true)
            {
                using (var client = this._tcpListener.AcceptSocket())
                {
                    if (client.Connected)
                    {
                        Console.WriteLine("Connection.");
                        var size = client.ReceiveBufferSize;
                        var data = new byte[size];
                        receiver.ReceivedData(data);
                    }
                }
            }
        }

    }

    public interface IReceiver
    {
        void ReceivedData(byte[] data);
    }

    public class ConsoleReceiver : IReceiver
    {
        public void ReceivedData(byte[] data)
        {
            Console.WriteLine(Encoding.UTF8.GetString(data));
        }
    }
}

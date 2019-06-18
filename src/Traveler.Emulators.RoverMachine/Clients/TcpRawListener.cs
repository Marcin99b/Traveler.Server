using System;
using System.Linq;
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

                using (var socket = this._tcpListener.AcceptSocket())
                {
                    if (!socket.Connected)
                    {
                        Thread.Sleep(200);
                    };

                    Console.WriteLine("Connection.");

                    var size = socket.ReceiveBufferSize;
                    var buffer = new byte[size];
                    size = socket.Receive(buffer);

                    var response = buffer.Take(size).ToArray();

                    receiver.ReceivedData(response);
                }

            }
        }

        public void StopListening()
        {
            this._tcpListener.Stop();
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

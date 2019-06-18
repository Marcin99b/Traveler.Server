using System.Net.Sockets;
using System.Threading;
using Traveler.Integration.RoverMachine.Connection.Clients;
using Traveler.Integration.RoverMachine.Connection.Models;

namespace Traveler.Integration.RoverMachine.Connections.Clients
{
    public class TcpRawClient : ITcpRawClient
    {
        private readonly TcpClient _tcpClient;
        public bool IsConnected => _tcpClient.Connected;

        public TcpRawClient(IpAddress ipAddress)
        {
            this._tcpClient = new TcpClient(ipAddress.Ip, ipAddress.Port);
        }

        public void Send(byte[] bytes)
        {
            using (var stream = _tcpClient.GetStream())
            {
                while (!stream.CanWrite)
                {
                }
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        public void Dispose()
        {
            this._tcpClient.Dispose();
        }
    }
}

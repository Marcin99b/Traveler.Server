using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Traveler.Integration.RoverMachine.Connection
{
    public class TcpRawClient : IDisposable
    {
        private readonly TcpClient _tcpClient;
        public bool IsConnected => _tcpClient.Connected;

        public TcpRawClient(IpAddress ipAddress)
        {
            this._tcpClient = new TcpClient(ipAddress.Ip, ipAddress.Port);
        }

        public void Send(byte[] message)
        {
            using (var stream = _tcpClient.GetStream())
            {
                stream.Write(message, 0, message.Length);
            }
        }

        public void Dispose()
        {
            this._tcpClient.Dispose();
        }
    }
}

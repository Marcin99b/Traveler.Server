﻿using System.Net.Sockets;
using Traveler.Integration.RoverMachine.Connection.Models;

namespace Traveler.Integration.RoverMachine.Connection.Clients
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
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        public void Dispose()
        {
            this._tcpClient.Dispose();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Traveler.Integration.RoverMachine.Connection
{
    public class IpAddress
    {
        public string Ip { get; private set; }
        public int Port { get; private set; }

        public IpAddress(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }
    }
}

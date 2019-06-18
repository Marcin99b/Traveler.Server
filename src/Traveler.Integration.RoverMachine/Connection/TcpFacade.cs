using System;
using System.Collections.Generic;
using System.Text;

namespace Traveler.Integration.RoverMachine.Connection
{
    public class TcpFacade : ITcpFacade
    {
        private readonly IpAddress _ipAddress;

        public TcpFacade(IpAddress ipAddress)
        {
            _ipAddress = ipAddress;
        }

        public void Send(string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            using (var client = new TcpRawClient(this._ipAddress))
            {
                client.Send(bytes);
            }
        }

        public void Send(byte[] bytes)
        {
            using (var client = new TcpRawClient(this._ipAddress))
            {
                client.Send(bytes);
            }
        }

        public void Send(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}

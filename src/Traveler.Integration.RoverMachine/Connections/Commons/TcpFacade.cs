using System.Text;
using Newtonsoft.Json;
using Traveler.Integration.RoverMachine.Connection.Clients;
using Traveler.Integration.RoverMachine.Connection.Models;

namespace Traveler.Integration.RoverMachine.Connection.Commons
{
    public class TcpFacade : ITcpFacade
    {
        private readonly IpAddress _ipAddress;
        private readonly ITcpRawClientsFactory _tcpRawClientsFactory;

        public TcpFacade(IpAddress ipAddress, ITcpRawClientsFactory tcpRawClientsFactory)
        {
            _ipAddress = ipAddress;
            _tcpRawClientsFactory = tcpRawClientsFactory;
        }

        public void Send(ICommand command)
        {
            var json = JsonConvert.SerializeObject(command, Formatting.None);
            this.Send(json);
        }

        public void Send(string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            this.Send(bytes);
        }

        public void Send(byte[] bytes)
        {
            using (var client = this._tcpRawClientsFactory.Create(this._ipAddress))
            {
                client.Send(bytes);
            }
        }

        
    }
}

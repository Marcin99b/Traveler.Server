using Traveler.Integration.RoverMachine.Connection.Clients;
using Traveler.Integration.RoverMachine.Connection.Models;

namespace Traveler.Integration.RoverMachine.Connections.Clients
{
    public class TcpRawClientsFactory : ITcpRawClientsFactory
    {
        public ITcpRawClient Create(IpAddress ipAddress)
        {
            return new TcpRawClient(ipAddress);
        }
    }
}

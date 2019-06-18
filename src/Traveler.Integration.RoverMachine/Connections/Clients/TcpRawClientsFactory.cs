using Traveler.Integration.RoverMachine.Connection.Models;

namespace Traveler.Integration.RoverMachine.Connection.Clients
{
    public class TcpRawClientsFactory : ITcpRawClientsFactory
    {
        public ITcpRawClient Create(IpAddress ipAddress)
        {
            return new TcpRawClient(ipAddress);
        }
    }
}

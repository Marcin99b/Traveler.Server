using Traveler.Integration.RoverMachine.Connection.Models;

namespace Traveler.Integration.RoverMachine.Connections.Clients
{
    public interface ITcpRawClientsFactory
    {
        ITcpRawClient Create(IpAddress ipAddress);
    }
}

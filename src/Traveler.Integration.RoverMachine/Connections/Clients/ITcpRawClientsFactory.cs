using Traveler.Integration.RoverMachine.Connection.Models;

namespace Traveler.Integration.RoverMachine.Connection.Clients
{
    public interface ITcpRawClientsFactory
    {
        ITcpRawClient Create(IpAddress ipAddress);
    }
}

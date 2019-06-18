using Traveler.Integration.RoverMachine.Connection.Models;

namespace Traveler.Integration.RoverMachine.Connections.Services
{
    public interface IConnectionsService
    {
        void SendCommand<T>(T command, IpAddress ipAddress) where T : ICommand;
    }
}

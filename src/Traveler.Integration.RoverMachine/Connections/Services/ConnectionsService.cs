using System;
using Traveler.Integration.RoverMachine.Connection.Commons;

namespace Traveler.Integration.RoverMachine.Connections.Services
{
    public class ConnectionsService : IConnectionsService
    {
        private readonly ITcpFacade _tcpFacade;

        public ConnectionsService(ITcpFacade tcpFacade)
        {
            _tcpFacade = tcpFacade;
        }

        public void SendCommand<T>(T command) where T : ICommand
        {
            throw new NotImplementedException();
        }
    }
}

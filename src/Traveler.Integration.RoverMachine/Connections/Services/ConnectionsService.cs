using System;
using Traveler.Integration.RoverMachine.Connection.Models;
using Traveler.Integration.RoverMachine.Connections.Clients;
using Traveler.Integration.RoverMachine.Connections.Commons;

namespace Traveler.Integration.RoverMachine.Connections.Services
{
    public class ConnectionsService : IConnectionsService
    {
        private readonly ITcpRawClientsFactory _tcpRawClientsFactory;

        public ConnectionsService(ITcpRawClientsFactory tcpRawClientsFactory)
        {
            this._tcpRawClientsFactory = tcpRawClientsFactory;
        }

        public void SendCommand<T>(T command, IpAddress ipAddress) where T : ICommand
        {
            var tcpFacade = new TcpFacade(ipAddress, this._tcpRawClientsFactory);
            tcpFacade.Send(command);
        }
    }
}

using System;

namespace Traveler.Integration.RoverMachine.Connections.Clients
{
    public interface ITcpRawClient : IDisposable
    {
        void Send(byte[] bytes);
    }
}

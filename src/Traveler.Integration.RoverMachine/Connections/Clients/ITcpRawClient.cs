using System;

namespace Traveler.Integration.RoverMachine.Connection.Clients
{
    public interface ITcpRawClient : IDisposable
    {
        void Send(byte[] bytes);
    }
}

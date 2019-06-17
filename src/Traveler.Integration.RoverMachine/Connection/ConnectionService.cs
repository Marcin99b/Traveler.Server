using System;
using System.Collections.Generic;
using System.Text;

namespace Traveler.Integration.RoverMachine.Connection
{
    public class ConnectionService : IConnectionService
    {
        public void SendCommand<T>(T command) where T : ICommand
        {
            throw new NotImplementedException();
        }
    }
}

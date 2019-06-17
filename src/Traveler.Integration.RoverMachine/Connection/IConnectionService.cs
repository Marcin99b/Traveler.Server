using System;
using System.Collections.Generic;
using System.Text;

namespace Traveler.Integration.RoverMachine.Connection
{
    public interface IConnectionService
    {
        void SendCommand<T>(T command) where T : ICommand;
    }
}

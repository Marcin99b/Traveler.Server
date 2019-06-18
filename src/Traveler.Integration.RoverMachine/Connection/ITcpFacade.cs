using System;
using System.Collections.Generic;
using System.Text;

namespace Traveler.Integration.RoverMachine.Connection
{
    public interface ITcpFacade
    {
        void Send(string message);
        void Send(byte[] bytes);
        void Send(ICommand command);
    }
}

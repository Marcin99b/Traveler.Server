using System;
using System.Net.Sockets;
using Traveler.Emulators.RoverMachine.Clients;

namespace Traveler.Emulators.RoverMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            new TcpRawListener(1234).StartListening(new ConsoleReceiver());
        }
    }
}

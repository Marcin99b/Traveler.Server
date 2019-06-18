namespace Traveler.Integration.RoverMachine.Connection.Models
{
    public class IpAddress
    {
        public string Ip { get; private set; }
        public int Port { get; private set; }

        public IpAddress(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }
    }
}

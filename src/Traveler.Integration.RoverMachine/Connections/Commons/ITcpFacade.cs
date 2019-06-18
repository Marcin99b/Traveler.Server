namespace Traveler.Integration.RoverMachine.Connection.Commons
{
    public interface ITcpFacade
    {
        void Send(ICommand command);
        void Send(string message);
        void Send(byte[] bytes);
    }
}

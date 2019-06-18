namespace Traveler.Integration.RoverMachine.Connections.Services
{
    public interface IConnectionsService
    {
        void SendCommand<T>(T command) where T : ICommand;
    }
}

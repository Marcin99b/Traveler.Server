namespace Traveler.Integration.RoverMachine.Steering.Services
{
    public interface ISteeringService
    {
        /// <param name="power">value from 0 to 100</param>
        /// <param name="steering">value from -100 to 100, where values lower than zero means left side,
        /// and higher than zero right side</param>
        void UpdateSteeringInfo(int power, int steering, bool reverseGear);
    }
}

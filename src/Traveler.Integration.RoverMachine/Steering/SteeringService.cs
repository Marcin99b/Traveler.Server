using System;
using Traveler.Integration.RoverMachine.Connection;
using Traveler.Integration.RoverMachine.Steering.Commands;

namespace Traveler.Integration.RoverMachine.Steering
{
    public class SteeringService : ISteeringService
    {
        private readonly IConnectionService _connectionService;

        public SteeringService(IConnectionService connectionService)
        {
            this._connectionService = connectionService;
        }

        /// <param name="power">value from -100 to 100</param>
        /// <param name="steering">value from -100 to 100, where values lower than zero means left side,
        /// and higher than zero right side</param>
        public void UpdateSteeringInfo(int power, int steering)
        {
            power = power > 100 ? 100 : power;
            power = power < -100 ? -100 : power;

            steering = steering > 100 ? 100 : steering;
            steering = steering < -100 ? -100 : steering;

            var left = steering < 0 ? Math.Abs(steering) * power / 100 : power;
            var right = steering > 0 ? Math.Abs(steering) * power / 100 : power;
            var reverseGear = power < 0;

            var command = new UpdateSteeringInfoCommand(left, right, reverseGear);
            this._connectionService.SendCommand(command);
        }
    }
}


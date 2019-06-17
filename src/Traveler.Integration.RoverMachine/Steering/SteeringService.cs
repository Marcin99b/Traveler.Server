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

        /// <param name="power">value from 0 to 100</param>
        /// <param name="steering">value from -100 to 100, where values lower than zero means left side,
        /// and higher than zero right side</param>
        public void UpdateSteeringInfo(int power, int steering, bool reverseGear)
        {
            power = power > 100 ? 100 : power;

            steering = steering > 100 ? 100 : steering;
            steering = steering < -100 ? -100 : steering;

            var left = 0;
            var right = 0;

            if (steering < 0)
            {
                left = Math.Abs(steering) * power / 100;
                right = power;
            }

            if (steering > 0)
            {
                left = power;
                right =  Math.Abs(steering) * power / 100;
            }

            var command = new UpdateSteeringInfoCommand(left, right, reverseGear);
            this._connectionService.SendCommand(command);
        }
    }
}


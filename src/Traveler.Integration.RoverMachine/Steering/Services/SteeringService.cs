using System;
using Traveler.Integration.RoverMachine.Connections.Services;
using Traveler.Integration.RoverMachine.Steering.Commands;

namespace Traveler.Integration.RoverMachine.Steering.Services
{
    public class SteeringService : ISteeringService
    {
        private readonly IConnectionsService _connectionsService;

        public SteeringService(IConnectionsService connectionsService)
        {
            this._connectionsService = connectionsService;
        }

        /// <param name="power">value from 0 to 100</param>
        /// <param name="steering">value from -100 to 100, where values lower than zero means left side,
        /// and higher than zero right side</param>
        public void UpdateSteeringInfo(int power, int steering, bool reverseGear)
        {
            power = power > 100 ? 100 : power;

            steering = steering > 100 ? 100 : steering;
            steering = steering < -100 ? -100 : steering;

            var left = power;
            var right = power;

            if (steering < 0 && power > 0)
            {
                left = power - Math.Abs(steering) * power / 100;
            }
            else if (steering > 0 && power > 0)
            {
                right = power - Math.Abs(steering) * power / 100;
            }

            var command = new UpdateSteeringInfoCommand(left, right, reverseGear);
            this._connectionsService.SendCommand(command);
        }
    }
}


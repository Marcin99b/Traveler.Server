using System;
using System.Collections.Generic;
using System.Text;
using Traveler.Integration.RoverMachine.Steering.Commands;

namespace Traveler.Integration.RoverMachine.Steering
{
    public interface ISteeringService
    {
        /// <param name="power">value from 0 to 100</param>
        /// <param name="steering">value from -100 to 100, where values lower than zero means left side,
        /// and higher than zero right side</param>
        void UpdateSteeringInfo(int power, int steering);
    }
}

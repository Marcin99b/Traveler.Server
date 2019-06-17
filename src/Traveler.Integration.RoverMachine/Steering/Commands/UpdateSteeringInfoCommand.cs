namespace Traveler.Integration.RoverMachine.Steering.Commands
{
    public class UpdateSteeringInfoCommand : ICommand
    {
        public int LeftSidePower { get; private set; }
        public int RightSidePower { get; private set; }
        public bool ReverseGear { get; private set; }

        public UpdateSteeringInfoCommand(int leftSidePower, int rightSidePower, bool reverseGear)
        {
            LeftSidePower = leftSidePower;
            RightSidePower = rightSidePower;
            ReverseGear = reverseGear;
        }
    }
}

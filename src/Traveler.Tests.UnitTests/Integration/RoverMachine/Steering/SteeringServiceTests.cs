using Moq;
using NUnit.Framework;
using Traveler.Integration.RoverMachine.Connections.Services;
using Traveler.Integration.RoverMachine.Steering.Commands;
using Traveler.Integration.RoverMachine.Steering.Services;

namespace Traveler.Tests.UnitTests.Integration.RoverMachine.Steering
{
    [TestFixture]
    public class SteeringServiceTests
    {
        [Test]
        [TestCase(100, -50, 50, 100)]
        [TestCase(100, 50, 100, 50)]
        [TestCase(100, -100, 0, 100)]
        [TestCase(100, -200, 0, 100)]
        [TestCase(80, 50, 80, 40)]
        [TestCase(0, -50, 0, 0)]
        [TestCase(80, 0, 80, 80)]
        public void ShouldCalculateSteeringCorrectly(int power, int steering, int expectedLeft, int expectedRight)
        {
            //Arrange
            var resultCommand = new UpdateSteeringInfoCommand(0, 0, false);

            var connectionServiceMock = new Mock<IConnectionsService>();
            connectionServiceMock.Setup(x => x.SendCommand(It.IsAny<UpdateSteeringInfoCommand>()))
                .Callback<UpdateSteeringInfoCommand>(x => { resultCommand = x; });

            var steeringService = new SteeringService(connectionServiceMock.Object);

            //Act
            steeringService.UpdateSteeringInfo(power, steering, true);

            //Assert
            Assert.That(resultCommand.LeftSidePower, Is.EqualTo(expectedLeft));
            Assert.That(resultCommand.RightSidePower, Is.EqualTo(expectedRight));
        }
    }
}

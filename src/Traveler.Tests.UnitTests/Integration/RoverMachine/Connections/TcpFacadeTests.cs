using System.Text;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using Traveler.Integration.RoverMachine.Connection.Clients;
using Traveler.Integration.RoverMachine.Connection.Commons;
using Traveler.Integration.RoverMachine.Connection.Models;
using Traveler.Integration.RoverMachine.Steering.Commands;

namespace Traveler.Tests.UnitTests.Integration.RoverMachine.Connections
{
    [TestFixture]
    public class TcpFacadeTests
    {
        [Test]
        public void ShouldConvertCommandToJsonCorrectly()
        {
            //Arrange
            var testCommand = new UpdateSteeringInfoCommand(10, 10, true);

            var resultBytes = new byte[0];

            var tcpRawClientMock = new Mock<ITcpRawClient>();
            tcpRawClientMock.Setup(x => x.Send(It.IsAny<byte[]>()))
                .Callback<byte[]>(x => resultBytes = x);

            var tcpRawClientsFactoryMock = new Mock<ITcpRawClientsFactory>();
            tcpRawClientsFactoryMock.Setup(x => x.Create(It.IsAny<IpAddress>()))
                .Returns(tcpRawClientMock.Object);

            var tcpFacade = new TcpFacade(new IpAddress("127.0.0.1", 1234), tcpRawClientsFactoryMock.Object);

            //Act
            tcpFacade.Send(testCommand);

            //Assert
            var jsonTestCommand = JsonConvert.SerializeObject(testCommand, Formatting.None);
            var stringResult = Encoding.UTF8.GetString(resultBytes);
            Assert.That(stringResult, Is.EqualTo(jsonTestCommand));
        }
    }
}

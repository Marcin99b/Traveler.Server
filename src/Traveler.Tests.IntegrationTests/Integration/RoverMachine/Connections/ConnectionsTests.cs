using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Traveler.Emulators.RoverMachine.Clients;
using Traveler.Integration.RoverMachine.Connection.Clients;
using Traveler.Integration.RoverMachine.Connection.Models;
using Traveler.Integration.RoverMachine.Connections.Clients;

namespace Traveler.Tests.IntegrationTests.Integration.RoverMachine.Connections
{
    [TestFixture]
    public class ConnectionsTests
    {
        [Test]
        public void ShouldSendDataByTcpCorrectly()
        {
            //Arrange
            var result = new byte[0];
            var testData = "abc";

            var tcpReceiverMock = new Mock<IReceiver>();
            tcpReceiverMock.Setup(x => x.ReceivedData(It.IsAny<byte[]>()))
                .Callback<byte[]>(x => result = x);

            var port = 1234;

            var listener = new TcpRawListener(port);
            var client = new TcpRawClient(new IpAddress(IPAddress.Loopback.ToString(), port));

            //Act
            Task.Run(() => listener.StartListening(tcpReceiverMock.Object)).Start();
            client.Send(Encoding.UTF8.GetBytes(testData));

            //Assert
            Assert.That(result, Is.EqualTo(testData));
        }
    }
}

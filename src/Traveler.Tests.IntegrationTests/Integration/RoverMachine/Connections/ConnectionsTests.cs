using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
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
            var testData = new byte[5] { 1, 2, 3, 4, 5 };

            var tcpReceiverMock = new Mock<IReceiver>();
            tcpReceiverMock.Setup(x => x.ReceivedData(It.IsAny<byte[]>()))
                .Callback<byte[]>(x => result = x);

            var port = 1234;
            var listener = new TcpRawListener(port);

            //Act
            Task.Run(() => listener.StartListening(tcpReceiverMock.Object));

            var client = new TcpRawClient(new IpAddress(IPAddress.Loopback.ToString(), port));
            client.Send(testData);

            while (result.Length == 0)
            {
                Thread.Sleep(200);
            }

            //Assert
            Assert.That(result, Is.EqualTo(testData));
        }
    }
}

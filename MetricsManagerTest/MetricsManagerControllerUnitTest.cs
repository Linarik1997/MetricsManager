using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MetricsManagerTest
{
    public abstract class MetricsManagerControllerUnitTest
    {
        private MetricsManagerController _controller;
        public MetricsManagerControllerUnitTest()
        {
            _controller = new();
        }
        [Fact]
        public virtual void GetMetricsFromAgentByPeriod_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(10);

            //Act
            var result = _controller.GetMetricsFromAgent(agentId, fromTime, toTime);

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public virtual void GetMetricsFromClusterByPeriod_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(10);

            //Act
            var result = _controller.GetMetricsFromCluster(fromTime, toTime);

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public virtual void GetMetricsFromAgentByAllTime_ReturnsOk()
        {
            //Arrange
            var agentId = 1;

            //Act
            var result = _controller.GetMetricsFromAgent(agentId);

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public virtual void GetMetricsFromClusterByAllTime_ReturnsOk()
        {
            //Arrange

            //Act
            var result = _controller.GetMetricsFromCluster();

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

using System;
using MetricsAgent;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTest
{
    public class CpuMetricsControllerUnitTest
    {
        private CpuMetricsController _controller;
        public CpuMetricsControllerUnitTest()
        {
            _controller = new();
        }
        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(10);

            //Act
            var result = _controller.GetMetrics(fromTime, toTime);

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

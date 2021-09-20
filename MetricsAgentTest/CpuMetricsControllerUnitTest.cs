using System;
using Core.Controllers;
using Xunit;
using Moq;
using Core.Models;
using Microsoft.Extensions.Logging;
using Core.Interfaces;
using Core.DAL.Repositories;

namespace MetricsAgentTest
{
    public class CpuMetricsControllerUnitTest
    {
        private CpuMetricsController _controller;
        private Mock<IDbTest> mock;
        public CpuMetricsControllerUnitTest()
        {
            mock = new Mock<IDbTest>();
            var mocklog = new Mock<ILogger<CpuMetricsController>>();
            _controller = new CpuMetricsController(mock.Object,mocklog.Object);
        }

    }
}

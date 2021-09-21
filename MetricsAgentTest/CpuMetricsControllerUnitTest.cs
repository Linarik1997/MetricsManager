using System;
using DB.Controllers;
using Xunit;
using Moq;
using DB.Models;
using Microsoft.Extensions.Logging;
using DB.Interfaces;
using DB.DAL.Repositories;
using MertricAgentServices.Mapper;

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
            var mapper = new MetricMapper();
            _controller = new CpuMetricsController(mock.Object,mapper,mocklog.Object);
        }

    }
}

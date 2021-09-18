using System;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using Microsoft.Extensions.Logging;

namespace MetricsAgentTest
{
    public class CpuMetricsControllerUnitTest
    {
        private CpuMetricsController _controller;
        private Mock<IÑpuMetricRepository> mock;
        public CpuMetricsControllerUnitTest()
        {

            mock = new Mock<IÑpuMetricRepository>();
            var mocklog = new Mock<ILogger<CpuMetricsController>>();
            _controller = new CpuMetricsController(mock.Object,mocklog.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mock.Setup(repo => repo.Create(It.IsAny<CpuMetric>())).Verifiable();
            var result = _controller.Create(new MetricsAgent.Requests.MetricCreateRequest
            {
                Dt = TimeSpan.FromSeconds(1),
                Value = 50
            });
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }
}

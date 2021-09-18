using MetricsManager.Controllers;
using MetricsManagerTest;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class CpuMetricsControllerUnitTest:MetricsManagerControllerUnitTest
    {
        private CpuMetricsController _controller;

        public CpuMetricsControllerUnitTest()
        {
            _controller = new CpuMetricsController();
        }
    }
}

using MetricsManager.Controllers;
using MetricsManagerTest;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class RamMetricsControllerUnitTest : MetricsManagerControllerUnitTest
    {
        private RamMetricsController _controller;

        public RamMetricsControllerUnitTest()
        {
            _controller = new RamMetricsController();
        }
    }
}

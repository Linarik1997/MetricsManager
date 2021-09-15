using MetricsManager.Controllers;
using MetricsManagerTest;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class DotNetMetricsControllerUnitTest : MetricsManagerControllerUnitTest
    {
        private DotNetMetricsController _controller;

        public DotNetMetricsControllerUnitTest()
        {
            _controller = new DotNetMetricsController();
        }     
    }
}

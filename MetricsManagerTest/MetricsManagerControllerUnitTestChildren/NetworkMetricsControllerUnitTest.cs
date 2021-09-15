using MetricsManager.Controllers;
using MetricsManagerTest;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class NetworkMetricsControllerUnitTest : MetricsManagerControllerUnitTest
    {
        private NetworkMetricsController _controller;

        public NetworkMetricsControllerUnitTest()
        {
            _controller = new NetworkMetricsController();
        }
    }
}

using MetricsManager.Controllers;
using MetricsManagerTest;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class HddMetricsControllerUnitTest: MetricsManagerControllerUnitTest
    {
        private HddMetricsController _controller;

        public HddMetricsControllerUnitTest():base()
        {
            _controller = new HddMetricsController();
        }
       
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/cpu/metrics")]
    [ApiController]
    public class CpuMetricsController : MetricsManagerController
    {
        public CpuMetricsController()
        {
        }

        public CpuMetricsController(ILogger<CpuMetricsController> logger):base(logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsController");
        }
    } 
}


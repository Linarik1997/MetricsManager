using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    public class MetricsManagerController : ControllerBase
    {
        protected ILogger<MetricsManagerController> _logger;
        public MetricsManagerController() { }
        public MetricsManagerController(ILogger<MetricsManagerController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в MetricsController");
        }
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public virtual IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public virtual IActionResult GetMetricsFromCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }


        [HttpGet("agent/{agentId}")]
        public virtual IActionResult GetMetricsFromAgent([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpGet("cluster")]
        public virtual IActionResult GetMetricsFromCluster()
        {
            return Ok();
        }
    }
}

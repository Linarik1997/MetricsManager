using Core.Interfaces;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Repositories.Inherited;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/cpu/metrics")]
    [ApiController]
    public class CpuMetricsController : MetricsAgentController<CpuMetric>
    {
        private readonly IСpuMetricRepository _repo;

        private readonly  ILogger<CpuMetricsController> _logger;

        public CpuMetricsController(IСpuMetricRepository repository, ILogger<CpuMetricsController> logger): base(repository)
        {
            _logger = logger;
            _repo = repository;
            _logger.LogInformation("Logger is turned on");
        }
        [HttpPost("create")]
        public override IActionResult Create([FromBody] MetricCreateRequest request)
        {
            try
            {
                return base.Create(request);
            }
            catch(Exception e)
            {
                _logger.LogError($"Unexpected error {e.Message} " +
                    $"during MetricsAgent.Controllers.CpuMetricsController.Create method");
                return BadRequest(e);
            }
        }
        [HttpGet("all")]
        public override IActionResult GetAll()
        {
            try
            {
                return base.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError($"Unexpected error {e.Message} " +
                    $"during MetricsAgent.Controllers.CpuMetricsController.Create method");
                return BadRequest(e);
            }
        }
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            try
            {
                return base.GetMetrics(fromTime, toTime);
            }
            catch (Exception e)
            {
                _logger.LogError($"Unexpected error {e.Message} " +
                    $"during MetricsAgent.Controllers.CpuMetricsController.Create method");
                return BadRequest(e);
            }
        }

    }
}


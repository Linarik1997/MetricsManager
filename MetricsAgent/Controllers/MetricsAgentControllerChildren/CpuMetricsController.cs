using Core.Interfaces;
using Core.Models;
using Core.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Controllers
{
    [Route("api/cpu/metrics")]
    [ApiController]
    public class CpuMetricsController : MetricsAgentController<CpuMetric>
    {
        private new readonly IDbRepository<CpuMetric>  _repo;

        private readonly  ILogger<CpuMetricsController> _logger;

        public CpuMetricsController(IDbRepository<CpuMetric> repository, ILogger<CpuMetricsController> logger): base(repository)
        {
            _logger = logger;
            _repo = repository;
            _logger.LogInformation("Logger is turned on");
        }
        [HttpPost("create")]
        public override Task Create([FromBody] CpuMetric request)
        {
            try
            {
                return base.Create(request);
            }
            catch(Exception e)
            {
                _logger.LogError($"Unexpected error {e.Message} " +
                    $"during MetricsAgent.Controllers.CpuMetricsController.Create method");
                throw;
            }
        }
        [HttpGet("all")]
        public override Task<List<CpuMetric>> GetAll()
        {
            try
            {
                return base.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError($"Unexpected error {e.Message} " +
                    $"during MetricsAgent.Controllers.CpuMetricsController.Create method");
                throw;
            }
        }
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public override Task<List<CpuMetric>> GetMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            try
            {
                return base.GetMetrics(fromTime, toTime);
            }
            catch (Exception e)
            {
                _logger.LogError($"Unexpected error {e.Message} " +
                    $"during MetricsAgent.Controllers.CpuMetricsController.Create method");
                throw;
            }
        }

    }
}


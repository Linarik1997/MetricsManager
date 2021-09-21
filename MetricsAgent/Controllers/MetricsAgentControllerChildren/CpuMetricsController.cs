using DB.Interfaces;
using DB.Models;
using MertricAgentServices.Dto;
using MertricAgentServices.Mapper;
using MertricAgentServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.Controllers
{
    [Route("api/cpu/metrics")]
    [ApiController]
    public class CpuMetricsController
    {
        private readonly CpuMetricService _service;

        private readonly  ILogger<CpuMetricsController> _logger;

        public CpuMetricsController(IDbRepository<CpuMetric> repository, IMetricMapper mapper, ILogger<CpuMetricsController> logger)
        {
            _logger = logger;
            _logger.LogInformation("Logger is turned on");
            _service = new(mapper, repository);
        }
        [HttpPost]
        public async Task CreateAsync([FromBody] CpuDto request)
        {
             await _service.AddAsync(request);
        }
        [HttpGet]
        public List<CpuMetric> Get()
        {
           return _service.Get();
        }
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public Task<List<CpuMetric>> GetMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return _service.GetMetricsInTimeRange(fromTime.Ticks, toTime.Ticks);
        }
        [HttpPut("update")]
        public async Task UpdateAsync(CpuDto request)
        {
            await _service.UpdateAsync(request);
        }
        [HttpDelete]
        public async Task DeleteAsync(CpuDto request)
        {
            await _service.DeleteAsync(request);
        }

    }
}


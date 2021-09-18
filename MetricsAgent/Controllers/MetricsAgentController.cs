using Core.Interfaces;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    public abstract class MetricsAgentController<T> : ControllerBase where T: Models.T, new()
    {
        protected IRepository<T> _repo;
        public MetricsAgentController(IRepository<T> repository)
        {
            _repo = repository;
        }
        [HttpPost("create")]
        public virtual IActionResult Create([FromBody] MetricCreateRequest request)
        {
            _repo.Create(new T
            {
                Dt = request.Dt,
                Value = request.Value
            });
            return Ok();
        }
        [HttpGet("all")]
        public virtual IActionResult GetAll()
        {
            var metrics = _repo.GetAll();
            var response = new MetricResponse()
            {
                Metrics = new List<Models.T>()
            };
            foreach(var metric in metrics)
            {
                response.Metrics.Add(new T
                {
                    Dt = metric.Dt,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public virtual IActionResult GetMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            var metrics = _repo.GetInPeriod(fromTime, toTime);
            var response = new MetricResponse()
            {
                Metrics = new List<Models.T>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new T
                {
                    Dt = metric.Dt,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(metrics);
        }
    }
}

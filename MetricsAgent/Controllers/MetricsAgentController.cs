using Core.Interfaces;
using Core.Requests;
using Core.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Controllers
{
    public abstract class MetricsAgentController<T> : ControllerBase where T: Models.BaseEntity, new()
    {
        protected IDbRepository<T> _repo;
        public MetricsAgentController(IDbRepository<T> repository)
        {
            _repo = repository;
        }
        [HttpPost("create")]
        public virtual Task Create([FromBody] T request)
        {
            return _repo.AddAsync(request);
        }
        [HttpGet("all")]
        public virtual Task<List<T>> GetAll()
        {
            return _repo.GetAll().ToListAsync();
        }
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public virtual Task<List<T>> GetMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return _repo.GetAll().ToListAsync();
        }
    }
}

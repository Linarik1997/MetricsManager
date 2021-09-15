using MetricsManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private AgentStorage _storage;
        public AgentsController(AgentStorage storage)
        {
            _storage = storage;
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] Uri uri)
        {
            foreach(var agent in _storage.GetAgents())
            {
                if(agent.AgentUri == uri)
                {
                    return BadRequest($"agent with id {agent.AgentId} already exhists wit the same Uri: {uri}");
                }
            }
            _storage.AddAgent(new AgentInfo(uri));
            return Ok();
        }
        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgent([FromRoute] int agentId)
        {
            foreach (var agent in _storage.GetAgents())
            {
                if (agent.AgentId == agentId)
                {
                    agent.Enable();
                    return Ok();
                }
            }
            return BadRequest($"agent with id {agentId} is not found");
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgent([FromRoute] int agentId)
        {
            foreach (var agent in _storage.GetAgents())
            {
                if (agent.AgentId == agentId)
                {
                    agent.Disable();
                    return Ok();
                }
            }
            return BadRequest($"agent with id {agentId} is not found");
        }
        [HttpGet("list")]
        public IActionResult GetAgentsList()
        {
            return Ok(_storage.GetAgents()); 
        }
    }
}

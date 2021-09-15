using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Models
{
    public class AgentStorage
    {
        private List<AgentInfo> _agents = new List<AgentInfo>();
        public void AddAgent(AgentInfo agent)
        {
            _agents.Add(agent);
        }
        public List<AgentInfo> GetAgents() => _agents;
        public int Count { get => _agents.Count; }
    }
}

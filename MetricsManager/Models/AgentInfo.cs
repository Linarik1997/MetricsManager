using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Models
{
    public class AgentInfo
    {
        public AgentInfo(Uri uri)
        {
            AgentId = _lastId++;
            AgentUri = uri;
        }
        public void Enable()
        {
            isEnabled = true;
        }
        public void Disable()
        {
            isEnabled = false;
        }
        public int AgentId { get; set; }
        public Uri AgentUri { get; set; }

        private bool isEnabled;
        private static int _lastId { get; set; } = 0;
    }
}

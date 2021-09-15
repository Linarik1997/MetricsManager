using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models
{
    public class CpuMetric: BaseModel
    {
        public CpuMetric(): base()
        {
            var random = new Random();
            Value = random.NextDouble();
            Dt = DateTime.Now;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models
{
    public class CpuMetric: T
    {
        public CpuMetric(): base()
        {

        }
        public CpuMetric(double val, TimeSpan time): base(val, time)
        {
            Value = val;
            Dt = time;
        }
    }
}

using Core.Interfaces;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL.Repositories.Inherited
{
    public class CpuMetricsRepository : MetricRepository<CpuMetric>, IСpuMetricRepository
    {

    }
}

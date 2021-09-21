using DB.Interfaces;
using DB.Models;
using MertricAgentServices.Dto;
using MertricAgentServices.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MertricAgentServices.Services
{
    public class CpuMetricService: BaseService<CpuMetric, CpuDto>
    {
        public CpuMetricService(IMetricMapper mapper, IDbRepository<CpuMetric> repo) : base(mapper, repo)
        {

        }
        public Task<List<CpuMetric>> GetMetricsInTimeRange(long from, long to)
        {
            return Repository.Get().Where(x => x.Dt >= from && x.Dt <= to).ToListAsync();
        }

    }
}

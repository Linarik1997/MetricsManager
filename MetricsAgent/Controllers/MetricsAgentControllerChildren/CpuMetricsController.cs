using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/cpu/metrics")]
    [ApiController]
    public class CpuMetricsController : MetricsAgentController
    {

    }
}


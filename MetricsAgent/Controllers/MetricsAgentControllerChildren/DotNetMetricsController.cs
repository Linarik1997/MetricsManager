﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/dotnet/metrics")]
    [ApiController]
    public class DotNetMetricsController : MetricsAgentController
    {

    }
}

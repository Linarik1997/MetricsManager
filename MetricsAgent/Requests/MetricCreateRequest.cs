﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Requests
{
    public class MetricCreateRequest
    {
        public MetricCreateRequest()
        {
            
        }
        public TimeSpan Dt { get; set; }
        public double Value { get; set; }
    }
}

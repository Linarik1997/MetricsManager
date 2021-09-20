using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CpuMetric: BaseEntity
    {
        public double Value { get; set; }
        public double Dt { get; set; }
        public CpuMetric(): base()
        {

        }
    }
}

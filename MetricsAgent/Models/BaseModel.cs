using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models
{
    public abstract class BaseModel
    {
        public int? Id { get; set; }
        public double Value { get; set; }
        public DateTime Dt { get; set; }
        public BaseModel()
        {

        }
        public BaseModel(double val, DateTime dt)
        {
            Value = val;
            Dt = dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models
{
    public abstract class T
    {
        public virtual int? Id { get; set; }
        public virtual double Value { get; set; }
        public virtual TimeSpan Dt { get; set; }
        public T()
        {

        }
        public T(double val, TimeSpan dt)
        {
            Value = val;
            Dt = dt;
        }
    }
}

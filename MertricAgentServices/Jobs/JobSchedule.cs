using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MertricAgentServices.Jobs
{
    public class JobSchedule
    {
        public Type JobType { get; }
        public string CronExpression { get; }
        public JobSchedule(Type jobtype, string cronExpression)
        {
            JobType = jobtype;
            CronExpression = cronExpression;
        }
    }
}

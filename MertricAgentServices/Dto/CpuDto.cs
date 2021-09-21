using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MertricAgentServices.Dto
{
    public class CpuDto:BaseDto
    {
        /// <summary>
        /// % Использования ЦП
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// Время сохранения метрики
        /// </summary>
        public DateTime Dt { get; set; }
        public long Epoch { 
            get
            {
                var epoch = Dt - new DateTime(1970, 1, 1, 0, 0, 0);
                return (long)epoch.TotalSeconds;
            } 
        }
        public CpuDto() : base()
        {

        }
    }
}

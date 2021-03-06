using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Models
{
    /// <summary>
    /// Сущность Метрики нагруженности процессора
    /// </summary>
    public class CpuMetric: BaseEntity
    {
        /// <summary>
        /// % Использования ЦП
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// Время сохранения метрики
        /// </summary>
        public long Dt { get; set; }
        public CpuMetric(): base()
        {

        }
    }
}

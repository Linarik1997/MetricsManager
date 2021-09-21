using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Interfaces
{
    public interface IDbTest:IDbRepository<CpuMetric>
    {
        //Маркировочный интерфейс для тестов
    }
}

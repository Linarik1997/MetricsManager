using DB;
using DB.Interfaces;
using DB.Models;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MertricAgentServices.MetricJobs
{
    public class CpuMetricJob : IJob
    {
        //Счетчик метрики CPU
        private readonly PerformanceCounter _cpuCounter;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public CpuMetricJob(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
#pragma warning disable CA1416 // Проверка совместимости платформы
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
#pragma warning restore CA1416 // Проверка совместимости платформы
        }
        
        /// <inheritdoc/>
        public async Task Execute(IJobExecutionContext context)
        {
            //получаем значение занятости CPU
#pragma warning disable CA1416 // Проверка совместимости платформы
            var cpuUsageInPercents = Convert.ToDouble(_cpuCounter.NextValue());
#pragma warning restore CA1416 // Проверка совместимости платформы
            var time = (long)(DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                _context.Add(new CpuMetric
                {
                    Value = cpuUsageInPercents,
                    Dt = time
                });
                await _context.SaveChangesAsync();
            }
            Debug.WriteLine($"CpuMetricJob, {DateTime.Now: ddd HH:mm:ss} CpuPercent: {cpuUsageInPercents:f2}%");
        }
    }
}

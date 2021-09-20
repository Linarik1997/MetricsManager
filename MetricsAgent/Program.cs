using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Program
    {
        private const string _logConfig = @"C:\Users\l.khamitov\Desktop\Linar\Studies\ASP\ASP\MetricsAgent\Properties\nlog.config";
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog(_logConfig).GetCurrentClassLogger();
            try
            {
                logger.Debug("logger is turned on");
                CreateHostBuilder(args).Build().Run();
            }
            //����� ���� ���������� � ������ ������ ����������
            catch (Exception exception)
            {
                //NLog: ������������� ����� ����������
                logger.Error(exception, "Stopped program because of exceptrion");
                throw;
            }
            finally
            {
                //��������� �������
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        })
        .ConfigureLogging(logging =>
        {
            logging.ClearProviders();// �������� ����������� �����������
                    logging.SetMinimumLevel(LogLevel.Trace);// ������������� ����������� ������� �����������
                }).UseNLog();// ��������� ���������� nlog
    }
}

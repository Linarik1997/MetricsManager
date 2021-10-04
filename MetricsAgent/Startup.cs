using DB.DAL.Repositories;
using DB.Interfaces;
using DB.Models;
using MertricAgentServices.Mapper;
using MertricAgentServices.Jobs;
using MertricAgentServices.MetricJobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Quartz.Spi;
using Quartz;
using Quartz.Impl;
using System.Net.Http;

namespace DB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();
            // �������� ��������� ��
            services.AddDbContext<AppDbContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                 optionsBuilder => optionsBuilder.MigrationsAssembly("DB")));
            // �������� ������� �������
            services.AddScoped<IMetricMapper, MetricMapper>();

            // ��������� ������� ������
            //services.AddSingleton<IJobFactory, JobFactory>();
            //services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            // �������� ����� 
            //services.AddSingleton<CpuMetricJob>();
            //services.AddSingleton(new JobSchedule(
                //jobtype: typeof(CpuMetricJob),
                //cronExpression: "0/5 * * * * ?"));//������ 5 ������
            //services.AddHostedService<QuartzHostedService>();

            // �������� ������� �������������� � ������������  
            services.AddScoped<IDbRepository<CpuMetric>, DbRepository<CpuMetric>>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsAgent", Version = "v1" });
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MetricsAgent v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

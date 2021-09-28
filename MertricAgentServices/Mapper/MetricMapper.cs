using AutoMapper;
using DB.Interfaces;
using DB.Models;
using MertricAgentServices.Dto;
using System;

namespace MertricAgentServices.Mapper
{
    /// <summary>
    /// Базовый класс для маппера
    /// </summary>
    public class MetricMapper : IMetricMapper
    {
        public MetricMapper()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<CpuDto, CpuMetric>().
                    ForMember(src => src.Dt, opt => opt.MapFrom(src => src.Epoch)).
                    IgnoreAllPropertiesWithAnInaccessibleSetter());
            Mapper = config.CreateMapper();
        }
        public IConfigurationProvider ConfigurationProvider => Mapper.ConfigurationProvider;
        protected IMapper Mapper { get; set; }

        public T Map<T>(object source)
        {
            return Mapper.Map<T>(source);
        }

        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            Mapper.Map(source, destination);
        }
    }
}

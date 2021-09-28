using DB.Interfaces;
using DB.Models;
using MertricAgentServices.Dto;
using MertricAgentServices.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MertricAgentServices
{
    public abstract class BaseService<TEntity,TDto> 
        where TEntity:BaseEntity 
        where TDto:BaseDto
    {
        protected BaseService(IMetricMapper mapper, IDbRepository<TEntity> repository)
        {
            Mapper = mapper;
            Repository = repository;
        }
        protected IMetricMapper Mapper { get; }
        protected IDbRepository<TEntity> Repository { get; }
        public virtual async Task UpdateAsync(long id, TDto dto)
        {
            _ = dto ?? throw new ArgumentException(nameof(dto));
            var entity = Repository.Get().FirstOrDefault(s=>s.Id.Equals(id));
            Mapper.Map(dto, entity);
            await Repository.UpdateAsync(entity);
        }
        public virtual async Task AddAsync(TDto dto)
        {
            _ = dto ?? throw new ArgumentException(nameof(dto));
            var entity = Mapper.Map<TEntity>(dto);
            await Repository.AddAsync(entity);
        }
        public virtual async Task DeleteAsync(long id)
        {
            var entity = Repository.Get().FirstOrDefault(s => s.Id.Equals(id));
            if(entity == null)
            {
                throw new Exception();
            }
            await Repository.DeleteAsync(entity);
        }
        public virtual List<TEntity> Get()
        {
            return Repository.Get().ToList();
        }
    }
}

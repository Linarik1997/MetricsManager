using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IList<T> GetAll();
        T GetById(int id);
        IList<T> GetInPeriod(TimeSpan from, TimeSpan to);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}

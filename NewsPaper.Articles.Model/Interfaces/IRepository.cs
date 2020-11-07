using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPaper.Articles.Models.Interfaces
{
    public interface IRepository<T>
        where T : DomainObject, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid objGuid);
        Task<Guid> Create(T obj);
    }
}
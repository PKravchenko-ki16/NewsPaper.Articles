using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPaper.Articles.Models.Interfaces
{
    public interface IRepository<T>
        where T : DomainObject, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid articleGuid);
        //Task Update(T obj);
        //Task Delete(T obj);
        //Task Create(T obj);
    }
}
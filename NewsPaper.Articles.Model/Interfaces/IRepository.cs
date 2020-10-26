using System.Collections.Generic;

namespace NewsPaper.Articles.Models.Interfaces
{
    public interface IRepository<T>
        where T : DomainObject, new()
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(T obj);
        void Delete(T obj);
        void Create(T obj);
    }
}
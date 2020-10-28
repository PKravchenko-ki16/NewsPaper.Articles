using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NewsPaper.Articles.Models.Interfaces;

namespace NewsPaper.Articles.DAL
{
    //public class EntityRepository<T> : IRepository<T> where T : DomainObject, new()
    //{
    //    private readonly ApplicationContext _context;

    //    public EntityRepository(ApplicationContext context)
    //    {
    //        _context = context;
    //    }

    //    public IEnumerable<T> GetAll()
    //    {
    //        return _context.Set<T>();
    //    }
    //    public T Get(int id)
    //    {
    //        return _context.Set<T>().Find(id);
    //    }

    //    public void Delete(T obj)
    //    {
    //        _context.Set<T>().Remove(obj);
    //    }

    //    public void Create(T obj)
    //    {
    //        _context.Set<T>().Add(obj);
    //    }

    //    public void Update(T obj)
    //    {
    //        _context.Entry(obj).State = EntityState.Modified;
    //    }
    //}
}
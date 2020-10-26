using System;
using NewsPaper.Articles.Models;
using NewsPaper.Articles.Models.Interfaces;

namespace NewsPaper.Articles.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context = new ApplicationContext();
        private EntityRepository<Article> _article;

        public IRepository<Article> ArticlesRepository => _article ?? (_article = new EntityRepository<Article>(_context));

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Discard()
        {
            _context.Dispose();
            _context = new ApplicationContext();
        }
    }
}
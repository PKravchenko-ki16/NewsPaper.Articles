using System;
using System.Threading.Tasks;
using NewsPaper.Articles.DAL.Repository;
using NewsPaper.Articles.Models.Interfaces;

namespace NewsPaper.Articles.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context = new ApplicationContext();
        private ArticlesRepository _article;

        public IArticlesRepository ArticlesRepository
        {
            get { return _article ?? (_article = new ArticlesRepository(_context)); }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
               await _context.SaveChangesAsync();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPaper.Articles.Models;
using NewsPaper.Articles.Models.Interfaces;

namespace NewsPaper.Articles.DAL.Repository
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly ApplicationContext _context;

        public ArticlesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Article>> GetArticlesByAuthor(Guid authorGuid)
        {
            return await _context.Articles.Where(x => x.AuthorGuid == authorGuid).ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.Articles.Where(x=>x.IsArchive == false).ToListAsync();
        }

        public async Task<Article> GetByIdAsync(Guid articleGuid)
        {
            return await _context.Articles.Where(x=>x.Id == articleGuid).FirstOrDefaultAsync();
        }
    }
}
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

        public async Task<List<Article>> GetAllByAuthor(Guid authorGuid)
        {
            DateTime defaultDateTime = new DateTime();
            return await _context.Articles.Where(x => x.AuthorGuid == authorGuid && x.IsArchive == false && x.DateOfRevision > defaultDateTime).ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            DateTime defaultDateTime = new DateTime();
            return await _context.Articles.Where(x=>x.IsArchive == false && x.DateOfRevision > defaultDateTime).ToListAsync();
        }

        public async Task<Article> GetByIdAsync(Guid articleGuid)
        {
            return await _context.Articles.Where(x=>x.Id == articleGuid).FirstOrDefaultAsync();
        }

        public async Task<Article> Create(Article article)
        {
            try
            {
                _context.Articles.Add(article);
                return article;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
               await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> GoArchive(Guid articleGuid)
        {
            try
            {
               var article = await GetByIdAsync(articleGuid);
               if (article != null)
               {
                   article.IsArchive = true;
                   _context.Articles.Update(article);
                   return true;
               }
               throw new ApplicationException("Not found article in DataBase");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
               await _context.SaveChangesAsync();
            }
        }
    }
}
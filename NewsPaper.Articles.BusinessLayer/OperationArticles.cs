using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsPaper.Articles.DAL;
using NewsPaper.Articles.Models;

namespace NewsPaper.Articles.BusinessLayer
{
    public class OperationArticles
    {
        private UnitOfWork entity;
        public OperationArticles()
        {
            entity = new UnitOfWork();
        }

        public async Task<IEnumerable<Article>> GetAllArticlesAsync()
        {
            return await entity.ArticlesRepository.GetAllAsync();
        }

        public async Task<Article> GetByIdArticleAsync(Guid articleIGuid)
        {
            return await entity.ArticlesRepository.GetByIdAsync(articleIGuid);
        }

        public async Task<List<Article>> GetArticlesByAuthor(Guid authorIGuid)
        {
            return await entity.ArticlesRepository.GetArticlesByAuthor(authorIGuid);
        }

        public void Commit()
        {
            entity.SaveChanges();
        }
    }
}
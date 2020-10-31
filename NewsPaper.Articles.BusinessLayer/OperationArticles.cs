using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsPaper.Articles.DAL;
using NewsPaper.Articles.Models;
using NewsPaper.Articles.Models.Exceptions;

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
            var listArticle = await entity.ArticlesRepository.GetArticlesByAuthor(authorIGuid);
            if (!listArticle.Any())
                throw new NoArticlesFoundForAuthorAppException("This author has no articles");
            return listArticle;
        }

        public void Commit()
        {
            entity.SaveChanges();
        }
    }
}
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
        private readonly UnitOfWork _entity;
        public OperationArticles()
        {
            _entity = new UnitOfWork();
        }

        public async Task<IEnumerable<Article>> GetAllArticlesAsync()
        {
            return await _entity.ArticlesRepository.GetAllAsync();
        }

        public async Task<Article> GetByIdArticleAsync(Guid articleIGuid)
        {
            return await _entity.ArticlesRepository.GetByIdAsync(articleIGuid);
        }

        public async Task<List<Article>> GetArticlesByAuthor(Guid authorGuid)
        {
            var listArticle = await _entity.ArticlesRepository.GetAllByAuthor(authorGuid);
            if (!listArticle.Any())
                throw new NoArticlesFoundForAuthorAppException("This author has no articles");
            return listArticle;
        }

        public async Task<Guid> CreateArticle(Article article)
        {
            var guidCreatedArticle = await _entity.ArticlesRepository.Create(article);
            if (guidCreatedArticle != null)
                throw new FailedToCreateArticleAppException("Failed to create article");
            return guidCreatedArticle;
        }
        
        public async Task<bool> GoArchive(Guid articleGuid)
        {
            var isArchive = await _entity.ArticlesRepository.GoArchive(articleGuid);
            if (!isArchive)
                throw new FailedTransferToArchiveAppException("Failed transfer to archive");
            return true;
        }
    }
}
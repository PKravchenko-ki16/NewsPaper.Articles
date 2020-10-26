using System.Collections.Generic;
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

        public IEnumerable<Article> GetAllArticles()
        {
            return entity.ArticlesRepository.GetAll();
        }

        public void CreateArticle(Article article)
        {
            entity.ArticlesRepository.Create(article);
        }

        public Article GetByIdArticle(int id)
        {
            return entity.ArticlesRepository.Get(id);
        }

        public void DeleteArticle(Article article)
        {
            entity.ArticlesRepository.Delete(article);
        }

        public void UpdateArticle(Article article)
        {
            entity.ArticlesRepository.Update(article);
        }

        public void Commit()
        {
            entity.SaveChanges();
        }
    }
}
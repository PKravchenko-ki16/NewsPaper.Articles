using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPaper.Articles.Models.Interfaces
{
    public interface IArticlesRepository : IRepository<Article>
    {
        Task<List<Article>> GetArticlesByAuthor(Guid authorGuid);
    }
}
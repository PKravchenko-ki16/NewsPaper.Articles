using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPaper.Articles.Models.Interfaces
{
    public interface IArticlesRepository : IRepository<Article>
    {
        Task<List<Article>> GetAllByAuthor(Guid authorGuid);
        Task<bool> GoArchive(Guid articleGuid);
    }
}
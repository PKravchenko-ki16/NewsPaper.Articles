using System.Threading.Tasks;

namespace NewsPaper.Articles.Models.Interfaces
{
    public interface IUnitOfWork
    {
        IArticlesRepository ArticlesRepository { get; }
        Task<bool> SaveChangesAsync();
        void Discard();
    }
}
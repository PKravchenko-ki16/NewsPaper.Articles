namespace NewsPaper.Articles.Models.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Article> ArticlesRepository { get; }
        bool SaveChanges();
        void Discard();
    }
}
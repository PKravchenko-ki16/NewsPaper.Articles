namespace NewsPaper.Articles.Models.Interfaces
{
    public interface IUnitOfWork
    {
        IArticlesRepository ArticlesRepository { get; }
        bool SaveChanges();
        void Discard();
    }
}
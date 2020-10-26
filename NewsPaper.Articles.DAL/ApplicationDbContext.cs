using Microsoft.EntityFrameworkCore;
using NewsPaper.Articles.Models;

namespace NewsPaper.Articles.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-U4JR3LV;Database=NewsPaperArticlesDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
        private InitializerEntity initializerEntity = new InitializerEntity();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasKey(u => u.Id);
            modelBuilder.Entity<Article>().HasData(initializerEntity.GetEntityArticle());
        }
    }
}
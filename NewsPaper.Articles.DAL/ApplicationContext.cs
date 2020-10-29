using Microsoft.EntityFrameworkCore;
using NewsPaper.Articles.Models;

namespace NewsPaper.Articles.DAL
{
    public sealed class ApplicationContext : DbContext
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FakeInitializerEntity.Init(10);
            modelBuilder.Entity<Article>().HasKey(u => u.Id);
            modelBuilder.Entity<Article>().HasData(FakeInitializerEntity.Article);
        }
    }
}
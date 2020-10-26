using System;
using System.Collections.Generic;
using System.Text;
using NewsPaper.Articles.Models;

namespace NewsPaper.Articles.DAL
{
    class InitializerEntity
    {
        private List<Article> _listArticle = new List<Article>() { };

        private Random _rng = new Random();
        private Random _rngInt = new Random((int)DateTime.Now.Ticks);

        public List<Article> GetEntityArticle()
        {
            RandomArticle(10);
            return _listArticle;
        }

        private void RandomArticle(int count)
        {
            for (var i = 0; i < count; i++)
            {
                Article article = new Article(Guid.NewGuid(), RandomString(30), RandomString(100), RandomString(1000), RandomString(10), Guid.NewGuid(), Guid.NewGuid(), RandomDateTime());
                _listArticle.Add(article);
            }

        }

        DateTime RandomDateTime()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_rng.Next(range));
        }

        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * _rngInt.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
using System;

namespace NewsPaper.Articles.ViewModels
{
    public class ArticleViewModelApi 
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public int Rating { get; set; }

        public string Text { get; set; }

        public string NikeNameAuthor { get; set; }

        public DateTime DateOfRevision { get; set; }
    }
}
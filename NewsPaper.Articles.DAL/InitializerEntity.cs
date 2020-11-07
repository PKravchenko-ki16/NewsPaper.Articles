using System;
using System.Collections.Generic;
using AutoMapper;
using Bogus;
using Bogus.DataSets;
using NewsPaper.Articles.Models;

namespace NewsPaper.Articles.DAL
{
    public static class FakeInitializerEntity
    {
        private static readonly IMapper _mapper;

        public static List<Article> Article = new List<Article>();

        public static void Init(int count)
        {
            var articleFaker = new Faker<Article>("ru")
                .RuleFor(x => x.Title, f => f.Lorem.Sentence(5))
                .RuleFor(x => x.Description, f => f.Lorem.Paragraph())
                .RuleFor(x => x.Text, f => f.Lorem.Text())
                .RuleFor(x => x.Picture, f => f.Image.PlaceholderUrl(400, 300))
                .RuleFor(x => x.Rating, f => f.Random.Byte(1, 100))
                .RuleFor(x => x.NikeNameAuthor, f => f.Name.FirstName(Name.Gender.Male))
                .RuleFor(x => x.NikeNameEditor, f => f.Name.FirstName(Name.Gender.Male))
                .RuleFor(x => x.AuthorGuid, f => Guid.NewGuid())
                .RuleFor(x => x.EditorGuid, f => Guid.NewGuid())
                .RuleFor(x => x.IsArchive, f => f.Random.Bool())
                .RuleFor(x => x.IsRevision, true)
                .RuleFor(x => x.DateOfWriting,
                    f => f.Date.Between(new DateTime(2008, 5, 1), new DateTime(2018, 5, 1)))
                .RuleFor(x => x.DateOfRevision,
                    f => f.Date.Between(new DateTime(2018, 5, 2), new DateTime(2020, 10, 1)));

            var articles = articleFaker.Generate(count);

            InitIdArticles(count);
            SetIdArticles(articles);
        }

        private static void InitIdArticles(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Article.Add(new Article(Guid.NewGuid()));
            }
        }

        private static void SetIdArticles(List<Article> articles)
        {
            Article = _mapper.Map<List<Article>>(articles);
        }
    }
}
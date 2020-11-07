using System;
using NewsPaper.Articles.Mappings.Base;
using NewsPaper.Articles.Models;
using NewsPaper.MassTransit.Contracts.DTO.Models.Articles;

namespace NewsPaper.Articles.Mappings
{
    public class MappingArticles : MapperConfigurationBase
    {
        public MappingArticles()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>()
                .ConstructUsing(s => new Article(Guid.NewGuid()));
        }
    }
}

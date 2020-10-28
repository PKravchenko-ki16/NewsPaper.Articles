using NewsPaper.Articles.Mappings.Base;
using NewsPaper.Articles.Models;
using NewsPaper.MassTransit.Contracts.DTO.Models;

namespace NewsPaper.Articles.Mappings
{
    public class MappingArticles : MapperConfigurationBase
    {
        public MappingArticles()
        {
            CreateMap<Article, ArticlesDto>();
        }
    }
}

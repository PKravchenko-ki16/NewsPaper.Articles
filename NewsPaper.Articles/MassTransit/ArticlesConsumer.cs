using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using NewsPaper.Articles.BusinessLayer;
using NewsPaper.MassTransit.Contracts.DTO;
using System.Collections.Generic;

namespace NewsPaper.Articles.MassTransit
{
    public class ArticlesConsumer : IConsumer<ArticlesByIdAutorRequestDto>
    {
        private readonly IMapper _mapper;
        public ArticlesConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        private OperationArticles _articles = new OperationArticles();

        public async Task Consume(ConsumeContext<ArticlesByIdAutorRequestDto> context)
        {
            var listArticles = await _articles.GetArticlesByAuthor(context.Message.AuthorGuid);
            var responseArticlesDto = _mapper.Map<IEnumerable<ArticlesDto>>(listArticles);
            await context.RespondAsync(responseArticlesDto);
        }
    }
}

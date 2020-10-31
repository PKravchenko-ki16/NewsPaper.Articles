using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using NewsPaper.Articles.BusinessLayer;
using System.Collections.Generic;
using NewsPaper.Articles.Models.Exceptions;
using NewsPaper.MassTransit.Contracts.DTO.Exception.Articles;
using NewsPaper.MassTransit.Contracts.DTO.Models.Articles;
using NewsPaper.MassTransit.Contracts.DTO.Requests.Articles;
using NewsPaper.MassTransit.Contracts.DTO.Responses.Articles;

namespace NewsPaper.Articles.MassTransit
{
    public class ArticlesConsumer : IConsumer<ArticlesByIdAuthorRequestDto>
    {
        private readonly OperationArticles _operationArticles;
        private readonly IMapper _mapper;
        public ArticlesConsumer(IMapper mapper, OperationArticles operationArticles)
        {
            _mapper = mapper;
            _operationArticles = operationArticles;
        }

        public async Task Consume(ConsumeContext<ArticlesByIdAuthorRequestDto> context)
        {
            var listArticles = await _operationArticles.GetArticlesByAuthor(context.Message.AuthorGuid);
            if (listArticles.Count == 0)
            {
                await context.RespondAsync( new NoArticlesFoundForAuthor
                {
                    AuthorGuid = context.Message.AuthorGuid,
                    MassageException = $"This author has no articles {context.Message.AuthorGuid}"
                });
            }
            else
            {
                var articles = _mapper.Map<IEnumerable<ArticlesDto>>(listArticles);
                await context.RespondAsync(new ArticlesResponseDto
                {
                    ArticlesDto = articles
                });
            }
        }
    }
}

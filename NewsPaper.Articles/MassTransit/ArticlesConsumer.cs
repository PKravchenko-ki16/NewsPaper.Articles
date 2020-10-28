using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using NewsPaper.Articles.BusinessLayer;
using System.Collections.Generic;
using NewsPaper.MassTransit.Contracts.DTO.Models;
using NewsPaper.MassTransit.Contracts.DTO.Requests;
using NewsPaper.MassTransit.Contracts.DTO.Responses;

namespace NewsPaper.Articles.MassTransit
{
    public class ArticlesConsumer : IConsumer<ArticlesByIdAuthorRequestDto>
    {
        private readonly IMapper _mapper;
        public ArticlesConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        private readonly OperationArticles _articles = new OperationArticles();

        public async Task Consume(ConsumeContext<ArticlesByIdAuthorRequestDto> context)
        {
            var listArticles = await _articles.GetArticlesByAuthor(context.Message.AuthorGuid);
            var articles = _mapper.Map<IEnumerable<ArticlesDto>>(listArticles);
            await context.RespondAsync(new ArticlesResponseDto
            {
                ArticlesDto = articles
            });
        }
    }
}

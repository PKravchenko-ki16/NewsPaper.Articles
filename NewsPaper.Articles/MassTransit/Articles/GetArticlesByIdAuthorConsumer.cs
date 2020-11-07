using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using NewsPaper.Articles.BusinessLayer;
using NewsPaper.Articles.Models.Exceptions;
using NewsPaper.MassTransit.Contracts.DTO.Exception.Articles;
using NewsPaper.MassTransit.Contracts.DTO.Models.Articles;
using NewsPaper.MassTransit.Contracts.DTO.Requests.Articles;
using NewsPaper.MassTransit.Contracts.DTO.Responses.Articles;

namespace NewsPaper.Articles.MassTransit.Articles
{
    public class GetArticlesByIdAuthorConsumer : IConsumer<ArticlesByIdAuthorRequestDto>
    {
        private readonly OperationArticles _operationArticles;
        private readonly IMapper _mapper;
        public GetArticlesByIdAuthorConsumer(IMapper mapper, OperationArticles operationArticles)
        {
            _mapper = mapper;
            _operationArticles = operationArticles;
        }

        public async Task Consume(ConsumeContext<ArticlesByIdAuthorRequestDto> context)
        {
            try
            {
                var listArticles = await _operationArticles.GetArticlesByAuthor(context.Message.AuthorGuid);
                var articles = _mapper.Map<IEnumerable<ArticleDto>>(listArticles);
                await context.RespondAsync(new ArticlesByIdAuthorResponseDto()
                {
                    ArticlesDto = articles
                });
            }
            catch (NoArticlesFoundForAuthorAppException e)
            {
                await context.RespondAsync(new NoArticlesFound
                {
                    CodeException = e.CodeException,
                    MassageException = $"{e.Message}"
                });
            }
            catch (Exception e)
            {
                await context.RespondAsync(new NoArticlesFound
                {
                    MassageException = $"{e.Message}"
                });
            }
        }
    }
}

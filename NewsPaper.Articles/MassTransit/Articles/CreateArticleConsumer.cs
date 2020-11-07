using System;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using NewsPaper.Articles.BusinessLayer;
using NewsPaper.Articles.Models;
using NewsPaper.Articles.Models.Exceptions;
using NewsPaper.MassTransit.Contracts.DTO.Exception.Articles;
using NewsPaper.MassTransit.Contracts.DTO.Requests.Articles;
using NewsPaper.MassTransit.Contracts.DTO.Responses.Articles;

namespace NewsPaper.Articles.MassTransit.Articles
{
    public class CreateArticleConsumer : IConsumer<ArticleCreateRequestDto>
    {
        private readonly OperationArticles _operationArticles;
        private readonly IMapper _mapper;
        public CreateArticleConsumer(IMapper mapper, OperationArticles operationArticles)
        {
            _mapper = mapper;
            _operationArticles = operationArticles;
        }

        public async Task Consume(ConsumeContext<ArticleCreateRequestDto> context)
        {
            try
            {
                var article = _mapper.Map<Article>(context.Message.Article);
                var result = await _operationArticles.CreateArticle(article);
                await context.RespondAsync(new ArticleCreateResponseDto
                {
                    ArticleGuid = result
                });
            }
            catch (FailedToCreateArticleAppException e)
            {
                await context.RespondAsync(new FailedToCreateArticle
                {
                    CodeException = e.CodeException,
                    MassageException = $"{e.Message}"
                });
            }
            catch (Exception e)
            {
                await context.RespondAsync(new FailedToCreateArticle
                {
                    MassageException = $"{e.Message}"
                });
            }
        }
    }
}
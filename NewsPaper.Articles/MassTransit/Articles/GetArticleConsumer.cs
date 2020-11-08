using System;
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
    public class GetArticleConsumer : IConsumer<ArticleByIdRequestDto>
    {
        private readonly OperationArticles _operationArticles;
        private readonly IMapper _mapper;
        public GetArticleConsumer(IMapper mapper, OperationArticles operationArticles)
        {
            _mapper = mapper;
            _operationArticles = operationArticles;
        }

        public async Task Consume(ConsumeContext<ArticleByIdRequestDto> context)
        {
            try
            {
                var result = await _operationArticles.GetByIdArticleAsync(context.Message.ArticleGuid);
                var article = _mapper.Map<ArticleDto>(result);
                await context.RespondAsync(new ArticleResponseDto
                {
                    ArticleDto = article
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

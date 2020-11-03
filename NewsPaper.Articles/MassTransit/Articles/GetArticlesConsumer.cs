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
    public class GetArticlesConsumer : IConsumer<ArticlesRequestDto>
    {
        private readonly OperationArticles _operationArticles;
        private readonly IMapper _mapper;
        public GetArticlesConsumer(IMapper mapper, OperationArticles operationArticles)
        {
            _mapper = mapper;
            _operationArticles = operationArticles;
        }

        public async Task Consume(ConsumeContext<ArticlesRequestDto> context)
        {
            try
            {
                var result = await _operationArticles.GetAllArticlesAsync();
                var articles = _mapper.Map<IEnumerable<ArticleDto>>(result);
                await context.RespondAsync(new ArticlesResponseDto
                {
                    ArticlesDto = articles
                });
            }
            catch (NoArticlesFoundForAuthorAppException e)
            {
                await context.RespondAsync(new NoArticlesFoundForAuthor()
                {
                    CodeException = e.CodeException,
                    MassageException = $"{e.Message}"
                });
            }
            catch (Exception e)
            {
                await context.RespondAsync(new NoArticlesFoundForAuthor
                {
                    MassageException = $"{e.Message}"
                });
            }
        }
    }
}

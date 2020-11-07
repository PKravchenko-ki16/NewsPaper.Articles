using System;
using System.Threading.Tasks;
using MassTransit;
using NewsPaper.Articles.BusinessLayer;
using NewsPaper.Articles.Models.Exceptions;
using NewsPaper.MassTransit.Contracts.DTO.Exception.Articles;
using NewsPaper.MassTransit.Contracts.DTO.Requests.Articles;
using NewsPaper.MassTransit.Contracts.DTO.Responses.Articles;

namespace NewsPaper.Articles.MassTransit.Articles
{
    public class GoArchiveArticleConsumer : IConsumer<ArticleGoArchiveRequestDto>
    {
        private readonly OperationArticles _operationArticles;
        public GoArchiveArticleConsumer(OperationArticles operationArticles)
        {
            _operationArticles = operationArticles;
        }

        public async Task Consume(ConsumeContext<ArticleGoArchiveRequestDto> context)
        {
            try
            {
                var result = await _operationArticles.GoArchive(context.Message.ArticleGuid);
                if (result)
                {
                    await context.RespondAsync(new ArticleGoArchiveResponseDto
                    {
                        ArticleGuid = context.Message.ArticleGuid
                    });
                }
                else
                {
                    throw new FailedTransferToArchiveAppException();
                }
            }
            catch (FailedTransferToArchiveAppException e)
            {
                await context.RespondAsync(new FailedTransferToArchive
                {
                    CodeException = e.CodeException,
                    MassageException = $"{e.Message}"
                });
            }
            catch (Exception e)
            {
                await context.RespondAsync(new FailedTransferToArchive
                {
                    MassageException = $"{e.Message}"
                });
            }
        }
    }
}
# NewsPaper.Articles

It is an ASP.NET Core 3.1 based microservice using RabbitMQ with MassTransit, EntityFramework Core with MS SQL Server as well as Bogus, AutoMapper, etc.

## Project structure

- BusinessLayer

The business layer is responsible for performing operations on data coming from the DAL (Data Access Layer).
- DAL

The Data Access Layer is responsible for providing simplified and data access. Uses Models to access the database.
- Models

The Model Layer is responsible for storing data models for accessing the database.
- Accounts (directly the web project itself)

## Consumer 

Uses `Multiple Response Types` technique

```C#
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
```

## ConfigureServices MassTransit for RabbitMq

Consumer is added to MassTransit in ConfigureServicesMassTransitRabbitMq

```C#
public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
{
    var section = configuration.GetSection("MassTransit");
    ConfigureServicesMassTransit.ConfigureServices(services, configuration, new MassTransitConfiguration()
    {
        IsDebug = section.GetValue<bool>("IsDebug"),
        ServiceName = "Articles",
        Configurator = busMassTransit => 
        {
            busMassTransit.AddConsumer<GetArticlesByIdAuthorConsumer>();
            busMassTransit.AddConsumer<GetArticlesConsumer>();
            busMassTransit.AddConsumer<GetArticleConsumer>();
            busMassTransit.AddConsumer<GoArchiveArticleConsumer>();
            busMassTransit.AddConsumer<CreateArticleConsumer>(); 
        }
    });
}
```
## Links to project repositories
- :white_check_mark:[NewsPaper Review](https://github.com/PKravchenko-ki16/NewsPaper)
- :white_check_mark:[NewsPaper.MassTransit.Configuration](https://github.com/PKravchenko-ki16/NewsPaper.MassTransit.Configuration)
- :white_check_mark:[NewsPaper.MassTransit.Contracts](https://github.com/PKravchenko-ki16/NewsPaper.MassTransit.Contracts)
- :black_square_button:[NewsPaper.IdentityServer]()
- :white_check_mark:[Newspaper.GateWay](https://github.com/PKravchenko-ki16/Newspaper.GateWay)
- :white_check_mark:[NewsPaper.Accounts](https://github.com/PKravchenko-ki16/NewsPaper.Accounts)
- :white_check_mark:NewsPaper.Articles
- :white_check_mark:[NewsPaper.GatewayClientApi](https://github.com/PKravchenko-ki16/NewsPaper.GatewayClientApi)
- :white_check_mark:[NewsPaper.Client.Mvc](https://github.com/PKravchenko-ki16/NewsPaper.Client.Mvc)

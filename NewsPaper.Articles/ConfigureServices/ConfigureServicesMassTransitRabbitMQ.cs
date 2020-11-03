using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsPaper.Articles.MassTransit.Articles;
using NewsPaper.MassTransit.Configuration;
using ConfigureServicesMassTransit = NewsPaper.MassTransit.Configuration.ConfigureServicesMassTransit;

namespace NewsPaper.Articles.ConfigureServices
{
    public class ConfigureServicesMassTransitRabbitMq
    {
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
                }
            });
        }
    }
}

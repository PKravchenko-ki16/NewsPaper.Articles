using Microsoft.Extensions.DependencyInjection;
using NewsPaper.Articles.BusinessLayer;
using NewsPaper.Articles.DAL;

namespace NewsPaper.Articles.Infrastructure.DependencyInjection
{
    public class DependencyContainerRegistrations
    {
        public static void Common(IServiceCollection services)
        {
            services.AddTransient<ApplicationContext>();
            services.AddTransient<OperationArticles>();
        }
    }
}

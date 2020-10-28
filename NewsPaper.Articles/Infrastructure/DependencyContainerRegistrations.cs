using Microsoft.Extensions.DependencyInjection;
using NewsPaper.Articles.DAL;

namespace NewsPaper.Articles.Infrastructure
{
    public class DependencyContainerRegistrations
    {
        public static void Common(IServiceCollection services)
        {
            services.AddTransient<ApplicationContext>();
            //services.AddTransient<OperationArticles>();
        }
    }
}

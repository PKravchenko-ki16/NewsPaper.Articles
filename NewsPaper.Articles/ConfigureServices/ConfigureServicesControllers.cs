using Microsoft.Extensions.DependencyInjection;

namespace NewsPaper.Articles.ConfigureServices
{
    public class ConfigureServicesControllers
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }
    }
}

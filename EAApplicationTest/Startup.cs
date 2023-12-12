using EAApplicationTest.Pages;
using EAFramework.Config;
using EAFramework.Driver;
using Microsoft.Extensions.DependencyInjection;

namespace EAApplicationTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton(ConfigReader.ReadConfig())
                .AddScoped<IDriverFixture, DriverFixture>()
                .AddScoped<IDriverWait, DriverWait>()
                .AddScoped<IHomePage, HomePage>()
                .AddScoped<IProductPage, ProductPage>();
        }
    }
}
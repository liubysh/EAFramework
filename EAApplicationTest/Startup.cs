using EAFramework.Config;
using EAFramework.Driver;
using Microsoft.Extensions.DependencyInjection;

namespace EAApplicationTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(ConfigReader.ReadConfig());
            services.AddScoped<IDriverFixture, DriverFixture>();
            services.AddScoped<IDriverWait, DriverWait>();
        }
    }
}
using EAFramework.Config;
using EAFramework.Driver;
using EOSpecFlowTest.Pages;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;

namespace EOSpecFlowTest;

public class Startup
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();
    
        services
            .AddSingleton(ConfigReader.ReadConfig())
            .AddScoped<IDriverFixture, DriverFixture>()
            .AddScoped<IDriverWait, DriverWait>()
            .AddScoped<IHomePage, HomePage>()
            .AddScoped<IProductPage, ProductPage>();
       
        return services;
    }
}
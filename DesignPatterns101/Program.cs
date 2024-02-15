using DesignPatterns101.Behavioral_Patterns;
using DesignPatterns101.Creational_Patterns;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IConfiguration settings = null;
var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        // Creates the SingletonExample Object. This will be reused everytime the solution wants to call this service.
        SingletonExample singleton = SingletonExample.GetInstance();
        services.AddSingleton<SingletonExample>(singleton);

        WeatherStation weatherStation = new WeatherStation();
        services.AddSingleton<WeatherStation>(weatherStation);
    })
    .Build();

host.Run();

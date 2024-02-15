using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DesignPatterns101.Behavioral_Patterns
{
    public class ObserverFunctionHTTP
    {
        private readonly ILogger<ObserverFunctionHTTP> _logger;
        private readonly WeatherStation _weatherStation;
        private readonly Random randGenerator;

        public ObserverFunctionHTTP(ILogger<ObserverFunctionHTTP> logger, WeatherStation weatherStation)
        {
            _logger = logger;
            _weatherStation = weatherStation;
            randGenerator = new Random();
        }

        [Function("ObserverFunctionHTTP")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "behavioral/observer/startLoop")] HttpRequest req)
        {
            DisplayDevice mobileApp = new DisplayDevice("Mobile App", _logger);
            DisplayDevice website = new DisplayDevice("Website", _logger);
            DisplayDevice dedicatedDevice = new DisplayDevice("Dedicated Device", _logger);

            string[] weatherTypes = { "Sunny", "Rainy", "Cloudy", "Foggy", "Sunny", "Thunder", "Cloudy", "Sunny", "Rainy", "Rainy", "Sunny", "Sunny" };

            _weatherStation.AddObserver(mobileApp);
            _weatherStation.AddObserver(website);
            _weatherStation.AddObserver(dedicatedDevice);

            while (_weatherStation.ShouldKeepRunning())
            {
                _weatherStation.SetWeather(weatherTypes[randGenerator.Next(0, weatherTypes.Length-1)]);
                Sleep10Seconds(_logger);
            }
            _weatherStation.RemoveObserver("Mobile App");
            _weatherStation.RemoveObserver("Website");
            _weatherStation.RemoveObserver("Dedicated Device");

            return new OkObjectResult("Demo Finished");
        }

        private static void Sleep10Seconds(ILogger log)
        {
            log.LogInformation("Weather Update in 10 seconds:");
            Thread.Sleep(1000);
            log.LogInformation("10");
            Thread.Sleep(1000);
            log.LogInformation("9");
            Thread.Sleep(1000);
            log.LogInformation("8");
            Thread.Sleep(1000);
            log.LogInformation("7");
            Thread.Sleep(1000);
            log.LogInformation("6");
            Thread.Sleep(1000);
            log.LogInformation("5");
            Thread.Sleep(1000);
            log.LogInformation("4");
            Thread.Sleep(1000);
            log.LogInformation("3");
            Thread.Sleep(1000);
            log.LogInformation("2");
            Thread.Sleep(1000);
            log.LogInformation("1");
            Thread.Sleep(1000);
        }
    }
}

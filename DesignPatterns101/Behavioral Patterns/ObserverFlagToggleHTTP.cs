using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DesignPatterns101.Behavioral_Patterns
{
    public class ObserverFlagToggleHTTP
    {
        private readonly ILogger<ObserverFlagToggleHTTP> _logger;
        private readonly WeatherStation _weatherStation;

        public ObserverFlagToggleHTTP(ILogger<ObserverFlagToggleHTTP> logger, WeatherStation weatherStation)
        {
            _logger = logger;
            _weatherStation = weatherStation;
        }

        [Function("ObserverFlagToggleHTTP")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "behavioral/observer/toggleFlag")] HttpRequest req)
        {
            _weatherStation.ToggleRunFlag();
            return new OkObjectResult($"Toggled flag to now be: {_weatherStation.ShouldKeepRunning()}");
        }
    }
}

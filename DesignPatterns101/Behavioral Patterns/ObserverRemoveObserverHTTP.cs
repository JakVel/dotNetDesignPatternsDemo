using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DesignPatterns101.Behavioral_Patterns
{
    public class ObserverRemoveObserverHTTP
    {
        private readonly ILogger<ObserverFunctionHTTP> _logger;
        private readonly WeatherStation _weatherStation;

        public ObserverRemoveObserverHTTP(ILogger<ObserverFunctionHTTP> logger, WeatherStation weatherStation)
        {
            _logger = logger;
            _weatherStation = weatherStation;
        }

        [Function("ObserverRemoveObserverHTTP")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "behavioral/observer/removeObserver/{observerName}")] HttpRequest req, string observerName)
        {
            _weatherStation.RemoveObserver(observerName);
            return new OkObjectResult($"Removed Observer with name: {observerName}");
        }
    }
}

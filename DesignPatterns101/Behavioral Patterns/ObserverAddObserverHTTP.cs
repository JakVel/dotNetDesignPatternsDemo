using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DesignPatterns101.Behavioral_Patterns
{
    public class ObserverAddObserverHTTP
    {
        private readonly ILogger<ObserverFunctionHTTP> _logger;
        private readonly WeatherStation _weatherStation;

        public ObserverAddObserverHTTP(ILogger<ObserverFunctionHTTP> logger, WeatherStation weatherStation)
        {
            _logger = logger;
            _weatherStation = weatherStation;
        }

        [Function("ObserverAddObserverHTTP")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "behavioral/observer/addObserver/{observerName}")] HttpRequest req, string observerName)
        {
            DisplayDevice newObserver = new DisplayDevice(observerName, _logger);
            _weatherStation.AddObserver(newObserver);
            return new OkObjectResult($"Added Observer with name: {observerName}");
        }
    }
}

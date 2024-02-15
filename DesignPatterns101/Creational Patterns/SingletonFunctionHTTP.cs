using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DesignPatterns101.Creational_Patterns
{
    public class SingletonFunctionHTTP
    {
        private readonly ILogger<SingletonFunctionHTTP> _logger;
        private readonly SingletonExample _singletonFromProgram;
        private readonly SingletonExample _singletonFromGetInstanceLocally;

        public SingletonFunctionHTTP(ILogger<SingletonFunctionHTTP> logger, SingletonExample singleton)
        {
            _logger = logger;
            _singletonFromProgram = singleton;
            _singletonFromGetInstanceLocally = SingletonExample.GetInstance();
        }

        [Function("SingletonFunctionHTTP")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "creational/singleton")] HttpRequest req)
        {
            _logger.LogWarning(_singletonFromProgram.DoSomething());
            _logger.LogWarning(_singletonFromGetInstanceLocally.DoSomething());
            SingletonExample singletonFromWithinMethod = SingletonExample.GetInstance();
            _logger.LogWarning(singletonFromWithinMethod.DoSomething());
            return new OkObjectResult("We did something!");
        }
    }
}

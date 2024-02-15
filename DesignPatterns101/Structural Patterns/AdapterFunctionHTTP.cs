using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DesignPatterns101.Structural_Patterns
{
    public class AdapterFunctionHTTP
    {
        private readonly ILogger<AdapterFunctionHTTP> _logger;

        public AdapterFunctionHTTP(ILogger<AdapterFunctionHTTP> logger)
        {
            _logger = logger;
        }

        [Function("AdapterFunctionHTTP")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "structural/adapter")] HttpRequest req)
        {
            // Using Adapter
            NewService newService = new NewService();
            ILegacyService legacyServiceAdapter = new Adapter(newService);

            // Client invokes LegacyRequest without knowing about NewService
            string resultString = legacyServiceAdapter.LegacyRequest(_logger);
            return new OkObjectResult(resultString);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DesignPatterns101.Creational_Patterns
{
    public class FactoryMethodFunctionHTTP
    {
        private readonly ILogger<FactoryMethodFunctionHTTP> _logger;

        public FactoryMethodFunctionHTTP(ILogger<FactoryMethodFunctionHTTP> logger)
        {
            _logger = logger;
        }

        [Function("FactoryMethodFunctionHTTP")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "creational/FactoryMethod")] HttpRequest req)
        {
            Client client = new Client();

            client.BuildVehicle(VehicleType.TwoWheeler);
            client.GetVehicle().LogVehicleInfo(_logger);

            client.BuildVehicle(VehicleType.ThreeWheeler);
            client.GetVehicle().LogVehicleInfo(_logger);

            client.BuildVehicle(VehicleType.FourWheeler);
            client.GetVehicle().LogVehicleInfo(_logger);

            return new OkObjectResult("We created some Vehicles!");
        }
    }
}

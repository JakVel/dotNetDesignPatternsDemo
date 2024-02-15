using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DesignPatterns101.Structural_Patterns
{
    public class CompositeFunctionHTTP
    {
        private readonly ILogger<CompositeFunctionHTTP> _logger;

        public CompositeFunctionHTTP(ILogger<CompositeFunctionHTTP> logger)
        {
            _logger = logger;
        }

        // Creating instances of individual employees(Developers and Managers) and organizing them into composite structures
        // using CompanyDirectory. It then demonstrates the use of the Composite pattern by displaying the
        // details of the entire employee structure
        [Function("CompositeFunctionHTTP")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "structural/composite")] HttpRequest req)
        {
            Developer dev1 = new Developer(100, "Lokesh Sharma", "Pro Developer");
            Developer dev2 = new Developer(101, "Vinay Sharma", "Developer");

            CompanyDirectory engDirectory = new CompanyDirectory();
            engDirectory.AddEmployee(dev1);
            engDirectory.AddEmployee(dev2);

            Manager man1 = new Manager(200, "Kushagra Garg", "SEO Manager");
            Manager man2 = new Manager(201, "Vikram Sharma", "Kushagra's Manager");

            CompanyDirectory accDirectory = new CompanyDirectory();
            accDirectory.AddEmployee(man1);
            accDirectory.AddEmployee(man2);

            CompanyDirectory directory = new CompanyDirectory();
            directory.AddEmployee(engDirectory);
            directory.AddEmployee(accDirectory);
            directory.ShowEmployeeDetails(_logger);

            return new OkObjectResult("Done");
        }
    }
}

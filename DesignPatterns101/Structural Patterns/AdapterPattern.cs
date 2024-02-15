using Microsoft.Extensions.Logging;
using System;

// In design, adapters are used when we have a class (Client) expecting some type of object and we have an object (Adaptee)
// offering the same features but exposing a different interface.

// Lets consider you have an existing system that works with a service called LegacyService, which has a method LegacyRequest().
// However, you need to integrate a new service called NewService, which has a method NewRequest().

//  - The method names and signatures in LegacyService and NewService do not match, causing a direct incompatibility.
//  - Modifying the existing system to work with NewService directly would require changes to its code, leading to
//    disruptions and potentially breaking the existing functionality.

// The Adapter Pattern makes the NewService compatible with the ILegacyService interface expected by the existing system.

namespace DesignPatterns101.Structural_Patterns
{
    // Target Interface
    // An interface called ILegacyService that represents the operations expected by the existing system.
    public interface ILegacyService
    {
        string LegacyRequest(ILogger log);
    }

    // Adaptee
    // A class called NewService with the method NewRequest().
    public class NewService
    {
        public string NewRequest(ILogger logger)
        {
            logger.LogWarning("Executing NewService.NewRequest()");
            return "Executing NewService.NewRequest()";
        }
    }

    // Adapter
    // An adapter class Adapter that implements ILegacyService and wraps an instance of NewService.
    // The Adapter class delegates calls to LegacyRequest() to the corresponding method in NewService.
    public class Adapter : ILegacyService
    {
        private readonly NewService newService;

        public Adapter(NewService newService)
        {
            this.newService = newService;
        }

        public string LegacyRequest(ILogger log)
        {
            log.LogWarning("Called ILegacyService Adapter.LegacyRequest()");
            return newService.NewRequest(log);
        }
    }
}
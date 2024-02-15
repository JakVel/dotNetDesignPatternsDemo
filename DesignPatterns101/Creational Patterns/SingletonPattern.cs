using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;

// Singleton pattern is a design pattern which restricts a class to instantiate its multiple objects.
// It is nothing but a way of defining a class.

//  - Class is defined in such a way that only one instance of the class is created in the complete execution of a program or project.
//  - When the sole instance should be extensible by subclassing and clients should be able to use an
//    extended instance without modifying 
//  - Singleton classes are used for logging, driver objects, caching, and thread pool, database connections.

// The Singleton class has a private constructor, a private static instance, and a public static method GetInstance() that
// returns the instance. The method demonstrates the usage of the Singleton pattern by calling the GetInstance() method and
// then invoking the DoSomething() method on the obtained instance.

namespace DesignPatterns101.Creational_Patterns
{
    public class SingletonExample
    {
        // static class
        private static SingletonExample instance;
        private static int randomID;
        private static ILogger _log;

        private SingletonExample(ILoggerFactory loggerFactory)
        {
            _log = loggerFactory.CreateLogger("Singleton");
            Random randGenerator = new Random();

            randomID = randGenerator.Next(100000, 999999);
            _log.LogWarning($"Singleton is Instantiated with ID: {randomID}");
        }

        public static SingletonExample GetInstance()
        {
            if (instance == null)
            {
                ILoggerFactory loggerFactory = new LoggerFactory();
                instance = new SingletonExample(loggerFactory);
            }
            return instance;
        }

        public string DoSomething()
        {
            return $"DoesSomething with the Singleton with ID: {randomID}";
        }
    }
}
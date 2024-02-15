using Microsoft.Extensions.Logging;
using System;

// Factory Method or Factory Design Patterns also known as virtual constructor, it define an interface for creating an object,
// but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses. 

// When to use Factory Method
//  - A class can’t anticipate the class of objects it must create.
//  - A class wants its subclass to specify the objects it creates.
//  - Classes delegate responsibility to one of several helper subclasses, and you want to localize the knowledge of which
//    helper subclass is the delegate.


// EXAMPLE: 
//  - If multiple clients need to create instances of Vehicles, the code for creating those instances might be duplicated across
//    different parts of the application.
//  - Creating instances of concrete classes directly ties the client code to those specific classes.
//  - The Client code could become cluttered with the details of object creation, making it harder to read and understand.

namespace DesignPatterns101.Creational_Patterns
{
    // Enum defining vehicle types
    public enum VehicleType
    {
        TwoWheeler,
        ThreeWheeler,
        FourWheeler
    }

    // Abstract class for Vehicle, With one abstract method
    public abstract class Vehicle
    {
        public abstract void LogVehicleInfo(ILogger log);
    }

    // Concrete classes for each type of vehicle with implementation of the abstract method from abstract Vehicle
    public class TwoWheeler : Vehicle
    {
        public override void LogVehicleInfo(ILogger log)
        {
            log.LogWarning("I am two wheeler");
        }
    }

    public class ThreeWheeler : Vehicle
    {
        public override void LogVehicleInfo(ILogger log)
        {
            log.LogWarning("I am three wheeler");
        }
    }

    public class FourWheeler : Vehicle
    {
        public override void LogVehicleInfo(ILogger log)
        {
            log.LogWarning("I am four wheeler");
        }
    }

    // Interface for the VehicleFactory
    public interface IVehicleFactory
    {
        Vehicle Build(VehicleType vehicleType);
    }

    // Concrete class implementing the VehicleFactory
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle Build(VehicleType vehicleType)
        {
            switch (vehicleType)
            {
                case VehicleType.TwoWheeler:
                    return new TwoWheeler();
                case VehicleType.ThreeWheeler:
                    return new ThreeWheeler();
                case VehicleType.FourWheeler:
                    return new FourWheeler();
                default:
                    return null;
            }
        }
    }

    // Client class
    public class Client
    {
        private Vehicle _pVehicle;

        public Client()
        {
            _pVehicle = null;
        }

        public void BuildVehicle(VehicleType vehicleType)
        {
            IVehicleFactory vf = new VehicleFactory();
            _pVehicle = vf.Build(vehicleType);
        }

        public Vehicle GetVehicle()
        {
            return _pVehicle;
        }
    }
}
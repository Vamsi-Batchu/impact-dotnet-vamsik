using System;

namespace FactoryDemo
{
    public interface IVehicle
    {
        string Drive();
    }

    public class Car : IVehicle { public string Drive() => "Driving a Car!"; }
    public class Bike : IVehicle { public string Drive() => "Riding a Bike!"; }
    public class Truck : IVehicle { public string Drive() => "Driving a heavy Truck!"; }

    // Simple Factory
    public static class VehicleFactory
    {
        public static IVehicle CreateVehicle(string type)
        {
            return type.ToLower() switch
            {
                "car" => new Car(),
                "bike" => new Bike(),
                "truck" => new Truck(),
                _ => throw new ArgumentException($"Unknown vehicle type: {type}")
            };
        }
    }

    // Factory Method Pattern
    public abstract class VehicleCreator
    {
        public abstract IVehicle CreateVehicle();
        
        public string Deliver()
        {
            var vehicle = CreateVehicle();
            return $"Delivered using: {vehicle.Drive()}";
        }
    }

    public class CarFactory : VehicleCreator
    {
        public override IVehicle CreateVehicle() => new Car();
    }

    public class BikeFactory : VehicleCreator
    {
        public override IVehicle CreateVehicle() => new Bike();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 3.5: Simple Factory & Factory Method ===");

            // Caller never uses 'new Car()' or 'new Bike()' directly
            IVehicle vehicle1 = VehicleFactory.CreateVehicle("car");
            IVehicle vehicle2 = VehicleFactory.CreateVehicle("bike");
            Console.WriteLine(vehicle1.Drive());
            Console.WriteLine(vehicle2.Drive());

            // Factory Method usage
            VehicleCreator creator = new CarFactory();
            Console.WriteLine(creator.Deliver());
        }
    }
}

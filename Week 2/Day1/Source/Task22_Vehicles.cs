using System;

public class Vehicle
{
    public string Make { get; }
    public string Model { get; }
    public int Year { get; }

    public Vehicle(string make, string model, int year)
    {
        Console.WriteLine("Vehicle constructor");
        Make = make;
        Model = model;
        Year = year;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"{Year} {Make} {Model}");
    }
}

public class Car : Vehicle
{
    public int NumberOfDoors { get; }

    public Car(string make, string model, int year, int numberOfDoors)
        : base(make, model, year)
    {
        Console.WriteLine("Car constructor");
        NumberOfDoors = numberOfDoors;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{Year} {Make} {Model}, Doors: {NumberOfDoors}");
    }
}

public class Bike : Vehicle
{
    public bool HasSidecar { get; }

    public Bike(string make, string model, int year, bool hasSidecar)
        : base(make, model, year)
    {
        Console.WriteLine("Bike constructor");
        HasSidecar = hasSidecar;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{Year} {Make} {Model}, Sidecar: {HasSidecar}");
    }
}

public class ElectricCar : Car
{
    public double BatteryCapacity { get; }

    public ElectricCar(string make, string model, int year, int numberOfDoors, double batteryCapacity)
        : base(make, model, year, numberOfDoors)
    {
        Console.WriteLine("ElectricCar constructor");
        BatteryCapacity = batteryCapacity;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{Year} {Make} {Model}, Doors: {NumberOfDoors}, Battery: {BatteryCapacity} kWh");
    }
}

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Creating ElectricCar:");
        var electricCar = new ElectricCar("Tesla", "Model 3", 2026, 4, 75);
        electricCar.DisplayInfo();

        Console.WriteLine("\nOther vehicles:");
        new Car("Toyota", "Camry", 2025, 4).DisplayInfo();
        new Bike("Yamaha", "MT-15", 2025, false).DisplayInfo();
    }
}

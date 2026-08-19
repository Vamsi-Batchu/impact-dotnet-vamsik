using System;
using System.Collections.Generic;

public class Calculator
{
    public int Add(int a, int b) => a + b;
    public double Add(double a, double b) => a + b;
    public int Add(int a, int b, int c) => a + b + c;
    public int Add(params int[] numbers)
    {
        int total = 0;
        foreach (var number in numbers)
            total += number;
        return total;
    }
}

public class Shape
{
    public virtual double CalculateArea() => 0;
}

public class Circle : Shape
{
    public double Radius { get; }
    public Circle(double radius) => Radius = radius;
    public override double CalculateArea() => Math.PI * Radius * Radius;
}

public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    public override double CalculateArea() => Width * Height;
}

public class Logger
{
    public void Log() => Console.WriteLine("Base Logger.Log()");
}

public class FileLogger : Logger
{
    public new void Log() => Console.WriteLine("FileLogger.Log()");
}

public static class Program
{
    public static void Main()
    {
        var calculator = new Calculator();

        Console.WriteLine(calculator.Add(2, 3));
        Console.WriteLine(calculator.Add(2.5, 3.5));
        Console.WriteLine(calculator.Add(1, 2, 3));
        Console.WriteLine(calculator.Add(1, 2, 3, 4, 5));

        var shapes = new List<Shape>
        {
            new Circle(5),
            new Rectangle(10, 4)
        };

        Console.WriteLine("\nRuntime polymorphism:");
        foreach (var shape in shapes)
            Console.WriteLine(shape.CalculateArea());

        Console.WriteLine("\nMethod hiding:");
        Logger logger = new FileLogger();
        FileLogger fileLogger = new FileLogger();

        logger.Log();      // Base version because reference type is Logger.
        fileLogger.Log();  // Derived hidden version.

        /*
         * override = runtime polymorphism; derived method is selected based
         * on the actual object.
         *
         * new = method hiding; method selected based on reference type.
         */
    }
}

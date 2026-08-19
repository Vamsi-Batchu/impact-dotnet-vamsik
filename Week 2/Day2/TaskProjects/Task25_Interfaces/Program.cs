using System;

public interface IShape
{
    double CalculateArea();
    double CalculatePerimeter();
}

public interface IDrawable
{
    void Draw();
}

public class Rectangle : IShape, IDrawable
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double CalculateArea() => Width * Height;
    public double CalculatePerimeter() => 2 * (Width + Height);

    public void Draw() => Console.WriteLine("Drawing rectangle.");

    /*
     * Interface vs Abstract class:
     *
     * Interface:
     * - Defines a contract.
     * - A class can implement multiple interfaces.
     * - Best when unrelated classes need common behavior/capabilities.
     *
     * Abstract class:
     * - Can contain fields, constructors, concrete methods and abstract methods.
     * - A class can inherit only one base class.
     * - Best when classes share a strong "is-a" relationship and common implementation.
     */
}

public static class Program
{
    public static void Main()
    {
        var rectangle = new Rectangle(10, 5);

        Console.WriteLine($"Area: {rectangle.CalculateArea()}");
        Console.WriteLine($"Perimeter: {rectangle.CalculatePerimeter()}");
        rectangle.Draw();
    }
}

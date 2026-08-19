using System;

public abstract class Shape
{
    public abstract double CalculateArea();

    public void DisplayArea()
    {
        Console.WriteLine($"Area: {CalculateArea():F2}");
    }
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

public static class Program
{
    public static void Main()
    {
        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(10, 4);

        circle.DisplayArea();
        rectangle.DisplayArea();

        // Shape shape = new Shape();
        // ERROR: Cannot create an instance of the abstract type or interface 'Shape'
    }
}

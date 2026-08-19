using System;

public delegate double MathOperation(double a, double b);

public static class Program
{
    static double Add(double a, double b) => a + b;
    static double Subtract(double a, double b) => a - b;
    static double Multiply(double a, double b) => a * b;
    static double Divide(double a, double b) => b == 0 ? throw new DivideByZeroException() : a / b;

    public static void Main()
    {
        MathOperation add = Add;
        MathOperation subtract = Subtract;
        MathOperation multiply = Multiply;
        MathOperation divide = Divide;

        Console.WriteLine($"Add: {add(10, 5)}");
        Console.WriteLine($"Subtract: {subtract(10, 5)}");
        Console.WriteLine($"Multiply: {multiply(10, 5)}");
        Console.WriteLine($"Divide: {divide(10, 5)}");

        Console.WriteLine("\nMulticast delegate:");
        MathOperation multi = Add;
        multi += Multiply;

        // Both methods execute. For a value-returning multicast delegate,
        // the return value is from the last method in the invocation list.
        multi(10, 5);

        Console.WriteLine("\nFunc version:");
        Func<double, double, double> funcAdd = Add;
        Func<double, double, double> funcMultiply = Multiply;

        Console.WriteLine($"Func Add: {funcAdd(10, 5)}");
        Console.WriteLine($"Func Multiply: {funcMultiply(10, 5)}");
    }
}

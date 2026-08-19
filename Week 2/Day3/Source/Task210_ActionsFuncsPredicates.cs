using System;
using System.Collections.Generic;

public static class Program
{
    static void ProcessList(
        List<int> list,
        Predicate<int> filter,
        Func<int, int> transform,
        Action<int> output)
    {
        foreach (var item in list)
        {
            if (filter(item))
            {
                var transformed = transform(item);
                output(transformed);
            }
        }
    }

    public static void Main()
    {
        Action<string> uppercasePrint = text => Console.WriteLine(text.ToUpper());
        Func<int, int, int> multiply = (a, b) => a * b;
        Predicate<int> isEven = number => number % 2 == 0;

        uppercasePrint("hello world");
        Console.WriteLine($"3 * 4 = {multiply(3, 4)}");
        Console.WriteLine($"8 is even: {isEven(8)}");

        Console.WriteLine("\nEven -> square -> print:");
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

        ProcessList(
            numbers,
            isEven,
            number => number * number,
            number => Console.WriteLine(number));
    }
}

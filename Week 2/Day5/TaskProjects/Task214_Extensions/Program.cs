using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public static class Extensions
{
    public static string ToTitleCase(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return value;

        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
    }

    public static bool IsNullOrEmpty<T>(this List<T>? list)
        => list == null || list.Count == 0;

    public static string ToWords(this int number)
    {
        if (number < 0 || number > 999)
            throw new ArgumentOutOfRangeException(nameof(number), "Supported range is 0-999.");

        if (number == 0) return "Zero";

        string[] ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
                          "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
                          "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

        string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        string result = "";

        if (number >= 100)
        {
            result += ones[number / 100] + " Hundred";
            number %= 100;
            if (number > 0) result += " ";
        }

        if (number >= 20)
        {
            result += tens[number / 10];
            number %= 10;
            if (number > 0) result += " " + ones[number];
        }
        else if (number > 0)
        {
            result += ones[number];
        }

        return result;
    }
}

public class Employee
{
    public string Name { get; set; } = "";
    public decimal Salary { get; set; }
}

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("hello world".ToTitleCase());

        List<int>? empty = null;
        Console.WriteLine($"Null list: {empty.IsNullOrEmpty()}");

        var numbers = new List<int>();
        Console.WriteLine($"Empty list: {numbers.IsNullOrEmpty()}");

        Console.WriteLine($"0 -> {0.ToWords()}");
        Console.WriteLine($"42 -> {42.ToWords()}");
        Console.WriteLine($"999 -> {999.ToWords()}");

        var employees = new List<Employee>
        {
            new() { Name = "Alice", Salary = 60000 },
            new() { Name = "Bob", Salary = 70000 }
        };

        var projected = employees.Select(e => new
        {
            e.Name,
            AnnualSalary = e.Salary * 12
        });

        foreach (var employee in projected)
            Console.WriteLine($"{employee.Name}: {employee.AnnualSalary:C}");

        /*
         * Anonymous types are compiler-generated types with no accessible
         * type name that you can use as a normal public return type.
         *
         * Therefore this is not suitable:
         *
         * public ??? GetEmployees()
         *
         * Usually use a named DTO/record/class when returning projected
         * data from a method.
         */
    }
}

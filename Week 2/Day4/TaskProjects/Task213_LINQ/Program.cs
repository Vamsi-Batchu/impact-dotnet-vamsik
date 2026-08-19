using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public string Name { get; set; } = "";
    public string Department { get; set; } = "";
    public decimal Salary { get; set; }
    public DateTime JoiningDate { get; set; }
}

public static class Program
{
    static List<Employee> GetEmployees() => new()
    {
        new() { Name="Alice", Department="IT", Salary=65000, JoiningDate=new DateTime(2020,1,10) },
        new() { Name="Bob", Department="HR", Salary=48000, JoiningDate=new DateTime(2021,5,15) },
        new() { Name="Charlie", Department="IT", Salary=72000, JoiningDate=new DateTime(2018,3,20) },
        new() { Name="Diana", Department="Finance", Salary=58000, JoiningDate=new DateTime(2019,7,1) },
        new() { Name="Evan", Department="HR", Salary=52000, JoiningDate=new DateTime(2022,2,12) },
        new() { Name="Fiona", Department="Finance", Salary=61000, JoiningDate=new DateTime(2017,11,5) },
        new() { Name="George", Department="IT", Salary=55000, JoiningDate=new DateTime(2023,4,18) },
        new() { Name="Helen", Department="Sales", Salary=67000, JoiningDate=new DateTime(2019,9,9) },
        new() { Name="Ian", Department="Sales", Salary=51000, JoiningDate=new DateTime(2021,6,6) },
        new() { Name="Jane", Department="IT", Salary=83000, JoiningDate=new DateTime(2016,12,1) }
    };

    public static void Main()
    {
        var employees = GetEmployees();

        Console.WriteLine("Query syntax - salary > 50000:");
        var highSalaryQuery =
            from e in employees
            where e.Salary > 50000
            select e;

        foreach (var e in highSalaryQuery)
            Console.WriteLine($"{e.Name}: {e.Salary}");

        Console.WriteLine("\nMethod syntax - salary > 50000:");
        var highSalaryMethod = employees.Where(e => e.Salary > 50000);

        foreach (var e in highSalaryMethod)
            Console.WriteLine($"{e.Name}: {e.Salary}");

        Console.WriteLine("\nOrder by salary descending - query syntax:");
        var orderedQuery =
            from e in employees
            orderby e.Salary descending
            select e;

        foreach (var e in orderedQuery)
            Console.WriteLine($"{e.Name}: {e.Salary}");

        Console.WriteLine("\nOrder by salary descending - method syntax:");
        var orderedMethod = employees.OrderByDescending(e => e.Salary);

        foreach (var e in orderedMethod)
            Console.WriteLine($"{e.Name}: {e.Salary}");

        Console.WriteLine("\nGroup by department - query syntax:");
        var groupedQuery =
            from e in employees
            group e by e.Department into department
            select new
            {
                Department = department.Key,
                Count = department.Count(),
                AverageSalary = department.Average(e => e.Salary)
            };

        foreach (var group in groupedQuery)
            Console.WriteLine($"{group.Department}: Count={group.Count}, Avg={group.AverageSalary:F2}");

        Console.WriteLine("\nGroup by department - method syntax:");
        var groupedMethod = employees
            .GroupBy(e => e.Department)
            .Select(g => new
            {
                Department = g.Key,
                Count = g.Count(),
                AverageSalary = g.Average(e => e.Salary)
            });

        foreach (var group in groupedMethod)
            Console.WriteLine($"{group.Department}: Count={group.Count}, Avg={group.AverageSalary:F2}");

        Console.WriteLine("\nProjection to anonymous type - query syntax:");
        var projectionQuery =
            from e in employees
            select new
            {
                e.Name,
                Experience = DateTime.Now.Year - e.JoiningDate.Year
            };

        foreach (var e in projectionQuery)
            Console.WriteLine($"{e.Name}: {e.Experience} years");

        Console.WriteLine("\nProjection to anonymous type - method syntax:");
        var projectionMethod = employees.Select(e => new
        {
            e.Name,
            Experience = DateTime.Now.Year - e.JoiningDate.Year
        });

        foreach (var e in projectionMethod)
            Console.WriteLine($"{e.Name}: {e.Experience} years");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Employee
{
    public string Name { get; }
    public string Department { get; }

    protected Employee(string name, string department)
    {
        Name = name;
        Department = department;
    }

    public abstract decimal CalculateSalary();
}

public interface ITaxable
{
    decimal CalculateTax();
}

public class FullTimeEmployee : Employee, ITaxable
{
    public decimal MonthlySalary { get; }

    public FullTimeEmployee(string name, string department, decimal monthlySalary)
        : base(name, department)
    {
        MonthlySalary = monthlySalary;
    }

    public override decimal CalculateSalary() => MonthlySalary;

    public decimal CalculateTax() => CalculateSalary() * 0.10m;
}

public class PartTimeEmployee : Employee
{
    public decimal HourlyRate { get; }
    public int HoursWorked { get; }

    public PartTimeEmployee(string name, string department, decimal hourlyRate, int hoursWorked)
        : base(name, department)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override decimal CalculateSalary() => HourlyRate * HoursWorked;
}

public class ContractEmployee : Employee
{
    public decimal ContractAmount { get; }

    public ContractEmployee(string name, string department, decimal contractAmount)
        : base(name, department)
    {
        ContractAmount = contractAmount;
    }

    public override decimal CalculateSalary() => ContractAmount;
}

public static class Program
{
    public static void Main()
    {
        var employees = new List<Employee>
        {
            new FullTimeEmployee("Alice", "IT", 70000),
            new FullTimeEmployee("Bob", "HR", 60000),
            new PartTimeEmployee("Charlie", "IT", 500, 80),
            new ContractEmployee("Diana", "Finance", 45000)
        };

        decimal totalPayroll = employees.Sum(e => e.CalculateSalary());

        Console.WriteLine($"Total payroll: {totalPayroll:C}");

        Console.WriteLine("\nPayroll by department:");
        var byDepartment = employees
            .GroupBy(e => e.Department)
            .Select(g => new
            {
                Department = g.Key,
                Payroll = g.Sum(e => e.CalculateSalary())
            });

        foreach (var group in byDepartment)
            Console.WriteLine($"{group.Department}: {group.Payroll:C}");

        Console.WriteLine("\nTaxable employees:");
        foreach (var employee in employees.OfType<ITaxable>())
            Console.WriteLine($"{((Employee)employee).Name}: Tax = {employee.CalculateTax():C}");
    }
}

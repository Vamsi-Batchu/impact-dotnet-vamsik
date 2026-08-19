using System;
using System.Collections.Generic;

namespace SortingDemo
{
    public class Employee : IComparable<Employee>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }

        public int CompareTo(Employee? other)
        {
            if (other == null) return 1;
            // Default sort by Salary (Ascending)
            return Salary.CompareTo(other.Salary);
        }

        public override string ToString() => $"{Name} - {Salary:C}";
    }

    public class EmployeeNameComparer : IComparer<Employee>
    {
        public int Compare(Employee? x, Employee? y)
        {
            if (x == null || y == null) return 0;
            // Custom sort by Name (Alphabetical)
            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 3.14: Sorting with IComparable & IComparer ===");

            var employees = new List<Employee>
            {
                new Employee { Name = "Charlie", Salary = 75000 },
                new Employee { Name = "Alice", Salary = 95000 },
                new Employee { Name = "Bob", Salary = 50000 },
                new Employee { Name = "Eve", Salary = 110000 },
                new Employee { Name = "David", Salary = 60000 }
            };

            Console.WriteLine("
--- Default Sorting (by Salary via IComparable) ---");
            employees.Sort();
            employees.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("
--- Custom Sorting (by Name via IComparer) ---");
            employees.Sort(new EmployeeNameComparer());
            employees.ForEach(e => Console.WriteLine(e));
        }
    }
}

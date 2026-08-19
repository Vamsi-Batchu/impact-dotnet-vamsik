using System;
using System.Reflection;

namespace ReflectionDemo
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public Invoice() { }

        public Invoice(int id, string name, decimal amount)
        {
            InvoiceId = id;
            CustomerName = name;
            Amount = amount;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Invoice #{InvoiceId} | Customer: {CustomerName} | Amount: {Amount:C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 3.11: Reflection Inspection & Dynamic Instantiation ===");

            Type type = typeof(Invoice);
            Console.WriteLine($"Class Name: {type.Name}");

            Console.WriteLine("
Properties:");
            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine($" - {prop.Name} ({prop.PropertyType.Name})");
            }

            Console.WriteLine("
Methods:");
            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                Console.WriteLine($" - {method.Name}");
            }

            Console.WriteLine("
Constructors:");
            foreach (var ctor in type.GetConstructors())
            {
                var paramsInfo = string.Join(", ", Array.ConvertAll(ctor.GetParameters(), p => $"{p.ParameterType.Name} {p.Name}"));
                Console.WriteLine($" - Ctor({paramsInfo})");
            }

            // Dynamic Creation via Reflection
            Console.WriteLine("
--- Creating Instance & Setting Property via Reflection ---");
            object? invoiceObj = Activator.CreateInstance(type);
            
            PropertyInfo? idProp = type.GetProperty("InvoiceId");
            PropertyInfo? nameProp = type.GetProperty("CustomerName");

            idProp?.SetValue(invoiceObj, 1001);
            nameProp?.SetValue(invoiceObj, "Acme Corp");

            MethodInfo? printMethod = type.GetMethod("PrintDetails");
            printMethod?.Invoke(invoiceObj, null);
        }
    }
}

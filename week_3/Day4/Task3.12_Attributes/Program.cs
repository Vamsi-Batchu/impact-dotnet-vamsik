using System;
using System.Reflection;

namespace AttributesDemo
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLengthNoAttribute : Attribute
    {
        public int Length { get; }
        public MaxLengthNoAttribute(int length)
        {
            Length = length;
        }
    }

    public class User
    {
        [MaxLengthNo(10)]
        public string Name { get; set; } = string.Empty;
    }

    public static class Validator
    {
        public static bool Validate(object obj)
        {
            bool isValid = true;
            Type type = obj.GetType();

            foreach (var prop in type.GetProperties())
            {
                var attr = prop.GetCustomAttribute<MaxLengthNoAttribute>();
                if (attr != null)
                {
                    string? val = prop.GetValue(obj) as string;
                    if (val != null && val.Length > attr.Length)
                    {
                        Console.WriteLine($"[VALIDATION WARNING] Property '{prop.Name}' with value '{val}' (len: {val.Length}) exceeds max length of {attr.Length}!");
                        isValid = false;
                    }
                }
            }
            return isValid;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 3.12: Custom Attribute & Reflection Validator ===");

            var validUser = new User { Name = "Short" };
            var invalidUser = new User { Name = "ThisNameIsWayTooLong" };

            Console.WriteLine("Validating validUser...");
            Validator.Validate(validUser);

            Console.WriteLine("
Validating invalidUser...");
            Validator.Validate(invalidUser);
        }
    }
}

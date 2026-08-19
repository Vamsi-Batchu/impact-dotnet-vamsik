using System;

namespace InterfaceVsAbstractDemo
{
    // Static Helper Class
    public static class MathHelper
    {
        // Static because it contains pure stateless mathematical calculations
        public static long Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("Negative numbers not allowed.");
            if (n == 0 || n == 1) return 1;
            long result = 1;
            for (int i = 2; i <= n; i++) result *= i;
            return result;
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }
    }

    // Instance Class
    public class OrderProcessor
    {
        // Instance method because processing an order requires object state, dependencies, and tracking workflow execution
        public string OrderStatus { get; private set; } = "Created";

        public void ProcessOrder(int orderId)
        {
            OrderStatus = $"Processed Order #{orderId}";
            Console.WriteLine($"[OrderProcessor] {OrderStatus}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 3.13: Interface vs Abstract & Static vs Instance ===");

            Console.WriteLine($"Factorial(5): {MathHelper.Factorial(5)}");
            Console.WriteLine($"IsPrime(17): {MathHelper.IsPrime(17)}");
            Console.WriteLine($"GCD(24, 36): {MathHelper.GCD(24, 36)}");

            var processor = new OrderProcessor();
            processor.ProcessOrder(42);
        }
    }
}

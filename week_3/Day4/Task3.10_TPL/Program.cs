using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TPLDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Task 3.10: Timing Thread vs Task.Run vs Parallel.ForEach ===");
            const int totalOps = 100;
            const int delayMs = 10; // 10ms per operation to keep overall runtime reasonable

            // 1. Sequential Foreach
            var sw1 = Stopwatch.StartNew();
            for (int i = 0; i < totalOps; i++)
            {
                Thread.Sleep(delayMs);
            }
            sw1.Stop();
            Console.WriteLine($"Sequential Foreach Time: {sw1.ElapsedMilliseconds} ms");

            // 2. Parallel.ForEach
            var sw2 = Stopwatch.StartNew();
            Parallel.For(0, totalOps, i =>
            {
                Thread.Sleep(delayMs);
            });
            sw2.Stop();
            Console.WriteLine($"Parallel.ForEach Time: {sw2.ElapsedMilliseconds} ms");

            Console.WriteLine($"
[Result] Parallel execution was ~{sw1.ElapsedMilliseconds / (double)sw2.ElapsedMilliseconds:F2}x faster!");
        }
    }
}

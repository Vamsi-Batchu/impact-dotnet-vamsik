using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncDemo
{
    public class Program
    {
        public static async Task<string> FetchUserDataAsync(int userId)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Starting fetch for User {userId}...");
            await Task.Delay(3000); // 3 seconds delay
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Finished fetch for User {userId}.");
            return $"UserData_{userId}";
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Task 3.3: Async Execution Performance ===");

            // 1. Sequential Execution
            var swSeq = Stopwatch.StartNew();
            Console.WriteLine("
--- Starting Sequential Fetches ---");
            var user1 = await FetchUserDataAsync(1);
            var user2 = await FetchUserDataAsync(2);
            var user3 = await FetchUserDataAsync(3);
            swSeq.Stop();
            Console.WriteLine($"Sequential Execution Time: {swSeq.ElapsedMilliseconds} ms");

            // 2. Concurrent Execution via Task.WhenAll
            var swConc = Stopwatch.StartNew();
            Console.WriteLine("
--- Starting Concurrent Fetches (Task.WhenAll) ---");
            Task<string> task1 = FetchUserDataAsync(10);
            Task<string> task2 = FetchUserDataAsync(20);
            Task<string> task3 = FetchUserDataAsync(30);

            string[] results = await Task.WhenAll(task1, task2, task3);
            swConc.Stop();
            Console.WriteLine($"Concurrent Execution Time: {swConc.ElapsedMilliseconds} ms");

            Console.WriteLine($"
[Result] Speedup Factor: ~{swSeq.ElapsedMilliseconds / (double)swConc.ElapsedMilliseconds:F2}x faster!");
        }
    }
}

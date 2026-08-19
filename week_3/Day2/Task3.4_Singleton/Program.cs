using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class Logger
    {
        // Thread-safe Singleton utilizing Lazy<T>
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

        public static Logger Instance => _instance.Value;

        private Logger()
        {
            // Private ctor prevents instantiation outside
        }

        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] [Hash: {GetHashCode()}] {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 3.4: Thread-Safe Singleton Demo ===");
            var instanceHashes = new ConcurrentBag<int>();

            // Hit Singleton from 5 Threads
            Thread[] threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                int id = i + 1;
                threads[i] = new Thread(() =>
                {
                    var logger = Logger.Instance;
                    instanceHashes.Add(logger.GetHashCode());
                    logger.Log($"Thread {id} accessing logger.");
                });
            }

            foreach (var t in threads) t.Start();
            foreach (var t in threads) t.Join();

            // Hit Singleton from 5 Tasks
            Task[] tasks = new Task[5];
            for (int i = 0; i < 5; i++)
            {
                int id = i + 1;
                tasks[i] = Task.Run(() =>
                {
                    var logger = Logger.Instance;
                    instanceHashes.Add(logger.GetHashCode());
                    logger.Log($"Task {id} accessing logger.");
                });
            }

            Task.WaitAll(tasks);

            Console.WriteLine("
--- Verification ---");
            foreach (var hash in instanceHashes)
            {
                Console.WriteLine($"Recorded Instance Hash Code: {hash}");
            }
        }
    }
}

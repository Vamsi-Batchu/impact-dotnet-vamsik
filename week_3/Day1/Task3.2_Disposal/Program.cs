using System;
using System.IO;

namespace DisposalDemo
{
    // Implementation of Standard Dispose Pattern
    public class TempFileManager : IDisposable
    {
        public string FilePath { get; }
        private bool _disposed = false;

        public TempFileManager()
        {
            FilePath = Path.Combine(Path.GetTempPath(), $"temp_{Guid.NewGuid()}.tmp");
            File.WriteAllText(FilePath, "Temporary data stored during execution.");
            Console.WriteLine($"[TempFileManager Ctor] Created temp file: {FilePath}");
        }

        // Public implementation of Dispose pattern callable by user / using block
        public void Dispose()
        {
            Dispose(true);
            // GC.SuppressFinalize tells the Garbage Collector that this object was cleaned up explicitly.
            // This avoids running the Finalizer (~TempFileManager), which saves GC cycles and performance.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Free managed resources here if any
                }

                // Clean up unmanaged resources (e.g., file system cleanup)
                if (File.Exists(FilePath))
                {
                    try
                    {
                        File.Delete(FilePath);
                        Console.WriteLine($"[Dispose] Successfully deleted file: {FilePath}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Dispose Error] Could not delete file: {ex.Message}");
                    }
                }
                _disposed = true;
            }
        }

        // Finalizer (Unmanaged Cleanup Backup)
        // Why both exist: Dispose() is for deterministic cleanup by developer. 
        // Finalizer (~TempFileManager) is a safety net invoked by Garbage Collector if developer forgets calling Dispose().
        ~TempFileManager()
        {
            Console.WriteLine("[Finalizer] Safety net invoked by GC.");
            Dispose(false);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 3.2: TempFileManager Disposal Demo ===");
            string path;

            using (var manager = new TempFileManager())
            {
                path = manager.FilePath;
                Console.WriteLine($"[Inside using block] File exists? {File.Exists(path)}");
            }

            Console.WriteLine($"[After using block] File exists? {File.Exists(path)}");
        }
    }
}

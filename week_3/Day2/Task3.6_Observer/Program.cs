using System;
using System.Collections.Generic;

namespace ObserverDemo
{
    // --- 1. Custom IObserver / ISubject Interface Approach ---
    public interface IInvestor
    {
        void Update(string symbol, decimal price);
    }

    public class StockTickerInterface
    {
        private readonly List<IInvestor> _investors = new();
        public void Register(IInvestor investor) => _investors.Add(investor);
        public void Unregister(IInvestor investor) => _investors.Remove(investor);

        public void Notify(string symbol, decimal price)
        {
            foreach (var inv in _investors)
            {
                inv.Update(symbol, price);
            }
        }
    }

    public class InterfaceInvestor : IInvestor
    {
        public string Name { get; }
        public InterfaceInvestor(string name) => Name = name;
        public void Update(string symbol, decimal price)
        {
            Console.WriteLine($"[Interface] Investor {Name} notified: {symbol} is now {price:C}");
        }
    }

    // --- 2. C# Events Approach ---
    public class StockPriceChangedEventArgs : EventArgs
    {
        public string Symbol { get; }
        public decimal Price { get; }
        public StockPriceChangedEventArgs(string symbol, decimal price)
        {
            Symbol = symbol;
            Price = price;
        }
    }

    public class StockTickerEvent
    {
        public event EventHandler<StockPriceChangedEventArgs>? PriceChanged;

        public void ChangePrice(string symbol, decimal price)
        {
            PriceChanged?.Invoke(this, new StockPriceChangedEventArgs(symbol, price));
        }
    }

    public class EventInvestor
    {
        public string Name { get; }
        public EventInvestor(string name) => Name = name;

        public void OnPriceChanged(object? sender, StockPriceChangedEventArgs e)
        {
            Console.WriteLine($"[Event] Investor {Name} notified: {e.Symbol} is now {e.Price:C}");
        }
    }

    class Program
    {
        /*
         * COMPARISON COMMENT:
         * Interface Approach: Classic GoF pattern. Requires explicit register/unregister methods and list management.
         * Useful in multi-language environments or when strictly decoupling via dynamic object graphs.
         * 
         * C# Events Approach: Idiomatic C# implementation using delegates. Thread safety, event registration (+/=-),
         * and memory handling are built right into the language runtime, reducing boilerplate code significantly.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 3.6: Observer Pattern Comparison ===");

            Console.WriteLine("
--- 1. Interface Implementation ---");
            var tickerInterface = new StockTickerInterface();
            var inv1 = new InterfaceInvestor("Alice");
            var inv2 = new InterfaceInvestor("Bob");
            tickerInterface.Register(inv1);
            tickerInterface.Register(inv2);
            tickerInterface.Notify("MSFT", 420.50m);

            Console.WriteLine("
--- 2. C# Events Implementation ---");
            var tickerEvent = new StockTickerEvent();
            var inv3 = new EventInvestor("Charlie");
            tickerEvent.PriceChanged += inv3.OnPriceChanged;
            tickerEvent.ChangePrice("AAPL", 225.75m);
        }
    }
}

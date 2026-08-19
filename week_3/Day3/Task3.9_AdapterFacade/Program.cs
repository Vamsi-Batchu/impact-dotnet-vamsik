using System;

namespace AdapterFacadeDemo
{
    // --- 1. Adapter Pattern ---
    public class XmlReportGenerator
    {
        public string GenerateXmlReport(string xmlData)
        {
            return $"<report>{xmlData}</report>";
        }
    }

    public interface IXmlReportAdapter
    {
        string ProcessJsonReport(string jsonData);
    }

    public class XmlReportAdapter : IXmlReportAdapter
    {
        private readonly XmlReportGenerator _generator = new();

        public string ProcessJsonReport(string jsonData)
        {
            // Simple mock converting JSON to XML
            string convertedXml = jsonData.Replace("{", "<data>").Replace("}", "</data>").Replace(":", "=");
            return _generator.GenerateXmlReport(convertedXml);
        }
    }

    // --- 2. Facade Pattern ---
    public class InventoryService
    {
        public bool CheckStock(string itemId) => true;
    }

    public class PaymentService
    {
        public bool ProcessPayment(decimal amount) => true;
    }

    public class ShippingService
    {
        public string ScheduleShipment(string itemId) => $"Tracking_#12345";
    }

    public class OrderFacade
    {
        private readonly InventoryService _inventory = new();
        private readonly PaymentService _payment = new();
        private readonly ShippingService _shipping = new();

        public string PlaceOrder(string itemId, decimal price)
        {
            if (!_inventory.CheckStock(itemId)) return "Order Failed: Item out of stock";
            if (!_payment.ProcessPayment(price)) return "Order Failed: Payment declined";
            string tracking = _shipping.ScheduleShipment(itemId);

            return $"Order Placed Successfully! Tracking Code: {tracking}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 3.9: Adapter & Facade Patterns ===");

            var adapter = new XmlReportAdapter();
            string xmlResult = adapter.ProcessJsonReport("{'title': 'Sales'}");
            Console.WriteLine($"Adapter Output: {xmlResult}");

            var orderFacade = new OrderFacade();
            string result = orderFacade.PlaceOrder("PROD-99", 199.99m);
            Console.WriteLine($"Facade Result: {result}");
        }
    }
}

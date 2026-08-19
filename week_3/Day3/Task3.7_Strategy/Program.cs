using System;

namespace StrategyDemo
{
    public interface IPaymentStrategy
    {
        string Pay(decimal amount);
    }

    public class CreditCardPayment : IPaymentStrategy
    {
        public string CardNumber { get; }
        public CreditCardPayment(string cardNumber) => CardNumber = cardNumber;
        public string Pay(decimal amount) => $"Paid {amount:C} using Credit Card ending in {CardNumber[^4..]}.";
    }

    public class UpiPayment : IPaymentStrategy
    {
        public string UpiId { get; }
        public UpiPayment(string upiId) => UpiId = upiId;
        public string Pay(decimal amount) => $"Paid {amount:C} via UPI ID {UpiId}.";
    }

    public class NetBankingPayment : IPaymentStrategy
    {
        public string BankName { get; }
        public NetBankingPayment(string bankName) => BankName = bankName;
        public string Pay(decimal amount) => $"Paid {amount:C} via NetBanking ({BankName}).";
    }

    public class ShoppingCart
    {
        private IPaymentStrategy? _paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            _paymentStrategy = strategy;
        }

        public string Checkout(decimal amount)
        {
            if (_paymentStrategy == null)
                throw new InvalidOperationException("Payment strategy not set!");
            return _paymentStrategy.Pay(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 3.7: Strategy Pattern Demo ===");
            var cart = new ShoppingCart();

            cart.SetPaymentStrategy(new CreditCardPayment("1234-5678-9012-3456"));
            Console.WriteLine(cart.Checkout(150.00m));

            cart.SetPaymentStrategy(new UpiPayment("user@upi"));
            Console.WriteLine(cart.Checkout(75.50m));
        }
    }
}

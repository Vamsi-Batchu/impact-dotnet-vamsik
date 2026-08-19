using System;

namespace ExceptionsDemo
{
    public class InsufficientFundsException : Exception
    {
        public decimal DeficitAmount { get; }

        public InsufficientFundsException(decimal deficitAmount, string message)
            : base(message)
        {
            DeficitAmount = deficitAmount;
        }
    }

    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void Withdraw(decimal amount)
        {
            Console.WriteLine($"[Attempting Withdrawal] Amount requested: {amount:C}");
            try
            {
                if (amount > Balance)
                {
                    decimal deficit = amount - Balance;
                    throw new InsufficientFundsException(deficit, $"Insufficient funds! Missing {deficit:C}");
                }
                Balance -= amount;
                Console.WriteLine($"Withdrawal successful! Remaining balance: {Balance:C}");
            }
            finally
            {
                Console.WriteLine("[LOG - Finally Block] Withdrawal attempt logged to system logs.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 3.1: Exceptions & Catch Ordering ===");
            var account = new BankAccount(100);

            try
            {
                account.Withdraw(150);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Caught InsufficientFundsException: {ex.Message} (Deficit: {ex.DeficitAmount:C})");
            }

            Console.WriteLine("
--- Testing Catch Order ---");
            TestCatchOrder("123456789012345678901234567890"); // Overflow
            TestCatchOrder("invalid_number"); // Format
        }

        public static void TestCatchOrder(string input)
        {
            try
            {
                int parsed = int.Parse(input);
                Console.WriteLine($"Parsed value: {parsed}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"[Specific Catch] FormatException caught: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"[Specific Catch] OverflowException caught: {ex.Message}");
            }
            catch (Exception ex)
            {
                // NOTE ON CATCH ORDERING:
                // Reordering catches to put 'catch (Exception)' FIRST causes C# Compile Error CS0160:
                // "A previous catch clause already catches all exceptions of this or a super type ('Exception')"
                // Specific exceptions must always precede base Exception class.
                Console.WriteLine($"[General Catch] General Exception caught: {ex.Message}");
            }
        }
    }
}

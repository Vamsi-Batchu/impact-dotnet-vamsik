using System;
using System.Collections.Generic;

public class BankAccount
{
    private decimal balance;
    private readonly List<string> history = new();

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            history.Add($"Deposit rejected: {amount:C} - amount must be positive.");
            return;
        }

        balance += amount;
        history.Add($"Deposited {amount:C}. Balance: {balance:C}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            history.Add($"Withdraw rejected: {amount:C} - amount must be positive.");
            return;
        }

        if (amount > balance)
        {
            history.Add($"Withdraw rejected: {amount:C} - insufficient funds.");
            return;
        }

        balance -= amount;
        history.Add($"Withdrew {amount:C}. Balance: {balance:C}");
    }

    public decimal GetBalance() => balance;

    public void PrintHistory()
    {
        Console.WriteLine("\nTransaction History:");
        foreach (var item in history)
            Console.WriteLine(item);
    }
}

public static class Program
{
    public static void Main()
    {
        var account = new BankAccount();

        account.Deposit(1000);
        account.Withdraw(250);
        account.Withdraw(1000); // Rejected
        account.Deposit(-50);   // Rejected

        Console.WriteLine($"Final balance: {account.GetBalance():C}");
        account.PrintHistory();
    }
}

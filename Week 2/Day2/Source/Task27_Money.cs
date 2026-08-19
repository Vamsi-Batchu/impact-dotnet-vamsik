using System;

public struct Money : IEquatable<Money>
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money operator +(Money left, Money right)
    {
        if (!string.Equals(left.Currency, right.Currency, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Cannot add money with different currencies.");

        return new Money(left.Amount + right.Amount, left.Currency);
    }

    public static bool operator ==(Money left, Money right) => left.Amount == right.Amount &&
        string.Equals(left.Currency, right.Currency, StringComparison.OrdinalIgnoreCase);

    public static bool operator !=(Money left, Money right) => !(left == right);

    public static bool operator >(Money left, Money right)
    {
        EnsureSameCurrency(left, right);
        return left.Amount > right.Amount;
    }

    public static bool operator <(Money left, Money right)
    {
        EnsureSameCurrency(left, right);
        return left.Amount < right.Amount;
    }

    private static void EnsureSameCurrency(Money left, Money right)
    {
        if (!string.Equals(left.Currency, right.Currency, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Currencies must match.");
    }

    public bool Equals(Money other) => this == other;
    public override bool Equals(object? obj) => obj is Money other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(Amount, Currency);

    public override string ToString() => $"{Amount:0.00} {Currency}";
}

public static class Program
{
    public static void Main()
    {
        var a = new Money(100, "USD");
        var b = new Money(50, "USD");
        var euro = new Money(20, "EUR");

        Console.WriteLine($"a + b = {a + b}");
        Console.WriteLine($"a == b: {a == b}");
        Console.WriteLine($"a != b: {a != b}");
        Console.WriteLine($"a > b: {a > b}");
        Console.WriteLine($"a < b: {a < b}");

        try
        {
            Console.WriteLine(a + euro);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Expected error: {ex.Message}");
        }
    }
}

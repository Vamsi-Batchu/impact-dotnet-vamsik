using System;

public class Notification
{
    public virtual void Send()
    {
        Console.WriteLine("Sending notification");
    }
}

public class EmailNotification : Notification
{
    public sealed override void Send()
    {
        Console.WriteLine("Sending Email notification");
    }
}

public class SmsNotification : Notification
{
    public override void Send()
    {
        Console.WriteLine("Sending SMS notification");
    }
}

public class PushNotification : Notification
{
    public override void Send()
    {
        Console.WriteLine("Sending Push notification");
    }
}

// Intentional compile-error example:
//
// public class SpecialEmailNotification : EmailNotification
// {
//     public override void Send() // ERROR: cannot override sealed member
//     {
//         Console.WriteLine("Another email");
//     }
// }

public static class Program
{
    public static void Main()
    {
        Notification[] notifications =
        {
            new EmailNotification(),
            new SmsNotification(),
            new PushNotification()
        };

        foreach (var notification in notifications)
            notification.Send();

        Console.WriteLine("\nSee the commented SpecialEmailNotification above for the sealed override compile error.");
    }
}

using System;

public delegate void NotificationSender(string recipient, string message);

public class EmailSender
{
    public void Send(string recipient, string message)
        => Console.WriteLine($"Email -> {recipient}: {message}");
}

public class SmsSender
{
    public void Send(string recipient, string message)
        => Console.WriteLine($"SMS -> {recipient}: {message}");
}

public class PushSender
{
    public void Send(string recipient, string message)
        => Console.WriteLine($"Push -> {recipient}: {message}");
}

public class NotificationSentEventArgs : EventArgs
{
    public string Channel { get; }
    public string Recipient { get; }

    public NotificationSentEventArgs(string channel, string recipient)
    {
        Channel = channel;
        Recipient = recipient;
    }
}

public class NotificationService
{
    public event EventHandler<NotificationSentEventArgs>? OnNotificationSent;

    public void Send(NotificationSender sender, string channel, string recipient, string message)
    {
        sender(recipient, message);

        OnNotificationSent?.Invoke(
            this,
            new NotificationSentEventArgs(channel, recipient));
    }
}

public static class Program
{
    public static void Main()
    {
        var email = new EmailSender();
        var sms = new SmsSender();
        var push = new PushSender();

        var service = new NotificationService();

        service.OnNotificationSent += (sender, args) =>
            Console.WriteLine($"LOG: {args.Channel} notification sent to {args.Recipient}");

        service.Send(email.Send, "Email", "alice@example.com", "Welcome!");
        service.Send(sms.Send, "SMS", "+91-9876543210", "Your OTP is 1234");
        service.Send(push.Send, "Push", "User-123", "You have a new message");
    }
}

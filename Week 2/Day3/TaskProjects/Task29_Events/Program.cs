using System;

public class AlarmEventArgs : EventArgs
{
    public DateTime AlarmTime { get; }

    public AlarmEventArgs(DateTime alarmTime)
    {
        AlarmTime = alarmTime;
    }
}

public class AlarmClock
{
    public event EventHandler<AlarmEventArgs>? OnAlarmRing;

    public void TriggerAlarm(DateTime alarmTime)
    {
        Console.WriteLine("Alarm triggered.");
        OnAlarmRing?.Invoke(this, new AlarmEventArgs(alarmTime));
    }
}

public class Person
{
    public string Name { get; }

    public Person(string name) => Name = name;

    public void OnAlarm(object? sender, AlarmEventArgs e)
    {
        Console.WriteLine($"{Name} received alarm at {e.AlarmTime:T}");
    }
}

public class CoffeeMachine
{
    public void OnAlarm(object? sender, AlarmEventArgs e)
    {
        Console.WriteLine($"CoffeeMachine started at {e.AlarmTime:T}");
    }
}

public static class Program
{
    public static void Main()
    {
        var alarm = new AlarmClock();
        var person = new Person("Vamsi");
        var coffeeMachine = new CoffeeMachine();

        alarm.OnAlarmRing += person.OnAlarm;
        alarm.OnAlarmRing += coffeeMachine.OnAlarm;

        alarm.TriggerAlarm(DateTime.Now);
    }
}

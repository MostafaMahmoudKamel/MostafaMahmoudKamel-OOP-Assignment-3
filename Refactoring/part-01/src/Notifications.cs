namespace RefactoringLab;

public interface INotification
{
    public void Send(string to, string message);
}

public class EmailNotification :INotification
{
    public void Send(string to, string message) =>
        Console.WriteLine($"[email] {to}: {message}");
}

public class SmsNotification :INotification
{

    public  void Send(string to, string message) => 
    Console.WriteLine($"[sms] {to}: {message}");
}

//R6) Add one new notification channel without editing any existing class.

public class TelgramNotification : INotification
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"[telgram] {to}: {message}");
    }
}



public class UrgentNotification : INotification
{
    private readonly INotification _notification;

    public UrgentNotification(INotification notification)
    {
        _notification = notification;
    }

    public void Send(string to, string message)
    {
        _notification.Send(to, $"[URGENT] {message}");
    }
}

public class ScheduledNotification : INotification
{
    private readonly INotification _notification;
    public DateTime SendAt { get; set; }

    public ScheduledNotification(INotification innerNotification, DateTime sendAt)
    {
        _notification = innerNotification;
        SendAt = sendAt;
    }

    public void Send(string to, string message)
    {
        Console.WriteLine($"[scheduled {SendAt:g}]");
        _notification.Send(to, message); // بيشغل القناة اللي جواه
    }
}

//public class UrgentScheduledEmailNotification : INotification//: UrgentEmailNotification
//{
//    UrgentEmailNotification urgentEmailNotification = new();
//    public DateTime SendAt { get; set; }

//    public void Send(string to, string message) {
//        Console.WriteLine($"[email scheduled {SendAt:g}]");
//        urgentEmailNotification.Send(to, message);
//        }

//}

//public class UrgentScheduledSmsNotification :INotification//: UrgentSmsNotification
//{
//    UrgentSmsNotification urgentSmsNotification = new();
//    public DateTime SendAt { get; set; }

//    public  void Send(string to, string message)
//    {
//        Console.WriteLine($"[sms scheduled {SendAt:g}]");
//        urgentSmsNotification.Send(to, message);
//    }
//}


//public class UrgentEmailNotification : INotification
//{
//    EmailNotification _emailNotification = new();
//    public void Send(string to, string message) =>
//        _emailNotification.Send(to, $"[URGENT] {message}");
//}



//public class UrgentSmsNotification : INotification//: SmsNotification
//{
//    SmsNotification smsNotification = new();
//    public void Send(string to, string message) => smsNotification.Send(to, $"[URGENT] {message}");
//}
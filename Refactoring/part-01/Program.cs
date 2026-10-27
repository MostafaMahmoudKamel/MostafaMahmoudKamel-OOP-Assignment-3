using RefactoringLab;

var shipping = new ShippingCostCalculator();
Aramex armex = new Aramex();
Console.WriteLine($"Aramex 2kg → {shipping.Calculate(armex,2)}");
Console.WriteLine($"FedEx 2kg → {shipping.Calculate(new FedEx(),2)}");
//new added Shipping company
Console.WriteLine($"Fast 2kg → {shipping.Calculate(new Fast(),2)}");
Console.WriteLine();

SqlOrderRepository sqlOrderRepository = new();
SmtpEmailSender smtpEmailSender = new();
var processor = new OrderProcessor(smtpEmailSender,sqlOrderRepository);
processor.Process(1001, "customer@example.com");
Console.WriteLine();
new ScheduledNotification(new EmailNotification() ,sendAt:DateTime.Today)
.Send("customer@example.com", "Your order ships tomorrow");

new UrgentNotification(new SmsNotification())
    .Send("+201000000000", "OTP 4821");


//new UrgentScheduledEmailNotification { SendAt = DateTime.Today.AddHours(18) }
//    .Send("customer@example.com", "Your order ships tomorrow");
//new UrgentSmsNotification()
//    .Send("+201000000000", "OTP 4821");

TelgramNotification tNotification = new();
tNotification.Send("Mostafa kamel", "hallo y broooo");

    
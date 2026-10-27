namespace RefactoringLab.Part02.Enrollment;

//facade design pattern 
public class EnrollmentFacade
{
    private readonly PaymentGateway _paymentGateway; 
    private readonly SeatInventory _seatInventory;
    private readonly InvoiceGenerator _invoiceGenerator;
    private readonly EmailService _emailService;

    public EnrollmentFacade(PaymentGateway paymentGateway, SeatInventory seatInventory, InvoiceGenerator invoiceGenerator, EmailService emailService)
    {
        _paymentGateway = paymentGateway;
        _seatInventory = seatInventory;
        _invoiceGenerator = invoiceGenerator;
        _emailService = emailService;
    }

    public void Enroll(string studentId, string itemId, decimal amount)
    {
        _seatInventory.Reserve(itemId, studentId);
        _paymentGateway.Charge(studentId, amount);
        var invoiceId=_invoiceGenerator.Create(studentId, amount);
        _emailService.Send(studentId, "Enrollment Success", $"Your invoice ID is {invoiceId}");
    }
}
public class PaymentGateway
{
    public void Charge(string studentId, decimal amount) =>
        Console.WriteLine($"charge {studentId}: {amount}");
}

public class SeatInventory
{
    public void Reserve(string itemId, string studentId) =>
        Console.WriteLine($"reserve seat {itemId} for {studentId}");
}

public class InvoiceGenerator
{
    public string Create(string studentId, decimal amount)
    {
        var invoiceId = $"INV-{studentId}-{amount}";
        Console.WriteLine($"invoice {invoiceId}");
        return invoiceId;
    }
}

public class EmailService
{
    public void Send(string studentId, string subject, string body) =>
        Console.WriteLine($"email {studentId}: {subject} / {body}");
}

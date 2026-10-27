using System.Net.Mail;

namespace RefactoringLab;

public interface ISqlOrder
{
    public void Save(int orderId, DateTime processedAt);

}
public interface IsmtpEmailSender 
{
    public void Send(string to, string body);

}
public class OrderProcessor
{
    private readonly IsmtpEmailSender _stmpEmailSender;
    private readonly ISqlOrder _sqlOrder;

    //constructor injection to avoid passing two object null
    public OrderProcessor(IsmtpEmailSender stmpEmailSender, ISqlOrder sqlOrder)
    {
        _stmpEmailSender = stmpEmailSender;
        _sqlOrder = sqlOrder;
    }

    public void Process(int orderId, string customerEmail)
    {

        _sqlOrder.Save(orderId, DateTime.Now);
        _stmpEmailSender.Send(customerEmail, $"Order {orderId} confirmed at {DateTime.Now}");
    }
}

public class SqlOrderRepository:ISqlOrder
{
    public void Save(int orderId, DateTime processedAt) =>
        Console.WriteLine($"[SQL] save order {orderId} @ {processedAt:O}");
}

public class SmtpEmailSender:IsmtpEmailSender
{
    public void Send(string to, string body) =>
        Console.WriteLine($"[SMTP] to={to} body={body}");
}

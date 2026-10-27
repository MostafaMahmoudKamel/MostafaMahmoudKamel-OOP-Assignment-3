namespace RefactoringLab;

public interface ICostCalculator
{
    public decimal Calculate( decimal weightKg);
}
public class Fast : ICostCalculator
{
    public decimal Calculate(decimal weightKg)
    {
        return weightKg * 7;
    }
}
public class Aramex : ICostCalculator
{
    public decimal Calculate( decimal weightKg)
    {
        return weightKg * 12m;
    }
}

public class FedEx : ICostCalculator
{
    public decimal Calculate( decimal weightKg) => weightKg * 15m;
}

public class DHL : ICostCalculator
{
    public decimal Calculate( decimal weightKg) => weightKg * 18m;
   
    
}
public class ShippingCostCalculator
{
    public decimal Calculate(ICostCalculator costCalculator,decimal weightKg)
    {
       return  costCalculator.Calculate(weightKg);
    }

}

namespace BudgetPlanner.Models;

public class CreditCard
{
    public string Name { get; set; } = "Credit";
    public Guid? AccountId { get; set; }
    public decimal CreditLimit { get; set; }
    public decimal Debt { get; set; } // остается всегда меньше кредитного лимита

    public decimal AvailableCredit => CreditLimit - Debt;
}
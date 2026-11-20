namespace BudgetPlanner.Models;

public class Funds
{
    public List<FinancialAccount> Accounts{ get; set; } = new();
    public List<CreditCard> CreditCards { get; set; } = new();
    public List<DebitCard> DebitCards { get; set; } = new();

    public decimal OwnFunds => Accounts.Sum(a => a.Balance);
    public decimal AvailableCredit => CreditCards.Sum(card => card.AvailableCredit);
    public decimal TotalAvailable => OwnFunds + (AvailableCredit > 0? AvailableCredit : 0);
}

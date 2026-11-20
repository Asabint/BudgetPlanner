namespace BudgetPlanner.Models;

public class Funds
{
    public List<FinancialAccount> accounts{ get; set; } = new();
    public List<CreditCard> CreditCards { get; set; } = new();

    public decimal AvailableCredit => CreditCards.Sum(card => card.AvailableCredit);
    public decimal OwnFunds => accounts.Sum(a => a.Balance);
}

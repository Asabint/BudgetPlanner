namespace BudgetPlanner.Models;

public class CreditCard(string cardName = "Unnamed") : Card(cardName)
{
    public decimal CreditLimit;
    public decimal Debt;
    public decimal AvailableCredit => CreditLimit - Debt;
}
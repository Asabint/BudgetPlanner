namespace BudgetPlanner.Models;

public class DebitCard(string cardName = "Unnamed") : Card(cardName)
{
    public decimal Amount { get; set; } = 0;
}

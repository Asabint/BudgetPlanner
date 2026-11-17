namespace BudgetPlanner.Models;

public class Card(string cardName = "Unnamed")
{
    public string CardName { get; set; } = cardName;
}
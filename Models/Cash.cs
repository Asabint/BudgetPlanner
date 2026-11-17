namespace BudgetPlanner.Models;

public class Cash
{
    public string Source { get; set; } = "Unknown";
    public decimal Amount { get; set; }

    public Cash(string source, decimal amount)
    {
        Source = source;
        Amount = amount;
    }
}

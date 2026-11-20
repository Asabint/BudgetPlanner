using BudgetPlanner.Models.Enums;

namespace BudgetPlanner.Models;

public class FinancialAccount
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "Unnamed";
    public FinancialAccountType Type { get; set; }
    public decimal Balance { get; set; }
}

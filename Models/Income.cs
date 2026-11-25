
using BudgetPlanner.Models.Enums;

namespace BudgetPlanner.Models;

public class Income
{
    public string Name { get; set; } = "Unknown";
    public decimal Amount { get; set; }
    public FinancialFrequency Frequency { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public List<IncomeAmountChange> AmountChanges { get; set; } = new();

    public decimal GetAmountForDate(DateTime date)
    {
        var lastAmount = this.AmountChanges
            .Where(change => change.EffectiveDate <= date.Date)
            .OrderByDescending(change => change.EffectiveDate)
            .FirstOrDefault();

        return lastAmount?. Amount ?? Amount;
    }
}

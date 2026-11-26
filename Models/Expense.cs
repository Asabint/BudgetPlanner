using BudgetPlanner.Models.Enums;

namespace BudgetPlanner.Models;

public class Expense
{
    public string Name { get; set; } = string.Empty;

    public decimal Amount
    {
        get;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
            field = value;
        }
    }
    public FinancialFrequency Frequency
    {
        get;
        set
        {
            if (!Enum.IsDefined(typeof(FinancialFrequency), value))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
                
            field = value;
            
            if (value == FinancialFrequency.Once)
            {
                EndDate = null;
            }
        }
    }

    public DateTime StartDate
    {
        get;
        set
        {
            if (value == default)
            {
                throw new ArgumentOutOfRangeException(nameof(StartDate));
            }
            if (EndDate.HasValue && value.Date > EndDate.Value.Date)
            {
                throw new ArgumentOutOfRangeException(nameof(StartDate));
            }
            field = value.Date;
        }
    }

    public DateTime? EndDate
    {
        get;
        set
        {
            if (Frequency == FinancialFrequency.Once)
            {
                field = null;
                return;
            }
            if (value.HasValue && value.Value.Date < StartDate.Date)
            {
                throw new ArgumentOutOfRangeException(nameof(EndDate));
            }
            field = value?.Date;
        }
    }

    public bool IsMandatory { get; set; }

    public FinancialAccount? Accaunt {  get; set; }

    public Expense(
        decimal amount,
        FinancialFrequency frequency,
        DateTime startDate,
        DateTime? endDate = null,
        bool isMandatory = false,
        string name = "",
        FinancialAccount? accaunt = null)
    {
        Name = name;
        Amount = amount;
        Frequency = frequency;
        StartDate = startDate;
        EndDate = endDate;
        IsMandatory = isMandatory;
        Accaunt = accaunt;
    }
}

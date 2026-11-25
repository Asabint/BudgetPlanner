using BudgetPlanner.Models.Enums;

namespace BudgetPlanner.Models;

public class Expense
{
    private decimal _amount;

    public string Name { get; set; } = string.Empty;

    public decimal Amount
    {
        get => _amount;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
            _amount = value;
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
            if (EndDate.HasValue && value.Date > EndDate.Value.Date)
            {
                throw new ArgumentOutOfRangeException(nameof(StartDate));
            }
            field = value.Date;
        }
    } = DateTime.Now.Date;

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


}

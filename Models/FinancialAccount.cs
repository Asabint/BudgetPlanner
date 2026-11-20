// FinancialAccount — модель отдельного источника собственных денежных средств пользователя, содержащая исходный остаток и тип хранения средств.

using BudgetPlanner.Models.Enums;

namespace BudgetPlanner.Models;

public class FinancialAccount
{
    private decimal _balance;

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "Unnamed";
    public FinancialAccountType Type { get; set; }
    public decimal Balance
    {
        get => _balance; set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Balance cannot be negative.");
            }
            _balance = value;
        }
    }

}

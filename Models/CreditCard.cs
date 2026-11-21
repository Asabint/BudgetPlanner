namespace BudgetPlanner.Models;

public class CreditCard
{
    private decimal _creditLimit;
    private decimal _debt;

    public string Name { get; set; } = "Credit";
    public Guid? AccountId { get; set; }
    public decimal CreditLimit 
    {
        get => _creditLimit;
        set 
        {
            if (value< 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value), "Credit limit cannot be negative.");
            }
            else if (value < _debt)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value), "Credit limit cannot be less than debt.");
            }
            _creditLimit = value;
        }
    }
    public decimal Debt
    {

        get => _debt;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value), "Debt cannot be negative.");
            }
            else if (value > _creditLimit)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value), "Debt cannot be greater than credit limit.");
            }
            _debt = value;
        }
    }

    public decimal AvailableCredit => CreditLimit - Debt;
}
namespace BudgetPlanner.Models;

public class Funds
{
    public List<Cash> Cashes { get; set; } = new();
    public List<DebitCard> DebitCards { get; set; } = new();
    public List<CreditCard> CreditCards { get; set; } = new();

    public bool IncludeCredit { get; set; } = true;

    public decimal CashBalance => Cashes.Sum(cash => cash.Amount);
    public decimal DebitBalance => DebitCards.Sum(card => card.Amount);
    public decimal AvailableCredit => CreditCards.Sum(card => card.AvailableCredit);


    public decimal OwnFunds => CashBalance + DebitBalance;
    public decimal TotalAvailable => OwnFunds + (IncludeCredit && AvailableCredit>0 ? AvailableCredit : 0);


}

namespace BudgetPlanner.Models;

public class Funds
{
    public List<FinancialAccount> Accounts{ get; set; } = new();
    public List<CreditCard> CreditCards { get; private set; } = new();
    public List<DebitCard> DebitCards { get; private set; } = new();

    public decimal OwnFunds => Accounts.Sum(a => a.Balance);
    public decimal AvailableCredit => CreditCards.Sum(card => card.AvailableCredit);
    public decimal TotalAvailable => OwnFunds + (AvailableCredit > 0? AvailableCredit : 0);

    public void AddDebitCard(string cardName, FinancialAccount account)
    {
        ArgumentNullException.ThrowIfNull(account);

        if (!Accounts.Any(a => a.Id == account.Id))
        {
            throw new ArgumentException("Этот счет не был добавлен в список Funds", nameof(account));
        }

        if (DebitCards.Any(c => c.AccountId == account.Id) || CreditCards.Any(c => c.AccountId == account.Id))
        {
            throw new ArgumentOutOfRangeException(nameof(account), "к этому счету уже привязана карта");
        }
        var card = new DebitCard();
        card.Name = cardName;
        card.AccountId = account.Id;
        DebitCards.Add(card);
    }

    public void AddCreditCard(string cardName, FinancialAccount account)
    {
        ArgumentNullException.ThrowIfNull(account);

        if (!Accounts.Any(a => a.Id == account.Id))
        {
            throw new ArgumentException("Этот счет не был добавлен в список Funds", nameof(account));
        }

        if (DebitCards.Any(c => c.AccountId == account.Id) || CreditCards.Any(c => c.AccountId == account.Id))
        {
            throw new ArgumentOutOfRangeException(nameof(account), "к этому счету уже привязана карта");
        }
        var card = new CreditCard();
        card.Name = cardName;
        card.AccountId = account.Id;
        CreditCards.Add(card);
    }
}

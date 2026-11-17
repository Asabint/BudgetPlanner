using BudgetPlanner.Models;
using System.Diagnostics;

DebitCard card1 = new DebitCard
{
    CardName = "Main",
    Amount = 1000,
};

DebitCard card2 = new DebitCard
{
    CardName = "Support",
    Amount = 100,
};

CreditCard credit1 = new CreditCard
{
    CardName = "Bank1",
   CreditLimit = 10000,
   Debt = 1000,
};

CreditCard credit2 = new CreditCard
{
    CardName = "Bank2",
    CreditLimit = 1000,
    Debt = 999,
};

Cash homeCash = new("My home", 111);

Funds account1 = new Funds();

account1.DebitCards.Add(card1);
account1.DebitCards.Add(card2);

account1.CreditCards.Add(credit1);
account1.CreditCards.Add(credit2);

account1.Cashes.Add(homeCash);

account1.IncludeCredit = true;

Debug.WriteLine($"Наличные: {account1.CashBalance}");
Debug.WriteLine($"Дебетовые: {account1.DebitBalance} ₽");
Debug.WriteLine($"Кредитные: {account1.AvailableCredit} ₽");
Debug.WriteLine($"Свои средства: {account1.OwnFunds} ₽");
Debug.WriteLine($"Общее: {account1.TotalAvailable} ₽");
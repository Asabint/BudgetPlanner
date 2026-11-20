using BudgetPlanner.Models;
using System.Diagnostics;

FinancialAccount tAccount = new FinancialAccount
{
    Name = "T-Bank main",
    Type = BudgetPlanner.Models.Enums.FinancialAccountType.Bank,
    Balance = 1000,
};

FinancialAccount wallet = new FinancialAccount
{
    Name = "My wallet",
    Type = BudgetPlanner.Models.Enums.FinancialAccountType.Cash,
    Balance = 2000,
};

DebitCard dCard = new DebitCard
{
    Name = "T-Debit",
    AccountId = tAccount.Id,
};

CreditCard cCard = new CreditCard
{
    Name = "T-credit",
    AccountId = tAccount.Id,
    CreditLimit = 10000,
    Debt = 0,
};

Funds funds = new Funds();

funds.accounts.Add(wallet);
funds.accounts.Add(tAccount);

funds.CreditCards.Add(cCard);

Console.WriteLine($"Имя первого счета {tAccount.Name}");
Console.WriteLine($"Тип первого счета {tAccount.Type}");
Console.WriteLine($"ИД первого счета {tAccount.Id}");
Console.WriteLine($"Балланс первого счета {tAccount.Balance}");

Console.WriteLine("\n");

Console.WriteLine($"Имя второго счета {wallet.Name}");
Console.WriteLine($"Тип второго счета {wallet.Type}");
Console.WriteLine($"ИД второго счета {wallet.Id}");
Console.WriteLine($"Балланс второго счета {wallet.Balance}");

Console.WriteLine("\n");

Console.WriteLine($"Доступный кредитный лимит {funds.AvailableCredit}");
Console.WriteLine($"Свои средства {funds.OwnFunds}");

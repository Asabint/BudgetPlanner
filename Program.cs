using BudgetPlanner.Models;
using BudgetPlanner.Models.Enums;

/*

var creditCard = new CreditCard
{
    Name = "Credit card",
    CreditLimit = 50000,
    Debt = 15000
};

Console.WriteLine("Корректные значения:");
Console.WriteLine($"Название: {creditCard.Name}");
Console.WriteLine($"Кредитный лимит: {creditCard.CreditLimit}");
Console.WriteLine($"Долг: {creditCard.Debt}");
Console.WriteLine($"Доступный кредит: {creditCard.AvailableCredit}");

Console.WriteLine();



var emptyCard = new CreditCard
{
    CreditLimit = 0,
    Debt = 0
};

Console.WriteLine("Проверка нулевых значений:");
Console.WriteLine($"Кредитный лимит: {emptyCard.CreditLimit}");
Console.WriteLine($"Долг: {emptyCard.Debt}");
Console.WriteLine($"Доступный кредит: {emptyCard.AvailableCredit}");

Console.WriteLine();


TestInvalidValue("Отрицательный кредитный лимит", () =>
{
    var card = new CreditCard
    {
        CreditLimit = -1000
    };
});

TestInvalidValue("Отрицательный долг", () =>
{
    var card = new CreditCard
    {
        CreditLimit = 10000,
        Debt = -1000
    };
});

TestInvalidValue("Долг выше кредитного лимита", () =>
{
    var card = new CreditCard
    {
        CreditLimit = 10000,
        Debt = 15000
    };
});

TestInvalidValue("Уменьшение лимита ниже текущего долга", () =>
{
    var card = new CreditCard
    {
        CreditLimit = 10000,
        Debt = 8000
    };

    card.CreditLimit = 5000;
});*/

static void TestInvalidValue(string testName, Action action)
{
    try
    {
        action();
        Console.WriteLine($"{testName} — исключение не возникло.");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"Исключение: {testName}\nСообщение: {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Исключение: {testName}\nСообщение: {ex.Message}");
    }
}

var funds = new Funds();

var acc1 = new FinancialAccount
{
    Name = "Test1",
    Type = FinancialAccountType.Bank,
};

var acc2 = new FinancialAccount
{
    Name = "Test2",
    Type = FinancialAccountType.Bank,
};

var acc3 = new FinancialAccount
{
    Name = "Test3",
    Type = FinancialAccountType.Bank,
};

funds.Accounts.Add( acc1 );
funds.Accounts.Add( acc2 );


TestInvalidValue("Card A - acc1", () =>
{
    funds.AddDebitCard("A", acc1);
    Console.WriteLine("Add card A");
});
TestInvalidValue("Card B - acc2", () =>
{
    funds.AddCreditCard("B", acc2);
    Console.WriteLine("Add card B");
});
TestInvalidValue("Card C - acc1", () =>
{
    funds.AddDebitCard("C", acc1);
    Console.WriteLine("Add card C");
});
TestInvalidValue("Card D - acc2", () =>
{
    funds.AddCreditCard("D", acc2);
    Console.WriteLine("Add card D");
});
TestInvalidValue("Card E - acc1", () =>
{
    funds.AddCreditCard("E", acc1);
    Console.WriteLine("Add card E");
});
TestInvalidValue("Card F - acc3", () =>
{
    funds.AddCreditCard("F", acc3);
    Console.WriteLine("Add card F");
});
TestInvalidValue("Card G - acc2", () =>
{
    funds.AddDebitCard("G", acc2);
    Console.WriteLine("Add card G");
});
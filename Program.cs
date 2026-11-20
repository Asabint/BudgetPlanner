using BudgetPlanner.Models;
using BudgetPlanner.Models.Enums;

Income salary = new Income
{
    Name = "Зарплата",
    Amount = 60000m,
    Frequency = IncomeFrequency.BiWeekly,
    StartDate = new DateTime(2026, 11, 20),
    EndDate = null,
    IsExpected = false
};

Income bonus = new Income
{
    Name = "Премия",
    Amount = 15000m,
    Frequency = IncomeFrequency.Once,
    StartDate = new DateTime(2026, 12, 25),
    IsExpected = true
};

salary.AmountChanges.Add(new IncomeAmountChange
{
    Amount = 100500,
    EffectiveDate = new DateTime(2026, 12, 1)
}); 

salary.AmountChanges.Add(new IncomeAmountChange
{
    Amount = 120000,
    EffectiveDate = new DateTime(2026, 12, 31)
});

salary.AmountChanges.Add(new IncomeAmountChange
{
    Amount = 200000,
    EffectiveDate = new DateTime(2027, 02, 01)
});

salary.AmountChanges.Add(new IncomeAmountChange
{
    Amount = 150000,
    EffectiveDate = new DateTime(2027, 03, 03)
});

Console.WriteLine($"{salary.Name}: {salary.Amount} ₽");
Console.WriteLine($"Периодичность: {salary.Frequency}");
Console.WriteLine($"Начало: {salary.StartDate:d}");
Console.WriteLine($"История изменеий: {salary.AmountChanges.Count}\n");

DateTime date = DateTime.Now;

for ( int i = 0; i < 10; i++)
{
    date = date.AddMonths(1);
    Console.WriteLine($"Зарплата на {date}: {salary.GetAmountForDate(date)}");
}

Console.WriteLine();

Console.WriteLine($"{bonus.Name}: {bonus.Amount} ₽");
Console.WriteLine($"Ожидаемый: {bonus.IsExpected}");

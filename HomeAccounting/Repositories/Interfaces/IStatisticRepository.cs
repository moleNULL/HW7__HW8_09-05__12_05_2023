using HomeAccounting.Models;

namespace HomeAccounting.Repositories.Interfaces
{
    public interface IStatisticRepository
    {
        Task<IEnumerable<ExpensesStatisticViewModel>> GetExpenseStatisticAsync(int year, int month);
    }
}
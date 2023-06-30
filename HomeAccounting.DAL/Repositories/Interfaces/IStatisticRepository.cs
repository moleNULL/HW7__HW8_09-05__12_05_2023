using HomeAccounting.DAL.Entities;

namespace HomeAccounting.DAL.Repositories.Interfaces
{
    public interface IStatisticRepository
    {
        Task<IEnumerable<ExpensesStatisticEntity>> GetExpenseStatisticAsync(int year, int month);
    }
}
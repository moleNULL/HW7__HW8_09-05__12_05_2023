using HomeAccountingDAL.Entities;

namespace HomeAccountingDAL.Repositories.Interfaces
{
    public interface IStatisticRepository
    {
        Task<IEnumerable<ExpensesStatisticViewModelEntity>> GetExpenseStatisticAsync(int year, int month);
    }
}
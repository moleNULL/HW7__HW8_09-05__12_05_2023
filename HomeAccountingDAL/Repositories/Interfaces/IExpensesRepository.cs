using HomeAccountingDAL.Entities;

namespace HomeAccountingDAL.Repositories.Interfaces
{
    public interface IExpensesRepository
    {
        Task<IEnumerable<ExpensesViewModelEntity>> GetExpensesAsync();
    }
}
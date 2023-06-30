using HomeAccounting.DAL.Entities;

namespace HomeAccounting.DAL.Repositories.Interfaces
{
    public interface IExpensesRepository
    {
        Task<IEnumerable<ExpensesViewModelEntity>> GetExpensesAsync();
    }
}
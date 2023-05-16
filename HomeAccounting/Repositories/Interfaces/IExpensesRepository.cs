using HomeAccounting.Models;

namespace HomeAccounting.Repositories.Interfaces
{
    public interface IExpensesRepository
    {
        Task<IEnumerable<ExpensesViewModel>> GetExpensesAsync();
    }
}
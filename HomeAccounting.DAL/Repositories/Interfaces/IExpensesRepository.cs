using HomeAccounting.DAL.Models.DataModels;

namespace HomeAccounting.DAL.Repositories.Interfaces
{
    public interface IExpensesRepository
    {
        Task<IEnumerable<ExpensesDataModel>> GetExpensesAsync();
    }
}
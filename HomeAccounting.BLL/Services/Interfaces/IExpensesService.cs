using HomeAccounting.BLL.Models;

namespace HomeAccounting.BLL.Services.Interfaces
{
    public interface IExpensesService
    {
        Task<IEnumerable<ExpensesModel>> GetExpensesAsync();
    }
}

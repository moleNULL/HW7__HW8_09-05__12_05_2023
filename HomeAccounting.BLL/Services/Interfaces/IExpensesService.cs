using HomeAccounting.BLL.Dtos;

namespace HomeAccounting.BLL.Services.Interfaces
{
    public interface IExpensesService
    {
        Task<IEnumerable<ExpensesViewModelDto>> GetExpensesAsync();
    }
}

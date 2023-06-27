using HomeAccountingBLL.Dtos;

namespace HomeAccountingBLL.Services.Interfaces
{
    public interface IExpensesService
    {
        Task<IEnumerable<ExpensesViewModelDto>> GetExpensesAsync();
    }
}

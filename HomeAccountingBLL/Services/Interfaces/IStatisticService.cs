using HomeAccountingBLL.Dtos;

namespace HomeAccountingBLL.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<IEnumerable<ExpensesStatisticViewModelDto>> GetExpenseStatisticAsync(int year, int month);
    }
}

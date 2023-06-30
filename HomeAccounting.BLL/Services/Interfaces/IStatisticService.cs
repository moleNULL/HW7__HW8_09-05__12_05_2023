using HomeAccounting.BLL.Dtos;

namespace HomeAccounting.BLL.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<ExpensesStatisticViewModelDto> GetExpenseStatisticAsync(int? year, int? month);
    }
}

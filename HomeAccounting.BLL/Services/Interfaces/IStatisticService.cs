using HomeAccounting.BLL.Models;

namespace HomeAccounting.BLL.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<StatisticCompositeModel> GetExpenseStatisticAsync(int? year, int? month);
    }
}

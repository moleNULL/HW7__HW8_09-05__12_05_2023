using HomeAccounting.DAL.Models.DataModels;

namespace HomeAccounting.DAL.Repositories.Interfaces
{
    public interface IStatisticRepository
    {
        Task<IEnumerable<StatisticDataModel>> GetExpenseStatisticAsync(int year, int month);
    }
}
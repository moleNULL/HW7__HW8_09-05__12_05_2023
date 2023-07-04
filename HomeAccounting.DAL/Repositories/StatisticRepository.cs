using HomeAccounting.DAL.Models.DataModels;
using HomeAccounting.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HomeAccounting.DAL.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly ILogger<StatisticRepository> _logger;
        private readonly ApplicationDbContext _dbContext;

        public StatisticRepository(ILogger<StatisticRepository> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<StatisticDataModel>> GetExpenseStatisticAsync(int year, int month)
        {
            var monthStatistic = await (from e in _dbContext.Expenses
                                        join c in _dbContext.Categories on e.CategoryId equals c.Id
                                        where e.Date.Month == month && e.Date.Year == year
                                        group e by e.Category.Name into g
                                        select new StatisticDataModel
                                        {
                                            CategoryName = g.Key,
                                            TotalExpenses = g.Sum(e => e.Cost)
                                        })
                                        .ToListAsync();


            _logger.LogInformation($"Returned {monthStatistic.Count} rows");

            return monthStatistic;
        }
    }
}

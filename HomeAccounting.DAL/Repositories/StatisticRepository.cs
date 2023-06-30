using HomeAccounting.DAL.Entities;
using HomeAccounting.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.DAL.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StatisticRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ExpensesStatisticEntity>> GetExpenseStatisticAsync(int year, int month)
        {
            var monthStatistic = from e in _dbContext.Expenses
                                 join c in _dbContext.Categories on e.CategoryId equals c.Id
                                 where e.Date.Month == month && e.Date.Year == year
                                 group e by e.Category.Name into g
                                 select new ExpensesStatisticEntity
                                 {
                                     CategoryName = g.Key,
                                     TotalExpenses = g.Sum(e => e.Cost)
                                 };

            return await monthStatistic.ToListAsync();
        }
    }
}

using HomeAccounting.DAL.Models.DataModels;
using HomeAccounting.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HomeAccounting.DAL.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly ILogger<ExpensesRepository> _logger;
        private readonly ApplicationDbContext _dbContext;

        public ExpensesRepository(ILogger<ExpensesRepository> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ExpensesDataModel>> GetExpensesAsync()
        {
            var expenses = await (from e in _dbContext.Expenses
                                  join c in _dbContext.Categories on e.CategoryId equals c.Id
                                  select new ExpensesDataModel
                                  {
                                      Id = e.Id,
                                      Name = e.Name,
                                      Cost = e.Cost,
                                      Date = e.Date,
                                      CategoryName = c.Name,
                                      Comment = e.Comment
                                  })
                                  .ToListAsync();

            _logger.LogInformation($"Returned {expenses.Count} rows");

            return expenses;
        }
    }
}

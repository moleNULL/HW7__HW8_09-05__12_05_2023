using HomeAccounting.DAL.Entities;
using HomeAccounting.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.DAL.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ExpensesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ExpensesViewModelEntity>> GetExpensesAsync()
        {
            var expenses = from e in _dbContext.Expenses
                           join c in _dbContext.Categories on e.CategoryId equals c.Id
                           select new ExpensesViewModelEntity
                           {
                               Id = e.Id,
                               Name = e.Name,
                               Cost = e.Cost,
                               Date = e.Date,
                               CategoryName = c.Name,
                               Comment = e.Comment
                           };

            return await expenses.ToListAsync();
        }
    }
}

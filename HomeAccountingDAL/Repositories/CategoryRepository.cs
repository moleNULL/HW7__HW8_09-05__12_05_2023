using HomeAccountingDAL.Entities;
using HomeAccountingDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeAccountingDAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<int> AddCategoryAsync(CategoryEntity category)
        {
            await _dbContext.Categories.AddAsync(category);
            int countAdded = await _dbContext.SaveChangesAsync();

            return countAdded;
        }

        public async Task<int> UpdateCategoriesAsync(IEnumerable<CategoryEntity> categories)
        {
            var modifiedCategories = categories.Where(category =>
                                            _dbContext.Categories.Any(dbCategory =>
                                                dbCategory.Id == category.Id && dbCategory.Name != category.Name));

            if (modifiedCategories.Any())
            {
                _dbContext.Categories.UpdateRange(modifiedCategories);
                int countUpdated = await _dbContext.SaveChangesAsync();

                return countUpdated;
            }

            return 0;
        }

        public async Task<int> DeleteCategoriesAsync(IEnumerable<int> categoryIds)
        {
            foreach (int categoryId in categoryIds)
            {
                var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

                if (category is not null)
                {
                    _dbContext.Remove(category);
                }
            }

            int countDeleted = await _dbContext.SaveChangesAsync();

            return countDeleted;
        }
    }
}

using HomeAccounting.Data;
using HomeAccounting.Data.Entities;
using HomeAccounting.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.Repositories
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
            int count = await _dbContext.SaveChangesAsync();

            return count;
        }

        public async Task<int> UpdateCategoriesAsync(IEnumerable<CategoryEntity> categories)
        {
            var modifiedCategories = categories
                                        .Where(category => _dbContext.Categories
                                            .Any(dbCategory => dbCategory.Id == category.Id 
                                                                && dbCategory.Name != category.Name));

            if (modifiedCategories is not null)
            {
                _dbContext.Categories.UpdateRange(modifiedCategories);
                int count = await _dbContext.SaveChangesAsync();

                return count;
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

            int count = await _dbContext.SaveChangesAsync();

            return count;
        }
    }
}

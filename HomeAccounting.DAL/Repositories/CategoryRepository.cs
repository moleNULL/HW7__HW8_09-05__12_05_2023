using HomeAccounting.DAL.Entities;
using HomeAccounting.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HomeAccounting.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ILogger<CategoryRepository> _logger;
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ILogger<CategoryRepository> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategoriesAsync()
        {
            var categoriesEntity = await _dbContext.Categories.ToListAsync();

            _logger.LogInformation($"Returned {categoriesEntity.Count} rows");

            return categoriesEntity;
        }

        public async Task AddCategoryAsync(CategoryEntity category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Inserted row with id: {category.Id}");
        }

        //_Batch_ batch operations in SQL | UpdateCategoriesBatchAsync()
        public async Task UpdateCategoriesAsync(IEnumerable<CategoryEntity> categories)
        {
            var modifiedCategories = categories.Where(category =>
                                            _dbContext.Categories.Any(dbCategory =>
                                                dbCategory.Id == category.Id && dbCategory.Name != category.Name));

            int countUpdated = 0;

            if (modifiedCategories.Any())
            {
                _dbContext.Categories.UpdateRange(modifiedCategories);
                countUpdated = await _dbContext.SaveChangesAsync();
            }

            _logger.LogInformation($"Rows updated: {countUpdated}");
        }

        public async Task<int> DeleteCategoriesAsync(IEnumerable<int> categoryIds)
        {
            //Where
            foreach (int categoryId in categoryIds)
            {
                // Single
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

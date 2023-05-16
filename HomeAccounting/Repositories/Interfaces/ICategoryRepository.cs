using HomeAccounting.Data.Entities;

namespace HomeAccounting.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryEntity>> GetCategoriesAsync();
        Task<int> AddCategoryAsync(CategoryEntity category);
        Task<int> UpdateCategoriesAsync(IEnumerable<CategoryEntity> categories);
        Task<int> DeleteCategoriesAsync(IEnumerable<int> categoryIds);
    }
}
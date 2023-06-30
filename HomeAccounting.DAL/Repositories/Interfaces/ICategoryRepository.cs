using HomeAccounting.DAL.Entities;

namespace HomeAccounting.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryEntity>> GetCategoriesAsync();
        Task AddCategoryAsync(CategoryEntity category);
        Task UpdateCategoriesAsync(IEnumerable<CategoryEntity> categories);
        Task<int> DeleteCategoriesAsync(IEnumerable<int> categoryIds);
    }
}
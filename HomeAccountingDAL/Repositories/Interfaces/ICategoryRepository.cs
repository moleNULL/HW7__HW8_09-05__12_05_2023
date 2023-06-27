using HomeAccountingDAL.Entities;

namespace HomeAccountingDAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryEntity>> GetCategoriesAsync();
        Task<int> AddCategoryAsync(CategoryEntity category);
        Task<int> UpdateCategoriesAsync(IEnumerable<CategoryEntity> categories);
        Task<int> DeleteCategoriesAsync(IEnumerable<int> categoryIds);
    }
}
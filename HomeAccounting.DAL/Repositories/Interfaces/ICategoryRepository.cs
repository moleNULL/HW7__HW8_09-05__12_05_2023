using HomeAccounting.DAL.Models.Entities;

namespace HomeAccounting.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryEntity>> GetCategoriesAsync();
        Task AddCategoryAsync(CategoryEntity category);
        Task UpdateCategoriesAsync(IEnumerable<CategoryEntity> categories);
        Task DeleteCategoriesAsync(IEnumerable<int> categoryIds);
    }
}
using HomeAccounting.BLL.Dtos;

namespace HomeAccounting.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task AddCategoryAsync(CategoryDto category);
        Task UpdateCategoriesAsync(IEnumerable<CategoryDto> categories);
        Task<int> DeleteCategoriesAsync(IEnumerable<int> categoryIds);
    }
}

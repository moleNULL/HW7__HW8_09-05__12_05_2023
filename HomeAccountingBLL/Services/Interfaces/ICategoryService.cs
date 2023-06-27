using HomeAccountingBLL.Dtos;

namespace HomeAccountingBLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<int> AddCategoryAsync(CategoryDto category);
        Task<int> UpdateCategoriesAsync(IEnumerable<CategoryDto> categories);
        Task<int> DeleteCategoriesAsync(IEnumerable<int> categoryIds);
    }
}

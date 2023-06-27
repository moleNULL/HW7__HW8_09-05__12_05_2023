using AutoMapper;
using HomeAccountingBLL.Dtos;
using HomeAccountingBLL.Services.Interfaces;
using HomeAccountingDAL.Entities;
using HomeAccountingDAL.Repositories.Interfaces;

namespace HomeAccountingBLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task<int> AddCategoryAsync(CategoryDto category)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(category);

            return _categoryRepository.AddCategoryAsync(categoryEntity);
        }

        public Task<int> DeleteCategoriesAsync(IEnumerable<int> categoryIds)
        {
            return _categoryRepository.DeleteCategoriesAsync(categoryIds);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity);

            return categoriesDto;
        }

        public Task<int> UpdateCategoriesAsync(IEnumerable<CategoryDto> categories)
        {
            var categoriesEntity = _mapper.Map<IEnumerable<CategoryEntity>>(categories);

            return _categoryRepository.UpdateCategoriesAsync(categoriesEntity);
        }
    }
}

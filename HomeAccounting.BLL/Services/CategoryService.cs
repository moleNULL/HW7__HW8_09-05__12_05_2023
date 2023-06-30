using AutoMapper;
using HomeAccounting.BLL.Dtos;
using HomeAccounting.BLL.Services.Interfaces;
using HomeAccounting.DAL.Entities;
using HomeAccounting.DAL.Repositories.Interfaces;

namespace HomeAccounting.BLL.Services
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

        public async Task AddCategoryAsync(CategoryDto category)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(category);
            await _categoryRepository.AddCategoryAsync(categoryEntity);
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

        public async Task UpdateCategoriesAsync(IEnumerable<CategoryDto> categories)
        {
            var categoriesEntity = _mapper.Map<IEnumerable<CategoryEntity>>(categories);

            await _categoryRepository.UpdateCategoriesAsync(categoriesEntity);
        }
    }
}

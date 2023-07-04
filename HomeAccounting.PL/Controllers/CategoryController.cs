using AutoMapper;
using HomeAccounting.BLL.Models.Dtos;
using HomeAccounting.BLL.Services.Interfaces;
using HomeAccounting.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.PL.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categoriesDto = await _categoryService.GetCategoriesAsync();
            var categories = _mapper.Map<IEnumerable<Category>>(categoriesDto);

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> AddCategoryPage()
        {
            var categoriesDto = await _categoryService.GetCategoriesAsync();
            var categories = _mapper.Map<IEnumerable<Category>>(categoriesDto);

            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryPage(Category category)
        {
            var categoryDto = _mapper.Map<CategoryDto>(category);
            await _categoryService.AddCategoryAsync(categoryDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategoryPage()
        {
            var categoriesDto = await _categoryService.GetCategoriesAsync();
            var categories = _mapper.Map<IEnumerable<Category>>(categoriesDto);

            return View("EditCategoryPage", categories);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategoryPage(IEnumerable<Category> categories)
        {
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            await _categoryService.UpdateCategoriesAsync(categoriesDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategoryPage()
        {
            var categoriesDto = await _categoryService.GetCategoriesAsync();
            var categories = _mapper.Map<IEnumerable<Category>>(categoriesDto);

            return View("RemoveCategoryPage", categories);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategoryPage(IEnumerable<int> categoryIds)
        {
            await _categoryService.DeleteCategoriesAsync(categoryIds);

            return RedirectToAction("Index");
        }
    }
}
using AutoMapper;
using HomeAccountingBLL.Dtos;
using HomeAccountingBLL.Services.Interfaces;
using HomeAccountingPL.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccountingPL.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(
            ILogger<CategoryController> logger,
            ICategoryService categoryService,
            IMapper mapper)
        {
            _logger = logger;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categoriesDto = await _categoryService.GetCategoriesAsync();
            var categories = _mapper.Map<IEnumerable<Category>>(categoriesDto);

            _logger.LogInformation($"Returned {categories.Count()} rows");

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categoriesDto = await _categoryService.GetCategoriesAsync();
            var categories = _mapper.Map<IEnumerable<Category>>(categoriesDto);

            _logger.LogInformation($"Returned {categories.Count()} rows");

            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            var categoryDto = _mapper.Map<CategoryDto>(category);
            int count = await _categoryService.AddCategoryAsync(categoryDto);

            _logger.LogInformation($"Rows added: {count}");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var categoriesDto = await _categoryService.GetCategoriesAsync();
            var categories = _mapper.Map<IEnumerable<Category>>(categoriesDto);

            _logger.LogInformation($"Returned {categories.Count()} rows");

            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IEnumerable<Category> categories)
        {
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            int count = await _categoryService.UpdateCategoriesAsync(categoriesDto);

            _logger.LogInformation($"Rows updated: {count}");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            var categoriesDto = await _categoryService.GetCategoriesAsync();
            var categories = _mapper.Map<IEnumerable<Category>>(categoriesDto);

            _logger.LogInformation($"Returned {categories.Count()} rows");

            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(IEnumerable<int> categoryIds)
        {
            int count = await _categoryService.DeleteCategoriesAsync(categoryIds);

            _logger.LogInformation($"Rows deleted: {count}");

            return RedirectToAction("Index");
        }
    }
}